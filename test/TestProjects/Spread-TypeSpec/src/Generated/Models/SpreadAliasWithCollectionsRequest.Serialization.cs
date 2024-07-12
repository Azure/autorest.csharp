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

namespace SpreadTypeSpec.Models
{
    internal partial class SpreadAliasWithCollectionsRequest : IUtf8JsonSerializable, IJsonModel<SpreadAliasWithCollectionsRequest>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SpreadAliasWithCollectionsRequest>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<SpreadAliasWithCollectionsRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadAliasWithCollectionsRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SpreadAliasWithCollectionsRequest)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("requiredStringList"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredStringList)
            {
                writer.WriteStringValue(item);
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
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        SpreadAliasWithCollectionsRequest IJsonModel<SpreadAliasWithCollectionsRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadAliasWithCollectionsRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SpreadAliasWithCollectionsRequest)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSpreadAliasWithCollectionsRequest(document.RootElement, options);
        }

        internal static SpreadAliasWithCollectionsRequest DeserializeSpreadAliasWithCollectionsRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<string> requiredStringList = default;
            IReadOnlyList<string> optionalStringList = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredStringList"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    requiredStringList = array;
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
            return new SpreadAliasWithCollectionsRequest(requiredStringList, optionalStringList ?? new ChangeTrackingList<string>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<SpreadAliasWithCollectionsRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadAliasWithCollectionsRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(SpreadAliasWithCollectionsRequest)} does not support writing '{options.Format}' format.");
            }
        }

        SpreadAliasWithCollectionsRequest IPersistableModel<SpreadAliasWithCollectionsRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadAliasWithCollectionsRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeSpreadAliasWithCollectionsRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(SpreadAliasWithCollectionsRequest)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<SpreadAliasWithCollectionsRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static SpreadAliasWithCollectionsRequest FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeSpreadAliasWithCollectionsRequest(document.RootElement);
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
