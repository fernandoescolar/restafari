using System.IO;
using System.Text;

namespace Restafari.Tests.Mocks
{
    public class TestStream : Stream
    {
        private MemoryStream buffer = new MemoryStream();

        public string TextContent
        {
            get
            {
                return Encoding.UTF8.GetString(this.buffer.GetBuffer(), 0, (int)this.buffer.Length);
            }
            set
            {
                this.buffer.Close();
                this.buffer = new MemoryStream(Encoding.UTF8.GetBytes(value));
            }
        }

        public override void Flush()
        {
            buffer.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return buffer.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            buffer.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.buffer.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.buffer.Write(buffer, offset, count);
        }

        public override bool CanRead
        {
            get { return this.buffer.CanRead; }
        }

        public override bool CanSeek
        {
            get { return this.buffer.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return this.buffer.CanWrite; }
        }

        public override long Length
        {
            get { return this.buffer.Length; }
        }

        public override long Position
        {
            get { return this.buffer.Position; }
            set { this.buffer.Position = value; }
        }

        public void CleanUp()
        {
            if (this.buffer != null)
            {
                buffer.Close();
            }

            this.buffer = new MemoryStream();
        }
    }
}
