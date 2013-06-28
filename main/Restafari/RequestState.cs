using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Restafari
{
    internal class RequestState : IDisposable
    {
        public IRequest Request { get; set; }
        public IResponse Response { get; set; }
        public Stream ResponseStream { get; set; }
        public AsyncCallback Callback { get; set; }
        public readonly ManualResetEvent Waiter = new ManualResetEvent(false);

        /// <summary>
        /// Realiza tareas definidas por la aplicación asociadas a la liberación o al restablecimiento de recursos no administrados.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            this.Waiter.Dispose();
        }
    }
}
