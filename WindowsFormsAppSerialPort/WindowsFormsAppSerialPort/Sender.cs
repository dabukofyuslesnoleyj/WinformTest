using System.Collections.Generic;
using Newtonsoft.Json;

namespace WindowsFormsAppSerialPort
{
    interface ISender
    {
        void send();
    }

    class AnswerSender : ISender
    {
        public void send()
        {
            //TODO: implement sender function with sockets
        }
    }

    //{
    //MessageId : "0001",
    //MessageType : "REQUEST"
    //Message : "SET, <KEY>, <value>"
    //}
    interface IMessageAdapter
    {
        string translateMessage(string input);
    }

    class MaynardMessageAdapter : IMessageAdapter
    {
        public string translateMessage(string input)
        {
            Dictionary<string, string> inputData = JsonConvert.DeserializeObject<Dictionary<string, string>>(input);
            Dictionary<string, string> outputData = new Dictionary<string, string>();
            outputData.Add("commandID", inputData["Id"]);

            string[] inputMessage = inputData["Message"].Split(',');
            outputData.Add("commandType", inputData["Command"]);
            switch (inputData["Command"])
            {
                case "SET":
                    outputData.Add("messageTarget", inputMessage[1]);
                    outputData.Add("messageType", "str");
                    outputData.Add("messageValue", inputMessage[2]);
                    break;
                case "GET":
                    outputData.Add("messageTarget", inputMessage[0]);
                    break;
            }

            return JsonConvert.SerializeObject(outputData);
        }
    }
}