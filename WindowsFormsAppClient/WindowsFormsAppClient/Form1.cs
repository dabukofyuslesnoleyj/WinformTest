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
                    break;
                case 1 :
                    varNameTextBox.Visible = true;
                    varTypeTextBox.Visible = true;
                    newValTextBox.Visible = true;
                    varNameLabel.Visible = true;
                    varTypeLabel.Visible = true;
                    newValLabel.Visible = true;
                    break;
                case 2 :
                    varNameTextBox.Visible = false;
                    varTypeTextBox.Visible = false;
                    newValTextBox.Visible = false;
                    varNameLabel.Visible = false;
                    varTypeLabel.Visible = false;
                    newValLabel.Visible = false;
                    break;
            }
        }
    }
}
