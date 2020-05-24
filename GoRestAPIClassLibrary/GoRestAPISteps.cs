using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace GoRestAPIClassLibrary
{
    [Binding]
    public sealed class GoRestAPISteps
    {
        private readonly ScenarioContext context;
        //private RestClient client;
        private IRestResponse apiResponse;
        public GoRestAPISteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"user has an endpoint")]
        public void GivenUserHasAnEndpointUsers()
        {
            RestAPIHelper.SetUrl();
        }

        [When(@"get request with json header format is sent to endpoint '(.*)'")]
        public void WhenGetRequestWithJsonHeaderFormatIsSentToEndpoint(string endpoint)
        {
            RestAPIHelper.CreateJSONRequest(endpoint);
        }

        [Then(@"api response is with ok status")]
        public void ThenApiResponseIsWithOkStatus()
        {
            apiResponse = RestAPIHelper.GetResponse();
            Assert.AreEqual(apiResponse.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [Then(@"with correct count in api response")]
        public void ThenWithCorrectCountInApiResponse()
        {
            string response = apiResponse.Content;
            var jObject = JObject.Parse(apiResponse.Content);
            string value = jObject["_meta"]["totalCount"].Value<string>();
            Assert.AreEqual(value, "2053", "Correct count number not received in the Response");            
        }

    }
}
