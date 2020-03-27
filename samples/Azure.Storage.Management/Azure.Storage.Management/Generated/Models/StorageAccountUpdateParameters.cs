// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Storage.Management.Models
{
    /// <summary> The parameters that can be provided when updating the storage account properties. </summary>
    public partial class StorageAccountUpdateParameters
    {
        /// <summary> Initializes a new instance of StorageAccountUpdateParameters. </summary>
        public StorageAccountUpdateParameters()
        {
        }

        /// <summary> Initializes a new instance of StorageAccountUpdateParameters. </summary>
        /// <param name="sku"> Gets or sets the SKU name. Note that the SKU name cannot be updated to Standard_ZRS, Premium_LRS or Premium_ZRS, nor can accounts of those SKU names be updated to any other value. </param>
        /// <param name="tags"> Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater in length than 128 characters and a value no greater in length than 256 characters. </param>
        /// <param name="identity"> The identity of the resource. </param>
        /// <param name="kind"> Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server. </param>
        /// <param name="customDomain"> Custom domain assigned to the storage account by the user. Name is the CNAME source. Only one custom domain is supported per storage account at this time. To clear the existing custom domain, use an empty string for the custom domain name property. </param>
        /// <param name="encryption"> Provides the encryption settings on the account. The default setting is unencrypted. </param>
        /// <param name="accessTier"> Required for storage accounts where kind = BlobStorage. The access tier used for billing. </param>
        /// <param name="azureFilesIdentityBasedAuthentication"> Provides the identity based authentication settings for Azure Files. </param>
        /// <param name="enableHttpsTrafficOnly"> Allows https traffic only to storage service if sets to true. </param>
        /// <param name="networkRuleSet"> Network rule set. </param>
        /// <param name="largeFileSharesState"> Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled. </param>
        /// <param name="routingPreference"> Maintains information about the network routing choice opted by the user for data transfer. </param>
        internal StorageAccountUpdateParameters(Sku sku, IDictionary<string, string> tags, Identity identity, Kind? kind, CustomDomain customDomain, Encryption encryption, AccessTier? accessTier, AzureFilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication, bool? enableHttpsTrafficOnly, NetworkRuleSet networkRuleSet, LargeFileSharesState? largeFileSharesState, RoutingPreference routingPreference)
        {
            Sku = sku;
            Tags = tags;
            Identity = identity;
            Kind = kind;
            CustomDomain = customDomain;
            Encryption = encryption;
            AccessTier = accessTier;
            AzureFilesIdentityBasedAuthentication = azureFilesIdentityBasedAuthentication;
            EnableHttpsTrafficOnly = enableHttpsTrafficOnly;
            NetworkRuleSet = networkRuleSet;
            LargeFileSharesState = largeFileSharesState;
            RoutingPreference = routingPreference;
        }

        /// <summary> Gets or sets the SKU name. Note that the SKU name cannot be updated to Standard_ZRS, Premium_LRS or Premium_ZRS, nor can accounts of those SKU names be updated to any other value. </summary>
        public Sku Sku { get; set; }
        /// <summary> Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater in length than 128 characters and a value no greater in length than 256 characters. </summary>
        public IDictionary<string, string> Tags { get; set; }
        /// <summary> The identity of the resource. </summary>
        public Identity Identity { get; set; }
        /// <summary> Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server. </summary>
        public Kind? Kind { get; set; }
        /// <summary> Custom domain assigned to the storage account by the user. Name is the CNAME source. Only one custom domain is supported per storage account at this time. To clear the existing custom domain, use an empty string for the custom domain name property. </summary>
        public CustomDomain CustomDomain { get; set; }
        /// <summary> Provides the encryption settings on the account. The default setting is unencrypted. </summary>
        public Encryption Encryption { get; set; }
        /// <summary> Required for storage accounts where kind = BlobStorage. The access tier used for billing. </summary>
        public AccessTier? AccessTier { get; set; }
        /// <summary> Provides the identity based authentication settings for Azure Files. </summary>
        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }
        /// <summary> Allows https traffic only to storage service if sets to true. </summary>
        public bool? EnableHttpsTrafficOnly { get; set; }
        /// <summary> Network rule set. </summary>
        public NetworkRuleSet NetworkRuleSet { get; set; }
        /// <summary> Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled. </summary>
        public LargeFileSharesState? LargeFileSharesState { get; set; }
        /// <summary> Maintains information about the network routing choice opted by the user for data transfer. </summary>
        public RoutingPreference RoutingPreference { get; set; }
    }
}
