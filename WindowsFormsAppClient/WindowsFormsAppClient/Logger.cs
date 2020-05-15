using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsAppClient
{
    interface ILogger
    {
        void WriteLog(string s);
        void Attach(ILoggerListener loggerListener);
    }
    interface ILoggerListener
    {
        void Update(string s);
    }

    class Logger : ILogger
    {
        private static ILogger instance;
        List<ILoggerListener> loggerListeners;
        List<string> logs;

        private Logger()
        {
            loggerListeners = new List<ILoggerListener>();
            logs = new List<string>();
        }

        public static ILogger GetInstance()
        {
            if (instance != null)
                return instance;
            instance = new Logger();
            return instance;
        }

        public void WriteLog(string s)
        {
            logs.Add(s);
            
            foreach (ILoggerListener loggerListener in loggerListeners)
            {
                              loggerListener.Update(s);
            }
        }

        public void Attach(ILoggerListener loggerListener)
        {
            loggerListeners.Add(loggerListener);
        }
    }

    class LoggerListenerFileWriter : ILoggerListener
    {
        string filename;

        public LoggerListenerFileWriter(string fn)
        {
            filename = fn;
        }

        public void Update(string s)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(s);
            }
        }
    }

    class LoggerListenerTextBox : ILoggerListener
    {
        TextBox textBox;
        Form mainForm;

        public LoggerListenerTextBox(Form f, TextBox tb)
        {
            mainForm = f;
            textBox = tb;
        }
        delegate void SetTextCallback(string text);
        public void Update(string s)
        {
            if (textBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Update);
                mainForm.Invoke(d, new object[] { s });
            }
            else
            {
                textBox.AppendText(s);
            }
        }
    }

    public interface ITextChanger
    {
        void ChangeText(string s);
    }

    public class IPAddressTextChanger : ITextChanger
    {
        TextBox textbox;
        Form form;

        public IPAddressTextChanger (Form f, TextBox tb)
        {
            form = f;
            textbox = tb;
        }
        delegate void SetTextCallback(string text);
        public void ChangeText(string s)
        {
            if (textbox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(ChangeText);
                form.Invoke(d, new object[] { s });
            }
            else
            {
                textbox.Text = s;
            }
        }
    }
}