// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace _Azure.ResourceManager.CommonProperties.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class Mockable_AzureResourceManagerCommonPropertiesResourceGroupResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="Mockable_AzureResourceManagerCommonPropertiesResourceGroupResource"/> class for mocking. </summary>
        protected Mockable_AzureResourceManagerCommonPropertiesResourceGroupResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="Mockable_AzureResourceManagerCommonPropertiesResourceGroupResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Mockable_AzureResourceManagerCommonPropertiesResourceGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of ManagedIdentityTrackedResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of ManagedIdentityTrackedResources and their operations over a ManagedIdentityTrackedResource. </returns>
        public virtual ManagedIdentityTrackedResourceCollection GetManagedIdentityTrackedResources()
        {
            return GetCachedClient(client => new ManagedIdentityTrackedResourceCollection(client, Id));
        }

        /// <summary>
        /// Get a ManagedIdentityTrackedResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Azure.ResourceManager.CommonProperties/managedIdentityTrackedResources/{managedIdentityTrackedResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedIdentityTrackedResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ManagedIdentityTrackedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managedIdentityTrackedResourceName"> arm resource name for path. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managedIdentityTrackedResourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="managedIdentityTrackedResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ManagedIdentityTrackedResource>> GetManagedIdentityTrackedResourceAsync(string managedIdentityTrackedResourceName, CancellationToken cancellationToken = default)
        {
            return await GetManagedIdentityTrackedResources().GetAsync(managedIdentityTrackedResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a ManagedIdentityTrackedResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Azure.ResourceManager.CommonProperties/managedIdentityTrackedResources/{managedIdentityTrackedResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedIdentityTrackedResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ManagedIdentityTrackedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managedIdentityTrackedResourceName"> arm resource name for path. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managedIdentityTrackedResourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="managedIdentityTrackedResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<ManagedIdentityTrackedResource> GetManagedIdentityTrackedResource(string managedIdentityTrackedResourceName, CancellationToken cancellationToken = default)
        {
            return GetManagedIdentityTrackedResources().Get(managedIdentityTrackedResourceName, cancellationToken);
        }
    }
}
