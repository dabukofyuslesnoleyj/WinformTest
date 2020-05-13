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

    class ErrorMessage : Message
    {
        public ErrorMessage(string commandID) : base(commandID)
        {

        }

        public override string call()
        {
            return "INVALID COMMAND SENT";
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
            string output = DataSource.GetInstance().GetData(targetName).GetAsString();
            if (output == null)
                return this.targetName+" does not exist in the data source";
            return output;
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
                case "flt":
                    newValue = new FloatDataType(float.Parse(setValue));
                    break;
                case "str":
                    newValue = new StringDataType(setValue);
                    break;
                default:
                    newValue = new EmptyDataType();
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