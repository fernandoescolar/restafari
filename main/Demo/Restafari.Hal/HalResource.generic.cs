using System.Linq;

namespace Restafari.Hal
{
    public class HalResource<T> : HalResource where T : class, new()
    {
        public T Entity { get { return this.GetElement<T>(); } }

        public HalResource() : base()
        {
        }

        public HalResource(T entity) : base(entity)
        {
        }

        public static HalResource<T> FromHalResource(HalResource d)
        {
            return  new HalResource<T> {Embedded = d.Embedded, Links = d.Links, Properties = d.Properties};
        }

        public static HalResource<T>[] FromHalResource(HalResource[] d)
        {
            return d.Select(FromHalResource).ToArray();
        }
    }
}