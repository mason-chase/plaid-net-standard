using Newtonsoft.Json;

namespace Mc2.Plaid.Career.Endpoints.Jobs
{
    public class JobsResponseFailed : IFailedResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
