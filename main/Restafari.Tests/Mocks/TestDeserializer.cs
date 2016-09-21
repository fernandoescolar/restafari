using System.Text;

namespace Restafari.Tests.Mocks
{
    public class TestDeserializer : IDeserializationStrategy
    {
        public bool Visited { get; set; }

        public bool CanSerialize(string contentType)
        {
            return true;
        }

        public T Deserialize<T>(byte[] payload, Encoding encoding)
        {
            this.Visited = true;
            return default(T);
        }
    }
}
