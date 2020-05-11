using System;
using System.Collections.Generic;

namespace WindowsFormsAppSerialPort
{
    interface MessageEnumerator
    {
        void AddMessage(Message message);
        Message NextMessage();
        Message CurrentMessage();
        bool IsLastMessage();
    }
    class MessageCollection : MessageEnumerator
    {
        private static MessageCollection instance;
        List<Message> messages;
        int currCount;

        private MessageCollection()
        {
            this.messages = new List<Message>();
            currCount = 0;
        }
        public static MessageEnumerator GetInstance()
        {
            if (instance == null)
                instance = new MessageCollection();
            return instance;
        }
        
        public void AddMessage(Message message)
        {
            this.messages.Add(message);
        }

        public Message NextMessage()
        {
            if (!IsLastMessage())
            {
                return messages[currCount];
            }
            currCount++;
            return null;
        }

        public Message CurrentMessage()
        {
            if (!IsLastMessage())
            {
                return messages[currCount];
            }
            return null;
        }

        public bool IsLastMessage()
        {
            return currCount >= messages.Count;
        }
    }
}