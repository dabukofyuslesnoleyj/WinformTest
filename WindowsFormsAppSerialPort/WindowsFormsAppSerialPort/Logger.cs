using System;
using System.Collections.Generic;
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
        public static Message MessageParser(string json)
        {
            Dictionary<string, string> message = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            switch (message["commandType"])
            {
                case "GET" :
                    return new GetMessage(message["commandID"], message["messageTarget"]);
                case "SET" : return new SetMessage(message["commandID"], message["messageTarget"],
                    message["messageValue"], message["messageType"]);
                case "PING": return new PingMessage(message["commandID"]);
                default : return null;
            }
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
            {
                listener.update(s);
            }
        }

        public void Attach(ILoggerListener listener)
        {
            listeners.Add(listener);
        }

    }

    class TextBoxLoggerListener : ILoggerListener
    {
        TextBox textbox;

        public TextBoxLoggerListener(TextBox tb)
        {
            textbox = tb;
        }

        public void update(string s)
        {
            textbox.AppendText(s);
            textbox.AppendText(System.Environment.NewLine);
        }
    }
}