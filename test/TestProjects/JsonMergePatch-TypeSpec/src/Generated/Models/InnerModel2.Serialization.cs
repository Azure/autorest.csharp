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
    public partial class InnerModel2 : IUtf8JsonSerializable, IJsonModel<InnerModel2>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<InnerModel2>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<InnerModel2>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InnerModel2>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InnerModel2)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Property1))
            {
                writer.WritePropertyName("property1"u8);
                writer.WriteNumberValue(Property1.Value);
            }
            if (Optional.IsDefined(Property2))
            {
                writer.WritePropertyName("property2"u8);
                writer.WriteNumberValue(Property2.Value);
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

        private void WritePatch(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (_property1changed)
            {
                writer.WritePropertyName("property1"u8);
                if (Property1 != null)
                {
                    writer.WriteNumberValue(Property1.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }
            }
            if (_property2changed)
            {
                writer.WritePropertyName("property2"u8);
                if (Property2 != null)
                {
                    writer.WriteNumberValue(Property2.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }
            }
        }

        InnerModel2 IJsonModel<InnerModel2>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InnerModel2>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InnerModel2)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInnerModel2(document.RootElement, options);
        }

        internal static InnerModel2 DeserializeInnerModel2(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> property1 = default;
            Optional<int> property2 = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("property1"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    property1 = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("property2"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    property2 = property.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new InnerModel2(Optional.ToNullable(property1), Optional.ToNullable(property2), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InnerModel2>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InnerModel2>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InnerModel2)} does not support '{options.Format}' format.");
            }
        }

        InnerModel2 IPersistableModel<InnerModel2>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InnerModel2>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInnerModel2(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InnerModel2)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<InnerModel2>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static InnerModel2 FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInnerModel2(document.RootElement);
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