namespace UdpSimpleServer
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class UdpBasicServer
    {
        public void ProcessRequest()
        {
            int serverPort = 60010;

            UdpClient udpClient = null;

            try
            {
                udpClient = new UdpClient(serverPort);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            IPEndPoint remoteEndpoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    byte[] receiveBuffer = udpClient.Receive(ref remoteEndpoint);
                    Console.WriteLine("Handling client package from: {0}", remoteEndpoint);

                    udpClient.Send(receiveBuffer, receiveBuffer.Length, remoteEndpoint);
                    Console.WriteLine("Sent back the message of length: {0}", receiveBuffer.Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
