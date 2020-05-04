using System;

namespace WindowsFormsAppSerialPort
{
    interface ISender
    {
        void send();
    }

    class AnswerSender : ISender
    {
        public void send()
        {
            //TODO: implement sender function with sockets
        }
    }
}