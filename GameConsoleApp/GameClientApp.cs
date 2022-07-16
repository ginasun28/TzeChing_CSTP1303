using Common;
using GameManager.Management;
using System;

namespace GameConsoleApp
{
    public class GameClientApp
    {
        private readonly GameLogicManager gameLogicManager = new GameLogicManager(); 

        static void Main(string[] args)
        {
            var app = new GameClientApp();
            var number = app.GetIntegerFromConsole("Pick a number from 1 to 5:");
            
            app.ProcessGame(number);
        }

        private int GetIntegerFromConsole(string message)
        {
            Console.WriteLine(message);
            string msg = Console.ReadLine();
            bool success = int.TryParse(msg, out var result) ;
            if(success)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Your input is not integer." + message);
            }
            // TODO: add error handling for invalid user input
            var command = int.Parse(msg);
            return command;
        }

        private void ProcessGame(int command)
        {
            var response = this.gameLogicManager.InitializeGame(command);
            Console.WriteLine("initial Game response from server: {0}", response);

            while (response != Constant.GameEnded && response != Constant.GameWinner)
            {
                Console.WriteLine("Take a guess:");
                var guess = Console.ReadLine();
                response = this.gameLogicManager.SendGuess(guess);
                Console.WriteLine("Server response: {0}", response);
            }

            this.gameLogicManager.Dispose();
        }
    }
}
