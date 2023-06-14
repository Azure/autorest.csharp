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

namespace MgmtPagination
{
    /// <summary> A class to add extension methods to MgmtPagination. </summary>
    public static partial class MgmtPaginationExtensions
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
        #region PageSizeIntegerModelResource
        /// <summary>
        /// Gets an object representing a <see cref="PageSizeIntegerModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeIntegerModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeIntegerModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeIntegerModelResource" /> object. </returns>
        public static PageSizeIntegerModelResource GetPageSizeIntegerModelResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                PageSizeIntegerModelResource.ValidateResourceId(id);
                return new PageSizeIntegerModelResource(client, id);
            }
            );
        }
        #endregion

        #region PageSizeInt64ModelResource
        /// <summary>
        /// Gets an object representing a <see cref="PageSizeInt64ModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeInt64ModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeInt64ModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeInt64ModelResource" /> object. </returns>
        public static PageSizeInt64ModelResource GetPageSizeInt64ModelResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                PageSizeInt64ModelResource.ValidateResourceId(id);
                return new PageSizeInt64ModelResource(client, id);
            }
            );
        }
        #endregion

        #region PageSizeInt32ModelResource
        /// <summary>
        /// Gets an object representing a <see cref="PageSizeInt32ModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeInt32ModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeInt32ModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeInt32ModelResource" /> object. </returns>
        public static PageSizeInt32ModelResource GetPageSizeInt32ModelResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                PageSizeInt32ModelResource.ValidateResourceId(id);
                return new PageSizeInt32ModelResource(client, id);
            }
            );
        }
        #endregion

        #region PageSizeNumericModelResource
        /// <summary>
        /// Gets an object representing a <see cref="PageSizeNumericModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeNumericModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeNumericModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeNumericModelResource" /> object. </returns>
        public static PageSizeNumericModelResource GetPageSizeNumericModelResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                PageSizeNumericModelResource.ValidateResourceId(id);
                return new PageSizeNumericModelResource(client, id);
            }
            );
        }
        #endregion

        #region PageSizeFloatModelResource
        /// <summary>
        /// Gets an object representing a <see cref="PageSizeFloatModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeFloatModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeFloatModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeFloatModelResource" /> object. </returns>
        public static PageSizeFloatModelResource GetPageSizeFloatModelResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                PageSizeFloatModelResource.ValidateResourceId(id);
                return new PageSizeFloatModelResource(client, id);
            }
            );
        }
        #endregion

        #region PageSizeDoubleModelResource
        /// <summary>
        /// Gets an object representing a <see cref="PageSizeDoubleModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeDoubleModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeDoubleModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeDoubleModelResource" /> object. </returns>
        public static PageSizeDoubleModelResource GetPageSizeDoubleModelResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                PageSizeDoubleModelResource.ValidateResourceId(id);
                return new PageSizeDoubleModelResource(client, id);
            }
            );
        }
        #endregion

        #region PageSizeDecimalModelResource
        /// <summary>
        /// Gets an object representing a <see cref="PageSizeDecimalModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeDecimalModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeDecimalModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeDecimalModelResource" /> object. </returns>
        public static PageSizeDecimalModelResource GetPageSizeDecimalModelResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                PageSizeDecimalModelResource.ValidateResourceId(id);
                return new PageSizeDecimalModelResource(client, id);
            }
            );
        }
        #endregion

        #region PageSizeStringModelResource
        /// <summary>
        /// Gets an object representing a <see cref="PageSizeStringModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeStringModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeStringModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeStringModelResource" /> object. </returns>
        public static PageSizeStringModelResource GetPageSizeStringModelResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                PageSizeStringModelResource.ValidateResourceId(id);
                return new PageSizeStringModelResource(client, id);
            }
            );
        }
        #endregion

        /// <summary> Gets a collection of PageSizeIntegerModelResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of PageSizeIntegerModelResources and their operations over a PageSizeIntegerModelResource. </returns>
        public static PageSizeIntegerModelCollection GetPageSizeIntegerModels(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetPageSizeIntegerModels();
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<PageSizeIntegerModelResource>> GetPageSizeIntegerModelAsync(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetPageSizeIntegerModels().GetAsync(name, cancellationToken).ConfigureAwait(false);
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<PageSizeIntegerModelResource> GetPageSizeIntegerModel(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetPageSizeIntegerModels().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of PageSizeInt64ModelResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of PageSizeInt64ModelResources and their operations over a PageSizeInt64ModelResource. </returns>
        public static PageSizeInt64ModelCollection GetPageSizeInt64Models(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetPageSizeInt64Models();
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<PageSizeInt64ModelResource>> GetPageSizeInt64ModelAsync(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetPageSizeInt64Models().GetAsync(name, cancellationToken).ConfigureAwait(false);
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<PageSizeInt64ModelResource> GetPageSizeInt64Model(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetPageSizeInt64Models().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of PageSizeInt32ModelResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of PageSizeInt32ModelResources and their operations over a PageSizeInt32ModelResource. </returns>
        public static PageSizeInt32ModelCollection GetPageSizeInt32Models(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetPageSizeInt32Models();
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<PageSizeInt32ModelResource>> GetPageSizeInt32ModelAsync(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetPageSizeInt32Models().GetAsync(name, cancellationToken).ConfigureAwait(false);
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<PageSizeInt32ModelResource> GetPageSizeInt32Model(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetPageSizeInt32Models().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of PageSizeNumericModelResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of PageSizeNumericModelResources and their operations over a PageSizeNumericModelResource. </returns>
        public static PageSizeNumericModelCollection GetPageSizeNumericModels(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetPageSizeNumericModels();
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<PageSizeNumericModelResource>> GetPageSizeNumericModelAsync(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetPageSizeNumericModels().GetAsync(name, cancellationToken).ConfigureAwait(false);
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<PageSizeNumericModelResource> GetPageSizeNumericModel(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetPageSizeNumericModels().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of PageSizeFloatModelResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of PageSizeFloatModelResources and their operations over a PageSizeFloatModelResource. </returns>
        public static PageSizeFloatModelCollection GetPageSizeFloatModels(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetPageSizeFloatModels();
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<PageSizeFloatModelResource>> GetPageSizeFloatModelAsync(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetPageSizeFloatModels().GetAsync(name, cancellationToken).ConfigureAwait(false);
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<PageSizeFloatModelResource> GetPageSizeFloatModel(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetPageSizeFloatModels().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of PageSizeDoubleModelResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of PageSizeDoubleModelResources and their operations over a PageSizeDoubleModelResource. </returns>
        public static PageSizeDoubleModelCollection GetPageSizeDoubleModels(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetPageSizeDoubleModels();
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<PageSizeDoubleModelResource>> GetPageSizeDoubleModelAsync(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetPageSizeDoubleModels().GetAsync(name, cancellationToken).ConfigureAwait(false);
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<PageSizeDoubleModelResource> GetPageSizeDoubleModel(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetPageSizeDoubleModels().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of PageSizeDecimalModelResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of PageSizeDecimalModelResources and their operations over a PageSizeDecimalModelResource. </returns>
        public static PageSizeDecimalModelCollection GetPageSizeDecimalModels(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetPageSizeDecimalModels();
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<PageSizeDecimalModelResource>> GetPageSizeDecimalModelAsync(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetPageSizeDecimalModels().GetAsync(name, cancellationToken).ConfigureAwait(false);
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<PageSizeDecimalModelResource> GetPageSizeDecimalModel(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetPageSizeDecimalModels().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of PageSizeStringModelResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of PageSizeStringModelResources and their operations over a PageSizeStringModelResource. </returns>
        public static PageSizeStringModelCollection GetPageSizeStringModels(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetPageSizeStringModels();
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<PageSizeStringModelResource>> GetPageSizeStringModelAsync(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetPageSizeStringModels().GetAsync(name, cancellationToken).ConfigureAwait(false);
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<PageSizeStringModelResource> GetPageSizeStringModel(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetPageSizeStringModels().Get(name, cancellationToken);
        }
    }
}
