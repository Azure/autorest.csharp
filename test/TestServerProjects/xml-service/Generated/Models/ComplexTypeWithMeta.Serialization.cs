// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class ComplexTypeWithMeta : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (ID != null)
            {
                writer.WritePropertyName("ID");
                writer.WriteStringValue(ID);
            }
            writer.WriteEndObject();
        }
        internal static ComplexTypeWithMeta DeserializeComplexTypeWithMeta(JsonElement element)
        {
            ComplexTypeWithMeta result = new ComplexTypeWithMeta();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ID"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ID = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "XMLComplexTypeWithMeta");
            if (ID != null)
            {
                writer.WriteStartElement("ID");
                writer.WriteValue(ID);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static ComplexTypeWithMeta DeserializeComplexTypeWithMeta(XElement element)
        {
            ComplexTypeWithMeta result = default;
            string? value = default;
            var iD = element.Element("ID");
            if (iD != null)
            {
                value = (string?)iD;
            }
            result.ID = value;
            return result;
        }
    }
}
