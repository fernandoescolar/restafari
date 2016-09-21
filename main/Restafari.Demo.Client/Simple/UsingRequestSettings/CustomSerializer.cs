using System;
using System.Text;

namespace Restafari.Demo.Client.Simple.UsingRequestSettings
{
    class CustomSerializer : ISerializationStrategy
    {
        public bool CanSerialize(Method method, string contentType, Parameters parameters)
        {
            return true;
        }

        public byte[] Serialize(Parameters parameters, Encoding encoding)
        {
            var sb = new StringBuilder(@"{
""_links"": {
    ""self"": {
      ""href"": ""http://www.programandonet.com""
    },
  },");
            foreach (var parameter in parameters)
            {
                sb.AppendLine(string.Format(@"""{0}"": {1},", parameter.Key, parameter.Value));
            }
            sb.AppendLine(@"""date"": ""2013-09-03""");
            sb.AppendLine(@"}");

            return encoding.GetBytes(sb.ToString());
        }
    }
}
