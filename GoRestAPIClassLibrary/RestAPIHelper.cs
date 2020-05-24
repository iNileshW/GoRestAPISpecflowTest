using GoRestAPITesting.DataEntities;
using RestSharp;

namespace GoRestAPIClassLibrary
{
    public class RestAPIHelper : GoRestAPITesting.DataEntities.BaseClass
	{
        public static RestRequest restRequest;
        private static RestClient client;

        public static void SetUrl()
        {
            client = new RestClient(baseURL);
        }

        public static RestRequest CreateJSONRequest(string endpoint)
        {
            restRequest = new RestRequest(endpoint, Method.GET);
            restRequest.RequestFormat = RestSharp.DataFormat.Json;
            restRequest.AddHeader("Authorization", "Bearer "+MyToken);
            return restRequest;
        }

        public static IRestResponse GetResponse()
        {
            var restResponse = client.Execute(restRequest);
            return restResponse;
        } 
    }
}
