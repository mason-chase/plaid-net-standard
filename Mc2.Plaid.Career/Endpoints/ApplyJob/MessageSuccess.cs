using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.Plaid.Career.Endpoints.ApplyJob
{
    public class MessageSuccess
    {
        public MessageSuccess() 
        {
            Message = SUCCESS_RESPONSE;
        }
        public MessageSuccess(string message)
        {
            if (message.Trim('"') != SUCCESS_RESPONSE)
                throw new InvalidSuccessfulMessage("Message received is not successful, it must match: "+ SUCCESS_RESPONSE, message);
            Message = message;
        }
        public string Message { get; }
        public const string SUCCESS_RESPONSE = "We got your application and we'll get back to you shortly!";
    }
}
