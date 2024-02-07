// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace model_flattening.Models
{
    public partial class ResourceCollection : IUtf8JsonSerializable, IJsonModel<ResourceCollection>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ResourceCollection>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ResourceCollection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ResourceCollection>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ResourceCollection)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Productresource))
            {
                writer.WritePropertyName("productresource"u8);
                BinaryData data = ModelReaderWriter.Write(Productresource, options);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(data);
#else
                using (JsonDocument document = JsonDocument.Parse(data))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (Optional.IsCollectionDefined(Arrayofresources))
            {
                writer.WritePropertyName("arrayofresources"u8);
                writer.WriteStartArray();
                foreach (var item in Arrayofresources)
                {
                    BinaryData data = ModelReaderWriter.Write(item, options);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(data);
#else
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Dictionaryofresources))
            {
                writer.WritePropertyName("dictionaryofresources"u8);
                writer.WriteStartObject();
                foreach (var item in Dictionaryofresources)
                {
                    writer.WritePropertyName(item.Key);
                    BinaryData data = ModelReaderWriter.Write(item.Value, options);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(data);
#else
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                writer.WriteEndObject();
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

        ResourceCollection IJsonModel<ResourceCollection>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ResourceCollection>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ResourceCollection)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeResourceCollection(document.RootElement, options);
        }

        internal static ResourceCollection DeserializeResourceCollection(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<FlattenedProduct> productresource = default;
            Optional<IList<FlattenedProduct>> arrayofresources = default;
            Optional<IDictionary<string, FlattenedProduct>> dictionaryofresources = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("productresource"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    productresource = FlattenedProduct.DeserializeFlattenedProduct(property.Value);
                    continue;
                }
                if (property.NameEquals("arrayofresources"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FlattenedProduct> array = new List<FlattenedProduct>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FlattenedProduct.DeserializeFlattenedProduct(item));
                    }
                    arrayofresources = array;
                    continue;
                }
                if (property.NameEquals("dictionaryofresources"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, FlattenedProduct> dictionary = new Dictionary<string, FlattenedProduct>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, FlattenedProduct.DeserializeFlattenedProduct(property0.Value));
                    }
                    dictionaryofresources = dictionary;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ResourceCollection(productresource.Value, Optional.ToList(arrayofresources), Optional.ToDictionary(dictionaryofresources), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ResourceCollection>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ResourceCollection>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ResourceCollection)} does not support '{options.Format}' format.");
            }
        }

        ResourceCollection IPersistableModel<ResourceCollection>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ResourceCollection>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeResourceCollection(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ResourceCollection)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ResourceCollection>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
