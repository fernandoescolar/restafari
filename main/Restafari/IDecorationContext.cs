using System.Collections.Generic;

namespace Restafari
{
    public interface IDecorationContext : IList<IRequestDecorator>
    {
        void Decorate(IRequest request, RequestSettings settings);
    }
}
