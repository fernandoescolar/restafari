using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Timers;
using System.Web.Http;

namespace Restafari.Demo.Service.Controllers
{
    public class PushController : ApiController
    {
        private static readonly SynchronizedCollection<StreamWriter> Listeners = new SynchronizedCollection<StreamWriter>();
        private static readonly Timer Timer = new Timer(1000);

        static PushController()
        {
            Timer.Elapsed += (s, a) => Send(DateTime.Now.ToLongTimeString());
        }

        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            Timer.Start();
            var response = request.CreateResponse();
            response.Content = new PushStreamContent(OnStreamAvailable, "text/event-stream");
            return response;
        }

        private void OnStreamAvailable(Stream stream, HttpContent content, TransportContext context)
        {
            stream.Flush();
            Listeners.Add(new StreamWriter(stream));
        }

        public static void Send(string text)
        {
            var toDeleteList = new List<StreamWriter>();
            foreach (var w in Listeners)
            {
                try
                {
                    w.WriteLine("data:{ text : \"" + text + "\" }");
                    w.Flush();
                }
                catch
                {
                    toDeleteList.Add(w);
                }
            }

            foreach (var w in toDeleteList)
            {
                Listeners.Remove(w);
            }
        }
    }
}
