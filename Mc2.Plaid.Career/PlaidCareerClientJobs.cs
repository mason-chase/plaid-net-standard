using Mc2.Plaid.Career.Endpoints.ApplyJob;
using System.Net.Http;
using Mc2.Plaid.Career.Endpoints;
using Azihub.Appstract.ApiClient;
using System;

namespace Mc2.Plaid.Career
{
    public partial class PlaidCareerClient : ApiClientBase, IJobsEndpoints
    {
        public PlaidCareerClient() : base(new Uri(BASE_URL)) { }

        private const string BASE_URL = "https://contact.plaid.com";
        private const string JOBS_ENDPOINT = "/jobs";
        public JobsResponse ApplyJob(JobsRequest jobsRequest)
        {
            // Plaid team, Why don't reply errors with an object?
            // I hate it when RestAPI is not consistent!
            HttpResponse<string, MessageFailed> responseAdapt = SendJsonRequest<HttpResponse<string, MessageFailed>, string, MessageFailed> (HttpMethod.Post, jobsRequest, JOBS_ENDPOINT);
            string responseText = ((string)responseAdapt.Data).Trim('"', ' ');

            // We need to adapt a failed response.
            JobsResponse response;
            if (responseText == MessageSuccess.SUCCESS_RESPONSE)
                response = new JobsResponse(new MessageSuccess(), responseAdapt.Request, responseAdapt.Response);
            else
                response = new JobsResponse(responseAdapt.DataFailed, responseAdapt.Request, responseAdapt.Response);

            return response;
        }
    }
}
