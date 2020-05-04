

namespace WindowsFormsAppSerialPort
{
    abstract class Message
    {
        public Message(string commandID)
        {
            this.commandID = commandID;
        }
        public string commandID { get; set; }

        public abstract string call();
    }

    class PingMessage : Message
    {
        public PingMessage(string commandID) : base(commandID)
        {

        }
        
        public override string call()
        {
            return "PONG";
        }
    }

    class GetMessage : Message
    {
        public string targetName;
        public GetMessage(string commandID, string targetName) : base(commandID)
        {
            this.targetName = targetName;
        }

        public override string call()
        {
            return "PONG";
        }
    }


}