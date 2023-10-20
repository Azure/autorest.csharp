// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Serialization;
using MgmtXmlDeserialization;

namespace MgmtXmlDeserialization.Models
{
    internal partial class XmlCollection : IUtf8JsonSerializable, IModelJsonSerializable<XmlCollection>, IXmlSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "XmlCollection");
            if (Optional.IsDefined(Count))
            {
                writer.WriteStartElement("count");
                writer.WriteValue(Count.Value);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(NextLink))
            {
                writer.WriteStartElement("nextLink");
                writer.WriteValue(NextLink);
                writer.WriteEndElement();
            }
            if (Optional.IsCollectionDefined(Value))
            {
                foreach (var item in Value)
                {
                    writer.WriteObjectValue(item, "XmlInstance");
                }
            }
            writer.WriteEndElement();
        }

        internal static XmlCollection DeserializeXmlCollection(XElement element)
        {
            long? count = default;
            string nextLink = default;
            IReadOnlyList<XmlInstanceData> value = default;
            if (element.Element("count") is XElement countElement)
            {
                count = (long?)countElement;
            }
            if (element.Element("nextLink") is XElement nextLinkElement)
            {
                nextLink = (string)nextLinkElement;
            }
            var array = new List<XmlInstanceData>();
            foreach (var e in element.Elements("XmlInstance"))
            {
                array.Add(XmlInstanceData.DeserializeXmlInstanceData(e));
            }
            value = array;
            return new XmlCollection(value, count, nextLink, default);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<XmlCollection>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<XmlCollection>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Value))
            {
                writer.WritePropertyName("value"u8);
                writer.WriteStartArray();
                foreach (var item in Value)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Count))
            {
                writer.WritePropertyName("count"u8);
                writer.WriteNumberValue(Count.Value);
            }
            if (Optional.IsDefined(NextLink))
            {
                writer.WritePropertyName("nextLink"u8);
                writer.WriteStringValue(NextLink);
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        XmlCollection IModelJsonSerializable<XmlCollection>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeXmlCollection(document.RootElement, options);
        }

        BinaryData IModelSerializable<XmlCollection>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        XmlCollection IModelSerializable<XmlCollection>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeXmlCollection(document.RootElement, options);
        }

        internal static XmlCollection DeserializeXmlCollection(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<XmlInstanceData>> value = default;
            Optional<long> count = default;
            Optional<string> nextLink = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<XmlInstanceData> array = new List<XmlInstanceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(XmlInstanceData.DeserializeXmlInstanceData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("count"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    count = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new XmlCollection(Optional.ToList(value), Optional.ToNullable(count), nextLink.Value, serializedAdditionalRawData);
        }
    }
}
