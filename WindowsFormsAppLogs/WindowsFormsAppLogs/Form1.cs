using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private LogCollection logModel;

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

                List<LogMessage> logs = new List<LogMessage>();
                string inputLog = File.ReadAllText(openFileDialog1.FileName);
                string[] logMessages = inputLog.Split('\n');
                Regex regex = new Regex("^(INFO|WARNING|ERROR),(.*?),(.*?),");
                foreach (string logMessage in logMessages)
                {
                    Match match = regex.Match(logMessage);
                    string log_header = match.Groups[0].Value;
                    List<string> log_header_split = log_header.Split(',').ToList();

                    string log_body = logMessage.Remove(0, log_header.Length);

                    LogMessage lm = new LogMessage(log_header_split, log_body);

                    logs.Add(lm);

                }
                logModel = new LogCollection(logs);
                drawDataGrid(logs);
                displayInfo(logModel);
                initializeCheckedLIstBox();
            }
        }

        private void displayInfo(LogCollection logModel)
        {
            int[] temp = logModel.GetTypeCount();
            typeCountBox.AppendText("INFO: " + temp[0]);
            typeCountBox.AppendText(Environment.NewLine);
            typeCountBox.AppendText("WARNING: " + temp[1]);
            typeCountBox.AppendText(Environment.NewLine);
            typeCountBox.AppendText("ERROR: " + temp[2]);

            foreach (string source in logModel.GetSources())
            {
                SourceCountBox.AppendText(source+" : "+logModel.GetSourceCount(source));
                SourceCountBox.AppendText(Environment.NewLine);
            }

            if (logModel.GetStartDate() == logModel.GetEndDate())
            {
                dateTextBox.AppendText("Date: " + logModel.GetStartDate());
                dateTextBox.AppendText(Environment.NewLine);
            }
            else
            {
                dateTextBox.AppendText("From Date: " + logModel.GetStartDate());
                dateTextBox.AppendText(Environment.NewLine);
                dateTextBox.AppendText("To Date: " + logModel.GetEndDate());
                dateTextBox.AppendText(Environment.NewLine);
            }
            dateTextBox.AppendText("Starting Time: "+logModel.GetStartTime());
            dateTextBox.AppendText(Environment.NewLine);
            dateTextBox.AppendText("Ending Time: " + logModel.GetEndTime());
            dateTextBox.AppendText(Environment.NewLine);
            dateTextBox.AppendText("Duration: " + logModel.GetLogDuration());
            dateTextBox.AppendText(Environment.NewLine);

        }

        private void drawDataGrid(List<LogMessage> logs)
        {
            foreach (LogMessage log in logs)
            {
                if (log.messageSource != null)
                {
                    string[] s = { log.TypeAsString(), log.messageSource, 
                        log.messageTimestamp.ToString(), log.messageBody };
                    logDataGridView.Rows.Add(s);
                }
            } 
        }

        private void filterDisplayDatarid()
        {
            List<LogMessage> logs = new List<LogMessage>();
            
            if (infoChkBox.Checked)
            {
                logs.AddRange(LogAnalyzer.GetListWIthMessageType(logModel.GetLogs(), 
                    LogMessage.MessageType.Info));
            }
            if (warningChkBox.Checked)
            {
                logs.AddRange(LogAnalyzer.GetListWIthMessageType(logModel.GetLogs(),
                    LogMessage.MessageType.Warning));
            }
            if (errorChkBox.Checked)
            {
                logs.AddRange(LogAnalyzer.GetListWIthMessageType(logModel.GetLogs(),
                    LogMessage.MessageType.Error));
            }
            logs = filterSources(logs);
            this.logDataGridView.Rows.Clear();
            drawDataGrid(logs);
        }

        private List<LogMessage> filterSources(List<LogMessage> inputLogs)
        {
            List<LogMessage> logs = new List<LogMessage>();
            for (int i = 0; i < sourceCheckedListBox.CheckedItems.Count; i++)
            {
                if (sourceCheckedListBox.GetItemChecked(i))
                {
                    logs.AddRange(LogAnalyzer.GetListWIthMessageSource(inputLogs,
                    sourceCheckedListBox.Items[i].ToString()));
                }       
            }
            return logs;
        }

        private void initializeCheckedLIstBox()
        {
            foreach (string key in logModel.GetSources())
            {
                sourceCheckedListBox.Items.Add(key, CheckState.Checked);
            }
            
        }

        private void runFilterBtn_Click(object sender, EventArgs e)
        {
            filterDisplayDatarid();
        }


        private void showDetailsBtn_Click(object sender, EventArgs e)
        {
            if (logDataGridView.SelectedRows.Count == 1)
            {
                string type = logDataGridView.SelectedRows[0].Cells[0].Value + string.Empty;
                string source = logDataGridView.SelectedRows[0].Cells[1].Value + string.Empty;
                string timeStamp = logDataGridView.SelectedRows[0].Cells[2].Value + string.Empty;
                string body = logDataGridView.SelectedRows[0].Cells[3].Value + string.Empty;
                typeTextBox.Text = type;
                sourceTextBox.Text = source;
                timeStampTextBox.Text = timeStamp;
                bodyTextBox.Text = "";
                List<string> row_values = LogAnalyzer.parseMessageBody(body);
                if (row_values.Count <= 1)
                {
                    bodyTextBox.Text = row_values[0];
                }
                else
                {
                    foreach (string s in row_values)
                    {
                        bodyTextBox.Text = bodyTextBox.Text + s + "\r\n";
                    }
                }  
            }
        }

        private void saveCsvBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = logDataGridView.DataSource as DataTable;

                var textWriter = new StringWriter();
                var csv = new CsvWriter(textWriter, CultureInfo.InvariantCulture);

                foreach (DataColumn dc in dt.Columns)
                {
                    csv.WriteField(dc.ColumnName);
                }
                csv.NextRecord();

                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        csv.WriteField(dr[i]);
                    }
                    csv.NextRecord();
                }

                string data = textWriter.ToString();
                textWriter.Flush();
                File.WriteAllText(saveFileDialog1.FileName + ".csv", data);
            }
        }
    }
}
