using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Restafari.Hal
{
    [JsonConverter(typeof(HalResourceConverter))]
    [KnownType(typeof(HalLink))]
    [XmlRoot("resource", Namespace = "")]
    public class HalResource : IXmlSerializable
    {
        internal object entity;

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
            return this.GetElement(typeof (T)) as T;
        }

        public virtual object GetElement(Type type) 
        {
            this.entity = Activator.CreateInstance(type);

            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite))
            {
                if (property.PropertyType.IsPrimitive || property.PropertyType.IsEnum || property.PropertyType.IsAssignableFrom(typeof(string)) || property.PropertyType.IsAssignableFrom(typeof(DateTime)))
                {
                    if (this.Properties.ContainsKey(property.Name))
                    {
                        property.SetValue(this.entity, ((JValue)this.Properties[property.Name]).ToObject(property.PropertyType));
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

            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite))
            {

                if (property.PropertyType.IsPrimitive || property.PropertyType.IsEnum || property.PropertyType.IsAssignableFrom(typeof(string)) || property.PropertyType.IsAssignableFrom(typeof(DateTime)))
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

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (var link in this.Links)
            {
                writer.WriteStartElement("link");
                link.Value.WriteXml(writer);
                writer.WriteEndElement();
            }

            foreach (var property in this.Properties)
            {
                writer.WriteStartElement(property.Key);
                writer.WriteValue(property.Value);
                writer.WriteEndElement();
            }

            foreach (var resource in this.Embedded)
            {
                writer.WriteStartElement("resource");
                resource.Value.WriteXml(writer);
                writer.WriteEndElement();
            }
        }

        public static HalResource CreateFrom(object o)
        {
            return o is IEnumerable ? new HalListResource((IEnumerable)o) : new HalResource(o);
        }
    }
}