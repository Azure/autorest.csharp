// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using AzureSample.ResourceManager.Storage.Models;

namespace AzureSample.ResourceManager.Storage
{
    public partial class BlobServiceData : IUtf8JsonSerializable
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
            if (Optional.IsDefined(DefaultServiceVersion))
            {
                writer.WritePropertyName("defaultServiceVersion"u8);
                writer.WriteStringValue(DefaultServiceVersion);
            }
            if (Optional.IsDefined(DeleteRetentionPolicy))
            {
                writer.WritePropertyName("deleteRetentionPolicy"u8);
                writer.WriteObjectValue(DeleteRetentionPolicy);
            }
            if (Optional.IsDefined(IsVersioningEnabled))
            {
                writer.WritePropertyName("isVersioningEnabled"u8);
                writer.WriteBooleanValue(IsVersioningEnabled.Value);
            }
            if (Optional.IsDefined(AutomaticSnapshotPolicyEnabled))
            {
                writer.WritePropertyName("automaticSnapshotPolicyEnabled"u8);
                writer.WriteBooleanValue(AutomaticSnapshotPolicyEnabled.Value);
            }
            if (Optional.IsDefined(ChangeFeed))
            {
                writer.WritePropertyName("changeFeed"u8);
                writer.WriteObjectValue(ChangeFeed);
            }
            if (Optional.IsDefined(RestorePolicy))
            {
                writer.WritePropertyName("restorePolicy"u8);
                writer.WriteObjectValue(RestorePolicy);
            }
            if (Optional.IsDefined(ContainerDeleteRetentionPolicy))
            {
                writer.WritePropertyName("containerDeleteRetentionPolicy"u8);
                writer.WriteObjectValue(ContainerDeleteRetentionPolicy);
            }
            if (Optional.IsDefined(LastAccessTimeTrackingPolicy))
            {
                writer.WritePropertyName("lastAccessTimeTrackingPolicy"u8);
                writer.WriteObjectValue(LastAccessTimeTrackingPolicy);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static BlobServiceData DeserializeBlobServiceData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            AzureSampleResourceManagerStorageSku sku = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            SystemData systemData = default;
            CorsRules cors = default;
            string defaultServiceVersion = default;
            DeleteRetentionPolicy deleteRetentionPolicy = default;
            bool? isVersioningEnabled = default;
            bool? automaticSnapshotPolicyEnabled = default;
            ChangeFeed changeFeed = default;
            RestorePolicyProperties restorePolicy = default;
            DeleteRetentionPolicy containerDeleteRetentionPolicy = default;
            LastAccessTimeTrackingPolicy lastAccessTimeTrackingPolicy = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sku"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sku = AzureSampleResourceManagerStorageSku.DeserializeAzureSampleResourceManagerStorageSku(property.Value);
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
                    systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureSampleResourceManagerStorageContext.Default);
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
                        if (property0.NameEquals("defaultServiceVersion"u8))
                        {
                            defaultServiceVersion = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("deleteRetentionPolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            deleteRetentionPolicy = DeleteRetentionPolicy.DeserializeDeleteRetentionPolicy(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("isVersioningEnabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            isVersioningEnabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("automaticSnapshotPolicyEnabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            automaticSnapshotPolicyEnabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("changeFeed"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            changeFeed = ChangeFeed.DeserializeChangeFeed(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("restorePolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            restorePolicy = RestorePolicyProperties.DeserializeRestorePolicyProperties(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("containerDeleteRetentionPolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            containerDeleteRetentionPolicy = DeleteRetentionPolicy.DeserializeDeleteRetentionPolicy(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("lastAccessTimeTrackingPolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            lastAccessTimeTrackingPolicy = LastAccessTimeTrackingPolicy.DeserializeLastAccessTimeTrackingPolicy(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new BlobServiceData(
                id,
                name,
                type,
                systemData,
                sku,
                cors,
                defaultServiceVersion,
                deleteRetentionPolicy,
                isVersioningEnabled,
                automaticSnapshotPolicyEnabled,
                changeFeed,
                restorePolicy,
                containerDeleteRetentionPolicy,
                lastAccessTimeTrackingPolicy);
        }
    }
}
