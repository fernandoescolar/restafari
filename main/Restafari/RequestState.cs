using System;
using System.IO;
using System.Threading;

namespace Restafari
{
    public class RequestState : IDisposable
    {
        public IRequest Request { get; set; }
        public IResponse Response { get; set; }
        public Stream ResponseStream { get; set; }
        public AsyncCallback Callback { get; set; }
        internal RequestSettings Settings { get; set; }

        public readonly ManualResetEvent Waiter = new ManualResetEvent(false);

        public void Dispose()
        {
            this.Waiter.Dispose();
        }
    }
}
