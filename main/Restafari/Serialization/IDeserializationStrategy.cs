namespace Restafari.Serialization
{
    internal interface IDeserializationStrategy
    {
        T Deserialize<T>(string payload);
    }
}