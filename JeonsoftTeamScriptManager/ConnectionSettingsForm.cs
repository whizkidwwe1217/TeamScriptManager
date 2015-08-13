using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeonsoftTeamScriptManager
{
    public partial class ConnectionSettingsForm : Form
    {
        private bool saveOnClose;

        public ConnectionSettingsForm(bool saveOnClose)
            : this()
        {
            this.saveOnClose = saveOnClose;
        }
        public ConnectionSettingsForm()
        {
            InitializeComponent();
            txtLogin.Text = GlobalOptions.Instance.SqlUsername;
            if (GlobalOptions.Instance.SqlRememberPassword)
                txtPassword.Text = GlobalOptions.Instance.SqlPassword;
            txtServer.Text = GlobalOptions.Instance.SqlServerName;
            chbRemember.Checked = GlobalOptions.Instance.SqlRememberPassword;
            if (GlobalOptions.Instance.SqlIsWindowsAuthentication)
                cboAuthentication.SelectedIndex = 1;
            else
                cboAuthentication.SelectedIndex = 0;
            txtDb.Text = GlobalOptions.Instance.SqlDatabaseName;
        }

        private bool connected = false;

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataSource ds = new DataSource("Parser", txtServer.Text.Trim(), txtDb.Text == "" ? "master" : txtDb.Text, txtLogin.Text.Trim(), txtPassword.Text.Trim(), cboAuthentication.SelectedIndex == 1);
            try
            {
                ds.Connect();
                connected = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!connected)
                e.Cancel = true;
            else
            {
                GlobalOptions.Instance.SqlIsWindowsAuthentication = cboAuthentication.SelectedIndex == 1;
                GlobalOptions.Instance.SqlPassword = txtPassword.Text;
                GlobalOptions.Instance.SqlRememberPassword = chbRemember.Checked;
                GlobalOptions.Instance.SqlUsername = txtLogin.Text;
                GlobalOptions.Instance.SqlServerName = txtServer.Text;
                GlobalOptions.Instance.SqlDatabaseName = txtDb.Text;
                if (saveOnClose)
                    GlobalOptions.Instance.SaveSettings();
                e.Cancel = false;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            connected = true;
        }

        private void cboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAuthentication.SelectedIndex == 0)
            {
                txtPassword.Enabled = true;
                txtLogin.Enabled = true;
                chbRemember.Enabled = true;
            }
            else
            {
                txtPassword.Enabled = false;
                txtLogin.Enabled = false;
                chbRemember.Enabled = false;
            }
        }
    }
}
