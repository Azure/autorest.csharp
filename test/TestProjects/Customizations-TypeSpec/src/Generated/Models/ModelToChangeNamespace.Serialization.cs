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
    public partial class ModelToChangeNamespace : IUtf8JsonSerializable, IJsonModel<ModelToChangeNamespace>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelToChangeNamespace>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ModelToChangeNamespace>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelToChangeNamespace>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelToChangeNamespace)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("requiredInt"u8);
            writer.WriteNumberValue(RequiredInt);
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

        ModelToChangeNamespace IJsonModel<ModelToChangeNamespace>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelToChangeNamespace>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelToChangeNamespace)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelToChangeNamespace(document.RootElement, options);
        }

        internal static ModelToChangeNamespace DeserializeModelToChangeNamespace(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int requiredInt = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredInt"u8))
                {
                    requiredInt = property.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ModelToChangeNamespace(requiredInt, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ModelToChangeNamespace>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelToChangeNamespace>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ModelToChangeNamespace)} does not support writing '{options.Format}' format.");
            }
        }

        ModelToChangeNamespace IPersistableModel<ModelToChangeNamespace>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelToChangeNamespace>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeModelToChangeNamespace(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ModelToChangeNamespace)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ModelToChangeNamespace>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ModelToChangeNamespace FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeModelToChangeNamespace(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue<ModelToChangeNamespace>(this, new ModelReaderWriterOptions("W"));
            return content;
        }
    }
}
