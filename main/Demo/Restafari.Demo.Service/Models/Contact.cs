using System.Globalization;
using System.Runtime.Serialization;

namespace Restafari.Demo.Service.Models
{
    [DataContract(Name = "contact", Namespace = "")]
    public class Contact
    {
        [DataMember(Name = "id")]
        public int ContactId { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "address")]
        public string Address { get; set; }
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "state")]
        public string State { get; set; }
        [DataMember(Name = "zip")]
        public string Zip { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "twitter")]
        public string Twitter { get; set; }
        [DataMember(Name = "self")]
        public string Self
        {
            get
            {
                return string.Format(CultureInfo.CurrentCulture,
                    "api/contacts/{0}", this.ContactId);
            }
            set { }
        }
    }
}