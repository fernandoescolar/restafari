namespace Restafari.MessageExchange
{
    internal class XmlRequestDecorator : IRequestDecorator
    {
        public bool CanDecorate(RequestSettings settings)
        {
            return settings.ContentType == ContentTypes.Xml;
        }

        public void Decorate(IRequest request, RequestSettings settings)
        {
            if (request.Method.ToUpper() != "GET")
            {
                request.ContentType = ContentTypes.Xml;
            }

            request.Accept = ContentTypes.Xml;
        }
    }
}