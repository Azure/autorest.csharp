// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace ModelShapes.Models
{
    public partial class MixedModelWithReadonlyProperty : IUtf8JsonSerializable, IJsonModel<MixedModelWithReadonlyProperty>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MixedModelWithReadonlyProperty>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<MixedModelWithReadonlyProperty>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(ReadonlyProperty))
                {
                    writer.WritePropertyName("ReadonlyProperty"u8);
                    writer.WriteObjectValue(ReadonlyProperty);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsCollectionDefined(ReadonlyListProperty))
                {
                    writer.WritePropertyName("ReadonlyListProperty"u8);
                    writer.WriteStartArray();
                    foreach (var item in ReadonlyListProperty)
                    {
                        writer.WriteObjectValue(item);
                    }
                    writer.WriteEndArray();
                }
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
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

        MixedModelWithReadonlyProperty IJsonModel<MixedModelWithReadonlyProperty>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMixedModelWithReadonlyProperty(document.RootElement, options);
        }

        internal static MixedModelWithReadonlyProperty DeserializeMixedModelWithReadonlyProperty(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ReadonlyModel> readonlyProperty = default;
            Optional<IReadOnlyList<ReadonlyModel>> readonlyListProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ReadonlyProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    readonlyProperty = ReadonlyModel.DeserializeReadonlyModel(property.Value);
                    continue;
                }
                if (property.NameEquals("ReadonlyListProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ReadonlyModel> array = new List<ReadonlyModel>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ReadonlyModel.DeserializeReadonlyModel(item));
                    }
                    readonlyListProperty = array;
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new MixedModelWithReadonlyProperty(readonlyProperty.Value, Optional.ToList(readonlyListProperty), serializedAdditionalRawData);
        }

        BinaryData IModel<MixedModelWithReadonlyProperty>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return ModelReaderWriter.WriteCore(this, options);
        }

        MixedModelWithReadonlyProperty IModel<MixedModelWithReadonlyProperty>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeMixedModelWithReadonlyProperty(document.RootElement, options);
        }
    }
}
