// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    internal partial class UnknownMyBaseType : IUtf8JsonSerializable, IJsonModel<MyBaseType>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MyBaseType>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<MyBaseType>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MyBaseType>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MyBaseType)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind.ToString());
            if (PropB1 != null)
            {
                writer.WritePropertyName("propB1"u8);
                writer.WriteStringValue(PropB1);
            }
            writer.WritePropertyName("helper"u8);
            writer.WriteStartObject();
            if (PropBH1 != null)
            {
                writer.WritePropertyName("propBH1"u8);
                writer.WriteStringValue(PropBH1);
            }
            writer.WriteEndObject();
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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

        MyBaseType IJsonModel<MyBaseType>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MyBaseType>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MyBaseType)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMyBaseType(document.RootElement, options);
        }

        internal static UnknownMyBaseType DeserializeUnknownMyBaseType(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MyKind kind = "Unknown";
            Optional<string> propB1 = default;
            Optional<string> propBH1 = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"u8))
                {
                    kind = new MyKind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("propB1"u8))
                {
                    propB1 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("helper"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("propBH1"u8))
                        {
                            propBH1 = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new UnknownMyBaseType(kind, propB1.Value, propBH1.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MyBaseType>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MyBaseType>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(MyBaseType)} does not support '{options.Format}' format.");
            }
        }

        MyBaseType IPersistableModel<MyBaseType>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MyBaseType>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeMyBaseType(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MyBaseType)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<MyBaseType>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
