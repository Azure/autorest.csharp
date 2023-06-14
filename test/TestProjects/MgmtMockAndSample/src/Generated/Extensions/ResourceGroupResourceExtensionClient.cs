// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace MgmtMockAndSample
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    internal partial class ResourceGroupResourceExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="ResourceGroupResourceExtensionClient"/> class for mocking. </summary>
        protected ResourceGroupResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceGroupResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of VaultResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of VaultResources and their operations over a VaultResource. </returns>
        public virtual VaultCollection GetVaults()
        {
            return GetCachedClient(Client => new VaultCollection(Client, Id));
        }

        /// <summary> Gets a collection of DiskEncryptionSetResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of DiskEncryptionSetResources and their operations over a DiskEncryptionSetResource. </returns>
        public virtual DiskEncryptionSetCollection GetDiskEncryptionSets()
        {
            return GetCachedClient(Client => new DiskEncryptionSetCollection(Client, Id));
        }

        /// <summary> Gets a collection of ManagedHsmResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of ManagedHsmResources and their operations over a ManagedHsmResource. </returns>
        public virtual ManagedHsmCollection GetManagedHsms()
        {
            return GetCachedClient(Client => new ManagedHsmCollection(Client, Id));
        }

        /// <summary> Gets a collection of FirewallPolicyResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of FirewallPolicyResources and their operations over a FirewallPolicyResource. </returns>
        public virtual FirewallPolicyCollection GetFirewallPolicies()
        {
            return GetCachedClient(Client => new FirewallPolicyCollection(Client, Id));
        }
    }
}
