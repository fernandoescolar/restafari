using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
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

        private readonly string user;

        private readonly string password;

        private readonly IRequestFactory requestFactory;

        public ContentType ContentType { get; set; }

        protected RestClientBase() : this(new RequestFactory())
        {
        }

        protected RestClientBase(IRequestFactory requestFactory)
        {
            this.requestFactory = requestFactory;
            this.ContentType = ContentType.Json;
        }

        protected RestClientBase(string user, string password) : this(user, password, new RequestFactory())
        {
        }

        protected RestClientBase(string user, string password, IRequestFactory requestFactory)
        {
            this.user = user;
            this.password = password;
            this.requestFactory = requestFactory;
            this.ContentType = ContentType.Json;
        }

        protected virtual void OnRequestCreated(IRequest request)
        {
        }

        protected virtual void OnResponseReceived(IResponse response)
        {
        }

        private void OnRequestCreated(IRequest request, RequestSettings settings)
        {
            this.OnRequestCreated(request);

            var handler = settings.RequestCreated;
            if (handler != null)
            {
                handler(this, request);
            }
        }

        private void OnResponseReceived(IResponse response, RequestSettings settings)
        {
            this.OnResponseReceived(response);

            var handler = settings.ResponseReceived;
            if (handler != null)
            {
                handler(this, response);
            }
        }

        private IRequest CreateAndPrepareRequest(RequestSettings settings, out byte[] byteArray)
        {
            byteArray = null;

            var parameterString = SerializeParameters(settings);
            var parsedUrl = ParseUrl(settings.Method, settings.Url, parameterString);
            var request = this.CreateRequest(parsedUrl, settings);

            if (settings.Method == Method.Post || settings.Method == Method.Put)
            {
                if (!string.IsNullOrEmpty(parameterString))
                {
                    byteArray = Encoding.UTF8.GetBytes(parameterString);
                }
            }
            
            this.OnRequestCreated(request, settings);
            return request;
        }

        private IRequest CreateRequest(string parsedUrl, RequestSettings settings)
        {
            var request = this.requestFactory.Create(parsedUrl);
            request.Method = settings.Method.ToString().ToUpper();
            settings.RequestDecorator.Decorate(request);

            if (settings.UseCredentials)
            {
                request.Credentials = new NetworkCredential(settings.User, settings.Password);
            }

            return request;
        }

        private RequestSettings CreateRequestSettings(Method method, string url, Parameters parameters)
        {
            return new RequestSettings
                       {
                           Method = method,
                           Url = url,
                           Parameters = parameters,
                           ContentType = this.ContentType,
                           User = this.user,
                           Password = this.password,
                           RequestDecorator = RequestDecorators.Value[this.ContentType],
                           SerializationStrategy = null,
                           DeserializationStrategy = null,
                           RequestCreated = null,
                           ResponseReceived = null
                       };
        }

        private static string SerializeParameters(RequestSettings settings)
        {
            if (settings.SerializationStrategy != null)
            {
                if (settings.SerializationStrategy.CanSerialize(settings.Method, settings.ContentType, settings.Parameters))
                {
                    return settings.SerializationStrategy.Serialize(settings.Parameters);
                }

                throw new SerializationException("Can not serialize the parameters with the specified serializer.");
            }

            return SerializationContext.Value.Serialize(settings.Method, settings.ContentType, settings.Parameters);
        }

        private static T DeserializeParameters<T>(RequestSettings settings, string payload)
        {
            if (settings.DeserializationStrategy != null)
            {
                return settings.DeserializationStrategy.Deserialize<T>(payload);
            }

            return DeserializeParameters<T>(settings, payload);
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
                        throw new RestClientException(message, new Response((HttpWebResponse)ex.Response), ex);
                    }
                }
            }

            throw new RestClientException("Connection error", null, ex);
        }
    }
}
