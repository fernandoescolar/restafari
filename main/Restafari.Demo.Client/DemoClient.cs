using System.Collections.Generic;

namespace Restafari.Demo.Client
{
    public class DemoClient : RestClientBase
    {
        private const string ContactResource = "http://{0}/api/contacts";
        private string host;

        public DemoClient(string host) : base()
        {
            this.host = host;
            //this.ContentType = ContentType.Xml;
        }

        public IList<Contact> GetContacts()
        {
            var url = string.Format(ContactResource, host);
            return this.GetList<Contact>(url);
        }

        public Contact GetContactById(int id)
        {
            var url = string.Format(ContactResource + "/{1}", host, id);
            return this.Get<Contact>(url);
        }

        public void AddContact(Contact contact)
        {
            var url = string.Format(ContactResource, host);
            this.Post(url, contact);
        }

        public void UpdateContact(Contact contact)
        {
            var url = string.Format(ContactResource + "/{1}", host, contact.ContactId);
            this.Put(url, contact);
        }

        public void DeleteContact(int id)
        {
            var url = string.Format(ContactResource + "/{1}", host, id);
            this.Delete(url);
        }
    }
}
