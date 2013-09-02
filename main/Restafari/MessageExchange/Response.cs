using System;
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

        public string ContentType
        {
            get { return this.internalResponse.ContentType; }
        }

        public long ContentLength
        {
            get { return this.internalResponse.ContentLength; }
        }

        public CookieCollection Cookies
        {
            get { return this.internalResponse.Cookies; }
        }

        public WebHeaderCollection Headers
        {
            get { return this.internalResponse.Headers; }
        }
       
        public string Method
        {
            get { return this.internalResponse.Method; }
        }

        public Uri ResponseUri
        {
            get { return this.internalResponse.ResponseUri; }
        }

        public HttpStatusCode StatusCode
        {
            get { return this.internalResponse.StatusCode; }
        }

        public string StatusDescription
        {
            get { return this.internalResponse.StatusDescription; }
        }

        public Stream GetResponseStream()
        {
            return this.internalResponse.GetResponseStream();
        }
    }
}