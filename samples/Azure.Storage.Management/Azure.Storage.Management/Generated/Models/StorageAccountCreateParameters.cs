// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Storage.Management.Models
{
    /// <summary> The parameters used when creating a storage account. </summary>
    public partial class StorageAccountCreateParameters
    {
        /// <summary> Initializes a new instance of StorageAccountCreateParameters. </summary>
        /// <param name="sku"> Required. Gets or sets the SKU name. </param>
        /// <param name="kind"> Required. Indicates the type of storage account. </param>
        /// <param name="location"> Required. Gets or sets the location of the resource. This will be one of the supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed. </param>
        public StorageAccountCreateParameters(Sku sku, Kind kind, string location)
        {
            Sku = sku;
            Kind = kind;
            Location = location;
        }

        /// <summary> Initializes a new instance of StorageAccountCreateParameters. </summary>
        /// <param name="sku"> Required. Gets or sets the SKU name. </param>
        /// <param name="kind"> Required. Indicates the type of storage account. </param>
        /// <param name="location"> Required. Gets or sets the location of the resource. This will be one of the supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed. </param>
        /// <param name="tags"> Gets or sets a list of key value pairs that describe the resource. These tags can be used for viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key with a length no greater than 128 characters and a value with a length no greater than 256 characters. </param>
        /// <param name="identity"> The identity of the resource. </param>
        /// <param name="customDomain"> User domain assigned to the storage account. Name is the CNAME source. Only one custom domain is supported per storage account at this time. To clear the existing custom domain, use an empty string for the custom domain name property. </param>
        /// <param name="encryption"> Not applicable. Azure Storage encryption is enabled for all storage accounts and cannot be disabled. </param>
        /// <param name="networkRuleSet"> Network rule set. </param>
        /// <param name="accessTier"> Required for storage accounts where kind = BlobStorage. The access tier used for billing. </param>
        /// <param name="azureFilesIdentityBasedAuthentication"> Provides the identity based authentication settings for Azure Files. </param>
        /// <param name="enableHttpsTrafficOnly"> Allows https traffic only to storage service if sets to true. The default value is true since API version 2019-04-01. </param>
        /// <param name="isHnsEnabled"> Account HierarchicalNamespace enabled if sets to true. </param>
        /// <param name="largeFileSharesState"> Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled. </param>
        /// <param name="routingPreference"> Maintains information about the network routing choice opted by the user for data transfer. </param>
        internal StorageAccountCreateParameters(Sku sku, Kind kind, string location, IDictionary<string, string> tags, Identity identity, CustomDomain customDomain, Encryption encryption, NetworkRuleSet networkRuleSet, AccessTier? accessTier, AzureFilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication, bool? enableHttpsTrafficOnly, bool? isHnsEnabled, LargeFileSharesState? largeFileSharesState, RoutingPreference routingPreference)
        {
            Sku = sku;
            Kind = kind;
            Location = location;
            Tags = tags;
            Identity = identity;
            CustomDomain = customDomain;
            Encryption = encryption;
            NetworkRuleSet = networkRuleSet;
            AccessTier = accessTier;
            AzureFilesIdentityBasedAuthentication = azureFilesIdentityBasedAuthentication;
            EnableHttpsTrafficOnly = enableHttpsTrafficOnly;
            IsHnsEnabled = isHnsEnabled;
            LargeFileSharesState = largeFileSharesState;
            RoutingPreference = routingPreference;
        }

        /// <summary> Required. Gets or sets the SKU name. </summary>
        public Sku Sku { get; }
        /// <summary> Required. Indicates the type of storage account. </summary>
        public Kind Kind { get; }
        /// <summary> Required. Gets or sets the location of the resource. This will be one of the supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed. </summary>
        public string Location { get; }
        /// <summary> Gets or sets a list of key value pairs that describe the resource. These tags can be used for viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key with a length no greater than 128 characters and a value with a length no greater than 256 characters. </summary>
        public IDictionary<string, string> Tags { get; set; }
        /// <summary> The identity of the resource. </summary>
        public Identity Identity { get; set; }
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
    }
}
