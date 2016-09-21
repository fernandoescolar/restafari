using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restafari.Serialization
{
    internal class DeserializationContext : List<IDeserializationStrategy>, IDeserializationContext
    {
        private static readonly IDeserializationStrategy[] DefaultDeserilizationStrategies = { 
            new JsonDeserializationStrategy(),
            new XmlDeserializationStrategy() 
        };

        public DeserializationContext()
            : base(DefaultDeserilizationStrategies)
        {

        }

        public T Deserialize<T>(string contentType, byte[] payload, Encoding encoding)
        {
            return this.GetStrategy(contentType).Deserialize<T>(payload, encoding);
        }

        private IDeserializationStrategy GetStrategy(string contentType)
        {
            var result = this.FirstOrDefault(s => s.CanSerialize(contentType));
            if (result == null)
            {
                return this[0];
            }

            return result;
        }
    }
}
