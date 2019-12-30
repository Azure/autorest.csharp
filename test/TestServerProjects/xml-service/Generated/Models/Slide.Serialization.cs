// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class Slide : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Type != null)
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue(Type);
            }
            if (Title != null)
            {
                writer.WritePropertyName("title");
                writer.WriteStringValue(Title);
            }
            if (Items != null)
            {
                writer.WritePropertyName("items");
                writer.WriteStartArray();
                foreach (var item in Items)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static Slide DeserializeSlide(JsonElement element)
        {
            Slide result = new Slide();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("title"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Title = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("items"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Items = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Items.Add(item.GetString());
                    }
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "slide");
            if (Type != null)
            {
                writer.WriteStartAttribute("type");
                writer.WriteValue(Type);
                writer.WriteEndAttribute();
            }
            if (Title != null)
            {
                writer.WriteStartElement("title");
                writer.WriteValue(Title);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static Slide DeserializeSlide(XElement element)
        {
            Slide result = new Slide();
            var type = element.Attribute("type");
            if (type != null)
            {
                result.Type = (string?)type;
            }
            var title = element.Element("title");
            if (title != null)
            {
                result.Title = (string?)title;
            }
            result.Items = new List<string>();
            var elements = element.Elements("item");
            foreach (var e in elements)
            {
                result.Items.Add((string)e);
            }
            return result;
        }
    }
}
