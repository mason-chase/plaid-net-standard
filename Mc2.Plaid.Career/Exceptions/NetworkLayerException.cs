using System;

namespace Mc2.Plaid.Career.Exceptions
{
    public class NetworkLayerException : Exception
    {
        public NetworkLayerException(string message , Exception ex): base(message, ex)
        {

        }
    }
}
