// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageAccountData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity"u8);
                var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
                JsonSerializer.Serialize(writer, Identity, serializeOptions);
            }
            if (Optional.IsDefined(ExtendedLocation))
            {
                writer.WritePropertyName("extendedLocation"u8);
                JsonSerializer.Serialize(writer, ExtendedLocation);
            }
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("location"u8);
            writer.WriteStringValue(Location);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(AzureFilesIdentityBasedAuthentication))
            {
                writer.WritePropertyName("azureFilesIdentityBasedAuthentication"u8);
                writer.WriteObjectValue(AzureFilesIdentityBasedAuthentication);
            }
            if (Optional.IsDefined(EnableHttpsTrafficOnly))
            {
                writer.WritePropertyName("supportsHttpsTrafficOnly"u8);
                writer.WriteBooleanValue(EnableHttpsTrafficOnly.Value);
            }
            if (Optional.IsDefined(IsHnsEnabled))
            {
                writer.WritePropertyName("isHnsEnabled"u8);
                writer.WriteBooleanValue(IsHnsEnabled.Value);
            }
            if (Optional.IsDefined(LargeFileSharesState))
            {
                writer.WritePropertyName("largeFileSharesState"u8);
                writer.WriteStringValue(LargeFileSharesState.Value.ToString());
            }
            if (Optional.IsDefined(RoutingPreference))
            {
                writer.WritePropertyName("routingPreference"u8);
                writer.WriteObjectValue(RoutingPreference);
            }
            if (Optional.IsDefined(AllowBlobPublicAccess))
            {
                writer.WritePropertyName("allowBlobPublicAccess"u8);
                writer.WriteBooleanValue(AllowBlobPublicAccess.Value);
            }
            if (Optional.IsDefined(MinimumTlsVersion))
            {
                writer.WritePropertyName("minimumTlsVersion"u8);
                writer.WriteStringValue(MinimumTlsVersion.Value.ToString());
            }
            if (Optional.IsDefined(AllowSharedKeyAccess))
            {
                writer.WritePropertyName("allowSharedKeyAccess"u8);
                writer.WriteBooleanValue(AllowSharedKeyAccess.Value);
            }
            if (Optional.IsDefined(EnableNfsV3))
            {
                writer.WritePropertyName("isNfsV3Enabled"u8);
                writer.WriteBooleanValue(EnableNfsV3.Value);
            }
            if (Optional.IsDefined(AllowCrossTenantReplication))
            {
                writer.WritePropertyName("allowCrossTenantReplication"u8);
                writer.WriteBooleanValue(AllowCrossTenantReplication.Value);
            }
            if (Optional.IsDefined(DefaultToOAuthAuthentication))
            {
                writer.WritePropertyName("defaultToOAuthAuthentication"u8);
                writer.WriteBooleanValue(DefaultToOAuthAuthentication.Value);
            }
            if (Optional.IsDefined(PublicNetworkAccess))
            {
                writer.WritePropertyName("publicNetworkAccess"u8);
                writer.WriteStringValue(PublicNetworkAccess.Value.ToString());
            }
            if (Optional.IsDefined(ImmutableStorageWithVersioning))
            {
                writer.WritePropertyName("immutableStorageWithVersioning"u8);
                writer.WriteObjectValue(ImmutableStorageWithVersioning);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static StorageAccountData DeserializeStorageAccountData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            StorageSku sku = default;
            StorageKind? kind = default;
            ManagedServiceIdentity identity = default;
            ExtendedLocation extendedLocation = default;
            IDictionary<string, string> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            SystemData systemData = default;
            ProvisioningState? provisioningState = default;
            Endpoints primaryEndpoints = default;
            string primaryLocation = default;
            AccountStatus? statusOfPrimary = default;
            DateTimeOffset? lastGeoFailoverTime = default;
            string secondaryLocation = default;
            AccountStatus? statusOfSecondary = default;
            DateTimeOffset? creationTime = default;
            CustomDomain customDomain = default;
            SasPolicy sasPolicy = default;
            KeyPolicy keyPolicy = default;
            KeyCreationTime keyCreationTime = default;
            Endpoints secondaryEndpoints = default;
            Encryption encryption = default;
            AccessTier? accessTier = default;
            AzureFilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication = default;
            bool? supportsHttpsTrafficOnly = default;
            NetworkRuleSet networkAcls = default;
            bool? isHnsEnabled = default;
            GeoReplicationStats geoReplicationStats = default;
            bool? failoverInProgress = default;
            LargeFileSharesState? largeFileSharesState = default;
            IReadOnlyList<StoragePrivateEndpointConnectionData> privateEndpointConnections = default;
            RoutingPreference routingPreference = default;
            BlobRestoreStatus blobRestoreStatus = default;
            bool? allowBlobPublicAccess = default;
            MinimumTlsVersion? minimumTlsVersion = default;
            bool? allowSharedKeyAccess = default;
            bool? isNfsV3Enabled = default;
            bool? allowCrossTenantReplication = default;
            bool? defaultToOAuthAuthentication = default;
            PublicNetworkAccess? publicNetworkAccess = default;
            ImmutableStorageAccount immutableStorageWithVersioning = default;
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
                if (property.NameEquals("kind"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    kind = new StorageKind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("identity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
                    identity = JsonSerializer.Deserialize<ManagedServiceIdentity>(property.Value.GetRawText(), serializeOptions);
                    continue;
                }
                if (property.NameEquals("extendedLocation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    extendedLocation = JsonSerializer.Deserialize<ExtendedLocation>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
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
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningState = property0.Value.GetString().ToProvisioningState();
                            continue;
                        }
                        if (property0.NameEquals("primaryEndpoints"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            primaryEndpoints = Endpoints.DeserializeEndpoints(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("primaryLocation"u8))
                        {
                            primaryLocation = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("statusOfPrimary"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            statusOfPrimary = property0.Value.GetString().ToAccountStatus();
                            continue;
                        }
                        if (property0.NameEquals("lastGeoFailoverTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            lastGeoFailoverTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("secondaryLocation"u8))
                        {
                            secondaryLocation = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("statusOfSecondary"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            statusOfSecondary = property0.Value.GetString().ToAccountStatus();
                            continue;
                        }
                        if (property0.NameEquals("creationTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            creationTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("customDomain"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            customDomain = CustomDomain.DeserializeCustomDomain(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("sasPolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            sasPolicy = SasPolicy.DeserializeSasPolicy(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("keyPolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            keyPolicy = KeyPolicy.DeserializeKeyPolicy(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("keyCreationTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            keyCreationTime = KeyCreationTime.DeserializeKeyCreationTime(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("secondaryEndpoints"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            secondaryEndpoints = Endpoints.DeserializeEndpoints(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("encryption"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            encryption = Encryption.DeserializeEncryption(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("accessTier"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            accessTier = property0.Value.GetString().ToAccessTier();
                            continue;
                        }
                        if (property0.NameEquals("azureFilesIdentityBasedAuthentication"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            azureFilesIdentityBasedAuthentication = AzureFilesIdentityBasedAuthentication.DeserializeAzureFilesIdentityBasedAuthentication(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("supportsHttpsTrafficOnly"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            supportsHttpsTrafficOnly = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("networkAcls"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            networkAcls = NetworkRuleSet.DeserializeNetworkRuleSet(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("isHnsEnabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            isHnsEnabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("geoReplicationStats"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            geoReplicationStats = GeoReplicationStats.DeserializeGeoReplicationStats(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("failoverInProgress"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            failoverInProgress = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("largeFileSharesState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            largeFileSharesState = new LargeFileSharesState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("privateEndpointConnections"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<StoragePrivateEndpointConnectionData> array = new List<StoragePrivateEndpointConnectionData>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(StoragePrivateEndpointConnectionData.DeserializeStoragePrivateEndpointConnectionData(item));
                            }
                            privateEndpointConnections = array;
                            continue;
                        }
                        if (property0.NameEquals("routingPreference"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            routingPreference = RoutingPreference.DeserializeRoutingPreference(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("blobRestoreStatus"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            blobRestoreStatus = BlobRestoreStatus.DeserializeBlobRestoreStatus(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("allowBlobPublicAccess"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            allowBlobPublicAccess = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("minimumTlsVersion"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            minimumTlsVersion = new MinimumTlsVersion(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("allowSharedKeyAccess"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            allowSharedKeyAccess = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("isNfsV3Enabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            isNfsV3Enabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("allowCrossTenantReplication"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            allowCrossTenantReplication = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("defaultToOAuthAuthentication"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            defaultToOAuthAuthentication = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("publicNetworkAccess"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            publicNetworkAccess = new PublicNetworkAccess(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("immutableStorageWithVersioning"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            immutableStorageWithVersioning = ImmutableStorageAccount.DeserializeImmutableStorageAccount(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new StorageAccountData(
                id,
                name,
                type,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                sku,
                kind,
                identity,
                extendedLocation,
                provisioningState,
                primaryEndpoints,
                primaryLocation,
                statusOfPrimary,
                lastGeoFailoverTime,
                secondaryLocation,
                statusOfSecondary,
                creationTime,
                customDomain,
                sasPolicy,
                keyPolicy,
                keyCreationTime,
                secondaryEndpoints,
                encryption,
                accessTier,
                azureFilesIdentityBasedAuthentication,
                supportsHttpsTrafficOnly,
                networkAcls,
                isHnsEnabled,
                geoReplicationStats,
                failoverInProgress,
                largeFileSharesState,
                privateEndpointConnections ?? new ChangeTrackingList<StoragePrivateEndpointConnectionData>(),
                routingPreference,
                blobRestoreStatus,
                allowBlobPublicAccess,
                minimumTlsVersion,
                allowSharedKeyAccess,
                isNfsV3Enabled,
                allowCrossTenantReplication,
                defaultToOAuthAuthentication,
                publicNetworkAccess,
                immutableStorageWithVersioning);
        }
    }
}
