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
using Azure.ResourceManager.Resources;
using MgmtHierarchicalNonResource.Mocking;

namespace MgmtHierarchicalNonResource
{
    /// <summary> A class to add extension methods to MgmtHierarchicalNonResource. </summary>
    public static partial class MgmtHierarchicalNonResourceExtensions
    {
        private static MockableMgmtHierarchicalNonResourceArmClient GetMockableMgmtHierarchicalNonResourceArmClient(ArmClient client)
        {
            Argument.AssertNotNull(client, nameof(client));

            return client.GetCachedClient(client0 => new MockableMgmtHierarchicalNonResourceArmClient(client0));
        }

        private static MockableMgmtHierarchicalNonResourceSubscriptionResource GetMockableMgmtHierarchicalNonResourceSubscriptionResource(ArmResource resource)
        {
            Argument.AssertNotNull(resource, nameof(resource));

            return resource.GetCachedClient(client => new MockableMgmtHierarchicalNonResourceSubscriptionResource(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing a <see cref="SharedGalleryResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SharedGalleryResource.CreateResourceIdentifier" /> to create a <see cref="SharedGalleryResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtHierarchicalNonResourceArmClient.GetSharedGalleryResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="SharedGalleryResource" /> object. </returns>
        public static SharedGalleryResource GetSharedGalleryResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableMgmtHierarchicalNonResourceArmClient(client).GetSharedGalleryResource(id);
        }

        /// <summary>
        /// Gets a collection of SharedGalleryResources in the SubscriptionResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtHierarchicalNonResourceSubscriptionResource.GetSharedGalleries(string)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> Resource location. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="location"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> An object representing collection of SharedGalleryResources and their operations over a SharedGalleryResource. </returns>
        public static SharedGalleryCollection GetSharedGalleries(this SubscriptionResource subscriptionResource, string location)
        {
            return GetMockableMgmtHierarchicalNonResourceSubscriptionResource(subscriptionResource).GetSharedGalleries(location);
        }

        /// <summary>
        /// Get a shared gallery by subscription id or tenant id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SharedGalleries_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtHierarchicalNonResourceSubscriptionResource.GetSharedGalleryAsync(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/>, <paramref name="location"/> or <paramref name="galleryUniqueName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<SharedGalleryResource>> GetSharedGalleryAsync(this SubscriptionResource subscriptionResource, string location, string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            return await GetMockableMgmtHierarchicalNonResourceSubscriptionResource(subscriptionResource).GetSharedGalleryAsync(location, galleryUniqueName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a shared gallery by subscription id or tenant id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SharedGalleries_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtHierarchicalNonResourceSubscriptionResource.GetSharedGallery(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/>, <paramref name="location"/> or <paramref name="galleryUniqueName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<SharedGalleryResource> GetSharedGallery(this SubscriptionResource subscriptionResource, string location, string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            return GetMockableMgmtHierarchicalNonResourceSubscriptionResource(subscriptionResource).GetSharedGallery(location, galleryUniqueName, cancellationToken);
        }
    }
}
