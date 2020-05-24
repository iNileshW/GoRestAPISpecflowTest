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

        public static RestRequest CreateJSONRequest(string format, string endpoint)
        {
            restRequest = new RestRequest(endpoint, Method.GET);            
            if (format.Equals("json"))
            {
                restRequest.RequestFormat = RestSharp.DataFormat.Json;
            }
            else if (format.Equals("xml"))
            {
                restRequest.RequestFormat = RestSharp.DataFormat.Xml;
                restRequest.AddHeader("_format", format);
            }
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
