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
            logDataGridView.ColumnCount = 4;

            logDataGridView.Columns[0].Name = "Tag";
            logDataGridView.Columns[1].Name = "Category";
            logDataGridView.Columns[2].Name = "Timestamp";
            logDataGridView.Columns[3].Name = "Message";
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void importLogBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                List<LogMessage> log_list = new List<LogMessage>();
                string input_log = File.ReadAllText(openFileDialog1.FileName);
                string[] log_messages = input_log.Split('\n');

                foreach (string log_message in log_messages)
                {
                    string[] log_params = log_message.Split(',');

                    LogMessage lm = new LogMessage(log_params);

                    log_list.Add(lm);

                }
                logs = new Log_Collection(log_list);
                drawDataGrid(log_list);
                displayInfo(logs);
            }
        }

        private void displayInfo(Log_Collection logs)
        {
            int[] temp = logs.getTypeCount();
            typeCountBox.AppendText("INFO: " + temp[0]);
            typeCountBox.AppendText(Environment.NewLine);
            typeCountBox.AppendText("WARNING: " + temp[1]);
            typeCountBox.AppendText(Environment.NewLine);
            typeCountBox.AppendText("ERROR: " + temp[2]);

            foreach(string source in logs.getSources())
            {
                SourceCountBox.AppendText(source+" : "+logs.getSourceCount(source));
                SourceCountBox.AppendText(Environment.NewLine);
            }
            
        }

        private void drawDataGrid(List<LogMessage> log_list)
        {
            foreach (LogMessage log in log_list)
            {
                if (log.messageSource != null)
                {
                    string[] s = { log.typeAsString(), log.messageSource, log.messageTimestamp.ToString(), string.Join("", log.messageBody) };
                    logDataGridView.Rows.Add(s);
                }
                
            }
            
        }

    }
}
