using System;

namespace Mc2.Plaid.Career.Endpoints
{
    public abstract class NetworkError
    {
        public NetworkError(string message, Exception exception)
        {
            Message = message;
            Exception = exception;
        }

        public string Message { get; }
        public Exception Exception { get; }
    }
}