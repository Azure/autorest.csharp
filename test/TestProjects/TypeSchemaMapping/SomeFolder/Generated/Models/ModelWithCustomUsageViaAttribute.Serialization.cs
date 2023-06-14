// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    public partial class ModelWithCustomUsageViaAttribute : IUtf8JsonSerializable, IXmlSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "ModelWithCustomUsageViaAttribute");
            if (Optional.IsDefined(ModelProperty))
            {
                writer.WriteStartElement("ModelProperty");
                writer.WriteValue(ModelProperty);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        internal static ModelWithCustomUsageViaAttribute DeserializeModelWithCustomUsageViaAttribute(XElement element)
        {
            string modelProperty = default;
            if (element.Element("ModelProperty") is XElement modelPropertyElement)
            {
                modelProperty = (string)modelPropertyElement;
            }
            return new ModelWithCustomUsageViaAttribute(modelProperty);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ModelProperty))
            {
                writer.WritePropertyName("ModelProperty"u8);
                writer.WriteStringValue(ModelProperty);
            }
            writer.WriteEndObject();
        }

        internal static ModelWithCustomUsageViaAttribute DeserializeModelWithCustomUsageViaAttribute(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> modelProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"u8))
                {
                    modelProperty = property.Value.GetString();
                    continue;
                }
            }
            return new ModelWithCustomUsageViaAttribute(modelProperty.Value);
        }
    }
}
