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
            var parameters = new Parameters { { string.Empty, parameter } };
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
            var parameters = new Parameters { { string.Empty, parameter } };
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
            var parameters = new Parameters { { string.Empty, parameter } };
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
            var parameters = new Parameters { { string.Empty, parameter } };
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
            var parameters = new Parameters { { string.Empty, parameter } };
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
            var parameters = new Parameters { { string.Empty, parameter } };
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
            var parameters = new Parameters { { string.Empty, parameter } };
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
            var parameters = new Parameters { { string.Empty, parameter } };
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
            var parameters = new Parameters { { string.Empty, parameter } };
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
            var parameters = new Parameters { { string.Empty, parameter } };
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
            var parameters = new Parameters { { string.Empty, parameter } };
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
            var parameters = new Parameters { { string.Empty, parameter } };
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
        /// Fetches the specified method.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of deserialized objects.</returns>
        private async Task<IList<T>> FetchListAsync<T>(Method method, string url, Parameters parameters)
        {

            string responseString;

            using (var reader = new StreamReader(await this.FetchStreamAsync(method, url, parameters)))
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
        private async Task<T> FetchAsync<T>(Method method, string url, Parameters parameters)
        {

            string responseString;

            using (var reader = new StreamReader(await this.FetchStreamAsync(method, url, parameters)))
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
        private async Task<Stream> FetchStreamAsync(Method method, string url, Parameters parameters)
        {
            try
            {
                var request = await this.CreateRequestAsync(method, url, parameters);
                var response = await request.GetResponseAsync();
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
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        private async Task FetchAsync(Method method, string url, Parameters parameters)
        {
            try
            {
                var request = await this.CreateRequestAsync(method, url, parameters);
                var response = await request.GetResponseAsync();
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
        private async Task<IRequest> CreateRequestAsync(Method method, string url, Parameters parameters)
        {
            byte[] byteArray;
            var request = this.CreateRequest(method, url, parameters, out byteArray);

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
