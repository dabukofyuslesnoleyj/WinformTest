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
                try
                {
                    if (message.ContainsKey("Id"))
                    {
                        string translatedJson = new MaynardMessageAdapter().TranslateMessage(json);
                        message = JsonConvert.DeserializeObject<Dictionary<string, string>>(translatedJson);
                    }
                    switch (message["commandType"])
                    {
                        case "GET":
                            messages.Add(new GetMessage(message["commandID"], message["messageTarget"]));
                            break;
                        case "SET":
                            messages.Add(new SetMessage(message["commandID"], message["messageTarget"],
                                message["messageValue"], message["messageType"]));
                            break;
                        case "PING":
                            messages.Add(new PingMessage(message["commandID"]));
                            break;
                        default:
                            messages.Add(new ErrorMessage(""));
                            break;
                    }
                }
                catch (Exception e)
                {
                    Logger.GetInstance().NotifyAll(e+"");
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
        void Update(string s);
    }

    class Logger : ILogger
    {
        private static ILogger instance;
        private List<ILoggerListener> listeners;
        private List<string> logs;

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
                listener.Update(s);
        }

        public void Attach(ILoggerListener listener)
        {
            listeners.Add(listener);
        }

    }

    class FileWriterLoggerListener : ILoggerListener
    {
        private string filename;

        public FileWriterLoggerListener(string fn)
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

    class TextBoxLoggerListener : ILoggerListener
    {
        private TextBox textbox;
        private Form form;

        public TextBoxLoggerListener(Form f, TextBox tb)
        {
            form = f;
            textbox = tb;
        }
        delegate void SetTextCallback(string text);
        public void Update(string s)
        {
            if (textbox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Update);
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
        void ChangeText(string s);
    }

    class IPTextChanger : ITextChanger
    {
        private TextBox textbox;
        private Form form;

        public IPTextChanger(Form f, TextBox tb)
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