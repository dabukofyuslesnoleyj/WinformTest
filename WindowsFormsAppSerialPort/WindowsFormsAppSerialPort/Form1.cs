using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using CsvHelper;

namespace WindowsFormsAppSerialPort
{
    public partial class Form1 : Form
    {
        IReceiver receiver;
        ILoggerListener textBoxListener;
        public Form1()
        {
            InitializeComponent();
            receiver = new TcpReceiver("192.168.0.126");
            textBoxListener = new TextBoxLoggerListener(this, logTextBox);
            Logger.GetInstance().Attach(textBoxListener);
            Logger.GetInstance().Attach(new FileWriterLoggerListener("logs.txt"));
            Logger.GetInstance().NotifyAll("logger initialized...");
        }

        private void startServerBtn_Click(object sender, EventArgs e)
        {
            new Thread(delegate () {
                receiver.StartReceiving(ipText: new IPTextChanger(this, IPTextBix));
            }).Start();
        }

        private void loadDataBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var reader = new StreamReader(openFileDialog1.FileName);
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                var records = csv.GetRecords<CSVRawData>();

                Logger.GetInstance().NotifyAll("Loading Data source.....");

                foreach (CSVRawData record in records)
                {
                    DataType value;
                    Logger.GetInstance().NotifyAll("Loading variable named " + record.name);
                    switch (record.name)
                    {
                        case "int":
                            value = new IntegerDataType(Int32.Parse(record.value));
                            break;
                        default:
                            value = new StringDataType(record.value);
                            break;
                    }

                    DataSource.GetInstance().SetData(record.name, value);
                }
                Logger.GetInstance().NotifyAll("Finished loading data");
            }
        }

        private void clsoeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
