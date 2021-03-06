﻿using System.Collections.Generic;
using System.Net;

namespace Restafari.Demo.Client.Simple.Sync
{
    public class DemoClient : RestClientBase
    {
        private const string ContactResource = "http://{0}/api/contact";
        private readonly string host;

        public DemoClient(string host) : base()
        {
            this.host = host;
            //this.ContentType = ContentType.Xml;
        }

        public IList<Contact> GetContacts()
        {
            var url = string.Format(ContactResource, this.host);
            return this.GetList<Contact>(url);
        }

        public Contact GetContactById(int id)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            return this.Get<Contact>(url);
        }

        public void AddContact(Contact contact)
        {
            var url = string.Format(ContactResource, this.host);
            this.Post(url, contact);
        }

        public void UpdateContact(Contact contact)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, contact.ContactId);
            this.Put(url, contact);
        }

        public void DeleteContact(int id)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            this.Delete(url);
        }

        protected override void OnRequestCreated(IRequest request)
        {
            // here we can add authentication headers or whatever
            //request.Headers[HttpRequestHeader.UserAgent] = "Restafari 0.9.0.0 Rest Client";
            base.OnRequestCreated(request);
        }
    }
}
