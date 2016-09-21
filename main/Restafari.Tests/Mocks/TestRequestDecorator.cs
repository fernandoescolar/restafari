namespace Restafari.Tests.Mocks
{
    public class TestRequestDecorator : IRequestDecorator
    {
        public const string ContentTypeText = "application/hal-json; charset=utf-8";
        public const string AcceptText = "application/hal-json;application/json";

        public bool Visited { get; set; }

        public bool CanDecorate(RequestSettings settings)
        {
            return true;
        }

        public void Decorate(IRequest request, RequestSettings settings)
        {
            request.ContentType = ContentTypeText;
            request.Accept = AcceptText;
            this.Visited = true;
        }
    }
}
