using System.Collections.Generic;

namespace Restafari.Hal
{
    public interface ILinkProvider
    {
        Dictionary<string, HalLink> GetLinksFor(object value);
    }
    public interface ILinkProvider<in T> : ILinkProvider
    {
        Dictionary<string, HalLink> GetLinksFor(T value);
    }
}
