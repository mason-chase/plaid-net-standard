using Mc2.Plaid.Career.Endpoints.Jobs;
using System.Net.Http;
using Mc2.Plaid.Career.Endpoints;

namespace Mc2.Plaid.Career
{
    public partial class PlaidCareerClient
    {
        private const string JOBS_ENDPOINT = "/jobs";
        public JobsResponse Jobs(JobsRequest jobsRequest)
        {
            // Plaid team, Why don't reply errors with an object?
            // I hate it when RestAPI is not consistent!
            Response<string, string> responseAdapt = SendApiRequest<string, string>(HttpMethod.Post, jobsRequest, JOBS_ENDPOINT);
            string responseText = ((string)responseAdapt.Data).Trim('"', ' ');

            // We need to adapt a failed response.
            JobsResponse response;
            if (responseText == JobsResponseSuccess.SUCCESS_RESPONSE)
                response = new JobsResponse(new JobsResponseSuccess()); 
            else
                response = new JobsResponse(new JobsResponseFailed { Message = responseAdapt.DataFailed });

            return response;
        }
    }
}
