using System;
using Restafari.MessageExchange;
using Restafari.Serialization;

namespace Restafari
{
    public class RequestSettings
    {
        public string Url { get; set; }
        public Method Method{ get; set; }
        public Parameters Parameters { get; set; }

        public bool UseCredentials { get { return !string.IsNullOrEmpty(this.User) || !string.IsNullOrEmpty(this.Password); } }
        public string User { get; set; }
        public string Password { get; set; }

        public IRequestDecorator RequestDecorator { get; set; }
        public ISerializationStrategy SerializationStrategy { get; set; }
        public IDeserializationStrategy DeserializationStrategy { get; set; }

        public Action<object, IRequest> RequestCreated { get; set; }
        public Action<object, IResponse> ResponseReceived { get; set; }

        public ContentType ContentType { get; set; }
    }
}
