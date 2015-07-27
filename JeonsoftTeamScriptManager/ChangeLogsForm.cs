using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Html;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeonsoftTeamScriptManager
{
    public partial class ChangeLogsForm : Form
    {
        private HtmlPanel hp;

        public ChangeLogsForm()
        {
            InitializeComponent();
            hp = new HtmlPanel();
            hp.Dock = DockStyle.Fill;
            hp.Parent = this;
            hp.Text = Properties.Resources.ChangeLog;
        }      
    }
}
