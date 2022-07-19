namespace GameManager.Management
{
    using Common;
    using TcpGameClient;

    public class GameLogicManager
    {
        private const int serverPort = 60007;
        private const int maxNumberOfGuesses = 3;
        private int numberOfGuesses;
        private GameTcpClient gameTcpClient;

        public GameLogicManager()
        {
            this.numberOfGuesses = 0;
            this.gameTcpClient = new GameTcpClient(serverPort, new Logger());
        }

        public string InitializeGame(int command)
        {
            var response = this.gameTcpClient.SendRequest(command.ToString());
            return response;
        }

        public string SendGuess(string guess)
        {
            var response = this.gameTcpClient.SendRequest(guess.ToLower());
            if (response.Equals(Constant.GameWinner))
            {
                return response;
            }
            numberOfGuesses++;
            if (numberOfGuesses >= maxNumberOfGuesses)
            {
                return Constant.GameEndedMessage;
            }
            int chances = maxNumberOfGuesses - numberOfGuesses;
            return $"You have {chances} chances to guess the word.";
        }

        public void Dispose()
        {
            this.gameTcpClient.Dispose();
        }
    }
}
