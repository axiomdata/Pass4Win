﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="GitHandling.cs">
//   
// </copyright>
// <summary>
//   Class to interface with the Git Repo
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------
namespace Pass4Win
{
    using System;
    using System.Linq;
    using System.Net.Sockets;

    using LibGit2Sharp;
    using System.IO;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    /// <summary>
    ///     Class to interface with the Git Repo
    /// </summary>
    public class GitHandling : IDisposable
    {
        /// <summary>
        ///     The repo remote location object.
        /// </summary>
        private Repository gitRepo;

        /// <summary>
        ///     The host.
        /// </summary>
        private readonly string host;

        /// <summary>
        ///     The repo location.
        /// </summary>
        private readonly string repoLocation;

        /// <summary>
        ///     External or internal GIT.
        ///     When filled in it's external
        /// </summary>
        private readonly string ExternalGitPath;
        
        /// <summary>
        ///     Connection string when using external git 
        /// </summary>
        private readonly string ConnectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="GitHandling"/> class.
        /// </summary>
        /// <param name="repoLocation">
        /// The repo location.
        /// </param>
        /// <param name="host">
        /// The host.
        /// </param>
        /// <param name="GitLocation">
        /// The full path of the Git executable.
        /// </param>
        public GitHandling(string repoLocation, string host, string GitLocation, string ConnectionString)
        {
            this.repoLocation = repoLocation;
            this.host = host;
            this.ExternalGitPath = GitLocation;
            this.ConnectionString = ConnectionString;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GitHandling"/> class.
        /// </summary>
        /// <param name="repoLocation">
        /// The repo location.
        /// </param>
        /// <param name="host">
        /// The host.
        /// </param>
        public GitHandling(string repoLocation, string host)
        {
            this.repoLocation = repoLocation;
            this.host = host;
        }

        /// <summary>
        ///     The dispose function of this class.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Checks if repo is valid.
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// Sucess <see cref="bool"/>.
        /// </returns>
        public static bool IsValid(string location)
        {
            return Repository.IsValid(location);
        }

        /// <summary>
        /// The check connection.
        /// </summary>
        /// <param name="hostName">
        /// The host name.
        /// </param>
        /// <returns>
        /// Succes or failure <see cref="bool"/>.
        /// </returns>
        public static bool CheckConnection(string hostName)
        {
            Uri hostTest;
            if (Uri.TryCreate(hostName, UriKind.Absolute, out hostTest))
            {
                var client = new TcpClient();
                var client2 = new TcpClient();
                var client3 = new TcpClient();
                try
                {
                    var gitAlive = true;
                    var httpsAlive = true;
                    var SSHAlive = true;

                    // Check Git connection
                    var result = client.BeginConnect(hostTest.Authority, 9418, null, null);
                    result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                    if (!client.Connected)
                    {
                        client.Close();
                        gitAlive = false;
                    }

                    // Check HTTPS
                    var result2 = client2.BeginConnect(hostTest.Authority, 443, null, null);
                    result2.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                    if (!client2.Connected)
                    {
                        client2.Close();
                        httpsAlive = false;
                    }

                    // Check SSH
                    var result3 = client3.BeginConnect(hostTest.Authority, 22, null, null);
                    result3.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                    if (!client3.Connected)
                    {
                        client3.Close();
                        SSHAlive = false;
                    }

                    if (gitAlive || httpsAlive || SSHAlive)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }

            // fail
            return false;
        }

        /// <summary>
        ///     The connect to repo.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool ConnectToRepo()
        {
            if (CheckConnection(this.host) && Repository.IsValid(this.repoLocation))
            {
                if (File.Exists(ExternalGitPath))
                {
                    // nothing to do here as yet
                }
                else
                {
                    try
                    {
                        this.gitRepo = new Repository(this.repoLocation);

                        // Making sure core.autocrlf = true
                        this.gitRepo.Config.Set("core.autocrlf", true);
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private string ExecuteGitCommand(string command)
        {
            ProcessStartInfo gitInfo = new ProcessStartInfo();
            string output = "";
            string error = string.Empty;

            gitInfo.CreateNoWindow = true;
            gitInfo.RedirectStandardError = true;
            gitInfo.RedirectStandardOutput = true;
            gitInfo.UseShellExecute = false;
            gitInfo.FileName = this.ExternalGitPath;

            Process gitProcess = new Process();
            gitInfo.Arguments = command;
            gitInfo.WorkingDirectory = this.repoLocation;

            gitProcess.StartInfo = gitInfo;
            gitProcess.Start();

            using (System.IO.StreamReader myOutput = gitProcess.StandardOutput)
            {
                output = myOutput.ReadToEnd();
            }
            using (System.IO.StreamReader myError = gitProcess.StandardError)
            {
                error = myError.ReadToEnd();

            }

            gitProcess.WaitForExit();
            gitProcess.Close();

            // give the output or the error message
            if (error.Length == 0) return output;
            else return error;
        }

        /// <summary>
        /// The git clone.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// return boolean <see cref="bool"/>.
        /// </returns>
        public bool GitClone(string username, string password)
        {
            if (File.Exists(ExternalGitPath))
            {
                string GitOutput = ExecuteGitCommand("clone " + ConnectionString + " " + repoLocation);
                bool result = Regex.IsMatch(GitOutput, "\\bfatal\\b", RegexOptions.IgnoreCase);
                if (!result)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    Repository.Clone(
                        this.host,
                        this.repoLocation,
                        new CloneOptions
                        {
                            CredentialsProvider =
                                    (url, user, cred) =>
                                    new UsernamePasswordCredentials
                                    {
                                        Username = username,
                                        Password = password
                                    }
                        });
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Get's the latest and greatest from remote
        /// </summary>
        /// <param name="gitUser">
        /// The Git User.
        /// </param>
        /// <param name="gitPass">
        /// The Git Pass.
        /// </param>
        /// <returns>
        /// A boolean that signals success
        /// </returns>
        public bool Fetch(string gitUser, string gitPass)
        {
            if (File.Exists(ExternalGitPath))
            {
                string GitOutput = ExecuteGitCommand("pull");
                bool result = Regex.IsMatch(GitOutput, "\\bfatal\\b", RegexOptions.IgnoreCase);
                if (!result)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    var signature = new Signature(
                        "pass4win",
                        "pull@pass4win.com",
                        new DateTimeOffset(2011, 06, 16, 10, 58, 27, TimeSpan.FromHours(2)));
                    var fetchOptions = new FetchOptions
                    {
                        CredentialsProvider =
                                                   (url, user, cred) =>
                                                   new UsernamePasswordCredentials
                                                   {
                                                       Username = gitUser,
                                                       Password = gitPass
                                                   }
                    };
                    var mergeOptions = new MergeOptions();
                    var pullOptions = new PullOptions { FetchOptions = fetchOptions, MergeOptions = mergeOptions };
                    this.gitRepo.Network.Pull(signature, pullOptions);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// The commit.
        /// </summary>
        /// <param name="fileToCommit">
        /// The file to commit.
        /// </param>
        /// <returns>
        /// Result in boolean <see cref="bool"/>.
        /// </returns>
        public bool Commit(string fileToCommit = null)
        {
            // Stage the file
            if (fileToCommit != null)
            {
                if (File.Exists(ExternalGitPath))
                {
                    string GitOutput = ExecuteGitCommand("git add" + fileToCommit);
                    bool result = Regex.IsMatch(GitOutput, "\\bfatal\\b", RegexOptions.IgnoreCase);
                    if (!result)
                    {
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        this.gitRepo.Stage(fileToCommit);
                    }
                    catch (Exception)
                    {
                        // file most likely already staged. We'll just ignore the error.
                    }
                }
            }

            // Commit
            try
            {
                this.gitRepo.Commit(
                    "password changes", 
                    new Signature("pass4win", "pass4win", DateTimeOffset.Now), 
                    new Signature("pass4win", "pass4win", DateTimeOffset.Now));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Push function.
        /// </summary>
        /// <param name="gitUser">
        /// The git user.
        /// </param>
        /// <param name="gitPass">
        /// The git pass.
        /// </param>
        /// <returns>
        /// Result in boolean <see cref="bool"/>.
        /// </returns>
        public bool Push(string gitUser, string gitPass)
        {
            var tc = this.gitRepo.Diff.Compare<TreeChanges>(
                            this.gitRepo.Branches["origin/master"].Tip.Tree,
                this.gitRepo.Head.Tip.Tree);
            if (!tc.Any())
            {
                return true;
            }

            if (File.Exists(ExternalGitPath))
            {
                string GitOutput = ExecuteGitCommand("git commit -m Pass4Win_commit");
                bool result = Regex.IsMatch(GitOutput, "\\bfatal\\b", RegexOptions.IgnoreCase);
                if (!result)
                {
                    return false;
                }
            }
            else
            {

                var remote = this.gitRepo.Network.Remotes["origin"];
                var options = new PushOptions
                {
                    CredentialsProvider =
                                          (url, user, cred) =>
                                          new UsernamePasswordCredentials
                                          {
                                              Username = gitUser,
                                              Password = gitPass
                                          }
                };
                var pushRefSpec = @"refs/heads/master";
                try
                {
                    this.gitRepo.Network.Push(remote, pushRefSpec, options);
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Removes a file from the Git repo
        /// </summary>
        /// <param name="removeFile">
        /// The filename.
        /// </param>
        /// <returns>
        /// result in boolean<see cref="bool"/>.
        /// </returns>
        public bool RemoveFile(string removeFile)
        {
            if (File.Exists(ExternalGitPath))
            {
                string GitOutput = ExecuteGitCommand("git rm " + removeFile);
                bool result = Regex.IsMatch(GitOutput, "\\bfatal\\b", RegexOptions.IgnoreCase);
                if (!result)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    this.gitRepo.Remove(removeFile);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Free the resources.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.gitRepo.Dispose();
            }
        }
    }
}