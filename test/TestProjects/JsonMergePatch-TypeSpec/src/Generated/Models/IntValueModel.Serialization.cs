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

namespace Payload.JsonMergePatch.Models
{
    public partial class IntValueModel : IUtf8JsonSerializable, IJsonModel<IntValueModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<IntValueModel>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<IntValueModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" || options.Format == "JMP" ? ((IPersistableModel<IntValueModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IntValueModel)} does not support '{format}' format.");
            }

            if (options.Format == "W")
            {
                WriteJson(writer, options);
            }
            else if (options.Format == "JMP")
            {
                WritePatch(writer);
            }
        }

        void WriteJson(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("requiredIntValue"u8);
            writer.WriteNumberValue(RequiredIntValue);
            if (Optional.IsDefined(OptionalIntValue))
            {
                writer.WritePropertyName("optionalIntValue"u8);
                writer.WriteNumberValue(OptionalIntValue.Value);
            }
            writer.WritePropertyName("requiredValue"u8);
#if NET6_0_OR_GREATER
            writer.WriteRawValue(RequiredValue);
#else
            using (JsonDocument document = JsonDocument.Parse(RequiredValue))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            if (Optional.IsDefined(OptionalValue))
            {
                writer.WritePropertyName("optionalValue"u8);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(OptionalValue);
#else
                using (JsonDocument document = JsonDocument.Parse(OptionalValue))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
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

        void WritePatch(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (_requiredIntValueChanged)
            {
                writer.WritePropertyName("requiredIntValue"u8);
                writer.WriteNumberValue(RequiredIntValue);
            }
            if (_optionalIntValueChanged)
            {
                writer.WritePropertyName("optionalIntValue"u8);
                if (_optionalIntValue != null)
                {
                    writer.WriteNumberValue(OptionalIntValue.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }
            }

            if (_requiredValueChanged)
            {
                writer.WritePropertyName("requiredValue"u8);
                if (RequiredValue != null)
                {
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(RequiredValue);
#else
                    using (JsonDocument document = JsonDocument.Parse(RequiredValue))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                else
                {
                    writer.WriteNullValue();
                }
            }

            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }

        IntValueModel IJsonModel<IntValueModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IntValueModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IntValueModel)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIntValueModel(document.RootElement, options);
        }

        internal static IntValueModel DeserializeIntValueModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int requiredIntValue = default;
            Optional<int> optionalIntValue = default;
            BinaryData requiredValue = default;
            Optional<BinaryData> optionalValue = default;
            string kind = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredIntValue"u8))
                {
                    requiredIntValue = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("optionalIntValue"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalIntValue = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("requiredValue"u8))
                {
                    requiredValue = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("optionalValue"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalValue = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new IntValueModel(requiredValue, optionalValue.Value, kind, serializedAdditionalRawData, requiredIntValue, Optional.ToNullable(optionalIntValue));
        }

        BinaryData IPersistableModel<IntValueModel>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IntValueModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(IntValueModel)} does not support '{options.Format}' format.");
            }
        }

        IntValueModel IPersistableModel<IntValueModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IntValueModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeIntValueModel(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(IntValueModel)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<IntValueModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new IntValueModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeIntValueModel(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}