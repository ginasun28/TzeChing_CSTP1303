namespace UdpSimpleServer
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            new UdpBasicServer().ProcessRequest();
        }
    }
}
