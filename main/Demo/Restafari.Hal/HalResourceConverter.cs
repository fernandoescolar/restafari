using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Restafari.Hal
{
    public class HalResourceConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var hal = (HalResource) value;
            var token = JToken.FromObject(hal.Properties);
            var links = JToken.FromObject(this.GetHalLinksFor(hal.entity));

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
            if (reader.TokenType == JsonToken.StartArray)
            {
                var a = JArray.Load(reader);
                return a.Select(i => ReadHalResourceFromJson((JObject)i)).ToArray();
            }
            
            var o = JObject.Load(reader);
            return ReadHalResourceFromJson(o);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(HalResource));
        }

        private object GetHalLinksFor(object value)
        {
            var provider = HalConfig.GetProvider(value.GetType());
            if (provider != null)
            {
                return provider.GetLinksFor(value);
            }

            return new Dictionary<string, HalLink>();
        }

        private static object ReadHalResourceFromJson(JObject o)
        {
            var result = new HalResource();

            foreach (var field in o)
            {
                if (field.Key == "_links")
                {
                    result.Links = field.Value.ToObject<Dictionary<string, HalLink>>();
                }
                else if (field.Key == "_embedded")
                {
                    result.Embedded = ReadEmbeddedFromJson(field.Value);
                }
                else
                {
                    result.Properties.Add(field.Key, field.Value);
                }
            }

            return result;
        }

        private static Dictionary<string, HalResource> ReadEmbeddedFromJson(JToken token)
        {
            var result = new Dictionary<string, HalResource>();
            var temp = token.ToObject<Dictionary<string, JToken>>();

            foreach (var field in temp)
            {
                var value = field.Value.Type == JTokenType.Array ? field.Value.ToObject<HalListResource>() : field.Value.ToObject<HalResource>();
                result.Add(field.Key, value);
            }

            return result;
        }
    }
}