// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class RootWithRefAndNoMeta : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (RefToModel != null)
            {
                writer.WritePropertyName("RefToModel");
                writer.WriteObjectValue(RefToModel);
            }
            if (Something != null)
            {
                writer.WritePropertyName("Something");
                writer.WriteStringValue(Something);
            }
            writer.WriteEndObject();
        }
        internal static RootWithRefAndNoMeta DeserializeRootWithRefAndNoMeta(JsonElement element)
        {
            RootWithRefAndNoMeta result = new RootWithRefAndNoMeta();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("RefToModel"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.RefToModel = ComplexTypeNoMeta.DeserializeComplexTypeNoMeta(property.Value);
                    continue;
                }
                if (property.NameEquals("Something"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Something = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "RootWithRefAndNoMeta");
            if (RefToModel != null)
            {
                writer.WriteObjectValue(RefToModel, "RefToModel");
            }
            if (Something != null)
            {
                writer.WriteStartElement("Something");
                writer.WriteValue(Something);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static RootWithRefAndNoMeta DeserializeRootWithRefAndNoMeta(XElement element)
        {
            RootWithRefAndNoMeta result = default;
            result = new RootWithRefAndNoMeta(); ComplexTypeNoMeta value = default;
            var refToModel = element.Element("RefToModel");
            if (refToModel != null)
            {
                value = ComplexTypeNoMeta.DeserializeComplexTypeNoMeta(refToModel);
            }
            result.RefToModel = value;
            string value0 = default;
            var something = element.Element("Something");
            if (something != null)
            {
                value0 = (string)something;
            }
            result.Something = value0;
            return result;
        }
    }
}
