// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class RollingUpgradeProgressInfo : IUtf8JsonSerializable, IModelJsonSerializable<RollingUpgradeProgressInfo>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<RollingUpgradeProgressInfo>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<RollingUpgradeProgressInfo>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(SuccessfulInstanceCount))
            {
                writer.WritePropertyName("successfulInstanceCount"u8);
                writer.WriteNumberValue(SuccessfulInstanceCount.Value);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(FailedInstanceCount))
            {
                writer.WritePropertyName("failedInstanceCount"u8);
                writer.WriteNumberValue(FailedInstanceCount.Value);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(InProgressInstanceCount))
            {
                writer.WritePropertyName("inProgressInstanceCount"u8);
                writer.WriteNumberValue(InProgressInstanceCount.Value);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(PendingInstanceCount))
            {
                writer.WritePropertyName("pendingInstanceCount"u8);
                writer.WriteNumberValue(PendingInstanceCount.Value);
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

        RollingUpgradeProgressInfo IModelJsonSerializable<RollingUpgradeProgressInfo>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRollingUpgradeProgressInfo(document.RootElement, options);
        }

        internal static RollingUpgradeProgressInfo DeserializeRollingUpgradeProgressInfo(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> successfulInstanceCount = default;
            Optional<int> failedInstanceCount = default;
            Optional<int> inProgressInstanceCount = default;
            Optional<int> pendingInstanceCount = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("successfulInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    successfulInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("failedInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    failedInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("inProgressInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    inProgressInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("pendingInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    pendingInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new RollingUpgradeProgressInfo(Optional.ToNullable(successfulInstanceCount), Optional.ToNullable(failedInstanceCount), Optional.ToNullable(inProgressInstanceCount), Optional.ToNullable(pendingInstanceCount), serializedAdditionalRawData);
        }

        BinaryData IModelSerializable<RollingUpgradeProgressInfo>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        RollingUpgradeProgressInfo IModelSerializable<RollingUpgradeProgressInfo>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeRollingUpgradeProgressInfo(document.RootElement, options);
        }
    }
}
