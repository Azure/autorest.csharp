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
using MgmtExactMatchFlattenInheritance.Models;

namespace MgmtExactMatchFlattenInheritance
{
    /// <summary> A class to add extension methods to MgmtExactMatchFlattenInheritance. </summary>
    public static partial class MgmtExactMatchFlattenInheritanceExtensions
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
        #region AzureResourceFlattenModel1Resource
        /// <summary>
        /// Gets an object representing an <see cref="AzureResourceFlattenModel1Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AzureResourceFlattenModel1Resource.CreateResourceIdentifier" /> to create an <see cref="AzureResourceFlattenModel1Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AzureResourceFlattenModel1Resource" /> object. </returns>
        public static AzureResourceFlattenModel1Resource GetAzureResourceFlattenModel1Resource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                AzureResourceFlattenModel1Resource.ValidateResourceId(id);
                return new AzureResourceFlattenModel1Resource(client, id);
            }
            );
        }
        #endregion

        #region CustomModel2Resource
        /// <summary>
        /// Gets an object representing a <see cref="CustomModel2Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CustomModel2Resource.CreateResourceIdentifier" /> to create a <see cref="CustomModel2Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CustomModel2Resource" /> object. </returns>
        public static CustomModel2Resource GetCustomModel2Resource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                CustomModel2Resource.ValidateResourceId(id);
                return new CustomModel2Resource(client, id);
            }
            );
        }
        #endregion

        #region CustomModel3Resource
        /// <summary>
        /// Gets an object representing a <see cref="CustomModel3Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CustomModel3Resource.CreateResourceIdentifier" /> to create a <see cref="CustomModel3Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CustomModel3Resource" /> object. </returns>
        public static CustomModel3Resource GetCustomModel3Resource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                CustomModel3Resource.ValidateResourceId(id);
                return new CustomModel3Resource(client, id);
            }
            );
        }
        #endregion

        /// <summary> Gets a collection of AzureResourceFlattenModel1Resources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of AzureResourceFlattenModel1Resources and their operations over a AzureResourceFlattenModel1Resource. </returns>
        public static AzureResourceFlattenModel1Collection GetAzureResourceFlattenModel1s(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel1s();
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel1.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel1s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<AzureResourceFlattenModel1Resource>> GetAzureResourceFlattenModel1Async(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetAzureResourceFlattenModel1s().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel1.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel1s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<AzureResourceFlattenModel1Resource> GetAzureResourceFlattenModel1(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetAzureResourceFlattenModel1s().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of CustomModel2Resources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of CustomModel2Resources and their operations over a CustomModel2Resource. </returns>
        public static CustomModel2Collection GetCustomModel2s(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetCustomModel2s();
        }

        /// <summary>
        /// Get an CustomModel2.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel2s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<CustomModel2Resource>> GetCustomModel2Async(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetCustomModel2s().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get an CustomModel2.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel2s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<CustomModel2Resource> GetCustomModel2(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetCustomModel2s().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of CustomModel3Resources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of CustomModel3Resources and their operations over a CustomModel3Resource. </returns>
        public static CustomModel3Collection GetCustomModel3s(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetCustomModel3s();
        }

        /// <summary>
        /// Get an CustomModel3.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel3s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel3s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<CustomModel3Resource>> GetCustomModel3Async(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetCustomModel3s().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get an CustomModel3.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel3s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel3s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<CustomModel3Resource> GetCustomModel3(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetCustomModel3s().Get(name, cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel2.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AzureResourceFlattenModel2" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<AzureResourceFlattenModel2> GetAzureResourceFlattenModel2sAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel2sAsync(cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel2.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AzureResourceFlattenModel2" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<AzureResourceFlattenModel2> GetAzureResourceFlattenModel2s(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel2s(cancellationToken);
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel2.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel2s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="azureResourceFlattenModel2"> The AzureResourceFlattenModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="azureResourceFlattenModel2"/> is null. </exception>
        public static async Task<Response<AzureResourceFlattenModel2>> PutAzureResourceFlattenModel2Async(this ResourceGroupResource resourceGroupResource, string name, AzureResourceFlattenModel2 azureResourceFlattenModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(azureResourceFlattenModel2, nameof(azureResourceFlattenModel2));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutAzureResourceFlattenModel2Async(name, azureResourceFlattenModel2, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel2.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel2s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="azureResourceFlattenModel2"> The AzureResourceFlattenModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="azureResourceFlattenModel2"/> is null. </exception>
        public static Response<AzureResourceFlattenModel2> PutAzureResourceFlattenModel2(this ResourceGroupResource resourceGroupResource, string name, AzureResourceFlattenModel2 azureResourceFlattenModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(azureResourceFlattenModel2, nameof(azureResourceFlattenModel2));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutAzureResourceFlattenModel2(name, azureResourceFlattenModel2, cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel2.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel2s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public static async Task<Response<AzureResourceFlattenModel2>> GetAzureResourceFlattenModel2Async(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel2Async(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel2.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel2s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public static Response<AzureResourceFlattenModel2> GetAzureResourceFlattenModel2(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel2(name, cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel3.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel3s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel3s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AzureResourceFlattenModel3" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<AzureResourceFlattenModel3> GetAzureResourceFlattenModel3sAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel3sAsync(cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel3.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel3s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel3s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AzureResourceFlattenModel3" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<AzureResourceFlattenModel3> GetAzureResourceFlattenModel3s(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel3s(cancellationToken);
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel3.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel3s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel3s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="azureResourceFlattenModel3"> The AzureResourceFlattenModel3 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="azureResourceFlattenModel3"/> is null. </exception>
        public static async Task<Response<AzureResourceFlattenModel3>> PutAzureResourceFlattenModel3Async(this ResourceGroupResource resourceGroupResource, string name, AzureResourceFlattenModel3 azureResourceFlattenModel3, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(azureResourceFlattenModel3, nameof(azureResourceFlattenModel3));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutAzureResourceFlattenModel3Async(name, azureResourceFlattenModel3, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel3.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel3s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel3s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="azureResourceFlattenModel3"> The AzureResourceFlattenModel3 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="azureResourceFlattenModel3"/> is null. </exception>
        public static Response<AzureResourceFlattenModel3> PutAzureResourceFlattenModel3(this ResourceGroupResource resourceGroupResource, string name, AzureResourceFlattenModel3 azureResourceFlattenModel3, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(azureResourceFlattenModel3, nameof(azureResourceFlattenModel3));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutAzureResourceFlattenModel3(name, azureResourceFlattenModel3, cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel3.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel3s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel3s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public static async Task<Response<AzureResourceFlattenModel3>> GetAzureResourceFlattenModel3Async(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel3Async(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel3.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel3s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel3s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public static Response<AzureResourceFlattenModel3> GetAzureResourceFlattenModel3(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel3(name, cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel4.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel4s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel4s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AzureResourceFlattenModel4" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<AzureResourceFlattenModel4> GetAzureResourceFlattenModel4sAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel4sAsync(cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel4.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel4s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel4s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AzureResourceFlattenModel4" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<AzureResourceFlattenModel4> GetAzureResourceFlattenModel4s(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel4s(cancellationToken);
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel4.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel4s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel4s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="azureResourceFlattenModel4"> The AzureResourceFlattenModel4 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="azureResourceFlattenModel4"/> is null. </exception>
        public static async Task<Response<AzureResourceFlattenModel4>> PutAzureResourceFlattenModel4Async(this ResourceGroupResource resourceGroupResource, string name, AzureResourceFlattenModel4 azureResourceFlattenModel4, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(azureResourceFlattenModel4, nameof(azureResourceFlattenModel4));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutAzureResourceFlattenModel4Async(name, azureResourceFlattenModel4, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel4.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel4s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel4s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="azureResourceFlattenModel4"> The AzureResourceFlattenModel4 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="azureResourceFlattenModel4"/> is null. </exception>
        public static Response<AzureResourceFlattenModel4> PutAzureResourceFlattenModel4(this ResourceGroupResource resourceGroupResource, string name, AzureResourceFlattenModel4 azureResourceFlattenModel4, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(azureResourceFlattenModel4, nameof(azureResourceFlattenModel4));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutAzureResourceFlattenModel4(name, azureResourceFlattenModel4, cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel4.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel4s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel4s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public static async Task<Response<AzureResourceFlattenModel4>> GetAzureResourceFlattenModel4Async(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel4Async(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel4.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel4s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel4s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public static Response<AzureResourceFlattenModel4> GetAzureResourceFlattenModel4(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel4(name, cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel5.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel5s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel5s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AzureResourceFlattenModel5" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<AzureResourceFlattenModel5> GetAzureResourceFlattenModel5sAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel5sAsync(cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel5.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel5s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel5s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AzureResourceFlattenModel5" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<AzureResourceFlattenModel5> GetAzureResourceFlattenModel5s(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel5s(cancellationToken);
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel5.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel5s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel5s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="foo"> New property. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public static async Task<Response<AzureResourceFlattenModel5>> PutAzureResourceFlattenModel5Async(this ResourceGroupResource resourceGroupResource, string name, int? foo = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).PutAzureResourceFlattenModel5Async(name, foo, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel5.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel5s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel5s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="foo"> New property. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public static Response<AzureResourceFlattenModel5> PutAzureResourceFlattenModel5(this ResourceGroupResource resourceGroupResource, string name, int? foo = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).PutAzureResourceFlattenModel5(name, foo, cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel5.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel5s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel5s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public static async Task<Response<AzureResourceFlattenModel5>> GetAzureResourceFlattenModel5Async(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return await GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel5Async(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel5.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel5s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel5s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public static Response<AzureResourceFlattenModel5> GetAzureResourceFlattenModel5(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAzureResourceFlattenModel5(name, cancellationToken);
        }
    }
}
