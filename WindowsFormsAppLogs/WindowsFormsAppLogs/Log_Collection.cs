using System;
using Json.Net;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace WindowsFormsAppLogs
{
    public class Log_Collection
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
        private List<LogMessage> log_list {get; set;}
        private int warningCount;
        private int errorCount;

        private Dictionary <string, int> messageSourceCount;

        private DateTime startTime;
        private DateTime endTime;
        private TimeSpan logDuration;
        public Log_Collection (List<LogMessage> logMessages)
        {
            log_list = logMessages;

            startTime = log_list[0].messageTimestamp;
            endTime = log_list[log_list.Count - 2].messageTimestamp;
            logDuration = endTime.Subtract(startTime);

            messageSourceCount = new Dictionary<string, int>();
            foreach (LogMessage lm in log_list)
            {
                if(lm.messageSource != null)
                {
                    if (messageSourceCount.ContainsKey(lm.messageSource))
                    {
                        messageSourceCount[lm.messageSource]++;
                    }
                    else
                    {
                        messageSourceCount.Add(lm.messageSource, 1);
                    }
                }
                

                if(lm.messageType == LogMessage.MessageType.Warning)
                {
                    warningCount++;
                }
                else if(lm.messageType == LogMessage.MessageType.Error)
                {
                    errorCount++;
                }
            }
        }

        public List<LogMessage> getLogs()
        {
            return log_list;
        }

        public int[] getTypeCount()
        {
            int info_count = log_list.Count - warningCount - errorCount;
            int[] temp = { info_count, warningCount, errorCount };
            return temp;
        }

        public List<string> getSources()
        {
            return 
               (from keys in messageSourceCount.Keys select keys).ToList();
        }

        public int getSourceCount(string key)
        {
            return messageSourceCount[key];
        }

        public string getStartDate()
        {
            return startTime.ToString("dd/MM/yyyy");
        }
        public string getStartTime()
        {
            return startTime.ToString("HH:mm");
        }

        public string getEndDate()
        {
            return endTime.ToString("dd/MM/yyyy");
        }

        public string getEndTime()
        {
            return endTime.ToString("HH:mm");
        }

        public string getLogDuration()
        {
            return logDuration.ToString();
        }

    }
}