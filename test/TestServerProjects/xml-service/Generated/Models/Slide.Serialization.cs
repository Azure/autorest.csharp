// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class Slide : IXmlSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "slide");
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

        internal static Slide DeserializeSlide(XElement element)
        {
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
