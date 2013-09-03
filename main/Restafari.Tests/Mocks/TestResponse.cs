using System;
using System.IO;
using System.Net;
using System.Text;

namespace Restafari.Tests.Mocks
{
    public class TestResponse : IResponse
    {
        private TestStream stream = new TestStream();
        private bool faulted = false;

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
            this.stream.Write(bytes, 0, bytes.Length);
            this.stream.Flush();
            this.stream.Position = 0;
        }

        public Stream GetResponseStream()
        {
            if (this.faulted)
            {
                throw new WebException("Without connection", WebExceptionStatus.ConnectionClosed);
            }

            return this.stream;
        }

        public void CreateException()
        {
            this.faulted = true;
        }

        public void CleanUp()
        {
            this.faulted = false;
            this.stream.CleanUp();
        }
    }
}