using System.Text;

namespace Restafari.Serialization
{
    internal class EmptySerializationStrategy : ISerializationStrategy
    {
        public bool CanSerialize(Method method, string contentType, Parameters parameters)
        {
            return parameters == null || parameters.Count == 0;
        }

        public byte[] Serialize(Parameters parameters, Encoding encoding)
        {
            return new byte[0];
        }
    }
}
