// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Serialization;

namespace xml_service.Models
{
    public partial class Slide : IXmlSerializable, IXmlModelSerializable
    {
        void IXmlModelSerializable.Serialize(XmlWriter writer, ModelSerializerOptions options) => ((IXmlSerializable)this).Write(writer, null, options);

        void IXmlSerializable.Write(XmlWriter writer, string nameHint, ModelSerializerOptions options)
        {
            writer.WriteStartElement("slide");
            if (Optional.IsDefined(Type))
            {
                writer.WriteStartAttribute("type");
                writer.WriteValue(Type);
                writer.WriteEndAttribute();
            }
            if (Optional.IsDefined(Title))
            {
                writer.WriteStartElement("title");
                writer.WriteValue(Title);
                writer.WriteEndElement();
            }
            if (Optional.IsCollectionDefined(Items))
            {
                foreach (var item in Items)
                {
                    writer.WriteStartElement("item");
                    writer.WriteValue(item);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeSlide(XElement.Load(data.ToStream()), options);
        }

        internal static Slide DeserializeSlide(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            string type = default;
            string title = default;
            IList<string> items = default;
            if (element.Attribute("type") is XAttribute typeAttribute)
            {
                type = (string)typeAttribute;
            }
            if (element.Element("title") is XElement titleElement)
            {
                title = (string)titleElement;
            }
            var array = new List<string>();
            foreach (var e in element.Elements("item"))
            {
                array.Add((string)e);
            }
            items = array;
            return new Slide(type, title, items);
        }
    }
}
