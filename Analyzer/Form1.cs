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
        ReportSaver saver;


        public void FillCbProviders()
        {
            foreach (string pn in helper.getProviders())
            {
                CBProviderAnalyze.Items.Add(pn);
                CBProviderReport.Items.Add(pn);

            }
            CBProviderAnalyze.SelectedItem = "express";
            CBProviderReport.SelectedItem = "express";
        }
        public Form1()
        {
            InitializeComponent();

            helper = new DbHelper();
            analyzer = new DbAnalyzer();
            viewer = new DbViewer();
            saver = new ReportSaver();

            FillCbProviders();

        }
        private void ButtonAnalyze_Click(object sender, EventArgs e)
        {
            string? providerName = CBProviderAnalyze.SelectedItem.ToString();

            if (providerName == null)
                throw new Exception("No provider chosen");
            helper.SetProvider(providerName);

            string? DbName = CBDatabases.SelectedItem.ToString();
            if (DbName == null) throw new Exception("No Database chosen");

            helper.SetDb(DbName);

            analyzer.SetConnection(helper.GetConnection());

            viewer.showResult(analyzer.Analyze(CBProcedures.Checked, CBDateCreated.Checked, CBDateCurrent.Checked));

        }

        private void CBProviderAnalyze_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? providerName = CBProviderAnalyze.SelectedItem.ToString();

            if (providerName == null)
                throw new Exception("No provider chosen");
            helper.SetProvider(providerName);
            //analyzer.SetConnection(helper.GetConnection());
            CBDatabases.Items.Clear();
            foreach (string s in helper.GetDbNames())
            {
                CBDatabases.Items.Add(s);
            }
            CBDatabases.SelectedIndex = 4;
        }
        private void CBDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string? DbName = CBDatabases.SelectedItem.ToString();
            //if (DbName == null) throw new Exception("No Database chosen");

            //helper.SetDb(DbName);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            helper.CloseConnection();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string name = "test";

            string? providerName = CBProviderReport.SelectedItem.ToString();
            string? DbName = CBDBSave.SelectedItem.ToString();

            if (providerName == null)
                throw new Exception("No provider chosen");
            helper.SetProvider(providerName);

            if (DbName == null) throw new Exception("no db set");

            if (DbName == "NewDB")
            {
                if (!helper.GetDbNames().Contains(name))
                    helper.CreateDb(name);
                else
                {
                    helper.DropDb(name);
                    helper.CreateDb(name);
                }
                DbName = name;
            }

            helper.SetDb(DbName);

            string nameT = "testT";
            string nameP = "testP";

            saver.SetConnection(helper.GetConnection());

            if (!helper.GetTablesNames().Contains(nameT))
                saver.CrateTableT(nameT);
            if (!helper.GetTablesNames().Contains(nameP))
                saver.CrateTableP(nameP);

        }
        private void CBDBSave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (saver.conn == null) throw new Exception("no connection");
            

        }

        private void CBProviderReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? providerName = CBProviderReport.SelectedItem.ToString();

            if (providerName == null)
                throw new Exception("No provider chosen");
            helper.SetProvider(providerName);
            saver.SetConnection(helper.GetConnection());
            CBDBSave.Items.Clear();
            foreach (string s in helper.GetDbNames())
            {
                CBDBSave.Items.Add(s);
            }
            CBDBSave.Items.Add("NewDB"); 
            CBDBSave.SelectedItem = "NewDB";
        }
    }
}