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
using MgmtPropertyBag.Models;

namespace MgmtPropertyBag
{
    /// <summary> A class to add extension methods to MgmtPropertyBag. </summary>
    public static partial class MgmtPropertyBagExtensions
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

        private static SubscriptionResourceExtensionClient GetSubscriptionResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new SubscriptionResourceExtensionClient(client, resource.Id);
            });
        }

        private static SubscriptionResourceExtensionClient GetSubscriptionResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new SubscriptionResourceExtensionClient(client, scope);
            });
        }
        #region FooResource
        /// <summary>
        /// Gets an object representing a <see cref="FooResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FooResource.CreateResourceIdentifier" /> to create a <see cref="FooResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FooResource" /> object. </returns>
        public static FooResource GetFooResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                FooResource.ValidateResourceId(id);
                return new FooResource(client, id);
            }
            );
        }
        #endregion

        #region BarResource
        /// <summary>
        /// Gets an object representing a <see cref="BarResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="BarResource.CreateResourceIdentifier" /> to create a <see cref="BarResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="BarResource" /> object. </returns>
        public static BarResource GetBarResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                BarResource.ValidateResourceId(id);
                return new BarResource(client, id);
            }
            );
        }
        #endregion

        /// <summary> Gets a collection of FooResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of FooResources and their operations over a FooResource. </returns>
        public static FooCollection GetFoos(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetFoos();
        }

        /// <summary>
        /// Gets a specific foo with five optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<FooResource>> GetFooAsync(this ResourceGroupResource resourceGroupResource, FooCollectionGetOptions options, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetFoos().GetAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a specific foo with five optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<FooResource> GetFoo(this ResourceGroupResource resourceGroupResource, FooCollectionGetOptions options, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetFoos().Get(options, cancellationToken);
        }

        /// <summary> Gets a collection of BarResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of BarResources and their operations over a BarResource. </returns>
        public static BarCollection GetBars(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetBars();
        }

        /// <summary>
        /// Gets a specific bar with one required header parameter and four optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<BarResource>> GetBarAsync(this ResourceGroupResource resourceGroupResource, BarCollectionGetOptions options, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetBars().GetAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a specific bar with one required header parameter and four optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<BarResource> GetBar(this ResourceGroupResource resourceGroupResource, BarCollectionGetOptions options, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetBars().Get(options, cancellationToken);
        }

        /// <summary>
        /// Gets a list of foo with two optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/foos</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_ListWithSubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FooResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<FooResource> GetFoosAsync(this SubscriptionResource subscriptionResource, string filter = null, int? top = 10, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFoosAsync(filter, top, cancellationToken);
        }

        /// <summary>
        /// Gets a list of foo with two optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/foos</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_ListWithSubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FooResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<FooResource> GetFoos(this SubscriptionResource subscriptionResource, string filter = null, int? top = 10, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFoos(filter, top, cancellationToken);
        }

        /// <summary>
        /// Gets a list of bar with one required header parameter and one optional query parameter.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/bars</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_ListWithSubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of "*" can be used for If-Match to unconditionally apply the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BarResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<BarResource> GetBarsAsync(this SubscriptionResource subscriptionResource, ETag? ifMatch = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetBarsAsync(ifMatch, top, cancellationToken);
        }

        /// <summary>
        /// Gets a list of bar with one required header parameter and one optional query parameter.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/bars</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_ListWithSubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of "*" can be used for If-Match to unconditionally apply the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BarResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<BarResource> GetBars(this SubscriptionResource subscriptionResource, ETag? ifMatch = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetBars(ifMatch, top, cancellationToken);
        }
    }
}
