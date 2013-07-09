using System.Collections.Generic;

namespace Restafari.Serialization
{
    internal class DeserializationContext
    {
        private static readonly Dictionary<ContentType, IDeserializationStrategy> DeserilizationStrategy = new Dictionary<ContentType, IDeserializationStrategy> { { ContentType.Json, new JsonDeserializationStrategy() }, { ContentType.Xml, new XmlDeserializationStrategy() } }; 


        public T Deserialize<T>(ContentType contentType, string payload)
        {
            return DeserilizationStrategy[contentType].Deserialize<T>(payload);
        }
    }
}
