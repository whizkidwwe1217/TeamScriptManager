using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JeonsoftTeamScriptManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                if (Environment.CommandLine.LastIndexOf("-merge") > 0)
                {
                    try
                    {
                        MainForm.MergeCatalogScripts(args[0].Trim());
                    }
                    catch(Exception ex)
                    {
                        MainForm.AppendToLogFile("Error: " + ex.Message);
                    }
                }
                else
                    Application.Run(new MainForm(args[0]));
            }
            else
                Application.Run(new MainForm(string.Empty));
        }
    }
}
