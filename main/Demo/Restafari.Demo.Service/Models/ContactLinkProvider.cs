using System.Collections.Generic;
using Restafari.Hal;

namespace Restafari.Demo.Service.Models
{
    public class ContactLinkProvider : ILinkProvider<Contact>
    {
        public Dictionary<string, HalLink> GetLinksFor(Contact value)
        {
            return new Dictionary<string, HalLink>
                       {
                           {"_self", new HalLink{ Rel = "", Href = "api/contact/" + value.ContactId}},
                           {"meetings", new HalLink{ Rel = "", Href = "api/contact/" + value.ContactId + "/meetings"}}
                       };
        }

        public Dictionary<string, HalLink> GetLinksFor(object value)
        {
            return this.GetLinksFor(value as Contact);
        }
    }
}