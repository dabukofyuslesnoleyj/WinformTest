using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WindowsFormsAppClient
{

    // State object for receiving data from remote device.  
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousClient
    {
        // The port number for the remote device.  
        private const int port = 11000;

        // ManualResetEvent instances signal completion.  
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // The response from the remote device.  
        private static String response = String.Empty;

        public static void StartClient(string messageToSend, ITextChanger ipTextChanger)
        {
            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                // The name of the
                // remote device is "host.contoso.com".  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                ipTextChanger.changeText(ipAddress.MapToIPv4().ToString());

                // Create a TCP/IP socket.  
                Socket client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
                client.BeginConnect(remoteEP,
                    new AsyncCallback(connectCallback), client);
                connectDone.WaitOne();

                send(client, messageToSend + "<EOF>");
                sendDone.WaitOne();

                // Receive the response from the remote device.  
                receive(client);
                receiveDone.WaitOne();

                // Write the response to the console.  
                Logger.GetInstance().WriteLog("Response received : " + response);

                // Release the socket.  
                client.Shutdown(SocketShutdown.Both);
                client.Close();

            }
            catch (Exception e)
            {
                Logger.GetInstance().WriteLog(e.ToString());
            }
        }

        private static void connectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                Logger.GetInstance().WriteLog("Socket connected to " +
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();
            }
            catch (Exception e)
            {
                Logger.GetInstance().WriteLog(e.ToString());
            }
        }

        private static void receive(Socket client)
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(receiveCallback), state);
            }
            catch (Exception e)
            {
                Logger.GetInstance().WriteLog(e.ToString());
            }
        }

        private static void receiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    Console.WriteLine("still receiving");
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(receiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    // Signal that all bytes have been received.  
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Logger.GetInstance().WriteLog(e.ToString());
            }
        }

        private static void send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            Logger.GetInstance().WriteLog("Whole string sent : " + data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(sendCallback), client);
        }

        private static void sendCallback(IAsyncResult ar)
        {
            try
            {
                Console.WriteLine("still sending");
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Logger.GetInstance().WriteLog("Sent "+ bytesSent + " bytes to server.");

                // Signal that all bytes have been sent.  
                sendDone.Set();
            }
            catch (Exception e)
            {
                Logger.GetInstance().WriteLog(e.ToString());
            }
        }
        //      commandID : "s0001"
        //      commandType : "SET"
        //      messageTarget : "name"
        //      messageType : "int"
        //      messageValue : "1"
        public static string JsonMessageBuilder (string[] message)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            string jsonData = "";
            switch(message[1])
            {
                case "GET" :
                    data.Add("commandID", message[0]);
                    data.Add("commandType", message[1]);
                    data.Add("messageTarget", message[2]);
                    break;
                case "SET":
                    data.Add("commandID", message[0]);
                    data.Add("commandType", message[1]);
                    data.Add("messageTarget", message[2]);
                    data.Add("messageType", message[3]);
                    data.Add("messageValue", message[4]);
                    break;
                case "PING":
                    data.Add("commandID", message[0]);
                    break;
                default :
                    break;
            }
            jsonData = JsonConvert.SerializeObject(data);
            return jsonData;
        }
    }
}