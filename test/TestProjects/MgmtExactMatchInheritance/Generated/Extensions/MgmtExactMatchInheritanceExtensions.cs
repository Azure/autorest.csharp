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
using MgmtExactMatchInheritance.Models;

namespace MgmtExactMatchInheritance
{
    /// <summary> A class to add extension methods to MgmtExactMatchInheritance. </summary>
    public static partial class MgmtExactMatchInheritanceExtensions
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
        #region ExactMatchModel1Resource
        /// <summary>
        /// Gets an object representing an <see cref="ExactMatchModel1Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ExactMatchModel1Resource.CreateResourceIdentifier" /> to create an <see cref="ExactMatchModel1Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ExactMatchModel1Resource" /> object. </returns>
        public static ExactMatchModel1Resource GetExactMatchModel1Resource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ExactMatchModel1Resource.ValidateResourceId(id);
                return new ExactMatchModel1Resource(client, id);
            }
            );
        }
        #endregion

        #region ExactMatchModel5Resource
        /// <summary>
        /// Gets an object representing an <see cref="ExactMatchModel5Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ExactMatchModel5Resource.CreateResourceIdentifier" /> to create an <see cref="ExactMatchModel5Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ExactMatchModel5Resource" /> object. </returns>
        public static ExactMatchModel5Resource GetExactMatchModel5Resource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ExactMatchModel5Resource.ValidateResourceId(id);
                return new ExactMatchModel5Resource(client, id);
            }
            );
        }
        #endregion

        /// <summary> Gets a collection of ExactMatchModel1Resources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ExactMatchModel1Resources and their operations over a ExactMatchModel1Resource. </returns>
        public static ExactMatchModel1Collection GetExactMatchModel1s(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetExactMatchModel1s();
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel1SName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ExactMatchModel1Resource>> GetExactMatchModel1Async(this ResourceGroupResource resourceGroupResource, string exactMatchModel1SName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetExactMatchModel1s().GetAsync(exactMatchModel1SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel1SName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ExactMatchModel1Resource> GetExactMatchModel1(this ResourceGroupResource resourceGroupResource, string exactMatchModel1SName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetExactMatchModel1s().Get(exactMatchModel1SName, cancellationToken);
        }

        /// <summary> Gets a collection of ExactMatchModel5Resources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ExactMatchModel5Resources and their operations over a ExactMatchModel5Resource. </returns>
        public static ExactMatchModel5Collection GetExactMatchModel5s(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetExactMatchModel5s();
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel5s/{exactMatchModel5sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel5s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel5SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel5SName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ExactMatchModel5Resource>> GetExactMatchModel5Async(this ResourceGroupResource resourceGroupResource, string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetExactMatchModel5s().GetAsync(exactMatchModel5SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel5s/{exactMatchModel5sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel5s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel5SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel5SName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ExactMatchModel5Resource> GetExactMatchModel5(this ResourceGroupResource resourceGroupResource, string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetExactMatchModel5s().Get(exactMatchModel5SName, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel2s/{exactMatchModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="exactMatchModel2SName"> The String to use. </param>
        /// <param name="exactMatchModel2"> The ExactMatchModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel2SName"/> or <paramref name="exactMatchModel2"/> is null. </exception>
        public static async Task<Response<ExactMatchModel2>> PutExactMatchModel2Async(this ResourceGroupResource resourceGroupResource, string exactMatchModel2SName, ExactMatchModel2 exactMatchModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel2SName, nameof(exactMatchModel2SName));
            Argument.AssertNotNull(exactMatchModel2, nameof(exactMatchModel2));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutExactMatchModel2Async(exactMatchModel2SName, exactMatchModel2, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel2s/{exactMatchModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="exactMatchModel2SName"> The String to use. </param>
        /// <param name="exactMatchModel2"> The ExactMatchModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel2SName"/> or <paramref name="exactMatchModel2"/> is null. </exception>
        public static Response<ExactMatchModel2> PutExactMatchModel2(this ResourceGroupResource resourceGroupResource, string exactMatchModel2SName, ExactMatchModel2 exactMatchModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel2SName, nameof(exactMatchModel2SName));
            Argument.AssertNotNull(exactMatchModel2, nameof(exactMatchModel2));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutExactMatchModel2(exactMatchModel2SName, exactMatchModel2, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel3s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel3s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ExactMatchModel3" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ExactMatchModel3> GetExactMatchModel3sAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetExactMatchModel3sAsync(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel3s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel3s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ExactMatchModel3" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ExactMatchModel3> GetExactMatchModel3s(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetExactMatchModel3s(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel3s/{exactMatchModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel3s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="exactMatchModel3"> The ExactMatchModel3 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel3SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel3SName"/> or <paramref name="exactMatchModel3"/> is null. </exception>
        public static async Task<Response<ExactMatchModel3>> PutExactMatchModel3Async(this ResourceGroupResource resourceGroupResource, string exactMatchModel3SName, ExactMatchModel3 exactMatchModel3, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel3SName, nameof(exactMatchModel3SName));
            Argument.AssertNotNull(exactMatchModel3, nameof(exactMatchModel3));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutExactMatchModel3Async(exactMatchModel3SName, exactMatchModel3, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel3s/{exactMatchModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel3s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="exactMatchModel3"> The ExactMatchModel3 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel3SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel3SName"/> or <paramref name="exactMatchModel3"/> is null. </exception>
        public static Response<ExactMatchModel3> PutExactMatchModel3(this ResourceGroupResource resourceGroupResource, string exactMatchModel3SName, ExactMatchModel3 exactMatchModel3, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel3SName, nameof(exactMatchModel3SName));
            Argument.AssertNotNull(exactMatchModel3, nameof(exactMatchModel3));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutExactMatchModel3(exactMatchModel3SName, exactMatchModel3, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel3s/{exactMatchModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel3s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel3SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel3SName"/> is null. </exception>
        public static async Task<Response<ExactMatchModel3>> GetExactMatchModel3Async(this ResourceGroupResource resourceGroupResource, string exactMatchModel3SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel3SName, nameof(exactMatchModel3SName));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).GetExactMatchModel3Async(exactMatchModel3SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel3s/{exactMatchModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel3s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel3SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel3SName"/> is null. </exception>
        public static Response<ExactMatchModel3> GetExactMatchModel3(this ResourceGroupResource resourceGroupResource, string exactMatchModel3SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel3SName, nameof(exactMatchModel3SName));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetExactMatchModel3(exactMatchModel3SName, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel4s/{exactMatchModel4sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel4s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="exactMatchModel4SName"> The String to use. </param>
        /// <param name="exactMatchModel4"> The ExactMatchModel4 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel4SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel4SName"/> or <paramref name="exactMatchModel4"/> is null. </exception>
        public static async Task<Response<ExactMatchModel4>> PutExactMatchModel4Async(this ResourceGroupResource resourceGroupResource, string exactMatchModel4SName, ExactMatchModel4 exactMatchModel4, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel4SName, nameof(exactMatchModel4SName));
            Argument.AssertNotNull(exactMatchModel4, nameof(exactMatchModel4));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutExactMatchModel4Async(exactMatchModel4SName, exactMatchModel4, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel4s/{exactMatchModel4sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel4s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="exactMatchModel4SName"> The String to use. </param>
        /// <param name="exactMatchModel4"> The ExactMatchModel4 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel4SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel4SName"/> or <paramref name="exactMatchModel4"/> is null. </exception>
        public static Response<ExactMatchModel4> PutExactMatchModel4(this ResourceGroupResource resourceGroupResource, string exactMatchModel4SName, ExactMatchModel4 exactMatchModel4, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel4SName, nameof(exactMatchModel4SName));
            Argument.AssertNotNull(exactMatchModel4, nameof(exactMatchModel4));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutExactMatchModel4(exactMatchModel4SName, exactMatchModel4, cancellationToken);
        }
    }
}
