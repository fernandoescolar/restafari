using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Restafari
{
    public static class RequestAsyncExtensions
    {
        public static async Task<IResponse> GetResponseAsync(this IRequest request)
        {
            if (request is Request)
            {
                return new Response((HttpWebResponse)await ((Request)request).internalRequest.GetResponseAsync());
            }

            return await Task<IResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null);
        }

        public static async Task<Stream> GetRequestStreamAsync(this IRequest request)
        {
            if (request is Request)
            {
                return await ((Request) request).internalRequest.GetRequestStreamAsync();
            }

            return await Task<Stream>.Factory.FromAsync(request.BeginGetRequestStream, request.EndGetRequestStream, null);
        }
    }
}
