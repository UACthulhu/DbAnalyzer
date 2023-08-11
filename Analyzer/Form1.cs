using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;


namespace Analyzer
{
    public partial class Form1 : Form
    {
        DbHelper helper;
        public void FillCbProviders()
        {
            foreach (string pn in helper.getProviders())
            {
                CBProviderAnalyze.Items.Add(pn);
                CBProviderReport.Items.Add(pn);

            }
        }
        public Form1()
        {
            InitializeComponent();

            helper = new DbHelper();
            FillCbProviders();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonAnalyze_Click(object sender, EventArgs e)
        {
            MessageBox.Show(helper.GetConnType().ToString());
        }

        private void CBProviderAnalyze_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? providerName = CBProviderAnalyze.SelectedItem.ToString();

            if (providerName == null)
                throw new Exception();
            helper.SetProvider(providerName);
            CBDatabases.Items.Clear();
            foreach (string s in helper.GetDbNames())
            {
                CBDatabases.Items.Add(s);
            }
        }
    }
}