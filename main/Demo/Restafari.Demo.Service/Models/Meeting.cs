using System;
using System.Runtime.Serialization;

namespace Restafari.Demo.Service.Models
{
    [DataContract(Name = "meeting", Namespace = "")]
    public class Meeting
    {
        [DataMember(Name = "id")]
        public int MeetingId { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "type")]
        public MeetingType Type { get; set; }
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }
    }
}