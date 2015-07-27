using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode.SharpCvsLib;
using ICSharpCode.SharpCvsLib.Client;
using ICSharpCode.SharpCvsLib.Attributes;
using ICSharpCode.SharpCvsLib.Commands;
using ICSharpCode.SharpCvsLib.Config;
using ICSharpCode.SharpCvsLib.Exceptions;
using ICSharpCode.SharpCvsLib.Extension;
using ICSharpCode.SharpCvsLib.FileHandler;
using ICSharpCode.SharpCvsLib.FileSystem;
using ICSharpCode.SharpCvsLib.Logs;
using ICSharpCode.SharpCvsLib.Messages;
using ICSharpCode.SharpCvsLib.Misc;
using ICSharpCode.SharpCvsLib.Protocols;
using ICSharpCode.SharpCvsLib.Requests;
using ICSharpCode.SharpCvsLib.Responses;
using ICSharpCode.SharpCvsLib.Streams;
using ICSharpCode.SharpCvsLib.Util;
using System.Diagnostics;

namespace CVSTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private BackgroundWorker bw;

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync();
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CVS();
            }
            catch(Exception ex)
            {
                richTextBox1.AppendText(ex.Message);
            }
        }

        private void CVS()
        {
            string command = @"C:\Program Files (x86)\CVSNT\cvs";
            string auth = @"-d :pserver:wendell@main:/cvsroot ";
            string arguments = @"-q -Q ls -q /";
            string startPath = @"D:\Wayne Lapstop\Jeonsoft\Software Projects\Latest JPS\head\jps 2007\jps 2007\Database\Schema\stored procs";

            string line = StartProcess(startPath, command, auth + arguments);
            //richTextBox1.AppendText(line);

            arguments = @"-q -f log uspAddEmployees.sqdl";
            line = StartProcess(startPath, command, auth + arguments);
            richTextBox1.AppendText(line);
        }

        private string StartProcess(string startPath, string command, string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo(command, arguments);
            Process proc = new Process();
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.WorkingDirectory = startPath;
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            proc.StartInfo = psi;
            proc.Start();
            StringBuilder sb = new StringBuilder();
            while (!proc.StandardOutput.EndOfStream)
            {
                sb.AppendLine(proc.StandardOutput.ReadToEnd());
            }
            while(!proc.StandardError.EndOfStream)
            {
                sb.AppendLine(proc.StandardError.ReadToEnd());
            }
            return sb.ToString();
        }

        private void OpenCvs()
        {
            CvsRoot root = new CvsRoot(@":pserver:wendell@main:/cvsroot");
            string localdirectory = @"D:\Trash\CVS";
            string moduleName = @"KeyGen";

            WorkingDirectory wd = new WorkingDirectory(root, localdirectory, moduleName);
            CVSServerConnection con = new CVSServerConnection(wd);
            try
            {
                // CONNECTION
                richTextBox1.AppendText("Connecting..." + Environment.NewLine);
                con.Connect(wd, "Azure_884#");
                richTextBox1.AppendText("Connected." + Environment.NewLine);

                //goto fetch;
                // CHECK OUT
                richTextBox1.AppendText("Checking out..." + Environment.NewLine);
                CheckoutModuleCommand cmd = new CheckoutModuleCommand(wd);
                cmd.Execute(con);
                richTextBox1.AppendText("Check out complete." + Environment.NewLine);

         
                // FETCH LIST
                string str = System.IO.Path.Combine(localdirectory, moduleName);
                Manager manager = new Manager(str);
                manager.AddDirectories(str);
                manager.GetFolders(str +"\\Source");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText("Error: " + ex.Message + Environment.NewLine);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = @"\\newdevserver.jeonsoft.local\On Going Scripts\JPS";
            //string url = @"C:\Program Files\";
            string host = string.Empty;
            //MessageBox.Show(Utils.GetHostType(url, ref host).ToString());
            //MessageBox.Show(host);
            //MessageBox.Show(Utils.GetHostName("\\newdevserver\\"));
            Uri uri = new Uri(url);
            MessageBox.Show(System.Net.Dns.GetHostByName("newdevserver.jeonsoft.local").HostName);
            //MessageBox.Show(System.Net.Dns.GetHostEntry("newdevserver").HostName);
            //MessageBox.Show(System.Net.Dns.GetHostEntry("10.0.0.3").HostName);
        }
    }
}
