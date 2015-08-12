namespace JeonsoftTeamScriptManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtLoadFiles = new System.Windows.Forms.ToolStripButton();
            this.tbtAddStash = new System.Windows.Forms.ToolStripButton();
            this.tbtRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtPreferences = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbtProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblModified = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblOutput = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMachineName = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadDefaultDir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadDefaultStash = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStash = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKnockOff = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGenerateFromStash = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveStash = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveStashAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewStashManifest = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToStashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmnuTextEditor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuWarnings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.cmnuTextEditor.SuspendLayout();
            this.cmnuWarnings.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtLoadFiles,
            this.tbtAddStash,
            this.tbtRefresh,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton5,
            this.toolStripButton7,
            this.toolStripSeparator2,
            this.toolStripButton4,
            this.toolStripSeparator3,
            this.tbtPreferences,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(843, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtLoadFiles
            // 
            this.tbtLoadFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtLoadFiles.Image = global::JeonsoftTeamScriptManager.Properties.Resources.directory;
            this.tbtLoadFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtLoadFiles.Name = "tbtLoadFiles";
            this.tbtLoadFiles.Size = new System.Drawing.Size(23, 22);
            this.tbtLoadFiles.Text = "Load Files from this Location";
            this.tbtLoadFiles.Click += new System.EventHandler(this.mnuLoadFiles_Click);
            // 
            // tbtAddStash
            // 
            this.tbtAddStash.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtAddStash.Image = global::JeonsoftTeamScriptManager.Properties.Resources.stash_add;
            this.tbtAddStash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtAddStash.Name = "tbtAddStash";
            this.tbtAddStash.Size = new System.Drawing.Size(23, 22);
            this.tbtAddStash.Text = "Add to Catalog";
            this.tbtAddStash.Click += new System.EventHandler(this.mnuStash_Click);
            // 
            // tbtRefresh
            // 
            this.tbtRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtRefresh.Image = global::JeonsoftTeamScriptManager.Properties.Resources.refresh;
            this.tbtRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtRefresh.Name = "tbtRefresh";
            this.tbtRefresh.Size = new System.Drawing.Size(23, 22);
            this.tbtRefresh.Text = "Refresh";
            this.tbtRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::JeonsoftTeamScriptManager.Properties.Resources.stash_save;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Save Catalog";
            this.toolStripButton3.Click += new System.EventHandler(this.mnuSaveStash_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::JeonsoftTeamScriptManager.Properties.Resources.merge;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(99, 22);
            this.toolStripButton2.Text = "Merge Scripts";
            this.toolStripButton2.Click += new System.EventHandler(this.mnuGenerateFromStash_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(124, 22);
            this.toolStripButton5.Text = "Validate All Scripts";
            this.toolStripButton5.ToolTipText = "Validate All Scripts";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(129, 22);
            this.toolStripButton7.Text = "Clean up All Scripts";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::JeonsoftTeamScriptManager.Properties.Resources.manifest;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(145, 22);
            this.toolStripButton4.Text = "View Catalog Manifest";
            this.toolStripButton4.Click += new System.EventHandler(this.mnuViewStashManifest_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtPreferences
            // 
            this.tbtPreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtPreferences.Image = global::JeonsoftTeamScriptManager.Properties.Resources.preferences;
            this.tbtPreferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtPreferences.Name = "tbtPreferences";
            this.tbtPreferences.Size = new System.Drawing.Size(23, 22);
            this.tbtPreferences.Text = "Preferences";
            this.tbtPreferences.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::JeonsoftTeamScriptManager.Properties.Resources.about;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "About";
            this.toolStripButton1.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.tbtProgress,
            this.lblModified,
            this.lblOutput,
            this.lblMachineName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 433);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(843, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(544, 19);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Ready.";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbtProgress
            // 
            this.tbtProgress.Name = "tbtProgress";
            this.tbtProgress.Size = new System.Drawing.Size(100, 18);
            // 
            // lblModified
            // 
            this.lblModified.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(35, 19);
            this.lblModified.Text = "Stash";
            // 
            // lblOutput
            // 
            this.lblOutput.BackColor = System.Drawing.Color.Pink;
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(45, 19);
            this.lblOutput.Text = "Output";
            // 
            // lblMachineName
            // 
            this.lblMachineName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblMachineName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(102, 19);
            this.lblMachineName.Text = "MACHINE NAME";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(843, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLoadFiles,
            this.mnuLoadDefaultDir,
            this.mnuLoadDefaultStash,
            this.mnuStash,
            this.mnuKnockOff,
            this.toolStripSeparator4,
            this.mnuGenerateFromStash,
            this.mnuSaveStash,
            this.mnuSaveStashAs,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuLoadFiles
            // 
            this.mnuLoadFiles.Image = global::JeonsoftTeamScriptManager.Properties.Resources.directory;
            this.mnuLoadFiles.Name = "mnuLoadFiles";
            this.mnuLoadFiles.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mnuLoadFiles.Size = new System.Drawing.Size(271, 22);
            this.mnuLoadFiles.Text = "Load Files from this Location...";
            this.mnuLoadFiles.Click += new System.EventHandler(this.mnuLoadFiles_Click);
            // 
            // mnuLoadDefaultDir
            // 
            this.mnuLoadDefaultDir.Name = "mnuLoadDefaultDir";
            this.mnuLoadDefaultDir.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.mnuLoadDefaultDir.Size = new System.Drawing.Size(271, 22);
            this.mnuLoadDefaultDir.Text = "Load Default File Directory";
            this.mnuLoadDefaultDir.Click += new System.EventHandler(this.loaddefaultdirectory_Click);
            // 
            // mnuLoadDefaultStash
            // 
            this.mnuLoadDefaultStash.Name = "mnuLoadDefaultStash";
            this.mnuLoadDefaultStash.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.mnuLoadDefaultStash.Size = new System.Drawing.Size(271, 22);
            this.mnuLoadDefaultStash.Text = "Load Default Catalog";
            this.mnuLoadDefaultStash.Click += new System.EventHandler(this.mnuLoadDefaultStash_Click);
            // 
            // mnuStash
            // 
            this.mnuStash.Image = global::JeonsoftTeamScriptManager.Properties.Resources.stash_add;
            this.mnuStash.Name = "mnuStash";
            this.mnuStash.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuStash.Size = new System.Drawing.Size(271, 22);
            this.mnuStash.Text = "Add to Catalog";
            this.mnuStash.Click += new System.EventHandler(this.mnuStash_Click);
            // 
            // mnuKnockOff
            // 
            this.mnuKnockOff.Name = "mnuKnockOff";
            this.mnuKnockOff.Size = new System.Drawing.Size(271, 22);
            this.mnuKnockOff.Text = "&Copy Files and Add to Catalog...";
            this.mnuKnockOff.Click += new System.EventHandler(this.mnuKnockOff_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(268, 6);
            // 
            // mnuGenerateFromStash
            // 
            this.mnuGenerateFromStash.Image = global::JeonsoftTeamScriptManager.Properties.Resources.merge;
            this.mnuGenerateFromStash.Name = "mnuGenerateFromStash";
            this.mnuGenerateFromStash.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuGenerateFromStash.Size = new System.Drawing.Size(271, 22);
            this.mnuGenerateFromStash.Text = "&Generate Merge File from Catalog";
            this.mnuGenerateFromStash.Click += new System.EventHandler(this.mnuGenerateFromStash_Click);
            // 
            // mnuSaveStash
            // 
            this.mnuSaveStash.Image = global::JeonsoftTeamScriptManager.Properties.Resources.stash_save;
            this.mnuSaveStash.Name = "mnuSaveStash";
            this.mnuSaveStash.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mnuSaveStash.Size = new System.Drawing.Size(271, 22);
            this.mnuSaveStash.Text = "Sa&ve Catalog";
            this.mnuSaveStash.Click += new System.EventHandler(this.mnuSaveStash_Click);
            // 
            // mnuSaveStashAs
            // 
            this.mnuSaveStashAs.Name = "mnuSaveStashAs";
            this.mnuSaveStashAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mnuSaveStashAs.Size = new System.Drawing.Size(271, 22);
            this.mnuSaveStashAs.Text = "Save Catalog &as...";
            this.mnuSaveStashAs.Click += new System.EventHandler(this.mnuSaveStashAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(268, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewStashManifest,
            this.mnuOpenExplorer,
            this.mnuRefresh,
            this.preferencesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // mnuViewStashManifest
            // 
            this.mnuViewStashManifest.Image = global::JeonsoftTeamScriptManager.Properties.Resources.manifest;
            this.mnuViewStashManifest.Name = "mnuViewStashManifest";
            this.mnuViewStashManifest.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnuViewStashManifest.Size = new System.Drawing.Size(211, 22);
            this.mnuViewStashManifest.Text = "View Catalog Manifest";
            this.mnuViewStashManifest.Click += new System.EventHandler(this.mnuViewStashManifest_Click);
            // 
            // mnuOpenExplorer
            // 
            this.mnuOpenExplorer.Name = "mnuOpenExplorer";
            this.mnuOpenExplorer.Size = new System.Drawing.Size(211, 22);
            this.mnuOpenExplorer.Text = "Open in &Explorer";
            this.mnuOpenExplorer.Click += new System.EventHandler(this.mnuOpenExplorer_Click);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Image = global::JeonsoftTeamScriptManager.Properties.Resources.refresh;
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuRefresh.Size = new System.Drawing.Size(211, 22);
            this.mnuRefresh.Text = "&Refresh";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Image = global::JeonsoftTeamScriptManager.Properties.Resources.preferences;
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.preferencesToolStripMenuItem.Text = "&Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCheckForUpdates,
            this.changeLogsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // mnuCheckForUpdates
            // 
            this.mnuCheckForUpdates.Name = "mnuCheckForUpdates";
            this.mnuCheckForUpdates.Size = new System.Drawing.Size(180, 22);
            this.mnuCheckForUpdates.Text = "&Check for Updates...";
            this.mnuCheckForUpdates.Click += new System.EventHandler(this.mnuCheckForUpdates_Click);
            // 
            // changeLogsToolStripMenuItem
            // 
            this.changeLogsToolStripMenuItem.Name = "changeLogsToolStripMenuItem";
            this.changeLogsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changeLogsToolStripMenuItem.Text = "Change &Logs...";
            this.changeLogsToolStripMenuItem.Click += new System.EventHandler(this.changeLogsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::JeonsoftTeamScriptManager.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToStashToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 26);
            // 
            // addToStashToolStripMenuItem
            // 
            this.addToStashToolStripMenuItem.Image = global::JeonsoftTeamScriptManager.Properties.Resources.stash_add;
            this.addToStashToolStripMenuItem.Name = "addToStashToolStripMenuItem";
            this.addToStashToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addToStashToolStripMenuItem.Text = "Add to Catalog";
            this.addToStashToolStripMenuItem.Click += new System.EventHandler(this.mnuStash_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "warning.png");
            this.imageList1.Images.SetKeyName(1, "error(1).png");
            // 
            // cmnuTextEditor
            // 
            this.cmnuTextEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.validateToolStripMenuItem,
            this.cleanUpToolStripMenuItem});
            this.cmnuTextEditor.Name = "cmnuTextEditor";
            this.cmnuTextEditor.Size = new System.Drawing.Size(139, 70);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::JeonsoftTeamScriptManager.Properties.Resources.stash_save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // validateToolStripMenuItem
            // 
            this.validateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("validateToolStripMenuItem.Image")));
            this.validateToolStripMenuItem.Name = "validateToolStripMenuItem";
            this.validateToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.validateToolStripMenuItem.Text = "&Validate";
            this.validateToolStripMenuItem.Click += new System.EventHandler(this.validateToolStripMenuItem_Click);
            // 
            // cleanUpToolStripMenuItem
            // 
            this.cleanUpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cleanUpToolStripMenuItem.Image")));
            this.cleanUpToolStripMenuItem.Name = "cleanUpToolStripMenuItem";
            this.cleanUpToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.cleanUpToolStripMenuItem.Text = "&Clean up";
            this.cleanUpToolStripMenuItem.Click += new System.EventHandler(this.cleanUpToolStripMenuItem_Click);
            // 
            // cmnuWarnings
            // 
            this.cmnuWarnings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.saveToFileToolStripMenuItem});
            this.cmnuWarnings.Name = "cmnuWarnings";
            this.cmnuWarnings.Size = new System.Drawing.Size(141, 48);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveToFileToolStripMenuItem.Text = "&Save to file...";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 457);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "JeonSoft Team Script Manager";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.cmnuTextEditor.ResumeLayout(false);
            this.cmnuWarnings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuStash;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuViewStashManifest;
        private System.Windows.Forms.ToolStripMenuItem mnuGenerateFromStash;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveStash;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveStashAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tbtAddStash;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton tbtRefresh;
        private System.Windows.Forms.ToolStripProgressBar tbtProgress;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tbtPreferences;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadFiles;
        private System.Windows.Forms.ToolStripButton tbtLoadFiles;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadDefaultDir;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadDefaultStash;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToStashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenExplorer;
        private System.Windows.Forms.ToolStripMenuItem mnuKnockOff;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripStatusLabel lblModified;
        private System.Windows.Forms.ToolStripStatusLabel lblMachineName;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripStatusLabel lblOutput;
        private System.Windows.Forms.ToolStripMenuItem mnuCheckForUpdates;
        private System.Windows.Forms.ToolStripMenuItem changeLogsToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ContextMenuStrip cmnuTextEditor;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanUpToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmnuWarnings;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;


    }
}

