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
        public static string idValue;
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
        }
    }
}
