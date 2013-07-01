using Newtonsoft.Json;

namespace Restafari.Serialization
{
    internal class JsonDeserializationStrategy : IDeserializationStrategy
    {
        public T Deserialize<T>(string payload)
        {
            return JsonConvert.DeserializeObject<T>(payload);
        }
    }
}
