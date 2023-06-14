// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using MgmtSupersetFlattenInheritance.Models;

namespace MgmtSupersetFlattenInheritance
{
    /// <summary> A class to add extension methods to MgmtSupersetFlattenInheritance. </summary>
    public static partial class MgmtSupersetFlattenInheritanceExtensions
    {
        private static ResourceGroupResourceExtensionClient GetResourceGroupResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new ResourceGroupResourceExtensionClient(client, resource.Id);
            });
        }

        private static ResourceGroupResourceExtensionClient GetResourceGroupResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new ResourceGroupResourceExtensionClient(client, scope);
            });
        }
        #region ResourceModel1Resource
        /// <summary>
        /// Gets an object representing a <see cref="ResourceModel1Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ResourceModel1Resource.CreateResourceIdentifier" /> to create a <see cref="ResourceModel1Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ResourceModel1Resource" /> object. </returns>
        public static ResourceModel1Resource GetResourceModel1Resource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ResourceModel1Resource.ValidateResourceId(id);
                return new ResourceModel1Resource(client, id);
            }
            );
        }
        #endregion

        #region TrackedResourceModel1Resource
        /// <summary>
        /// Gets an object representing a <see cref="TrackedResourceModel1Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TrackedResourceModel1Resource.CreateResourceIdentifier" /> to create a <see cref="TrackedResourceModel1Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TrackedResourceModel1Resource" /> object. </returns>
        public static TrackedResourceModel1Resource GetTrackedResourceModel1Resource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                TrackedResourceModel1Resource.ValidateResourceId(id);
                return new TrackedResourceModel1Resource(client, id);
            }
            );
        }
        #endregion

        /// <summary> Gets a collection of ResourceModel1Resources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ResourceModel1Resources and their operations over a ResourceModel1Resource. </returns>
        public static ResourceModel1Collection GetResourceModel1s(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetResourceModel1s();
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s/{resourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ResourceModel1Resource>> GetResourceModel1Async(this ResourceGroupResource resourceGroupResource, string resourceModel1SName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetResourceModel1s().GetAsync(resourceModel1SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s/{resourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ResourceModel1Resource> GetResourceModel1(this ResourceGroupResource resourceGroupResource, string resourceModel1SName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetResourceModel1s().Get(resourceModel1SName, cancellationToken);
        }

        /// <summary> Gets a collection of TrackedResourceModel1Resources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of TrackedResourceModel1Resources and their operations over a TrackedResourceModel1Resource. </returns>
        public static TrackedResourceModel1Collection GetTrackedResourceModel1s(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetTrackedResourceModel1s();
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s/{trackedResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrackedResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<TrackedResourceModel1Resource>> GetTrackedResourceModel1Async(this ResourceGroupResource resourceGroupResource, string trackedResourceModel1SName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetTrackedResourceModel1s().GetAsync(trackedResourceModel1SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s/{trackedResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrackedResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<TrackedResourceModel1Resource> GetTrackedResourceModel1(this ResourceGroupResource resourceGroupResource, string trackedResourceModel1SName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetTrackedResourceModel1s().Get(trackedResourceModel1SName, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel1s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CustomModel1" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<CustomModel1> GetCustomModel1sAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetCustomModel1sAsync(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel1s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CustomModel1" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<CustomModel1> GetCustomModel1s(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetCustomModel1s(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel1s/{customModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="customModel1"> The CustomModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customModel1SName"/> or <paramref name="customModel1"/> is null. </exception>
        public static async Task<Response<CustomModel1>> PutCustomModel1Async(this ResourceGroupResource resourceGroupResource, string customModel1SName, CustomModel1 customModel1, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customModel1SName, nameof(customModel1SName));
            Argument.AssertNotNull(customModel1, nameof(customModel1));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutCustomModel1Async(customModel1SName, customModel1, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel1s/{customModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="customModel1"> The CustomModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customModel1SName"/> or <paramref name="customModel1"/> is null. </exception>
        public static Response<CustomModel1> PutCustomModel1(this ResourceGroupResource resourceGroupResource, string customModel1SName, CustomModel1 customModel1, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customModel1SName, nameof(customModel1SName));
            Argument.AssertNotNull(customModel1, nameof(customModel1));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutCustomModel1(customModel1SName, customModel1, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel1s/{customModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customModel1SName"/> is null. </exception>
        public static async Task<Response<CustomModel1>> GetCustomModel1Async(this ResourceGroupResource resourceGroupResource, string customModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customModel1SName, nameof(customModel1SName));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).GetCustomModel1Async(customModel1SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel1s/{customModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customModel1SName"/> is null. </exception>
        public static Response<CustomModel1> GetCustomModel1(this ResourceGroupResource resourceGroupResource, string customModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customModel1SName, nameof(customModel1SName));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetCustomModel1(customModel1SName, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CustomModel2" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<CustomModel2> GetCustomModel2sAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetCustomModel2sAsync(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CustomModel2" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<CustomModel2> GetCustomModel2s(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetCustomModel2s(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel2s/{customModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="customModel2SName"> The String to use. </param>
        /// <param name="customModel2"> The CustomModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customModel2SName"/> or <paramref name="customModel2"/> is null. </exception>
        public static async Task<Response<CustomModel2>> PutCustomModel2Async(this ResourceGroupResource resourceGroupResource, string customModel2SName, CustomModel2 customModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customModel2SName, nameof(customModel2SName));
            Argument.AssertNotNull(customModel2, nameof(customModel2));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutCustomModel2Async(customModel2SName, customModel2, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel2s/{customModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="customModel2SName"> The String to use. </param>
        /// <param name="customModel2"> The CustomModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customModel2SName"/> or <paramref name="customModel2"/> is null. </exception>
        public static Response<CustomModel2> PutCustomModel2(this ResourceGroupResource resourceGroupResource, string customModel2SName, CustomModel2 customModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customModel2SName, nameof(customModel2SName));
            Argument.AssertNotNull(customModel2, nameof(customModel2));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutCustomModel2(customModel2SName, customModel2, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel2s/{customModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="customModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customModel2SName"/> is null. </exception>
        public static async Task<Response<CustomModel2>> GetCustomModel2Async(this ResourceGroupResource resourceGroupResource, string customModel2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customModel2SName, nameof(customModel2SName));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).GetCustomModel2Async(customModel2SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel2s/{customModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="customModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customModel2SName"/> is null. </exception>
        public static Response<CustomModel2> GetCustomModel2(this ResourceGroupResource resourceGroupResource, string customModel2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customModel2SName, nameof(customModel2SName));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetCustomModel2(customModel2SName, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel1s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubResourceModel1" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<SubResourceModel1> GetSubResourceModel1sAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetSubResourceModel1sAsync(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel1s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubResourceModel1" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<SubResourceModel1> GetSubResourceModel1s(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetSubResourceModel1s(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel1s/{subResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="subResourceModel1"> The SubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel1SName"/> or <paramref name="subResourceModel1"/> is null. </exception>
        public static async Task<Response<SubResourceModel1>> PutSubResourceModel1Async(this ResourceGroupResource resourceGroupResource, string subResourceModel1SName, SubResourceModel1 subResourceModel1, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subResourceModel1SName, nameof(subResourceModel1SName));
            Argument.AssertNotNull(subResourceModel1, nameof(subResourceModel1));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutSubResourceModel1Async(subResourceModel1SName, subResourceModel1, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel1s/{subResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="subResourceModel1"> The SubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel1SName"/> or <paramref name="subResourceModel1"/> is null. </exception>
        public static Response<SubResourceModel1> PutSubResourceModel1(this ResourceGroupResource resourceGroupResource, string subResourceModel1SName, SubResourceModel1 subResourceModel1, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subResourceModel1SName, nameof(subResourceModel1SName));
            Argument.AssertNotNull(subResourceModel1, nameof(subResourceModel1));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutSubResourceModel1(subResourceModel1SName, subResourceModel1, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel1s/{subResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel1SName"/> is null. </exception>
        public static async Task<Response<SubResourceModel1>> GetSubResourceModel1Async(this ResourceGroupResource resourceGroupResource, string subResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subResourceModel1SName, nameof(subResourceModel1SName));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).GetSubResourceModel1Async(subResourceModel1SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel1s/{subResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel1SName"/> is null. </exception>
        public static Response<SubResourceModel1> GetSubResourceModel1(this ResourceGroupResource resourceGroupResource, string subResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subResourceModel1SName, nameof(subResourceModel1SName));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetSubResourceModel1(subResourceModel1SName, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<SubResourceModel2> GetSubResourceModel2sAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetSubResourceModel2sAsync(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<SubResourceModel2> GetSubResourceModel2s(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetSubResourceModel2s(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel2s/{subResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="subResourceModel2"> The SubResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subResourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel2SName"/> or <paramref name="subResourceModel2"/> is null. </exception>
        public static async Task<Response<SubResourceModel2>> PutSubResourceModel2Async(this ResourceGroupResource resourceGroupResource, string subResourceModel2SName, SubResourceModel2 subResourceModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subResourceModel2SName, nameof(subResourceModel2SName));
            Argument.AssertNotNull(subResourceModel2, nameof(subResourceModel2));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutSubResourceModel2Async(subResourceModel2SName, subResourceModel2, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel2s/{subResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="subResourceModel2"> The SubResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subResourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel2SName"/> or <paramref name="subResourceModel2"/> is null. </exception>
        public static Response<SubResourceModel2> PutSubResourceModel2(this ResourceGroupResource resourceGroupResource, string subResourceModel2SName, SubResourceModel2 subResourceModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subResourceModel2SName, nameof(subResourceModel2SName));
            Argument.AssertNotNull(subResourceModel2, nameof(subResourceModel2));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutSubResourceModel2(subResourceModel2SName, subResourceModel2, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel2s/{subResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subResourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel2SName"/> is null. </exception>
        public static async Task<Response<SubResourceModel2>> GetSubResourceModel2Async(this ResourceGroupResource resourceGroupResource, string subResourceModel2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subResourceModel2SName, nameof(subResourceModel2SName));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).GetSubResourceModel2Async(subResourceModel2SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel2s/{subResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subResourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel2SName"/> is null. </exception>
        public static Response<SubResourceModel2> GetSubResourceModel2(this ResourceGroupResource resourceGroupResource, string subResourceModel2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subResourceModel2SName, nameof(subResourceModel2SName));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetSubResourceModel2(subResourceModel2SName, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel1s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="WritableSubResourceModel1" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<WritableSubResourceModel1> GetWritableSubResourceModel1sAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetWritableSubResourceModel1sAsync(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel1s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="WritableSubResourceModel1" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<WritableSubResourceModel1> GetWritableSubResourceModel1s(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetWritableSubResourceModel1s(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel1s/{writableSubResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="writableSubResourceModel1"> The WritableSubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="writableSubResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResourceModel1SName"/> or <paramref name="writableSubResourceModel1"/> is null. </exception>
        public static async Task<Response<WritableSubResourceModel1>> PutWritableSubResourceModel1Async(this ResourceGroupResource resourceGroupResource, string writableSubResourceModel1SName, WritableSubResourceModel1 writableSubResourceModel1, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(writableSubResourceModel1SName, nameof(writableSubResourceModel1SName));
            Argument.AssertNotNull(writableSubResourceModel1, nameof(writableSubResourceModel1));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutWritableSubResourceModel1Async(writableSubResourceModel1SName, writableSubResourceModel1, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel1s/{writableSubResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="writableSubResourceModel1"> The WritableSubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="writableSubResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResourceModel1SName"/> or <paramref name="writableSubResourceModel1"/> is null. </exception>
        public static Response<WritableSubResourceModel1> PutWritableSubResourceModel1(this ResourceGroupResource resourceGroupResource, string writableSubResourceModel1SName, WritableSubResourceModel1 writableSubResourceModel1, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(writableSubResourceModel1SName, nameof(writableSubResourceModel1SName));
            Argument.AssertNotNull(writableSubResourceModel1, nameof(writableSubResourceModel1));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutWritableSubResourceModel1(writableSubResourceModel1SName, writableSubResourceModel1, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel1s/{writableSubResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="writableSubResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResourceModel1SName"/> is null. </exception>
        public static async Task<Response<WritableSubResourceModel1>> GetWritableSubResourceModel1Async(this ResourceGroupResource resourceGroupResource, string writableSubResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(writableSubResourceModel1SName, nameof(writableSubResourceModel1SName));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).GetWritableSubResourceModel1Async(writableSubResourceModel1SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel1s/{writableSubResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="writableSubResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResourceModel1SName"/> is null. </exception>
        public static Response<WritableSubResourceModel1> GetWritableSubResourceModel1(this ResourceGroupResource resourceGroupResource, string writableSubResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(writableSubResourceModel1SName, nameof(writableSubResourceModel1SName));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetWritableSubResourceModel1(writableSubResourceModel1SName, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="WritableSubResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<WritableSubResourceModel2> GetWritableSubResourceModel2sAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetWritableSubResourceModel2sAsync(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="WritableSubResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<WritableSubResourceModel2> GetWritableSubResourceModel2s(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetWritableSubResourceModel2s(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel2s/{writableSubResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="writableSubResourceModel2SName"> The String to use. </param>
        /// <param name="writableSubResourceModel2"> The WritableSubResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="writableSubResourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResourceModel2SName"/> or <paramref name="writableSubResourceModel2"/> is null. </exception>
        public static async Task<Response<WritableSubResourceModel2>> PutWritableSubResourceModel2Async(this ResourceGroupResource resourceGroupResource, string writableSubResourceModel2SName, WritableSubResourceModel2 writableSubResourceModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(writableSubResourceModel2SName, nameof(writableSubResourceModel2SName));
            Argument.AssertNotNull(writableSubResourceModel2, nameof(writableSubResourceModel2));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutWritableSubResourceModel2Async(writableSubResourceModel2SName, writableSubResourceModel2, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel2s/{writableSubResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="writableSubResourceModel2SName"> The String to use. </param>
        /// <param name="writableSubResourceModel2"> The WritableSubResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="writableSubResourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResourceModel2SName"/> or <paramref name="writableSubResourceModel2"/> is null. </exception>
        public static Response<WritableSubResourceModel2> PutWritableSubResourceModel2(this ResourceGroupResource resourceGroupResource, string writableSubResourceModel2SName, WritableSubResourceModel2 writableSubResourceModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(writableSubResourceModel2SName, nameof(writableSubResourceModel2SName));
            Argument.AssertNotNull(writableSubResourceModel2, nameof(writableSubResourceModel2));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutWritableSubResourceModel2(writableSubResourceModel2SName, writableSubResourceModel2, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel2s/{writableSubResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="writableSubResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="writableSubResourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResourceModel2SName"/> is null. </exception>
        public static async Task<Response<WritableSubResourceModel2>> GetWritableSubResourceModel2Async(this ResourceGroupResource resourceGroupResource, string writableSubResourceModel2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(writableSubResourceModel2SName, nameof(writableSubResourceModel2SName));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).GetWritableSubResourceModel2Async(writableSubResourceModel2SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel2s/{writableSubResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="writableSubResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="writableSubResourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResourceModel2SName"/> is null. </exception>
        public static Response<WritableSubResourceModel2> GetWritableSubResourceModel2(this ResourceGroupResource resourceGroupResource, string writableSubResourceModel2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(writableSubResourceModel2SName, nameof(writableSubResourceModel2SName));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetWritableSubResourceModel2(writableSubResourceModel2SName, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ResourceModel2> GetResourceModel2sAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetResourceModel2sAsync(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ResourceModel2> GetResourceModel2s(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetResourceModel2s(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel2s/{resourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="resourceModel2"> The ResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel2SName"/> or <paramref name="resourceModel2"/> is null. </exception>
        public static async Task<Response<ResourceModel2>> PutResourceModel2Async(this ResourceGroupResource resourceGroupResource, string resourceModel2SName, ResourceModel2 resourceModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceModel2SName, nameof(resourceModel2SName));
            Argument.AssertNotNull(resourceModel2, nameof(resourceModel2));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutResourceModel2Async(resourceModel2SName, resourceModel2, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel2s/{resourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="resourceModel2"> The ResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel2SName"/> or <paramref name="resourceModel2"/> is null. </exception>
        public static Response<ResourceModel2> PutResourceModel2(this ResourceGroupResource resourceGroupResource, string resourceModel2SName, ResourceModel2 resourceModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceModel2SName, nameof(resourceModel2SName));
            Argument.AssertNotNull(resourceModel2, nameof(resourceModel2));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutResourceModel2(resourceModel2SName, resourceModel2, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel2s/{resourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel2SName"/> is null. </exception>
        public static async Task<Response<ResourceModel2>> GetResourceModel2Async(this ResourceGroupResource resourceGroupResource, string resourceModel2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceModel2SName, nameof(resourceModel2SName));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).GetResourceModel2Async(resourceModel2SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel2s/{resourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel2SName"/> is null. </exception>
        public static Response<ResourceModel2> GetResourceModel2(this ResourceGroupResource resourceGroupResource, string resourceModel2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceModel2SName, nameof(resourceModel2SName));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetResourceModel2(resourceModel2SName, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrackedResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TrackedResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<TrackedResourceModel2> GetTrackedResourceModel2sAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetTrackedResourceModel2sAsync(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrackedResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TrackedResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<TrackedResourceModel2> GetTrackedResourceModel2s(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetTrackedResourceModel2s(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel2s/{trackedResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrackedResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="trackedResourceModel2"> The TrackedResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel2SName"/> or <paramref name="trackedResourceModel2"/> is null. </exception>
        public static async Task<Response<TrackedResourceModel2>> PutTrackedResourceModel2Async(this ResourceGroupResource resourceGroupResource, string trackedResourceModel2SName, TrackedResourceModel2 trackedResourceModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel2SName, nameof(trackedResourceModel2SName));
            Argument.AssertNotNull(trackedResourceModel2, nameof(trackedResourceModel2));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutTrackedResourceModel2Async(trackedResourceModel2SName, trackedResourceModel2, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel2s/{trackedResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrackedResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="trackedResourceModel2"> The TrackedResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel2SName"/> or <paramref name="trackedResourceModel2"/> is null. </exception>
        public static Response<TrackedResourceModel2> PutTrackedResourceModel2(this ResourceGroupResource resourceGroupResource, string trackedResourceModel2SName, TrackedResourceModel2 trackedResourceModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel2SName, nameof(trackedResourceModel2SName));
            Argument.AssertNotNull(trackedResourceModel2, nameof(trackedResourceModel2));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutTrackedResourceModel2(trackedResourceModel2SName, trackedResourceModel2, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel2s/{trackedResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrackedResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel2SName"/> is null. </exception>
        public static async Task<Response<TrackedResourceModel2>> GetTrackedResourceModel2Async(this ResourceGroupResource resourceGroupResource, string trackedResourceModel2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel2SName, nameof(trackedResourceModel2SName));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).GetTrackedResourceModel2Async(trackedResourceModel2SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel2s/{trackedResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrackedResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel2SName"/> is null. </exception>
        public static Response<TrackedResourceModel2> GetTrackedResourceModel2(this ResourceGroupResource resourceGroupResource, string trackedResourceModel2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel2SName, nameof(trackedResourceModel2SName));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetTrackedResourceModel2(trackedResourceModel2SName, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/nonResourceModel1s/{nonResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NonResourceModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="nonResourceModel1SName"> The String to use. </param>
        /// <param name="nonResourceModel1"> The NonResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="nonResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="nonResourceModel1SName"/> or <paramref name="nonResourceModel1"/> is null. </exception>
        public static async Task<Response<NonResourceModel1>> PutNonResourceModel1Async(this ResourceGroupResource resourceGroupResource, string nonResourceModel1SName, NonResourceModel1 nonResourceModel1, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(nonResourceModel1SName, nameof(nonResourceModel1SName));
            Argument.AssertNotNull(nonResourceModel1, nameof(nonResourceModel1));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutNonResourceModel1Async(nonResourceModel1SName, nonResourceModel1, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/nonResourceModel1s/{nonResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NonResourceModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="nonResourceModel1SName"> The String to use. </param>
        /// <param name="nonResourceModel1"> The NonResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="nonResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="nonResourceModel1SName"/> or <paramref name="nonResourceModel1"/> is null. </exception>
        public static Response<NonResourceModel1> PutNonResourceModel1(this ResourceGroupResource resourceGroupResource, string nonResourceModel1SName, NonResourceModel1 nonResourceModel1, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(nonResourceModel1SName, nameof(nonResourceModel1SName));
            Argument.AssertNotNull(nonResourceModel1, nameof(nonResourceModel1));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutNonResourceModel1(nonResourceModel1SName, nonResourceModel1, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/nonResourceModel1s/{nonResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NonResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="nonResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="nonResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="nonResourceModel1SName"/> is null. </exception>
        public static async Task<Response<NonResourceModel1>> GetNonResourceModel1Async(this ResourceGroupResource resourceGroupResource, string nonResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(nonResourceModel1SName, nameof(nonResourceModel1SName));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).GetNonResourceModel1Async(nonResourceModel1SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/nonResourceModel1s/{nonResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NonResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="nonResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="nonResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="nonResourceModel1SName"/> is null. </exception>
        public static Response<NonResourceModel1> GetNonResourceModel1(this ResourceGroupResource resourceGroupResource, string nonResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(nonResourceModel1SName, nameof(nonResourceModel1SName));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetNonResourceModel1(nonResourceModel1SName, cancellationToken);
        }
    }
}
