using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppClient
{
    public partial class Form1 : Form
    {
        LoggerListenerTextBox listenerTextBox;
        public Form1()
        {
            InitializeComponent();
            Logger.GetInstance();
            listenerTextBox = new LoggerListenerTextBox(logTextBox);
        }

    }
}
