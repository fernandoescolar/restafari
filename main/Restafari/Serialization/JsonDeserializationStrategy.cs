using Newtonsoft.Json;
using System.Text;

namespace Restafari.Serialization
{
    internal class JsonDeserializationStrategy : IDeserializationStrategy
    { 
        public bool CanSerialize(string contentType)
        {
            return contentType == ContentTypes.Json;
        }

        public T Deserialize<T>(byte[] payload, Encoding encoding)
        {
            return JsonConvert.DeserializeObject<T>(encoding.GetString(payload, 0, payload.Length));
        }       
    }
}
