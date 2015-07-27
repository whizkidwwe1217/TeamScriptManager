using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JeonsoftTeamScriptManager
{
    public partial class InputBox : Form
    {
        public InputBox(string defaultvalue)
        {
            InitializeComponent();
            textBox1.Text = defaultvalue;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = textBox1.Text.Trim() != "";
        }

        public event EventHandler OKClick;
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (OKClick != null)
                    OKClick(textBox1, new EventArgs());
            }
        }
    }
}
