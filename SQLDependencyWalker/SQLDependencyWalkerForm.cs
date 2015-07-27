using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Common;

namespace SQLDependencyWalker
{
    public partial class SQLDependencyWalkerForm : Form
    {
        public SQLDependencyWalkerForm()
        {
            InitializeComponent();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            ServerConnection con = new ServerConnection("WAYNE-LAPTOP\\MSSQL2012", "sa", "masterkey");
            Server server = new Server(con);
            Scripter scripter = new Scripter(server);
            scripter.Options.ScriptDrops = false;
            scripter.Options.WithDependencies = true;
            scripter.Options.Indexes = true;
            scripter.Options.DriAllConstraints = true;
            Database db = server.Databases["sephil"];
            foreach (Table tb in db.Tables)
            {
                if (tb.IsSystemObject == false && tb.Name.Contains("tblEmployees"))
                {
                    System.Collections.Specialized.StringCollection sc = scripter.Script(new Urn[] { tb.Urn });
                    foreach (string st in sc)
                    {
                        MessageBox.Show(st);
                    }
                }
            }
        }
    }
}
