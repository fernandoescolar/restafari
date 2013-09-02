using System;
using System.IO;
using System.Net;
using System.Text;

namespace Restafari.Tests.Mocks
{
    public class TestResponse : IResponse
    {
        private TestStream stream = new TestStream();

        public Stream Stream { get { return stream; } }
        public string Buffer { get { return stream.TextContent; } }
        public string ContentType { get; private set; }
        public long ContentLength { get; private set; }
        public CookieCollection Cookies { get; private set; }
        public WebHeaderCollection Headers { get; private set; }
        public string Method { get; private set; }
        public Uri ResponseUri { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public string StatusDescription { get; private set; }

        public void WriteInStream(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
            stream.Position = 0;
        }

        public Stream GetResponseStream()
        {
            return stream;
        }

        public void CleanUp()
        {
            this.stream.CleanUp();
        }
    }
}