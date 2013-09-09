namespace Restafari.Tests.Mocks
{
    public class TestRequestDecorator : IRequestDecorator
    {
        public const string ContentTypeText = "application/hal-json; charset=UTF-8";
        public const string AcceptText = "application/hal-json;application/json";

        public bool Visited { get; set; }

        public void Decorate(IRequest request)
        {
            request.ContentType = ContentTypeText;
            request.Accept = AcceptText;
            this.Visited = true;
        }
    }
}
