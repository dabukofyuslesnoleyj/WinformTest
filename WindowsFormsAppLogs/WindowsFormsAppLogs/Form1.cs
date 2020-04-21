using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppLogs
{
    public partial class Form1 : Form
    {
        private Log_Collection logs;

        public Form1()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void importLogBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                logDataGridView.ColumnCount = 4;

                logDataGridView.Columns[0].Name = "Tag";
                logDataGridView.Columns[1].Name = "Category";
                logDataGridView.Columns[2].Name = "Timestamp";
                logDataGridView.Columns[3].Name = "Message";

                string input_log = File.ReadAllText(openFileDialog1.FileName);
                string[] log_messages = input_log.Split('\n');

                foreach (string log_message in log_messages)
                {
                    string[] log_params = log_message.Split(',');

                    LogMessage lm = new LogMessage(log_params);
                    string[] temp = { log_params[0], log_params[1], log_params[2], lm.messageBody.ToString() };
                    logDataGridView.Rows.Add(temp);

                }
            }
        }
    }
}
