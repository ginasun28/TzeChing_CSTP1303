using System;

namespace TcpClientWithSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            new TcpSimpleClientSocket().SendRequest();
        }
    }
}
