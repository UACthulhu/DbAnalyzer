using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    internal class ReportSaver
    {
        public const string SqlCreateTableTQuery = "exec ('CREATE TABLE ' + @name + '(Id int NOT NULL IDENTITY, ReportId int NOT NULL, TableName varchar(50) NOT NULL, DBName varchar(50) NOT NULL, RowsCount int NOT NULL, DateCreate DateTime NULL, DateReport DateTime NULL);');";
        public const string SqlCreateTablePQuery = "exec ('CREATE TABLE ' + @name + '(Id int NOT NULL IDENTITY, ReportId int NOT NULL, ProcedureName varchar(50) NOT NULL, DBName varchar(50) NOT NULL, Def varchar(2048));')";

        public DbConnection? conn { get; set; }
        public void SetConnection(DbConnection conn)
        {
            this.conn = conn;
        }

        public void CrateTableT(string name)
        {
            if (conn == null) throw new Exception("no connection");
            DbHelper.ExecuteParQuery(SqlCreateTableTQuery, "@name", name, conn);
        }

        public void CrateTableP(string name)
        {
            if (conn == null) throw new Exception("no connection");
            DbHelper.ExecuteParQuery(SqlCreateTablePQuery, "@name", name, conn);
        }

    }
}
