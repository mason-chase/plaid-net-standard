using Azihub.Utilities.Base.Tests;
using Mc2.Plaid.Career.Endpoints.Jobs;
using Newtonsoft.Json;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Mc2.Plaid.Career.Tests
{
    public class PlaidClientTests : TestBase
    {
        private readonly char _ds = Path.DirectorySeparatorChar;

        public PlaidClientTests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void WebsiteSampleDataTest()
        {
            string jsonFile = File.ReadAllText($"Samples{_ds}JobsRequestSample.json");
            JobsRequest request = JsonConvert.DeserializeObject<JobsRequest>(jsonFile);

            PlaidCareerClient client = new();
            JobsResponse response = client.Jobs(request);
            
            Output.WriteLine(response.Data.ToString());
        }
    }
}
