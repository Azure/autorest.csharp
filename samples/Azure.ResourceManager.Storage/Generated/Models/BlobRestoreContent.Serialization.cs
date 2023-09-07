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

namespace Azure.ResourceManager.Storage.Models
{
    public partial class BlobRestoreContent : IUtf8JsonSerializable, IModelJsonSerializable<BlobRestoreContent>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<BlobRestoreContent>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<BlobRestoreContent>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("timeToRestore"u8);
            writer.WriteStringValue(TimeToRestore, "O");
            writer.WritePropertyName("blobRanges"u8);
            writer.WriteStartArray();
            foreach (var item in BlobRanges)
            {
                if (item is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<BlobRestoreRange>)item).Serialize(writer, options);
                }
            }
            writer.WriteEndArray();
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

        internal static BlobRestoreContent DeserializeBlobRestoreContent(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DateTimeOffset timeToRestore = default;
            IList<BlobRestoreRange> blobRanges = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
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
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new BlobRestoreContent(timeToRestore, blobRanges, serializedAdditionalRawData);
        }

        BlobRestoreContent IModelJsonSerializable<BlobRestoreContent>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeBlobRestoreContent(doc.RootElement, options);
        }

        BinaryData IModelSerializable<BlobRestoreContent>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        BlobRestoreContent IModelSerializable<BlobRestoreContent>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeBlobRestoreContent(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="BlobRestoreContent"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="BlobRestoreContent"/> to convert. </param>
        public static implicit operator RequestContent(BlobRestoreContent model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="BlobRestoreContent"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator BlobRestoreContent(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeBlobRestoreContent(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
