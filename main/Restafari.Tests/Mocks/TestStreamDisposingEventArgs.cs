using System;

namespace Restafari.Tests.Mocks
{
    public class TestStreamDisposingEventArgs : EventArgs
    {
        public string Content { get; set; }

        public TestStreamDisposingEventArgs(string content)
        {
            this.Content = content;
        }
    }
}