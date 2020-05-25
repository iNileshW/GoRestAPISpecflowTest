using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using GoRestAPITesting.XmlData;

namespace GoRestAPITesting.DataEntities
{
    public class XmlResponse
    {
        [XmlElement("_meta")]
        public MetaData metaData = new MetaData();

        [XmlElement("result")]
        public List<Item> itemList = new List<Item>();
    }

    
}
