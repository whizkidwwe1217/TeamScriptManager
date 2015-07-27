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
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(425, 341);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(344, 341);
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
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stash File Directory:";
            // 
            // txtStash
            // 
            this.txtStash.Location = new System.Drawing.Point(132, 33);
            this.txtStash.Name = "txtStash";
            this.txtStash.Size = new System.Drawing.Size(287, 20);
            this.txtStash.TabIndex = 1;
            this.txtStash.Leave += new System.EventHandler(this.txtStash_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Merged File Directory:";
            // 
            // txtMerge
            // 
            this.txtMerge.Location = new System.Drawing.Point(132, 59);
            this.txtMerge.Name = "txtMerge";
            this.txtMerge.Size = new System.Drawing.Size(287, 20);
            this.txtMerge.TabIndex = 4;
            this.txtMerge.Leave += new System.EventHandler(this.txtStash_Leave);
            // 
            // btnStash
            // 
            this.btnStash.Location = new System.Drawing.Point(425, 31);
            this.btnStash.Name = "btnStash";
            this.btnStash.Size = new System.Drawing.Size(75, 23);
            this.btnStash.TabIndex = 2;
            this.btnStash.Text = "Browse";
            this.btnStash.UseVisualStyleBackColor = true;
            this.btnStash.Click += new System.EventHandler(this.btnStash_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(425, 57);
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
            this.label3.Location = new System.Drawing.Point(9, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(326, 44);
            this.label3.TabIndex = 8;
            // 
            // chbIncludePrefixed
            // 
            this.chbIncludePrefixed.AutoSize = true;
            this.chbIncludePrefixed.Checked = true;
            this.chbIncludePrefixed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIncludePrefixed.Location = new System.Drawing.Point(132, 85);
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
            this.chbIncludePostfixed.Location = new System.Drawing.Point(264, 85);
            this.chbIncludePostfixed.Name = "chbIncludePostfixed";
            this.chbIncludePostfixed.Size = new System.Drawing.Size(131, 17);
            this.chbIncludePostfixed.TabIndex = 7;
            this.chbIncludePostfixed.Text = "Include Postfixed Files";
            this.chbIncludePostfixed.UseVisualStyleBackColor = true;
            // 
            // btnPrefixed
            // 
            this.btnPrefixed.Location = new System.Drawing.Point(425, 106);
            this.btnPrefixed.Name = "btnPrefixed";
            this.btnPrefixed.Size = new System.Drawing.Size(75, 23);
            this.btnPrefixed.TabIndex = 10;
            this.btnPrefixed.Text = "Browse";
            this.btnPrefixed.UseVisualStyleBackColor = true;
            this.btnPrefixed.Click += new System.EventHandler(this.btnPrefixed_Click);
            // 
            // btnPostFixed
            // 
            this.btnPostFixed.Location = new System.Drawing.Point(425, 132);
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
            this.label4.Location = new System.Drawing.Point(9, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Prefixed Files Directory:";
            // 
            // txtPrefixed
            // 
            this.txtPrefixed.Location = new System.Drawing.Point(132, 108);
            this.txtPrefixed.Name = "txtPrefixed";
            this.txtPrefixed.Size = new System.Drawing.Size(287, 20);
            this.txtPrefixed.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Postfixed Files Directory:";
            // 
            // txtPostFixed
            // 
            this.txtPostFixed.Location = new System.Drawing.Point(132, 134);
            this.txtPostFixed.Name = "txtPostFixed";
            this.txtPostFixed.Size = new System.Drawing.Size(287, 20);
            this.txtPostFixed.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 186);
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
            this.chbDefaultDirs.Location = new System.Drawing.Point(132, 160);
            this.chbDefaultDirs.Name = "chbDefaultDirs";
            this.chbDefaultDirs.Size = new System.Drawing.Size(149, 17);
            this.chbDefaultDirs.TabIndex = 17;
            this.chbDefaultDirs.Text = "Enable Default Directories";
            this.chbDefaultDirs.UseVisualStyleBackColor = true;
            // 
            // txtDefaultDirs
            // 
            this.txtDefaultDirs.AcceptsReturn = true;
            this.txtDefaultDirs.Location = new System.Drawing.Point(132, 183);
            this.txtDefaultDirs.Multiline = true;
            this.txtDefaultDirs.Name = "txtDefaultDirs";
            this.txtDefaultDirs.Size = new System.Drawing.Size(368, 99);
            this.txtDefaultDirs.TabIndex = 18;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(132, 288);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(117, 23);
            this.btnImport.TabIndex = 19;
            this.btnImport.Text = "&Import Configuration";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(255, 288);
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
            this.chbFileTracking.Location = new System.Drawing.Point(132, 317);
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
            this.chbCheckUpdates.Location = new System.Drawing.Point(132, 340);
            this.chbCheckUpdates.Name = "chbCheckUpdates";
            this.chbCheckUpdates.Size = new System.Drawing.Size(200, 17);
            this.chbCheckUpdates.TabIndex = 22;
            this.chbCheckUpdates.Text = "Automatically check for new updates";
            this.chbCheckUpdates.UseVisualStyleBackColor = true;
            // 
            // chkResolveHosts
            // 
            this.chkResolveHosts.AutoSize = true;
            this.chkResolveHosts.Location = new System.Drawing.Point(219, 317);
            this.chkResolveHosts.Name = "chkResolveHosts";
            this.chkResolveHosts.Size = new System.Drawing.Size(173, 17);
            this.chkResolveHosts.TabIndex = 22;
            this.chkResolveHosts.Text = "Resolve Host Name Addresses";
            this.chkResolveHosts.UseVisualStyleBackColor = true;
            // 
            // Preferences
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(520, 398);
            this.ControlBox = false;
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
            this.Controls.Add(this.txtMerge);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrefixed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStash);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPostFixed);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPrefixed);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnStash);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Preferences";
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
    }
}