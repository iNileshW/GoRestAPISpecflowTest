using GoRestAPITesting;
using GoRestAPITesting.DataEntities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace GoRestAPIClassLibrary
{
    [Binding]
    public class GoRestAPISteps : GoRestAPITesting.DataEntities.BaseClass
    {
        private readonly ScenarioContext context;
        private IRestResponse apiResponse;
        private string requestFormat;
        public static string idValue;
        private static RestRequest restRequest;

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
            if (Hooks.individualExecution)
            {
                idValue = BaseClass.userID;
            }

            restRequest = RestAPIHelper.CreateJSONRequest(format, endpoint, idValue);
            requestFormat = format;
        }

        [When(@"get request with '(.*)' format is sent to endpoint '(.*)'")]
        public void WhenGetRequestWithFormatIsSentToEndpoint(string format, string endpoint)
        {
            if (Hooks.individualExecution)
            {
                idValue = BaseClass.userID;
            }            

            restRequest = RestAPIHelper.CreateJSONRequest(format, endpoint, idValue);
            requestFormat = format;
        }


        [When(@"get request with (.*) header format is sent to endpoint (.*)")]
        public void WhenGetRequestWithJsonHeaderFormatIsSentToEndpointUsers(string format, string endpoint)
        {
            if (Hooks.individualExecution)
            {
                idValue = BaseClass.userID;
            }

            restRequest = RestAPIHelper.CreateJSONRequest(format, endpoint, idValue);
            requestFormat = format;
        }


        [Then(@"api response is with ok status")]
        public void ThenApiResponseIsWithOkStatus()
        {
            apiResponse = RestAPIHelper.GetResponse(restRequest);
            Assert.AreEqual(apiResponse.StatusCode, System.Net.HttpStatusCode.OK);
        }
        
        [Then(@"validate count in api response")]
        public void ThenValidateCountInApiResponse()
        {            
            int intValue = RestAPIHelper.ReturnCount(requestFormat, apiResponse);

            Assert.IsTrue(intValue > 1, "Count not more than 1");

            if (requestFormat.Equals("json")) 
            { 
                idValue = JObject.Parse(apiResponse.Content)["result"][0]["id"].Value<string>();                               
            }
            else if (requestFormat.Equals("xml"))
            {
                idValue = RestAPIHelper.ReturnXmlId(apiResponse);                
            }
            context["flag"] = true;
        }

        [Then(@"validate album count in api response")]
        public void ThenValidateAlbumCountInApiResponse()
        {
            //apiResponse = RestAPIHelper.GetResponse();
            int intValue = RestAPIHelper.ReturnCount(requestFormat, apiResponse);

            Assert.IsTrue(intValue > 1, "Count not more than 1");
        }

        [Then(@"validate api response is for requested id")]
        public void ThenValidateApiResponseIsForRequestedId()
        {
            //apiResponse = RestAPIHelper.GetResponse(restRequest);
            string actualId = RestAPIHelper.ReturnId(requestFormat, apiResponse);
            
            Assert.AreEqual(actualId, idValue);
        }

    }
}
