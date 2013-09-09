using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Restafari.Demo.Client.Simple.UsingRequestSettings
{
    public class DemoClientAsync : RestClientBase
    {
        private const string ContactResource = "http://{0}/api/contact";
        private readonly string host;

        public DemoClientAsync(string host)
            : base()
        {
            this.host = host;

            // Global content type (Default: Json)
            //this.ContentType = ContentType.Xml;
        }

        #region Custom Global Handlers

        protected override void OnRequestCreated(IRequest request)
        {
            base.OnRequestCreated(request);
        }

        protected override void OnResponseReceived(IResponse response)
        {
            base.OnResponseReceived(response);
        }

        #endregion

        #region Custom Request Handlers

        public Task<IList<Contact>> GetContactsAsync()
        {
            var url = string.Format(ContactResource, this.host);
            return this.GetListAsync<Contact>(new RequestSettings
                                             {
                                                 Url = url,
                                                 ContentType = ContentType.Json,
                                                 RequestCreated = OnRequestCreatedAddRestafariHeader,
                                                 ResponseReceived = OnResponseReceivedCheckRestafariHeader
                                             });
        }

        private void OnRequestCreatedAddRestafariHeader(object o, IRequest request)
        {
            request.Headers[HttpRequestHeader.UserAgent] = "Restafari 0.9.0.0 Rest Client";
        }

        private void OnResponseReceivedCheckRestafariHeader(object o, IResponse response)
        {
            if (response.ContentType != "application/hal-json")
            {
                throw new InvalidOperationException();
            }
        }

        #endregion

        #region Custom Request Decorator

        public Task<Contact> GetContactByIdAsync(int id)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            return this.GetAsync<Contact>(new RequestSettings
                                         {
                                             Url = url,
                                             RequestDecorator = new CustomRequestDecorator()
                                         });
        }

        #endregion

        #region Custom Serialization

        public Task<Contact> GetContactAsync(int id)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            return this.GetAsync<Contact>(new RequestSettings
            {
                Url = url,
                DeserializationStrategy = new CustomDeserializer()
            });
        }

        public Task AddContactAsync(Contact contact)
        {
            var url = string.Format(ContactResource, this.host);
            return this.PostAsync(new RequestSettings
            {
                Url = url,
                Parameters = new Parameters(contact),
                SerializationStrategy = new CustomSerializer()
            });
        }

        #endregion

        #region Custom Http Auth

        public Task UpdateContactAsync(Contact contact)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, contact.ContactId);
            return this.PutAsync(new RequestSettings
            {
                Url = url,
                Parameters = new Parameters(contact),
                User = "myUser",
                Password = "myPassword"
            });
        }

        #endregion

        #region Changing Request Content Type

        public Task DeleteContactAsync(int id)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            return this.DeleteAsync(new RequestSettings
            {
                Url = url,
                ContentType = ContentType.Xml
            });
        }

        #endregion
    }
}
