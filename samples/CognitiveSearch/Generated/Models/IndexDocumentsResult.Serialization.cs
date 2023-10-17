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
    public partial class IndexDocumentsResult : IUtf8JsonSerializable, IModelJsonSerializable<IndexDocumentsResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<IndexDocumentsResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<IndexDocumentsResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("value"u8);
                writer.WriteStartArray();
                foreach (var item in Results)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        IndexDocumentsResult IModelJsonSerializable<IndexDocumentsResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIndexDocumentsResult(document.RootElement, options);
        }

        BinaryData IModelSerializable<IndexDocumentsResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        IndexDocumentsResult IModelSerializable<IndexDocumentsResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeIndexDocumentsResult(document.RootElement, options);
        }

        internal static IndexDocumentsResult DeserializeIndexDocumentsResult(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<IndexingResult> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<IndexingResult> array = new List<IndexingResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(IndexingResult.DeserializeIndexingResult(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new IndexDocumentsResult(value);
        }
    }
}
