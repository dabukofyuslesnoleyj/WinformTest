using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsAppClient
{
    public partial class Form1 : Form
    {
        string currMessage;
        int idCount;
        IClient clientReceiver;
        public Form1()
        {
            InitializeComponent();
            Logger.GetInstance().Attach(new LoggerListenerTextBox(this, logTextBox));
            Logger.GetInstance().Attach(new LoggerListenerFileWriter("log.txt"));
            clientReceiver = new AsynchronousClient("127.0.0.1");

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
            string jsonInput = UtilityFunctions.JsonMessageBuilder(input);
            Logger.GetInstance().WriteLog(jsonInput);
            new Thread(delegate () {
                clientReceiver.StartClient(jsonInput, new IPAddressTextChanger(this, IPTextBox));
            }).Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string data = File.ReadAllText(openFileDialog1.FileName);
                clientReceiver.StartClient(data, new IPAddressTextChanger(this, IPTextBox));
            }
        }

        private void changeIpBtn_Click(object sender, EventArgs e)
        {
            Logger.GetInstance().WriteLog("Messeges will now be sent to IP Address : "+IPTextBox.Text);
            clientReceiver = new AsynchronousClient(IPTextBox.Text);
        }
    }
}
