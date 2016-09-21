using System.Text;

namespace Restafari.Tests.Mocks
{
    class TestSerializer : ISerializationStrategy
    {
        public bool Visited { get; set; }
        public bool CanVisited { get; set; }

        public bool CanSerialize(Method method, string contentType, Parameters parameters)
        {
            this.CanVisited = true;
            return true;
        }

        public byte[] Serialize(Parameters parameters, Encoding encoding)
        {
            this.Visited = true;
            return new byte[0];
        }
    }
}
