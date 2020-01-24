// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class Container : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Name");
            writer.WriteStringValue(Name);
            writer.WritePropertyName("Properties");
            writer.WriteObjectValue(Properties);
            if (Metadata != null)
            {
                writer.WritePropertyName("Metadata");
                writer.WriteStartObject();
                foreach (var item in Metadata)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }
        internal static Container DeserializeContainer(JsonElement element)
        {
            Container result = new Container();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Properties"))
                {
                    result.Properties = ContainerProperties.DeserializeContainerProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("Metadata"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Metadata = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        result.Metadata.Add(property0.Name, property0.Value.GetString());
                    }
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "Container");
            writer.WriteStartElement("Name");
            writer.WriteValue(Name);
            writer.WriteEndElement();
            writer.WriteObjectValue(Properties, "Properties");
            if (Metadata != null)
            {
                foreach (var pair in Metadata)
                {
                    writer.WriteStartElement("!dictionary-item");
                    writer.WriteValue(pair.Value);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }
        internal static Container DeserializeContainer(XElement element)
        {
            Container result = default;
            result = new Container(); string value = default;
            var name = element.Element("Name");
            if (name != null)
            {
                value = (string)name;
            }
            result.Name = value;
            ContainerProperties value0 = default;
            var properties = element.Element("Properties");
            if (properties != null)
            {
                value0 = ContainerProperties.DeserializeContainerProperties(properties);
            }
            result.Properties = value0;
            System.Collections.Generic.IDictionary<string, string> value1 = default;
            var metadata = element.Element("Metadata");
            if (metadata != null)
            {
                value1 = new System.Collections.Generic.Dictionary<string, string>(); var elements = metadata.Elements();
                foreach (var e in elements)
                {
                    string value2 = default;
                    value2 = (string)e;
                    value1.Add(e.Name.LocalName, value2);
                }
            }
            result.Metadata = value1;
            return result;
        }
    }
}
