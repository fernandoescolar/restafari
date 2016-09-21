using System.Text;

namespace Restafari
{
    public interface IDeserializationStrategy
    {
        bool CanSerialize(string contentType);
        T Deserialize<T>(byte[] payload, Encoding encoding);
    }
}