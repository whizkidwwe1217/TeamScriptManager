using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using System.Net;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
using JeonsoftTeamScriptManager.Utils;
using System.Threading;
using System.Linq;

//using System.Runtime.Caching;

namespace JeonsoftTeamScriptManager
{
    public partial class MainForm : Form
    {
        private DockPanel dPanel;
        private TreeView trvFileExplorer;
        private StashPanel stash;
        private RichTextBox rtbLogs;
        private ImageList imgTree;
        private string root = string.Empty;
        private string stashArg = string.Empty;

        public MainForm(string stashArg)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            Font = new System.Drawing.Font("Segoe UI", 8F);

            dPanel = new DockPanel();
            dPanel.Dock = DockStyle.Fill;
            dPanel.DocumentStyle = DocumentStyle.DockingWindow;
            dPanel.Parent = this;
            dPanel.BringToFront();

            trvFileExplorer = new TreeView();
            trvFileExplorer.Dock = DockStyle.Fill;
            trvFileExplorer.ItemHeight = 21;
            trvFileExplorer.CheckBoxes = true;
            trvFileExplorer.AfterSelect += trvFileExplorer_AfterSelect;
            trvFileExplorer.Font = new System.Drawing.Font(Font.FontFamily, 9F);

            DockContent paneFileExplorer = new DockContent();
            paneFileExplorer.Text = "File Explorer";
            paneFileExplorer.Controls.Add(trvFileExplorer);
            paneFileExplorer.Show(dPanel);
            DockPane pane1 = dPanel.DockPaneFactory.CreateDockPane(paneFileExplorer, DockState.DockLeft, true);

            stash = new StashPanel();
            stash.Dock = DockStyle.Fill;
            stash.StashCleared += stash_StashCleared;
            stash.StashRemoved += stash_StashRemoved;
            stash.RequestSave += stash_RequestSave;
            stash.RequestResetStash += stash_RequestResetStash;

            DockContent paneStash = new DockContent();
            paneStash.Text = "Stash";
            paneStash.Controls.Add(stash);
            paneStash.Show(dPanel);
            DockPane pane2 = dPanel.DockPaneFactory.CreateDockPane(paneStash, DockState.DockRight, true);

            rtbLogs = new RichTextBox();
            rtbLogs.Dock = DockStyle.Fill;

            DockContent paneLogMessages = new DockContent();
            paneLogMessages.Text = "Log Messages";
            paneLogMessages.Controls.Add(rtbLogs);
            paneLogMessages.Show(dPanel);
            DockPane pane3 = dPanel.DockPaneFactory.CreateDockPane(paneLogMessages, DockState.DockBottom, true);
            //pane3.DockState = DockState.DockBottomAutoHide;

            trvFileExplorer.NodeMouseDoubleClick += trvFileExplorer_NodeMouseDoubleClick;
            trvFileExplorer.AfterCheck += trvFileExplorer_AfterCheck;
            imgTree = new ImageList();
            imgTree.ColorDepth = ColorDepth.Depth32Bit;
            imgTree.ImageSize = new Size(16, 16);
            imgTree.Images.Add("folder", Properties.Resources.folder);
            imgTree.Images.Add("sql", Properties.Resources.sql);
            trvFileExplorer.ImageList = imgTree;
            trvFileExplorer.ContextMenuStrip = contextMenuStrip1;
            trvFileExplorer.NodeMouseClick += trvFileExplorer_NodeMouseClick;
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            this.stashArg = stashArg;
        }

        void trvFileExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblStatus.Text = e.Node.Name;
        }

        void stash_RequestResetStash(object sender, EventArgs e)
        {
            LoadIndexedFiles();
            stash.SetModified(false);
        }

        void trvFileExplorer_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }
        }

        void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }


        void trvFileExplorer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                trvFileExplorer.SelectedNode = e.Node;
        }

        void stash_RequestSave(object sender, EventArgs e)
        {
            mnuSaveStash_Click(sender, e);
            if (hasAdded)
            {
                LoadIndexedFiles();
            }
        }

        void stash_StashRemoved(object sender, StashPanel.StashEventArgs e)
        {
            TreeNode parent = trvFileExplorer.Nodes[e.Index.groupPath];
            if (parent != null)
            {
                TreeNode child = parent.Nodes[e.Index.path];
                child.ForeColor = Color.Red;
                parent.ForeColor = Color.Red;
            }
            else
            {
                TreeNode node = trvFileExplorer.Nodes[e.Index.path];
                node.ForeColor = Color.Red;
            }
            StashManager.Instance.Remove(e.Index);
        }

        void stash_StashCleared(object sender, EventArgs e)
        {
            UpdateTreeView();
        }

        void trvFileExplorer_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                string filename = e.Node.Name;
                OpenFile(e.Node.Text, filename, "SQL");
            }
        }

        private void CheckManifestChanges(TextEditorControl rtb, string filename)
        {
            FileInfo fi = new FileInfo(filename);
            if (rtb.Text.Length != fi.Length)
            {
                if (MessageBox.Show("The stash manifest has been modified. Do you want to reload the file?", "Reload Stash Manifest", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (StreamReader sr = new StreamReader(filename))
                    {
                        rtb.Text = sr.ReadToEnd();
                    }
                }
            }
        }
        private void OpenFile(string name, string filename, string syntax)
        {
            bool isOpened = false;
            bool _highlightingProviderLoaded = false;
            foreach (IDockContent c in dPanel.Documents)
            {
                if (c is DockContent)
                {
                    DockContent dc = (DockContent)c;
                    isOpened = (dc.Name == filename);
                    if (isOpened)
                    {
                        dc.Activate();
                        TextEditorControl rtb = (TextEditorControl)dc.Controls[0];
                        CheckManifestChanges(rtb, filename);
                        break;
                    }
                }
            }
            if (!isOpened)
            {
                DockContent doc = new DockContent();
                doc.Name = filename;
                TextEditorControl rtb = new TextEditorControl();
                rtb.Enter += rtb_Enter;
                if (!_highlightingProviderLoaded)
                {
                    // Attach to the text editor.
                    HighlightingManager.Manager.AddSyntaxModeFileProvider(
                        new AppSyntaxModeProvider());
                    _highlightingProviderLoaded = true;
                }
                rtb.SetHighlighting(syntax);
                rtb.Dock = DockStyle.Fill;
                rtb.ShowSpaces = true;
                rtb.ShowTabs = true;
                rtb.TextEditorProperties.LineViewerStyle = LineViewerStyle.FullRow;
                doc.Controls.Add(rtb);

                using (StreamReader sr = new StreamReader(filename))
                {
                    rtb.Text = sr.ReadToEnd();
                }

                doc.DockAreas = DockAreas.Document;
                doc.Text = name;
                doc.Show(dPanel);
            }
        }

        void rtb_Enter(object sender, EventArgs e)
        {
            CheckManifestChanges((TextEditorControl)sender, ((DockContent)((TextEditorControl)sender).Parent).Name);
        }

        public static bool IsLocalIpAddress(string host)
        {
            try
            { // get host IP addresses
                IPAddress[] hostIPs = Dns.GetHostAddresses(host);
                // get local IP addresses
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                // test if any host IP equals to any local IP or to localhost
                foreach (IPAddress hostIP in hostIPs)
                {
                    // is localhost
                    if (IPAddress.IsLoopback(hostIP)) return true;
                    // is local address
                    foreach (IPAddress localIP in localIPs)
                    {
                        if (hostIP.Equals(localIP)) return true;
                    }
                }
            }
            catch { }
            return false;
        }

        private static string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            if (addr.Length > 0)
                return addr[addr.Length - 1].ToString();
            return "";
        }

        public static string GetMachineInfo()
        {
            return string.Format("{0}[{1}:{2}]", Environment.MachineName,
                System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName, MainForm.GetIP());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblMachineName.Text = MainForm.GetMachineInfo();

            if ((GlobalOptions.Instance.MergeFileOutputDirectory == null || GlobalOptions.Instance.MergeFileOutputDirectory.Trim() == "") ||
                (GlobalOptions.Instance.StashManifestDirectory == null || GlobalOptions.Instance.StashManifestDirectory.Trim() == ""))
            {
                Preferences pf = new Preferences();
                pf.ShowDialog(this);
            }
            LoadIndexedFiles();

            if (GlobalOptions.Instance.EnableAutoCheckUpdates)
                CheckForUpdates();
        }

        private Dictionary<string, MappedHost> mappedHosts = new Dictionary<string, MappedHost>();

        private bool IsOnStash(string filename)
        {
            return false;
        }

        class MappedHost
        {
            private string name;
            private string hostName;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string HostName
            {
                get { return hostName; }
                set { hostName = value; }
            }
        }

        private BackgroundWorker loadIndexBackgroundWorker;

        private void AsyncLoadIndexedFiles()
        {
            tbtProgress.Style = ProgressBarStyle.Blocks;
            tbtProgress.Value = 0;
            lblStatus.Text = "Indexing files...";
            LockControls(true);

            loadIndexBackgroundWorker = new BackgroundWorker();
            loadIndexBackgroundWorker.DoWork += loadIndexBackgroundWorker_DoWork;
            loadIndexBackgroundWorker.RunWorkerCompleted += loadIndexBackgroundWorker_RunWorkerCompleted;
            loadIndexBackgroundWorker.RunWorkerAsync();
        }

        void loadIndexBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "Initializing...";

            UpdateTreeView();

            tbtProgress.Value = 0;
            tbtProgress.Style = ProgressBarStyle.Blocks;
            lblStatus.Text = "Ready.";
            LockControls(false);
        }

        private void mnuStash_Click(object sender, EventArgs e)
        {
            if (trvFileExplorer.SelectedNode == null)
                return;
            if (isGenerating)
            {
                MessageBox.Show("File merging is in process. Please wait.");
                return;
            }
            if (!(bool) trvFileExplorer.SelectedNode.Tag && trvFileExplorer.SelectedNode.ForeColor != Color.Green)
            {
                TreeNode node = trvFileExplorer.SelectedNode;

                if (trvFileExplorer.SelectedNode.Nodes.Count == 0 && trvFileExplorer.SelectedNode.ForeColor != Color.Green)
                {
                    FileInfo fi = new FileInfo(trvFileExplorer.SelectedNode.Name);
                    IndexedFile idx = new IndexedFile(fi.Directory.Name, fi.Directory.FullName, trvFileExplorer.SelectedNode.Text, trvFileExplorer.SelectedNode.Name);
                    idx.Added = true;
                    if (!StashManager.Instance.Contains(idx))
                        StashManager.Instance.Add(idx);
                    trvFileExplorer.SelectedNode.ForeColor = Color.Green;
                }
                foreach (TreeNode child in node.Nodes)
                {
                    if ((bool)child.Tag)
                    {
                        IndexedFile idx = new IndexedFile(node.Text, node.Name, child.Text, child.Name);
                        idx.Added = true;
                        if (!StashManager.Instance.Contains(idx))
                            StashManager.Instance.Add(idx);
                        child.ForeColor = Color.Green;
                    }
                    AddFilesToStash(child);
                }
                node.ForeColor = Color.Green;
            }
            else if ((bool) trvFileExplorer.SelectedNode.Tag && trvFileExplorer.SelectedNode.ForeColor != Color.Green)
            {
                TreeNode node = trvFileExplorer.SelectedNode;

                if (trvFileExplorer.SelectedNode.Nodes.Count == 0 && trvFileExplorer.SelectedNode.ForeColor != Color.Green)
                {
                    FileInfo fi = new FileInfo(trvFileExplorer.SelectedNode.Name);
                    IndexedFile idx = new IndexedFile(fi.Directory.Name, fi.Directory.FullName, trvFileExplorer.SelectedNode.Text, trvFileExplorer.SelectedNode.Name);
                    idx.Added = true;
                    if (!StashManager.Instance.Contains(idx))
                        StashManager.Instance.Add(idx);
                    trvFileExplorer.SelectedNode.ForeColor = Color.Green;
                }
            }
            stash.SetStash(StashManager.Instance.Stash);
            stash.SetModified(true);
            stash.InvalidateStash();
        }

        private void AddFilesToStash(TreeNode node)
        {
            if (trvFileExplorer.SelectedNode.Nodes.Count == 0 && trvFileExplorer.SelectedNode.ForeColor != Color.Green)
            {
                FileInfo fi = new FileInfo(trvFileExplorer.SelectedNode.Name);
                IndexedFile idx = new IndexedFile(fi.Directory.Name, fi.Directory.FullName, trvFileExplorer.SelectedNode.Text, trvFileExplorer.SelectedNode.Name);
                idx.Added = true;
                if (!StashManager.Instance.Contains(idx))
                    StashManager.Instance.Add(idx);
                trvFileExplorer.SelectedNode.ForeColor = Color.Green;
            }
            foreach (TreeNode child in node.Nodes)
            {
                if ((bool)child.Tag)
                {
                    IndexedFile idx = new IndexedFile(node.Text, node.Name, child.Text, child.Name);
                    idx.Added = true;
                    if (!StashManager.Instance.Contains(idx))
                        StashManager.Instance.Add(idx);
                    child.ForeColor = Color.Green;
                }
                AddFilesToStash(child);
            }
            node.ForeColor = Color.Green;
        }

        private void UpdateTreeView()
        {
            try
            {
                trvFileExplorer.BeginUpdate();
                trvFileExplorer.Nodes.Clear();
                string baseDir;
                if (root != string.Empty)
                    baseDir = root;
                else
                    baseDir = Path.GetDirectoryName(GetStashFilePath());

                var directories = Directory.EnumerateDirectories(baseDir).OrderBy(filename => filename);
                
                foreach (string d in directories)
                {
                    DirectoryInfo di = new DirectoryInfo(d);
                    TreeNode node = new TreeNode(di.Name);
                    node.Name = di.FullName;
                    Font font = new System.Drawing.Font(trvFileExplorer.Font, FontStyle.Bold);
                    node.NodeFont = font;
                    node.ImageKey = "folder";
                    node.ForeColor = Color.Red;
                    node.Tag = false;
                    trvFileExplorer.Nodes.Add(node);
                    int indexedFileCount = 0;
                    var files = Directory.EnumerateFiles(d, "*.sql").OrderBy(filename => filename);
                    foreach (string f in files)
                    {
                        FileInfo fi = new FileInfo(f);
                        TreeNode child = new TreeNode(fi.Name);
                        child.Name = fi.FullName;
                        child.ForeColor = Color.Red;
                        if (AlreadyIndexed(fi.FullName))
                        {
                            child.ForeColor = Color.Green;
                            indexedFileCount++;
                        }
                        child.ImageKey = "sql";
                        child.SelectedImageKey = "sql";
                        child.Tag = true;
                        node.Nodes.Add(child);
                        if (indexedFileCount == node.Nodes.Count)
                            node.ForeColor = Color.Green;
                    }

                    PopulateTreeNode(di.FullName, node);
                }

                var rootFiles = Directory.EnumerateFiles(baseDir, "*.sql").OrderBy(filename => filename);
                foreach (string f in rootFiles)
                {
                    FileInfo fi = new FileInfo(f);
                    TreeNode node = new TreeNode(fi.Name);
                    node.Name = fi.FullName;
                    node.ImageKey = "sql";
                    node.ForeColor = Color.Red;
                    node.SelectedImageKey = "sql";
                    node.Tag = true;
                    if (AlreadyIndexed(fi.FullName))
                        node.ForeColor = Color.Green;
                    trvFileExplorer.Nodes.Add(node);
                }
            }
            catch (Exception ex)
            {                
                rtbLogs.AppendText(ex.Message + Environment.NewLine);   
            }
            finally
            {
                trvFileExplorer.EndUpdate();
                LockControls(false);
            }
        }

        private void PopulateTreeNode(string dir, TreeNode parentNode)
        {
            var directories = Directory.EnumerateDirectories(dir).OrderBy(filename => filename);
            foreach (string d in directories)
            {
                DirectoryInfo di = new DirectoryInfo(d);
                TreeNode node = new TreeNode(di.Name);
                node.Name = di.FullName;
                Font font = new System.Drawing.Font(trvFileExplorer.Font, FontStyle.Bold);
                node.NodeFont = font;
                node.ImageKey = "folder";
                node.ForeColor = Color.Red;

                int indexedFileCount = 0;

                var files = Directory.EnumerateFiles(d, "*.sql").OrderBy(filename => filename);
                foreach (string f in files)
                {
                    FileInfo fi = new FileInfo(f);
                    TreeNode child = new TreeNode(fi.Name);
                    child.Name = fi.FullName;
                    child.ForeColor = Color.Red;
                    if (AlreadyIndexed(fi.FullName))
                    {
                        child.ForeColor = Color.Green;
                        indexedFileCount++;
                    }
                    child.ImageKey = "sql";
                    child.SelectedImageKey = "sql";
                    child.Tag = true;
                    node.Nodes.Add(child);
                }
                node.Tag = false;
                parentNode.Nodes.Add(node);
                if (indexedFileCount == node.Nodes.Count && indexedFileCount > 0)
                    node.ForeColor = Color.Green;
                PopulateTreeNode(di.FullName, node);
            }
        }

        private void UpdateTreeView1()
        {
            try
            {
                trvFileExplorer.BeginUpdate();
                trvFileExplorer.Nodes.Clear();
                string baseDir;
                if (root != string.Empty)
                    baseDir = root;
                else
                    baseDir = Path.GetDirectoryName(GetStashFilePath());

                var directories = Directory.EnumerateDirectories(baseDir).OrderBy(filename => filename);
                foreach (string d in directories)
                {
                    DirectoryInfo di = new DirectoryInfo(d);
                    TreeNode node = new TreeNode(di.Name);
                    node.Name = di.FullName;
                    Font font = new System.Drawing.Font(trvFileExplorer.Font, FontStyle.Bold);
                    node.NodeFont = font;
                    node.ImageKey = "folder";
                    node.ForeColor = Color.Red;
                    int fileCount = 0;
                    int indexedFileCount = 0;
                    var files = Directory.EnumerateFiles(d, "*.sql").OrderBy(filename => filename);

                    foreach (string f in files)
                    {
                        FileInfo fi = new FileInfo(f);
                        TreeNode child = new TreeNode(fi.Name);
                        child.Name = fi.FullName;
                        child.ForeColor = Color.Red;
                        if (AlreadyIndexed(fi.FullName))
                        {
                            child.ForeColor = Color.Green;
                            indexedFileCount++;
                        }
                        child.ImageKey = "sql";
                        child.SelectedImageKey = "sql";
                        node.Nodes.Add(child);
                        fileCount++;
                    }

                    if (fileCount > 0)
                    {
                        trvFileExplorer.Nodes.Add(node);
                        if (indexedFileCount == node.Nodes.Count)
                            node.ForeColor = Color.Green;
                    }
                }

                var rootFiles = Directory.EnumerateFiles(baseDir, "*.sql").OrderBy(filename => filename);
                foreach (string f in rootFiles)
                {
                    FileInfo fi = new FileInfo(f);
                    TreeNode node = new TreeNode(fi.Name);
                    node.Name = fi.FullName;
                    node.ImageKey = "sql";
                    node.ForeColor = Color.Red;
                    node.SelectedImageKey = "sql";
                    if (AlreadyIndexed(fi.FullName))
                        node.ForeColor = Color.Green;
                    trvFileExplorer.Nodes.Add(node);
                }
                //trvFileExplorer.Sort();
                trvFileExplorer.EndUpdate();
            }
            catch(Exception ex)
            {
                rtbLogs.AppendText(ex.Message + Environment.NewLine);
                LockControls(false);
            }
        }

        void loadIndexBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                StashManager.Instance.Clear();
                string filename = GetStashFilePath();
                Dictionary<string, string> files = new Dictionary<string, string>();

                if (GlobalOptions.Instance.EnableDefaultDirectories)
                {
                    string[] delimiter = new string[] { Environment.NewLine };
                    string[] lines = GlobalOptions.Instance.DefaultDirectories.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                    tbtProgress.Maximum = lines.Length;
                    int ddCnt = 0;

                    foreach (string s in lines)
                    {
                        tbtProgress.Maximum = lines.Length;
                        tbtProgress.Value = ddCnt;
                        lblStatus.Text = string.Format("Scanning default directory {0}...", s);
                        ddCnt++;
                        string[] dirs = Directory.GetDirectories(Path.GetDirectoryName(filename));
                        string indexedFile = s;

                        if (!Path.IsPathRooted(s))
                        {
                            FileInfo fi = Utils.FileUtils.GetAbsolutePath(Path.GetDirectoryName(filename), s);
                            indexedFile = fi.FullName;
                        }
                            
                        foreach (string d in dirs)
                        {
                            DirectoryInfo di = new DirectoryInfo(d);
                            if (di.Name.ToLower() == indexedFile.ToLower().Trim())
                            {
                                FileInfo[] fileInfos = di.GetFiles("*.sql");
                                tbtProgress.Value = 0;
                                tbtProgress.Maximum = fileInfos.Length + 1;

                                foreach (FileInfo fi in fileInfos)
                                {
                                    tbtProgress.Value++;
                                    lblStatus.Text = string.Format("Indexing {0}...", fi.Name);

                                    string dirname = fi.Directory.Name;
                                    string dirpath = fi.DirectoryName;
                                    string host = string.Empty;
                                    string name = fi.Name;
                                    string fullName = fi.FullName;

                                    if (GlobalOptions.Instance.ResolveHostNameAddresses)
                                    {
                                        UriHostNameType hostType = NetworkUtils.GetHostType(fi.FullName, ref host);

                                        if (hostType != UriHostNameType.Basic || hostType != UriHostNameType.Unknown)
                                        {
                                            if (!mappedHosts.ContainsKey(host) && !string.IsNullOrEmpty(host))
                                            {
                                                MappedHost mh = new MappedHost()
                                                {
                                                    Name = host.ToLower(),
                                                    HostName = string.Empty
                                                };
                                                if (!mappedHosts.ContainsKey(mh.Name))
                                                    mappedHosts.Add(mh.Name, mh);
                                            }
                                        }
                                    }
                                    if (!files.ContainsKey(fullName))
                                        files.Add(fullName, fullName);
                                }
                            }
                        }
                    }
                }

                if (File.Exists(filename))
                {
                    using (StreamReader sr = new StreamReader(filename))
                    {
                        string file;
                        while ((file = sr.ReadLine()) != null)
                        {
                            if (!Path.IsPathRooted(file))
                            {
                                FileInfo fi = Utils.FileUtils.GetAbsolutePath(Path.GetDirectoryName(GetStashFilePath()), file);
                                file = fi.FullName;
                            }
                            if (File.Exists(file))
                            {
                                FileInfo fi = new FileInfo(file);
                                string dirname = fi.Directory.Name;
                                string dirpath = fi.DirectoryName;
                                string host = string.Empty;
                                string name = fi.Name;
                                string fullName = fi.FullName;

                                lblStatus.Text = string.Format("Indexing {0}...", fi.Name);

                                if (GlobalOptions.Instance.ResolveHostNameAddresses)
                                {
                                    UriHostNameType hostType = NetworkUtils.GetHostType(fi.FullName, ref host);

                                    if (hostType != UriHostNameType.Basic || hostType != UriHostNameType.Unknown)
                                    {
                                        if (!mappedHosts.ContainsKey(host) && !string.IsNullOrEmpty(host))
                                        {
                                            MappedHost mh = new MappedHost()
                                            {
                                                Name = host.ToLower(),
                                                HostName = string.Empty
                                            };
                                            if (!mappedHosts.ContainsKey(mh.Name))
                                                mappedHosts.Add(mh.Name, mh);
                                        }
                                    }
                                }

                                if (!files.ContainsKey(fullName))
                                    files.Add(fullName, fullName);
                            }
                        }
                    }
                }

                if (GlobalOptions.Instance.ResolveHostNameAddresses)
                {
                    string cache = "";
                    string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Cache\\hosts.dat";
                    bool isCacheUpdated = false;

                    LoadMappedHostsCache(path);

                    foreach (KeyValuePair<string, MappedHost> pair in mappedHosts)
                    {
                        MappedHost mh = pair.Value;
                        if (mappedHosts[mh.Name].HostName == string.Empty)
                        {
                            lblStatus.Text = string.Format("Identifying host name for {0}...", mh.Name);
                            mappedHosts[mh.Name].HostName = GetHostName(mh.Name);
                            isCacheUpdated = true;
                        }
                        cache += mh.Name + "=" + mh.HostName + Environment.NewLine;
                    }

                    if (!Directory.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\Cache\\"))
                        Directory.CreateDirectory(Path.GetDirectoryName(Application.ExecutablePath) + "\\Cache");
                    if (isCacheUpdated || !File.Exists(path))
                        File.WriteAllText(path, cache);
                }

                foreach (KeyValuePair<string, string> pair in files)
                {
                    FileInfo fi = new FileInfo(pair.Key);
                    string dirname = fi.Directory.Name;
                    string dirpath = fi.DirectoryName;
                    string host = string.Empty;
                    string name = fi.Name;
                    string fullName = fi.FullName;

                    if (GlobalOptions.Instance.ResolveHostNameAddresses)
                    {
                        UriHostNameType hostType = NetworkUtils.GetHostType(fullName, ref host);
                        if (mappedHosts.ContainsKey(host.ToLower()))
                        {
                            MappedHost mh = mappedHosts[host.ToLower()];
                            string hostname = mh.HostName;
                            if (hostname.IndexOf(".") > 0)
                                hostname = hostname.Substring(0, hostname.IndexOf("."));
                            dirname = ReplaceFirst(dirname.ToLower(), host.ToLower(), hostname);
                            dirpath = ReplaceFirst(dirpath.ToLower(), host.ToLower(), hostname);
                            fullName = ReplaceFirst(fullName.ToLower(), host.ToLower(), hostname);
                        }
                    }

                    IndexedFile idx = new IndexedFile(fi.Directory.Name, dirpath, fi.Name, fullName);
                    if (!StashManager.Instance.Contains(idx))
                        StashManager.Instance.Add(idx);
                }

                stash.SetStash(StashManager.Instance.Stash);
            }
            catch(Exception ex)
            {
                rtbLogs.AppendText(ex.Message + Environment.NewLine);
                LockControls(false);
                e.Cancel = true;
            }
        }
        private void LoadIndexedFiles()
        {
            AsyncLoadIndexedFiles();
        }

        private void LoadMappedHostsCache(string path)
        {
            if (!File.Exists(path))
                return;
            //ObjectCache cache = MemoryCache.Default;
            //string hosts = cache["HOSTS"] as string;
            //if (hosts  == null)
            //{
            //    CacheItemPolicy policy = new CacheItemPolicy();
            //    List<string> fileList = new List<string>();
                
            //    fileList.Add(path);
            //    policy.ChangeMonitors.Add(new HostFileChangeMonitor(fileList));
            //    hosts = File.ReadAllText(path);
            //    cache.Set("HOSTS", hosts, policy);
            //}
            string hosts = File.ReadAllText(path);
            string[] strHosts = hosts.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in strHosts)
            {
                string[] hostInfo = s.Split(new string[] { "="} , StringSplitOptions.RemoveEmptyEntries);
                MappedHost mh = new MappedHost()
                {
                    Name = hostInfo[0].Trim().ToLower(),
                    HostName = hostInfo[1].Trim().ToLower()
                };
                if (!mappedHosts.ContainsKey(mh.Name))
                    mappedHosts.Add(mh.Name, mh);
                else
                    mappedHosts[mh.Name].HostName = mh.HostName;
            }
        }

        public string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        private string GetHostName(string host)
        {
            try
            {
                return System.Net.Dns.GetHostEntry(host).HostName;
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }

        private bool AlreadyIndexed(string filename)
        {
            foreach (IndexedFile idx in StashManager.Instance.Stash)
            {
                FileInfo fi = new FileInfo(filename);
                string dirname = fi.Directory.Name;
                string dirpath = fi.DirectoryName;
                string host = string.Empty;
                string name = fi.Name;
                string fullName = fi.FullName;

                if (GlobalOptions.Instance.ResolveHostNameAddresses)
                {
                    UriHostNameType hostType = NetworkUtils.GetHostType(fullName, ref host);
                    if (mappedHosts.ContainsKey(host.ToLower()))
                    {
                        MappedHost mh = mappedHosts[host.ToLower()];
                        string hostname = mh.HostName;
                        if (hostname.IndexOf(".") > 0)
                            hostname = hostname.Substring(0, hostname.IndexOf("."));
                        dirname = ReplaceFirst(dirname.ToLower(), host.ToLower(), hostname);
                        dirpath = ReplaceFirst(dirpath.ToLower(), host.ToLower(), hostname);
                        fullName = ReplaceFirst(fullName.ToLower(), host.ToLower(), hostname);
                    }
                }

                if (idx.path.ToLower() == fullName.ToLower())
                    return true;
            }
            return false;
        }

        private void mnuStash_Click1(object sender, EventArgs e)
        {
            if (trvFileExplorer.SelectedNode == null)
                return;
            if (isGenerating)
            {
                MessageBox.Show("File merging is in process. Please wait.");
                return;
            }
            if (trvFileExplorer.SelectedNode.Level == 0 && trvFileExplorer.SelectedNode.ForeColor != Color.Green)
            {
                TreeNode node = trvFileExplorer.SelectedNode;

                if (trvFileExplorer.SelectedNode.Nodes.Count == 0 && trvFileExplorer.SelectedNode.ForeColor != Color.Green)
                {
                    FileInfo fi = new FileInfo(trvFileExplorer.SelectedNode.Name);
                    IndexedFile idx = new IndexedFile(fi.Directory.Name, fi.Directory.FullName, trvFileExplorer.SelectedNode.Text, trvFileExplorer.SelectedNode.Name);
                    idx.Added = true;
                    if (!StashManager.Instance.Contains(idx))
                        StashManager.Instance.Add(idx);
                    trvFileExplorer.SelectedNode.ForeColor = Color.Green;
                }
                foreach (TreeNode child in node.Nodes)
                {
                    IndexedFile idx = new IndexedFile(node.Text, node.Name, child.Text, child.Name);
                    idx.Added = true;
                    if (!StashManager.Instance.Contains(idx))
                        StashManager.Instance.Add(idx);
                    child.ForeColor = Color.Green;
                }
                node.ForeColor = Color.Green;
            }
            else if (trvFileExplorer.SelectedNode.Level == 1 && trvFileExplorer.SelectedNode.ForeColor != Color.Green)
            {
                TreeNode parent = trvFileExplorer.SelectedNode.Parent;
                IndexedFile idx = new IndexedFile(parent.Text, parent.Name, trvFileExplorer.SelectedNode.Text, trvFileExplorer.SelectedNode.Name);
                idx.Added = true;
                if (!StashManager.Instance.Contains(idx))
                    StashManager.Instance.Add(idx);
                trvFileExplorer.SelectedNode.ForeColor = Color.Green;
            }
            stash.SetStash(StashManager.Instance.Stash);
            stash.SetModified(true);
            stash.InvalidateStash();
        }

        private void mnuViewStashManifest_Click(object sender, EventArgs e)
        {
            string filename = GetStashFilePath();
            if (File.Exists(filename))
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    FileInfo fi = new FileInfo(filename);
                    OpenFile(fi.Name, fi.FullName, "");
                }
            }
        }

        private bool isGenerating;
        private void mnuGenerateFromStash_Click(object sender, EventArgs e)
        {
            if (isGenerating)
            {
                MessageBox.Show("File merging is in process. Please wait.");
                return;
            }
            InputBox ib = new InputBox(output);
            ib.OKClick += ib_OKClick;
            ib.ShowDialog(this);
        }

        void ib_OKClick(object sender, EventArgs e)
        {
            output = ((TextBox)sender).Text.Trim();
            stash.SaveStash(GetStashFilePath());
            GenerateFromStash(GetStashFilePath(), GetMergedFilePath());
        }

        private BackgroundWorker worker;

        public void GenerateFromStash(string filename, string outputFilename)
        {
            LockControls(true);
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            tbtProgress.Minimum = 0;
            tbtProgress.Maximum = StashManager.Instance.Count;
            isGenerating = true;
            worker.RunWorkerAsync(new string[] { filename, outputFilename });
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tbtProgress.Value = 0;
            if (File.Exists(GetMergedFilePath()))
            {
                rtbLogs.AppendText("Output saved to: " + GetMergedFilePath());
                rtbLogs.AppendText(Environment.NewLine);
            }
            else
            {
                rtbLogs.AppendText("No output generated.");
                rtbLogs.AppendText(Environment.NewLine);
            }
            isGenerating = false;
            MessageBox.Show("Merge complete.", "Merge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LockControls(false);
            //MessageBox.Show("Merged file generated to: " + GetMergedFilePath(), "Merge Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            rtbLogs.Clear();
            string[] args = (string[])e.Argument;
            string filename = args[0];
            string outputFilename = args[1];
            if (File.Exists(outputFilename))
                File.Delete(outputFilename);
            if (File.Exists(filename))
            {
                rtbLogs.AppendText("Reading files from " + filename);
                rtbLogs.AppendText(Environment.NewLine);
                if (GlobalOptions.Instance.IncludePrefixedFiles)
                {
                    if (Directory.Exists(GetPreFixedFiles()))
                    {
                        using (StreamWriter sw = new StreamWriter(outputFilename, true))
                        {
                            foreach (string f in Directory.GetFiles(GetPreFixedFiles(), "*.sql"))
                            {
                                using (StreamReader reader = new StreamReader(f))
                                {
                                    sw.WriteLine(reader.ReadToEnd());
                                    rtbLogs.AppendText("Prefixed file written to merged output file: " + f);
                                    rtbLogs.AppendText(Environment.NewLine);
                                }
                            }
                        }
                    }
                }
                using (StreamReader sr = new StreamReader(filename))
                {
                    string file = "";

                    using (StreamWriter sw = new StreamWriter(outputFilename, true))
                    {
                        while ((file = sr.ReadLine()) != null)
                        {
                            if (!Path.IsPathRooted(file))
                            {
                                FileInfo fi = Utils.FileUtils.GetAbsolutePath(Path.GetDirectoryName(filename), file);
                                file = fi.FullName;
                            }

                            if (!string.IsNullOrEmpty(file) && File.Exists(file))
                            {
                                FileInfo fi = new FileInfo(file);

                                sw.WriteLine(File.ReadAllText(file));
                                tbtProgress.Value++;
                                rtbLogs.AppendText("File written to merged output file: " + file);
                                rtbLogs.AppendText(Environment.NewLine);
                            }
                            else
                            {
                                rtbLogs.AppendText("Merge error: Cannot find the file: '" + file + "'");
                                rtbLogs.AppendText(Environment.NewLine);
                            }
                        }
                    }
                }
                if (GlobalOptions.Instance.IncludePostFixedFiles)
                {
                    if (Directory.Exists(GetPostFixedFiles()))
                    {
                        using (StreamWriter sw = new StreamWriter(outputFilename, true))
                        {
                            foreach (string f in Directory.GetFiles(GetPostFixedFiles(), "*.sql"))
                            {
                                using (StreamReader reader = new StreamReader(f))
                                {
                                    sw.WriteLine(reader.ReadToEnd());
                                    rtbLogs.AppendText("Postfixed file written to merged output file: " + f);
                                    rtbLogs.AppendText(Environment.NewLine);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                rtbLogs.AppendText("Cannot find the file: '" + filename + "'");
                rtbLogs.AppendText(Environment.NewLine);
            }
        }

        private void LockControls(bool locked)
        {
            if (locked)
                Cursor = Cursors.WaitCursor;
            else
                Cursor = Cursors.Default;
            stash.Enabled = !locked;
            trvFileExplorer.Enabled = !locked;
            menuStrip1.Enabled = !locked;
            mnuLoadDefaultStash.Enabled = !locked;
            mnuLoadFiles.Enabled = !locked;
            mnuOpenExplorer.Enabled = !locked;
            mnuRefresh.Enabled = !locked;
            mnuKnockOff.Enabled = !locked;
            preferencesToolStripMenuItem.Enabled = !locked;
            mnuStash.Enabled = !locked;
            mnuLoadDefaultDir.Enabled = !locked;
            tbtAddStash.Enabled = !locked;
            tbtLoadFiles.Enabled = !locked;
            tbtPreferences.Enabled = !locked;
            tbtRefresh.Enabled = !locked;
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void mnuSaveStashAs_Click(object sender, EventArgs e)
        {
            if (isGenerating)
            {
                MessageBox.Show("File merging is in process. Please wait.");
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.DefaultExt = ".stash";
                sfd.FileName = GetStashFileName();
                sfd.Filter = "Stash File|*.stash";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    stash.SaveStash(sfd.FileName);
                    MessageBox.Show("Stash saved successfully.", "Save Stash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private string GetStashFileName()
        {
            return "_stash";
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            LoadIndexedFiles();
            stash.SetModified(false);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isGenerating)
            {
                if (MessageBox.Show("File merging is still in process. Are you sure you want to exit this application?", "Close Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                    e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        private void mnuSaveStash_Click(object sender, EventArgs e)
        {
            if (isGenerating)
            {
                MessageBox.Show("File merging is in process. Please wait.");
                return;
            }
            stash.SaveStash(GetStashFilePath());
            stash.SetModified(false);
            MessageBox.Show("Stash saved successfully.", "Save Stash", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGenerating)
            {
                MessageBox.Show("File merging is in process. Please wait.");
                return;
            }
            Preferences pf = new Preferences();
            if (pf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                mnuRefresh_Click(sender, e);
            }
        }

        private string GetStashFilePath()
        {
            if (stashArg != string.Empty)
                return stashArg;
            string dir = "";

            if (GlobalOptions.Instance.StashManifestDirectory == null || GlobalOptions.Instance.StashManifestDirectory.Trim() == "")
                dir = Directory.GetCurrentDirectory() + "\\" + GetStashFileName() + ".stash";
            if (GlobalOptions.Instance.StashManifestDirectory.EndsWith("\\"))
                dir = GlobalOptions.Instance.StashManifestDirectory + GetStashFileName() + ".stash";
            else
                dir = GlobalOptions.Instance.StashManifestDirectory + "\\" + GetStashFileName() + ".stash";

            //string host = string.Empty;
            //UriHostNameType hostType = Utils.GetHostType(dir, ref host);

            //if (hostType != UriHostNameType.Basic || hostType != UriHostNameType.Unknown)
            //{
            //    dir = ReplaceFirst(dir, "newdevserver", GetHostName(host.ToLower()));
            //}

            return dir;
        }

        private string GetMergedFilePath()
        {
            if (GlobalOptions.Instance.MergeFileOutputDirectory == null || GlobalOptions.Instance.MergeFileOutputDirectory.Trim() == "")
                return Directory.GetCurrentDirectory() + "\\" + GetOutputName();
            if (GlobalOptions.Instance.MergeFileOutputDirectory.EndsWith("\\"))
                return GlobalOptions.Instance.MergeFileOutputDirectory + GetOutputName();
            else
                return GlobalOptions.Instance.MergeFileOutputDirectory + "\\" + GetOutputName();
        }

        private string output = "merged.sql";
        private string GetOutputName()
        {
            return output;
        }
        private void mnuLoadFiles_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog ofd = new FolderBrowserDialog())
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    root = ofd.SelectedPath;
                UpdateTreeView();
            }
        }

        private void loaddefaultdirectory_Click(object sender, EventArgs e)
        {
            root = string.Empty;
            UpdateTreeView();
        }

        private string GetPreFixedFiles()
        {
            if (GlobalOptions.Instance.PrefixedFilesDirectory.Trim() != "")
                return GlobalOptions.Instance.PrefixedFilesDirectory;
            return Directory.GetCurrentDirectory() + "\\Prefixed Files";
        }

        private string GetPostFixedFiles()
        {
            if (GlobalOptions.Instance.PostfixedFilesDirectory.Trim() != "")
                return GlobalOptions.Instance.PostfixedFilesDirectory;
            return Directory.GetCurrentDirectory() + "\\PostFixed Files";
        }

        private void mnuLoadDefaultStash_Click(object sender, EventArgs e)
        {
            stashArg = string.Empty;
            LoadIndexedFiles();
        }

        private void mnuOpenExplorer_Click(object sender, EventArgs e)
        {
            string filename = GetStashFilePath();
            if (File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                Process.Start(fi.Directory.FullName);
            }
        }

        private void mnuKnockOff_Click(object sender, EventArgs e)
        {
            CloneFiles cf = new CloneFiles();
            cf.OnOkClicked += cf_OnOkClicked;
            cf.ShowDialog(this);
        }

        private BackgroundWorker addFileWorker;
        class FileWorkerArg
        {
            public string Destination;
            public Hashtable Files;
        }
        void cf_OnOkClicked(object sender, System.Collections.Hashtable files, string destination)
        {
            LockControls(true);
            tbtProgress.Minimum = 0;
            tbtProgress.Maximum = files.Count;
            tbtProgress.Value = 0;
            addFileWorker = new BackgroundWorker();
            addFileWorker.DoWork += addFileWorker_DoWork;
            addFileWorker.RunWorkerCompleted += addFileWorker_RunWorkerCompleted;
            FileWorkerArg arg = new FileWorkerArg() { Destination = destination, Files = files };
            addFileWorker.RunWorkerAsync(arg);
        }

        private bool hasAdded = false;
        void addFileWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stash.SetStash(StashManager.Instance.Stash);
            stash.SetModified(hasAdded);
            tbtProgress.Value = 0;
            hasAdded = false;
            LockControls(false);
        }

        void addFileWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            FileWorkerArg arg = e.Argument as FileWorkerArg;
            foreach (DictionaryEntry entry in arg.Files)
            {
                FileInfo fi = new FileInfo(entry.Key.ToString());
                IndexedFile idx = new IndexedFile(new DirectoryInfo(arg.Destination).Name, arg.Destination, fi.Name, arg.Destination + "\\" + fi.Name);
                if (!StashManager.Instance.Contains(idx))
                {
                    hasAdded = true;
                    StashManager.Instance.Add(idx);
                }
                rtbLogs.AppendText("Copied '" + fi.Name + "' to directory and added to stash." + Environment.NewLine);
                tbtProgress.Value++;
            }
        }

        private void mnuCheckForUpdates_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        private VersionInfo vi;
        private BackgroundWorker bgw;

        public void CheckForUpdates()
        {
            rtbLogs.AppendText("Checking for new updates...");
            bgw = new BackgroundWorker();
            bgw.DoWork += bgw_DoWork;
            bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
            bgw.RunWorkerAsync();
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result.GetType() == typeof(VersionInfo))
                {
                    vi = (VersionInfo)e.Result;
                    int updateVersion = int.Parse(vi.Version.Replace(".", ""));
                    int currentVersion = int.Parse(Application.ProductVersion.Replace(".", ""));
                    if (currentVersion < updateVersion)
                    {
                        rtbLogs.AppendText(Environment.NewLine + "New updates available.");
                        if (MessageBox.Show(this, "New updates available. Do you want to download and install updates?", "Download and install updates", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DownloadAndInstallUpdates();
                        }
                    }
                    else
                    {
                        rtbLogs.AppendText(Environment.NewLine + "No new updates available.");
                    }
                }
                else
                {
                    rtbLogs.AppendText(Environment.NewLine + "Error checking updates: " + e.Result.ToString());
                }
            }
            mnuCheckForUpdates.Enabled = true;
        }

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            string ftpUrl = "ftp://ftp.jeonsoft.com";
            string username = "u71059845";
            string password = "uptown_629#";
            string ftpDir = "installers/jeonsoftautomationtools";
            string filename = "team_script_manager_version.ini";

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl + "/" + ftpDir + "/" + filename);
                request.Credentials = new NetworkCredential(username, password);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                try
                {
                    VersionInfo vi = new VersionInfo();
                    IniDictionaryParser parser = new IniDictionaryParser();
                    Dictionary<string, DictionarySection> sections = parser.Parse(reader.ReadToEnd());
                    if (sections != null)
                    {
                        DictionarySection versionInfo = sections["Version Info"];
                        if (versionInfo != null)
                        {
                            if (versionInfo.Pairs.ContainsKey("Version"))
                                vi.Version = versionInfo.Pairs["Version"].Value;
                            if (versionInfo.Pairs.ContainsKey("File Name"))
                                vi.FileName = versionInfo.Pairs["File Name"].Value;
                            e.Result = vi;
                        }
                    }
                }
                catch (Exception ex)
                {
                    e.Result = ex.Message;
                }
                request = null;
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;           
            }
        }

        private BackgroundWorker bgw2;
        public void DownloadAndInstallUpdates()
        {
            rtbLogs.AppendText("Downloading updates..." + Environment.NewLine);
            mnuCheckForUpdates.Enabled = false;
            bgw2 = new BackgroundWorker();
            bgw2.DoWork += bgw2_DoWork;
            bgw2.RunWorkerCompleted += bgw2_RunWorkerCompleted;
            bgw2.RunWorkerAsync();
        }

        void bgw2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                mnuCheckForUpdates.Enabled = true;
                rtbLogs.AppendText("Error downloading updates..." + e.Result.ToString());
            }
            else
            {
                mnuCheckForUpdates.Enabled = true;
                if (File.Exists(e.Result.ToString()))
                {
                    Process.Start(e.Result.ToString());
                    Application.Exit();
                }
                rtbLogs.AppendText("Downloading complete...");
            }
        }

        void bgw2_DoWork(object sender, DoWorkEventArgs e)
        {
            string outputDir = Directory.GetCurrentDirectory() + "\\Cache\\";
            string ftpUrl = "ftp://ftp.jeonsoft.com";
            string username = "u71059845";
            string password = "uptown_629#";
            string ftpDir = "installers/jeonsoftautomationtools";
            string filename = "TeamScriptManager.exe";

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl + "/" + ftpDir + "/" + filename);
                request.Credentials = new NetworkCredential(username, password);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream stream = response.GetResponseStream();

                FileStream writeStream = new FileStream(outputDir + "/" + filename, FileMode.Create);
                int length = 2048;

                byte[] buffer = new byte[length];
                int bytesRead = stream.Read(buffer, 0, length);
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = stream.Read(buffer, 0, length);
                }
                stream.Close();
                writeStream.Close();
                request = null;
                e.Result = outputDir + "\\" + filename;
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
                e.Cancel = true;
            }
        }

        private void changeLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLogsForm cf = new ChangeLogsForm();
            cf.ShowDialog();
        }
    }
}
/* SERIAL NUMBERS */