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
        private const string SqlDbListQuery = "SELECT name FROM master.sys.databases;";
        private const string MySqlDbListQuery = "SHOW DATABASES";

        public const string SqlCreateDbQuery = "exec ('CREATE DATABASE ' + @name)";
        public const string SqlDropDbQuery = "exec ('DROP DATABASE ' + @name)";

        public const string SqlTablesListQuery = "SELECT o.name AS [TableName] FROM sys.objects AS o INNER JOIN sys.partitions AS p ON o.object_id = p.object_id WHERE o.type = 'U' GROUP BY o.name;";
        public const string MySqlTablesListQuery = "SELECT o.name AS [TableName] FROM sys.objects AS o INNER JOIN sys.partitions AS p ON o.object_id = p.object_id WHERE o.type = 'U' GROUP BY o.name;";


        public DbProviderFactory? factory;
        public DbConnection? conn;

        public DbHelper()
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
            if (conn != null && conn.State == ConnectionState.Open)
            {
                CloseConnection();
            }

            factory = DbProviderFactories.GetFactory(name);
            conn = factory.CreateConnection();

            if(conn == null) throw new Exception("No connection");

            conn.ConnectionString = ConfigurationManager
                .ConnectionStrings[name]
                .ConnectionString;

            OpenConnection();
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

        public string GetConnType()
        {
            if (conn == null) throw new Exception();   
            return conn.GetType().Name;
        }

        public List<string> GetDbNames()
        {
            //OpenConnection();
            DbCommand? cmd = null;
            switch (GetConnType())
            {
                case "SqlConnection":
                    cmd = new SqlCommand(SqlDbListQuery, conn as SqlConnection);
                    break;
                case "MySqlConnection":
                    cmd = new MySqlCommand(MySqlDbListQuery, conn as MySqlConnection);  
                    break;
            }
            if (cmd == null) throw new Exception("cmd is empty");
            DbDataReader reader =  cmd.ExecuteReader();

            DataTable result = new DataTable();
            result.Load(reader);

            List<string> dbList = new List<string>();
            foreach (DataRow r in result.Rows)
                dbList.Add($"{r[0]}");

            //CloseConnection();
            return dbList;
        }

        public List<string> GetTablesNames()
        {
            //OpenConnection();
            DbCommand? cmd = null;
            switch (GetConnType())
            {
                case "SqlConnection":
                    cmd = new SqlCommand(SqlTablesListQuery, conn as SqlConnection);
                    break;
                case "MySqlConnection":
                    cmd = new MySqlCommand(MySqlTablesListQuery, conn as MySqlConnection);
                    break;
            }
            if (cmd == null) throw new Exception("cmd is empty");
            DbDataReader reader = cmd.ExecuteReader();

            DataTable result = new DataTable();
            result.Load(reader);

            List<string> dbList = new List<string>();
            foreach (DataRow r in result.Rows)
                dbList.Add($"{r[0]}");

            //CloseConnection();
            return dbList;
        }

        public void SetDb(string name)
        {
            if (conn == null) throw new Exception("No connection");
            conn.ChangeDatabase(name);
        }

        // -

        public void CreateDb(string Name)
        {
            if (conn == null) throw new Exception("No connection");
            if (conn.State != ConnectionState.Open)
                OpenConnection();

            ExecuteParQuery(SqlCreateDbQuery, "@name", Name, conn);

        }

        public void DropDb(string Name)
        {
            if (conn == null) throw new Exception("No connection");
            if (conn.State != ConnectionState.Open)
                OpenConnection();

            ExecuteParQuery(SqlDropDbQuery, "@name", Name, conn);
        }

        public static void ExecuteParQuery(string query, string parametrName, string parametrValue, DbConnection conn)
        {
            DbCommand cmd;
            DbParameter parameter;
            switch (conn.GetType().Name)
            {
                case "SqlConnection":
                    cmd = new SqlCommand()
                    {
                        Connection = conn as SqlConnection
                    };
                    parameter = new SqlParameter();
                    break;
                case "MySqlConnection":
                    cmd = new MySqlCommand()
                    {
                        Connection = conn as MySqlConnection
                    };
                    parameter = new MySqlParameter();
                    break;
                default: throw new Exception("no connection");
            }

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            parameter.Value = parametrValue;
            parameter.ParameterName = parametrName;

            cmd.Parameters.Add(parameter);

            cmd.ExecuteNonQuery();
        }
    }
}
