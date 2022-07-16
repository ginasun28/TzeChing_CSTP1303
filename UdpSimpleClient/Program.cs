namespace UdpSimpleClient
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            new UdpBasicClient().SendPacket();
        }
    }
}
