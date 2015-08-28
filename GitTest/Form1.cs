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
            richTextBox1.Clear();
            string dest = @"C:\Program Files (x86)\JeonSoft Corporation\Team Script Manager\Recent Configs\Git Test";
            string rootedPath = Repository.Init(dest);
            richTextBox1.AppendText(rootedPath + Environment.NewLine);
        }
    }
}
