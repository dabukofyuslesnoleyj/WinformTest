using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            logDataGridView.Columns[3].Width = 400;
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
                    Regex regex = new Regex("^(INFO|WARNING|ERROR),(.*?),(.*?),");
                    Match match = regex.Match(log_message);
                    string log_header = match.Groups[0].Value;
                    List<string> log_header_split = log_header.Split(',').ToList();

                    string log_body = log_message.Remove(0, log_header.Length);

                    LogMessage lm = new LogMessage(log_header_split, log_body);

                    log_list.Add(lm);

                }
                logs = new Log_Collection(log_list);
                drawDataGrid(log_list);
                displayInfo(logs);
                initializeCheckedLIstBox();
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

            if(logs.getStartDate() == logs.getEndDate())
            {
                dateTextBox.AppendText("Date: " + logs.getStartDate());
                dateTextBox.AppendText(Environment.NewLine);
            }
            else
            {
                dateTextBox.AppendText("From Date: " + logs.getStartDate());
                dateTextBox.AppendText(Environment.NewLine);
                dateTextBox.AppendText("To Date: " + logs.getEndDate());
                dateTextBox.AppendText(Environment.NewLine);
            }
            dateTextBox.AppendText("Starting Time: "+logs.getStartTime());
            dateTextBox.AppendText(Environment.NewLine);
            dateTextBox.AppendText("Ending Time: " + logs.getEndTime());
            dateTextBox.AppendText(Environment.NewLine);
            dateTextBox.AppendText("Duration: " + logs.getLogDuration());
            dateTextBox.AppendText(Environment.NewLine);

        }

        private void drawDataGrid(List<LogMessage> log_list)
        {
            foreach (LogMessage log in log_list)
            {
                if (log.messageSource != null)
                {
                    string[] s = { log.typeAsString(), log.messageSource, 
                        log.messageTimestamp.ToString(), log.messageBody };
                    logDataGridView.Rows.Add(s);
                }
                
            }
            
        }

        private void dateTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void warningChkBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void filterDisplayDatarid()
        {
            List<LogMessage> log_list = new List<LogMessage>();
            if (infoChkBox.Checked)
            {
                log_list.AddRange(Log_Analyzer.getListWIthMessageType(logs.getLogs(), 
                    LogMessage.MessageType.Info));
            }
            if (warningChkBox.Checked)
            {
                log_list.AddRange(Log_Analyzer.getListWIthMessageType(logs.getLogs(),
                    LogMessage.MessageType.Warning));
            }
            if (errorChkBox.Checked)
            {
                log_list.AddRange(Log_Analyzer.getListWIthMessageType(logs.getLogs(),
                    LogMessage.MessageType.Error));
            }
            log_list = filterSources(log_list);
            this.logDataGridView.Rows.Clear();
            drawDataGrid(log_list);
        }

        private void infoChkBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void errorChkBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private List<LogMessage> filterSources(List<LogMessage> input_log_list)
        {
            List<LogMessage> log_list = new List<LogMessage>();
            for (int i = 0; i < sourceCheckedListBox.CheckedItems.Count; i++)
            {
                if (sourceCheckedListBox.GetItemChecked(i))
                {
                    log_list.AddRange(Log_Analyzer.getListWIthMessageSource(input_log_list,
                    sourceCheckedListBox.Items[i].ToString()));
                }       
            }
            return log_list;
        }

        private void initializeCheckedLIstBox()
        {
            foreach (string key in logs.getSources())
            {
                sourceCheckedListBox.Items.Add(key, CheckState.Checked);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            filterDisplayDatarid();
        }
    }
}
