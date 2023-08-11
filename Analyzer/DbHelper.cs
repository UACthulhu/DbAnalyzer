using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

namespace Analyzer
{
    internal class DbHelper
    {
        DbProviderFactory? factory;
        DbConnection? conn;

        DbHelper()
        {
            RegisterProviders();
        }

        public static void RegisterProviders()
        {
            DbProviderFactories.RegisterFactory("express", SqlClientFactory.Instance);
            DbProviderFactories.RegisterFactory("mysql", MySqlClientFactory.Instance);
        }
        public void SetProvider(string name)
        {
            factory = DbProviderFactories.GetFactory(name);
            conn = factory.CreateConnection();

            if(conn == null) throw new Exception("No connection");

            conn.ConnectionString = ConfigurationManager
                .ConnectionStrings[name]
                .ConnectionString;
        }
        public DbConnection GetConnection()
        {
            if (conn == null) throw new Exception("No connection");
            return conn;
        }
        public IEnumerable<string> getProviders()
        {
            return DbProviderFactories.GetProviderInvariantNames();
        }

        public void OpenConnection()
        {
            if (conn == null) throw new Exception("No connection");

            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        public void CloseConnection()
        {
            if (conn == null) throw new Exception("No connection");

            if (conn.State == ConnectionState.Open)
                conn.Close();   
        }
    }
}
