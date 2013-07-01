namespace Restafari.MessageExchange
{
    internal class RequestFactory : IRequestFactory
    {
        public IRequest Create(string url)
        {
            return new Request(url);
        }
    }
}