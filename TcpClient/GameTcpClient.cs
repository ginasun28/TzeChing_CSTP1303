using Common;
using System;
using System.Net.Sockets;
using System.Text;

namespace TcpGameClient
{
    public class GameTcpClient
    {
        private readonly ILogger logger;
        private readonly int port;
        private TcpClient tcpClient;

        public GameTcpClient(int port, ILogger logger)
        {
            this.port = port;
            this.logger = logger;
            this.tcpClient = new TcpClient("", this.port); // if any errors occur, will throw a SocketException
        }

        public string SendRequest(string request)
        {
            byte[] message = Encoding.ASCII.GetBytes(request);
            string messageReturnedFromServer = null;
            try
            {
                var networkStream = this.tcpClient.GetStream();

                // Sending the request to the server
                this.logger.Log(Constant.ClientWritingRequest);
                networkStream.Write(message, 0, message.Length);
                this.logger.Log(Constant.SentTemplate, message.Length, request);

                // Receiving the response from the server
                int bytesRecieved = 0;
                byte[] messageRecieved = new byte[1];
                this.logger.Log(Constant.ClientAwaitingResponse);

                bytesRecieved = networkStream.Read(messageRecieved, 0, 1);

                messageReturnedFromServer = Encoding.ASCII.GetString(messageRecieved);
                // this.logger.Log(Constant.ReceivedTemplate, messageRecieved.Length, messageReturnedFromServer);
            }
            catch(Exception e)
            {
                this.logger.Log(Constant.ExceptionTemplate, e.Message);
            }

            return messageReturnedFromServer;
        }

        public void Dispose()
        {
            this.tcpClient.Dispose();
        }
    }
}
