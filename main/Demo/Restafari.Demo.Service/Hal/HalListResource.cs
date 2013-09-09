using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Restafari.Demo.Service.Hal
{
    [JsonConverter(typeof(HalListResourceConverter))]
    public class HalListResource : HalResource, IEnumerable<HalResource>
    {
        private List<HalResource> resources;
 
        public HalListResource(IEnumerable e)
        {
            this.resources = e.Cast<object>().Select(HalResource.CreateFrom).ToList();
        }

        public IEnumerator<HalResource> GetEnumerator()
        {
            return this.resources.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.resources.GetEnumerator();
        }
    }
}