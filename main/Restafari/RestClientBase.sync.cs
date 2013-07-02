using System.Collections.Generic;
using System.IO;
using System.Net;
using Restafari.MessageExchange;

namespace Restafari
{
    partial class RestClientBase
    {
        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        protected void Post(string url)
        {
            this.Post(url, new Parameters());
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        protected void Post(string url, Parameters parameters)
        {
            this.Fetch(Method.Post, url, parameters);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        protected void Get(string url)
        {
            this.Get(url, new Parameters());
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        protected void Get(string url, Parameters parameters)
        {
            this.Fetch(Method.Get, url, parameters);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        protected void Put(string url)
        {
            this.Put(url, new Parameters());
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        protected void Put(string url, Parameters parameters)
        {
            this.Fetch(Method.Put, url, parameters);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        protected void Delete(string url)
        {
            this.Delete(url, new Parameters());
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        protected void Delete(string url, Parameters parameters)
        {
            this.Fetch(Method.Delete, url, parameters);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The response stream.</returns>
        protected Stream PostStream(string url)
        {
            return this.PostStream(url, new Parameters());
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response stream.</returns>
        protected Stream PostStream(string url, Parameters parameters)
        {
            return this.FetchStream(Method.Post, url, parameters);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The response stream.</returns>
        protected Stream GetStream(string url)
        {
            return this.GetStream(url, new Parameters());
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response stream.</returns>
        protected Stream GetStream(string url, Parameters parameters)
        {
            return this.FetchStream(Method.Get, url, parameters);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The response stream.</returns>
        protected Stream PutStream(string url)
        {
            return this.PutStream(url, new Parameters());
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response stream.</returns>
        protected Stream PutStream(string url, Parameters parameters)
        {
            return this.FetchStream(Method.Put, url, parameters);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The response stream.</returns>
        protected Stream DeleteStream(string url)
        {
            return this.DeleteStream(url, new Parameters());
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response stream.</returns>
        protected Stream DeleteStream(string url, Parameters parameters)
        {
            return this.FetchStream(Method.Delete, url, parameters);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> PostList<T>(string url)
        {
            return this.PostList<T>(url, new Parameters());
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> PostList<T>(string url, Parameters parameters)
        {
            return this.FetchList<T>(Method.Post, url, parameters);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> GetList<T>(string url)
        {
            return this.GetList<T>(url, new Parameters());
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> GetList<T>(string url, Parameters parameters)
        {
            return this.FetchList<T>(Method.Get, url, parameters);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> PutList<T>(string url)
        {
            return this.PutList<T>(url, new Parameters());
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> PutList<T>(string url, Parameters parameters)
        {
            return this.FetchList<T>(Method.Put, url, parameters);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> DeleteList<T>(string url)
        {
            return this.DeleteList<T>(url, new Parameters());
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> DeleteList<T>(string url, Parameters parameters)
        {
            return this.FetchList<T>(Method.Delete, url, parameters);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Post<T>(string url)
        {
            return this.Post<T>(url, new Parameters());
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Post<T>(string url, Parameters parameters)
        {
            return this.Fetch<T>(Method.Post, url, parameters);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Get<T>(string url)
        {
            return this.Get<T>(url, new Parameters());
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Get<T>(string url, Parameters parameters)
        {
            return this.Fetch<T>(Method.Get, url, parameters);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Put<T>(string url)
        {
            return this.Put<T>(url, new Parameters());
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Put<T>(string url, Parameters parameters)
        {
            return this.Fetch<T>(Method.Put, url, parameters);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Delete<T>(string url)
        {
            return this.Delete<T>(url, new Parameters());
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Delete<T>(string url, Parameters parameters)
        {
            return this.Fetch<T>(Method.Delete, url, parameters);
        }

        /// <summary>
        /// Fetches the specified method.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        private IList<T> FetchList<T>(Method method, string url, Parameters parameters)
        {

            string responseString;

            using (var reader = new StreamReader(this.FetchStream(method, url, parameters)))
            {
                responseString = reader.ReadToEnd();
            }

            var temporary = DeserializationContext.Value.Deserialize<T[]>(this.ContentType, responseString);
            return new List<T>(temporary);
        }

        /// <summary>
        /// Fetches the specified method.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        private T Fetch<T>(Method method, string url, Parameters parameters)
        {

            string responseString;

            using (var reader = new StreamReader(this.FetchStream(method, url, parameters)))
            {
                responseString = reader.ReadToEnd();
            }

            var temporary = DeserializationContext.Value.Deserialize<T>(this.ContentType, responseString);
            return temporary;
        }

        /// <summary>
        /// Fetches the stream.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response stream.</returns>
        private Stream FetchStream(Method method, string url, Parameters parameters)
        {
            var request = this.CreateRequestSync(method, url, parameters);
            var response = request.GetResponse();
            return response.GetResponseStream();
        }

        /// <summary>
        /// Fetches the specified method.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        private void Fetch(Method method, string url, Parameters parameters)
        {
            try
            {
                var request = this.CreateRequestSync(method, url, parameters);
                var response = request.GetResponse();
            }
            catch (WebException ex)
            {
                throw CreateRestException(ex);
            }
        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The http web request.</returns>
        private IRequest CreateRequestSync(Method method, string url, Parameters parameters)
        {
            byte[] byteArray;
            var request = this.CreateRequest(method, url, parameters, out byteArray);

            if (byteArray != null)
            {
                WriteBodySync(request, byteArray);
            }

            return request;
        }

        private void WriteBodySync(IRequest request, byte[] byteArray)
        {
            using(var writer = request.GetRequestStream())
            {
                writer.Write(byteArray, 0, byteArray.Length);
            }
        }
    }
}
