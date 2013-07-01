using System.IO;
using System.Net;

namespace Restafari.MessageExchange
{
    internal class Response : IResponse
    {
        internal readonly HttpWebResponse internalResponse;

        internal Response(HttpWebResponse internalResponse)
        {
            this.internalResponse = internalResponse;
        }

        public Stream GetResponseStream()
        {
            return this.internalResponse.GetResponseStream();
        }
    }
}