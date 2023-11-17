// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    internal partial class ModelWithArrayOfEnum : IUtf8JsonSerializable, IJsonModel<ModelWithArrayOfEnum>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelWithArrayOfEnum>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ModelWithArrayOfEnum>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<ModelWithArrayOfEnum>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<ModelWithArrayOfEnum>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(ArrayOfEnum))
            {
                writer.WritePropertyName("ArrayOfEnum"u8);
                writer.WriteStartArray();
                foreach (var item in ArrayOfEnum)
                {
                    writer.WriteStringValue(item.ToSerialString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ArrayOfEnumCustomizedToNullable))
            {
                writer.WritePropertyName("ArrayOfEnumCustomizedToNullable"u8);
                writer.WriteStartArray();
                foreach (var item in ArrayOfEnumCustomizedToNullable)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteStringValue(item.Value.ToSerialString());
                }
                writer.WriteEndArray();
            }
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        ModelWithArrayOfEnum IJsonModel<ModelWithArrayOfEnum>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithArrayOfEnum)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelWithArrayOfEnum(document.RootElement, options);
        }

        internal static ModelWithArrayOfEnum DeserializeModelWithArrayOfEnum(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<EnumForModelWithArrayOfEnum>> arrayOfEnum = default;
            Optional<IReadOnlyList<EnumForModelWithArrayOfEnum?>> arrayOfEnumCustomizedToNullable = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ArrayOfEnum"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<EnumForModelWithArrayOfEnum> array = new List<EnumForModelWithArrayOfEnum>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString().ToEnumForModelWithArrayOfEnum());
                    }
                    arrayOfEnum = array;
                    continue;
                }
                if (property.NameEquals("ArrayOfEnumCustomizedToNullable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<EnumForModelWithArrayOfEnum?> array = new List<EnumForModelWithArrayOfEnum?>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(item.GetString().ToEnumForModelWithArrayOfEnum());
                        }
                    }
                    arrayOfEnumCustomizedToNullable = array;
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ModelWithArrayOfEnum(Optional.ToList(arrayOfEnum), Optional.ToList(arrayOfEnumCustomizedToNullable), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ModelWithArrayOfEnum>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithArrayOfEnum)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        ModelWithArrayOfEnum IPersistableModel<ModelWithArrayOfEnum>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithArrayOfEnum)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeModelWithArrayOfEnum(document.RootElement, options);
        }

        string IPersistableModel<ModelWithArrayOfEnum>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
