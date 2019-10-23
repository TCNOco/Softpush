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
            this.gbKeepAlive = new System.Windows.Forms.GroupBox();
            this.btnKeepAliveUninstall = new System.Windows.Forms.Button();
            this.btnKeepAliveInstall = new System.Windows.Forms.Button();
            this.lblKeepAliveInfo = new System.Windows.Forms.Label();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.tsslblWebServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbOptions.SuspendLayout();
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
            this.gbOptions.Controls.Add(this.gbKeepAlive);
            this.gbOptions.Location = new System.Drawing.Point(278, 136);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(180, 289);
            this.gbOptions.TabIndex = 7;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // gbKeepAlive
            // 
            this.gbKeepAlive.Controls.Add(this.btnKeepAliveUninstall);
            this.gbKeepAlive.Controls.Add(this.btnKeepAliveInstall);
            this.gbKeepAlive.Controls.Add(this.lblKeepAliveInfo);
            this.gbKeepAlive.Location = new System.Drawing.Point(6, 164);
            this.gbKeepAlive.Name = "gbKeepAlive";
            this.gbKeepAlive.Size = new System.Drawing.Size(168, 119);
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
            this.btnKeepAliveUninstall.Size = new System.Drawing.Size(162, 23);
            this.btnKeepAliveUninstall.TabIndex = 7;
            this.btnKeepAliveUninstall.Text = "Uninstall Keep Alive";
            this.btnKeepAliveUninstall.UseVisualStyleBackColor = true;
            // 
            // btnKeepAliveInstall
            // 
            this.btnKeepAliveInstall.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKeepAliveInstall.Location = new System.Drawing.Point(3, 55);
            this.btnKeepAliveInstall.Name = "btnKeepAliveInstall";
            this.btnKeepAliveInstall.Size = new System.Drawing.Size(162, 23);
            this.btnKeepAliveInstall.TabIndex = 6;
            this.btnKeepAliveInstall.Text = "Install Keep Alive";
            this.btnKeepAliveInstall.UseVisualStyleBackColor = true;
            // 
            // lblKeepAliveInfo
            // 
            this.lblKeepAliveInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKeepAliveInfo.Location = new System.Drawing.Point(3, 16);
            this.lblKeepAliveInfo.Name = "lblKeepAliveInfo";
            this.lblKeepAliveInfo.Size = new System.Drawing.Size(162, 39);
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
            this.statusStripMain.Size = new System.Drawing.Size(483, 22);
            this.statusStripMain.TabIndex = 8;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // tsslblWebServer
            // 
            this.tsslblWebServer.Name = "tsslblWebServer";
            this.tsslblWebServer.Size = new System.Drawing.Size(109, 17);
            this.tsslblWebServer.Text = "Web server: STATUS";
            // 
            // tsslblSpacer
            // 
            this.tsslblSpacer.Name = "tsslblSpacer";
            this.tsslblSpacer.Size = new System.Drawing.Size(328, 17);
            this.tsslblSpacer.Spring = true;
            // 
            // frmSoftpushOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 479);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.lblURLFormat);
            this.Controls.Add(this.lblBlockedURLs);
            this.Controls.Add(this.txtURLs);
            this.Controls.Add(this.btnSaveURL);
            this.Name = "frmSoftpushOptions";
            this.Text = "Softpush Options";
            this.Load += new System.EventHandler(this.frmSoftpushOptions_Load);
            this.gbOptions.ResumeLayout(false);
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
    }
}

