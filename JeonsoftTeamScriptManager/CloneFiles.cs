using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ookii.Dialogs;
using System.Collections;
using System.IO;

namespace JeonsoftTeamScriptManager
{
    public partial class CloneFiles : ExtendedForm
    {
        private Hashtable fileReferences;

        public CloneFiles()
        {
            InitializeComponent();
            fileReferences = new Hashtable();
        }

        public bool ValidateInputs()
        {
            return (Directory.Exists(txtDest.Text.Trim())) && fileReferences.Count > 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Files to Copy";
                ofd.Multiselect = true;
                ofd.Filter = "SQL Files (*.sql)|*.sql|All Files (*.*)|*.*";
                if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    lvFiles.BeginUpdate();
                    foreach (string file in ofd.FileNames)
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        if (!fileReferences.ContainsKey(fi.FullName))
                        {
                            fileReferences.Add(fi.FullName, fi.FullName);
                            ListViewItem item = new ListViewItem(
                                new string[] {
                                fi.Name,
                                fi.FullName,
                                new DataSizeUnit(fi.Length).ToString(),
                                fi.CreationTime.ToShortDateString() + " " + fi.CreationTime.ToShortTimeString(),
                                fi.LastWriteTime.ToShortDateString() + " " + fi.LastWriteTime.ToShortTimeString()
                            });
                            item.Name = fi.FullName;
                            lvFiles.Items.Add(item);
                        }
                    }
                    lvFiles.EndUpdate();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lvFiles.BeginUpdate();
            foreach (ListViewItem eachItem in lvFiles.SelectedItems)
            {
                lvFiles.Items.Remove(eachItem);
                fileReferences.Remove(eachItem.Name);
            }
            lvFiles.EndUpdate();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog())
            {
                if (string.IsNullOrEmpty(txtDest.Text) == false)
                    fbd.SelectedPath = txtDest.Text + "\\";
                else
                    fbd.SelectedPath = GlobalOptions.Instance.StashManifestDirectory;
                if (fbd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    txtDest.Text = fbd.SelectedPath;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lvFiles.Items.Clear();
            fileReferences.Clear();
        }

        enum TaskDialogResult
        {
            None = 0,
            Overwritten = 2,
            Skipped = 4,
            Cancelled = 8,
            OverwrittenAll = 16,
            SkippedAll = 32
        }

        private TaskDialogResult ShowConflictTaskDialog(string fileName)
        {
            TaskDialog td = new TaskDialog(components);
            TaskDialogButton btnO = new TaskDialogButton("Overwrite");
            TaskDialogButton btnS = new TaskDialogButton("Skip");
            TaskDialogButton btnC = new TaskDialogButton("Cancel");
            td.AllowDialogCancellation = true;
            btnC.ButtonType = ButtonType.Cancel;
            td.Buttons.Add(btnO);
            td.Buttons.Add(btnS);
            td.Buttons.Add(btnC);
            td.Content = "There is already a file with same name in the specified destination.";
            td.MainInstruction = "'" + fileName + "' already exists";
            td.WindowTitle = "File Conflict";
            td.VerificationText = "Do this for all conflicts";
            switch(td.ShowDialog(this).Text)
            {
                case "Overwrite":
                    if (td.IsVerificationChecked)
                        return TaskDialogResult.OverwrittenAll;
                    else
                        return TaskDialogResult.Overwritten;
                case "Skip":
                    if (td.IsVerificationChecked)
                        return TaskDialogResult.SkippedAll;
                    else
                        return TaskDialogResult.Skipped;
                default:
                    return TaskDialogResult.Cancelled;
            }
        }

        private int CopyFile(string source, string destination, bool overwrite)
        {
            if (overwrite)
                File.Copy(source, destination, true);
            else
                File.Copy(source, destination);
            return 1;
        }

        private BackgroundWorker bg;
        private int noOfFilesCopied = 0;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (bg != null && bg.IsBusy)
            {
                MessageBox.Show("Please wait until file copying is complete.");
                return;
            }

            if (MessageBox.Show(this, "Are you sure you want to copy the files to the specified destination?", "Copy Files",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (ValidateInputs())
                {
                    progressBar1.Visible = true;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = fileReferences.Count;
                    progressBar1.Value = 0;
                    btnAdd.Enabled = false;
                    btnRemove.Enabled = false;
                    btnClear.Enabled = false;
                    lblStatus.Text = "";
                    string dest = txtDest.Text.Trim();
                    lblStatus.Visible = true;

                    bg = new BackgroundWorker();
                    bg.WorkerReportsProgress = true;
                    bg.WorkerSupportsCancellation = true;
                    bg.DoWork += bg_DoWork;
                    bg.RunWorkerCompleted += bg_RunWorkerCompleted;
                    bg.RunWorkerAsync(dest);
                }
                else
                {
                    if (fileReferences.Count == 0)
                        MessageBox.Show("There's nothing to copy.", "Copy Files", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        MessageBox.Show("Please specify a valid destination path.", "Copy Files", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        public delegate void OkClickHandler(object sender, Hashtable files, string destination);
        public event OkClickHandler OnOkClicked;

        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Visible = false;
            lblStatus.Visible = false;
            btnAdd.Enabled = true;
            btnRemove.Enabled = true;
            btnClear.Enabled = true;
            if (e.Cancelled)
                MessageBox.Show("You have aborted the file copy. Some files might not have been copied to the specified destination.", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(noOfFilesCopied.ToString() + " file(s) copied to the specified destination.", "Copy Files", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (OnOkClicked != null)
                OnOkClicked(this, fileReferences, txtDest.Text.Trim());
            Close();
        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            noOfFilesCopied = 0;
            TaskDialogResult result = TaskDialogResult.None;

            foreach (DictionaryEntry entry in fileReferences)
            {
                if (bg.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                FileInfo fi = new FileInfo(entry.Key.ToString());
                
                try
                {
                    string dest = e.Argument.ToString();
                    string destFile = dest + "\\" + fi.Name;

                    if (result == TaskDialogResult.OverwrittenAll)
                    {
                        noOfFilesCopied += CopyFile(fi.FullName, destFile, true);
                    }
                    else if (result == TaskDialogResult.SkippedAll)
                    {
                        // Do nothing.
                    }
                    else
                    {
                        if (File.Exists(destFile))
                        {
                            result = ShowConflictTaskDialog(fi.Name);
                            if (result == TaskDialogResult.Overwritten)
                                noOfFilesCopied += CopyFile(fi.FullName, destFile, true);
                        }
                        else
                            noOfFilesCopied += CopyFile(fi.FullName, destFile, false);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Copying File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                i++;
                lblStatus.Text = string.Format("Copying file {0} of {1} ({2}%)",
                    i, fileReferences.Count, (int) ((double) i / fileReferences.Count * 100.0));
                progressBar1.Value = i;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (bg != null && bg.IsBusy)
            {
                if (MessageBox.Show(this, "File copy is still in progress. Are you sure you want to close this window?",
                    "File Copying", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    bg.CancelAsync();
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            base.OnFormClosing(e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bg != null && bg.IsBusy)
            {
                if (MessageBox.Show(this, "File copy is still in progress. Are you sure you want to close this window?",
                    "File Copying", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    bg.CancelAsync();
                    Close();
                }
            }
        }
    }
}
