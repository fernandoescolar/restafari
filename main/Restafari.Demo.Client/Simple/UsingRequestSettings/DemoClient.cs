using System;
using System.Collections.Generic;
using System.Net;

namespace Restafari.Demo.Client.Simple.UsingRequestSettings
{
    public class DemoClient : RestClientBase
    {
        private const string ContactResource = "http://{0}/api/contact";
        private readonly string host;

        public DemoClient(string host)
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

        public IList<Contact> GetContacts()
        {
            var url = string.Format(ContactResource, this.host);
            return this.GetList<Contact>(new RequestSettings
                                             {
                                                 Url = url,
                                                 ContentType = ContentTypes.Json,
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

        public Contact GetContactById(int id)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            return this.Get<Contact>(new RequestSettings
                                         {
                                             Url = url,
                                             RequestDecorator = new CustomRequestDecorator()
                                         });
        }

        #endregion

        #region Custom Serialization

        public Contact GetContact(int id)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            return this.Get<Contact>(new RequestSettings
            {
                Url = url,
                DeserializationStrategy = new CustomDeserializer()
            });
        }

        public void AddContact(Contact contact)
        {
            var url = string.Format(ContactResource, this.host);
            this.Post(new RequestSettings
            {
                Url = url,
                Parameters = new Parameters(contact),
                SerializationStrategy = new CustomSerializer()
            });
        }

        #endregion

        #region Custom Http Auth

        public void UpdateContact(Contact contact)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, contact.ContactId);
            this.Put(new RequestSettings
            {
                Url = url,
                Parameters = new Parameters(contact),
                User = "myUser",
                Password = "myPassword"
            });
        }

        #endregion

        #region Changing Request Content Type

        public void DeleteContact(int id)
        {
            var url = string.Format(ContactResource + "/{1}", this.host, id);
            this.Delete(new RequestSettings
            {
                Url = url,
                ContentType = ContentTypes.Xml
            });
        }

        #endregion
    }
}
