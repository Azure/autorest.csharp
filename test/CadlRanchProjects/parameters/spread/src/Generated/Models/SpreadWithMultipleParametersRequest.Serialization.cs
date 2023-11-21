// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Parameters.Spread.Models
{
    internal partial class SpreadWithMultipleParametersRequest : IUtf8JsonSerializable, IJsonModel<SpreadWithMultipleParametersRequest>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SpreadWithMultipleParametersRequest>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<SpreadWithMultipleParametersRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadWithMultipleParametersRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(SpreadWithMultipleParametersRequest)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("prop1"u8);
            writer.WriteStringValue(Prop1);
            writer.WritePropertyName("prop2"u8);
            writer.WriteStringValue(Prop2);
            writer.WritePropertyName("prop3"u8);
            writer.WriteStringValue(Prop3);
            writer.WritePropertyName("prop4"u8);
            writer.WriteStringValue(Prop4);
            writer.WritePropertyName("prop5"u8);
            writer.WriteStringValue(Prop5);
            writer.WritePropertyName("prop6"u8);
            writer.WriteStringValue(Prop6);
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

        SpreadWithMultipleParametersRequest IJsonModel<SpreadWithMultipleParametersRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadWithMultipleParametersRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(SpreadWithMultipleParametersRequest)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSpreadWithMultipleParametersRequest(document.RootElement, options);
        }

        internal static SpreadWithMultipleParametersRequest DeserializeSpreadWithMultipleParametersRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string prop1 = default;
            string prop2 = default;
            string prop3 = default;
            string prop4 = default;
            string prop5 = default;
            string prop6 = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("prop1"u8))
                {
                    prop1 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("prop2"u8))
                {
                    prop2 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("prop3"u8))
                {
                    prop3 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("prop4"u8))
                {
                    prop4 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("prop5"u8))
                {
                    prop5 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("prop6"u8))
                {
                    prop6 = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new SpreadWithMultipleParametersRequest(prop1, prop2, prop3, prop4, prop5, prop6, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<SpreadWithMultipleParametersRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadWithMultipleParametersRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(SpreadWithMultipleParametersRequest)} does not support '{options.Format}' format.");
            }
        }

        SpreadWithMultipleParametersRequest IPersistableModel<SpreadWithMultipleParametersRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadWithMultipleParametersRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeSpreadWithMultipleParametersRequest(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(SpreadWithMultipleParametersRequest)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<SpreadWithMultipleParametersRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static SpreadWithMultipleParametersRequest FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeSpreadWithMultipleParametersRequest(document.RootElement, new ModelReaderWriterOptions("W"));
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
