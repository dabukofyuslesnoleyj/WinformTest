using System;
using System.Collections.Generic;
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

    class Logger
    {
        List<string> logs;
        public void AddLog(string log)
        {
            logs.Add(log);
        }

    }
}