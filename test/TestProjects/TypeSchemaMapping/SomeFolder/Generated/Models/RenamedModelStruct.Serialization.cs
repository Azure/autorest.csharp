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
using NamespaceForEnums;
using TypeSchemaMapping;

namespace CustomNamespace
{
    internal partial struct RenamedModelStruct : IUtf8JsonSerializable, IJsonModel<RenamedModelStruct>, IJsonModel<object>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RenamedModelStruct>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<RenamedModelStruct>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RenamedModelStruct>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RenamedModelStruct)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("ModelProperty"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(CustomizedFlattenedStringProperty))
            {
                writer.WritePropertyName("ModelProperty"u8);
                writer.WriteStringValue(CustomizedFlattenedStringProperty);
            }
            if (Optional.IsDefined(PropertyToField))
            {
                writer.WritePropertyName("PropertyToField"u8);
                writer.WriteStringValue(PropertyToField);
            }
            if (Optional.IsDefined(Fruit))
            {
                writer.WritePropertyName("Fruit"u8);
                writer.WriteStringValue(Fruit.Value.ToSerialString());
            }
            if (Optional.IsDefined(DaysOfWeek))
            {
                writer.WritePropertyName("DaysOfWeek"u8);
                writer.WriteStringValue(DaysOfWeek.Value.ToString());
            }
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

        RenamedModelStruct IJsonModel<RenamedModelStruct>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RenamedModelStruct>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RenamedModelStruct)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRenamedModelStruct(document.RootElement, options);
        }

        void IJsonModel<object>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<RenamedModelStruct>)this).Write(writer, options);

        object IJsonModel<object>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<RenamedModelStruct>)this).Create(ref reader, options);

        internal static RenamedModelStruct DeserializeRenamedModelStruct(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            string modelProperty = default;
            string propertyToField = default;
            CustomFruitEnum? fruit = default;
            CustomDaysOfWeek? daysOfWeek = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("ModelProperty"u8))
                        {
                            modelProperty = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("PropertyToField"u8))
                        {
                            propertyToField = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("Fruit"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            fruit = property0.Value.GetString().ToCustomFruitEnum();
                            continue;
                        }
                        if (property0.NameEquals("DaysOfWeek"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            daysOfWeek = new CustomDaysOfWeek(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new RenamedModelStruct(modelProperty, propertyToField, fruit, daysOfWeek, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<RenamedModelStruct>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RenamedModelStruct>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RenamedModelStruct)} does not support writing '{options.Format}' format.");
            }
        }

        RenamedModelStruct IPersistableModel<RenamedModelStruct>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RenamedModelStruct>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRenamedModelStruct(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RenamedModelStruct)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RenamedModelStruct>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<object>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<RenamedModelStruct>)this).Write(options);

        object IPersistableModel<object>.Create(BinaryData data, ModelReaderWriterOptions options) => ((IPersistableModel<RenamedModelStruct>)this).Create(data, options);

        string IPersistableModel<object>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<RenamedModelStruct>)this).GetFormatFromOptions(options);

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static RenamedModelStruct FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRenamedModelStruct(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
