using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Restafari
{
    public static class HttpWebRequestExtensions
    {
        public static Task<Stream> GetRequestStreamAsync(this HttpWebRequest request)
        {
            var taskComplete = new TaskCompletionSource<Stream>();
            request.BeginGetRequestStream(ar =>
            {
                var requestStream = request.EndGetRequestStream(ar);
                taskComplete.TrySetResult(requestStream);
            }, request);
            return taskComplete.Task;
        }

        public static Task<WebResponse> GetResponseAsync(this HttpWebRequest request)
        {
            var taskComplete = new TaskCompletionSource<WebResponse>();
            request.BeginGetResponse(ar =>
            {
                var response = request.EndGetResponse(ar);
                taskComplete.TrySetResult(response);
            }, request);
            return taskComplete.Task;
        }
    }
}
