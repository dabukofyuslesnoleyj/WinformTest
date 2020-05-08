using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            receiver = new Receiver();
            textBoxListener = new TextBoxLoggerListener(logTextBox);
            Logger.GetInstance().Attach(textBoxListener);
            Logger.GetInstance().NotifyAll("logger initialized...");
        }

        private void startServerBtn_Click(object sender, EventArgs e)
        {
            receiver.StartReceiving();
        }

        private void loadDataBtn_Click(object sender, EventArgs e)
        {
            var reader = new StreamReader("data.csv");
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<CSVRawData>();

            Logger.GetInstance().NotifyAll("Loading Data source.....");

            foreach (CSVRawData record in records)
            {
                DataType value;
                Logger.GetInstance().NotifyAll("Loading variable named " + record.name);
                switch (record.name)
                {
                    case "int" : value = new IntegerDataType(Int32.Parse(record.value));
                        break;
                    default : value = new StringDataType(record.value);
                        break;
                }

                DataSource.GetInstance().SetData(record.name, value);
            }
            Logger.GetInstance().NotifyAll("Finished loading data");
        }

        private void clsoeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
