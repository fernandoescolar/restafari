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
        /// <param name="parameter">The parameter.</param>
        protected void Post<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            this.Post(url, parameters);
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
        /// Posts the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        protected void Post(RequestSettings settings)
        {
            settings.Method = Method.Post;
            this.Fetch(settings);
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
        /// <param name="parameter">The parameter.</param>
        protected void Get<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            this.Get(url, parameters);
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
        /// Gets the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        protected void Get(RequestSettings settings)
        {
            settings.Method = Method.Get;
            this.Fetch(settings);
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
        /// <param name="parameter">The parameter.</param>
        protected void Put<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            this.Put(url, parameters);
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
        /// Puts the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        protected void Put(RequestSettings settings)
        {
            settings.Method = Method.Put;
            this.Fetch(settings);
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
        /// <param name="parameter">The parameter.</param>
        protected void Delete<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            this.Delete(url, parameters);
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
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        protected void Delete(RequestSettings settings)
        {
            settings.Method = Method.Delete;
            this.Fetch(settings);
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
        /// <param name="parameter">The parameter.</param>
        /// <returns>The response stream.</returns>
        protected Stream PostStream<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            return this.PostStream(url, parameters);
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
        /// Posts the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <returns>The response stream.</returns>
        protected Stream PostStream(RequestSettings settings)
        {
            settings.Method = Method.Post;
            return this.FetchStream(settings);
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
        /// <param name="parameter">The parameter.</param>
        /// <returns>The response stream.</returns>
        protected Stream GetStream<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            return this.GetStream(url, parameters);
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
        /// Gets the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <returns>The response stream.</returns>
        protected Stream GetStream(RequestSettings settings)
        {
            settings.Method = Method.Get;
            return this.FetchStream(settings);
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
        /// <param name="parameter">The parameter.</param>
        /// <returns>The response stream.</returns>
        protected Stream PutStream<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            return this.PutStream(url, parameters);
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
        /// Puts the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <returns>The response stream.</returns>
        protected Stream PutStream(RequestSettings settings)
        {
            settings.Method = Method.Put;
            return this.FetchStream(settings);
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
        /// <param name="parameter">The parameter.</param>
        /// <returns>The response stream.</returns>
        protected Stream DeleteStream<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            return this.DeleteStream(url, parameters);
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
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <returns>The response stream.</returns>
        protected Stream DeleteStream(RequestSettings settings)
        {
            settings.Method = Method.Delete;
            return this.FetchStream(settings);
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
        /// <typeparam name="S">The type to send.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> PostList<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.PostList<T>(url, parameters);
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
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> PostList<T>(RequestSettings settings)
        {
            settings.Method = Method.Post;
            return this.FetchList<T>(settings);
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
        /// <typeparam name="S">The type to send.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> GetList<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.GetList<T>(url, parameters);
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
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> GetList<T>(RequestSettings settings)
        {
            settings.Method = Method.Get;
            return this.FetchList<T>(settings);
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
        /// <typeparam name="S">The type to send.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> PutList<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.PutList<T>(url, parameters);
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
        /// Puts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> PutList<T>(RequestSettings settings)
        {
            settings.Method = Method.Put;
            return this.FetchList<T>(settings);
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
        /// <typeparam name="S">The type to send.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> DeleteList<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.DeleteList<T>(url, parameters);
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
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected IList<T> DeleteList<T>(RequestSettings settings)
        {
            settings.Method = Method.Delete;
            return this.FetchList<T>(settings);
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
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Post<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.Post<T>(url, parameters);
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
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Post<T>(RequestSettings settings)
        {
            settings.Method = Method.Post;
            return this.Fetch<T>(settings);
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
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Get<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.Get<T>(url, parameters);
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
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Get<T>(RequestSettings settings)
        {
            settings.Method = Method.Get;
            return this.Fetch<T>(settings);
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
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Put<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.Put<T>(url, parameters);
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
        /// Puts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Put<T>(RequestSettings settings)
        {
            settings.Method = Method.Put;
            return this.Fetch<T>(settings);
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
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Delete<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.Delete<T>(url, parameters);
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
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected T Delete<T>(RequestSettings settings)
        {
            settings.Method = Method.Delete;
            return this.Fetch<T>(settings);
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
            return this.FetchList<T>(this.CreateRequestSettings(method, url, parameters));
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
            return this.Fetch<T>(this.CreateRequestSettings(method, url, parameters));
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
            return this.FetchStream(this.CreateRequestSettings(method, url, parameters));
        }
       
        /// <summary>
        /// Fetches the specified method.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        private void Fetch(Method method, string url, Parameters parameters)
        {
            this.Fetch(this.CreateRequestSettings(method, url, parameters));
        }

        /// <summary>
        /// Fetches the specified method.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        private IList<T> FetchList<T>(RequestSettings settings)
        {

            string responseString;

            using (var reader = new StreamReader(this.FetchStream(settings)))
            {
                responseString = reader.ReadToEnd();
            }

            var temporary = DeserializeParameters<T[]>(settings, responseString);
            return new List<T>(temporary);
        }

        /// <summary>
        /// Fetches the specified method.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        private T Fetch<T>(RequestSettings settings)
        {

            string responseString;

            using (var reader = new StreamReader(this.FetchStream(settings)))
            {
                responseString = reader.ReadToEnd();
            }

            var temporary = DeserializeParameters<T>(settings, responseString);
            return temporary;
        }

        /// <summary>
        /// Fetches the stream.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <returns>The response stream.</returns>
        private Stream FetchStream(RequestSettings settings)
        {
            try
            {
                var request = this.CreateAndPrepareRequest(settings);
                var response = request.GetResponse();
                this.OnResponseReceived(response, settings);
                return response.GetResponseStream();
            }
            catch (WebException ex)
            {
                throw CreateRestException(ex);
            }
        }

        /// <summary>
        /// Fetches the specified method.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        private void Fetch(RequestSettings settings)
        {
            try
            {
                var request = this.CreateAndPrepareRequest(settings);
                var response = request.GetResponse();
                this.OnResponseReceived(response, settings);
            }
            catch (WebException ex)
            {
                throw CreateRestException(ex);
            }
        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <returns>The http web request.</returns>
        private IRequest CreateAndPrepareRequest(RequestSettings settings)
        {
            byte[] byteArray;
            var request = this.CreateAndPrepareRequest(settings, out byteArray);

            if (byteArray != null)
            {
                this.WriteBody(request, byteArray);
            }

            return request;
        }

        private void WriteBody(IRequest request, byte[] byteArray)
        {
            using(var writer = request.GetRequestStream())
            {
                writer.Write(byteArray, 0, byteArray.Length);
            }
        }
    }
}
