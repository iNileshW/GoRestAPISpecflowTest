using GoRestAPITesting;
using GoRestAPITesting.DataEntities;
using GoRestAPITesting.Util;
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

        public static RestRequest CreateRequest(string format, string endpoint, string idValue)
        {
            restRequest = new RestRequest(endpoint, Method.GET);            
            if (format.Equals("json"))
            {
                restRequest.RequestFormat = RestSharp.DataFormat.Json;
                restRequest.AddQueryParameter("_format", format);
            }
            else if (format.Equals("xml"))
            {
                restRequest.RequestFormat = RestSharp.DataFormat.Xml;
                restRequest.AddQueryParameter("_format", format);
            }
            restRequest.AddHeader("Authorization", "Bearer "+MyToken);

            if (endpoint.Equals(albumsEndPoint))
            {
                if (Hooks.individualExecution)
                {
                    idValue = BaseClass.userID;
                }

                else
                {
                    idValue = GoRestAPISteps.idValue;
                }
                
                restRequest.AddQueryParameter("user_id", idValue);
            }
            return restRequest;
        }

        public static IRestResponse GetResponse(RestRequest sentRequest)
        {
            var restResponse = client.Execute(sentRequest);
            return restResponse;
        }

        public static int ReturnCount(string format, IRestResponse apiResponse)
        {
            string responseString = apiResponse.Content;
            int intValue=0;
            if (format.Equals("json"))
            {
                var jObject = JObject.Parse(responseString);
                string value = jObject["_meta"]["totalCount"].Value<string>();
                intValue = int.Parse(value);
            }
            else if (format.Equals("xml"))
            {
                var responseObject = Deserialization.ResponseDeserialization(apiResponse);
                string value = responseObject.TotalCount;                
                intValue = int.Parse(value);                
            }
            return intValue;
        }

        public static string ReturnXmlId(IRestResponse apiResponse)
        {
            var responseObject = Deserialization.IdDeserialization(apiResponse);
            return responseObject;
        }

        public static string ReturnId(string format, IRestResponse apiResponse)
        {
            string idValue= GoRestAPISteps.idValue;
            if (format.Equals("json"))
            {
                string response = apiResponse.Content;
                var jObject = JObject.Parse(response);
                idValue = JObject.Parse(apiResponse.Content)["result"][0]["user_id"].Value<string>();                
            }
            else if (format.Equals("xml"))
            {
                idValue = Deserialization.AlbumIdDeserialization(apiResponse);                
            }
            return idValue;
        }
    }
}
