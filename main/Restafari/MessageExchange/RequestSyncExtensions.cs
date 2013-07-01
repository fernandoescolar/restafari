using System.IO;
using System.Net;

namespace Restafari.MessageExchange
{
    public static class RequestSyncExtensions
    {
        public static IResponse GetResponse(this IRequest request)
        {
            if (request is Request)
            {
                return new Response((HttpWebResponse)((Request)request).internalRequest.GetResponse());
            }

            var state = request.BeginGetResponse(null, null);
            return  request.EndGetResponse(state);
        }

        public static Stream GetRequestStream(this IRequest request)
        {
            if (request is Request)
            {
                return  ((Request) request).internalRequest.GetRequestStream();
            }

            var state = request.BeginGetRequestStream(null, null);
            return request.EndGetRequestStream(state);
        }
    }
}
