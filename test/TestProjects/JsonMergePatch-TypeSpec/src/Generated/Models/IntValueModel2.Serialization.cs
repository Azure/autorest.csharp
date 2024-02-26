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
    public partial class IntValueModel2 : IUtf8JsonSerializable, IJsonModel<IntValueModel2>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<IntValueModel2>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<IntValueModel2>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" || options.Format == "JMP" ? ((IPersistableModel<IntValueModel2>)this).GetFormatFromOptions(options) : options.Format;
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
            writer.WriteEndObject();
        }

        void WritePatch(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (_changed[_requiredIntValueCount])
            {
                writer.WritePropertyName("requiredIntValue"u8);
                writer.WriteNumberValue(RequiredIntValue);
            }
            if (_changed[_optionalIntValueCount])
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
            writer.WriteEndObject();
        }

        IntValueModel2 IJsonModel<IntValueModel2>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IntValueModel2>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IntValueModel2)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIntValueModel2(document.RootElement, options);
        }

        internal static IntValueModel2 DeserializeIntValueModel2(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int requiredIntValue = default;
            Optional<int> optionalIntValue = default;
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
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new IntValueModel2(requiredIntValue, Optional.ToNullable(optionalIntValue), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<IntValueModel2>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IntValueModel2>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(IntValueModel2)} does not support '{options.Format}' format.");
            }
        }

        IntValueModel2 IPersistableModel<IntValueModel2>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IntValueModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeIntValueModel2(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(IntValueModel)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<IntValueModel2>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static IntValueModel2 FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeIntValueModel2(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}