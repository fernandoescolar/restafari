namespace Restafari.MessageExchange
{
    internal class XmlRequestDecorator : IRequestDecorator
    {
        private const string XmlContentType = "application/xml; charset=UTF-8";
        private const string XmlAccept = "application/xml";

        public void Decorate(IRequest request)
        {
            request.ContentType = XmlContentType;
            request.Accept = XmlAccept;
        }
    }
}