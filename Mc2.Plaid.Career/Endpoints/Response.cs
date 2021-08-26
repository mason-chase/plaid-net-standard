using System;

namespace Mc2.Plaid.Career.Endpoints
{
    public class Response<TSuccess, TFailed>
    {
        [Obsolete("Please use factory methods", true)]
        public Response() { }

        public Response(TSuccess dataSuccess)
        {
            Success = true;
            Data = dataSuccess;
        }

        public Response(TFailed dataFailed)
        {
            Success = false;
            Data = dataFailed;
        }


        public static Response<TSuccess, TFailed> MakeSuccess(TSuccess data)
        {
            return new Response<TSuccess, TFailed>(data);
        }


        public static Response<TSuccess, TFailed> MakeFailed(TFailed data)
        {
            return new Response<TSuccess, TFailed>(data);
        }

        public bool Success { get; }


        public object Data { get; }

        public TSuccess DataSuccess
        {
            get
            {
                if (Success)
                    return (TSuccess) Data;
                throw new InvalidOperationException("When Request is failed, DataSuccess is available");
            }
        }

        public TFailed DataFailed
        {
            get
            {
                if (!Success)
                    return (TFailed) Data;
                throw new InvalidOperationException("When Request is successful, DataFailed is not available");
            }
        }

        public NetworkError NetworkError { get; }
    }
}
