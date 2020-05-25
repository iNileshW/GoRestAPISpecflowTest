using System;
using System.Collections.Generic;
using System.Text;
using GoRestAPITesting.DataEntities;
using RestSharp;

namespace GoRestAPITesting.Util
{
    public class Deserialization
    {
        public static XmlMeta ResponseDeserialization(IRestResponse restResponse)
        {
            RestSharp.Deserializers.XmlDeserializer deserializer = new RestSharp.Deserializers.XmlDeserializer();
            var metaObject = deserializer.Deserialize<XmlMeta>(restResponse);
            return metaObject;
        }

        public static string IdDeserialization(IRestResponse restResponse)
        {
            RestSharp.Deserializers.XmlDeserializer deserializer = new RestSharp.Deserializers.XmlDeserializer();
            var resultObject = deserializer.Deserialize<XmlResult>(restResponse);
            List<string> IdList = new List<string>();
            //foreach (var item in resultObject.Result)
            foreach (var item in resultObject.Result)
            {
                //if (item.Equals("id"))
                //{
                //    //var itemObject = deserializer.Deserialize<XmlItem>(item);
                //    IdList.Add(item);
                //}

                var itemObject = item.Substring(0, 4);
                IdList.Add(itemObject);
            }
            string id = IdList[0];
            return id;
        }
    }
}
