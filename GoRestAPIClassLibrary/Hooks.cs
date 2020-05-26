using System;
using GoRestAPITesting.DataEntities;
using RestSharp;
using TechTalk.SpecFlow;

namespace GoRestAPITesting
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext context;
        private IRestResponse apiResponse;
        public static string idValue;
        public static bool flag = false;
        public static bool individualExecution = true;
        public Hooks(ScenarioContext context)
        {
            this.context = context;
        }

        [BeforeScenario("users")]
        public void BeforeUsersTest()
        {
            individualExecution = false;
        }

        [BeforeScenario("albums")]
        public void BeforeAlbumTest()
        {
            if (individualExecution)
            {
                BaseClass.userID = "1555";
            }
            


            //bool currentFlag = this.context.TryGetValue("flag", out Boolean flag);
            //if (currentFlag.Equals(false))
            //{
            //    flag = false;
            //    RestAPIHelper.SetUrl();
            //    RestAPIHelper.CreateJSONRequest("xml", BaseClass.usersEndPoint);
            //    apiResponse = RestAPIHelper.GetResponse();
            //    idValue = RestAPIHelper.ReturnXmlId(apiResponse);
            //    this.context.Set("uid", idValue);
            //}
        }
    }
}
