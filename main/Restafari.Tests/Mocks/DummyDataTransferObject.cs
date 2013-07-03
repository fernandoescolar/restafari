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

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.Id.GetHashCode();
                hashCode = (hashCode*397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ this.Age;
                hashCode = (hashCode*397) ^ this.Active.GetHashCode();
                return hashCode;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DummyDataTransferObject) obj);
        }

        protected bool Equals(DummyDataTransferObject other)
        {
            return this.Id.Equals(other.Id) && string.Equals(this.Name, other.Name) && this.Age == other.Age && this.Active.Equals(other.Active);
        }
    }
}
