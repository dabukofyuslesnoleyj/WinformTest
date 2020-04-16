using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CsvHelper;
using Json.Net;
using System.Globalization;

namespace WindowsFormsAppIO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DataTable dataGridViewToDataTable(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                dt.Columns.Add(col.Name);
            }


            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            return dt;
        }

        private void importCsvBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK){               
                var reader = new StreamReader(openFileDialog1.FileName);
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var dr = new CsvDataReader(csv);

                var dt = new DataTable();
                dt.Columns.Add("Id",typeof(int));
                dt.Columns.Add("Name",typeof(string));
                dt.Columns.Add("Progress",typeof(int));

                dt.Load(dr);

                dataGridView1.DataSource = dt;
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveCsvBtn_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var dt = dataGridViewToDataTable(dataGridView1);
                string jsonData = JsonNet.Serialize(dt);

                File.WriteAllText(saveFileDialog1.FileName+".json", jsonData);

            }

        }
    }
}
