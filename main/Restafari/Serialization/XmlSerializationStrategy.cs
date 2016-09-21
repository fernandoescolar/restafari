using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Restafari.Serialization
{
    internal class XmlSerializationStrategy : ISerializationStrategy
    {
        private const string OnlyOneParameterMessage = "The xml content type doesn't support more one parameter";

        public bool CanSerialize(Method method, string contentType, Parameters parameters)
        {
            return ContentTypes.Xml == contentType && (Method.Post == method || Method.Put == method || Method.Patch == method) && parameters != null && parameters.Count > 0;
        }

        public byte[] Serialize(Parameters parameters, Encoding encoding)
        {
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Encoding = encoding };
            using (var writer = new MemoryStream())
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
                
                return writer.ToArray();
            }
        }

        private void AddElement(XmlWriter xml, object value)
        {
            var serializer = new DataContractSerializer(value.GetType());
            serializer.WriteObject(xml, value);
        }
    }
}
