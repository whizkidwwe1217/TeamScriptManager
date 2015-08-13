using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace JeonsoftTeamScriptManager
{
    public class DataSource
    {
        private string name;
        private string serverName;

        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }
        private string databaseName;

        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private bool isIntegratedSecurity;

        public bool IsIntegratedSecurity
        {
            get { return isIntegratedSecurity; }
            set { isIntegratedSecurity = value; }
        }

        public DataSource(string name, string serverName, string databaseName, string username, string password, bool isIntegratedSecurity)
        {
            this.name = name;
            this.serverName = serverName;
            this.databaseName = databaseName;
            this.username = username;
            this.password = password;
            this.isIntegratedSecurity = isIntegratedSecurity;
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.UserID = username;
            sb.Password = password;
            sb.DataSource = serverName;
            sb.InitialCatalog = databaseName;
            sb.IntegratedSecurity = isIntegratedSecurity;
            connectionString = sb.ConnectionString;
        }

        private string connectionString;
        public string ConnectionString
        {
            get { return connectionString; }
        }

        public void Connect()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Connection error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void Parse(string query)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SET PARSEONLY ON", con);
                cmd.ExecuteNonQuery();

                string[] splitter = new string[] { "\r\nGO\r\n" };
                string[] commandTexts = query.Split(splitter,
                  StringSplitOptions.RemoveEmptyEntries);
                foreach (string commandText in commandTexts)
                {
                    cmd.CommandText = commandText;
                    cmd.ExecuteNonQuery();
                }

                cmd.CommandText = "SET PARSEONLY OFF";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("SQL error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
