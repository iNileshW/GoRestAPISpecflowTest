using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace GoRestAPIClassLibrary
{
    [Binding]
    public sealed class GoRestAPISteps : GoRestAPITesting.DataEntities.BaseClass
    {
        private readonly ScenarioContext context;
        private IRestResponse apiResponse;
        private string requestFormat;
        public GoRestAPISteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"user has an endpoint")]
        public void GivenUserHasAnEndpointUsers()
        {
            RestAPIHelper.SetUrl();
        }

        [When(@"get request with '(.*)' header format is sent to endpoint '(.*)'")]
        public void WhenGetRequestWithHeaderFormatIsSentToEndpoint(string format, string endpoint)
        {
            RestAPIHelper.CreateJSONRequest(format, endpoint);
            requestFormat = format;
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
            //if (requestFormat.Equals("json"))
            //{
                Assert.AreEqual(value, userCount, "Correct count number not received in the Response");
            //}
            //else if (requestFormat.Equals("xml"))
            //{                
            //    Assert.AreEqual(value, xmlCount, "Correct count number not received in the Response");
            //}
        }

    }
}
