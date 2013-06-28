namespace Restafari.Tests.Mocks
{
    public class TestRestClient : RestClientBase
    {
        public TestRestClient() : base(TestRequestFactory.Instance)
        {
            
        }
    }
}
