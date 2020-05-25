using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using System.Xml.Serialization;
using GoRestAPITesting.DataEntities;
using GoRestAPITesting.Util;
using Newtonsoft.Json.Linq;
using Org.XmlUnit.Constraints;
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
                //restRequest.RequestFormat = RestSharp.DataFormat.Json;
                restRequest.AddQueryParameter("_format", format);
            }
            else if (format.Equals("xml"))
            {
                /*restRequest.RequestFormat = RestSharp.DataFormat.Xml;
                restRequest.AddHeader("_format", format);*/
                restRequest.AddQueryParameter("_format", format);
            }
            restRequest.AddHeader("Authorization", "Bearer "+MyToken);

            if (endpoint.Equals(albumsEndPoint))
            {
                restRequest.AddHeader("user_id", GoRestAPISteps.idValue);
                restRequest.AddQueryParameter("user_id", GoRestAPISteps.idValue);
            }
            return restRequest;
        }

        public static IRestResponse GetResponse()
        {
            var restResponse = client.Execute(restRequest);
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
                //XElement xmlcode = XElement.Load(apiResponse.Content);
                //IEnumerable<XElement> response = xmlcode.Elements();
                //List<string> responseList = new List<string>();
                //foreach (var item in response)
                //{
                //    if(item.Attribute("_meta").Value == "_meta")
                //    {
                //        foreach (var submenu in item.Elements())
                //        {
                //            responseList.Add(submenu.Attribute("totalCount").Value);
                //        }
                //    }
                //}

                var responseObject = Deserialization.ResponseDeserialization(apiResponse);
                string value = responseObject.TotalCount;                
                intValue = int.Parse(value);                
            }
            return intValue;
        }

        public static string ReturnXmlId(IRestResponse apiResponse)
        {
            var responseObject = Deserialization.IdDeserialization(apiResponse);

            /*XmlSerializer deserializer = new XmlSerializer(typeof(XmlResponse));
            TextReader reader = new StreamReader(apiResponse.Content.ToString());
            object obj = deserializer.Deserialize(reader);
            XmlResponse XmlData = (XmlResponse)obj;
            reader.Close();
            Console.WriteLine(XmlData);
            var responseObject = XmlData.ToString();*/
            return responseObject;
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
