// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class ComplexTypeNoMeta : IUtf8JsonSerializable, IXmlSerializable
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
                    result.ID = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "AutoComplexTypeNoMeta");
            if (ID != null)
            {
                writer.WriteStartElement("ID");
                writer.WriteValue(ID);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static ComplexTypeNoMeta DeserializeComplexTypeNoMeta(XElement element)
        {
            ComplexTypeNoMeta result = new ComplexTypeNoMeta();
            var iD = element.Element("ID");
            if (iD != null)
            {
                result.ID = (string?)iD;
            }
            return result;
        }
    }
}
