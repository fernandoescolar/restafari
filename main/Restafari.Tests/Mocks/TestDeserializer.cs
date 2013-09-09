namespace Restafari.Tests.Mocks
{
    public class TestDeserializer : IDeserializationStrategy
    {
        public bool Visited { get; set; }

        public T Deserialize<T>(string payload)
        {
            this.Visited = true;
            return default(T);
        }
    }
}
