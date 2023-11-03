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
using MgmtSingletonResource;

namespace MgmtSingletonResource.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class MockableMgmtSingletonResourceResourceGroupResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableMgmtSingletonResourceResourceGroupResource"/> class for mocking. </summary>
        protected MockableMgmtSingletonResourceResourceGroupResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtSingletonResourceResourceGroupResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMgmtSingletonResourceResourceGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of CarResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of CarResources and their operations over a CarResource. </returns>
        public virtual CarCollection GetCars()
        {
            return GetCachedClient(client => new CarCollection(client, Id));
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Cars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<CarResource>> GetCarAsync(string carName, CancellationToken cancellationToken = default)
        {
            return await GetCars().GetAsync(carName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Cars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<CarResource> GetCar(string carName, CancellationToken cancellationToken = default)
        {
            return GetCars().Get(carName, cancellationToken);
        }

        /// <summary> Gets a collection of ParentResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of ParentResources and their operations over a ParentResource. </returns>
        public virtual ParentResourceCollection GetParentResources()
        {
            return GetCachedClient(client => new ParentResourceCollection(client, Id));
        }

        /// <summary>
        /// Singleton Test Parent Example.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ParentResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ParentResource>> GetParentResourceAsync(string parentName, CancellationToken cancellationToken = default)
        {
            return await GetParentResources().GetAsync(parentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Singleton Test Parent Example.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ParentResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<ParentResource> GetParentResource(string parentName, CancellationToken cancellationToken = default)
        {
            return GetParentResources().Get(parentName, cancellationToken);
        }
    }
}
