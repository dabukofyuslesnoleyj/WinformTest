using System;
using Json.Net;
using Newtonsoft.Json;
using System.Data;
using System.Collections.Generic;

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
        
        public string messageBody;
        public bool hasJson;
        public DataTable bodyJson;

        private string completeMessage {get; set;}

        public LogMessage(List<string> log_params, string log_body)
        {
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
                hasJson = false;
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
