using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Restafari.Serialization
{
    internal class XmlDeserializationStrategy : IDeserializationStrategy
    {   
        public bool CanSerialize(string contentType)
        {
            return contentType == ContentTypes.Xml;
        }

        public T Deserialize<T>(byte[] payload, Encoding encoding)
        {
            var serializer = new DataContractSerializer(typeof(T));

            using (var reader = new MemoryStream(payload, false))
            {
                using (var xml = XmlReader.Create(reader))
                {
                    return (T)serializer.ReadObject(xml);
                }
            }
        }
    }
}