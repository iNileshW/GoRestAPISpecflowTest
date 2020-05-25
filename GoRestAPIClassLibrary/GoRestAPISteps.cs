﻿using System.Collections.Generic;
using System.Linq;
using GoRestAPITesting.DataEntities;
using Newtonsoft.Json;
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
        
        [Then(@"validate count in api response")]
        public void ThenValidateCountInApiResponse()
        {            
            int intValue = RestAPIHelper.ReturnCount(apiResponse);

            Assert.IsTrue(intValue > 1, "Count not more than 1");

            idValue = JObject.Parse(apiResponse.Content)["result"][0]["id"].Value<string>();
        }

        [Then(@"validate album count in api response")]
        public void ThenValidateAlbumCountInApiResponse()
        {
            int intValue = RestAPIHelper.ReturnCount(apiResponse);

            Assert.IsTrue(intValue > 1, "Count not more than 1");
        }

        [Then(@"validate api response is for requested id")]
        public void ThenValidateApiResponseIsForRequestedId()
        {
            string actualId = RestAPIHelper.ReturnId(apiResponse);
            
            Assert.AreEqual(actualId, idValue);
        }

    }
}
