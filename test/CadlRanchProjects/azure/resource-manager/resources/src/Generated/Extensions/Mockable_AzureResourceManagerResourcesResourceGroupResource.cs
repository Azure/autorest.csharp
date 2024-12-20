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

namespace _Azure.ResourceManager.Resources.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class Mockable_AzureResourceManagerResourcesResourceGroupResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="Mockable_AzureResourceManagerResourcesResourceGroupResource"/> class for mocking. </summary>
        protected Mockable_AzureResourceManagerResourcesResourceGroupResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="Mockable_AzureResourceManagerResourcesResourceGroupResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Mockable_AzureResourceManagerResourcesResourceGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of TopLevelTrackedResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of TopLevelTrackedResources and their operations over a TopLevelTrackedResource. </returns>
        public virtual TopLevelTrackedResourceCollection GetTopLevelTrackedResources()
        {
            return GetCachedClient(client => new TopLevelTrackedResourceCollection(client, Id));
        }

        /// <summary>
        /// Get a TopLevelTrackedResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Azure.ResourceManager.Resources/topLevelTrackedResources/{topLevelTrackedResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TopLevelTrackedResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TopLevelTrackedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="topLevelTrackedResourceName"> arm resource name for path. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topLevelTrackedResourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topLevelTrackedResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<TopLevelTrackedResource>> GetTopLevelTrackedResourceAsync(string topLevelTrackedResourceName, CancellationToken cancellationToken = default)
        {
            return await GetTopLevelTrackedResources().GetAsync(topLevelTrackedResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a TopLevelTrackedResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Azure.ResourceManager.Resources/topLevelTrackedResources/{topLevelTrackedResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TopLevelTrackedResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TopLevelTrackedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="topLevelTrackedResourceName"> arm resource name for path. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topLevelTrackedResourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topLevelTrackedResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<TopLevelTrackedResource> GetTopLevelTrackedResource(string topLevelTrackedResourceName, CancellationToken cancellationToken = default)
        {
            return GetTopLevelTrackedResources().Get(topLevelTrackedResourceName, cancellationToken);
        }

        /// <summary> Gets an object representing a SingletonTrackedResource along with the instance operations that can be performed on it in the ResourceGroupResource. </summary>
        /// <returns> Returns a <see cref="SingletonTrackedResource"/> object. </returns>
        public virtual SingletonTrackedResource GetSingletonTrackedResource()
        {
            return new SingletonTrackedResource(Client, Id.AppendProviderResource("Azure.ResourceManager.Resources", "singletonTrackedResources", "default"));
        }
    }
}
