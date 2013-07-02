using System;
using System.Runtime.Serialization;

namespace Restafari.Tests.Mocks
{
    [DataContract]
    public class DummyDataTransferObject
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "age")]
        public int Age { get; set; }

        [DataMember(Name = "active")]
        public bool Active { get; set; }
    }
}
