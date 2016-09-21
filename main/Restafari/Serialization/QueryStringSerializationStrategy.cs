using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Restafari.Serialization
{
    internal class QueryStringSerializationStrategy : ISerializationStrategy
    {
        public bool CanSerialize(Method method, string contentType, Parameters parameters)
        {
            return (Method.Get == method || Method.Delete == method || contentType == ContentTypes.Form) && parameters != null && parameters.Count > 0;
        }

        public byte[] Serialize(Parameters parameters, Encoding encoding)
        {
            return encoding.GetBytes(string.Join("&", parameters.ToList().Select(kp => kp.Key + "=" + parameters.GetSerialized(kp.Key))));
        }
    }
}
