using _1303_ClientServer.Shared;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace _1303_ClientServer.Section1
{
    class Assignment2 : AssignmentBase
    {
        public void runThreads()
        {
            Thread thread = new Thread(callFiveFunctions);
            thread.Start();
            Console.WriteLine();
            thread.Join();
        }

        private void WriteLetters1()
        {
            for (int j = 0; j < 101; j++)
            {
                Console.Write('a');
                Thread.Yield();
            }
            Console.WriteLine("\n");
        }
        private void WriteLetters2()
        {
            for (int j = 0; j < 101; j++)
            {
                Console.Write('a');
                Thread.Yield();
            }
            Console.WriteLine("\n");
        }

        private void WriteLetters3()
        {
            for (int j = 0; j < 101; j++)
            {
                Console.Write('a');
                Thread.Yield();
            }
            Console.WriteLine("\n");
        }
        private void WriteLetters4()
        {
            for (int j = 0; j < 101; j++)
            {
                Console.Write('a');
                Thread.Yield();
            }
            Console.WriteLine("\n");
        }
        private void WriteLetters5()
        {
            for (int j = 0; j < 101; j++)
            {
                Console.Write('a');
                Thread.Yield();
            }
            Console.WriteLine("\n");
        }
          
        private void callFiveFunctions()
        {
            WriteLetters1();
            WriteLetters2();
            WriteLetters3();
            WriteLetters4();
            WriteLetters5();

        }
            
        protected override void Execute()
            {
                runThreads();
            }
    }
}
