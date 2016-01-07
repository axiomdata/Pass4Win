﻿namespace Pass4Win
{
    partial class FrmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            this.txtPassFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGPG = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkboxRemoteRepo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGitUser = new System.Windows.Forms.TextBox();
            this.txtGitPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGitHost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.ExternalGit = new System.Windows.Forms.CheckBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassFolder
            // 
            resources.ApplyResources(this.txtPassFolder, "txtPassFolder");
            this.txtPassFolder.Name = "txtPassFolder";
            this.txtPassFolder.ReadOnly = true;
            this.txtPassFolder.Click += new System.EventHandler(this.TxtPassFolderClick);
            this.txtPassFolder.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPassFolderValidating);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.TxtPassFolderClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "exe";
            this.openFileDialog1.FileName = "gpg2.exe";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.TxtGpgClick);
            // 
            // txtGPG
            // 
            resources.ApplyResources(this.txtGPG, "txtGPG");
            this.txtGPG.Name = "txtGPG";
            this.txtGPG.ReadOnly = true;
            this.txtGPG.Click += new System.EventHandler(this.TxtGpgClick);
            this.txtGPG.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGpgValidating);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // chkboxRemoteRepo
            // 
            resources.ApplyResources(this.chkboxRemoteRepo, "chkboxRemoteRepo");
            this.chkboxRemoteRepo.Name = "chkboxRemoteRepo";
            this.chkboxRemoteRepo.UseVisualStyleBackColor = true;
            this.chkboxRemoteRepo.CheckedChanged += new System.EventHandler(this.ChkboxRemoteRepoCheckedChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtGitUser
            // 
            resources.ApplyResources(this.txtGitUser, "txtGitUser");
            this.txtGitUser.Name = "txtGitUser";
            this.txtGitUser.ReadOnly = true;
            this.txtGitUser.Leave += new System.EventHandler(this.TxtGitUserLeave);
            this.txtGitUser.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGitUserValidating);
            // 
            // txtGitPass
            // 
            resources.ApplyResources(this.txtGitPass, "txtGitPass");
            this.txtGitPass.Name = "txtGitPass";
            this.txtGitPass.ReadOnly = true;
            this.txtGitPass.Leave += new System.EventHandler(this.TxtGitPassLeave);
            this.txtGitPass.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGitPassValidating);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtGitHost
            // 
            resources.ApplyResources(this.txtGitHost, "txtGitHost");
            this.txtGitHost.Name = "txtGitHost";
            this.txtGitHost.ReadOnly = true;
            this.txtGitHost.Leave += new System.EventHandler(this.TxtGitHostLeave);
            this.txtGitHost.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGitHostValidating);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // ExternalGit
            // 
            resources.ApplyResources(this.ExternalGit, "ExternalGit");
            this.ExternalGit.Name = "ExternalGit";
            this.ExternalGit.UseVisualStyleBackColor = true;
            this.ExternalGit.CheckedChanged += new System.EventHandler(this.ExternalGit_CheckedChanged);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "git.exe";
            resources.ApplyResources(this.openFileDialog2, "openFileDialog2");
            this.openFileDialog2.RestoreDirectory = true;
            // 
            // FrmConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExternalGit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtGitHost);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGitPass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGitUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkboxRemoteRepo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGPG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfig";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConfigFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGPG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkboxRemoteRepo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGitUser;
        private System.Windows.Forms.TextBox txtGitPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGitHost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox ExternalGit;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}