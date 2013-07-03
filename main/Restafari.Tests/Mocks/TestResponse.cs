using System.IO;
using System.Text;

namespace Restafari.Tests.Mocks
{
    public class TestResponse : IResponse
    {
        private TestStream stream = new TestStream();

        public Stream Stream { get { return stream; } }
        public string Buffer { get { return stream.TextContent; } }

        public void WriteInStream(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
            stream.Position = 0;
        }

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