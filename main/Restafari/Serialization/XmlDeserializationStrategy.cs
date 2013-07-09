using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Restafari.Serialization
{
    internal class XmlDeserializationStrategy : IDeserializationStrategy
    {
        public T Deserialize<T>(string payload)
        {
            var serializer = new DataContractSerializer(typeof(T));

            using (var reader = new StringReader(payload))
            {
                using (var xml = XmlReader.Create(reader))
                {
                    return (T)serializer.ReadObject(xml);
                }
            }
        }
    }
}