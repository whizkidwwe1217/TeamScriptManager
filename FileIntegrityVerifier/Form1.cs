using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FileIntegrityVerifier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnStop.Enabled = false;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a file";
                ofd.Filter = "All Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txt1.Text = ofd.FileName;
                    FileInfo one = new FileInfo(ofd.FileName);
                    lblOneSize.Text = one.Length + " bytes";
                }
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a file";
                ofd.Filter = "All Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txt2.Text = ofd.FileName;
                    FileInfo one = new FileInfo(ofd.FileName);
                    lblTwoSize.Text = one.Length + " bytes";
                }
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (txt1.Text.Trim().Length == 0)
            {
                Error("File 1 is not specified.");
                return;
            }
            if (txt2.Text.Trim().Length == 0)
            {
                Error("File 2 is not specified.");
                return;
            }
            FileInfo one = new FileInfo(txt1.Text.Trim());
            FileInfo two = new FileInfo(txt2.Text.Trim());
            if (!one.Exists)
                Error("Cannot find File 1!");
            else if (!two.Exists)
                Error("Cannot find File 2!");
            else
            {
                Processed += Form1_Processed;
                FilesAreEqual(one, two);
            }
        }

        private void Form1_Processed(bool result)
        {
            if (result)
                Success("Files are equal.");
            else
                Error("Files are not equal.");
            btnVerify.Enabled = true;
            btnStop.Enabled = false;
        }

        private void Error(string message)
        {
            lblResult.Text = message;
            lblResult.ForeColor = Color.Red;
        }

        private void Success(string message)
        {
            lblResult.Text = message;
            lblResult.ForeColor = Color.Green;
        }

        private void Progress(string message)
        {
            lblResult.ForeColor = Color.Black;
            lblResult.Text = message;
        }

        public const int BYTES_TO_READ = sizeof(Int64);

        struct AsyncParam
        {
            public FileInfo First { get; set; }
            public FileInfo Second { get; set; }
        }

        public void FilesAreEqual(FileInfo first, FileInfo second)
        {
            AsyncParam param = new AsyncParam()
            {
                First = first,
                Second = second
            };
            ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncProcess), param);
        }

        public delegate void OnProcessedHandler(bool result);
        public event OnProcessedHandler Processed;

        public void OnProcessed(bool result)
        {
            if (Processed != null)
                Processed(result);
        }

        private void AsyncProcess(object param)
        {
            AsyncParam ap = (AsyncParam)param;

            if (ap.First.Length != ap.Second.Length)
            {
                OnProcessed(false);
                return;
            }

            int iterations = (int)Math.Ceiling((double)ap.First.Length / BYTES_TO_READ);

            progressBar.Maximum = iterations;
            progressBar.Minimum = 0;
            progressBar.Value = 0;
            btnVerify.Enabled = false;
            btnStop.Enabled = true;
            stopped = false;

            using (FileStream fs1 = ap.First.OpenRead())
            using (FileStream fs2 = ap.Second.OpenRead())
            {
                byte[] one = new byte[BYTES_TO_READ];
                byte[] two = new byte[BYTES_TO_READ];

                for (int i = 0; i < iterations; i++)
                {
                    progressBar.Value = i;
                    double a = (double)i;
                    double b = (double)iterations;
                    double progress = Math.Round(a / b * 100.0, 2);
                    Progress("Reading chunk of bytes..." + (BYTES_TO_READ * i).ToString() + " of " + iterations.ToString() + " (" + progress.ToString() + "%)");
                    if (stopped)
                    {
                        progressBar.Value = 0;
                        btnVerify.Enabled = true;
                        Progress("Process stopped.");
                        return;
                    }
                    fs1.Read(one, 0, BYTES_TO_READ);
                    fs2.Read(two, 0, BYTES_TO_READ);

                    if (BitConverter.ToInt64(one, 0) != BitConverter.ToInt64(two, 0))
                    {
                        OnProcessed(false);
                        return;
                    }
                }
            }

            OnProcessed(true);
        }

        private bool stopped = true;

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopped = true;
            btnStop.Enabled = false;
        }

        private void btnCalculateChecksum_Click(object sender, EventArgs e)
        {
            string str = File.ReadAllText(txt1.Text, UTF8Encoding.UTF8);
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                string hash = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", String.Empty);
                txtChecksum.Text = hash;
            }
        }
    }
}
