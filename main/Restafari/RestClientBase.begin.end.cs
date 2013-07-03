using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Restafari
{
    partial class RestClientBase
    {
        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginPost(string url, AsyncCallback callback = null)
        {
            return this.BeginPost(url, new Parameters(), callback);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginPost<T>(string url, T parameter, AsyncCallback callback = null)
        {
            var parameters = new Parameters { { string.Empty, parameter } };
            return this.BeginPost(url, parameters, callback);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginPost(string url, Parameters parameters, AsyncCallback callback = null)
        {
            return this.BeginFetchStream(Method.Post, url, parameters, callback);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginGet(string url, AsyncCallback callback = null)
        {
            return this.BeginGet(url, new Parameters(), callback);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginGet<T>(string url, T parameter, AsyncCallback callback = null)
        {
            var parameters = new Parameters { { string.Empty, parameter } };
            return this.BeginGet(url, parameters, callback);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginGet(string url, Parameters parameters, AsyncCallback callback = null)
        {
            return this.BeginFetchStream(Method.Get, url, parameters, callback);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginPut(string url, AsyncCallback callback = null)
        {
            return this.BeginPut(url, new Parameters(), callback);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginPut<T>(string url, T parameter, AsyncCallback callback = null)
        {
            var parameters = new Parameters { { string.Empty, parameter } };
            return this.BeginPut(url, parameters, callback);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginPut(string url, Parameters parameters, AsyncCallback callback = null)
        {
            return this.BeginFetchStream(Method.Put, url, parameters, callback);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginDelete(string url, AsyncCallback callback = null)
        {
            return this.BeginDelete(url, new Parameters(), callback);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginDelete<T>(string url, T parameter, AsyncCallback callback = null)
        {
            var parameters = new Parameters { { string.Empty, parameter } };
            return this.BeginDelete(url, parameters, callback);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginDelete(string url, Parameters parameters, AsyncCallback callback = null)
        {
            return this.BeginFetchStream(Method.Delete, url, parameters, callback);
        }

        /// <summary>
        /// Ends the request.
        /// </summary>
        /// <param name="ar">The async state.</param>
        protected void EndRequest(IAsyncResult ar)
        {
            var stream = this.EndFetchStream(ar);
            stream.Dispose();
        }

        /// <summary>
        /// Ends the request for an stream.
        /// </summary>
        /// <param name="ar">The async state.</param>
        /// <returns>The response stream.</returns>
        protected Stream EndRequestStream(IAsyncResult ar)
        {
            return this.EndFetchStream(ar);
        }

        /// <summary>
        /// Ends the request for an object.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="ar">The async state.</param>
        /// <returns>The generic object.</returns>
        protected T EndRequest<T>(IAsyncResult ar)
        {
            string responseString;

            using (var reader = new StreamReader(this.EndFetchStream(ar)))
            {
                responseString = reader.ReadToEnd();
            }

            var temporary = DeserializationContext.Value.Deserialize<T>(this.ContentType, responseString);
            return temporary;
        }

        /// <summary>
        /// Ends the request for a list.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="ar">The async state.</param>
        /// <returns>The list of objects.</returns>
        protected IList<T> EndRequestList<T>(IAsyncResult ar)
        {
            string responseString;

            using (var reader = new StreamReader(this.EndFetchStream(ar)))
            {
                responseString = reader.ReadToEnd();
            }

            var temporary = DeserializationContext.Value.Deserialize<T[]>(this.ContentType, responseString);
            return new List<T>(temporary);
        }

        /// <summary>
        /// Begins an async Fetch the stream.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="callback">The callback method.</param>
        /// <returns>The async state.</returns>
        private IAsyncResult BeginFetchStream(Method method, string url, Parameters parameters, AsyncCallback callback = null)
        {
            var request = this.CreateRequestSync(method, url, parameters);
            var state = new RequestState { Request = request, Callback = callback };
            return request.BeginGetResponse(FetchStreamCallback, state);
        }

        /// <summary>
        /// The async fetch stream callback.
        /// </summary>
        /// <param name="ar">The async state.</param>
        private void FetchStreamCallback(IAsyncResult ar)
        {
            var state = (RequestState)ar.AsyncState;
            var request = state.Request;

            try
            {
                state.Response = request.EndGetResponse(ar);
                state.ResponseStream = state.Response.GetResponseStream();
            }
            catch (WebException ex)
            {
                throw CreateRestException(ex);
            }


            if (state.Callback != null)
            {
                state.Callback(ar);
            }

            state.Waiter.Set();
        }

        /// <summary>
        /// Ends the fetch stream.
        /// </summary>
        /// <param name="ar">The async state.</param>
        /// <returns>The response stream.</returns>
        private Stream EndFetchStream(IAsyncResult ar)
        {
            var state = (RequestState)ar.AsyncState;
            state.Waiter.WaitOne();
            state.Dispose();

            return state.ResponseStream;
        }
    }
}
