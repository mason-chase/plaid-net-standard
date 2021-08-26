![alt text](Plaid-Logo.png "Plaid.NetStandard")

## Plaid.com C# NetStandard client library


Submitting a job application
```C#
string jsonFile = File.ReadAllText($"Samples{Ds}JobsRequestSample.json");
var request = JsonConvert.DeserializeObject<JobsRequest>(jsonFile);

var client = new PlaidCareerClient();
var response = client.Jobs(request);
            
Output.WriteLine(response.Data.ToString());
```