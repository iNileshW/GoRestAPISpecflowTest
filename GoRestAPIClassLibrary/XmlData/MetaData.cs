using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace GoRestAPITesting.DataEntities
{
    public class MetaData
    {
        [XmlElement("totalCount")]
        public string TotalCount { get; set; }        
    }
}
