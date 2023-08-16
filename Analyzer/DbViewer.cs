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
            DisposeAll();
            DataGridView dgv = createDGV();
            //dgv.Name = "dgv";
            dgv.Location = new Point(10, 135);
            dgv.DataSource = table;
            Resize(dgv);
            dgvl.Add(dgv);
        }

        public void showResult(List<DataTable> tables)
        {
            DisposeAll();
            int w = 10;
            foreach(DataTable table in tables)
            {

                DataGridView dgv = createDGV();
                //dgv.Name = "dgv";
                dgv.Location = new Point(w, 135);
                dgv.DataSource = table;
                Resize(dgv);
                dgvl.Add(dgv);

                w += dgv.Width + 10;
            }


            
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
            dgv.Width = dgv.Columns.GetColumnsWidth(0);

            if (dgv.Rows.GetRowsHeight(0) > dgv.Height)
                dgv.Width += 25;

            dgv.Height = 380;
        }
    }
}
