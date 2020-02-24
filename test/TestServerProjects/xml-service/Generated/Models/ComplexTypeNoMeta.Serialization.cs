// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class ComplexTypeNoMeta : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Id != null)
            {
                writer.WritePropertyName("ID");
                writer.WriteStringValue(Id);
            }
            writer.WriteEndObject();
        }
        internal static ComplexTypeNoMeta DeserializeComplexTypeNoMeta(JsonElement element)
        {
            ComplexTypeNoMeta result = new ComplexTypeNoMeta();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ID"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Id = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "ComplexTypeNoMeta");
            if (Id != null)
            {
                writer.WriteStartElement("ID");
                writer.WriteValue(Id);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static ComplexTypeNoMeta DeserializeComplexTypeNoMeta(XElement element)
        {
            ComplexTypeNoMeta result = default;
            result = new ComplexTypeNoMeta(); string value = default;
            var iD = element.Element("ID");
            if (iD != null)
            {
                value = (string)iD;
            }
            result.Id = value;
            return result;
        }
    }
}
