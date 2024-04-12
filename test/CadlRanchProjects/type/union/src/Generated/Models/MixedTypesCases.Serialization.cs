// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace _Type.Union.Models
{
    public partial class MixedTypesCases : IUtf8JsonSerializable, IJsonModel<MixedTypesCases>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MixedTypesCases>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<MixedTypesCases>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MixedTypesCases>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MixedTypesCases)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("model"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Model);
#else
            using (JsonDocument document = JsonDocument.Parse(Model))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            writer.WritePropertyName("literal"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Literal);
#else
            using (JsonDocument document = JsonDocument.Parse(Literal))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            writer.WritePropertyName("int"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Int);
#else
            using (JsonDocument document = JsonDocument.Parse(Int))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            writer.WritePropertyName("boolean"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Boolean);
#else
            using (JsonDocument document = JsonDocument.Parse(Boolean))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
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

        MixedTypesCases IJsonModel<MixedTypesCases>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MixedTypesCases>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MixedTypesCases)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMixedTypesCases(document.RootElement, options);
        }

        internal static MixedTypesCases DeserializeMixedTypesCases(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BinaryData model = default;
            BinaryData literal = default;
            BinaryData @int = default;
            BinaryData boolean = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("model"u8))
                {
                    model = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("literal"u8))
                {
                    literal = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("int"u8))
                {
                    @int = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("boolean"u8))
                {
                    boolean = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new MixedTypesCases(model, literal, @int, boolean, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MixedTypesCases>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MixedTypesCases>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(MixedTypesCases)} does not support writing '{options.Format}' format.");
            }
        }

        MixedTypesCases IPersistableModel<MixedTypesCases>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MixedTypesCases>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeMixedTypesCases(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MixedTypesCases)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MixedTypesCases>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MixedTypesCases FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMixedTypesCases(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
