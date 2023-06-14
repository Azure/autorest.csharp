// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The parameters used when creating a storage account. </summary>
    public partial class StorageAccountCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of StorageAccountCreateOrUpdateContent. </summary>
        /// <param name="sku"> Required. Gets or sets the SKU name. </param>
        /// <param name="kind"> Required. Indicates the type of storage account. </param>
        /// <param name="location"> Required. Gets or sets the location of the resource. This will be one of the supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sku"/> is null. </exception>
        public StorageAccountCreateOrUpdateContent(StorageSku sku, StorageKind kind, AzureLocation location)
        {
            Argument.AssertNotNull(sku, nameof(sku));

            Sku = sku;
            Kind = kind;
            Location = location;
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Required. Gets or sets the SKU name. </summary>
        public StorageSku Sku { get; }
        /// <summary> Required. Indicates the type of storage account. </summary>
        public StorageKind Kind { get; }
        /// <summary> Required. Gets or sets the location of the resource. This will be one of the supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed. </summary>
        public AzureLocation Location { get; }
        /// <summary> Optional. Set the extended location of the resource. If not set, the storage account will be created in Azure main region. Otherwise it will be created in the specified extended location. </summary>
        public ExtendedLocation ExtendedLocation { get; set; }
        /// <summary> Gets or sets a list of key value pairs that describe the resource. These tags can be used for viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key with a length no greater than 128 characters and a value with a length no greater than 256 characters. </summary>
        public IDictionary<string, string> Tags { get; }
        /// <summary> The identity of the resource. </summary>
        public ManagedServiceIdentity Identity { get; set; }
        /// <summary> Allow or disallow public network access to Storage Account. Value is optional but if passed in, must be 'Enabled' or 'Disabled'. </summary>
        public PublicNetworkAccess? PublicNetworkAccess { get; set; }
        /// <summary> SasPolicy assigned to the storage account. </summary>
        public SasPolicy SasPolicy { get; set; }
        /// <summary> KeyPolicy assigned to the storage account. </summary>
        internal KeyPolicy KeyPolicy { get; set; }
        /// <summary> The key expiration period in days. </summary>
        public int? KeyExpirationPeriodInDays
        {
            get => KeyPolicy is null ? default(int?) : KeyPolicy.KeyExpirationPeriodInDays;
            set
            {
                KeyPolicy = value.HasValue ? new KeyPolicy(value.Value) : null;
            }
        }

        /// <summary> User domain assigned to the storage account. Name is the CNAME source. Only one custom domain is supported per storage account at this time. To clear the existing custom domain, use an empty string for the custom domain name property. </summary>
        public CustomDomain CustomDomain { get; set; }
        /// <summary> Not applicable. Azure Storage encryption is enabled for all storage accounts and cannot be disabled. </summary>
        public Encryption Encryption { get; set; }
        /// <summary> Network rule set. </summary>
        public NetworkRuleSet NetworkRuleSet { get; set; }
        /// <summary> Required for storage accounts where kind = BlobStorage. The access tier used for billing. </summary>
        public AccessTier? AccessTier { get; set; }
        /// <summary> Provides the identity based authentication settings for Azure Files. </summary>
        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }
        /// <summary> Allows https traffic only to storage service if sets to true. The default value is true since API version 2019-04-01. </summary>
        public bool? EnableHttpsTrafficOnly { get; set; }
        /// <summary> Account HierarchicalNamespace enabled if sets to true. </summary>
        public bool? IsHnsEnabled { get; set; }
        /// <summary> Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled. </summary>
        public LargeFileSharesState? LargeFileSharesState { get; set; }
        /// <summary> Maintains information about the network routing choice opted by the user for data transfer. </summary>
        public RoutingPreference RoutingPreference { get; set; }
        /// <summary> Allow or disallow public access to all blobs or containers in the storage account. The default interpretation is true for this property. </summary>
        public bool? AllowBlobPublicAccess { get; set; }
        /// <summary> Set the minimum TLS version to be permitted on requests to storage. The default interpretation is TLS 1.0 for this property. </summary>
        public MinimumTlsVersion? MinimumTlsVersion { get; set; }
        /// <summary> Indicates whether the storage account permits requests to be authorized with the account access key via Shared Key. If false, then all requests, including shared access signatures, must be authorized with Azure Active Directory (Azure AD). The default value is null, which is equivalent to true. </summary>
        public bool? AllowSharedKeyAccess { get; set; }
        /// <summary> NFS 3.0 protocol support enabled if set to true. </summary>
        public bool? EnableNfsV3 { get; set; }
        /// <summary> Allow or disallow cross AAD tenant object replication. The default interpretation is true for this property. </summary>
        public bool? AllowCrossTenantReplication { get; set; }
        /// <summary> A boolean flag which indicates whether the default authentication is OAuth or not. The default interpretation is false for this property. </summary>
        public bool? DefaultToOAuthAuthentication { get; set; }
        /// <summary> The property is immutable and can only be set to true at the account creation time. When set to true, it enables object level immutability for all the new containers in the account by default. </summary>
        public ImmutableStorageAccount ImmutableStorageWithVersioning { get; set; }
    }
}
