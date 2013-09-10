using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Restafari.Hal
{
    [DataContract]
    [XmlRoot("link", Namespace = "")]
    public class HalLink : IXmlSerializable
    {
        [DataMember(Name = "rel")]
        public string Rel { get; set; }
        [DataMember(Name = "href")]
        public string Href { get; set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            this.Rel = reader.GetAttribute("rel");
            this.Href = reader.GetAttribute("href");
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("rel", this.Rel);
            writer.WriteAttributeString("href", this.Href);
        }
    }
}