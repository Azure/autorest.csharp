// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtAcronymMapping.Models
{
    public partial class UpgradeOperationHistoricalStatusInfo : IUtf8JsonSerializable, IModelJsonSerializable<UpgradeOperationHistoricalStatusInfo>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<UpgradeOperationHistoricalStatusInfo>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<UpgradeOperationHistoricalStatusInfo>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(Properties);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(UpgradeOperationHistoricalStatusInfoType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(UpgradeOperationHistoricalStatusInfoType.Value);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Location))
            {
                writer.WritePropertyName("location"u8);
                writer.WriteStringValue(Location.Value);
            }
            writer.WriteEndObject();
        }

        UpgradeOperationHistoricalStatusInfo IModelJsonSerializable<UpgradeOperationHistoricalStatusInfo>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUpgradeOperationHistoricalStatusInfo(document.RootElement, options);
        }

        BinaryData IModelSerializable<UpgradeOperationHistoricalStatusInfo>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        UpgradeOperationHistoricalStatusInfo IModelSerializable<UpgradeOperationHistoricalStatusInfo>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeUpgradeOperationHistoricalStatusInfo(document.RootElement, options);
        }

        internal static UpgradeOperationHistoricalStatusInfo DeserializeUpgradeOperationHistoricalStatusInfo(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<UpgradeOperationHistoricalStatusInfoProperties> properties = default;
            Optional<ResourceType> type = default;
            Optional<AzureLocation> location = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    properties = UpgradeOperationHistoricalStatusInfoProperties.DeserializeUpgradeOperationHistoricalStatusInfoProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
            }
            return new UpgradeOperationHistoricalStatusInfo(properties.Value, Optional.ToNullable(type), Optional.ToNullable(location));
        }
    }
}
