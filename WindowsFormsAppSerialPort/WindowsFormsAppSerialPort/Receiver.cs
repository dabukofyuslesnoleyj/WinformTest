using System;

namespace WindowsFormsAppSerialPort
{
    interface IReceiver
    {
        void StartListening();
        void Update();
    }

    class Receiver : IReceiver
    {
        public void update()
        {

        }

        public void StartListening()
        {

        }
    }
}