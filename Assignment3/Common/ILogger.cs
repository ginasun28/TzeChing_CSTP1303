using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface ILogger
    {
        void Log(string messageTemplate, int number, string message);

        void Log(string messageTemplate, int number);

        void Log(string messageTemplate, string message);

        void Log(string message);
    }
}
