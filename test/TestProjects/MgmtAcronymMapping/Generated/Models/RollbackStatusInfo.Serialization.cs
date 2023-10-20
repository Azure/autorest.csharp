// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtAcronymMapping.Models
{
    public partial class RollbackStatusInfo : IUtf8JsonSerializable, IModelJsonSerializable<RollbackStatusInfo>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<RollbackStatusInfo>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<RollbackStatusInfo>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(SuccessfullyRolledbackInstanceCount))
            {
                writer.WritePropertyName("successfullyRolledbackInstanceCount"u8);
                writer.WriteNumberValue(SuccessfullyRolledbackInstanceCount.Value);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(FailedRolledbackInstanceCount))
            {
                writer.WritePropertyName("failedRolledbackInstanceCount"u8);
                writer.WriteNumberValue(FailedRolledbackInstanceCount.Value);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(RollbackError))
            {
                writer.WritePropertyName("rollbackError"u8);
                writer.WriteObjectValue(RollbackError);
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

        RollbackStatusInfo IModelJsonSerializable<RollbackStatusInfo>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRollbackStatusInfo(document.RootElement, options);
        }

        BinaryData IModelSerializable<RollbackStatusInfo>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        RollbackStatusInfo IModelSerializable<RollbackStatusInfo>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeRollbackStatusInfo(document.RootElement, options);
        }

        internal static RollbackStatusInfo DeserializeRollbackStatusInfo(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> successfullyRolledbackInstanceCount = default;
            Optional<int> failedRolledbackInstanceCount = default;
            Optional<ApiError> rollbackError = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("successfullyRolledbackInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    successfullyRolledbackInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("failedRolledbackInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    failedRolledbackInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("rollbackError"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rollbackError = ApiError.DeserializeApiError(property.Value);
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new RollbackStatusInfo(Optional.ToNullable(successfullyRolledbackInstanceCount), Optional.ToNullable(failedRolledbackInstanceCount), rollbackError.Value, serializedAdditionalRawData);
        }
    }
}
