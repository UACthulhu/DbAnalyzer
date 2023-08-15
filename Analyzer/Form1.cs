using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Net.Http.Headers;
using System.Security.Cryptography;


namespace Analyzer
{
    public partial class Form1 : Form
    {
        DbHelper helper;
        DbAnalyzer analyzer;

        public void FillCbProviders()
        {
            foreach (string pn in helper.getProviders())
            {
                CBProviderAnalyze.Items.Add(pn);
                CBProviderReport.Items.Add(pn);

            }
            CBProviderAnalyze.SelectedItem = "express";
        }
        public Form1()
        {
            InitializeComponent();

            helper = new DbHelper();
            analyzer = new DbAnalyzer();
            FillCbProviders();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonAnalyze_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(helper.GetConnType().ToString());
            if(helper.conn != null && helper.conn.State != ConnectionState.Open)
            {
                 helper.OpenConnection();
            }

            //DataGridView dv = new DataGridView();
            //dv.Height = 380;
            //dv.Width = 350;
            //dv.Location = new Point(400,131);
            //this.Controls.Add(dv);

            DGVMain.DataSource = analyzer.GetTables();
            DGVMain.RowHeadersVisible = false;
            //DGVMain.Columns[0].Width = 90;
            DGVMain.Columns[1].Width = 80;
            DGVMain.Width = DGVMain.Columns.GetColumnsWidth(0);

            if (DGVMain.Rows.GetRowsHeight(0) > DGVMain.Height)
                DGVMain.Width += 25;



                DGVMain.Update();
            //if(helper.conn != null && helper.conn.State == ConnectionState.Open)
            //{
            //    helper.CloseConnection();
            //}
        }

        private void CBProviderAnalyze_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? providerName = CBProviderAnalyze.SelectedItem.ToString();

            if (providerName == null)
                throw new Exception("No provider chosen");
            helper.SetProvider(providerName);
            analyzer.SetConnection(helper.GetConnection());
            CBDatabases.Items.Clear();
            foreach (string s in helper.GetDbNames())
            {
                CBDatabases.Items.Add(s);
            }
            CBDatabases.SelectedIndex = 5;
        }

        private void CBDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? DbName = CBDatabases.SelectedItem.ToString();
            if (DbName == null) throw new Exception("No Database chosen");

            helper.SetDb(DbName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            helper.CloseConnection();
        }
    }
}