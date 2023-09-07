// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class IndexingParameters : IUtf8JsonSerializable, IModelJsonSerializable<IndexingParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<IndexingParameters>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<IndexingParameters>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(BatchSize))
            {
                writer.WritePropertyName("batchSize"u8);
                writer.WriteNumberValue(BatchSize.Value);
            }
            if (Optional.IsDefined(MaxFailedItems))
            {
                writer.WritePropertyName("maxFailedItems"u8);
                writer.WriteNumberValue(MaxFailedItems.Value);
            }
            if (Optional.IsDefined(MaxFailedItemsPerBatch))
            {
                writer.WritePropertyName("maxFailedItemsPerBatch"u8);
                writer.WriteNumberValue(MaxFailedItemsPerBatch.Value);
            }
            if (Optional.IsCollectionDefined(Configuration))
            {
                writer.WritePropertyName("configuration"u8);
                writer.WriteStartObject();
                foreach (var item in Configuration)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (_serializedAdditionalRawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static IndexingParameters DeserializeIndexingParameters(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> batchSize = default;
            Optional<int> maxFailedItems = default;
            Optional<int> maxFailedItemsPerBatch = default;
            Optional<IDictionary<string, object>> configuration = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("batchSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    batchSize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxFailedItems"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxFailedItems = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxFailedItemsPerBatch"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxFailedItemsPerBatch = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("configuration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(property0.Name, null);
                        }
                        else
                        {
                            dictionary.Add(property0.Name, property0.Value.GetObject());
                        }
                    }
                    configuration = dictionary;
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new IndexingParameters(Optional.ToNullable(batchSize), Optional.ToNullable(maxFailedItems), Optional.ToNullable(maxFailedItemsPerBatch), Optional.ToDictionary(configuration), serializedAdditionalRawData);
        }

        IndexingParameters IModelJsonSerializable<IndexingParameters>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeIndexingParameters(doc.RootElement, options);
        }

        BinaryData IModelSerializable<IndexingParameters>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        IndexingParameters IModelSerializable<IndexingParameters>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeIndexingParameters(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="IndexingParameters"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="IndexingParameters"/> to convert. </param>
        public static implicit operator RequestContent(IndexingParameters model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="IndexingParameters"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator IndexingParameters(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeIndexingParameters(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
