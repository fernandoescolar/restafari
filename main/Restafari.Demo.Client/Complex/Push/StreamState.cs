using System.IO;
using System.Text;

namespace Restafari.Demo.Client.Complex.Push
{
    internal class StreamState
    {
        public Stream Stream { get; set; }
        public byte[] Buffer { get; set; }
        public StringBuilder StringBuilder { get; set; }

        public StreamState()
        {
            this.StringBuilder = new StringBuilder();
        }
    }
}