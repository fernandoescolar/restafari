using System;
using System.Collections.Generic;
using System.Net;

namespace Restafari.Demo.Client.AsyncPattern
{
    public class DemoClient : RestClientBase
    {
        private const string ContactResource = "http://{0}/api/contacts";
        private readonly string host;

        public DemoClient(string host) : base()
        {
            this.host = host;
        }

        public IAsyncResult BeginGetContacts(AsyncCallback callback = null)
        {
            var url = string.Format(ContactResource, this.host);
            return this.BeginGet(url, callback);
        }

        public IList<Contact> EndGetContacts(IAsyncResult state)
        {
            return this.EndRequestList<Contact>(state);
        }

        public IAsyncResult BeginGetContactById(int id, AsyncCallback callback = null)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            return this.BeginGet(url, callback);
        }

        public Contact EndGetContactById(IAsyncResult state)
        {
            return this.EndRequest<Contact>(state);
        }

        public IAsyncResult BeginAddContact(Contact contact, AsyncCallback callback = null)
        {
            var url = string.Format(ContactResource, this.host);
            return this.BeginPost(url, contact, callback);
        }

        public void EndAddContact(IAsyncResult state)
        {
            this.EndRequest(state);
        }

        public IAsyncResult BeginUpdateContact(Contact contact, AsyncCallback callback = null)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, contact.ContactId);
            return this.BeginPut(url, contact, callback);
        }

        public void EndUpdateContact(IAsyncResult state)
        {
            this.EndRequest(state);
        }

        public IAsyncResult BeginDeleteContact(int id, AsyncCallback callback = null)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            return this.BeginDelete(url, callback);
        }

        public void EndDeleteContact(IAsyncResult state)
        {
            this.EndRequest(state);
        }
    }
}
