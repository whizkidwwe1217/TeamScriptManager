namespace JeonsoftTeamScriptManager
{
    partial class StashPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtRemoveFromStash = new System.Windows.Forms.ToolStripButton();
            this.tbtClearStash = new System.Windows.Forms.ToolStripButton();
            this.tbtSaveStash = new System.Windows.Forms.ToolStripButton();
            this.tbtResetStash = new System.Windows.Forms.ToolStripButton();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lvStash = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn43 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRemoveFromStash = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearStash = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveStash = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResetStash = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvStash)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtRemoveFromStash,
            this.tbtClearStash,
            this.tbtSaveStash,
            this.tbtResetStash});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(398, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtRemoveFromStash
            // 
            this.tbtRemoveFromStash.Image = global::JeonsoftTeamScriptManager.Properties.Resources.stash_remove;
            this.tbtRemoveFromStash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtRemoveFromStash.Name = "tbtRemoveFromStash";
            this.tbtRemoveFromStash.Size = new System.Drawing.Size(117, 22);
            this.tbtRemoveFromStash.Text = "Remove Selected";
            this.tbtRemoveFromStash.Click += new System.EventHandler(this.removeFromStash_Click);
            // 
            // tbtClearStash
            // 
            this.tbtClearStash.Image = global::JeonsoftTeamScriptManager.Properties.Resources.stash_clear;
            this.tbtClearStash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtClearStash.Name = "tbtClearStash";
            this.tbtClearStash.Size = new System.Drawing.Size(54, 22);
            this.tbtClearStash.Text = "Clear";
            this.tbtClearStash.Click += new System.EventHandler(this.tbtClearStash_Click);
            // 
            // tbtSaveStash
            // 
            this.tbtSaveStash.Image = global::JeonsoftTeamScriptManager.Properties.Resources.stash_save;
            this.tbtSaveStash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtSaveStash.Name = "tbtSaveStash";
            this.tbtSaveStash.Size = new System.Drawing.Size(51, 22);
            this.tbtSaveStash.Text = "Save";
            this.tbtSaveStash.Click += new System.EventHandler(this.tbtSaveStash_Click);
            // 
            // tbtResetStash
            // 
            this.tbtResetStash.Image = global::JeonsoftTeamScriptManager.Properties.Resources.undo;
            this.tbtResetStash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtResetStash.Name = "tbtResetStash";
            this.tbtResetStash.Size = new System.Drawing.Size(55, 22);
            this.tbtResetStash.Text = "Reset";
            this.tbtResetStash.Click += new System.EventHandler(this.tbtResetStash_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDescription.Location = new System.Drawing.Point(0, 348);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(398, 50);
            this.lblDescription.TabIndex = 1;
            // 
            // lvStash
            // 
            this.lvStash.AllColumns.Add(this.olvColumn43);
            this.lvStash.AllColumns.Add(this.olvColumn2);
            this.lvStash.AllColumns.Add(this.olvColumn1);
            this.lvStash.AllColumns.Add(this.olvColumn3);
            this.lvStash.AllowColumnReorder = true;
            this.lvStash.AllowDrop = true;
            this.lvStash.AlternateRowBackColor = System.Drawing.Color.Pink;
            this.lvStash.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.F2Only;
            this.lvStash.CheckedAspectName = "";
            this.lvStash.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn43,
            this.olvColumn2,
            this.olvColumn1,
            this.olvColumn3});
            this.lvStash.ContextMenuStrip = this.contextMenu;
            this.lvStash.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvStash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStash.EmptyListMsg = "Add some files from the File Explorer";
            this.lvStash.FullRowSelect = true;
            this.lvStash.GridLines = true;
            this.lvStash.GroupWithItemCountFormat = "{0} ({1} name)";
            this.lvStash.GroupWithItemCountSingularFormat = "{0} ({1} path)";
            this.lvStash.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvStash.HideSelection = false;
            this.lvStash.Location = new System.Drawing.Point(0, 25);
            this.lvStash.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.lvStash.Name = "lvStash";
            this.lvStash.OverlayText.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            this.lvStash.OverlayText.Text = "";
            this.lvStash.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.lvStash.ShowCommandMenuOnRightClick = true;
            this.lvStash.ShowImagesOnSubItems = true;
            this.lvStash.ShowItemToolTips = true;
            this.lvStash.Size = new System.Drawing.Size(398, 323);
            this.lvStash.TabIndex = 9;
            this.lvStash.UseAlternatingBackColors = true;
            this.lvStash.UseCellFormatEvents = true;
            this.lvStash.UseCompatibleStateImageBehavior = false;
            this.lvStash.UseHotItem = true;
            this.lvStash.View = System.Windows.Forms.View.Details;
            this.lvStash.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.lvStash_FormatRow);
            this.lvStash.SelectedIndexChanged += new System.EventHandler(this.lvStash_SelectedIndexChanged);
            // 
            // olvColumn43
            // 
            this.olvColumn43.AspectName = "name";
            this.olvColumn43.CellPadding = null;
            this.olvColumn43.Groupable = false;
            this.olvColumn43.Sortable = false;
            this.olvColumn43.Text = "File Name";
            this.olvColumn43.UseInitialLetterForGroup = true;
            this.olvColumn43.Width = 114;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "groupName";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.Text = "Group";
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "path";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.Groupable = false;
            this.olvColumn1.Sortable = false;
            this.olvColumn1.Text = "Path";
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "groupPath";
            this.olvColumn3.CellPadding = null;
            this.olvColumn3.Groupable = false;
            this.olvColumn3.Sortable = false;
            this.olvColumn3.Text = "Group Path";
            this.olvColumn3.Width = 90;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRemoveFromStash,
            this.toolStripSeparator1,
            this.mnuClearStash,
            this.mnuSaveStash,
            this.mnuResetStash});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(178, 98);
            // 
            // mnuRemoveFromStash
            // 
            this.mnuRemoveFromStash.Name = "mnuRemoveFromStash";
            this.mnuRemoveFromStash.Size = new System.Drawing.Size(177, 22);
            this.mnuRemoveFromStash.Text = "Remove from Stash";
            this.mnuRemoveFromStash.Click += new System.EventHandler(this.removeFromStash_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuClearStash
            // 
            this.mnuClearStash.Name = "mnuClearStash";
            this.mnuClearStash.Size = new System.Drawing.Size(177, 22);
            this.mnuClearStash.Text = "Clear Stash";
            this.mnuClearStash.Click += new System.EventHandler(this.tbtClearStash_Click);
            // 
            // mnuSaveStash
            // 
            this.mnuSaveStash.Name = "mnuSaveStash";
            this.mnuSaveStash.Size = new System.Drawing.Size(177, 22);
            this.mnuSaveStash.Text = "Save Stash";
            this.mnuSaveStash.Click += new System.EventHandler(this.tbtSaveStash_Click);
            // 
            // mnuResetStash
            // 
            this.mnuResetStash.Name = "mnuResetStash";
            this.mnuResetStash.Size = new System.Drawing.Size(177, 22);
            this.mnuResetStash.Text = "Reset Stash";
            this.mnuResetStash.Click += new System.EventHandler(this.tbtResetStash_Click);
            // 
            // StashPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvStash);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.toolStrip1);
            this.Name = "StashPanel";
            this.Size = new System.Drawing.Size(398, 398);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvStash)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbtRemoveFromStash;
        private System.Windows.Forms.ToolStripButton tbtClearStash;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ToolStripButton tbtSaveStash;
        private BrightIdeasSoftware.ObjectListView lvStash;
        private BrightIdeasSoftware.OLVColumn olvColumn43;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private System.Windows.Forms.ToolStripButton tbtResetStash;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveFromStash;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuClearStash;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveStash;
        private System.Windows.Forms.ToolStripMenuItem mnuResetStash;
    }
}
