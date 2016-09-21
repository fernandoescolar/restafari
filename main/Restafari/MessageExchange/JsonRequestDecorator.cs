namespace Restafari.MessageExchange
{
    internal class JsonRequestDecorator : IRequestDecorator
    {
        public bool CanDecorate(RequestSettings settings)
        {
            return settings.ContentType == ContentTypes.Json;
        }

        public void Decorate(IRequest request, RequestSettings settings)
        {
            if (request.Method.ToUpper() != "GET")
            {
                request.ContentType = ContentTypes.Json;
            }

            request.Accept = ContentTypes.Json;
        }
    }
}