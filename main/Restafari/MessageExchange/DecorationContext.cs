using System.Collections.Generic;
using System.Linq;

namespace Restafari.MessageExchange
{
    internal class DecorationContext : List<IRequestDecorator>, IDecorationContext
    {
        private static readonly IRequestDecorator[] DefaultRequestDecorators = { 
                                                                                   new JsonRequestDecorator(), 
                                                                                   new XmlRequestDecorator(), 
                                                                                   new CharsetDecorator() };

        public DecorationContext()
            : base(DefaultRequestDecorators)
        {

        }

        public void Decorate(IRequest request, RequestSettings settings)
        {
            foreach(var decorator in this.GetDecorators(settings))
                decorator.Decorate(request, settings);
        }

        private IEnumerable<IRequestDecorator> GetDecorators(RequestSettings settings)
        {
            return this.Where(d => d.CanDecorate(settings));
        }
    }
}
