// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
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
            writer.WriteStartElement(nameHint ?? "AutoRootWithRefAndNoMeta");
            if (RefToModel != null)
            {
                writer.WriteStartElement("RefToModel");
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
        internal static RootWithRefAndNoMeta DeserializeRootWithRefAndNoMeta(XElement element)
        {
            RootWithRefAndNoMeta result = new RootWithRefAndNoMeta();
            var refToModel = element.Element("RefToModel");
            if (refToModel != null)
            {
                result.RefToModel = ComplexTypeNoMeta.DeserializeComplexTypeNoMeta(refToModel);
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
