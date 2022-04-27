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
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal static XmlInstanceData DeserializeXmlInstanceData(JsonElement element)
        {
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            SystemData systemData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = (ResourceType)property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.ToString());
                    continue;
                }
            }
            return new XmlInstanceData(id, name, type, systemData);
        }

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
            writer.WriteStartElement("systemData");
            writer.WriteValue(SystemData);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
