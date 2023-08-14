using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    internal class DbAnalyzer
    {
        //public const string MySqlTablesQuery = "SELECT table_name FROM information_schema.tables where table_type = 'BASE TABLE'";
        //public const string SqlTablesQuery = "SELECT table_name FROM information_schema";

        public DbConnection? conn { get; set;}

        public void SetConnection(DbConnection connection)
        {
            conn = connection;
        }
        public DataTable GetTables()
        {
            if (conn == null) throw new Exception("No connection");

            DataTable dt = conn.GetSchema("Tables");
            return dt;
        }


    }
}
