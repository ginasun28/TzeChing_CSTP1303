using _1303_ClientServer.Shared;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _1303_ClientServer
{
    public class Assignment1 : AssignmentBase
    {
        protected override void Execute()
        {
            Thread t1 = new Thread(printNum);
            t1.Start();
            Thread t2 = new Thread(PrintChar);
            t2.Start();

        }
        
        // Print the numbers
        public static void printNum()
        {

            for (int i = 1; i < 201; i++)
            {
                Console.Write(i);
            }
        }

        // Print the characters
        private static void PrintChar()
        {
            for (int j = 0; j < 5; j++)
            {
                for (char i = 'a'; i <= 'z'; i++)
                {
                    Console.Write(i);
                }

            }
        }
    }
}