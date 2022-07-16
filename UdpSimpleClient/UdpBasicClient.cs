namespace UdpSimpleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class UdpBasicClient
    {
        public void SendPacket()
        {
            string serverIP = "";
            int serverPort = 60010;

            byte[] packet = Encoding.ASCII.GetBytes("MyFristUdpPacket");

            // can send datagrams to any UDP socket
            UdpClient udpClient = new UdpClient();

            try
            {
                // send the packet (datagram) to the specified server IP / Port
                var bytesSent = udpClient.Send(packet, packet.Length, serverIP, serverPort);

                IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] receivedPacket = udpClient.Receive(ref remoteIPEndPoint);

                var receivedPacketString = Encoding.ASCII.GetString(receivedPacket, 0, receivedPacket.Length);
                Console.WriteLine(receivedPacketString);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                udpClient.Close();
            }
        }
    }
}
