using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Restafari.Serialization
{
    internal class XmlSerializationStrategy : ISerializationStrategy
    {
        private const string OnlyOneParameterMessage = "The xml content type doesn't support more one parameter";

        public bool CanSerialize(Method method, ContentType type, Parameters parameters)
        {
            return ContentType.Xml == type && (Method.Post == method || Method.Put == method) && parameters != null && parameters.Count > 0;
        }

        public string Serialize(Parameters parameters)
        {
            var settings = new XmlWriterSettings {OmitXmlDeclaration = true};
            using (var writer = new StringWriter())
            {
                using (var xml = XmlWriter.Create(writer, settings))
                {
                    if (parameters.Count == 1)
                    {
                        this.AddElement(xml, parameters.Values.First());
                    }
                    else
                    {
                        throw new ArgumentException(OnlyOneParameterMessage, "parameters");
                    }
                }
                
                return writer.ToString();
            }
        }

        private void AddElement(XmlWriter xml, object value)
        {
            var serializer = new DataContractSerializer(value.GetType());
            serializer.WriteObject(xml, value);
        }
    }
}
