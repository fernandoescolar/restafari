using System.IO;

namespace Restafari.Tests.Mocks
{
    public class TestResponse : IResponse
    {
        private TestStream stream = new TestStream();

        public Stream Stream { get { return stream; } }
        public string Buffer { get { return stream.TextContent; } }

        public Stream GetResponseStream()
        {
            return stream;
        }

        public void CleanUp()
        {
            this.stream.CleanUp();
        }
    }
}