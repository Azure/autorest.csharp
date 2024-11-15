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

namespace _Type.Property.Nullable.Models
{
    public partial class CollectionsModelProperty : IUtf8JsonSerializable, IJsonModel<CollectionsModelProperty>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<CollectionsModelProperty>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<CollectionsModelProperty>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CollectionsModelProperty>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CollectionsModelProperty)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("requiredProperty"u8);
            writer.WriteStringValue(RequiredProperty);
            if (NullableProperty != null && Optional.IsCollectionDefined(NullableProperty))
            {
                writer.WritePropertyName("nullableProperty"u8);
                writer.WriteStartArray();
                foreach (var item in NullableProperty)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("nullableProperty");
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
        }

        CollectionsModelProperty IJsonModel<CollectionsModelProperty>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CollectionsModelProperty>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CollectionsModelProperty)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCollectionsModelProperty(document.RootElement, options);
        }

        internal static CollectionsModelProperty DeserializeCollectionsModelProperty(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredProperty = default;
            IReadOnlyList<InnerModel> nullableProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredProperty"u8))
                {
                    requiredProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("nullableProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nullableProperty = new ChangeTrackingList<InnerModel>();
                        continue;
                    }
                    List<InnerModel> array = new List<InnerModel>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InnerModel.DeserializeInnerModel(item, options));
                    }
                    nullableProperty = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new CollectionsModelProperty(requiredProperty, nullableProperty, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CollectionsModelProperty>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CollectionsModelProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(CollectionsModelProperty)} does not support writing '{options.Format}' format.");
            }
        }

        CollectionsModelProperty IPersistableModel<CollectionsModelProperty>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CollectionsModelProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCollectionsModelProperty(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CollectionsModelProperty)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CollectionsModelProperty>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static CollectionsModelProperty FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCollectionsModelProperty(document.RootElement);
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
