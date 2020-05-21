using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

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
        private List<ILoggerListener> loggerListeners;
        private List<string> logs;

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
                loggerListener.Update(s);
        }

        public void Attach(ILoggerListener loggerListener)
        {
            loggerListeners.Add(loggerListener);
        }
    }

    class LoggerListenerFileWriter : ILoggerListener
    {
        private string filename;

        public LoggerListenerFileWriter(string filename_)
        {
            filename = filename_;
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
        private TextBox textBox;
        private Form mainForm;

        public LoggerListenerTextBox(Form form, TextBox textBox_)
        {
            mainForm = form;
            textBox = textBox_;
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
        private TextBox textbox;
        private Form form;

        public IPAddressTextChanger (Form form_, TextBox textBox_)
        {
            form = form_;
            textbox = textBox_;
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

    class UtilityFunctions
    {
        public static string ResponseParser(string response)
        {
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
            string output = "response to our command " + data["Id"] + " \nwhich is a " + data["Type"] +
                " the response is: \n" + data["Message"];
            return output;
        }
        //      commandID : "s0001"
        //      commandType : "SET"
        //      messageTarget : "name"
        //      messageType : "int"
        //      messageValue : "1"
        public static string JsonMessageBuilder(string[] message)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            string jsonData = "";

            data.Add("commandID", "C-" + message[0]);
            data.Add("commandType", message[1]);
            switch (message[1])
            {
                case "GET":
                    data.Add("messageTarget", message[2]);
                    break;
                case "SET":
                    data.Add("messageTarget", message[2]);
                    data.Add("messageType", message[3]);
                    data.Add("messageValue", message[4]);
                    break;
                default:
                    break;
            }
            jsonData = JsonConvert.SerializeObject(data);
            return jsonData;
        }
    }
}