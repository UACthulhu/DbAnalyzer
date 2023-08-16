using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    internal class DbViewer
    {
        public CreateDGV createDGV;


        public List<DataGridView> dgvl;

        public DbViewer(CreateDGV create)
        {
            createDGV = create;
            dgvl = new List<DataGridView>();
        }
        public void showResult(DataTable table)
        {
            FormView fw = new FormView();
            DisposeAll();
            //DataGridView dgv = createDGV();
            DataGridView dgv = new DataGridView();
            fw.Controls.Add(dgv);
            //dgv.Name = "dgv";
            dgv.Location = new Point(10, 10);
            dgv.DataSource = table;
            Resize(dgv);
            dgvl.Add(dgv);
            fw.Height = 500;
            fw.Width = dgv.Width + 20;
            fw.Show();
        }

        public void showResult(List<DataTable> tables)
        {
            FormView fw = new FormView();
            DisposeAll();
            int w = 10;
            foreach(DataTable table in tables)
            {

                //DataGridView dgv = createDGV();
                DataGridView dgv = new DataGridView();
                fw.Controls.Add(dgv);
                //dgv.Name = "dgv";
                dgv.Location = new Point(w, 10);
                dgv.DataSource = table;
                Resize(dgv);
                dgvl.Add(dgv);

                w += dgv.Width + 10;
            }
            fw.Height = 500;
            fw.Width = w + 20;
            fw.Show();
        }

        public void DisposeAll()
        {
            foreach(DataGridView dgv in dgvl)
            {
                dgv.Dispose();
            }
            dgvl.Clear();
        }

        public static void Resize(DataGridView dgv) 
        {
            dgv.Width = 10;

            dgv.RowHeadersVisible = false;
            dgv.Width += dgv.Columns.GetColumnsWidth(0);

            //foreach(DataGridViewColumn c in dgv.Columns)
            //{
            //    dgv.Width += c.Width;
            //}
            //dgv.Width= 500;
            dgv.Height = 380;

            if (dgv.Rows.GetRowsHeight(0) > dgv.Height)
                dgv.Width += 25;

        }
    }
}
