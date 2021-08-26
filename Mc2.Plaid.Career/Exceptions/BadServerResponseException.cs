using System;
using System.Net.Http;

namespace Mc2.Plaid.Career.Exceptions
{
    /// <summary>
    /// Server response is not defined in success or failed model.
    /// </summary>
    public class BadServerResponseException : Exception
    {
        private HttpResponseMessage ResponseMessage;
        private string Body;


        public BadServerResponseException(HttpResponseMessage responseMessage, string body)
        {
            ResponseMessage = responseMessage;
            Body = body;
        }
    }
}