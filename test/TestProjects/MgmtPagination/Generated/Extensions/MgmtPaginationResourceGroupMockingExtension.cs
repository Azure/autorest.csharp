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
using MgmtPagination;

namespace MgmtPagination.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class MgmtPaginationResourceGroupMockingExtension : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MgmtPaginationResourceGroupMockingExtension"/> class for mocking. </summary>
        protected MgmtPaginationResourceGroupMockingExtension()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtPaginationResourceGroupMockingExtension"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MgmtPaginationResourceGroupMockingExtension(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of PageSizeIntegerModelResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of PageSizeIntegerModelResources and their operations over a PageSizeIntegerModelResource. </returns>
        public virtual PageSizeIntegerModelCollection GetPageSizeIntegerModels()
        {
            return GetCachedClient(Client => new PageSizeIntegerModelCollection(Client, Id));
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeIntegerModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<PageSizeIntegerModelResource>> GetPageSizeIntegerModelAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetPageSizeIntegerModels().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeIntegerModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<PageSizeIntegerModelResource> GetPageSizeIntegerModel(string name, CancellationToken cancellationToken = default)
        {
            return GetPageSizeIntegerModels().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of PageSizeInt64ModelResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of PageSizeInt64ModelResources and their operations over a PageSizeInt64ModelResource. </returns>
        public virtual PageSizeInt64ModelCollection GetPageSizeInt64Models()
        {
            return GetCachedClient(Client => new PageSizeInt64ModelCollection(Client, Id));
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt64Model/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeInt64Models_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<PageSizeInt64ModelResource>> GetPageSizeInt64ModelAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetPageSizeInt64Models().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt64Model/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeInt64Models_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<PageSizeInt64ModelResource> GetPageSizeInt64Model(string name, CancellationToken cancellationToken = default)
        {
            return GetPageSizeInt64Models().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of PageSizeInt32ModelResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of PageSizeInt32ModelResources and their operations over a PageSizeInt32ModelResource. </returns>
        public virtual PageSizeInt32ModelCollection GetPageSizeInt32Models()
        {
            return GetCachedClient(Client => new PageSizeInt32ModelCollection(Client, Id));
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt32Model/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeInt32Models_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<PageSizeInt32ModelResource>> GetPageSizeInt32ModelAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetPageSizeInt32Models().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt32Model/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeInt32Models_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<PageSizeInt32ModelResource> GetPageSizeInt32Model(string name, CancellationToken cancellationToken = default)
        {
            return GetPageSizeInt32Models().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of PageSizeNumericModelResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of PageSizeNumericModelResources and their operations over a PageSizeNumericModelResource. </returns>
        public virtual PageSizeNumericModelCollection GetPageSizeNumericModels()
        {
            return GetCachedClient(Client => new PageSizeNumericModelCollection(Client, Id));
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeNumericModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeNumericModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<PageSizeNumericModelResource>> GetPageSizeNumericModelAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetPageSizeNumericModels().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeNumericModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeNumericModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<PageSizeNumericModelResource> GetPageSizeNumericModel(string name, CancellationToken cancellationToken = default)
        {
            return GetPageSizeNumericModels().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of PageSizeFloatModelResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of PageSizeFloatModelResources and their operations over a PageSizeFloatModelResource. </returns>
        public virtual PageSizeFloatModelCollection GetPageSizeFloatModels()
        {
            return GetCachedClient(Client => new PageSizeFloatModelCollection(Client, Id));
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeFloatModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeFloatModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<PageSizeFloatModelResource>> GetPageSizeFloatModelAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetPageSizeFloatModels().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeFloatModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeFloatModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<PageSizeFloatModelResource> GetPageSizeFloatModel(string name, CancellationToken cancellationToken = default)
        {
            return GetPageSizeFloatModels().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of PageSizeDoubleModelResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of PageSizeDoubleModelResources and their operations over a PageSizeDoubleModelResource. </returns>
        public virtual PageSizeDoubleModelCollection GetPageSizeDoubleModels()
        {
            return GetCachedClient(Client => new PageSizeDoubleModelCollection(Client, Id));
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeDoubleModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeDoubleModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<PageSizeDoubleModelResource>> GetPageSizeDoubleModelAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetPageSizeDoubleModels().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeDoubleModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeDoubleModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<PageSizeDoubleModelResource> GetPageSizeDoubleModel(string name, CancellationToken cancellationToken = default)
        {
            return GetPageSizeDoubleModels().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of PageSizeDecimalModelResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of PageSizeDecimalModelResources and their operations over a PageSizeDecimalModelResource. </returns>
        public virtual PageSizeDecimalModelCollection GetPageSizeDecimalModels()
        {
            return GetCachedClient(Client => new PageSizeDecimalModelCollection(Client, Id));
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeDecimalModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeDecimalModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<PageSizeDecimalModelResource>> GetPageSizeDecimalModelAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetPageSizeDecimalModels().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeDecimalModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeDecimalModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<PageSizeDecimalModelResource> GetPageSizeDecimalModel(string name, CancellationToken cancellationToken = default)
        {
            return GetPageSizeDecimalModels().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of PageSizeStringModelResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of PageSizeStringModelResources and their operations over a PageSizeStringModelResource. </returns>
        public virtual PageSizeStringModelCollection GetPageSizeStringModels()
        {
            return GetCachedClient(Client => new PageSizeStringModelCollection(Client, Id));
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeStringModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeStringModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<PageSizeStringModelResource>> GetPageSizeStringModelAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetPageSizeStringModels().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeStringModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeStringModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<PageSizeStringModelResource> GetPageSizeStringModel(string name, CancellationToken cancellationToken = default)
        {
            return GetPageSizeStringModels().Get(name, cancellationToken);
        }
    }
}
