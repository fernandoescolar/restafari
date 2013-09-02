using System;
using System.IO;
using System.Net;

namespace Restafari
{
    public interface IResponse
    {
        string ContentType { get; }
        long ContentLength { get; }
        CookieCollection Cookies { get; }
        WebHeaderCollection Headers { get; }
        string Method { get; }
        Uri ResponseUri { get; }
        HttpStatusCode StatusCode { get; }
        string StatusDescription { get; }
        Stream GetResponseStream();
    }
}