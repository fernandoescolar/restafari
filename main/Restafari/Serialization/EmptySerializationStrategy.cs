namespace Restafari.Serialization
{
    internal class EmptySerializationStrategy : ISerializationStrategy
    {
        public bool CanSerialize(Method method, ContentType type, Parameters parameters)
        {
            return parameters == null || parameters.Count == 0;
        }

        public string Serialize(Parameters parameters)
        {
            return string.Empty;
        }
    }
}
