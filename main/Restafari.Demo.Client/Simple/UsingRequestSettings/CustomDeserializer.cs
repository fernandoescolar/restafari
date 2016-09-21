using System;
using System.Collections.Generic;
using System.Text;

namespace Restafari.Demo.Client.Simple.UsingRequestSettings
{
    public class CustomDeserializer : IDeserializationStrategy
    {
        public bool CanSerialize(string contentType)
        {
            return true;
        }

        public T Deserialize<T>(byte[] payload, Encoding encoding)
        {
            return this.Deserialize<T>(encoding.GetString(payload), encoding);
        }

        public T Deserialize<T>(string payload, Encoding encoding)
        {
            var dic = new Dictionary<string, string>();
            var values = payload.Split(',');

            foreach (var value in values)
            {
                var aux = value.Split(':');

                if (aux.Length == 2)
                {
                    dic.Add(aux[0], aux[1]);
                }
            }

            // try to transform 'dic' into 'T'
            //return dic as T;
            return default(T);
        }
    }
}
