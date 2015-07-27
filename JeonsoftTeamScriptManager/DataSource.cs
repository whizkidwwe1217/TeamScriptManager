﻿using System;
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
        }
    }
}
