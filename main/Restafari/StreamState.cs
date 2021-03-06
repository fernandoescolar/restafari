using System;
using System.IO;
using System.Text;

namespace Restafari
{
    internal class StreamState
    {
        public Stream Stream { get; set; }
        public byte[] Buffer { get; set; }
        public StringBuilder StringBuilder { get; set; }
        public AsyncCallback Callback { get; set; }

        public StreamState()
        {
            this.StringBuilder = new StringBuilder();
        }
    }
}