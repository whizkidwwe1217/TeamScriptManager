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
                GlobalOptions.Instance.CatalogDefaultExtension = cboExt.Text;
                GlobalOptions.Instance.ValidateOnSaveCatalog = chbValidateOnSaveCatalog.Checked;
                GlobalOptions.Instance.GitFileDirectory = txtGitDir.Text.Trim();
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
            GlobalOptions.Instance.CatalogDefaultExtension = cboExt.Text;
            GlobalOptions.Instance.ValidateOnSaveCatalog = chbValidateOnSaveCatalog.Checked;
            GlobalOptions.Instance.GitFileDirectory = txtGitDir.Text.Trim();
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
            cboExt.SelectedIndex = GlobalOptions.Instance.CatalogDefaultExtension == ".stash" ? 1 : 0;
            txtDefaultWorkspace.Text = GlobalOptions.Instance.DefaultWorkspace;
            chbValidateOnSaveCatalog.Checked = GlobalOptions.Instance.ValidateOnSaveCatalog;
            txtGitDir.Text = GlobalOptions.Instance.GitFileDirectory;
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
                        else
                            txtDefaultWorkspace.Text = string.Empty;
                        if (stash.Pairs.ContainsKey("Merge Directory"))
                            txtMerge.Text = stash.Pairs["Merge Directory"].Value;
                        else
                            txtMerge.Text = string.Empty;
                        if (stash.Pairs.ContainsKey("Enable File Tracking"))
                            chbFileTracking.Checked = stash.Pairs["Enable File Tracking"].Value.Trim().ToLower() == "true";
                        if (stash.Pairs.ContainsKey("Use Absolute Path"))
                            chbUseFullPath.Checked = stash.Pairs["Use Absolute Path"].Value.Trim().ToLower() == "true";
                        if (stash.Pairs.ContainsKey("Validate on Merge"))
                            chbValidateOnMerge.Checked = stash.Pairs["Validate on Merge"].Value.Trim().ToLower() == "true";
                        if (stash.Pairs.ContainsKey("Validate on Save Catalog"))
                            chbValidateOnSaveCatalog.Checked = stash.Pairs["Validate on Save Catalog"].Value.Trim().ToLower() == "true";
                        if (stash.Pairs.ContainsKey("Default Workspace"))
                            txtDefaultWorkspace.Text = stash.Pairs["Default Workspace"].Value;
                        else
                            txtDefaultWorkspace.Text = string.Empty;
                        if (stash.Pairs.ContainsKey("Default Catalog Extension"))
                            cboExt.SelectedIndex = stash.Pairs["Default Catalog Extension"].Value == ".stash" ? 1 : 0;
                        else
                            cboExt.SelectedIndex = 0;
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
            ConfigFile cf = new ConfigFile();
            cf.AddGroup("Stash", new ConfigFile.ConfigItem[]
            {
                new ConfigFile.ConfigItem() { Key = "Configuration Name", Value = cboRecent.Text },
                new ConfigFile.ConfigItem() { Key = "Stash Directory", Value = txtStash.Text},
                new ConfigFile.ConfigItem() { Key = "Merge Directory", Value = txtMerge.Text },
                new ConfigFile.ConfigItem() { Key = "Enable File Tracking", Value = chbFileTracking.Checked.ToString()},
                new ConfigFile.ConfigItem() { Key = "Use Absolute Path", Value = chbUseFullPath.Checked.ToString()},
                new ConfigFile.ConfigItem() { Key = "Validate on Merge", Value = chbValidateOnMerge.Checked.ToString() },
                new ConfigFile.ConfigItem() { Key = "Default Workspace", Value = txtDefaultWorkspace.Text },
                new ConfigFile.ConfigItem() { Key = "Default Catalog Extension", Value = cboExt.SelectedIndex == 0 ? ".wcat" : ".stash" },
                new ConfigFile.ConfigItem() { Key = "Validate on Save Catalog", Value = chbValidateOnSaveCatalog.Checked.ToString() }
            });

            cf.AddGroup("Templates", new ConfigFile.ConfigItem[]
            {
                new ConfigFile.ConfigItem() { Key = "Include Prefix", Value = chbIncludePrefixed.Checked.ToString() },
                new ConfigFile.ConfigItem() { Key = "Include Postfix", Value = chbIncludePostfixed.Checked.ToString()},
                new ConfigFile.ConfigItem() { Key = "Prefix Directory", Value = txtPrefixed.Text},
                new ConfigFile.ConfigItem() { Key = "Postfix Directory", Value = txtPostFixed.Text}
            });

            cf.AddGroup("Default Directories", new ConfigFile.ConfigItem[]
            {
                new ConfigFile.ConfigItem() { Key = "Enable Default Directories", Value = chbDefaultDirs.Checked.ToString() },
                new ConfigFile.ConfigItem() { Key = "Directory List", Value = txtDefaultDirs.Text.Trim().Replace(Environment.NewLine, ",")}
            });
            string config = cf.ToString();
            try
            {
                System.IO.File.WriteAllText(filename, config);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal class ConfigFile
        {
            internal struct ConfigItem
            {
                public string Key { get; set; }
                public string Value { get; set; }

                public override string ToString()
                {
                    return Key + " = " + Value;
                }
            }

            internal class ConfigGroup
            {
                private List<ConfigItem> items = new List<ConfigItem>();

                public string Name { get; set; }
                public List<ConfigItem> Items { get { return items; } set { items = value; } }

                public void AddItem(string key, string value)
                {
                    items.Add(new ConfigItem() { Key = key, Value = value });
                }

                public override string ToString()
                {
                    return "[" + Name + "]";
                }
            }

            private List<ConfigGroup> groups = new List<ConfigGroup>();

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                foreach (ConfigGroup cg in groups)
                {
                    sb.AppendLine(cg.ToString());

                    foreach (ConfigItem item in cg.Items)
                    {
                        sb.AppendLine(item.ToString());
                    }
                    sb.AppendLine();
                }

                return sb.ToString();
            }

            public void AddGroup(string name, ConfigItem[] items)
            {
                ConfigGroup cg = new ConfigGroup();
                cg.Name = name;
                foreach (ConfigItem item in items)
                    cg.AddItem(item.Key, item.Value);
                groups.Add(cg);
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

        private void btnGitDir_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog())
            {
                if (string.IsNullOrEmpty(txtGitDir.Text) == false)
                    fbd.SelectedPath = txtGitDir.Text + "\\";
                if (fbd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    txtGitDir.Text = fbd.SelectedPath;
            }
        }
    }
}
