using System;
using System.Runtime.Serialization;

namespace Mc2.Plaid.Career.Endpoints.ApplyJob
{
    [Serializable]
    internal class InvalidSuccessfulMessage : Exception
    {
        private string v;
        private string message;

        public InvalidSuccessfulMessage()
        {
        }

        public InvalidSuccessfulMessage(string message) : base(message)
        {
        }

        public InvalidSuccessfulMessage(string v, string message)
        {
            this.v = v;
            this.message = message;
        }

        public InvalidSuccessfulMessage(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidSuccessfulMessage(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}