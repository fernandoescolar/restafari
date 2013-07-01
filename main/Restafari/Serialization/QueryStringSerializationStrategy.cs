using System.Linq;

namespace Restafari.Serialization
{
    internal class QueryStringSerializationStrategy : ISerializationStrategy
    {
        public bool CanSerialize(Method method, ContentType type, Parameters parameters)
        {
            return (Method.Get == method || Method.Delete == method) && parameters != null && parameters.Count > 0; ;
        }

        public string Serialize(Parameters parameters)
        {
            return string.Join("&", parameters.ToList().Select(kp => kp.Key + "=" + parameters.GetSerialized(kp.Key)));
        }
    }
}
