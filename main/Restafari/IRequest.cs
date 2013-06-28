using System;
using System.IO;
using System.Net;

namespace Restafari
{
    public interface IRequest
    {
        string ContentType { get; set; }
        string Accept { get; set; }
        string Method { get; set; }
        ICredentials Credentials { get; set; }

        IAsyncResult BeginGetResponse(AsyncCallback fetchStreamCallback, object state);
        IResponse EndGetResponse(IAsyncResult ar);
        IAsyncResult BeginGetRequestStream(AsyncCallback fetchStreamCallback, object state);
        Stream EndGetRequestStream(IAsyncResult ar);
    }
}