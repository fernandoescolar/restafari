using System.Linq;
using Newtonsoft.Json;

namespace Restafari.Serialization
{
    internal class JsonSerializationStrategy : ISerializationStrategy
    {
        public bool CanSerialize(Method method, ContentType type, Parameters parameters)
        {
            return ContentType.Json == type && (Method.Post == method || Method.Put == method) && parameters != null && parameters.Count > 0;
        }

        public string Serialize(Parameters parameters)
        {
            if (parameters.Count == 1)
            {
                return JsonConvert.SerializeObject(parameters[parameters.Keys.First()]);
            }

            return JsonConvert.SerializeObject(parameters);
        }
    }
}
