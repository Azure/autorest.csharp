// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class StorageSkuListResult : IUtf8JsonSerializable, IModelJsonSerializable<StorageSkuListResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<StorageSkuListResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<StorageSkuListResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        StorageSkuListResult IModelJsonSerializable<StorageSkuListResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeStorageSkuListResult(doc.RootElement, options);
        }

        BinaryData IModelSerializable<StorageSkuListResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        StorageSkuListResult IModelSerializable<StorageSkuListResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeStorageSkuListResult(document.RootElement, options);
        }

        internal static StorageSkuListResult DeserializeStorageSkuListResult(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<StorageSkuInformation>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<StorageSkuInformation> array = new List<StorageSkuInformation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(StorageSkuInformation.DeserializeStorageSkuInformation(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new StorageSkuListResult(Optional.ToList(value));
        }
    }
}
