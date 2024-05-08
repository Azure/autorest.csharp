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

namespace _Type.Property.AdditionalProperties.Models
{
    public partial class DifferentSpreadModelArrayRecord : IUtf8JsonSerializable, IJsonModel<DifferentSpreadModelArrayRecord>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DifferentSpreadModelArrayRecord>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<DifferentSpreadModelArrayRecord>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DifferentSpreadModelArrayRecord>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DifferentSpreadModelArrayRecord)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("knownProp"u8);
            writer.WriteStringValue(KnownProp);
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStartArray();
                foreach (var item0 in item.Value)
                {
                    writer.WriteObjectValue(item0, options);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        DifferentSpreadModelArrayRecord IJsonModel<DifferentSpreadModelArrayRecord>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DifferentSpreadModelArrayRecord>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DifferentSpreadModelArrayRecord)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDifferentSpreadModelArrayRecord(document.RootElement, options);
        }

        internal static DifferentSpreadModelArrayRecord DeserializeDifferentSpreadModelArrayRecord(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string knownProp = default;
            IDictionary<string, IList<ModelForRecord>> additionalProperties = default;
            Dictionary<string, IList<ModelForRecord>> additionalPropertiesDictionary = new Dictionary<string, IList<ModelForRecord>>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("knownProp"u8))
                {
                    knownProp = property.Value.GetString();
                    continue;
                }
                List<ModelForRecord> array = new List<ModelForRecord>();
                foreach (var item in property.Value.EnumerateArray())
                {
                    array.Add(ModelForRecord.DeserializeModelForRecord(item, options));
                }
                additionalPropertiesDictionary.Add(property.Name, array);
            }
            additionalProperties = additionalPropertiesDictionary;
            return new DifferentSpreadModelArrayRecord(knownProp, additionalProperties);
        }

        BinaryData IPersistableModel<DifferentSpreadModelArrayRecord>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DifferentSpreadModelArrayRecord>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DifferentSpreadModelArrayRecord)} does not support writing '{options.Format}' format.");
            }
        }

        DifferentSpreadModelArrayRecord IPersistableModel<DifferentSpreadModelArrayRecord>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DifferentSpreadModelArrayRecord>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDifferentSpreadModelArrayRecord(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DifferentSpreadModelArrayRecord)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DifferentSpreadModelArrayRecord>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static DifferentSpreadModelArrayRecord FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDifferentSpreadModelArrayRecord(document.RootElement);
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
