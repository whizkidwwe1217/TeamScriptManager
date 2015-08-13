using JeonsoftTeamScriptManager.Utils;
using Ookii.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace JeonsoftTeamScriptManager
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                GlobalOptions.Instance.StashConfigName = cboRecent.Text;
                GlobalOptions.Instance.StashManifestDirectory = txtStash.Text.Trim();
                GlobalOptions.Instance.MergeFileOutputDirectory = txtMerge.Text.Trim();
                GlobalOptions.Instance.IncludePrefixedFiles = chbIncludePrefixed.Checked;
                GlobalOptions.Instance.IncludePostFixedFiles = chbIncludePostfixed.Checked;
                GlobalOptions.Instance.PrefixedFilesDirectory = txtPrefixed.Text.Trim();
                GlobalOptions.Instance.PostfixedFilesDirectory = txtPostFixed.Text.Trim();
                GlobalOptions.Instance.EnableDefaultDirectories = chbDefaultDirs.Checked;
                GlobalOptions.Instance.DefaultDirectories = txtDefaultDirs.Text;
                GlobalOptions.Instance.EnableFileTracking = chbFileTracking.Checked;
                GlobalOptions.Instance.EnableAutoCheckUpdates = chbCheckUpdates.Checked;
                GlobalOptions.Instance.ResolveHostNameAddresses = chkResolveHosts.Checked;
                GlobalOptions.Instance.SaveStashFilesWithFullPath = chbUseFullPath.Checked;
                GlobalOptions.Instance.ValidateOnMerge = chbValidateOnMerge.Checked;
                GlobalOptions.Instance.DefaultWorkspace = txtDefaultWorkspace.Text.Trim();
                GlobalOptions.Instance.SaveSettings();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            GlobalOptions.Instance.StashConfigName = cboRecent.Text;
            GlobalOptions.Instance.StashManifestDirectory = txtStash.Text .Trim();
            GlobalOptions.Instance.MergeFileOutputDirectory = txtMerge.Text.Trim();
            GlobalOptions.Instance.IncludePrefixedFiles = chbIncludePrefixed.Checked;
            GlobalOptions.Instance.IncludePostFixedFiles = chbIncludePostfixed.Checked;
            GlobalOptions.Instance.PrefixedFilesDirectory = txtPrefixed.Text.Trim();
            GlobalOptions.Instance.PostfixedFilesDirectory = txtPostFixed.Text.Trim();
            GlobalOptions.Instance.EnableDefaultDirectories = chbDefaultDirs.Checked;
            GlobalOptions.Instance.DefaultDirectories = txtDefaultDirs.Text;
            GlobalOptions.Instance.EnableFileTracking = chbFileTracking.Checked;
            GlobalOptions.Instance.EnableAutoCheckUpdates = chbCheckUpdates.Checked;
            GlobalOptions.Instance.ResolveHostNameAddresses = chkResolveHosts.Checked;
            GlobalOptions.Instance.SaveStashFilesWithFullPath = chbUseFullPath.Checked;
            GlobalOptions.Instance.ValidateOnMerge = chbValidateOnMerge.Checked;
            GlobalOptions.Instance.DefaultWorkspace = txtDefaultWorkspace.Text.Trim();
            GlobalOptions.Instance.SaveSettings();

            SaveToRecent();
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            GlobalOptions.Instance.LoadSettings();
            cboRecent.Text = GlobalOptions.Instance.StashConfigName;
            txtStash.Text = GlobalOptions.Instance.StashManifestDirectory;
            txtMerge.Text = GlobalOptions.Instance.MergeFileOutputDirectory;
            txtPostFixed.Text = GlobalOptions.Instance.PostfixedFilesDirectory;
            txtPrefixed.Text = GlobalOptions.Instance.PrefixedFilesDirectory;
            txtDefaultDirs.Text = GlobalOptions.Instance.DefaultDirectories;
            chbIncludePrefixed.Checked = GlobalOptions.Instance.IncludePrefixedFiles;
            chbIncludePostfixed.Checked = GlobalOptions.Instance.IncludePostFixedFiles;
            chbDefaultDirs.Checked = GlobalOptions.Instance.EnableDefaultDirectories;
            chbFileTracking.Checked = GlobalOptions.Instance.EnableFileTracking;
            chbCheckUpdates.Checked = GlobalOptions.Instance.EnableAutoCheckUpdates;
            chkResolveHosts.Checked = GlobalOptions.Instance.ResolveHostNameAddresses;
            chbUseFullPath.Checked = GlobalOptions.Instance.SaveStashFilesWithFullPath;
            chbValidateOnMerge.Checked = GlobalOptions.Instance.ValidateOnMerge;
            txtDefaultWorkspace.Text = GlobalOptions.Instance.DefaultWorkspace;
            if (txtMerge.Text.Trim() == "" || txtStash.Text.Trim() == "")
                label3.Text = "Alright, first things first. Before we move on, please let me know where to put all these thingies: (1) Stash File, (2) Merged File.";
            else
                label3.Text = "";

            if (txtDefaultDirs.Text.Length == 0)
            {
                txtDefaultDirs.AppendText("01 Tables" + Environment.NewLine);
                txtDefaultDirs.AppendText("02 Columns" + Environment.NewLine);
                txtDefaultDirs.AppendText("03 Data" + Environment.NewLine);
                txtDefaultDirs.AppendText("04 Indexes" + Environment.NewLine);
                txtDefaultDirs.AppendText("05 Triggers" + Environment.NewLine);
                chbDefaultDirs.Checked = true;
            }
            if (txtPostFixed.Text.Length == 0)
            {
                txtPostFixed.Text = Directory.GetCurrentDirectory() + "\\PostFixed Files";
                chbIncludePostfixed.Checked = true;
            }
            if (txtPrefixed.Text.Length == 0)
            {
                txtPrefixed.Text = Directory.GetCurrentDirectory() + "\\PreFixed Files";
                chbIncludePrefixed.Checked = true;
            }

            LoadRecentConfigs();
        }

        private void txtStash_TextChanged(object sender, EventArgs e)
        {
            validatePaths();
        }

        private void validatePaths()
        {
            //btnSave.Enabled = (txtMerge.Text.Trim() != "" && txtStash.Text.Trim() != "") && (Directory.Exists(txtStash.Text.Trim()) && Directory.Exists(txtMerge.Text.Trim()));
            btnSave.Enabled = (txtStash.Text.Trim() != "") && (Directory.Exists(txtStash.Text.Trim()));
            if (!Directory.Exists(txtStash.Text.Trim()))
                label3.Text = "Invalid path for stash.";
            else
                label3.Text = "";
            if (!Directory.Exists(txtMerge.Text.Trim()))
                label3.Text = "Invalid path for merged file.";
            else
                label3.Text = "";
        }

        private void btnStash_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog())
            {
                if (string.IsNullOrEmpty(txtStash.Text) == false)
                    fbd.SelectedPath = txtStash.Text + "\\";
                if (fbd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    txtStash.Text = fbd.SelectedPath;
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog())
            {
                if (string.IsNullOrEmpty(txtMerge.Text) == false)
                    fbd.SelectedPath = txtMerge.Text + "\\";
                if (fbd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    txtMerge.Text = fbd.SelectedPath;
            }
        }

        private void btnPostFixed_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog())
            {
                if (string.IsNullOrEmpty(txtPostFixed.Text) == false)
                    fbd.SelectedPath = txtPostFixed.Text + "\\";
                if (fbd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    txtPostFixed.Text = fbd.SelectedPath;
            }
        }

        private void btnPrefixed_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog())
            {
                if (string.IsNullOrEmpty(txtPrefixed.Text) == false)
                    fbd.SelectedPath = txtPrefixed.Text + "\\";
                if (fbd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    txtPrefixed.Text = fbd.SelectedPath;
            }
        }

        private void txtStash_Leave(object sender, EventArgs e)
        {
            //validatePaths();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Load Stash Configuration";
                ofd.FileName = "_stash_global_config";
                ofd.Filter = "Configuration File|*.ini";
                if(ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    LoadConfigurationFromFile(ofd.FileName);
                }
            }
        }

        private void LoadConfigurationFromFile(string filename)
        {
            try
            {
                IniDictionaryParser parser = new IniDictionaryParser();
                Dictionary<string, DictionarySection> sections = parser.ParseFile(filename);
                if (sections != null)
                {
                    DictionarySection stash = sections["Stash"];
                    if (stash != null)
                    {
                        if (stash.Pairs.ContainsKey("Configuration Name"))
                            cboRecent.Text = stash.Pairs["Configuration Name"].Value;
                        if (stash.Pairs.ContainsKey("Stash Directory"))
                            txtStash.Text = stash.Pairs["Stash Directory"].Value;
                        if (stash.Pairs.ContainsKey("Default Workspace"))
                            txtDefaultWorkspace.Text = stash.Pairs["Default Workspace"].Value;
                        if (stash.Pairs.ContainsKey("Merge Directory"))
                            txtMerge.Text = stash.Pairs["Merge Directory"].Value;
                        if (stash.Pairs.ContainsKey("Enable File Tracking"))
                            chbFileTracking.Checked = stash.Pairs["Enable File Tracking"].Value.Trim().ToLower() == "true";
                        if (stash.Pairs.ContainsKey("Use Absolute Path"))
                            chbUseFullPath.Checked = stash.Pairs["Use Absolute Path"].Value.Trim().ToLower() == "true";
                        if (stash.Pairs.ContainsKey("Validate on Merge"))
                            chbValidateOnMerge.Checked = stash.Pairs["Validate on Merge"].Value.Trim().ToLower() == "true";
                    }

                    DictionarySection templates = sections["Templates"];
                    if (templates != null)
                    {
                        if (templates.Pairs.ContainsKey("Include Prefix"))
                            chbIncludePrefixed.Checked = templates.Pairs["Include Prefix"].Value.Trim().ToLower() == "true";
                        if (templates.Pairs.ContainsKey("Include Postfix"))
                            chbIncludePostfixed.Checked = templates.Pairs["Include Postfix"].Value.Trim().ToLower() == "true";
                        if (templates.Pairs.ContainsKey("Prefix Directory"))
                            txtPrefixed.Text = templates.Pairs["Prefix Directory"].Value;
                        if (templates.Pairs.ContainsKey("Postfix Directory"))
                            txtPostFixed.Text = templates.Pairs["Postfix Directory"].Value;
                    }

                    DictionarySection defaultDirs = sections["Default Directories"];
                    if (defaultDirs != null)
                    {
                        if (defaultDirs.Pairs.ContainsKey("Enable Default Directories"))
                            chbDefaultDirs.Checked = defaultDirs.Pairs["Enable Default Directories"].Value.Trim().ToLower() == "true";
                        if (defaultDirs.Pairs.ContainsKey("Directory List"))
                        {
                            string dirList = defaultDirs.Pairs["Directory List"].Value.Trim();
                            string[] dirs = dirList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            txtDefaultDirs.Clear();
                            foreach (string s in dirs)
                                txtDefaultDirs.AppendText(s + Environment.NewLine);
                            txtDefaultDirs.Text = txtDefaultDirs.Text.Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveConfiguration(string filename)
        {
            string config = string.Format(
            "[Stash]" + Environment.NewLine +
            "Configuration Name = {0}" + Environment.NewLine +
            "Stash Directory = {1}" + Environment.NewLine +
            "Merge Directory = {2}" + Environment.NewLine + Environment.NewLine +
            "Enable File Tracking = {3}" + Environment.NewLine +
            "Use Absolute Path = {4}" + Environment.NewLine +
            "Validate on Merge = {5}" + Environment.NewLine +

            "[Templates]" + Environment.NewLine +
            "Include Prefix = {6}" + Environment.NewLine +
            "Include Postfix = {7}" + Environment.NewLine +
            "Prefix Directory = {8}" + Environment.NewLine +
            "Postfix Directory = {9}" + Environment.NewLine + Environment.NewLine +

            "[Default Directories]" + Environment.NewLine +
            "Enable Default Directories = {10}" + Environment.NewLine +
            "Directory List = {11}" + Environment.NewLine +
            "Default Workspace = {12}", cboRecent.Text, txtStash.Text, txtMerge.Text, chbFileTracking.Checked.ToString(), 
                chbUseFullPath.Checked.ToString(), chbValidateOnMerge.Checked.ToString(), 
                                chbIncludePrefixed.Checked.ToString(),
                                 chbIncludePostfixed.Checked.ToString(),
                                 txtPrefixed.Text, txtPostFixed.Text,
                                 chbDefaultDirs.Checked.ToString(),
                                 txtDefaultDirs.Text.Trim().Replace(Environment.NewLine, ","), txtDefaultWorkspace.Text);
            try
            {
                System.IO.File.WriteAllText(filename, config);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Configuration File|*.ini";
                sfd.FileName = "_stash_global_config";
                if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    SaveConfiguration(sfd.FileName);
                }
            }
        }

        private void SaveToRecent()
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Recent Configs";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string configName = cboRecent.Text.Trim() + ".ini";
            if (string.IsNullOrEmpty(configName.Trim()))
                configName = "Default Stash Config.ini";
            string configPath = path + "\\" + configName;
            SaveConfiguration(configPath);
        }

        private Dictionary<string, string> recentConfigs = new Dictionary<string, string>();
        private void LoadRecentConfigs()
        {
            cboRecent.Items.Clear();
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Recent Configs";
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path, "*.ini", SearchOption.TopDirectoryOnly);
                foreach(string file in files)
                {
                    cboRecent.Items.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
            cboRecent.SelectedItem = GlobalOptions.Instance.StashConfigName;
        }

        private void cboRecent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cboRecent.SelectedItem.ToString();
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Recent Configs\\" + name.Trim() + ".ini";
            if (File.Exists(path))
            {
                LoadConfigurationFromFile(path);
            }
        }

        private void btnBrowseDefaultWorkspace_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog())
            {
                if (string.IsNullOrEmpty(txtDefaultWorkspace.Text) == false)
                    fbd.SelectedPath = txtDefaultWorkspace.Text + "\\";
                if (fbd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    txtDefaultWorkspace.Text = fbd.SelectedPath;
            }
        }

        private void btnConnectionSettings_Click(object sender, EventArgs e)
        {
            ConnectionSettingsForm csf = new ConnectionSettingsForm();
            csf.ShowDialog();
        }
    }
}
