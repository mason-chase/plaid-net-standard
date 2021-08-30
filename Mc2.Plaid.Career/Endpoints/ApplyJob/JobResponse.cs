using Azihub.Appstract.ApiClient;
using System.Net.Http;

namespace Mc2.Plaid.Career.Endpoints.ApplyJob
{
    public class JobsResponse : HttpResponse<MessageSuccess, MessageFailed>
    { 
        /// <summary>
        /// Create response from successful data.
        /// </summary>
        /// <param name="dataSuccess"></param>
        public JobsResponse(MessageSuccess dataSuccess, HttpRequestMessage request, HttpResponseMessage response) : 
            base(dataSuccess, request, response) {}

        /// <summary>
        /// Create response of from failed data.
        /// </summary>
        /// <param name="dataFailed"></param>
        public JobsResponse(MessageFailed dataFailed, HttpRequestMessage request, HttpResponseMessage response) : 
            base(dataFailed, request, response) {}
    }
}
