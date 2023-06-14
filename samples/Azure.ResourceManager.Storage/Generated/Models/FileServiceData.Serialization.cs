// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class FileServiceData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(Cors))
            {
                writer.WritePropertyName("cors"u8);
                writer.WriteObjectValue(Cors);
            }
            if (Optional.IsDefined(ShareDeleteRetentionPolicy))
            {
                writer.WritePropertyName("shareDeleteRetentionPolicy"u8);
                writer.WriteObjectValue(ShareDeleteRetentionPolicy);
            }
            if (Optional.IsDefined(ProtocolSettings))
            {
                writer.WritePropertyName("protocolSettings"u8);
                writer.WriteObjectValue(ProtocolSettings);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static FileServiceData DeserializeFileServiceData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<StorageSku> sku = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<CorsRules> cors = default;
            Optional<DeleteRetentionPolicy> shareDeleteRetentionPolicy = default;
            Optional<ProtocolSettings> protocolSettings = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sku"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sku = StorageSku.DeserializeStorageSku(property.Value);
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("cors"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            cors = CorsRules.DeserializeCorsRules(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("shareDeleteRetentionPolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            shareDeleteRetentionPolicy = DeleteRetentionPolicy.DeserializeDeleteRetentionPolicy(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("protocolSettings"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            protocolSettings = ProtocolSettings.DeserializeProtocolSettings(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new FileServiceData(id, name, type, systemData.Value, sku.Value, cors.Value, shareDeleteRetentionPolicy.Value, protocolSettings.Value);
        }
    }
}
