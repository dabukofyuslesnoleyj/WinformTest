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

namespace WindowsFormsAppIO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void importCsvBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK){               
                var reader = new StreamReader(openFileDialog1.FileName);
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                var dt = new DataTable();
                dt.Columns.Add("Id",typeof(int));
                dt.Columns.Add("Name",typeof(string));
                dt.Columns.Add("Progress",typeof(int));

                dt.Load(csv);

                dataGridView1.DataSource = dt;
            }
        }
    }
}
