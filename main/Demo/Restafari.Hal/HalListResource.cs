using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Restafari.Hal
{
    [JsonConverter(typeof(HalListResourceConverter))]
    public class HalListResource : HalResource, IEnumerable<HalResource>
    {
        private List<HalResource> resources;
 
        public HalListResource(IEnumerable e)
        {
            this.resources = e.Cast<object>().Select(i => i is HalResource ? (HalResource)i : CreateFrom(i)).ToList();
        }

        public IEnumerator<HalResource> GetEnumerator()
        {
            return this.resources.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.resources.GetEnumerator();
        }

        public override object GetElement(Type type)
        {
            if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                var innerType = type.IsArray ? type.GetElementType() : type.IsGenericType ? type.GenericTypeArguments[0] : typeof(object);
                var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(new[] { innerType }));
                var buffer = this.resources.Select(h => h.GetElement(innerType));

                foreach(var item in buffer)
                {
                    list.Add(item);
                }

                if (type.IsArray)
                {
                    var method = typeof(Enumerable).GetMethod("ToArray").MakeGenericMethod(innerType);
                    return method.Invoke(list, null);
                }

                return list;
            }

            throw new InvalidCastException("The type is not an enumerable object");
        }
    }
}