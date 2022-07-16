using Common;
using System;

namespace TcpServer
{
    public class GameProcessor
    {
        private int numberPicked = -1;

        public GameProcessor()
        {
        }

        public string Process(string request)
        {
            if (this.numberPicked == -1)
            {
                return this.InitializeGame(request);
            }

            return this.CompareGuess(request);
        }

        private string InitializeGame(string request)
        {
            this.numberPicked = Convert.ToInt32(request);
            if (this.numberPicked <= 0 || numberPicked > 10)
            {
                return "Error!";
                /*return Constant.GameServerError1 + "Error!";*/
            }
            return "The game is start!";
            /*return Constant.GameStarted + "The game is start!";*/
        }

        private string CompareGuess(string request)
        {
            if (request == GameData.Words[this.numberPicked - 1])
            {
                /*return Constant.GameWinner;*/
                return "You Win!!";
            }
            return "Keep guessing";
            /*return Constant.GuessAgain;*/
        }
    }
}
