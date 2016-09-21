using System;

namespace Restafari.Demo.Client.Complex.Hal
{
    public class HalRequestDecorator : IRequestDecorator
    {
        private const string HalContentType = "application/hal-json; charset=UTF-8";
        private const string HalAccept = "application/hal-json";

        public void Decorate(IRequest request, RequestSettings settings)
        {
            if (request.Method.ToUpper() != "GET")
            {
                request.ContentType = HalContentType;
            }

            request.Accept = HalAccept;
        }

        public bool CanDecorate(RequestSettings settings)
        {
            return true;
        }
    }
}
