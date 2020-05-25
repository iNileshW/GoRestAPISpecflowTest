using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace GoRestAPITesting.DataEntities
{
    public class Result
    {
        [XmlElement("item")]
        public string Item { get; set; }        
    }
}
