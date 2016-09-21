using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restafari.Serialization
{
    internal class SerializationContext : List<ISerializationStrategy>, ISerializationContext
    {
        private static readonly ISerializationStrategy[] DefaultSerializationStrategies =  {
                                                                                               new EmptySerializationStrategy(),
                                                                                               new QueryStringSerializationStrategy(),
                                                                                               new JsonSerializationStrategy(),
                                                                                               new XmlSerializationStrategy()
                                                                                           };

        public SerializationContext()
            : base(DefaultSerializationStrategies)
        {

        }

        public byte[] Serialize(Method method, string contentType, Parameters parameters, Encoding encoding)
        {
            var strategy = this.GetStrategy(method, contentType, parameters);
            return strategy.Serialize(parameters, encoding);
        }

        private ISerializationStrategy GetStrategy(Method method, string contentType, Parameters parameters)
        {
            var result = this.FirstOrDefault(s => s.CanSerialize(method, contentType, parameters));
            if (result == null)
            {
                return this[0];
            }

            return result;
        }
    }
}
