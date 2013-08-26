using System;
using System.Threading;

namespace Restafari.Tests.Mocks
{
    public class TestAsyncResult : IAsyncResult
    {
        private readonly object asyncState = new object();

        public bool IsCompleted { get { return true; } }
        public WaitHandle AsyncWaitHandle { get { return new EventWaitHandle(true, EventResetMode.AutoReset); } }
        public object AsyncState { get { return this.asyncState; } }
        public bool CompletedSynchronously { get { return true; } }
    }
}