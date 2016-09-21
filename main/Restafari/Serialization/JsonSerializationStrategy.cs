using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace Restafari.Serialization
{
    internal class JsonSerializationStrategy : ISerializationStrategy
    {
        public bool CanSerialize(Method method, string contentType, Parameters parameters)
        {
            return ContentTypes.Json == contentType && (Method.Post == method || Method.Put == method || Method.Patch == method) && parameters != null && parameters.Count > 0;
        }

        public byte[] Serialize(Parameters parameters, Encoding encoding)
        {
            if (parameters.Count == 1)
            {
                return encoding.GetBytes(JsonConvert.SerializeObject(parameters[parameters.Keys.First()]));
            }

            return encoding.GetBytes(JsonConvert.SerializeObject(parameters));
        }
    }
}
