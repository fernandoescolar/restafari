using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Restafari.Demo.Service.Hal
{
    [JsonConverter(typeof(HalResourceConverter))]
    [KnownType(typeof(HalLink))]
    public class HalResource
    {
        protected object entity;

        public IDictionary<string, HalLink> Links { get; set; }

        public IDictionary<string, HalResource> Embedded { get; set; }

        public IDictionary<string, object> Properties { get; set; }

        public HalResource()
        {
            this.Properties = new Dictionary<string, object>();
            this.Embedded = new Dictionary<string, HalResource>();
        }

        public HalResource(object entity) : this()
        {
            this.entity = entity;
            this.GenerateHal();
        }

        public T GetElement<T>() where T : class, new()
        {
            return GetElement(typeof (T)) as T;
        }

        public object GetElement(Type type) 
        {
            this.entity = Activator.CreateInstance(type);

            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.GetProperty))
            {
                if (property.PropertyType.IsPrimitive || property.PropertyType.IsEnum)
                {
                    if (this.Properties.ContainsKey(property.Name))
                    {
                        property.SetValue(this.entity, this.Properties[property.Name]);
                    }
                }
                else
                {
                    if (this.Embedded.ContainsKey(property.Name))
                    {
                        property.SetValue(this.entity, this.Embedded[property.Name].GetElement(property.PropertyType));
                    }
                }
            }

            return this.entity;
        }

        private void GenerateHal()
        {
            this.Properties.Clear();
            this.Embedded.Clear();

            var type = this.entity.GetType();

            foreach (var property in type.GetProperties().Where(p => p.CanRead && p.CanWrite))
            {

                if (property.PropertyType.IsPrimitive || property.PropertyType.IsEnum || property.PropertyType.IsAssignableFrom(typeof(string)))
                {
                    this.Properties.Add(property.Name, property.GetValue(this.entity));
                }
                else
                {
                    var value = property.GetValue(this.entity);
                    if (value != null) /* embedded are optional paramaters */
                    {
                        this.Embedded.Add(property.Name, CreateFrom(value));
                    }
                }
            }
        }

        public static HalResource CreateFrom(object o)
        {
            var list = o as IEnumerable;
            return list != null ? new HalListResource(list) : new HalResource(o);
        }
    }

    public class HalResource<T> : HalResource where T : class, new()
    {
        public T Entity { get { return this.GetElement<T>(); } }

        public HalResource() : base()
        {
        }

        public HalResource(T entity) : base(entity)
        {
        }
    }
}