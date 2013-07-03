using System;
using System.IO;
using System.Net;

namespace Restafari.MessageExchange
{
    internal class Request : IRequest
    {
        internal readonly HttpWebRequest internalRequest;

        internal Request(string url)
        {
            this.internalRequest = (HttpWebRequest) WebRequest.Create(url);
        }

        public string ContentType
        {
            get { return this.internalRequest.ContentType; }
            set { this.internalRequest.ContentType = value; }
        }

        public string Accept
        {
            get { return this.internalRequest.Accept; }
            set { this.internalRequest.Accept = value; }
        }

        public string Method
        {
            get { return this.internalRequest.Method; }
            set { this.internalRequest.Method = value; }
        }

        public ICredentials Credentials
        {
            get { return this.internalRequest.Credentials; }
            set { this.internalRequest.Credentials = value; }
        }

        public WebHeaderCollection Headers
        {
            get { return this.internalRequest.Headers; }
            set { this.internalRequest.Headers = value; }
        }

        public IAsyncResult BeginGetRequestStream(AsyncCallback fetchStreamCallback, object state)
        {
            return this.internalRequest.BeginGetRequestStream(fetchStreamCallback, state);
        }

        public Stream EndGetRequestStream(IAsyncResult ar)
        {
            return this.internalRequest.EndGetRequestStream(ar);
        }

        public IAsyncResult BeginGetResponse(AsyncCallback fetchStreamCallback, object state)
        {
            return this.internalRequest.BeginGetResponse(fetchStreamCallback, state);
        }

        public IResponse EndGetResponse(IAsyncResult ar)
        {
            return new Response((HttpWebResponse)this.internalRequest.EndGetResponse(ar));
        }
    }
}