using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;

namespace Analyzer
{
    internal class DbAnalyzer
    {
        public const string SqlTablesQuery = "SELECT o.name AS [TableName], SUM(p.Rows) AS [RowCount] FROM sys.objects AS o INNER JOIN sys.partitions AS p ON o.object_id = p.object_id WHERE o.type = 'U' GROUP BY o.schema_id, o.name;";
        public const string MySqlTablesQuery = "SELECT table_name, TABLE_ROWS FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = DATABASE();";


        public DbConnection? conn { get; set;}

        public void SetConnection(DbConnection connection)
        {
            conn = connection;
        }
        public DataTable GetTables()
        {
            if (conn == null) throw new Exception("No connection");

            DbCommand? cmd = null;
            switch (conn.GetType().Name)
            {
                case "SqlConnection":
                    cmd = new SqlCommand(SqlTablesQuery, conn as SqlConnection);
                    break;
                case "MySqlConnection":
                    cmd = new MySqlCommand(MySqlTablesQuery, conn as MySqlConnection);
                    break;
            }
            if (cmd == null) throw new Exception("cmd is empty");
            DbDataReader reader = cmd.ExecuteReader();

            DataTable result = new DataTable();
            result.Load(reader);

            //List<string> TbList = new List<string>();
            //foreach (DataRow r in result.Rows)
            //    TbList.Add($"{r[0]}");

            return result;
        }


    }
}
