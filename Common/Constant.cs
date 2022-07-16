using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class Constant
    {
        // Messages
        public const string StartServerListener = "starting server listener";
        public const string StartGameServerListener = "starting Game Server Listener ..";
        public const string StartProcessRequest = "starting to process a client request";
        public const string ServerReadyToAcceptClientRequest = "server ready to accept client request";
        public const string ClientWritingRequest = "client is writing request";
        public const string ClientAwaitingResponse = "client is awaiting response";

        // Message Templates
        public const string SocketExceptionTemplate = "SocketException - ErrorCode: {0}, ErrorMessage: {1}";
        public const string ReceivedTemplate = "received bytes: {0}, message: {1}";
        public const string SentTemplate = "sent bytes: {0}, message: {1}, timestamp: {2}";
        public const string SentTemplateShort = "sent message: {0}";
        public const string ExceptionTemplate = "Exception ErrorMessage: {0}";
        public const string ReceivedTemplateShort = "received message: {0}";

        // Client Messages
        public const string GameStartedMessage = "Game started, guess the word";
        public const string GameEndedMessage = "You're out of guesses, game ended";

        // Server Response Codes 
        public const string HelloCommand = "HelloFromClient";
        public const string GameEnded = "Game End";
        public const string GameWinner = "You Win!!";
        public const string GameStarted = "Game Start";
        public const string GameServerError1 = "Error!";
        public const string GuessAgain = "Keep guessing";
    }
}
