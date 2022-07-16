using Common;
using System;

namespace TcpServerWithSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            new TcpSimpleServerSocket(60011, new Logger()).RunServer();
        }
    }
}
