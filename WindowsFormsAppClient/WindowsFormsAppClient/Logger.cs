using System;
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
        void update(string s);
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
                              loggerListener.update(s);
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

        public void update(string s)
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
        public void update(string s)
        {
            if (textBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(update);
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
        void changeText(string s);
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
        public void changeText(string s)
        {
            if (textbox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(changeText);
                form.Invoke(d, new object[] { s });

            }
            else
            {
                textbox.Text = s;
            }
        }
    }
}