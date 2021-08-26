using Mc2.Plaid.Career.Endpoints.Jobs;

namespace Mc2.Plaid.Career.Endpoints
{
    public interface IEndpoints
    {
        /// <summary>
        /// Submit an application for a job
        /// </summary>
        /// <param name="jobsRequest"></param>
        /// <returns></returns>
        JobsResponse Jobs(JobsRequest jobsRequest);
    }
}
