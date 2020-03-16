// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Management.Models
{
    public partial class StorageAccount : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Sku != null)
            {
                writer.WritePropertyName("sku");
                writer.WriteObjectValue(Sku);
            }
            if (Kind != null)
            {
                writer.WritePropertyName("kind");
                writer.WriteStringValue(Kind.Value.ToString());
            }
            if (Identity != null)
            {
                writer.WritePropertyName("identity");
                writer.WriteObjectValue(Identity);
            }
            if (Tags != null)
            {
                writer.WritePropertyName("tags");
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("location");
            writer.WriteStringValue(Location);
            if (Id != null)
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(Id);
            }
            if (Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Type != null)
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue(Type);
            }
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (ProvisioningState != null)
            {
                writer.WritePropertyName("provisioningState");
                writer.WriteStringValue(ProvisioningState.Value.ToSerialString());
            }
            if (PrimaryEndpoints != null)
            {
                writer.WritePropertyName("primaryEndpoints");
                writer.WriteObjectValue(PrimaryEndpoints);
            }
            if (PrimaryLocation != null)
            {
                writer.WritePropertyName("primaryLocation");
                writer.WriteStringValue(PrimaryLocation);
            }
            if (StatusOfPrimary != null)
            {
                writer.WritePropertyName("statusOfPrimary");
                writer.WriteStringValue(StatusOfPrimary.Value.ToSerialString());
            }
            if (LastGeoFailoverTime != null)
            {
                writer.WritePropertyName("lastGeoFailoverTime");
                writer.WriteStringValue(LastGeoFailoverTime.Value, "S");
            }
            if (SecondaryLocation != null)
            {
                writer.WritePropertyName("secondaryLocation");
                writer.WriteStringValue(SecondaryLocation);
            }
            if (StatusOfSecondary != null)
            {
                writer.WritePropertyName("statusOfSecondary");
                writer.WriteStringValue(StatusOfSecondary.Value.ToSerialString());
            }
            if (CreationTime != null)
            {
                writer.WritePropertyName("creationTime");
                writer.WriteStringValue(CreationTime.Value, "S");
            }
            if (CustomDomain != null)
            {
                writer.WritePropertyName("customDomain");
                writer.WriteObjectValue(CustomDomain);
            }
            if (SecondaryEndpoints != null)
            {
                writer.WritePropertyName("secondaryEndpoints");
                writer.WriteObjectValue(SecondaryEndpoints);
            }
            if (Encryption != null)
            {
                writer.WritePropertyName("encryption");
                writer.WriteObjectValue(Encryption);
            }
            if (AccessTier != null)
            {
                writer.WritePropertyName("accessTier");
                writer.WriteStringValue(AccessTier.Value.ToSerialString());
            }
            if (AzureFilesIdentityBasedAuthentication != null)
            {
                writer.WritePropertyName("azureFilesIdentityBasedAuthentication");
                writer.WriteObjectValue(AzureFilesIdentityBasedAuthentication);
            }
            if (EnableHttpsTrafficOnly != null)
            {
                writer.WritePropertyName("supportsHttpsTrafficOnly");
                writer.WriteBooleanValue(EnableHttpsTrafficOnly.Value);
            }
            if (NetworkRuleSet != null)
            {
                writer.WritePropertyName("networkAcls");
                writer.WriteObjectValue(NetworkRuleSet);
            }
            if (IsHnsEnabled != null)
            {
                writer.WritePropertyName("isHnsEnabled");
                writer.WriteBooleanValue(IsHnsEnabled.Value);
            }
            if (GeoReplicationStats != null)
            {
                writer.WritePropertyName("geoReplicationStats");
                writer.WriteObjectValue(GeoReplicationStats);
            }
            if (FailoverInProgress != null)
            {
                writer.WritePropertyName("failoverInProgress");
                writer.WriteBooleanValue(FailoverInProgress.Value);
            }
            if (LargeFileSharesState != null)
            {
                writer.WritePropertyName("largeFileSharesState");
                writer.WriteStringValue(LargeFileSharesState.Value.ToString());
            }
            if (PrivateEndpointConnections != null)
            {
                writer.WritePropertyName("privateEndpointConnections");
                writer.WriteStartArray();
                foreach (var item in PrivateEndpointConnections)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (RoutingPreference != null)
            {
                writer.WritePropertyName("routingPreference");
                writer.WriteObjectValue(RoutingPreference);
            }
            if (BlobRestoreStatus != null)
            {
                writer.WritePropertyName("blobRestoreStatus");
                writer.WriteObjectValue(BlobRestoreStatus);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static StorageAccount DeserializeStorageAccount(JsonElement element)
        {
            StorageAccount result = new StorageAccount();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sku"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Sku = Sku.DeserializeSku(property.Value);
                    continue;
                }
                if (property.NameEquals("kind"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Kind = new Kind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("identity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Identity = Identity.DeserializeIdentity(property.Value);
                    continue;
                }
                if (property.NameEquals("tags"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Tags = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        result.Tags.Add(property0.Name, property0.Value.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("location"))
                {
                    result.Location = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("provisioningState"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.ProvisioningState = property0.Value.GetString().ToProvisioningState();
                            continue;
                        }
                        if (property0.NameEquals("primaryEndpoints"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.PrimaryEndpoints = Endpoints.DeserializeEndpoints(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("primaryLocation"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.PrimaryLocation = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("statusOfPrimary"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.StatusOfPrimary = property0.Value.GetString().ToAccountStatus();
                            continue;
                        }
                        if (property0.NameEquals("lastGeoFailoverTime"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.LastGeoFailoverTime = property0.Value.GetDateTimeOffset("S");
                            continue;
                        }
                        if (property0.NameEquals("secondaryLocation"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.SecondaryLocation = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("statusOfSecondary"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.StatusOfSecondary = property0.Value.GetString().ToAccountStatus();
                            continue;
                        }
                        if (property0.NameEquals("creationTime"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.CreationTime = property0.Value.GetDateTimeOffset("S");
                            continue;
                        }
                        if (property0.NameEquals("customDomain"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.CustomDomain = CustomDomain.DeserializeCustomDomain(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("secondaryEndpoints"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.SecondaryEndpoints = Endpoints.DeserializeEndpoints(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("encryption"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.Encryption = Encryption.DeserializeEncryption(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("accessTier"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.AccessTier = property0.Value.GetString().ToAccessTier();
                            continue;
                        }
                        if (property0.NameEquals("azureFilesIdentityBasedAuthentication"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.AzureFilesIdentityBasedAuthentication = AzureFilesIdentityBasedAuthentication.DeserializeAzureFilesIdentityBasedAuthentication(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("supportsHttpsTrafficOnly"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.EnableHttpsTrafficOnly = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("networkAcls"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.NetworkRuleSet = NetworkRuleSet.DeserializeNetworkRuleSet(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("isHnsEnabled"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.IsHnsEnabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("geoReplicationStats"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.GeoReplicationStats = GeoReplicationStats.DeserializeGeoReplicationStats(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("failoverInProgress"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.FailoverInProgress = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("largeFileSharesState"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.LargeFileSharesState = new LargeFileSharesState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("privateEndpointConnections"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.PrivateEndpointConnections = new List<PrivateEndpointConnection>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                result.PrivateEndpointConnections.Add(PrivateEndpointConnection.DeserializePrivateEndpointConnection(item));
                            }
                            continue;
                        }
                        if (property0.NameEquals("routingPreference"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.RoutingPreference = RoutingPreference.DeserializeRoutingPreference(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("blobRestoreStatus"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.BlobRestoreStatus = BlobRestoreStatus.DeserializeBlobRestoreStatus(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
