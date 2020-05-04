using System.Collections.Generic;
using System;

namespace WindowsFormsAppSerialPort
{
    interface DataType
    {
        string GetAsString();
        void SetDataValue(string input);
    }

    class IntegerDataType : DataType
    {
        public int value { get; set; }

        public IntegerDataType(int input)
        {
            value = input;
        }

        public string GetAsString()
        { 
            return value + "";
        }
        public void SetDataValue(string input)
        {
            value = Int32.Parse(input);
        }
    }

    class StringDataType : DataType
    {
        public string value { get; set; }

        public StringDataType (string input)
        {
            value = input;
        }

        public string GetAsString()
        {
            return value;
        }
        public void SetDataValue(string input)
        {
            value = input;
        }
    }

    class DataSource
    {
        Dictionary<string, DataType> data;
    }
}