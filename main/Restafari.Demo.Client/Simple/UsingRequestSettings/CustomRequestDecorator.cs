using System;
using System.Net;

namespace Restafari.Demo.Client.Simple.UsingRequestSettings
{
    public class CustomRequestDecorator : IRequestDecorator
    {
        private const string HalContentType = "application/hal-json; charset=UTF-8";
        private const string HalAccept = "application/hal-json;application/json";

        public void Decorate(IRequest request, RequestSettings settings)
        {
            if (request.Method.ToUpper() != "GET")
            {
                request.ContentType = HalContentType;
            }

            request.Accept = HalAccept;
            request.Headers[HttpRequestHeader.UserAgent] = "Restafari 0.9.0.0 Rest Client";
        }

        public bool CanDecorate(RequestSettings settings)
        {
            return true;
        }
    }
}
