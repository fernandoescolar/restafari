namespace Restafari.Serialization
{
    internal class DeserializationContext
    {
        private static readonly IDeserializationStrategy JsonDeserilizationStrategy = new JsonDeserializationStrategy();

        public T Deserialize<T>(ContentType contentType, string payload)
        {
            return JsonDeserilizationStrategy.Deserialize<T>(payload);
        }
    }
}
