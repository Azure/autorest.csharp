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
    public partial class BlobRestoreStatus : IUtf8JsonSerializable, IModelJsonSerializable<BlobRestoreStatus>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<BlobRestoreStatus>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<BlobRestoreStatus>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.Value.ToString());
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(FailureReason))
            {
                writer.WritePropertyName("failureReason"u8);
                writer.WriteStringValue(FailureReason);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(RestoreId))
            {
                writer.WritePropertyName("restoreId"u8);
                writer.WriteStringValue(RestoreId);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Parameters))
            {
                writer.WritePropertyName("parameters"u8);
                writer.WriteObjectValue(Parameters);
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        BlobRestoreStatus IModelJsonSerializable<BlobRestoreStatus>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBlobRestoreStatus(document.RootElement, options);
        }

        internal static BlobRestoreStatus DeserializeBlobRestoreStatus(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<BlobRestoreProgressStatus> status = default;
            Optional<string> failureReason = default;
            Optional<string> restoreId = default;
            Optional<BlobRestoreContent> parameters = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = new BlobRestoreProgressStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("failureReason"u8))
                {
                    failureReason = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("restoreId"u8))
                {
                    restoreId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("parameters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    parameters = BlobRestoreContent.DeserializeBlobRestoreContent(property.Value);
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new BlobRestoreStatus(Optional.ToNullable(status), failureReason.Value, restoreId.Value, parameters.Value, serializedAdditionalRawData);
        }

        BinaryData IModelSerializable<BlobRestoreStatus>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        BlobRestoreStatus IModelSerializable<BlobRestoreStatus>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeBlobRestoreStatus(document.RootElement, options);
        }
    }
}
