
namespace Mc2.Plaid.Career.Endpoints.Jobs
{
    public class JobsResponse : Response<JobsResponseSuccess, JobsResponseFailed>
    { 
        /// <summary>
        /// Create response from successful data.
        /// </summary>
        /// <param name="dataSuccess"></param>
        public JobsResponse(JobsResponseSuccess dataSuccess) : base(dataSuccess) {}

        /// <summary>
        /// Create response of from failed data.
        /// </summary>
        /// <param name="dataFailed"></param>
        public JobsResponse(JobsResponseFailed dataFailed) : base(dataFailed) {}
    }
}
