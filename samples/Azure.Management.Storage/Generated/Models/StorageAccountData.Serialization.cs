// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Management.Storage.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.Management.Storage
{
    public partial class StorageAccountData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity"u8);
                var serializeOptions = new JsonSerializerOptions { Converters = { new ResourceManager.Models.ManagedServiceIdentityTypeV3Converter() } };
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
            Optional<StorageSku> sku = default;
            Optional<StorageKind> kind = default;
            Optional<ManagedServiceIdentity> identity = default;
            Optional<ExtendedLocation> extendedLocation = default;
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<ProvisioningState> provisioningState = default;
            Optional<Endpoints> primaryEndpoints = default;
            Optional<string> primaryLocation = default;
            Optional<AccountStatus> statusOfPrimary = default;
            Optional<DateTimeOffset> lastGeoFailoverTime = default;
            Optional<string> secondaryLocation = default;
            Optional<AccountStatus> statusOfSecondary = default;
            Optional<DateTimeOffset> creationTime = default;
            Optional<CustomDomain> customDomain = default;
            Optional<SasPolicy> sasPolicy = default;
            Optional<KeyPolicy> keyPolicy = default;
            Optional<KeyCreationTime> keyCreationTime = default;
            Optional<Endpoints> secondaryEndpoints = default;
            Optional<Encryption> encryption = default;
            Optional<AccessTier> accessTier = default;
            Optional<AzureFilesIdentityBasedAuthentication> azureFilesIdentityBasedAuthentication = default;
            Optional<bool> supportsHttpsTrafficOnly = default;
            Optional<NetworkRuleSet> networkAcls = default;
            Optional<bool> isHnsEnabled = default;
            Optional<GeoReplicationStats> geoReplicationStats = default;
            Optional<bool> failoverInProgress = default;
            Optional<LargeFileSharesState> largeFileSharesState = default;
            Optional<IReadOnlyList<StoragePrivateEndpointConnectionData>> privateEndpointConnections = default;
            Optional<RoutingPreference> routingPreference = default;
            Optional<BlobRestoreStatus> blobRestoreStatus = default;
            Optional<bool> allowBlobPublicAccess = default;
            Optional<MinimumTlsVersion> minimumTlsVersion = default;
            Optional<bool> allowSharedKeyAccess = default;
            Optional<bool> isNfsV3Enabled = default;
            Optional<bool> allowCrossTenantReplication = default;
            Optional<bool> defaultToOAuthAuthentication = default;
            Optional<PublicNetworkAccess> publicNetworkAccess = default;
            Optional<ImmutableStorageAccount> immutableStorageWithVersioning = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sku"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    sku = StorageSku.DeserializeStorageSku(property.Value);
                    continue;
                }
                if (property.NameEquals("kind"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    kind = new StorageKind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("identity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    var serializeOptions = new JsonSerializerOptions { Converters = { new ResourceManager.Models.ManagedServiceIdentityTypeV3Converter() } };
                    identity = JsonSerializer.Deserialize<ManagedServiceIdentity>(property.Value.GetRawText(), serializeOptions);
                    continue;
                }
                if (property.NameEquals("extendedLocation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    extendedLocation = JsonSerializer.Deserialize<ExtendedLocation>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
                        property.ThrowNonNullablePropertyIsNull();
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
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            provisioningState = property0.Value.GetString().ToProvisioningState();
                            continue;
                        }
                        if (property0.NameEquals("primaryEndpoints"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
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
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            statusOfPrimary = property0.Value.GetString().ToAccountStatus();
                            continue;
                        }
                        if (property0.NameEquals("lastGeoFailoverTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
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
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            statusOfSecondary = property0.Value.GetString().ToAccountStatus();
                            continue;
                        }
                        if (property0.NameEquals("creationTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            creationTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("customDomain"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            customDomain = CustomDomain.DeserializeCustomDomain(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("sasPolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            sasPolicy = SasPolicy.DeserializeSasPolicy(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("keyPolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            keyPolicy = KeyPolicy.DeserializeKeyPolicy(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("keyCreationTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            keyCreationTime = KeyCreationTime.DeserializeKeyCreationTime(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("secondaryEndpoints"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            secondaryEndpoints = Endpoints.DeserializeEndpoints(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("encryption"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            encryption = Encryption.DeserializeEncryption(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("accessTier"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            accessTier = property0.Value.GetString().ToAccessTier();
                            continue;
                        }
                        if (property0.NameEquals("azureFilesIdentityBasedAuthentication"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            azureFilesIdentityBasedAuthentication = AzureFilesIdentityBasedAuthentication.DeserializeAzureFilesIdentityBasedAuthentication(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("supportsHttpsTrafficOnly"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            supportsHttpsTrafficOnly = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("networkAcls"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            networkAcls = NetworkRuleSet.DeserializeNetworkRuleSet(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("isHnsEnabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            isHnsEnabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("geoReplicationStats"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            geoReplicationStats = GeoReplicationStats.DeserializeGeoReplicationStats(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("failoverInProgress"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            failoverInProgress = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("largeFileSharesState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            largeFileSharesState = new LargeFileSharesState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("privateEndpointConnections"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
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
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            routingPreference = RoutingPreference.DeserializeRoutingPreference(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("blobRestoreStatus"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            blobRestoreStatus = BlobRestoreStatus.DeserializeBlobRestoreStatus(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("allowBlobPublicAccess"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            allowBlobPublicAccess = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("minimumTlsVersion"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            minimumTlsVersion = new MinimumTlsVersion(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("allowSharedKeyAccess"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            allowSharedKeyAccess = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("isNfsV3Enabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            isNfsV3Enabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("allowCrossTenantReplication"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            allowCrossTenantReplication = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("defaultToOAuthAuthentication"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            defaultToOAuthAuthentication = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("publicNetworkAccess"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            publicNetworkAccess = new PublicNetworkAccess(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("immutableStorageWithVersioning"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            immutableStorageWithVersioning = ImmutableStorageAccount.DeserializeImmutableStorageAccount(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new StorageAccountData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, sku.Value, Optional.ToNullable(kind), identity, extendedLocation, Optional.ToNullable(provisioningState), primaryEndpoints.Value, primaryLocation.Value, Optional.ToNullable(statusOfPrimary), Optional.ToNullable(lastGeoFailoverTime), secondaryLocation.Value, Optional.ToNullable(statusOfSecondary), Optional.ToNullable(creationTime), customDomain.Value, sasPolicy.Value, keyPolicy.Value, keyCreationTime.Value, secondaryEndpoints.Value, encryption.Value, Optional.ToNullable(accessTier), azureFilesIdentityBasedAuthentication.Value, Optional.ToNullable(supportsHttpsTrafficOnly), networkAcls.Value, Optional.ToNullable(isHnsEnabled), geoReplicationStats.Value, Optional.ToNullable(failoverInProgress), Optional.ToNullable(largeFileSharesState), Optional.ToList(privateEndpointConnections), routingPreference.Value, blobRestoreStatus.Value, Optional.ToNullable(allowBlobPublicAccess), Optional.ToNullable(minimumTlsVersion), Optional.ToNullable(allowSharedKeyAccess), Optional.ToNullable(isNfsV3Enabled), Optional.ToNullable(allowCrossTenantReplication), Optional.ToNullable(defaultToOAuthAuthentication), Optional.ToNullable(publicNetworkAccess), immutableStorageWithVersioning.Value);
        }
    }
}
