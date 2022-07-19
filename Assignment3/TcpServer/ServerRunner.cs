using Common;
using System;

namespace TcpServer
{
    public class ServerRunner
    {
        private const int portNumber = 60007;

        static void Main(string[] args)
        {
            new GameTcpServer(portNumber, new Logger()).RunServer();
        }
    }
}
