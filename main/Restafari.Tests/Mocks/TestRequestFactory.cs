namespace Restafari.Tests.Mocks
{
    public class TestRequestFactory : IRequestFactory
    {
        private static readonly TestRequestFactory instance = new TestRequestFactory();
        private static readonly TestRequest request = new TestRequest();
        private static readonly TestResponse response = new TestResponse();

        public static TestRequestFactory Instance { get { return instance; } }

        public static TestRequest Request { get { return request; } }

        public static TestResponse Response { get { return response; } }

        public IRequest Create(string url)
        {
            request.Url = url;
            return request;
        }
    }
}