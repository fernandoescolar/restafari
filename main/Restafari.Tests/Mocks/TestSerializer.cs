namespace Restafari.Tests.Mocks
{
    class TestSerializer : ISerializationStrategy
    {
        public bool Visited { get; set; }
        public bool CanVisited { get; set; }

        public bool CanSerialize(Method method, ContentType type, Parameters parameters)
        {
            this.CanVisited = true;
            return true;
        }

        public string Serialize(Parameters parameters)
        {
            this.Visited = true;
            return string.Empty;
        }
    }
}
