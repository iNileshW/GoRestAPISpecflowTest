using System.Xml.Serialization;

namespace GoRestAPITesting.XmlData
{
    public class Item
    {
        [XmlElement("id")]
        public string Id { get; set; }        
    }
}
