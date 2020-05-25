using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json.Linq;
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

            if (endpoint.Equals(albumsEndPoint))
            {
                restRequest.AddHeader("user_id", GoRestAPISteps.idValue);
            }
            return restRequest;
        }

        public static IRestResponse GetResponse()
        {
            var restResponse = client.Execute(restRequest);
            return restResponse;
        }

        public static int ReturnCount(IRestResponse apiResponse)
        {
            string response = apiResponse.Content;
            var jObject = JObject.Parse(response);
            string value = jObject["_meta"]["totalCount"].Value<string>();
            int intValue = int.Parse(value);
            return intValue;
        }

        public static string ReturnId(IRestResponse apiResponse)
        {
            string response = apiResponse.Content;
            var jObject = JObject.Parse(response);
            string idValue = JObject.Parse(apiResponse.Content)["result"][0]["user_id"].Value<string>();
            return idValue;
        }
    }
}
