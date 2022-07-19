﻿using Common;
using GameManager.Management;
using System;

namespace GameConsoleApp
{
    public class GameClientApp
    {
        private readonly GameLogicManager gameLogicManager = new GameLogicManager(); 

        static void Main(string[] args)
        {
            Greeting();
            /*var app = new GameClientApp();
            Random number = new Random();
            int randomNum = number.Next(0, 5);
            app.ProcessGame(randomNum);*/

        }

        public static void Greeting()
        {
            string name;
            Console.WriteLine("Welcome to the Word Guess Game!  Would you like to play now?");
            Console.WriteLine("Enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("What's up {0}! Let's play!", name);
            Console.WriteLine("Waiting Game Start......");

            var app = new GameClientApp();
            Random number = new Random();
            int randomNum = number.Next(0, 5);
            app.ProcessGame(randomNum);
        }

        private void ProcessGame(int randomNum)
        {
            Console.WriteLine("Game Start");
            Console.WriteLine("You have 3 chances to guess a word\n");
            var response = this.gameLogicManager.InitializeGame(randomNum);
            // Console.WriteLine($"Initial Game response from server: {response}");

            while (!(response.Equals( Constant.GameEndedMessage) || response.Equals( Constant.GameWinner)))
            {
                Console.WriteLine("Guess a word:");
                var guess = Console.ReadLine();
                response = this.gameLogicManager.SendGuess(guess);
                if (response.Equals(Constant.GameEndedMessage))
                {
                    Console.WriteLine($"Server response: Game Over");
                }
                else if (response.Equals(Constant.GameWinner))
                {
                    Console.WriteLine($"Server response: You Won");
                }
                else
                {
                    Console.WriteLine($"Server response: {response.ToLower()}");
                }
            }



            this.gameLogicManager.Dispose();
        }
    }
}
