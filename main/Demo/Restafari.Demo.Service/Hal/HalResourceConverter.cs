using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Restafari.Demo.Service.Hal
{
    public class HalResourceConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var hal = (HalResource) value;
            var token = JToken.FromObject(hal.Properties);
            var links = JToken.FromObject(GetHalLinksFor(value));

            var o = (JObject)token;
            o.AddFirst(new JProperty("_links", links));

            if (hal.Embedded.Count > 0)
            {
                var embedded = JToken.FromObject(hal.Embedded);
                o.Last.AddAfterSelf(new JProperty("_embedded", embedded));
            }

            o.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var o = JObject.Load(reader);
            var result = new HalResource();

            foreach (var field in o)
            {
                if (field.Key == "_links")
                {
                    result.Links = field.Value.ToObject<Dictionary<string, HalLink>>();
                }
                else if (field.Key == "_embedded")
                {
                    result.Embedded = field.Value.ToObject<Dictionary<string, HalResource>>();
                }
                else
                {
                    result.Properties.Add(field.Key, field.Value);
                }
            }

            return o;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(HalResource));
        }

        private object GetHalLinksFor(object value)
        {
            return new Dictionary<string, HalLink>
                       {
                           {"_self", new HalLink{Href = "aaaa", Rel = "bbbb"}},
                           {"orders", new HalLink{Href = "cccc", Rel = "dddd"}},
                       };
        }

    }
}