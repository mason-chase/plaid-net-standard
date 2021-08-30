using Mc2.Plaid.Career.Endpoints.ApplyJob;

namespace Mc2.Plaid.Career.Endpoints
{
    public interface IJobsEndpoints
    {
        /// <summary>
        /// Submit an application for a job
        /// </summary>
        /// <param name="jobsRequest"></param>
        /// <returns></returns>
        JobsResponse ApplyJob(JobsRequest jobsRequest);
    }
}
