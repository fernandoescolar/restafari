using System.Collections.Generic;
using System.Linq;

namespace Restafari.Serialization
{
    internal class SerializationContext
    {
        private static readonly List<ISerializationStrategy> SerializationStrategies = new List<ISerializationStrategy>
                                                                                           {
                                                                                               new EmptySerializationStrategy(),
                                                                                               new QueryStringSerializationStrategy(),
                                                                                               new JsonSerializationStrategy()
                                                                                           };
        public string Serialize(Method method, ContentType type, Parameters parameters)
        {
            var strategy = this.GetStrategy(method, type, parameters);
            return strategy.Serialize(parameters);
        }

        private ISerializationStrategy GetStrategy(Method method, ContentType type, Parameters parameters)
        {
            var result = SerializationStrategies.FirstOrDefault(s => s.CanSerialize(method, type, parameters));
            if (result == null)
            {
                return SerializationStrategies[0];
            }

            return result;
        }
    }
}
