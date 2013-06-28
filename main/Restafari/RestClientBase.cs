using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Restafari
{
    /// <summary>
    /// The REST client base, to create custom REST clients.
    /// </summary>
    public abstract partial class RestClientBase
    {
        private readonly bool useCredentials;

        private readonly string user;

        private readonly string password;

        private readonly IRequestFactory requestFactory;

        protected RestClientBase() : this(new RequestFactory())
        {
        }

        protected RestClientBase(IRequestFactory requestFactory)
        {
            this.useCredentials = false;
            this.requestFactory = requestFactory;
        }

        protected RestClientBase(string user, string password, IRequestFactory requestFactory)
        {
            this.useCredentials = true;
            this.user = user;
            this.password = password;
            this.requestFactory = requestFactory;
        }

        private IRequest CreateRequest(Method method, string url, Parameters parameters, out byte[] byteArray)
        {
            byteArray = null;

            var parameterString = SerializeParameters(method, parameters);
            var parsedUrl = ParseUrl(method, url, parameterString);
            var request = this.CreateHttpWebRequest(method, parsedUrl);

            if (method == Method.Post || method == Method.Put)
            {
                if (!string.IsNullOrEmpty(parameterString))
                {
                    byteArray = Encoding.UTF8.GetBytes(parameterString);
                }
            }
            
            return request;
        }

        private IRequest CreateHttpWebRequest(Method method, string parsedUrl)
        {
            var request = this.requestFactory.Create(parsedUrl);
            request.ContentType = "application/json; charset=UTF-8";
            request.Accept = "application/json";
            request.Method = method.ToString().ToUpper();

            //if (method == Method.Post || method == Method.Put)
            //{
            //    request.ContentType = "application/x-www-form-urlencoded";
            //}
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

        /// <summary>
        /// Serializes the parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The serialized parameters.</returns>
        private static string SerializeParameters(Method method, Parameters parameters)
        {
            if (Method.Get == method || Method.Delete == method)
            {
                return string.Join("&", parameters.ToList().Select(kp => kp.Key + "=" + parameters.GetSerialized(kp.Key)));
            }

            if (parameters.Count == 1)
            {
                return JsonConvert.SerializeObject(parameters[parameters.Keys.First()]);
            }

            return JsonConvert.SerializeObject(parameters);
        }

        /// <summary>
        /// Deserializes the specified text.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="text">The text.</param>
        /// <returns>The deserialized object.</returns>
        private static T Deserialize<T>(string text)
        {
            return JsonConvert.DeserializeObject<T>(text);
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
