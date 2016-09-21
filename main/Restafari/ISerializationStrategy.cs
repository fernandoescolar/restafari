using System.Text;

namespace Restafari
{
    public interface ISerializationStrategy
    {
        bool CanSerialize(Method method, string contentType, Parameters parameters);
        byte[] Serialize(Parameters parameters, Encoding encoding);
    }
}