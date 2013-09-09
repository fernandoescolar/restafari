using System.Web.Http;
using Restafari.Demo.Service.Hal;

namespace Restafari.Demo.Service
{
    public static class HalConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Add(new HalJsonMediaTypeFormatter());
        }
    }
}
