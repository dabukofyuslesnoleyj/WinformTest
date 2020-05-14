using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsAppSerialPort
{
    static class UtilityFunctions
    {
        //JSON FORMAT
        //  {
        //      commandID : "g0001"
        //      commandType : "GET"
        //      messageTarget : "name"
        //  }
        //  {
        //      commandID : "s0001"
        //      commandType : "SET"
        //      messageTarget : "name"
        //      messageType : "int"
        //      messageValue : "1"
        //  }
        public static List<Message> MessageParser(string json)
        {
            if (json.Contains("<EOF>"))
            {
                json = json.Substring(0, json.Length - 5);
            }
            List<Message> messages = new List<Message>();
            string[] jsonList = json.Split('|');
            foreach (string s in jsonList)
            {
                Dictionary<string, string> message = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                switch (message["commandType"])
                {
                    case "GET":
                        messages.Add(new GetMessage(message["commandID"], message["messageTarget"]));
                        break;
                    case "SET":
                        messages.Add(new SetMessage(message["commandID"], message["messageTarget"],
                            message["messageValue"], message["messageType"]));
                        break;
                    case "PING": messages.Add(new PingMessage(message["commandID"]));
                        break;
                    default: messages.Add(new ErrorMessage(""));
                        break;
                }
            }
            return messages;
        }
    }

    interface ILogger
    {
        void NotifyAll(string s);
        void Attach(ILoggerListener listener);
    }

    interface ILoggerListener
    {
        void update(string s);
    }

    class Logger : ILogger
    {
        private static ILogger instance;
        List<ILoggerListener> listeners;
        List<string> logs;

        private Logger()
        {
            listeners = new List<ILoggerListener>();
            logs = new List<string>();
        }

        public static ILogger GetInstance()
        {
            if (instance == null)
                instance = new Logger();
            return instance;
        }

        public void AddLog(string log)
        {
            logs.Add(log);
            NotifyAll(log);
        }

        public void NotifyAll(string s)
        {
            foreach (ILoggerListener listener in listeners)
                listener.update(s);
        }

        public void Attach(ILoggerListener listener)
        {
            listeners.Add(listener);
        }

    }

    class FileWriterLoggerListener : ILoggerListener
    {
        string filename;

        public FileWriterLoggerListener(string fn)
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

    class TextBoxLoggerListener : ILoggerListener
    {
        TextBox textbox;
        Form form;

        public TextBoxLoggerListener(Form f, TextBox tb)
        {
            form = f;
            textbox = tb;
        }
        delegate void SetTextCallback(string text);
        public void update(string s)
        {
            if (textbox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(update);
                form.Invoke(d, new object[] { s });

            }
            else
            {
                textbox.AppendText(s);
                textbox.AppendText(System.Environment.NewLine);
            }
        }
    }

    interface ITextChanger
    {
        void changeText(string s);
    }

    class IPTextChanger : ITextChanger
    {
        TextBox textbox;
        Form form;

        public IPTextChanger(Form f, TextBox tb)
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