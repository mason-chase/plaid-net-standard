![alt text](Plaid-Logo.png "Plaid.NetStandard")

## Plaid.com C# NetStandard client library


Submitting a job application,
first copy the sample json to new .json and edit content:
```bash
cp Mc2.Plaid.Career.Tests/Samples/JobsRequestSample.json Mc2.Plaid.Career.Tests/JobsRequest.json
```

```C#
string jsonFile = File.ReadAllText($"Samples{Ds}JobsRequestSample.json");
var request = JsonConvert.DeserializeObject<JobsRequest>(jsonFile);

var client = new PlaidCareerClient();
var response = client.Jobs(request);
            
Output.WriteLine(response.Data.ToString());
```

application is parsed from `.json` file:
```json
{
  "name": "Jenny Applicant",
  "email": "john@doe.com",
  "resume": "www.john-doe.com/john-doe.pdf",
  "phone": "555-867-5309",
  "job_id": "f6416ac9-86a1-4419-908e-557f7214f0cc",
  "github": "https://www.github.com/octocat", // optional
  "twitter": "@example", // optional
  "website": "https://www.example.com", // optional
  "location": "", // optional
  "favorite_candy": "m&m’s", // optional
  "superpower": "multilingual" // optional
}
```