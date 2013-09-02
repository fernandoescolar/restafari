namespace Restafari
{
    public interface IDeserializationStrategy
    {
        T Deserialize<T>(string payload);
    }
}