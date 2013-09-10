using Newtonsoft.Json;
using Restafari.Hal;

namespace Restafari.Demo.Client.Complex.Hal
{
    public class HalJsonDeserializationStrategy : IDeserializationStrategy
    {
        public T Deserialize<T>(string payload)
        {
            if (typeof(HalResource).IsAssignableFrom(typeof(T)) && typeof(T).IsGenericType)
            {
                var halObject = JsonConvert.DeserializeObject<HalResource>(payload);
                var converter = typeof(T).GetMethod("FromHalResource", new[] { typeof(HalResource) });
                return (T)converter.Invoke(null, new object[] { halObject });
            }

            if (typeof(T).IsArray)
            {
                var type = typeof(T).GetElementType();
                if (typeof(HalResource).IsAssignableFrom(type) && type.IsGenericType)
                {
                    var halObjects = JsonConvert.DeserializeObject<HalResource[]>(payload);
                    var converter = type.GetMethod("FromHalResource", new[] { typeof(HalResource[]) });
                    return (T)converter.Invoke(null, new object[] { halObjects });
                }
            }

            return JsonConvert.DeserializeObject<T>(payload);
        }
    }
}
