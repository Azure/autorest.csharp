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
using MgmtSafeFlatten;

namespace MgmtSafeFlatten.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class MgmtSafeFlattenResourceGroupMockingExtension : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MgmtSafeFlattenResourceGroupMockingExtension"/> class for mocking. </summary>
        protected MgmtSafeFlattenResourceGroupMockingExtension()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtSafeFlattenResourceGroupMockingExtension"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MgmtSafeFlattenResourceGroupMockingExtension(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of TypeOneResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of TypeOneResources and their operations over a TypeOneResource. </returns>
        public virtual TypeOneCollection GetTypeOnes()
        {
            return GetCachedClient(client => new TypeOneCollection(client, Id));
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeOne</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<TypeOneResource>> GetTypeOneAsync(string typeOneName, CancellationToken cancellationToken = default)
        {
            return await GetTypeOnes().GetAsync(typeOneName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeOne</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<TypeOneResource> GetTypeOne(string typeOneName, CancellationToken cancellationToken = default)
        {
            return GetTypeOnes().Get(typeOneName, cancellationToken);
        }

        /// <summary> Gets a collection of TypeTwoResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of TypeTwoResources and their operations over a TypeTwoResource. </returns>
        public virtual TypeTwoCollection GetTypeTwos()
        {
            return GetCachedClient(client => new TypeTwoCollection(client, Id));
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeTwo</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<TypeTwoResource>> GetTypeTwoAsync(string typeTwoName, CancellationToken cancellationToken = default)
        {
            return await GetTypeTwos().GetAsync(typeTwoName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeTwo</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<TypeTwoResource> GetTypeTwo(string typeTwoName, CancellationToken cancellationToken = default)
        {
            return GetTypeTwos().Get(typeTwoName, cancellationToken);
        }
    }
}
