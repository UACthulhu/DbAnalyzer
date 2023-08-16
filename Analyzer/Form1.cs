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
        DbViewer viewer;



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
            viewer = new DbViewer();

            FillCbProviders();

        }
        private void ButtonAnalyze_Click(object sender, EventArgs e)
        {
            if(helper.conn != null && helper.conn.State != ConnectionState.Open)
            {
                 helper.OpenConnection();
            }


            viewer.showResult(analyzer.Analyze(CBProcedures.Checked, CBDateCreated.Checked, CBDateCurrent.Checked));

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
            CBDatabases.SelectedIndex = 4;
        }
        private void CBDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? DbName = CBDatabases.SelectedItem.ToString();
            if (DbName == null) throw new Exception("No Database chosen");

            helper.SetDb(DbName);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            helper.CloseConnection();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {

        }
    }
}