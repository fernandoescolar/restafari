namespace Restafari.MessageExchange
{
    internal class JsonRequestDecorator : IRequestDecorator
    {
        private const string JsonContentType = "application/json; charset=UTF-8";
        private const string JsonAccept = "application/json";

        public void Decorate(IRequest request)
        {
            if (request.Method.ToUpper() != "GET")
            {
                request.ContentType = JsonContentType;
            }

            request.Accept = JsonAccept;
        }
    }
}