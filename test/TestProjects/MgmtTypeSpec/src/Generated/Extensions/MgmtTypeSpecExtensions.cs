// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using MgmtTypeSpec.Mocking;
using MgmtTypeSpec.Models;

namespace MgmtTypeSpec
{
    /// <summary> A class to add extension methods to MgmtTypeSpec. </summary>
    public static partial class MgmtTypeSpecExtensions
    {
        private static MockableMgmtTypeSpecResourceGroupResource GetMockableMgmtTypeSpecResourceGroupResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableMgmtTypeSpecResourceGroupResource(client, resource.Id));
        }

        /// <summary>
        /// list private links on the given resource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/privateLinkResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PrivateLinkResource_ListByMongoCluster</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>v1</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtTypeSpecResourceGroupResource.GetPrivateLinksByMongoCluster(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="MgmtTypeSpecPrivateLinkResourceData"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<MgmtTypeSpecPrivateLinkResourceData> GetPrivateLinksByMongoClusterAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtTypeSpecResourceGroupResource(resourceGroupResource).GetPrivateLinksByMongoClusterAsync(cancellationToken);
        }

        /// <summary>
        /// list private links on the given resource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/privateLinkResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PrivateLinkResource_ListByMongoCluster</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>v1</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtTypeSpecResourceGroupResource.GetPrivateLinksByMongoCluster(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> A collection of <see cref="MgmtTypeSpecPrivateLinkResourceData"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<MgmtTypeSpecPrivateLinkResourceData> GetPrivateLinksByMongoCluster(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtTypeSpecResourceGroupResource(resourceGroupResource).GetPrivateLinksByMongoCluster(cancellationToken);
        }
    }
}
