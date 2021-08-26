using Newtonsoft.Json;

namespace Mc2.Plaid.Career.Endpoints.Errors
{
    public class MissingToken : IFailedResponse
    {
        /*
        "{\"message\":\"Missing Authentication Token\"}"
        */
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
