using System;
using System.IO;
using System.Net;

namespace Restafari.Tests.Mocks
{
    public class TestRequest : IRequest
    {
        private TestStream stream = new TestStream();

        public string ContentType { get; set; }
        public string Accept { get; set; }
        public string Method { get; set; }
        public ICredentials Credentials { get; set; }
        public WebHeaderCollection Headers { get; set; }

        public string Url { get; set; }
        public Stream Stream { get { return stream; } }
        public string Buffer { get { return stream.TextContent; } }

        public IAsyncResult BeginGetResponse(AsyncCallback fetchStreamCallback, object state)
        {
            return new TestAsyncResult();
        }

        public IResponse EndGetResponse(IAsyncResult ar)
        {
            return TestRequestFactory.Response;
        }

        public IAsyncResult BeginGetRequestStream(AsyncCallback fetchStreamCallback, object state)
        {
            return new TestAsyncResult();
        }

        public Stream EndGetRequestStream(IAsyncResult ar)
        {
            return stream;
        }

        public void CleanUp()
        {
            stream.CleanUp();
        }
    }
}