using System;
using System.Collections.Generic;

namespace WindowsFormsAppSerialPort
{
    interface MessageEnumerator
    {
        void AddMessage(Message message);
        Message NextMessage();
        bool IsLastMessage();
    }
    class MessageCollection : MessageEnumerator
    {
        List<Message> messages;
        int currCount;

        public MessageCollection(List<Message> messages)
        {
            this.messages = messages;
            currCount = 0;
        }

        public MessageCollection()
        {
            this.messages = new List<Message>();
            currCount = 0;
        }
        
        public void AddMessage(Message message)
        {
            this.messages.Add(message);
        }

        public Message NextMessage()
        {
            if(!IsLastMessage())
            {
                currCount++;
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