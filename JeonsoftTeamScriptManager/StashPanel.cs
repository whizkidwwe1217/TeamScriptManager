using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BrightIdeasSoftware;

namespace JeonsoftTeamScriptManager
{
    public partial class StashPanel : UserControl
    {
        public delegate void ItemDoubleClickHandler(object sender, string path);
        public event ItemDoubleClickHandler OnItemDoubleClick;

        public StashPanel()
        {
            InitializeComponent();
            lvStash.KeyDown += lvStash_KeyDown;
            lvStash.ItemDrag += lvStash_ItemDrag;
            lvStash.ItemsChanged += lvStash_ItemsChanged;
            lvStash.DoubleClick += lvStash_DoubleClick;
        }

        void lvStash_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = lvStash.FocusedItem;
            if (item != null)
            {
                if (OnItemDoubleClick != null)
                    OnItemDoubleClick(sender, item.SubItems[2].Text);
            }
        }

        private bool dragged = false;

        void lvStash_ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            if (dragged)
                SetModified(true);
        }

        void lvStash_ItemDrag(object sender, ItemDragEventArgs e)
        {
            dragged = true;
        }
        void lvStash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                RemoveSelectedFromStash();
        }

        private void removeFromStash_Click(object senderv, EventArgs v)
        {
            RemoveSelectedFromStash();   
        }

        public void SetStash(System.Collections.IEnumerable o)
        {
            this.lvStash.DragSource = new SimpleDragSource();
            RearrangingDropSink dropSink = new RearrangingDropSink(false);
            this.lvStash.DropSink = dropSink;
            lvStash.SetObjects(o);
            lvStash.ShowGroups = true;
        }

        public void SaveStash(string filename)
        {
            StashManager.Instance.Clear();

            using (StreamWriter sw = new StreamWriter(filename))
            {
                StringBuilder sb = new StringBuilder();
                foreach (ListViewItem item in lvStash.Items)
                {
                    string file = item.SubItems[2].Text;
                    if (!GlobalOptions.Instance.SaveStashFilesWithFullPath)
                    {
                        file = Utils.FileUtils.GetRelativePathFromFile(GlobalOptions.Instance.StashManifestDirectory, Utils.FileUtils.GetAbsolutePath(Path.GetDirectoryName(filename), file).FullName);
                    }
                    sb.AppendLine(file);

                    FileInfo fi = Utils.FileUtils.GetAbsolutePath(GlobalOptions.Instance.StashManifestDirectory, file);
                    IndexedFile idx = new IndexedFile(fi.Directory.Name, fi.Directory.FullName, fi.Name, fi.FullName);
                    StashManager.Instance.Add(idx);
                }
                sw.WriteLine(sb.ToString().Trim());
            }
        }

        public class StashEventArgs: EventArgs
        {
            private IndexedFile index;

            public StashEventArgs(IndexedFile index)
            {
                this.index = index;
            }

            public IndexedFile Index
            {
                get { return index; }
            }
        }

        public delegate void StashEventHandler(object sender, StashEventArgs e);
        public event StashEventHandler StashRemoved;
        public void RemoveSelectedFromStash()
        {
            lvStash.BeginUpdate();
            foreach (ListViewItem item in lvStash.SelectedItems)
            {
                item.Remove();
                SetModified(true);
                if (StashRemoved != null)
                    StashRemoved(this, new StashEventArgs(new IndexedFile(
                        item.SubItems[1].Text, item.SubItems[3].Text,
                        item.SubItems[0].Text, item.SubItems[2].Text)));
            }
            lvStash.EndUpdate();
        }

        public event EventHandler StashCleared;

        public void ClearStash()
        {
            lvStash.Groups.Clear();
            lvStash.Items.Clear();
            SetModified(true);
            StashManager.Instance.Clear();
            if (StashCleared != null)
                StashCleared(this, new EventArgs());
        }

        private bool modified;

        public bool Modified
        {
            get { return modified; }
            set { modified = value; }
        }

        public void SetModified(bool modified)
        {
            if (modified)
                tbtSaveStash.Image = Properties.Resources.stash_modified_save;
            else
                tbtSaveStash.Image = Properties.Resources.stash_save;
            this.modified = modified;
        }

        public event EventHandler RequestSave;
        public event EventHandler RequestResetStash;
        private void tbtSaveStash_Click(object sender, EventArgs e)
        {
            if (RequestSave != null)
                RequestSave(sender, e);
        } 

        private void tbtClearStash_Click(object sender, EventArgs e)
        {
            ClearStash();       
        }

        private void lvStash_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStash.SelectedItem != null)
            {
                lblDescription.Text = lvStash.SelectedItem.SubItems[0].Text + Environment.NewLine +
                                lvStash.SelectedItem.SubItems[2].Text;
            }
        }

        private void tbtResetStash_Click(object sender, EventArgs e)
        {
            if (RequestResetStash != null)
                RequestResetStash(sender, e);
        }


        private void lvStash_FormatRow(object sender, FormatRowEventArgs e)
        {
            IndexedFile idx = (IndexedFile)e.Model;
            if (idx.Added)
                e.Item.ForeColor = Color.Magenta;
        }

        public void InvalidateStash()
        {
            lvStash.Invalidate();
            lvStash.RefreshObjects(StashManager.Instance.Stash);
        }
    }
}
