using System;
using System.Collections.Generic;

namespace WindowsFormsAppSerialPort
{
    interface IReceiver
    {
        void StartReceiving();
        void NotifyAll();
        void Attach(IReceiverListener listener);
    }

    interface IReceiverListener
    {
        void Update();
    }

    class Receiver : IReceiver
    {
        List<IReceiverListener> listeners;
        public void StartReceiving()
        {
            //TODO: Add threading and Sockets
            while (true)
            {
                // if (new message received)
                NotifyAll();
            }
        }
        public void NotifyAll()
        {
            foreach (IReceiverListener listener in listeners)
                listener.Update();
        }
        public void Attach(IReceiverListener listener)
        {
            listeners.Add(listener);
        }
    }
}