using Common;

using System;
using System.Net.Sockets;
using System.Text;

namespace TcpSimpleClient
{
    public class TcpBasicClient : AssignmentBase
    {
        private readonly ILogger logger;
        public TcpBasicClient(ILogger logger)
        {
            this.logger = logger;
        }

        public void SendRequest()
        {
            int serverPort = 60007;
            byte[] message = Encoding.ASCII.GetBytes(Constant.HelloCommand);

            TcpClient tcpClient = null;
            try
            {
                tcpClient = new TcpClient("", serverPort); // if any errors occur, will throw a SocketException

                var networkStream = tcpClient.GetStream();

                // Sending the request to the server
                this.logger.Log(Constant.ClientWritingRequest);
                networkStream.Write(message, 0, message.Length);
                this.logger.Log(Constant.SentTemplate, message.Length, Constant.HelloCommand);

                // Receivving the response from the server
                int bytesRecieved = 0;
                int totalBytesRecieved = 0;
                byte[] messageRecieved = new byte[message.Length];
                this.logger.Log(Constant.ClientAwaitingResponse);
                while (totalBytesRecieved < message.Length)
                {
                    bytesRecieved = networkStream.Read(messageRecieved, totalBytesRecieved, message.Length - totalBytesRecieved);
                    totalBytesRecieved += bytesRecieved;
                }

                this.logger.Log(Constant.ReceivedTemplate, totalBytesRecieved, Encoding.ASCII.GetString(messageRecieved));
            }
            catch(Exception e)
            {
                this.logger.Log(Constant.ExceptionTemplate, e.Message);
            }
            finally
            {
                tcpClient.Dispose();
            }
        }

        protected override void Execute()
        {
            SendRequest();
        }
    }
}
