using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Restafari.Demo.Service.Hal
{
    public class HalListResourceConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var list = (HalListResource) value;
            var array = JArray.FromObject(list.ToArray());
            array.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var e = serializer.Deserialize<HalResource[]>(reader);
            return new HalListResource(e);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof (HalListResource).IsAssignableFrom(objectType);
        }
    }
}