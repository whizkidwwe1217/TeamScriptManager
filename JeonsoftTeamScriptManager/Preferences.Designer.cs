namespace JeonsoftTeamScriptManager
{
    partial class Preferences
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStash = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMerge = new System.Windows.Forms.TextBox();
            this.btnStash = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chbIncludePrefixed = new System.Windows.Forms.CheckBox();
            this.chbIncludePostfixed = new System.Windows.Forms.CheckBox();
            this.btnPrefixed = new System.Windows.Forms.Button();
            this.btnPostFixed = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrefixed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPostFixed = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chbDefaultDirs = new System.Windows.Forms.CheckBox();
            this.txtDefaultDirs = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboRecent = new System.Windows.Forms.ComboBox();
            this.chbFileTracking = new System.Windows.Forms.CheckBox();
            this.chbCheckUpdates = new System.Windows.Forms.CheckBox();
            this.chkResolveHosts = new System.Windows.Forms.CheckBox();
            this.chbUseFullPath = new System.Windows.Forms.CheckBox();
            this.chbValidateOnMerge = new System.Windows.Forms.CheckBox();
            this.btnBrowseDefaultWorkspace = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDefaultWorkspace = new System.Windows.Forms.TextBox();
            this.btnConnectionSettings = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cboExt = new System.Windows.Forms.ComboBox();
            this.chbValidateOnSaveCatalog = new System.Windows.Forms.CheckBox();
            this.btnGitDir = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGitDir = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(424, 491);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(343, 491);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Catalog File Directory:";
            // 
            // txtStash
            // 
            this.txtStash.Location = new System.Drawing.Point(132, 59);
            this.txtStash.Name = "txtStash";
            this.txtStash.Size = new System.Drawing.Size(206, 20);
            this.txtStash.TabIndex = 1;
            this.txtStash.Leave += new System.EventHandler(this.txtStash_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Merged File Directory:";
            // 
            // txtMerge
            // 
            this.txtMerge.Location = new System.Drawing.Point(132, 85);
            this.txtMerge.Name = "txtMerge";
            this.txtMerge.Size = new System.Drawing.Size(287, 20);
            this.txtMerge.TabIndex = 4;
            this.txtMerge.Leave += new System.EventHandler(this.txtStash_Leave);
            // 
            // btnStash
            // 
            this.btnStash.Location = new System.Drawing.Point(344, 57);
            this.btnStash.Name = "btnStash";
            this.btnStash.Size = new System.Drawing.Size(75, 23);
            this.btnStash.TabIndex = 2;
            this.btnStash.Text = "Browse";
            this.btnStash.UseVisualStyleBackColor = true;
            this.btnStash.Click += new System.EventHandler(this.btnStash_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(425, 83);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 5;
            this.btnMerge.Text = "Browse";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Olive;
            this.label3.Location = new System.Drawing.Point(8, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(326, 44);
            this.label3.TabIndex = 8;
            // 
            // chbIncludePrefixed
            // 
            this.chbIncludePrefixed.AutoSize = true;
            this.chbIncludePrefixed.Checked = true;
            this.chbIncludePrefixed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIncludePrefixed.Location = new System.Drawing.Point(131, 144);
            this.chbIncludePrefixed.Name = "chbIncludePrefixed";
            this.chbIncludePrefixed.Size = new System.Drawing.Size(126, 17);
            this.chbIncludePrefixed.TabIndex = 6;
            this.chbIncludePrefixed.Text = "Include Prefixed Files";
            this.chbIncludePrefixed.UseVisualStyleBackColor = true;
            // 
            // chbIncludePostfixed
            // 
            this.chbIncludePostfixed.AutoSize = true;
            this.chbIncludePostfixed.Checked = true;
            this.chbIncludePostfixed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIncludePostfixed.Location = new System.Drawing.Point(263, 144);
            this.chbIncludePostfixed.Name = "chbIncludePostfixed";
            this.chbIncludePostfixed.Size = new System.Drawing.Size(131, 17);
            this.chbIncludePostfixed.TabIndex = 7;
            this.chbIncludePostfixed.Text = "Include Postfixed Files";
            this.chbIncludePostfixed.UseVisualStyleBackColor = true;
            // 
            // btnPrefixed
            // 
            this.btnPrefixed.Location = new System.Drawing.Point(424, 165);
            this.btnPrefixed.Name = "btnPrefixed";
            this.btnPrefixed.Size = new System.Drawing.Size(75, 23);
            this.btnPrefixed.TabIndex = 10;
            this.btnPrefixed.Text = "Browse";
            this.btnPrefixed.UseVisualStyleBackColor = true;
            this.btnPrefixed.Click += new System.EventHandler(this.btnPrefixed_Click);
            // 
            // btnPostFixed
            // 
            this.btnPostFixed.Location = new System.Drawing.Point(424, 191);
            this.btnPostFixed.Name = "btnPostFixed";
            this.btnPostFixed.Size = new System.Drawing.Size(75, 23);
            this.btnPostFixed.TabIndex = 13;
            this.btnPostFixed.Text = "Browse";
            this.btnPostFixed.UseVisualStyleBackColor = true;
            this.btnPostFixed.Click += new System.EventHandler(this.btnPostFixed_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Prefixed Files Directory:";
            // 
            // txtPrefixed
            // 
            this.txtPrefixed.Location = new System.Drawing.Point(131, 167);
            this.txtPrefixed.Name = "txtPrefixed";
            this.txtPrefixed.Size = new System.Drawing.Size(287, 20);
            this.txtPrefixed.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Postfixed Files Directory:";
            // 
            // txtPostFixed
            // 
            this.txtPostFixed.Location = new System.Drawing.Point(131, 193);
            this.txtPostFixed.Name = "txtPostFixed";
            this.txtPostFixed.Size = new System.Drawing.Size(287, 20);
            this.txtPostFixed.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Default Directories:";
            // 
            // chbDefaultDirs
            // 
            this.chbDefaultDirs.AutoSize = true;
            this.chbDefaultDirs.Checked = true;
            this.chbDefaultDirs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDefaultDirs.Location = new System.Drawing.Point(131, 219);
            this.chbDefaultDirs.Name = "chbDefaultDirs";
            this.chbDefaultDirs.Size = new System.Drawing.Size(149, 17);
            this.chbDefaultDirs.TabIndex = 17;
            this.chbDefaultDirs.Text = "Enable Default Directories";
            this.chbDefaultDirs.UseVisualStyleBackColor = true;
            // 
            // txtDefaultDirs
            // 
            this.txtDefaultDirs.AcceptsReturn = true;
            this.txtDefaultDirs.Location = new System.Drawing.Point(131, 242);
            this.txtDefaultDirs.Multiline = true;
            this.txtDefaultDirs.Name = "txtDefaultDirs";
            this.txtDefaultDirs.Size = new System.Drawing.Size(368, 99);
            this.txtDefaultDirs.TabIndex = 18;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(131, 347);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(117, 23);
            this.btnImport.TabIndex = 19;
            this.btnImport.Text = "&Import Configuration";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(254, 347);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(117, 23);
            this.btnExport.TabIndex = 20;
            this.btnExport.Text = "&Export Configuration";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Recent Configurations:";
            // 
            // cboRecent
            // 
            this.cboRecent.FormattingEnabled = true;
            this.cboRecent.Location = new System.Drawing.Point(132, 6);
            this.cboRecent.Name = "cboRecent";
            this.cboRecent.Size = new System.Drawing.Size(368, 21);
            this.cboRecent.TabIndex = 21;
            this.cboRecent.SelectedIndexChanged += new System.EventHandler(this.cboRecent_SelectedIndexChanged);
            // 
            // chbFileTracking
            // 
            this.chbFileTracking.AutoSize = true;
            this.chbFileTracking.Checked = true;
            this.chbFileTracking.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbFileTracking.Location = new System.Drawing.Point(131, 376);
            this.chbFileTracking.Name = "chbFileTracking";
            this.chbFileTracking.Size = new System.Drawing.Size(78, 17);
            this.chbFileTracking.TabIndex = 22;
            this.chbFileTracking.Text = "Track Files";
            this.chbFileTracking.UseVisualStyleBackColor = true;
            // 
            // chbCheckUpdates
            // 
            this.chbCheckUpdates.AutoSize = true;
            this.chbCheckUpdates.Checked = true;
            this.chbCheckUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCheckUpdates.Location = new System.Drawing.Point(131, 399);
            this.chbCheckUpdates.Name = "chbCheckUpdates";
            this.chbCheckUpdates.Size = new System.Drawing.Size(200, 17);
            this.chbCheckUpdates.TabIndex = 22;
            this.chbCheckUpdates.Text = "Automatically check for new updates";
            this.chbCheckUpdates.UseVisualStyleBackColor = true;
            // 
            // chkResolveHosts
            // 
            this.chkResolveHosts.AutoSize = true;
            this.chkResolveHosts.Location = new System.Drawing.Point(218, 376);
            this.chkResolveHosts.Name = "chkResolveHosts";
            this.chkResolveHosts.Size = new System.Drawing.Size(173, 17);
            this.chkResolveHosts.TabIndex = 22;
            this.chkResolveHosts.Text = "Resolve Host Name Addresses";
            this.chkResolveHosts.UseVisualStyleBackColor = true;
            // 
            // chbUseFullPath
            // 
            this.chbUseFullPath.AutoSize = true;
            this.chbUseFullPath.Location = new System.Drawing.Point(131, 422);
            this.chbUseFullPath.Name = "chbUseFullPath";
            this.chbUseFullPath.Size = new System.Drawing.Size(191, 17);
            this.chbUseFullPath.TabIndex = 22;
            this.chbUseFullPath.Text = "Save Files in Catalog with Full Path";
            this.chbUseFullPath.UseVisualStyleBackColor = true;
            // 
            // chbValidateOnMerge
            // 
            this.chbValidateOnMerge.AutoSize = true;
            this.chbValidateOnMerge.Checked = true;
            this.chbValidateOnMerge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbValidateOnMerge.Location = new System.Drawing.Point(353, 399);
            this.chbValidateOnMerge.Name = "chbValidateOnMerge";
            this.chbValidateOnMerge.Size = new System.Drawing.Size(112, 17);
            this.chbValidateOnMerge.TabIndex = 22;
            this.chbValidateOnMerge.Text = "Validate on Merge";
            this.chbValidateOnMerge.UseVisualStyleBackColor = true;
            // 
            // btnBrowseDefaultWorkspace
            // 
            this.btnBrowseDefaultWorkspace.Location = new System.Drawing.Point(425, 31);
            this.btnBrowseDefaultWorkspace.Name = "btnBrowseDefaultWorkspace";
            this.btnBrowseDefaultWorkspace.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDefaultWorkspace.TabIndex = 2;
            this.btnBrowseDefaultWorkspace.Text = "Browse";
            this.btnBrowseDefaultWorkspace.UseVisualStyleBackColor = true;
            this.btnBrowseDefaultWorkspace.Click += new System.EventHandler(this.btnBrowseDefaultWorkspace_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Default Workspace:";
            // 
            // txtDefaultWorkspace
            // 
            this.txtDefaultWorkspace.Location = new System.Drawing.Point(132, 33);
            this.txtDefaultWorkspace.Name = "txtDefaultWorkspace";
            this.txtDefaultWorkspace.Size = new System.Drawing.Size(287, 20);
            this.txtDefaultWorkspace.TabIndex = 1;
            this.txtDefaultWorkspace.Leave += new System.EventHandler(this.txtStash_Leave);
            // 
            // btnConnectionSettings
            // 
            this.btnConnectionSettings.Location = new System.Drawing.Point(131, 455);
            this.btnConnectionSettings.Name = "btnConnectionSettings";
            this.btnConnectionSettings.Size = new System.Drawing.Size(117, 23);
            this.btnConnectionSettings.TabIndex = 23;
            this.btnConnectionSettings.Text = "Connection Settings";
            this.btnConnectionSettings.UseVisualStyleBackColor = true;
            this.btnConnectionSettings.Click += new System.EventHandler(this.btnConnectionSettings_Click);
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(131, 450);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(367, 2);
            this.label9.TabIndex = 24;
            // 
            // cboExt
            // 
            this.cboExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExt.FormattingEnabled = true;
            this.cboExt.Items.AddRange(new object[] {
            ".wcat",
            ".stash"});
            this.cboExt.Location = new System.Drawing.Point(425, 57);
            this.cboExt.Name = "cboExt";
            this.cboExt.Size = new System.Drawing.Size(74, 21);
            this.cboExt.TabIndex = 25;
            // 
            // chbValidateOnSaveCatalog
            // 
            this.chbValidateOnSaveCatalog.AutoSize = true;
            this.chbValidateOnSaveCatalog.Checked = true;
            this.chbValidateOnSaveCatalog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbValidateOnSaveCatalog.Location = new System.Drawing.Point(353, 418);
            this.chbValidateOnSaveCatalog.Name = "chbValidateOnSaveCatalog";
            this.chbValidateOnSaveCatalog.Size = new System.Drawing.Size(154, 17);
            this.chbValidateOnSaveCatalog.TabIndex = 22;
            this.chbValidateOnSaveCatalog.Text = "Validate on Saving Catalog";
            this.chbValidateOnSaveCatalog.UseVisualStyleBackColor = true;
            // 
            // btnGitDir
            // 
            this.btnGitDir.Location = new System.Drawing.Point(424, 109);
            this.btnGitDir.Name = "btnGitDir";
            this.btnGitDir.Size = new System.Drawing.Size(75, 23);
            this.btnGitDir.TabIndex = 5;
            this.btnGitDir.Text = "Browse";
            this.btnGitDir.UseVisualStyleBackColor = true;
            this.btnGitDir.Click += new System.EventHandler(this.btnGitDir_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Git File Directory:";
            // 
            // txtGitDir
            // 
            this.txtGitDir.Location = new System.Drawing.Point(131, 111);
            this.txtGitDir.Name = "txtGitDir";
            this.txtGitDir.Size = new System.Drawing.Size(287, 20);
            this.txtGitDir.TabIndex = 4;
            this.txtGitDir.Leave += new System.EventHandler(this.txtStash_Leave);
            // 
            // Preferences
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(520, 545);
            this.ControlBox = false;
            this.Controls.Add(this.cboExt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnConnectionSettings);
            this.Controls.Add(this.chbValidateOnSaveCatalog);
            this.Controls.Add(this.chbValidateOnMerge);
            this.Controls.Add(this.chbUseFullPath);
            this.Controls.Add(this.chkResolveHosts);
            this.Controls.Add(this.chbCheckUpdates);
            this.Controls.Add(this.chbFileTracking);
            this.Controls.Add(this.cboRecent);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtDefaultDirs);
            this.Controls.Add(this.chbDefaultDirs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chbIncludePostfixed);
            this.Controls.Add(this.chbIncludePrefixed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPostFixed);
            this.Controls.Add(this.txtGitDir);
            this.Controls.Add(this.txtMerge);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrefixed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDefaultWorkspace);
            this.Controls.Add(this.txtStash);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPostFixed);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPrefixed);
            this.Controls.Add(this.btnGitDir);
            this.Controls.Add(this.btnBrowseDefaultWorkspace);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnStash);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Preferences";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.Preferences_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMerge;
        private System.Windows.Forms.Button btnStash;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbIncludePrefixed;
        private System.Windows.Forms.CheckBox chbIncludePostfixed;
        private System.Windows.Forms.Button btnPrefixed;
        private System.Windows.Forms.Button btnPostFixed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrefixed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPostFixed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chbDefaultDirs;
        private System.Windows.Forms.TextBox txtDefaultDirs;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboRecent;
        private System.Windows.Forms.CheckBox chbFileTracking;
        private System.Windows.Forms.CheckBox chbCheckUpdates;
        private System.Windows.Forms.CheckBox chkResolveHosts;
        private System.Windows.Forms.CheckBox chbUseFullPath;
        private System.Windows.Forms.CheckBox chbValidateOnMerge;
        private System.Windows.Forms.Button btnBrowseDefaultWorkspace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDefaultWorkspace;
        private System.Windows.Forms.Button btnConnectionSettings;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboExt;
        private System.Windows.Forms.CheckBox chbValidateOnSaveCatalog;
        private System.Windows.Forms.Button btnGitDir;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGitDir;
    }
}