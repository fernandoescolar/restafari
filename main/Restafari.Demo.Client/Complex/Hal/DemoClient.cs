using System;
using System.Collections.Generic;

namespace Restafari.Demo.Client.Complex.Hal
{
    public class DemoClient : RestClientBase
    {
        private const string ContactResource = "http://{0}/api/contact";
        private readonly string host;

        public DemoClient(string host)
            : base()
        {
            this.host = host;
        }

        public IList<Contact> GetContacts()
        {
            var url = string.Format(ContactResource, this.host);
            return this.GetList<Contact>(new RequestSettings
                                             {
                                                 Url = url,
                                                 RequestDecorator = new HalRequestDecorator(),
                                                 ResponseReceived = this.OnResponseReceivedCheckHalHeader
                                             });
        }

        public Contact GetContactById(int id)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            return this.Get<Contact>(new RequestSettings
                                         {
                                             Url = url,
                                             RequestDecorator = new HalRequestDecorator(),
                                             ResponseReceived = this.OnResponseReceivedCheckHalHeader
                                         });
        }

        public Contact GetContact(int id)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            return this.Get<Contact>(new RequestSettings
            {
                Url = url,
                RequestDecorator = new HalRequestDecorator()
            });
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

        private void OnResponseReceivedCheckHalHeader(object sender, IResponse response)
        {
            if (!response.ContentType.Contains("application/hal-json"))
            {
                throw new InvalidOperationException();
            }
        }

    }
}
