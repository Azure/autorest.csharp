// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage.Models
{
    /// <summary> A class representing the StorageAccount data model. </summary>
    public partial class StorageAccountData : TrackedResource<TenantResourceIdentifier>
    {
        /// <summary> Initializes a new instance of StorageAccountData. </summary>
        public StorageAccountData()
        {
            PrivateEndpointConnections = new ChangeTrackingList<PrivateEndpointConnectionData>();
        }

        /// <summary> Initializes a new instance of StorageAccountData. </summary>
        /// <param name="sku"> Gets the SKU. </param>
        /// <param name="kind"> Gets the Kind. </param>
        /// <param name="identity"> The identity of the resource. </param>
        /// <param name="provisioningState"> Gets the status of the storage account at the time the operation was called. </param>
        /// <param name="primaryEndpoints"> Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object. Note that Standard_ZRS and Premium_LRS accounts only return the blob endpoint. </param>
        /// <param name="primaryLocation"> Gets the location of the primary data center for the storage account. </param>
        /// <param name="statusOfPrimary"> Gets the status indicating whether the primary location of the storage account is available or unavailable. </param>
        /// <param name="lastGeoFailoverTime"> Gets the timestamp of the most recent instance of a failover to the secondary location. Only the most recent timestamp is retained. This element is not returned if there has never been a failover instance. Only available if the accountType is Standard_GRS or Standard_RAGRS. </param>
        /// <param name="secondaryLocation"> Gets the location of the geo-replicated secondary for the storage account. Only available if the accountType is Standard_GRS or Standard_RAGRS. </param>
        /// <param name="statusOfSecondary"> Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available if the SKU name is Standard_GRS or Standard_RAGRS. </param>
        /// <param name="creationTime"> Gets the creation date and time of the storage account in UTC. </param>
        /// <param name="customDomain"> Gets the custom domain the user assigned to this storage account. </param>
        /// <param name="secondaryEndpoints"> Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object from the secondary location of the storage account. Only available if the SKU name is Standard_RAGRS. </param>
        /// <param name="encryption"> Gets the encryption settings on the account. If unspecified, the account is unencrypted. </param>
        /// <param name="accessTier"> Required for storage accounts where kind = BlobStorage. The access tier used for billing. </param>
        /// <param name="azureFilesIdentityBasedAuthentication"> Provides the identity based authentication settings for Azure Files. </param>
        /// <param name="enableHttpsTrafficOnly"> Allows https traffic only to storage service if sets to true. </param>
        /// <param name="networkRuleSet"> Network rule set. </param>
        /// <param name="isHnsEnabled"> Account HierarchicalNamespace enabled if sets to true. </param>
        /// <param name="geoReplicationStats"> Geo Replication Stats. </param>
        /// <param name="failoverInProgress"> If the failover is in progress, the value will be true, otherwise, it will be null. </param>
        /// <param name="largeFileSharesState"> Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connection associated with the specified storage account. </param>
        /// <param name="routingPreference"> Maintains information about the network routing choice opted by the user for data transfer. </param>
        /// <param name="blobRestoreStatus"> Blob restore status. </param>
        internal StorageAccountData(Sku sku, Kind? kind, Identity identity, ProvisioningState? provisioningState, Endpoints primaryEndpoints, string primaryLocation, AccountStatus? statusOfPrimary, DateTimeOffset? lastGeoFailoverTime, string secondaryLocation, AccountStatus? statusOfSecondary, DateTimeOffset? creationTime, CustomDomain customDomain, Endpoints secondaryEndpoints, Encryption encryption, AccessTier? accessTier, AzureFilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication, bool? enableHttpsTrafficOnly, NetworkRuleSet networkRuleSet, bool? isHnsEnabled, GeoReplicationStats geoReplicationStats, bool? failoverInProgress, LargeFileSharesState? largeFileSharesState, IReadOnlyList<PrivateEndpointConnectionData> privateEndpointConnections, RoutingPreference routingPreference, BlobRestoreStatus blobRestoreStatus)
        {
            Sku = sku;
            Kind = kind;
            Identity = identity;
            ProvisioningState = provisioningState;
            PrimaryEndpoints = primaryEndpoints;
            PrimaryLocation = primaryLocation;
            StatusOfPrimary = statusOfPrimary;
            LastGeoFailoverTime = lastGeoFailoverTime;
            SecondaryLocation = secondaryLocation;
            StatusOfSecondary = statusOfSecondary;
            CreationTime = creationTime;
            CustomDomain = customDomain;
            SecondaryEndpoints = secondaryEndpoints;
            Encryption = encryption;
            AccessTier = accessTier;
            AzureFilesIdentityBasedAuthentication = azureFilesIdentityBasedAuthentication;
            EnableHttpsTrafficOnly = enableHttpsTrafficOnly;
            NetworkRuleSet = networkRuleSet;
            IsHnsEnabled = isHnsEnabled;
            GeoReplicationStats = geoReplicationStats;
            FailoverInProgress = failoverInProgress;
            LargeFileSharesState = largeFileSharesState;
            PrivateEndpointConnections = privateEndpointConnections;
            RoutingPreference = routingPreference;
            BlobRestoreStatus = blobRestoreStatus;
        }

        /// <summary> ARM resource type. </summary>
        public static ResourceType ResourceType => "todo: find out resource type";

        /// <summary> Gets the SKU. </summary>
        public Sku Sku { get; }
        /// <summary> Gets the Kind. </summary>
        public Kind? Kind { get; }
        /// <summary> The identity of the resource. </summary>
        public Identity Identity { get; set; }
        /// <summary> Gets the status of the storage account at the time the operation was called. </summary>
        public ProvisioningState? ProvisioningState { get; }
        /// <summary> Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object. Note that Standard_ZRS and Premium_LRS accounts only return the blob endpoint. </summary>
        public Endpoints PrimaryEndpoints { get; }
        /// <summary> Gets the location of the primary data center for the storage account. </summary>
        public string PrimaryLocation { get; }
        /// <summary> Gets the status indicating whether the primary location of the storage account is available or unavailable. </summary>
        public AccountStatus? StatusOfPrimary { get; }
        /// <summary> Gets the timestamp of the most recent instance of a failover to the secondary location. Only the most recent timestamp is retained. This element is not returned if there has never been a failover instance. Only available if the accountType is Standard_GRS or Standard_RAGRS. </summary>
        public DateTimeOffset? LastGeoFailoverTime { get; }
        /// <summary> Gets the location of the geo-replicated secondary for the storage account. Only available if the accountType is Standard_GRS or Standard_RAGRS. </summary>
        public string SecondaryLocation { get; }
        /// <summary> Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available if the SKU name is Standard_GRS or Standard_RAGRS. </summary>
        public AccountStatus? StatusOfSecondary { get; }
        /// <summary> Gets the creation date and time of the storage account in UTC. </summary>
        public DateTimeOffset? CreationTime { get; }
        /// <summary> Gets the custom domain the user assigned to this storage account. </summary>
        public CustomDomain CustomDomain { get; }
        /// <summary> Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object from the secondary location of the storage account. Only available if the SKU name is Standard_RAGRS. </summary>
        public Endpoints SecondaryEndpoints { get; }
        /// <summary> Gets the encryption settings on the account. If unspecified, the account is unencrypted. </summary>
        public Encryption Encryption { get; }
        /// <summary> Required for storage accounts where kind = BlobStorage. The access tier used for billing. </summary>
        public AccessTier? AccessTier { get; }
        /// <summary> Provides the identity based authentication settings for Azure Files. </summary>
        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }
        /// <summary> Allows https traffic only to storage service if sets to true. </summary>
        public bool? EnableHttpsTrafficOnly { get; set; }
        /// <summary> Network rule set. </summary>
        public NetworkRuleSet NetworkRuleSet { get; }
        /// <summary> Account HierarchicalNamespace enabled if sets to true. </summary>
        public bool? IsHnsEnabled { get; set; }
        /// <summary> Geo Replication Stats. </summary>
        public GeoReplicationStats GeoReplicationStats { get; }
        /// <summary> If the failover is in progress, the value will be true, otherwise, it will be null. </summary>
        public bool? FailoverInProgress { get; }
        /// <summary> Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled. </summary>
        public LargeFileSharesState? LargeFileSharesState { get; set; }
        /// <summary> List of private endpoint connection associated with the specified storage account. </summary>
        public IReadOnlyList<PrivateEndpointConnectionData> PrivateEndpointConnections { get; }
        /// <summary> Maintains information about the network routing choice opted by the user for data transfer. </summary>
        public RoutingPreference RoutingPreference { get; set; }
        /// <summary> Blob restore status. </summary>
        public BlobRestoreStatus BlobRestoreStatus { get; }
    }
}
