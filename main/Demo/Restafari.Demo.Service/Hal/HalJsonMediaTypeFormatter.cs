using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace Restafari.Demo.Service.Hal
{
    public class HalJsonMediaTypeFormatter : JsonMediaTypeFormatter
    {
        private const string HalJsonHeader = "application/hal-json";

        public HalJsonMediaTypeFormatter() 
        {
            this.SupportedMediaTypes.Clear();
            this.SupportedMediaTypes.Add(new MediaTypeWithQualityHeaderValue(HalJsonHeader));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }

        public override System.Threading.Tasks.Task WriteToStreamAsync(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
        {
            var obj = HalResource.CreateFrom(value);
            return base.WriteToStreamAsync(type, obj, writeStream, content, transportContext);
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            headers.ContentType = new MediaTypeHeaderValue(HalJsonHeader);
        }
    }
}