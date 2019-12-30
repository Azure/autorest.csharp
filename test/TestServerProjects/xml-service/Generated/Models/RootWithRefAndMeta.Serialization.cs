// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class RootWithRefAndMeta : IUtf8JsonSerializable, IXmlSerializable
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
        internal static RootWithRefAndMeta DeserializeRootWithRefAndMeta(JsonElement element)
        {
            RootWithRefAndMeta result = new RootWithRefAndMeta();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("RefToModel"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.RefToModel = ComplexTypeWithMeta.DeserializeComplexTypeWithMeta(property.Value);
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
            writer.WriteStartElement(nameHint ?? "AutoRootWithRefAndMeta");
            if (RefToModel != null)
            {
                writer.WriteStartElement("XMLComplexTypeWithMeta");
                writer.WriteObjectValue(RefToModel, null);
                writer.WriteEndElement();
            }
            if (Something != null)
            {
                writer.WriteStartElement("Something");
                writer.WriteValue(Something);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static RootWithRefAndMeta DeserializeRootWithRefAndMeta(XElement element)
        {
            RootWithRefAndMeta result = new RootWithRefAndMeta();
            var refToModel = element.Element("XMLComplexTypeWithMeta");
            if (refToModel != null)
            {
                result.RefToModel = ComplexTypeWithMeta.DeserializeComplexTypeWithMeta(refToModel);
            }
            var something = element.Element("Something");
            if (something != null)
            {
                result.Something = (string?)something;
            }
            return result;
        }
    }
}
