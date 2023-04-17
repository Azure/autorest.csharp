// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace XmlDeserialization
{
    public partial class XmlInstanceData : IUtf8JsonSerializable, IXmlSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "XmlInstance");
            writer.WriteStartElement("id");
            writer.WriteValue(Id);
            writer.WriteEndElement();
            writer.WriteStartElement("name");
            writer.WriteValue(Name);
            writer.WriteEndElement();
            writer.WriteStartElement("type");
            writer.WriteValue(ResourceType);
            writer.WriteEndElement();
            if (Optional.IsDefined(SystemData))
            {
                writer.WriteStartElement("systemData");
                writer.WriteValue(SystemData);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal static XmlInstanceData DeserializeXmlInstanceData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
                    continue;
                }
            }
            return new XmlInstanceData(id, name, type, systemData.Value);
        }
    }
}
