using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Restafari.MessageExchange;

namespace Restafari
{
    partial class RestClientBase
    {
        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        protected Task PostAsync(string url)
        {
            return this.PostAsync(url, new Parameters());
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        protected Task PostAsync<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            return this.PostAsync(url, parameters);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        protected Task PostAsync(string url, Parameters parameters)
        {
            return this.FetchAsync(Method.Post, url, parameters);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        protected Task PostAsync(RequestSettings settings)
        {
            settings.Method = Method.Post;
            return this.FetchAsync(settings);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        protected Task GetAsync(string url)
        {
            return this.GetAsync(url, new Parameters());
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        protected Task GetAsync<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            return this.GetAsync(url, parameters);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        protected Task GetAsync(string url, Parameters parameters)
        {
            return this.FetchAsync(Method.Get, url, parameters);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        protected Task GetAsync(RequestSettings settings)
        {
            settings.Method = Method.Get;
            return this.FetchAsync(settings);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        protected Task PutAsync(string url)
        {
            return this.PutAsync(url, new Parameters());
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        protected Task PutAsync<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            return this.PutAsync(url, parameters);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        protected Task PutAsync(string url, Parameters parameters)
        {
            return this.FetchAsync(Method.Put, url, parameters);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        protected Task PutAsync(RequestSettings settings)
        {
            settings.Method = Method.Put;
            return this.FetchAsync(settings);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        protected Task DeleteAsync(string url)
        {
            return this.DeleteAsync(url, new Parameters());
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        protected Task DeleteAsync<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            return this.DeleteAsync(url, parameters);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        protected Task DeleteAsync(string url, Parameters parameters)
        {
            return this.FetchAsync(Method.Delete, url, parameters);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        protected Task DeleteAsync(RequestSettings settings)
        {
            settings.Method = Method.Delete;
            return this.FetchAsync(settings);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> PostListAsync<T>(string url)
        {
            return this.PostListAsync<T>(url, new Parameters());
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <typeparam name="S">The type of the parameter.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> PostListAsync<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.PostListAsync<T>(url, parameters);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> PostListAsync<T>(string url, Parameters parameters)
        {
            return this.FetchListAsync<T>(Method.Post, url, parameters);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> PostListAsync<T>(RequestSettings settings)
        {
            settings.Method = Method.Post;
            return this.FetchListAsync<T>(settings);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> GetListAsync<T>(string url)
        {
            return this.GetListAsync<T>(url, new Parameters());
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <typeparam name="S">The type of the parameter.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> GetListAsync<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.GetListAsync<T>(url, parameters);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> GetListAsync<T>(string url, Parameters parameters)
        {
            return this.FetchListAsync<T>(Method.Get, url, parameters);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> GetListAsync<T>(RequestSettings settings)
        {
            settings.Method = Method.Get;
            return this.FetchListAsync<T>(settings);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> PutListAsync<T>(string url)
        {
            return this.PutListAsync<T>(url, new Parameters());
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <typeparam name="S">The type of the parameter.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> PutListAsync<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.PutListAsync<T>(url, parameters);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> PutListAsync<T>(string url, Parameters parameters)
        {
            return this.FetchListAsync<T>(Method.Put, url, parameters);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> PutListAsync<T>(RequestSettings settings)
        {
            settings.Method = Method.Put;
            return this.FetchListAsync<T>(settings);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> DeleteListAsync<T>(string url)
        {
            return this.DeleteListAsync<T>(url, new Parameters());
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <typeparam name="S">The type of the parameter.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> DeleteListAsync<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.DeleteListAsync<T>(url, parameters);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> DeleteListAsync<T>(string url, Parameters parameters)
        {
            return this.FetchListAsync<T>(Method.Delete, url, parameters);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<IList<T>> DeleteListAsync<T>(RequestSettings settings)
        {
            settings.Method = Method.Delete;
            return this.FetchListAsync<T>(settings);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> PostAsync<T>(string url)
        {
            return this.PostAsync<T>(url, new Parameters());
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <typeparam name="S">The type of the parameter.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> PostAsync<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.PostAsync<T>(url, parameters);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> PostAsync<T>(string url, Parameters parameters)
        {
            return this.FetchAsync<T>(Method.Post, url, parameters);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> PostAsync<T>(RequestSettings settings)
        {
            settings.Method = Method.Post;
            return this.FetchAsync<T>(settings);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> GetAsync<T>(string url)
        {
            return this.GetAsync<T>(url, new Parameters());
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <typeparam name="S">The type of the parameter.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> GetAsync<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.GetAsync<T>(url, parameters);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> GetAsync<T>(string url, Parameters parameters)
        {
            return this.FetchAsync<T>(Method.Get, url, parameters);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> GetAsync<T>(RequestSettings settings)
        {
            settings.Method = Method.Get;
            return this.FetchAsync<T>(settings);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> PutAsync<T>(string url)
        {
            return this.PutAsync<T>(url, new Parameters());
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <typeparam name="S">The type of the parameter.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> PutAsync<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.PutAsync<T>(url, parameters);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> PutAsync<T>(string url, Parameters parameters)
        {
            return this.FetchAsync<T>(Method.Put, url, parameters);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> PutAsync<T>(RequestSettings settings)
        {
            settings.Method = Method.Put;
            return this.FetchAsync<T>(settings);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> DeleteAsync<T>(string url)
        {
            return this.DeleteAsync<T>(url, new Parameters());
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <typeparam name="S">The type of the parameter.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> DeleteAsync<T, S>(string url, S parameter)
        {
            var parameters = new Parameters(parameter);
            return this.DeleteAsync<T>(url, parameters);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> DeleteAsync<T>(string url, Parameters parameters)
        {
            return this.FetchAsync<T>(Method.Delete, url, parameters);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        protected Task<T> DeleteAsync<T>(RequestSettings settings)
        {
            settings.Method = Method.Delete;
            return this.FetchAsync<T>(settings);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> PostStreamAsync(string url)
        {
            return this.PostStreamAsync(url, new Parameters());
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> PostStreamAsync<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            return this.PostStreamAsync(url, parameters);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> PostStreamAsync(string url, Parameters parameters)
        {
            return this.FetchStreamAsync(Method.Post, url, parameters);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> PostStreamAsync(RequestSettings settings)
        {
            settings.Method = Method.Post;
            return this.FetchStreamAsync(settings);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> GetStreamAsync(string url)
        {
            return this.GetStreamAsync(url, new Parameters());
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> GetStreamAsync<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            return this.GetStreamAsync(url, parameters);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> GetStreamAsync(string url, Parameters parameters)
        {
            return this.FetchStreamAsync(Method.Get, url, parameters);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> GetStreamAsync(RequestSettings settings)
        {
            settings.Method = Method.Get;
            return this.FetchStreamAsync(settings);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> PutStreamAsync(string url)
        {
            return this.PutStreamAsync(url, new Parameters());
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> PutStreamAsync<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            return this.PutStreamAsync(url, parameters);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> PutStreamAsync(string url, Parameters parameters)
        {
            return this.FetchStreamAsync(Method.Put, url, parameters);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> PutStreamAsync(RequestSettings settings)
        {
            settings.Method = Method.Put;
            return this.FetchStreamAsync(settings);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> DeleteStreamAsync(string url)
        {
            return this.DeleteStreamAsync(url, new Parameters());
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> DeleteStreamAsync<T>(string url, T parameter)
        {
            var parameters = new Parameters(parameter);
            return this.DeleteStreamAsync(url, parameters);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> DeleteStreamAsync(string url, Parameters parameters)
        {
            return this.FetchStreamAsync(Method.Delete, url, parameters);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <returns>The response stream.</returns>
        protected Task<Stream> DeleteStreamAsync(RequestSettings settings)
        {
            settings.Method = Method.Delete;
            return this.FetchStreamAsync(settings);
        }

        /// <summary>
        /// Fetches the specified method.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        private Task<IList<T>> FetchListAsync<T>(Method method, string url, Parameters parameters)
        {
            return this.FetchListAsync<T>(this.CreateRequestSettings(method, url, parameters));
        }

        /// <summary>
        /// Fetches the specified method.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        private Task<T> FetchAsync<T>(Method method, string url, Parameters parameters)
        {
            return this.FetchAsync<T>(this.CreateRequestSettings(method, url, parameters));
        }

        /// <summary>
        /// Fetches the stream.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response stream.</returns>
        private Task<Stream> FetchStreamAsync(Method method, string url, Parameters parameters)
        {
            return this.FetchStreamAsync(this.CreateRequestSettings(method, url, parameters));
        }

        /// <summary>
        /// Fetches the specified method.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        private Task FetchAsync(Method method, string url, Parameters parameters)
        {
            return this.FetchAsync(this.CreateRequestSettings(method, url, parameters));
        }

        /// <summary>
        /// Fetches the specified method.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="settings">The request settings.</param>
        /// <returns>A list of deserialized objects.</returns>
        private async Task<IList<T>> FetchListAsync<T>(RequestSettings settings)
        {

            string responseString;

            using (var reader = new StreamReader(await this.FetchStreamAsync(settings)))
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
        private async Task<T> FetchAsync<T>(RequestSettings settings)
        {

            string responseString;

            using (var reader = new StreamReader(await this.FetchStreamAsync(settings)))
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
        private async Task<Stream> FetchStreamAsync(RequestSettings settings)
        {
            try
            {
                var request = await this.CreateRequestAsync(settings);
                var response = await request.GetResponseAsync();
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
        private async Task FetchAsync(RequestSettings settings)
        {
            try
            {
                var request = await this.CreateRequestAsync(settings);
                var response = await request.GetResponseAsync();
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
        private async Task<IRequest> CreateRequestAsync(RequestSettings settings)
        {
            byte[] byteArray;
            var request = this.CreateAndPrepareRequest(settings, out byteArray);

            if (byteArray != null)
            {
                await WriteBodyAsync(request, byteArray);
            }

            return request;
        }

        private async Task WriteBodyAsync(IRequest request, byte[] byteArray)
        {
            using (var dataStream = await request.GetRequestStreamAsync())
            {
                await dataStream.WriteAsync(byteArray, 0, byteArray.Length);
            }
        }
    }
}
