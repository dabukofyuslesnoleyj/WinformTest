using System;

namespace WindowsFormsAppSerialPort
{
    interface ISender
    {
        void send();
    }

    class Sender : ISender
    {
        public void send()
        {
            //TODO: implement sender function with sockets
        }
    }
}