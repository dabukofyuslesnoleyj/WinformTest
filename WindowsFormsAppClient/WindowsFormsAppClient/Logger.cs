using System;
using System.Collections.Generic;
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

    class LoggerListenerTextBox : ILoggerListener
    {
        TextBox textBox;

        public LoggerListenerTextBox(TextBox tb)
        {
            textBox = tb;
        }
        public void update(String s)
        {
            textBox.AppendText(s + "\n");
        }
    }
}