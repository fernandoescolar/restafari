using System;
using System.Collections.Generic;
using System.Text;

namespace Restafari
{
    interface IDeserializationContext : IList<IDeserializationStrategy>
    {
        T Deserialize<T>(string contentType, byte[] payload, Encoding encoding);
    }
}
