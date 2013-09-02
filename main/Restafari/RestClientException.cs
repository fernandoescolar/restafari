using System;

namespace Restafari
{
    public class RestClientException : Exception
    {
        public IResponse Response { get; private set; }

        public RestClientException(string message, IResponse response) : base(message)
        {
            this.Response = response;
        }

        public RestClientException(string message, IResponse response, Exception innerExcepion)
            : base(message, innerExcepion)
        {
            this.Response = response;
        }
    }
}