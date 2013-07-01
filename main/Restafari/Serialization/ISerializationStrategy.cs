namespace Restafari.Serialization
{
    internal interface ISerializationStrategy
    {
        bool CanSerialize(Method method, ContentType type, Parameters parameters);
        string Serialize(Parameters parameters);
    }
}