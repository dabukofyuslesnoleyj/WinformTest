using System.Collections.Generic;
using System;

namespace WindowsFormsAppSerialPort
{
    class CSVRawData
    {
        public string name { get; set; }
        public string dataType { get; set; }
        public string value { get; set; }
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

    class FloatDataType : DataType
    {
        public float value { get; set; }

        public FloatDataType(float input)
        {
            value = input;
        }

        public string GetAsString()
        {
            return value + "";
        }
        public void SetDataValue(string input)
        {
            value = float.Parse(input);
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

    class EmptyDataType : DataType
    {

        public EmptyDataType()
        {
        }

        public string GetAsString()
        {
            return "EMPTY";
        }
        public void SetDataValue(string input)
        {
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

        public List<DataType> GetAllData()
        {
            List<DataType> dataList = new List<DataType>();
            foreach (string key in data.Keys)
                dataList.Add(data[key]);
            return dataList;
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