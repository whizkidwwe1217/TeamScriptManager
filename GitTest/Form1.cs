using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibGit2Sharp;

namespace GitTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           using (FolderBrowserDialog fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    txtWorkingPath.Text = fd.SelectedPath;
                    rtb.AppendText(LoadWorkingCopy(fd.SelectedPath) + Environment.NewLine);
                }
            }
        }

        private string LoadWorkingCopy(string path)
        {
            string output = Repository.Discover(path);
            return output;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (txtWorkingPath.Text.Trim().Length > 0)
                rtb.AppendText(LoadWorkingCopy(txtWorkingPath.Text) + Environment.NewLine);
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            rtb.AppendText(Clone(txtUrl.Text) + Environment.NewLine);
        }

        private string Clone(string url)
        {
            var co = new CloneOptions()
            {
                BranchName = "develop",
                CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials() { Username = "wendell", Password = "Iloveu_ckc2233#" },
                OnProgress = delegate(string progress) {
                    rtb.AppendText(progress + Environment.NewLine);
                    return true;
                }
            };
            
            string output = Repository.Clone(url, txtWorkingPath.Text, co);
            return output;
        }

        private void btnListFiles_Click(object sender, EventArgs e)
        {
            ListBranches(txtWorkingPath.Text);
        }

        private void ListBranches(string path)
        {
            using (var repo = new Repository(path))
            {
                foreach (Branch b in repo.Branches)
                    rtb.AppendText(b.FriendlyName + Environment.NewLine);
            }
        }

        private void btnDiff_Click(object sender, EventArgs e)
        {
            Diff();
        }

        private void Diff()
        {
            using (var repo = new Repository(txtWorkingPath.Text))
            {
                foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>())
                {
                    rtb.AppendText(c.Status.ToString() + " " + c.Path + Environment.NewLine);
                }

                foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>(repo.Head.Tip.Tree,
                                                  DiffTargets.Index | DiffTargets.WorkingDirectory))
                {
                    rtb.AppendText(c.Status.ToString() + " " + c.Path + Environment.NewLine);
                }
            }
        }
    }
}
