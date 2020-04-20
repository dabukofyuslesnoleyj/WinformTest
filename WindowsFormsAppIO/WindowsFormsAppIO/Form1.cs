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
using Newtonsoft.Json;

namespace WindowsFormsAppIO
{
    public partial class Form1 : Form
    {
        DataTable mainDT;
        public Form1()
        {
            InitializeComponent();
        }

        private DataTable dataGridViewToDataTable(DataGridView dgv)
        {
            var dt = dgv.DataSource as DataTable;

            return dt;
        }

        private void fillProgressChart(DataTable dt)
        {
            progressChart.DataSource = dt;

            while (progressChart.Series["Progress"].Points.Count > 0) { progressChart.Series["Progress"].Points.RemoveAt(0); }

            foreach (DataRow row in dt.Rows)
            {
                progressChart.Series["Progress"].Points.AddXY(row["Name"], row["Progress"]);
            }
            
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

                mainDT = dt.Copy();

                dataGridView1.DataSource = dt;

                fillProgressChart(dt);
                
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
                   string jsonData = JsonConvert.SerializeObject(dt, Formatting.Indented);
                
                File.WriteAllText(saveFileDialog1.FileName+".json", jsonData);

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void saveFileBtn_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var dt = mainDT;

                var textwriter = new StringWriter();
                var csv = new CsvWriter(textwriter, CultureInfo.InvariantCulture);
                
                foreach(DataColumn dc in dt.Columns)
                {
                    csv.WriteField(dc.ColumnName);
                }
                csv.NextRecord();

                foreach(DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        csv.WriteField(dr[i]);
                    }
                    csv.NextRecord();
                }

                string data = textwriter.ToString();
                textwriter.Flush();
                File.WriteAllText(saveFileDialog1.FileName + ".csv", data);
            }
            

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            var dt = mainDT.Copy();

            int init_rows = dt.Rows.Count;

            for (int i = trackBar1.Value; i < init_rows; i++)
            {
                dt.Rows.RemoveAt(dt.Rows.Count-1);
            }
            fillProgressChart(dt);
            dataGridView1.DataSource = dt;
        }

        private void importJSONBtn_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string read_data = File.ReadAllText(openFileDialog1.FileName);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(read_data);

                mainDT = dt.Copy();

                dataGridView1.DataSource = dt;

                fillProgressChart(dt);
            }
        }
    }
}
