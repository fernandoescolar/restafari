using System;
using System.Collections.Generic;
using System.Text;

namespace Restafari
{
    interface ISerializationContext : IList<ISerializationStrategy>
    {
        byte[] Serialize(Method method, string contentType, Parameters parameters, Encoding encoding);
    }
}
