// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class IndexingParameters : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
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
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeIndexingParameters(doc.RootElement, options);
        }

        internal static IndexingParameters DeserializeIndexingParameters(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> batchSize = default;
            Optional<int> maxFailedItems = default;
            Optional<int> maxFailedItemsPerBatch = default;
            Optional<IDictionary<string, object>> configuration = default;
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
            }
            return new IndexingParameters(Optional.ToNullable(batchSize), Optional.ToNullable(maxFailedItems), Optional.ToNullable(maxFailedItemsPerBatch), Optional.ToDictionary(configuration));
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeIndexingParameters(doc.RootElement, options);
        }
    }
}
