using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GoRestAPITesting.DataEntities
{
    public class XmlItem
    {
        [JsonProperty("id")]
        public List<string> Id { get; set; }
    }
}
