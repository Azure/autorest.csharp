// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Inheritance.Models
{
    internal partial class UnknownBaseClassWithExtensibleEnumDiscriminator : IUtf8JsonSerializable, IJsonModel<BaseClassWithExtensibleEnumDiscriminator>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<BaseClassWithExtensibleEnumDiscriminator>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<BaseClassWithExtensibleEnumDiscriminator>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BaseClassWithExtensibleEnumDiscriminator>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(BaseClassWithExtensibleEnumDiscriminator)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("DiscriminatorProperty"u8);
            writer.WriteStringValue(DiscriminatorProperty.ToString());
            if (_serializedAdditionalRawData != null && options.Format != "W")
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

        BaseClassWithExtensibleEnumDiscriminator IJsonModel<BaseClassWithExtensibleEnumDiscriminator>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BaseClassWithExtensibleEnumDiscriminator>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(BaseClassWithExtensibleEnumDiscriminator)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUnknownBaseClassWithExtensibleEnumDiscriminator(document.RootElement, options);
        }

        internal static UnknownBaseClassWithExtensibleEnumDiscriminator DeserializeUnknownBaseClassWithExtensibleEnumDiscriminator(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BaseClassWithEntensibleEnumDiscriminatorEnum discriminatorProperty = "Unknown";
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("DiscriminatorProperty"u8))
                {
                    discriminatorProperty = new BaseClassWithEntensibleEnumDiscriminatorEnum(property.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new UnknownBaseClassWithExtensibleEnumDiscriminator(discriminatorProperty, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<BaseClassWithExtensibleEnumDiscriminator>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BaseClassWithExtensibleEnumDiscriminator>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(BaseClassWithExtensibleEnumDiscriminator)} does not support '{options.Format}' format.");
            }
        }

        BaseClassWithExtensibleEnumDiscriminator IPersistableModel<BaseClassWithExtensibleEnumDiscriminator>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BaseClassWithExtensibleEnumDiscriminator>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeUnknownBaseClassWithExtensibleEnumDiscriminator(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(BaseClassWithExtensibleEnumDiscriminator)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<BaseClassWithExtensibleEnumDiscriminator>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
