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

namespace Parameters.Spread.Models
{
    internal partial class SpreadWithMultipleParametersRequest : IUtf8JsonSerializable, IJsonModel<SpreadWithMultipleParametersRequest>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SpreadWithMultipleParametersRequest>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<SpreadWithMultipleParametersRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadWithMultipleParametersRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SpreadWithMultipleParametersRequest)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("requiredString"u8);
            writer.WriteStringValue(RequiredString);
            if (Optional.IsDefined(OptionalInt))
            {
                writer.WritePropertyName("optionalInt"u8);
                writer.WriteNumberValue(OptionalInt.Value);
            }
            writer.WritePropertyName("requiredIntList"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredIntList)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsCollectionDefined(OptionalStringList))
            {
                writer.WritePropertyName("optionalStringList"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
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

        SpreadWithMultipleParametersRequest IJsonModel<SpreadWithMultipleParametersRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadWithMultipleParametersRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SpreadWithMultipleParametersRequest)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSpreadWithMultipleParametersRequest(document.RootElement, options);
        }

        internal static SpreadWithMultipleParametersRequest DeserializeSpreadWithMultipleParametersRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredString = default;
            int? optionalInt = default;
            IReadOnlyList<int> requiredIntList = default;
            IReadOnlyList<string> optionalStringList = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredString"u8))
                {
                    requiredString = property.Value.GetString();
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
                if (property.NameEquals("requiredIntList"u8))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    requiredIntList = array;
                    continue;
                }
                if (property.NameEquals("optionalStringList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    optionalStringList = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new SpreadWithMultipleParametersRequest(requiredString, optionalInt, requiredIntList, optionalStringList ?? new ChangeTrackingList<string>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<SpreadWithMultipleParametersRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadWithMultipleParametersRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, ParametersSpreadContext.Default);
                default:
                    throw new FormatException($"The model {nameof(SpreadWithMultipleParametersRequest)} does not support writing '{options.Format}' format.");
            }
        }

        SpreadWithMultipleParametersRequest IPersistableModel<SpreadWithMultipleParametersRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadWithMultipleParametersRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeSpreadWithMultipleParametersRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(SpreadWithMultipleParametersRequest)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<SpreadWithMultipleParametersRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static SpreadWithMultipleParametersRequest FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeSpreadWithMultipleParametersRequest(document.RootElement);
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
