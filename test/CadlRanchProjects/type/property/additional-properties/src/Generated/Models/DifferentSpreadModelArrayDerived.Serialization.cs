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
    public partial class DifferentSpreadModelArrayDerived : IUtf8JsonSerializable, IJsonModel<DifferentSpreadModelArrayDerived>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DifferentSpreadModelArrayDerived>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<DifferentSpreadModelArrayDerived>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DifferentSpreadModelArrayDerived>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DifferentSpreadModelArrayDerived)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("derivedProp"u8);
            writer.WriteStartArray();
            foreach (var item in DerivedProp)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStartArray();
                foreach (var item0 in item.Value)
                {
                    if (item0 == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item0);
#else
                    using (JsonDocument document = JsonDocument.Parse(item0))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                writer.WriteEndArray();
            }
        }

        DifferentSpreadModelArrayDerived IJsonModel<DifferentSpreadModelArrayDerived>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DifferentSpreadModelArrayDerived>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DifferentSpreadModelArrayDerived)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDifferentSpreadModelArrayDerived(document.RootElement, options);
        }

        internal static DifferentSpreadModelArrayDerived DeserializeDifferentSpreadModelArrayDerived(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<ModelForRecord> derivedProp = default;
            string knownProp = default;
            IDictionary<string, IList<BinaryData>> additionalProperties = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, IList<BinaryData>> additionalPropertiesDictionary = new Dictionary<string, IList<BinaryData>>();
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("derivedProp"u8))
                {
                    List<ModelForRecord> array = new List<ModelForRecord>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ModelForRecord.DeserializeModelForRecord(item, options));
                    }
                    derivedProp = array;
                    continue;
                }
                if (property.NameEquals("knownProp"u8))
                {
                    knownProp = property.Value.GetString();
                    continue;
                }
                if (property.Value.ValueKind == JsonValueKind.Array)
                {
                    List<BinaryData> array = new List<BinaryData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(BinaryData.FromString(item.GetRawText()));
                        }
                    }
                    additionalPropertiesDictionary.Add(property.Name, array);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            additionalProperties = additionalPropertiesDictionary;
            serializedAdditionalRawData = rawDataDictionary;
            return new DifferentSpreadModelArrayDerived(knownProp, additionalProperties, serializedAdditionalRawData, derivedProp);
        }

        BinaryData IPersistableModel<DifferentSpreadModelArrayDerived>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DifferentSpreadModelArrayDerived>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DifferentSpreadModelArrayDerived)} does not support writing '{options.Format}' format.");
            }
        }

        DifferentSpreadModelArrayDerived IPersistableModel<DifferentSpreadModelArrayDerived>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DifferentSpreadModelArrayDerived>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDifferentSpreadModelArrayDerived(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DifferentSpreadModelArrayDerived)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DifferentSpreadModelArrayDerived>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new DifferentSpreadModelArrayDerived FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDifferentSpreadModelArrayDerived(document.RootElement);
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
