using Common;

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpServer
{
    public class GameTcpServer
    {
        private const int BufferSize = 128;
        private const int CommandLength = 15;
        private GameProcessor gameProcessor;

        private readonly int portNumber;
        private readonly ILogger logger;

        public GameTcpServer(int portNumber, ILogger logger)
        {
            this.portNumber = portNumber;
            this.logger = logger;
            this.gameProcessor = new GameProcessor();
        }

        public void RunServer()
        {
            TcpListener tcpListener = null;
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, this.portNumber);
                tcpListener.Start();
                this.logger.Log(Constant.StartGameServerListener);
            }
            catch(SocketException e)
            {
                this.logger.Log(Constant.SocketExceptionTemplate, e.ErrorCode, e.Message);
                throw;
            }

            byte[] receiveBuffer = new byte[BufferSize];

            while(true)
            {
                TcpClient tcpClient = null;
                try
                {
                    // Supply the new TcpClient instance for each new TCP connection
                    this.logger.Log(Constant.ServerReadyToAcceptClientRequest);
                    tcpClient = tcpListener.AcceptTcpClient();
                    this.logger.Log(Constant.StartProcessRequest);

                    int bytesRecieved = 0;
                    int totalBytesRecieved = 0;
                    string receivedMessage = null;
                    var networkStream = tcpClient.GetStream();
                    while (true)
                    {
                        bytesRecieved = networkStream.Read(receiveBuffer, 0, CommandLength);
                        if (bytesRecieved <= 0)
                        {
                            break;
                        }
                        receivedMessage = Encoding.ASCII.GetString(receiveBuffer);
                        this.logger.Log(Constant.ReceivedTemplate, bytesRecieved, receivedMessage);
                        
                        var response = this.gameProcessor.Process(receivedMessage.Substring(0, bytesRecieved));
                        var bytesToSend = Encoding.ASCII.GetBytes(response); 

                        networkStream.Write(bytesToSend, 0, response.Length);
                        totalBytesRecieved += bytesRecieved;
                    }
                    this.logger.Log(Constant.SentTemplate, receivedMessage);

                    networkStream.Close();
                    tcpClient.Close();
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
        }
    }
}
