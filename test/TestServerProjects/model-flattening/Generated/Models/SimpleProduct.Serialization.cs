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
    public partial class SimpleProduct : IUtf8JsonSerializable, IJsonModel<SimpleProduct>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SimpleProduct>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<SimpleProduct>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SimpleProduct>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SimpleProduct)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("base_product_id"u8);
            writer.WriteStringValue(ProductId);
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("base_product_description"u8);
                writer.WriteStringValue(Description);
            }
            writer.WritePropertyName("details"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(MaxProductDisplayName))
            {
                writer.WritePropertyName("max_product_display_name"u8);
                writer.WriteStringValue(MaxProductDisplayName);
            }
            if (Optional.IsDefined(Capacity))
            {
                writer.WritePropertyName("max_product_capacity"u8);
                writer.WriteStringValue(Capacity.Value.ToString());
            }
            writer.WritePropertyName("max_product_image"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(GenericValue))
            {
                writer.WritePropertyName("generic_value"u8);
                writer.WriteStringValue(GenericValue);
            }
            if (Optional.IsDefined(OdataValue))
            {
                writer.WritePropertyName("@odata.value"u8);
                writer.WriteStringValue(OdataValue);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
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

        SimpleProduct IJsonModel<SimpleProduct>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SimpleProduct>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SimpleProduct)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSimpleProduct(document.RootElement, options);
        }

        internal static SimpleProduct DeserializeSimpleProduct(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string baseProductId = default;
            Optional<string> baseProductDescription = default;
            Optional<string> maxProductDisplayName = default;
            Optional<SimpleProductPropertiesMaxProductCapacity> maxProductCapacity = default;
            Optional<string> genericValue = default;
            Optional<string> odataValue = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("base_product_id"u8))
                {
                    baseProductId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("base_product_description"u8))
                {
                    baseProductDescription = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("details"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("max_product_display_name"u8))
                        {
                            maxProductDisplayName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("max_product_capacity"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            maxProductCapacity = new SimpleProductPropertiesMaxProductCapacity(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("max_product_image"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            foreach (var property1 in property0.Value.EnumerateObject())
                            {
                                if (property1.NameEquals("generic_value"u8))
                                {
                                    genericValue = property1.Value.GetString();
                                    continue;
                                }
                                if (property1.NameEquals("@odata.value"u8))
                                {
                                    odataValue = property1.Value.GetString();
                                    continue;
                                }
                            }
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new SimpleProduct(baseProductId, baseProductDescription.Value, serializedAdditionalRawData, maxProductDisplayName.Value, Optional.ToNullable(maxProductCapacity), genericValue.Value, odataValue.Value);
        }

        BinaryData IPersistableModel<SimpleProduct>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SimpleProduct>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(SimpleProduct)} does not support '{options.Format}' format.");
            }
        }

        SimpleProduct IPersistableModel<SimpleProduct>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SimpleProduct>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeSimpleProduct(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(SimpleProduct)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<SimpleProduct>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
