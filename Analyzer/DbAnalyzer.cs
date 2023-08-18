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
        public const string SqlTablesQuery = "SELECT o.name AS [TableName], SUM(p.Rows) AS [RowCount], DB_NAME() AS [DataBaseName] FROM sys.objects AS o INNER JOIN sys.partitions AS p ON o.object_id = p.object_id WHERE o.type = 'U' GROUP BY o.schema_id, o.name;";
        public const string MySqlTablesQuery = "SELECT table_name, TABLE_ROWS, DATABASE() FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = DATABASE();";

        public const string SqlTablesCreateDateQuery = "SELECT o.create_date AS [CreateDate] FROM sys.objects AS o INNER JOIN sys.partitions AS p ON o.object_id = p.object_id WHERE o.type = 'U' GROUP BY o.schema_id, o.name, o.create_date;";
        public const string MySqlTablesCreateDateQuery = "SELECT create_time FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = DATABASE();";

        public const string SqlProceduredQuery = "SELECT ROUTINE_NAME AS [Name], ROUTINE_DEFINITION AS [Definition], SPECIFIC_CATALOG AS [DbName] FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE';";
        public const string MySqlProceduredQuery = "SELECT ROUTINE_NAME, ROUTINE_DEFINITION, DATABASE() FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE';";

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

            return result;
        }
        public DataTable GetProcedures()
        {
            if (conn == null) throw new Exception("No connection");

            DbCommand? cmd = null;
            switch (conn.GetType().Name)
            {
                case "SqlConnection":
                    cmd = new SqlCommand(SqlProceduredQuery, conn as SqlConnection);
                    break;
                case "MySqlConnection":
                    cmd = new MySqlCommand(MySqlProceduredQuery, conn as MySqlConnection);
                    break;
            }
            if (cmd == null) throw new Exception("cmd is empty");
            DbDataReader reader = cmd.ExecuteReader();

            DataTable result = new DataTable();
            result.Load(reader);

            return result;
        }

        public DataTable GetCreateDates()
        {
            if (conn == null) throw new Exception("No connection");

            DbCommand? cmd = null;
            switch (conn.GetType().Name)
            {
                case "SqlConnection":
                    cmd = new SqlCommand(SqlTablesCreateDateQuery, conn as SqlConnection);
                    break;
                case "MySqlConnection":
                    cmd = new MySqlCommand(MySqlTablesCreateDateQuery, conn as MySqlConnection);
                    break;
            }
            if (cmd == null) throw new Exception("cmd is empty");
            DbDataReader reader = cmd.ExecuteReader();

            DataTable result = new DataTable();
            result.Load(reader);

            return result;
        }

        public List<DataTable> Analyze(bool procedures, bool dateCreated, bool dateAnalyzed)
        {
            List<DataTable> result = new List<DataTable>();
            DataTable dtTables = GetTables();
            if (dateCreated)
            {
                DataTable dCd = GetCreateDates();
                dtTables.Columns.Add(dCd.Columns[0].ColumnName, dCd.Columns[0].DataType);
                foreach (DataRow r in dtTables.Rows)
                {
                    r[dCd.Columns[0].ColumnName] = dCd.Rows[dtTables.Rows.IndexOf(r)][dCd.Columns[0].ColumnName];
                }
            }
            if(dateAnalyzed)
            {
                dtTables.Columns.Add("AnalyzedAt", typeof(DateTime));
                foreach (DataRow r in dtTables.Rows)
                {
                    r["AnalyzedAt"] = DateTime.Now;
                }
            }
            result.Add(dtTables);
            if(procedures)
            {
                result.Add(GetProcedures());
            }

            return result;           
        }

    }
}
