namespace GameManager.Management
{
    using Common;
    using TcpGameClient;

    public class GameLogicManager
    {
        private const int serverPort = 60007;
        private const int maxNumberOfGuesses = 5;
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
            var response = this.gameTcpClient.SendRequest(guess);
            numberOfGuesses++;
            if (numberOfGuesses >= maxNumberOfGuesses)
            {
                return Constant.GameEndedMessage;
            }

            return response;
        }

        public void Dispose()
        {
            this.gameTcpClient.Dispose();
        }
    }
}
