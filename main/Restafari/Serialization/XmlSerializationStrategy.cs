using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Restafari.Serialization
{
    internal class XmlSerializationStrategy : ISerializationStrategy
    {
        public bool CanSerialize(Method method, ContentType type, Parameters parameters)
        {
            return ContentType.Xml == type && (Method.Post == method || Method.Put == method) && parameters != null && parameters.Count > 0;
        }

        public string Serialize(Parameters parameters)
        {
            using (var writer = new StringWriter())
            {
                using (var xml = XmlWriter.Create(writer))
                {
                    if (parameters.Count == 1)
                    {
                        this.AddElement(xml, parameters.Values.First());
                    }
                    else
                    {
                        foreach(var param in parameters)
                        {
                            xml.WriteStartElement(param.Key);
                            this.AddElement(xml, param.Value);
                            xml.WriteEndElement();
                        }
                    }
                }
                
                return writer.ToString();
            }
        }

        private void AddElement(XmlWriter xml, object value)
        {
             var serializer = new XmlSerializer(value.GetType());
             serializer.Serialize(xml, value);
        }
    }
}
