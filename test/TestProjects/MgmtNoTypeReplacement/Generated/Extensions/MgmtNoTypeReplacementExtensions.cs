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

namespace MgmtNoTypeReplacement
{
    /// <summary> A class to add extension methods to MgmtNoTypeReplacement. </summary>
    public static partial class MgmtNoTypeReplacementExtensions
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
        #region NoTypeReplacementModel1Resource
        /// <summary>
        /// Gets an object representing a <see cref="NoTypeReplacementModel1Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NoTypeReplacementModel1Resource.CreateResourceIdentifier" /> to create a <see cref="NoTypeReplacementModel1Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NoTypeReplacementModel1Resource" /> object. </returns>
        public static NoTypeReplacementModel1Resource GetNoTypeReplacementModel1Resource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                NoTypeReplacementModel1Resource.ValidateResourceId(id);
                return new NoTypeReplacementModel1Resource(client, id);
            }
            );
        }
        #endregion

        #region NoTypeReplacementModel2Resource
        /// <summary>
        /// Gets an object representing a <see cref="NoTypeReplacementModel2Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NoTypeReplacementModel2Resource.CreateResourceIdentifier" /> to create a <see cref="NoTypeReplacementModel2Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NoTypeReplacementModel2Resource" /> object. </returns>
        public static NoTypeReplacementModel2Resource GetNoTypeReplacementModel2Resource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                NoTypeReplacementModel2Resource.ValidateResourceId(id);
                return new NoTypeReplacementModel2Resource(client, id);
            }
            );
        }
        #endregion

        #region NoTypeReplacementModel3Resource
        /// <summary>
        /// Gets an object representing a <see cref="NoTypeReplacementModel3Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NoTypeReplacementModel3Resource.CreateResourceIdentifier" /> to create a <see cref="NoTypeReplacementModel3Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NoTypeReplacementModel3Resource" /> object. </returns>
        public static NoTypeReplacementModel3Resource GetNoTypeReplacementModel3Resource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                NoTypeReplacementModel3Resource.ValidateResourceId(id);
                return new NoTypeReplacementModel3Resource(client, id);
            }
            );
        }
        #endregion

        /// <summary> Gets a collection of NoTypeReplacementModel1Resources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of NoTypeReplacementModel1Resources and their operations over a NoTypeReplacementModel1Resource. </returns>
        public static NoTypeReplacementModel1Collection GetNoTypeReplacementModel1s(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetNoTypeReplacementModel1s();
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s/{noTypeReplacementModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<NoTypeReplacementModel1Resource>> GetNoTypeReplacementModel1Async(this ResourceGroupResource resourceGroupResource, string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetNoTypeReplacementModel1s().GetAsync(noTypeReplacementModel1SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s/{noTypeReplacementModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<NoTypeReplacementModel1Resource> GetNoTypeReplacementModel1(this ResourceGroupResource resourceGroupResource, string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetNoTypeReplacementModel1s().Get(noTypeReplacementModel1SName, cancellationToken);
        }

        /// <summary> Gets a collection of NoTypeReplacementModel2Resources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of NoTypeReplacementModel2Resources and their operations over a NoTypeReplacementModel2Resource. </returns>
        public static NoTypeReplacementModel2Collection GetNoTypeReplacementModel2s(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetNoTypeReplacementModel2s();
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel2s/{noTypeReplacementModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="noTypeReplacementModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<NoTypeReplacementModel2Resource>> GetNoTypeReplacementModel2Async(this ResourceGroupResource resourceGroupResource, string noTypeReplacementModel2SName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetNoTypeReplacementModel2s().GetAsync(noTypeReplacementModel2SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel2s/{noTypeReplacementModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="noTypeReplacementModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<NoTypeReplacementModel2Resource> GetNoTypeReplacementModel2(this ResourceGroupResource resourceGroupResource, string noTypeReplacementModel2SName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetNoTypeReplacementModel2s().Get(noTypeReplacementModel2SName, cancellationToken);
        }

        /// <summary> Gets a collection of NoTypeReplacementModel3Resources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of NoTypeReplacementModel3Resources and their operations over a NoTypeReplacementModel3Resource. </returns>
        public static NoTypeReplacementModel3Collection GetNoTypeReplacementModel3s(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetNoTypeReplacementModel3s();
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s/{noTypeReplacementModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel3s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="noTypeReplacementModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel3SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel3SName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<NoTypeReplacementModel3Resource>> GetNoTypeReplacementModel3Async(this ResourceGroupResource resourceGroupResource, string noTypeReplacementModel3SName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetNoTypeReplacementModel3s().GetAsync(noTypeReplacementModel3SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s/{noTypeReplacementModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel3s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="noTypeReplacementModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel3SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel3SName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<NoTypeReplacementModel3Resource> GetNoTypeReplacementModel3(this ResourceGroupResource resourceGroupResource, string noTypeReplacementModel3SName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetNoTypeReplacementModel3s().Get(noTypeReplacementModel3SName, cancellationToken);
        }
    }
}
