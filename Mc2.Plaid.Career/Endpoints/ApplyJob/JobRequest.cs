using Mc2.Plaid.Career.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Net.Mail;

namespace Mc2.Plaid.Career.Endpoints.ApplyJob
{
    public class JobsRequest
    {
        /*
        {
            "name": "Jenny Applicant",
            "email": "jenny@example.com",
            "resume": "www.example.com/your-resume.pdf",
            "phone": "555-867-5309",
            "job_id": "f6416ac9-86a1-4419-908e-557f7214f0cc",
            "github": "github.com/octocat", // optional
            "twitter": "@example", // optional
            "website": "www.example.com", // optional
            "location": "San Francisco", // optional
            "favorite_candy": "m&m’s", // optional
            "superpower": "multilingual" // optional
        }
         */
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonConverter(typeof(MailAddressConverter))]
        [JsonProperty("email")]
        public MailAddress Email { get; set; }

        [JsonProperty("resume")]
        public Uri Resume { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("job_id")]
        public Guid JobId { get; set; }
        
        [JsonProperty("github")]
        public Uri Github { get; set; }

        [JsonProperty("twitter")]
        public Uri Twitter { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("favorite_candy")]
        public string FavoriteCandy { get; set; }
        
        [JsonProperty("superpower")]
        public string Superpower { get; set; }

    }
}
