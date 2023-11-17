// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;
using MgmtXmlDeserialization;

namespace MgmtXmlDeserialization.Models
{
    internal partial class XmlCollection : IUtf8JsonSerializable, IJsonModel<XmlCollection>, IXmlSerializable, IPersistableModel<XmlCollection>
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

        internal static XmlCollection DeserializeXmlCollection(XElement element, ModelReaderWriterOptions options = null)
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

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<XmlCollection>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<XmlCollection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<XmlCollection>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<XmlCollection>)} interface");
            }

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
            if (_serializedAdditionalRawData != null && options.Format == "J")
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        XmlCollection IJsonModel<XmlCollection>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(XmlCollection)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeXmlCollection(document.RootElement, options);
        }

        internal static XmlCollection DeserializeXmlCollection(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

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
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new XmlCollection(Optional.ToList(value), Optional.ToNullable(count), nextLink.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<XmlCollection>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(XmlCollection)} does not support '{options.Format}' format.");
            }

            if (options.Format == "J")
            {
                return ModelReaderWriter.Write(this, options);
            }
            else
            {
                using MemoryStream stream = new MemoryStream();
                using XmlWriter writer = XmlWriter.Create(stream);
                ((IXmlSerializable)this).Write(writer, null);
                writer.Flush();
                if (stream.Position > int.MaxValue)
                {
                    return BinaryData.FromStream(stream);
                }
                else
                {
                    return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
                }
            }
        }

        XmlCollection IPersistableModel<XmlCollection>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(XmlCollection)} does not support '{options.Format}' format.");
            }

            if (options.Format == "J")
            {
                using JsonDocument document = JsonDocument.Parse(data);
                return DeserializeXmlCollection(document.RootElement, options);
            }
            else
            {
                return DeserializeXmlCollection(XElement.Load(data.ToStream()), options);
            }
        }

        string IPersistableModel<XmlCollection>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
