using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using Restafari.MessageExchange;
using Restafari.Serialization;

namespace Restafari
{
    /// <summary>
    /// The REST client base, to create custom REST clients.
    /// </summary>
    public abstract partial class RestClientBase
    {
        private static readonly Lazy<Dictionary<ContentType, IRequestDecorator>> RequestDecorators = new Lazy<Dictionary<ContentType, IRequestDecorator>>(() => new Dictionary<ContentType, IRequestDecorator> { { ContentType.Json, new JsonRequestDecorator() }, { ContentType.Xml, new XmlRequestDecorator() } });

        private static readonly Lazy<SerializationContext> SerializationContext = new Lazy<SerializationContext>(() => new SerializationContext());

        private static readonly Lazy<DeserializationContext> DeserializationContext = new Lazy<DeserializationContext>(() => new DeserializationContext());

        private readonly bool useCredentials;

        private readonly string user;

        private readonly string password;

        private readonly IRequestFactory requestFactory;

        public ContentType ContentType { get; set; }

        protected RestClientBase() : this(new RequestFactory())
        {
        }

        protected RestClientBase(IRequestFactory requestFactory)
        {
            this.useCredentials = false;
            this.requestFactory = requestFactory;
            this.ContentType = ContentType.Json;
        }

        protected RestClientBase(string user, string password) : this(user, password, new RequestFactory())
        {
        }

        protected RestClientBase(string user, string password, IRequestFactory requestFactory)
        {
            this.useCredentials = true;
            this.user = user;
            this.password = password;
            this.requestFactory = requestFactory;
            this.ContentType = ContentType.Json;
        }

        protected virtual void OnRequestCreated(IRequest request)
        {
        }

        private IRequest CreateRequest(Method method, string url, Parameters parameters, out byte[] byteArray)
        {
            byteArray = null;

            var parameterString = SerializationContext.Value.Serialize(method, this.ContentType, parameters);
            var parsedUrl = ParseUrl(method, url, parameterString);
            var request = this.CreateHttpRequest(method, parsedUrl);

            if (method == Method.Post || method == Method.Put)
            {
                if (!string.IsNullOrEmpty(parameterString))
                {
                    byteArray = Encoding.UTF8.GetBytes(parameterString);
                }
            }
            
            this.OnRequestCreated(request);
            return request;
        }

        private IRequest CreateHttpRequest(Method method, string parsedUrl)
        {
            var request = this.requestFactory.Create(parsedUrl);
            request.Method = method.ToString().ToUpper();

            RequestDecorators.Value[this.ContentType].Decorate(request);

            if (this.useCredentials)
            {
                request.Credentials = new NetworkCredential(this.user, this.password);
            }

            return request;
        }

        private static string ParseUrl(Method method, string url, string parameterString)
        {
            return ((method == Method.Post || method == Method.Put) || string.IsNullOrEmpty(parameterString))
                ? url
                : url + "?" + parameterString;
        }

        [DebuggerStepThrough]
        private static Exception CreateRestException(WebException ex)
        {
            if (ex.Response != null)
            {
                var stream = ex.Response.GetResponseStream();
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var message = reader.ReadToEnd();
                        throw new RestClientException(message, ex);
                    }
                }
            }

            throw new RestClientException("Connection error", ex);
        }
    }
}
