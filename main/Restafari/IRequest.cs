using System;
using System.IO;
using System.Net;

namespace Restafari
{
    public interface IRequest
    {
        string Accept { get; set; }
        string ContentType { get; set; }
        CookieContainer CookieContainer { get; set; }
        ICredentials Credentials { get; set; }
        bool HaveResponse { get; }
        WebHeaderCollection Headers { get; set; }
        string Method { get; set; }
        Uri RequestUri { get; }
        bool UseDefaultCredentials { get; set; }
        IAsyncResult BeginGetRequestStream(AsyncCallback fetchStreamCallback, object state);
        Stream EndGetRequestStream(IAsyncResult ar);
        IAsyncResult BeginGetResponse(AsyncCallback fetchStreamCallback, object state);
        IResponse EndGetResponse(IAsyncResult ar);
    }
}