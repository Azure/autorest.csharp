// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class Blob : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Name");
            writer.WriteStringValue(Name);
            writer.WritePropertyName("Deleted");
            writer.WriteBooleanValue(Deleted);
            writer.WritePropertyName("Snapshot");
            writer.WriteStringValue(Snapshot);
            writer.WritePropertyName("Properties");
            writer.WriteObjectValue(Properties);
            if (Metadata != null)
            {
                writer.WritePropertyName("Metadata");
                writer.WriteStartObject();
                foreach (var item in Metadata)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }
        internal static Blob DeserializeBlob(JsonElement element)
        {
            Blob result = new Blob();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Deleted"))
                {
                    result.Deleted = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("Snapshot"))
                {
                    result.Snapshot = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Properties"))
                {
                    result.Properties = BlobProperties.DeserializeBlobProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("Metadata"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Metadata = new Dictionary<string, string>();
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
            writer.WriteStartElement(nameHint ?? "Blob");
            writer.WriteStartElement("Name");
            writer.WriteValue(Name);
            writer.WriteEndElement();
            writer.WriteStartElement("Deleted");
            writer.WriteValue(Deleted);
            writer.WriteEndElement();
            writer.WriteStartElement("Snapshot");
            writer.WriteValue(Snapshot);
            writer.WriteEndElement();
            writer.WriteObjectValue(Properties, "Properties");
            if (Metadata != null)
            {
                foreach (var pair in Metadata)
                {
                    writer.WriteStartElement("!dictionary-item");
                    writer.WriteValue(pair.Value);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }
        internal static Blob DeserializeBlob(XElement element)
        {
            Blob result = default;
            result = new Blob(); string value = default;
            var name = element.Element("Name");
            if (name != null)
            {
                value = (string)name;
            }
            result.Name = value;
            bool value0 = default;
            var deleted = element.Element("Deleted");
            if (deleted != null)
            {
                value0 = (bool)deleted;
            }
            result.Deleted = value0;
            string value1 = default;
            var snapshot = element.Element("Snapshot");
            if (snapshot != null)
            {
                value1 = (string)snapshot;
            }
            result.Snapshot = value1;
            BlobProperties value2 = default;
            var properties = element.Element("Properties");
            if (properties != null)
            {
                value2 = BlobProperties.DeserializeBlobProperties(properties);
            }
            result.Properties = value2;
            IDictionary<string, string>? value3 = default;
            var metadata = element.Element("Metadata");
            if (metadata != null)
            {
                value3 = new Dictionary<string, string>(); var elements = metadata.Elements();
                foreach (var e in elements)
                {
                    string value4 = default;
                    value4 = (string)e;
                    value3.Add(e.Name.LocalName, value4);
                }
            }
            result.Metadata = value3;
            return result;
        }
    }
}
