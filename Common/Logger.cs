using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Common
{
    public class Logger : ILogger
    {
        public void Log(string messageTemplate, int number, string message)
        {
            var timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            Console.WriteLine(messageTemplate, number, message, timestamp);
        }

        public void Log(string messageTemplate, int number)
        {
            Console.WriteLine(messageTemplate, number);
        }

        public void Log(string messageTemplate, string message)
        {
            Console.WriteLine(messageTemplate, message);
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
