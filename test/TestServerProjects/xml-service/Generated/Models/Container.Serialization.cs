// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class Container : IXmlSerializable, IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Name");
            writer.WriteStringValue(Name);
            writer.WritePropertyName("Properties");
            writer.WriteObjectValue(Properties);
            writer.WritePropertyName("Metadata");
            writer.WriteStartObject();
            foreach (var item in Metadata)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
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
            writer.WriteStartElement(nameHint ?? "AutoContainer");
            writer.WriteStartElement("Name");
            writer.WriteValue(Name);
            writer.WriteEndElement();
            writer.WriteStartElement("Properties");
            writer.WriteObjectValue(Properties, null);
            writer.WriteEndElement();
            writer.WriteStartElement("Metadata");
            writer.WriteEndElement();
        }
        internal static Container DeserializeContainer(XElement element)
        {
            Container result = new Container();
            var name = element.Element("Name");
            if (name != null)
            {
                result.Name = (string)name;
            }
            var properties = element.Element("Properties");
            if (properties != null)
            {
                result.Properties = ContainerProperties.DeserializeContainerProperties(properties);
            }
            var metadata = element.Element("Metadata");
            if (metadata != null)
            {
                IDictionary<string, string> value = new Dictionary<string, string>();
                result.Metadata = value;
            }
            return result;
        }
    }
}
