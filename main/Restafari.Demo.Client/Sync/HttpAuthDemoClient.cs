using System.Collections.Generic;
using System.Net;

namespace Restafari.Demo.Client.Sync
{
    public class HttpAuthDemoClient : RestClientBase
    {
        private const string ContactResource = "http://{0}/api/contacts";
        private readonly string host;

        public HttpAuthDemoClient(string host, string user, string password) : base(user, password)
        {
            this.host = host;
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
    }
}
