using System;

namespace Restafari.Demo.Client
{
    public class PushClient : RestClientBase
    {
        private const string PushResource = "http://{0}/api/push";
        private readonly string host;

        public PushClient(string host) : base()
        {
            this.host = host;
        }

        public void Subscribe()
        {
            var url = string.Format(PushResource, this.host);
            base.BeginGet(url, this.GetNotfitacionsCallback);
        }

        private void GetNotfitacionsCallback(IAsyncResult ar)
        {
            var requestState = (RequestState)ar.AsyncState;
            var buffer = new byte[1024];
            var streamState = new StreamState
            {
                Stream = requestState.ResponseStream,
                Buffer = buffer,
            };

            this.ReadLine(streamState);
        }

        private void ReadLine(StreamState state)
        {
            state.Stream.BeginRead(state.Buffer, 0, state.Buffer.Length, OnStreamReaded, state);
        }

        private void OnStreamReaded(IAsyncResult ar)
        {
            var state = (StreamState)ar.AsyncState;
            var read = state.Stream.EndRead(ar);
            var tempString = System.Text.Encoding.UTF8.GetString(state.Buffer, 0, read);
            state.StringBuilder.Append(tempString);
            var buffered = state.StringBuilder.ToString();

            int position;
            while ((position = buffered.IndexOf('\n')) > 0)
            {
                var line = buffered.Substring(0, position);
                buffered = buffered.Remove(0, position + 1);
                Console.WriteLine(line);
            }

            this.ReadLine(state);
        }
    }
}
