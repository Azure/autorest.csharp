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
                writer.WriteStringValue(UpgradeOperationHistoricalStatusInfoType);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Location))
            {
                writer.WritePropertyName("location"u8);
                writer.WriteStringValue(Location.Value);
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
            Optional<string> type = default;
            Optional<AzureLocation> location = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                    type = property.Value.GetString();
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
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new UpgradeOperationHistoricalStatusInfo(properties.Value, type.Value, Optional.ToNullable(location), serializedAdditionalRawData);
        }
    }
}
