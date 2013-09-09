using System.Collections.Generic;

namespace Restafari.Demo.Client.Simple.Sync
{
    public class CustomAuthDemoClient : RestClientBase
    {
        private const string AuthKey = "5s48e4fasA4sfadEE5E";
        private const string ContactResource = "http://{0}/api/contact";
        private readonly string host;

        public CustomAuthDemoClient(string host) : base()
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

        protected override void OnRequestCreated(IRequest request)
        {
            request.Headers["Authorization"] = this.GetAuthToken(ContactResource, request.Method, AuthKey);
        }

        protected override void OnResponseReceived(IResponse response)
        {
            var session = response.Headers["session-id"];
        }

        private string GetAuthToken(string resource, string method, string key)
        {
            // make your custom call to get the auth token
            return string.Empty;
        }
    }
}
