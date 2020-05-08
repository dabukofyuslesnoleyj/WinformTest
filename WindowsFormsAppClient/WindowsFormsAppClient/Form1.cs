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
using Json.Net;
using Newtonsoft.Json;

namespace WindowsFormsAppClient
{
    public partial class Form1 : Form
    {
        string currMessage;
        int idCount;
        public Form1()
        {
            InitializeComponent();
            Logger.GetInstance().Attach(new LoggerListenerTextBox(this, logTextBox));

            idCount = 0;
        }

        private void commondComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(commondComboBox.SelectedIndex)
            {
                case 0 :
                    varNameTextBox.Visible = true;
                    varTypeTextBox.Visible = false;
                    newValTextBox.Visible = false;
                    varNameLabel.Visible = true;
                    varTypeLabel.Visible = false;
                    newValLabel.Visible = false;
                    currMessage = "GET";
                    break;
                case 1 :        
                    varNameTextBox.Visible = true;
                    varTypeTextBox.Visible = true;
                    newValTextBox.Visible = true;
                    varNameLabel.Visible = true;
                    varTypeLabel.Visible = true;
                    newValLabel.Visible = true;
                    currMessage = "SET";
                    break;
                case 2 :
                    varNameTextBox.Visible = false;
                    varTypeTextBox.Visible = false;
                    newValTextBox.Visible = false;
                    varNameLabel.Visible = false;
                    varTypeLabel.Visible = false;
                    newValLabel.Visible = false;
                    currMessage = "PING";
                    break;
            }
        }
        private void sendBtn_Click(object sender, EventArgs e)
        {
            string[] input = {currMessage + idCount, currMessage, varNameTextBox.Text,
                varTypeTextBox.Text, newValTextBox.Text };
            Logger.GetInstance().WriteLog(AsynchronousClient.JsonMessageBuilder(input));
            AsynchronousClient.StartClient(AsynchronousClient.JsonMessageBuilder(input));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string data = File.ReadAllText(openFileDialog1.FileName);
                AsynchronousClient.StartClient(data);
            }
        }
    }
}
