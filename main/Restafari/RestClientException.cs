using System;

namespace Restafari
{
    public class RestClientException : Exception
    {
        public RestClientException(string message) : base(message)
        {
        }

        public RestClientException(string message, Exception innerExcepion) : base(message, innerExcepion)
        {
        }
    }
}