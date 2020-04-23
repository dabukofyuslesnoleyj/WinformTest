using System;
using Json.Net;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace WindowsFormsAppLogs
{
    public class LogCollection
    {
        //THINGS TO ANALYZE*************
        /*
        Count message types
        List by message type (emphasis on Wrnings and Errors)
        List by specific timeframe
        List by message source
        List debug messages
        Save subset of messages to csv/json
        Flag Anomalies
        Ignore Routine Messages?
        Message correlation 
        */
        private List<LogMessage> logs {get; set;}
        private int warningCount;
        private int errorCount;
        private int infoCount;

        private Dictionary <string, int> messageSourceCount;
        private Dictionary<string, int> bodyTagCount;

        private DateTime startTime;
        private DateTime endTime;
        private TimeSpan logDuration;
        public LogCollection (List<LogMessage> logMessages)
        {
            logs = logMessages;

            startTime = logs[0].messageTimestamp;

            if(logs.Count > 1) 
                endTime = logs[logs.Count - 2].messageTimestamp;
            else if(logs.Count == 1)
                endTime = logs[0].messageTimestamp;

            logDuration = endTime.Subtract(startTime);

            messageSourceCount = new Dictionary<string, int>();
            bodyTagCount = new Dictionary<string, int>();

            foreach (LogMessage lm in logs)
            {
                if (lm.messageSource != null)
                {
                    if (messageSourceCount.ContainsKey(lm.messageSource))
                    {
                        messageSourceCount[lm.messageSource]++;
                    }
                    else
                    {
                        messageSourceCount.Add(lm.messageSource, 1);
                    }

                    foreach (string tag in lm.bodyTags)
                    {
                        if (bodyTagCount.ContainsKey(tag))
                        {
                            bodyTagCount[tag]++;
                        }
                        else
                        {
                            bodyTagCount.Add(tag, 1);
                        }
                    }
                }   

                if (lm.messageType == LogMessage.MessageType.Warning)
                    warningCount++;
                else if (lm.messageType == LogMessage.MessageType.Error)
                    errorCount++;
                else if (lm.messageType == LogMessage.MessageType.Info)
                    infoCount++;
            }
        }

        public List<LogMessage> GetLogs()
        {
            return logs;
        }

        public int[] GetTypeCount()
        {
            int[] temp = { infoCount, warningCount, errorCount };
            return temp;
        }

        public List<string> GetSources()
        {
            return 
               (from keys in messageSourceCount.Keys select keys).ToList();
        }

        public int GetSourceCount(string key)
        {
            return messageSourceCount[key];
        }

        public List<string> GetBodyTags()
        {
            return
               (from keys in bodyTagCount.Keys select keys).ToList();
        }

        public int GetBodyTagsCount(string key)
        {
            return bodyTagCount[key];
        }

        public string GetStartDate()
        {
            return startTime.ToString("dd/MM/yyyy");
        }
        public string GetStartTime()
        {
            return startTime.ToString("HH:mm");
        }

        public string GetEndDate()
        {
            return endTime.ToString("dd/MM/yyyy");
        }

        public string GetEndTime()
        {
            return endTime.ToString("HH:mm");
        }

        public string GetLogDuration()
        {
            return logDuration.ToString();
        }

    }
}