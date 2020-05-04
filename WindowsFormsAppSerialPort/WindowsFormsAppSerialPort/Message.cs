using System;

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
            return DataSource.GetInstance().GetData(targetName).GetAsString();
        }
    }

    class SetMessage : Message
    {
        public string targetName;
        public DataType newValue;
        public SetMessage(string commandID, string targetName, string setValue, string dataType) : base(commandID)
        {
            this.targetName = targetName;
            
            switch (dataType)
            {
                case "int" : newValue = new IntegerDataType(Int32.Parse(setValue));
                    break;
                default : newValue = new StringDataType(setValue);
                    break;
            }
        }

        public override string call()
        {
            DataSource.GetInstance().SetData(targetName, newValue);
            return "OK";
        }
    }
}