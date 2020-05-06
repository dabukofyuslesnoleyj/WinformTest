using System.Collections.Generic;
using System;

namespace WindowsFormsAppSerialPort
{
    class CSVRawData
    {
        public string name;
        public string dataType;
        public string value;
    }
    
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
        private static DataSource instance;
        private Dictionary<string, DataType> data;

        private DataSource()
        {
            data = new Dictionary<string, DataType>();
        }

        public static DataSource GetInstance()
        {
            if (instance == null)
                instance = new DataSource();
            return instance;
        }

        public DataType GetData(string key)
        {
            if (data.ContainsKey(key))
                return data[key];
            else
                return null;
        }

        public void SetData(string key, DataType value)
        {
            if (data.ContainsKey(key))
                data[key] = value;
            else
                data.Add(key, value);
        }
    }
}