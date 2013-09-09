using System.Runtime.Serialization;

namespace Restafari.Demo.Service.Hal
{
    [DataContract]
    public class HalLink 
    {
        [DataMember(Name = "rel")]
        public string Rel { get; set; }
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}