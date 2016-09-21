using System.Text;

namespace Restafari.MessageExchange
{
    internal class CharsetDecorator : IRequestDecorator
    {
        public bool CanDecorate(RequestSettings settings)
        {
            return !string.IsNullOrEmpty(settings.ContentType);
        }

        public void Decorate(IRequest request, RequestSettings settings)
        {
            if (!string.IsNullOrEmpty(request.ContentType))
                request.ContentType += "; charset=" + settings.Encoding.WebName;
        }
    }
}
