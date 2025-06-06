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
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MixedTypesCases>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MixedTypesCases)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("model"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Model);
#else
            using (JsonDocument document = JsonDocument.Parse(Model, ModelSerializationExtensions.JsonDocumentOptions))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            writer.WritePropertyName("literal"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Literal);
#else
            using (JsonDocument document = JsonDocument.Parse(Literal, ModelSerializationExtensions.JsonDocumentOptions))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            writer.WritePropertyName("int"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Int);
#else
            using (JsonDocument document = JsonDocument.Parse(Int, ModelSerializationExtensions.JsonDocumentOptions))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            writer.WritePropertyName("boolean"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Boolean);
#else
            using (JsonDocument document = JsonDocument.Parse(Boolean, ModelSerializationExtensions.JsonDocumentOptions))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            writer.WritePropertyName("array"u8);
            writer.WriteStartArray();
            foreach (var item in Array)
            {
                if (item == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item);
#else
                using (JsonDocument document = JsonDocument.Parse(item, ModelSerializationExtensions.JsonDocumentOptions))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            writer.WriteEndArray();
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
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
            IList<BinaryData> array = default;
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
                if (property.NameEquals("array"u8))
                {
                    List<BinaryData> array0 = new List<BinaryData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array0.Add(null);
                        }
                        else
                        {
                            array0.Add(BinaryData.FromString(item.GetRawText()));
                        }
                    }
                    array = array0;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new MixedTypesCases(
                model,
                literal,
                @int,
                boolean,
                array,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MixedTypesCases>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MixedTypesCases>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, _TypeUnionContext.Default);
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
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
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
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
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
