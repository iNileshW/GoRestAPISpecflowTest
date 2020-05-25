using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GoRestAPITesting.DataEntities
{
    public class XmlMeta
    {
        [JsonProperty("totalCount")]
        public string TotalCount { get; set; }
    }
}
