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
            var parameters = new Parameters(parameter);
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
        /// Posts the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginPost(RequestSettings settings, AsyncCallback callback = null)
        {
            settings.Method = Method.Post;
            return this.BeginFetchStream(settings);
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
            var parameters = new Parameters(parameter);
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
        /// Gets the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginGet(RequestSettings settings, AsyncCallback callback = null)
        {
            settings.Method = Method.Get;
            return this.BeginFetchStream(settings);
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
            var parameters = new Parameters(parameter);
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
        /// Puts the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginPut(RequestSettings settings, AsyncCallback callback = null)
        {
            settings.Method = Method.Put;
            return this.BeginFetchStream(settings);
        }

        /// <summary>
        /// Patchs the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginPatch(string url, AsyncCallback callback = null)
        {
            return this.BeginPatch(url, new Parameters(), callback);
        }

        /// <summary>
        /// Patchs the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginPatch<T>(string url, T parameter, AsyncCallback callback = null)
        {
            var parameters = new Parameters(parameter);
            return this.BeginPatch(url, parameters, callback);
        }

        /// <summary>
        /// Patchs the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginPatch(string url, Parameters parameters, AsyncCallback callback = null)
        {
            return this.BeginFetchStream(Method.Patch, url, parameters, callback);
        }

        /// <summary>
        /// Patchs the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginPatch(RequestSettings settings, AsyncCallback callback = null)
        {
            settings.Method = Method.Patch;
            return this.BeginFetchStream(settings);
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
            var parameters = new Parameters(parameter);
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
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// The async state.
        /// </returns>
        protected IAsyncResult BeginDelete(RequestSettings settings, AsyncCallback callback = null)
        {
            settings.Method = Method.Delete;
            return this.BeginFetchStream(settings);
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
            byte[] responseBytes;
            var state = (RequestState)ar.AsyncState;

            using (var reader = new MemoryStream())
            {
                this.EndFetchStream(ar).CopyTo(reader);
                responseBytes = reader.ToArray();
            }

            var temporary = DeserializeParameters<T>(state.Settings, responseBytes);
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
            byte[] responseBytes;
            var state = (RequestState)ar.AsyncState;

            using (var reader = new MemoryStream())
            {
                this.EndFetchStream(ar).CopyTo(reader);
                responseBytes = reader.ToArray();
            }

            var temporary = DeserializeParameters<T[]>(state.Settings, responseBytes);
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
            return this.BeginFetchStream(this.CreateRequestSettings(method, url, parameters), callback);
        }

        /// <summary>
        /// Begins an async Fetch the stream.
        /// </summary>
        /// <param name="settings">The request settings.</param>
        /// <param name="callback">The callback method.</param>
        /// <returns>The async state.</returns>
        private IAsyncResult BeginFetchStream(RequestSettings settings, AsyncCallback callback = null)
        {
            var request = this.CreateAndPrepareRequest(settings);
            var state = new RequestState { Settings = settings, Request = request, Callback = callback };
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
                this.OnResponseReceived(state.Response, state.Settings);
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
