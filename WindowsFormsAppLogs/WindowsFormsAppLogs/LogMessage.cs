using System;
using Json.Net;
using Newtonsoft.Json;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WindowsFormsAppLogs
{
    public class LogMessage 
    {

        public enum MessageType
        {
            Info,
            Warning,
            Error
        }

        public MessageType messageType {get; set;}
        public string messageSource {get; set;}
        public DateTime messageTimestamp {get; set;}
        public List<string> bodyTags;
        
        public string messageBody;

        private string completeMessage {get; set;}

        public LogMessage(List<string> log_params, string log_body)
        {
            bodyTags = new List<string>();
            completeMessage = string.Join("", log_params);
            if (log_params.Count > 1)
            {
                switch (log_params[0])
                {
                    case "INFO": messageType = MessageType.Info; break;
                    case "WARNING": messageType = MessageType.Warning; break;
                    case "ERROR": messageType = MessageType.Error; break;
                }

                messageSource = log_params[1];
                messageTimestamp = DateTime.Parse(log_params[2]);
                messageBody = log_body;

                Regex regex = new Regex("@(.*?);(.*?)#");
                Match match = regex.Match(messageBody);
                string tag = match.Groups[0].Value;

                if (tag == "")
                {
                    bodyTags.Add("No Tag");
                }
                else
                {
                    tag.Remove(0);
                    tag.Remove(tag.Length - 1);
                    bodyTags.AddRange(new List<string>(tag.Split(';')));
                }
            }
            
        }

        public override string ToString()
        {
            return completeMessage;
        }
        public string TypeAsString()
        {
            switch (messageType)
            {
                case MessageType.Info: return "INFO";
                case MessageType.Warning: return "WARNING";
                case MessageType.Error: return "ERROR";
                default: return "NONE";
            }       
        }

    }
}
