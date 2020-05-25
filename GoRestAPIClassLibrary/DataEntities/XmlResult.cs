using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoRestAPITesting.DataEntities
{
    public class XmlResult
    {
        [JsonProperty("result")]
        public List<string> Result { get; set; }

        public class XmlItem
        {
            [JsonProperty("id")]
            public List<string> Id { get; set; }
        }
    }
}
