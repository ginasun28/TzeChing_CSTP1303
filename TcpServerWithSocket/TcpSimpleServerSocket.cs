using Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpServerWithSocket
{
    public class TcpSimpleServerSocket
    {
        private const int BufferSize = 128;
        private const int CommandLength = 23;

        private readonly int portNumber;
        private readonly ILogger logger;

        public TcpSimpleServerSocket(int portNumber, ILogger logger)
        {
            this.portNumber = portNumber;
            this.logger = logger;
        }

        public void RunServer()
        {
            Socket serverSocket = null;
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
                var host = Dns.GetHostEntry(Dns.GetHostName());
                var ipAddress = host.AddressList[0];

                serverSocket.Bind(new IPEndPoint(ipAddress, portNumber));
                this.logger.Log(Constant.StartServerListener);
            }
            catch (SocketException e)
            {
                this.logger.Log(Constant.SocketExceptionTemplate, e.ErrorCode, e.Message);
                throw;
            }

            byte[] receiveBuffer = new byte[BufferSize];

            while (true)
            {
                Socket clientSocket = null;
                try
                {
                    // Supply the new TcpClient instance for each new TCP connection
                    this.logger.Log(Constant.ServerReadyToAcceptClientRequest);

                    serverSocket.Listen(100);

                    // Get the client connection
                    clientSocket = serverSocket.Accept();

                    this.logger.Log(Constant.StartProcessRequest);

                    int bytesRecieved = 0;
                    int totalBytesRecieved = 0;
                    string receivedMessage = null;
                    while (true)
                    {
                        bytesRecieved = clientSocket.Receive(receiveBuffer, 0, CommandLength, SocketFlags.None);
                        if (bytesRecieved <= 0)
                        {
                            break;
                        }
                        receivedMessage = Encoding.ASCII.GetString(receiveBuffer);
                        this.logger.Log(Constant.ReceivedTemplateShort, receivedMessage);

                        clientSocket.Send(receiveBuffer, 0, bytesRecieved, SocketFlags.None);
                        totalBytesRecieved += bytesRecieved;
                    }

                    this.logger.Log(Constant.SentTemplateShort, receivedMessage);
                }
                catch (Exception e)
                {
                    this.logger.Log(Constant.ExceptionTemplate, e.Message);
                }
                finally
                {
                    clientSocket.Close();
                }
            }
        }
    }
}
