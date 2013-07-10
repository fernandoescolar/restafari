using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restafari.Demo.Client.AsyncAwait
{
    public class DemoClient : RestClientBase
    {
        private const string ContactResource = "http://{0}/api/contacts";
        private readonly string host;

        public DemoClient(string host)
            : base()
        {
            this.host = host;
            //this.ContentType = ContentType.Xml;
        }

        public async Task<IList<Contact>> GetContactsAsync()
        {
            var url = string.Format(ContactResource, this.host);
            return await this.GetListAsync<Contact>(url);
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            return await this.GetAsync<Contact>(url);
        }

        public async Task AddContactAsync(Contact contact)
        {
            var url = string.Format(ContactResource, this.host);
            await this.PostAsync(url, contact);
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, contact.ContactId);
            await this.PutAsync(url, contact);
        }

        public async Task DeleteContactAsync(int id)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            await this.DeleteAsync(url);
        }
    }
}
