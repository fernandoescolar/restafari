using Restafari.MessageExchange;
using Restafari.Serialization;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace Restafari
{
    /// <summary>
    /// The REST client base, to create custom REST clients.
    /// </summary>
    public abstract partial class RestClientBase
    {
        private static readonly Lazy<IDecorationContext> DecorationContext = new Lazy<IDecorationContext>(() => new DecorationContext());

        private static readonly Lazy<ISerializationContext> SerializationContext = new Lazy<ISerializationContext>(() => new SerializationContext());

        private static readonly Lazy<IDeserializationContext> DeserializationContext = new Lazy<IDeserializationContext>(() => new DeserializationContext());

        private readonly string user;

        private readonly string password;

        private readonly IRequestFactory requestFactory;

        public string ContentType { get; set; }

        public Encoding Encoding { get; set; }

        protected RestClientBase() : this(new RequestFactory())
        {
        }

        protected RestClientBase(IRequestFactory requestFactory)
        {
            this.requestFactory = requestFactory;
            this.ContentType = ContentTypes.Json;
            this.Encoding = Encoding.UTF8;
        }

        protected RestClientBase(string user, string password) : this(user, password, new RequestFactory())
        {
        }

        protected RestClientBase(string user, string password, IRequestFactory requestFactory) : this(requestFactory)
        {
            this.user = user;
            this.password = password;
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
            settings.ResponseContentType = response.ContentType;
            this.OnResponseReceived(response);

            var handler = settings.ResponseReceived;
            if (handler != null)
            {
                handler(this, response);
            }
        }

        private IRequest CreateAndPrepareRequest(RequestSettings settings, out byte[] byteArray)
        {
            this.CheckRequestSettings(settings);

            byteArray = SerializeParameters(settings);
            
            var parsedUrl = ParseUrl(settings.Method, settings.Url, byteArray, settings.Encoding);
            var request = this.CreateRequest(parsedUrl, settings);
            
            this.OnRequestCreated(request, settings);
            return request;
        }

        private void CheckRequestSettings(RequestSettings settings)
        {
            if (settings.Encoding == null) settings.Encoding = this.Encoding;
            if (settings.ContentType == null) settings.ContentType = this.ContentType;
        }

        private IRequest CreateRequest(string parsedUrl, RequestSettings settings)
        {
            var request = this.requestFactory.Create(parsedUrl);
            request.Method = settings.Method.ToString().ToUpper();

            DecorateRequest(settings, request);

            if (settings.UseCredentials)
            {
                request.Credentials = new NetworkCredential(settings.User, settings.Password);
            }

            return request;
        }

        private static void DecorateRequest(RequestSettings settings, IRequest request)
        {
            if (settings.RequestDecorator != null)
            {
                settings.RequestDecorator.Decorate(request, settings);
            }
            else
            {
                DecorationContext.Value.Decorate(request, settings);
            }
        }

        private RequestSettings CreateRequestSettings(Method method, string url, Parameters parameters)
        {
            return new RequestSettings
                       {
                           Method = method,
                           Url = url,
                           Parameters = parameters,
                           ContentType = this.ContentType,
                           Encoding = this.Encoding,
                           User = this.user,
                           Password = this.password,
                           RequestDecorator = null,
                           SerializationStrategy = null,
                           DeserializationStrategy = null,
                           RequestCreated = null,
                           ResponseReceived = null
                       };
        }

        private static byte[] SerializeParameters(RequestSettings settings)
        {
            if (settings.SerializationStrategy != null)
            {
                if (settings.SerializationStrategy.CanSerialize(settings.Method, settings.ContentType, settings.Parameters))
                {
                    return settings.SerializationStrategy.Serialize(settings.Parameters, settings.Encoding);
                }

                throw new SerializationException("Can not serialize the parameters with the specified serializer.");
            }

            return SerializationContext.Value.Serialize(settings.Method, settings.ContentType, settings.Parameters, settings.Encoding);
        }

        private static T DeserializeParameters<T>(RequestSettings settings, byte[] payload)
        {
            if (settings.DeserializationStrategy != null)
            {
                return settings.DeserializationStrategy.Deserialize<T>(payload, settings.Encoding);
            }

            var contentType = string.IsNullOrEmpty(settings.ResponseContentType) ? settings.ContentType : settings.ResponseContentType;
            return DeserializationContext.Value.Deserialize<T>(contentType, payload, settings.Encoding);
        }

        private static string ParseUrl(Method method, string url, byte[] parameterBytes, Encoding encoding)
        {
            if (method == Method.Post || method == Method.Put || method == Method.Patch) return url;

            var parameterString = (parameterBytes != null && parameterBytes.Length > 0) ? encoding.GetString(parameterBytes, 0, parameterBytes.Length) : string.Empty;
            return string.IsNullOrEmpty(parameterString) ? url : string.Format("{0}?{1}", url, parameterString);
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
