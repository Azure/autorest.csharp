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
    public partial class DifferentSpreadModelDerived : IUtf8JsonSerializable, IJsonModel<DifferentSpreadModelDerived>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DifferentSpreadModelDerived>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<DifferentSpreadModelDerived>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DifferentSpreadModelDerived>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DifferentSpreadModelDerived)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("derivedProp"u8);
            writer.WriteObjectValue(DerivedProp, options);
            foreach (var item in AdditionalProperties)
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

        DifferentSpreadModelDerived IJsonModel<DifferentSpreadModelDerived>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DifferentSpreadModelDerived>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DifferentSpreadModelDerived)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDifferentSpreadModelDerived(document.RootElement, options);
        }

        internal static DifferentSpreadModelDerived DeserializeDifferentSpreadModelDerived(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ModelForRecord derivedProp = default;
            string knownProp = default;
            IDictionary<string, BinaryData> additionalProperties = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("derivedProp"u8))
                {
                    derivedProp = ModelForRecord.DeserializeModelForRecord(property.Value, options);
                    continue;
                }
                if (property.NameEquals("knownProp"u8))
                {
                    knownProp = property.Value.GetString();
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
            additionalProperties = additionalPropertiesDictionary;
            return new DifferentSpreadModelDerived(knownProp, additionalProperties, derivedProp);
        }

        BinaryData IPersistableModel<DifferentSpreadModelDerived>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DifferentSpreadModelDerived>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DifferentSpreadModelDerived)} does not support writing '{options.Format}' format.");
            }
        }

        DifferentSpreadModelDerived IPersistableModel<DifferentSpreadModelDerived>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DifferentSpreadModelDerived>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDifferentSpreadModelDerived(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DifferentSpreadModelDerived)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DifferentSpreadModelDerived>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new DifferentSpreadModelDerived FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDifferentSpreadModelDerived(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
