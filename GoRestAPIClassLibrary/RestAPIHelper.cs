using RestSharp;

namespace GoRestAPIClassLibrary
{
    public class RestAPIHelper
	{
        public static RestRequest restRequest;
        public static string baseURL = "https://gorest.co.in/public-api/";
        private static RestClient client;

        public static void SetUrl()
        {
            client = new RestClient(baseURL);            
        }

        public static RestRequest CreateJSONRequest(string endpoint)
        {
            restRequest = new RestRequest(endpoint, Method.GET);
            string MyToken = "XTyKB6-Pr-Fk11uNOwDwFov-t75MXK2URWUE";
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
