
using Common;

namespace TcpSimpleClient
{
    public static class Program
    {
        static void Main(string[] args)
        {
            new TcpBasicClient(new Logger()).Run();
        }
    }
}