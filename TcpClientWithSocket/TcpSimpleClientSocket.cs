using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TcpClientWithSocket
{
    public class TcpSimpleClientSocket
    {
        public void SendRequest()
        {
            var serverPortNumber = 60011;

            Socket socket = null;

            try
            {
                byte[] sendBuffer = Encoding.ASCII.GetBytes("MessageFromSocketClient");

                socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
                
                // gets the host name for the current machine
                var host = Dns.GetHostEntry(Dns.GetHostName()); 
                var ipAddress = host.AddressList[0];
                
                IPEndPoint serverEndPoint = new IPEndPoint(ipAddress, serverPortNumber);

                socket.Connect(serverEndPoint);
                Console.WriteLine("Connection has been established");

                socket.Send(sendBuffer, 0, sendBuffer.Length, SocketFlags.None);
                Console.WriteLine("Sent {0} bytes to server", sendBuffer.Length);

                int bytesRecieved = 0;
                int totalBytesRecieved = 0;
                byte[] messageRecievedBuffer = new byte[sendBuffer.Length];
                while (totalBytesRecieved < sendBuffer.Length)
                {
                    bytesRecieved = socket.Receive(messageRecievedBuffer,
                        totalBytesRecieved,
                        sendBuffer.Length - totalBytesRecieved,
                        SocketFlags.None);

                    totalBytesRecieved += bytesRecieved;
                }

                Console.WriteLine("Received {0} bytes from server", totalBytesRecieved);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
            finally
            {
                socket.Close();
            }
        }
    }
}
