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
            this.numberPicked = int.Parse(request);
            if (this.numberPicked <= 0 || numberPicked > 10)
            {
                return Constant.GameServerError1;
            }
            return Constant.GameStarted;
        }

        private string CompareGuess(string request)
        {
            if (request == GameData.Words[this.numberPicked - 1])
            {
                return Constant.GameWinner;
            }
            return Constant.GuessAgain;
        }
    }
}
