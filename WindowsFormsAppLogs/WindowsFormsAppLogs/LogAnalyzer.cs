using System;
using System.IO;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;


namespace WindowsFormsAppLogs
{
    public static class LogAnalyzer
    {
        //THINGS TO ANALYZE*************
        //Count message types
        //List by message type (emphasis on Wrnings and Errors)
        //List by specific timeframe
        //List by message source
        //List debug messages
        //Save subset of messages to csv/json
        //Flag Anomalies
        //Ignore Routine Messages?
        //Message correlation 
        

        public static List<LogMessage> GetListWIthMessageType(List<LogMessage> log_list, LogMessage.MessageType mtype)
        {
            List<LogMessage> results = (
                            from lm in log_list
                            where lm.messageType == mtype
                            select lm).ToList();
            return results;
        }

        public static List<LogMessage> GetListWithTimeFrame(List<LogMessage> log_list, DateTime time_in, DateTime time_out)
        {
            List<LogMessage> results = (
                            from lm in log_list
                            where lm.messageTimestamp >= time_in && lm.messageTimestamp <= time_out
                            select lm).ToList();
            return results;
        }

        public static List<LogMessage> GetListWIthMessageSource(List<LogMessage> log_list, string msource)
        {
            List<LogMessage> results =(
                            from lm in log_list
                            where lm.messageSource == msource
                            select lm).ToList();
            return results;
        }

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static List<string> parseMessageBody(string messageBody)
        {
            List<string> parsedBody = new List<string>();

            if (messageBody.Contains("#json"))
            {
                Regex regex = new Regex("@(.*?)#");
                Match match = regex.Match(messageBody);
                parsedBody.Add("HEADER: "+match.Groups[0].Value);
                regex = new Regex("{(.*?)}");
                match = regex.Match(messageBody);
                string data = match.Groups[0].Value;
                parsedBody.Add("JSON: ");
                Dictionary<string, string> body = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
                foreach (string key in body.Keys)
                {
                    parsedBody.Add(key+" : "+body[key]);
                }
                return parsedBody;
            }
            return messageBody.Split(',').ToList();
        }
    }
}