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
    public partial class BlobRestoreContent : IUtf8JsonSerializable, IModelJsonSerializable<BlobRestoreContent>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<BlobRestoreContent>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<BlobRestoreContent>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("timeToRestore"u8);
            writer.WriteStringValue(TimeToRestore, "O");
            writer.WritePropertyName("blobRanges"u8);
            writer.WriteStartArray();
            foreach (var item in BlobRanges)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        BlobRestoreContent IModelJsonSerializable<BlobRestoreContent>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBlobRestoreContent(document.RootElement, options);
        }

        BinaryData IModelSerializable<BlobRestoreContent>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        BlobRestoreContent IModelSerializable<BlobRestoreContent>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeBlobRestoreContent(document.RootElement, options);
        }

        internal static BlobRestoreContent DeserializeBlobRestoreContent(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DateTimeOffset timeToRestore = default;
            IList<BlobRestoreRange> blobRanges = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("timeToRestore"u8))
                {
                    timeToRestore = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("blobRanges"u8))
                {
                    List<BlobRestoreRange> array = new List<BlobRestoreRange>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(BlobRestoreRange.DeserializeBlobRestoreRange(item));
                    }
                    blobRanges = array;
                    continue;
                }
            }
            return new BlobRestoreContent(timeToRestore, blobRanges);
        }
    }
}
