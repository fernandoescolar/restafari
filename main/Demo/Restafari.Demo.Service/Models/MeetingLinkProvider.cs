using System.Collections.Generic;
using Restafari.Hal;

namespace Restafari.Demo.Service.Models
{
    public class MeetingLinkProvider : ILinkProvider<Meeting>
    {
        public Dictionary<string, HalLink> GetLinksFor(Meeting value)
        {
            return new Dictionary<string, HalLink>
                       {
                           {"_self", new HalLink{ Rel = "", Href = "api/meeting/" + value.MeetingId}},
                       };
        }

        public Dictionary<string, HalLink> GetLinksFor(object value)
        {
            return this.GetLinksFor(value as Meeting);
        }
    }
}