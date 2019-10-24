namespace Softpush
{
    partial class frmSoftpushOptions
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
            this.lblBlockedURLs = new System.Windows.Forms.Label();
            this.btnSaveURL = new System.Windows.Forms.Button();
            this.txtURLs = new System.Windows.Forms.TextBox();
            this.lblURLFormat = new System.Windows.Forms.Label();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.gbBlockedAction = new System.Windows.Forms.GroupBox();
            this.tbRedirectURL = new System.Windows.Forms.TextBox();
            this.rbShowRedirect = new System.Windows.Forms.RadioButton();
            this.rbShowPage = new System.Windows.Forms.RadioButton();
            this.gbKeepAlive = new System.Windows.Forms.GroupBox();
            this.btnKeepAliveUninstall = new System.Windows.Forms.Button();
            this.btnKeepAliveInstall = new System.Windows.Forms.Button();
            this.lblKeepAliveInfo = new System.Windows.Forms.Label();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.tsslblSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblWebServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExitStop = new System.Windows.Forms.Button();
            this.btnUnblock = new System.Windows.Forms.Button();
            this.btnLoadList = new System.Windows.Forms.Button();
            this.gbOptions.SuspendLayout();
            this.gbBlockedAction.SuspendLayout();
            this.gbKeepAlive.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBlockedURLs
            // 
            this.lblBlockedURLs.AutoSize = true;
            this.lblBlockedURLs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockedURLs.Location = new System.Drawing.Point(12, 9);
            this.lblBlockedURLs.Name = "lblBlockedURLs";
            this.lblBlockedURLs.Size = new System.Drawing.Size(92, 13);
            this.lblBlockedURLs.TabIndex = 2;
            this.lblBlockedURLs.Text = "Blocked URLs:";
            // 
            // btnSaveURL
            // 
            this.btnSaveURL.Location = new System.Drawing.Point(16, 402);
            this.btnSaveURL.Name = "btnSaveURL";
            this.btnSaveURL.Size = new System.Drawing.Size(232, 23);
            this.btnSaveURL.TabIndex = 0;
            this.btnSaveURL.Text = "Save blocked URLs";
            this.btnSaveURL.UseVisualStyleBackColor = true;
            this.btnSaveURL.Click += new System.EventHandler(this.btnSaveURL_Click);
            // 
            // txtURLs
            // 
            this.txtURLs.Location = new System.Drawing.Point(16, 52);
            this.txtURLs.Multiline = true;
            this.txtURLs.Name = "txtURLs";
            this.txtURLs.Size = new System.Drawing.Size(232, 344);
            this.txtURLs.TabIndex = 1;
            // 
            // lblURLFormat
            // 
            this.lblURLFormat.AutoSize = true;
            this.lblURLFormat.Location = new System.Drawing.Point(13, 23);
            this.lblURLFormat.Name = "lblURLFormat";
            this.lblURLFormat.Size = new System.Drawing.Size(107, 26);
            this.lblURLFormat.TabIndex = 3;
            this.lblURLFormat.Text = "Format: example.com\r\n(One per line)";
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.gbBlockedAction);
            this.gbOptions.Controls.Add(this.gbKeepAlive);
            this.gbOptions.Location = new System.Drawing.Point(254, 52);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(232, 373);
            this.gbOptions.TabIndex = 7;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // gbBlockedAction
            // 
            this.gbBlockedAction.Controls.Add(this.tbRedirectURL);
            this.gbBlockedAction.Controls.Add(this.rbShowRedirect);
            this.gbBlockedAction.Controls.Add(this.rbShowPage);
            this.gbBlockedAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBlockedAction.Location = new System.Drawing.Point(3, 16);
            this.gbBlockedAction.Name = "gbBlockedAction";
            this.gbBlockedAction.Size = new System.Drawing.Size(226, 78);
            this.gbBlockedAction.TabIndex = 9;
            this.gbBlockedAction.TabStop = false;
            this.gbBlockedAction.Text = "Action when blocked page visited:";
            // 
            // tbRedirectURL
            // 
            this.tbRedirectURL.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbRedirectURL.Enabled = false;
            this.tbRedirectURL.Location = new System.Drawing.Point(3, 50);
            this.tbRedirectURL.Name = "tbRedirectURL";
            this.tbRedirectURL.Size = new System.Drawing.Size(220, 20);
            this.tbRedirectURL.TabIndex = 2;
            this.tbRedirectURL.Text = "https://google.com";
            this.tbRedirectURL.TextChanged += new System.EventHandler(this.tbRedirectURL_TextChanged);
            // 
            // rbShowRedirect
            // 
            this.rbShowRedirect.AutoSize = true;
            this.rbShowRedirect.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbShowRedirect.Location = new System.Drawing.Point(3, 33);
            this.rbShowRedirect.Name = "rbShowRedirect";
            this.rbShowRedirect.Size = new System.Drawing.Size(220, 17);
            this.rbShowRedirect.TabIndex = 1;
            this.rbShowRedirect.Text = "Redirect to site:";
            this.rbShowRedirect.UseVisualStyleBackColor = true;
            this.rbShowRedirect.CheckedChanged += new System.EventHandler(this.rbShowRedirect_CheckedChanged);
            // 
            // rbShowPage
            // 
            this.rbShowPage.AutoSize = true;
            this.rbShowPage.Checked = true;
            this.rbShowPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbShowPage.Location = new System.Drawing.Point(3, 16);
            this.rbShowPage.Name = "rbShowPage";
            this.rbShowPage.Size = new System.Drawing.Size(220, 17);
            this.rbShowPage.TabIndex = 0;
            this.rbShowPage.TabStop = true;
            this.rbShowPage.Text = "Show Blocked page";
            this.rbShowPage.UseVisualStyleBackColor = true;
            this.rbShowPage.CheckedChanged += new System.EventHandler(this.rbShowPage_CheckedChanged);
            // 
            // gbKeepAlive
            // 
            this.gbKeepAlive.Controls.Add(this.btnKeepAliveUninstall);
            this.gbKeepAlive.Controls.Add(this.btnKeepAliveInstall);
            this.gbKeepAlive.Controls.Add(this.lblKeepAliveInfo);
            this.gbKeepAlive.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbKeepAlive.Location = new System.Drawing.Point(3, 251);
            this.gbKeepAlive.Name = "gbKeepAlive";
            this.gbKeepAlive.Size = new System.Drawing.Size(226, 119);
            this.gbKeepAlive.TabIndex = 7;
            this.gbKeepAlive.TabStop = false;
            this.gbKeepAlive.Text = "Keep Alive";
            // 
            // btnKeepAliveUninstall
            // 
            this.btnKeepAliveUninstall.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKeepAliveUninstall.Enabled = false;
            this.btnKeepAliveUninstall.Location = new System.Drawing.Point(3, 78);
            this.btnKeepAliveUninstall.Name = "btnKeepAliveUninstall";
            this.btnKeepAliveUninstall.Size = new System.Drawing.Size(220, 23);
            this.btnKeepAliveUninstall.TabIndex = 7;
            this.btnKeepAliveUninstall.Text = "Uninstall Keep Alive";
            this.btnKeepAliveUninstall.UseVisualStyleBackColor = true;
            // 
            // btnKeepAliveInstall
            // 
            this.btnKeepAliveInstall.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKeepAliveInstall.Location = new System.Drawing.Point(3, 55);
            this.btnKeepAliveInstall.Name = "btnKeepAliveInstall";
            this.btnKeepAliveInstall.Size = new System.Drawing.Size(220, 23);
            this.btnKeepAliveInstall.TabIndex = 6;
            this.btnKeepAliveInstall.Text = "Install Keep Alive";
            this.btnKeepAliveInstall.UseVisualStyleBackColor = true;
            // 
            // lblKeepAliveInfo
            // 
            this.lblKeepAliveInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKeepAliveInfo.Location = new System.Drawing.Point(3, 16);
            this.lblKeepAliveInfo.Name = "lblKeepAliveInfo";
            this.lblKeepAliveInfo.Size = new System.Drawing.Size(220, 39);
            this.lblKeepAliveInfo.TabIndex = 5;
            this.lblKeepAliveInfo.Text = "Open hosting program if manually closed by user.";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblSpacer,
            this.tsslblWebServer});
            this.statusStripMain.Location = new System.Drawing.Point(0, 457);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(490, 22);
            this.statusStripMain.TabIndex = 8;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // tsslblSpacer
            // 
            this.tsslblSpacer.Name = "tsslblSpacer";
            this.tsslblSpacer.Size = new System.Drawing.Size(366, 17);
            this.tsslblSpacer.Spring = true;
            // 
            // tsslblWebServer
            // 
            this.tsslblWebServer.Name = "tsslblWebServer";
            this.tsslblWebServer.Size = new System.Drawing.Size(109, 17);
            this.tsslblWebServer.Text = "Web server: STATUS";
            // 
            // btnExitStop
            // 
            this.btnExitStop.Location = new System.Drawing.Point(361, 431);
            this.btnExitStop.Name = "btnExitStop";
            this.btnExitStop.Size = new System.Drawing.Size(117, 23);
            this.btnExitStop.TabIndex = 9;
            this.btnExitStop.Text = "Exit && Stop server";
            this.btnExitStop.UseVisualStyleBackColor = true;
            this.btnExitStop.Click += new System.EventHandler(this.btnExitStop_Click);
            // 
            // btnUnblock
            // 
            this.btnUnblock.Location = new System.Drawing.Point(173, 431);
            this.btnUnblock.Name = "btnUnblock";
            this.btnUnblock.Size = new System.Drawing.Size(75, 23);
            this.btnUnblock.TabIndex = 10;
            this.btnUnblock.Text = "Unblock";
            this.btnUnblock.UseVisualStyleBackColor = true;
            this.btnUnblock.Click += new System.EventHandler(this.btnUnblock_Click);
            // 
            // btnLoadList
            // 
            this.btnLoadList.Location = new System.Drawing.Point(15, 431);
            this.btnLoadList.Name = "btnLoadList";
            this.btnLoadList.Size = new System.Drawing.Size(152, 23);
            this.btnLoadList.TabIndex = 11;
            this.btnLoadList.Text = "Load list";
            this.btnLoadList.UseVisualStyleBackColor = true;
            this.btnLoadList.Click += new System.EventHandler(this.btnLoadList_Click);
            // 
            // frmSoftpushOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 479);
            this.Controls.Add(this.btnLoadList);
            this.Controls.Add(this.btnUnblock);
            this.Controls.Add(this.btnExitStop);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.lblURLFormat);
            this.Controls.Add(this.lblBlockedURLs);
            this.Controls.Add(this.txtURLs);
            this.Controls.Add(this.btnSaveURL);
            this.Name = "frmSoftpushOptions";
            this.Text = "Softpush Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSoftpushOptions_FormClosing);
            this.Load += new System.EventHandler(this.frmSoftpushOptions_Load);
            this.gbOptions.ResumeLayout(false);
            this.gbBlockedAction.ResumeLayout(false);
            this.gbBlockedAction.PerformLayout();
            this.gbKeepAlive.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBlockedURLs;
        private System.Windows.Forms.Button btnSaveURL;
        private System.Windows.Forms.TextBox txtURLs;
        private System.Windows.Forms.Label lblURLFormat;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.GroupBox gbKeepAlive;
        private System.Windows.Forms.Button btnKeepAliveUninstall;
        private System.Windows.Forms.Button btnKeepAliveInstall;
        private System.Windows.Forms.Label lblKeepAliveInfo;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel tsslblWebServer;
        private System.Windows.Forms.ToolStripStatusLabel tsslblSpacer;
        private System.Windows.Forms.GroupBox gbBlockedAction;
        private System.Windows.Forms.TextBox tbRedirectURL;
        private System.Windows.Forms.RadioButton rbShowRedirect;
        private System.Windows.Forms.RadioButton rbShowPage;
        private System.Windows.Forms.Button btnExitStop;
        private System.Windows.Forms.Button btnUnblock;
        private System.Windows.Forms.Button btnLoadList;
    }
}

