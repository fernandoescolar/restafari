using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Restafari.Hal
{
    public static class HalConfig
    {
        private static Dictionary<Type, Lazy<ILinkProvider>> providers =new Dictionary<Type, Lazy<ILinkProvider>>();

        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Add(new HalJsonMediaTypeFormatter());
        }

        public static void RegisterLinkProvider<T>(Func<ILinkProvider<T>> providerConstructor)
        {
            var lazy = new Lazy<ILinkProvider>(providerConstructor);

            if (providers.ContainsKey(typeof(T)))
            {
                providers[typeof(T)] = lazy;
            }
            else
            {
                providers.Add(typeof(T), lazy);
            }
        }

        internal static ILinkProvider GetProvider(Type type)
        {
            if (providers.ContainsKey(type))
            {
                return providers[type].Value;
            }

            return null;
        }
    }
}
