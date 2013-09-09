using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restafari.Demo.Client.Simple.AsyncAwait
{
    public class DemoClient : RestClientBase
    {
        private const string ContactResource = "http://{0}/api/contact";
        private readonly string host;

        public DemoClient(string host)
            : base()
        {
            this.host = host;
            //this.ContentType = ContentType.Xml;
        }

        public Task<IList<Contact>> GetContactsAsync()
        {
            var url = string.Format(ContactResource, this.host);
            return this.GetListAsync<Contact>(url);
        }

        public Task<Contact> GetContactByIdAsync(int id)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            return this.GetAsync<Contact>(url);
        }

        public Task AddContactAsync(Contact contact)
        {
            var url = string.Format(ContactResource, this.host);
            return this.PostAsync(url, contact);
        }

        public Task UpdateContactAsync(Contact contact)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, contact.ContactId);
            return this.PutAsync(url, contact);
        }

        public Task DeleteContactAsync(int id)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            return this.DeleteAsync(url);
        }
    }
}
