using Azihub.Utilities.Base.Tests;
using Mc2.Plaid.Career.Endpoints.ApplyJob;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Mc2.Plaid.Career.Tests
{
    public class PlaidClientTests : TestBase
    {
        private readonly char _ds = Path.DirectorySeparatorChar;

        public PlaidClientTests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void WebsiteSampleDataSuccess()
        {
            string jsonFile = File.ReadAllText($"Samples{_ds}JobsRequestSample.json");
            JobsRequest request = JsonConvert.DeserializeObject<JobsRequest>(jsonFile);

            PlaidCareerClient client = new();
            JobsResponse response = client.ApplyJob(request);
            
            Output.WriteLine("Response Headers:\n"+response.Response.Headers.ToString());

            if (response.Success)
                Output.WriteLine("Response Body:\n" + response.DataSuccess.Message);

        }

    }
}
