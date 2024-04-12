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

namespace CustomizationsInTsp.Models
{
    public partial class ModelToAddAdditionalSerializableProperty : IUtf8JsonSerializable, IJsonModel<ModelToAddAdditionalSerializableProperty>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelToAddAdditionalSerializableProperty>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ModelToAddAdditionalSerializableProperty>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelToAddAdditionalSerializableProperty>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelToAddAdditionalSerializableProperty)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("requiredInt"u8);
            WriteRequiredIntValue(writer);
            writer.WritePropertyName("additionalSerializableProperty"u8);
            writer.WriteNumberValue(AdditionalSerializableProperty);
            if (Optional.IsDefined(AdditionalNullableSerializableProperty))
            {
                if (AdditionalNullableSerializableProperty != null)
                {
                    writer.WritePropertyName("additionalNullableSerializableProperty"u8);
                    writer.WriteNumberValue(AdditionalNullableSerializableProperty.Value);
                }
                else
                {
                    writer.WriteNull("additionalNullableSerializableProperty");
                }
            }
            writer.WritePropertyName("requiredIntOnBase"u8);
            WriteRequiredIntOnBaseValue(writer);
            if (Optional.IsDefined(OptionalInt))
            {
                writer.WritePropertyName("optionalInt"u8);
                writer.WriteNumberValue(OptionalInt.Value);
            }
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

        ModelToAddAdditionalSerializableProperty IJsonModel<ModelToAddAdditionalSerializableProperty>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelToAddAdditionalSerializableProperty>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelToAddAdditionalSerializableProperty)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelToAddAdditionalSerializableProperty(document.RootElement, options);
        }

        internal static ModelToAddAdditionalSerializableProperty DeserializeModelToAddAdditionalSerializableProperty(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int requiredInt = default;
            int additionalSerializableProperty = default;
            int? additionalNullableSerializableProperty = default;
            int requiredIntOnBase = default;
            int? optionalInt = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredInt"u8))
                {
                    ReadRequiredIntValue(property, ref requiredInt);
                    continue;
                }
                if (property.NameEquals("additionalSerializableProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    additionalSerializableProperty = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("additionalNullableSerializableProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        additionalNullableSerializableProperty = null;
                        continue;
                    }
                    additionalNullableSerializableProperty = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("requiredIntOnBase"u8))
                {
                    ReadRequiredIntOnBaseValue(property, ref requiredIntOnBase);
                    continue;
                }
                if (property.NameEquals("optionalInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalInt = property.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ModelToAddAdditionalSerializableProperty(
                requiredIntOnBase,
                optionalInt,
                serializedAdditionalRawData,
                requiredInt,
                additionalSerializableProperty,
                additionalNullableSerializableProperty);
        }

        BinaryData IPersistableModel<ModelToAddAdditionalSerializableProperty>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelToAddAdditionalSerializableProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ModelToAddAdditionalSerializableProperty)} does not support writing '{options.Format}' format.");
            }
        }

        ModelToAddAdditionalSerializableProperty IPersistableModel<ModelToAddAdditionalSerializableProperty>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelToAddAdditionalSerializableProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeModelToAddAdditionalSerializableProperty(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ModelToAddAdditionalSerializableProperty)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ModelToAddAdditionalSerializableProperty>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new ModelToAddAdditionalSerializableProperty FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeModelToAddAdditionalSerializableProperty(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, new ModelReaderWriterOptions("W"));
            return content;
        }
    }
}
