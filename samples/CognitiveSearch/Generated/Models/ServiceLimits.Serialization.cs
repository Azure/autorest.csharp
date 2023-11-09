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

namespace CognitiveSearch.Models
{
    public partial class ServiceLimits : IUtf8JsonSerializable, IJsonModel<ServiceLimits>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ServiceLimits>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<ServiceLimits>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<ServiceLimits>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json || options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<ServiceLimits>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(MaxFieldsPerIndex))
            {
                if (MaxFieldsPerIndex != null)
                {
                    writer.WritePropertyName("maxFieldsPerIndex"u8);
                    writer.WriteNumberValue(MaxFieldsPerIndex.Value);
                }
                else
                {
                    writer.WriteNull("maxFieldsPerIndex");
                }
            }
            if (Optional.IsDefined(MaxFieldNestingDepthPerIndex))
            {
                if (MaxFieldNestingDepthPerIndex != null)
                {
                    writer.WritePropertyName("maxFieldNestingDepthPerIndex"u8);
                    writer.WriteNumberValue(MaxFieldNestingDepthPerIndex.Value);
                }
                else
                {
                    writer.WriteNull("maxFieldNestingDepthPerIndex");
                }
            }
            if (Optional.IsDefined(MaxComplexCollectionFieldsPerIndex))
            {
                if (MaxComplexCollectionFieldsPerIndex != null)
                {
                    writer.WritePropertyName("maxComplexCollectionFieldsPerIndex"u8);
                    writer.WriteNumberValue(MaxComplexCollectionFieldsPerIndex.Value);
                }
                else
                {
                    writer.WriteNull("maxComplexCollectionFieldsPerIndex");
                }
            }
            if (Optional.IsDefined(MaxComplexObjectsInCollectionsPerDocument))
            {
                if (MaxComplexObjectsInCollectionsPerDocument != null)
                {
                    writer.WritePropertyName("maxComplexObjectsInCollectionsPerDocument"u8);
                    writer.WriteNumberValue(MaxComplexObjectsInCollectionsPerDocument.Value);
                }
                else
                {
                    writer.WriteNull("maxComplexObjectsInCollectionsPerDocument");
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

        ServiceLimits IJsonModel<ServiceLimits>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ServiceLimits)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeServiceLimits(document.RootElement, options);
        }

        internal static ServiceLimits DeserializeServiceLimits(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int?> maxFieldsPerIndex = default;
            Optional<int?> maxFieldNestingDepthPerIndex = default;
            Optional<int?> maxComplexCollectionFieldsPerIndex = default;
            Optional<int?> maxComplexObjectsInCollectionsPerDocument = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxFieldsPerIndex"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxFieldsPerIndex = null;
                        continue;
                    }
                    maxFieldsPerIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxFieldNestingDepthPerIndex"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxFieldNestingDepthPerIndex = null;
                        continue;
                    }
                    maxFieldNestingDepthPerIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxComplexCollectionFieldsPerIndex"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxComplexCollectionFieldsPerIndex = null;
                        continue;
                    }
                    maxComplexCollectionFieldsPerIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxComplexObjectsInCollectionsPerDocument"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxComplexObjectsInCollectionsPerDocument = null;
                        continue;
                    }
                    maxComplexObjectsInCollectionsPerDocument = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ServiceLimits(Optional.ToNullable(maxFieldsPerIndex), Optional.ToNullable(maxFieldNestingDepthPerIndex), Optional.ToNullable(maxComplexCollectionFieldsPerIndex), Optional.ToNullable(maxComplexObjectsInCollectionsPerDocument), serializedAdditionalRawData);
        }

        BinaryData IModel<ServiceLimits>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ServiceLimits)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        ServiceLimits IModel<ServiceLimits>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ServiceLimits)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeServiceLimits(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<ServiceLimits>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
