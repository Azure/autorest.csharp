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
using OmitOperationGroups.Models;

namespace OmitOperationGroups
{
    /// <summary> A class to add extension methods to OmitOperationGroups. </summary>
    public static partial class OmitOperationGroupsExtensions
    {
        private static ResourceGroupExtensionClient GetExtensionClient(ResourceGroup resourceGroup)
        {
            return resourceGroup.GetCachedClient((client) =>
            {
                return new ResourceGroupExtensionClient(client, resourceGroup.Id);
            }
            );
        }

        /// <summary> Gets a collection of Model2s in the ResourceGroup. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of Model2s and their operations over a Model2. </returns>
        public static Model2Collection GetModel2s(this ResourceGroup resourceGroup)
        {
            return GetExtensionClient(resourceGroup).GetModel2s();
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}
        /// Operation Id: Model2s_Get
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public static async Task<Response<Model2>> GetModel2Async(this ResourceGroup resourceGroup, string model2SName, CancellationToken cancellationToken = default)
        {
            return await resourceGroup.GetModel2s().GetAsync(model2SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}
        /// Operation Id: Model2s_Get
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public static Response<Model2> GetModel2(this ResourceGroup resourceGroup, string model2SName, CancellationToken cancellationToken = default)
        {
            return resourceGroup.GetModel2s().Get(model2SName, cancellationToken);
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s
        /// Operation Id: Model5s_List
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Model5" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<Model5> GetModel5sAsync(this ResourceGroup resourceGroup, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(resourceGroup).GetModel5sAsync(cancellationToken);
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s
        /// Operation Id: Model5s_List
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Model5" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<Model5> GetModel5s(this ResourceGroup resourceGroup, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(resourceGroup).GetModel5s(cancellationToken);
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s/{model5sName}
        /// Operation Id: Model5s_CreateOrUpdate
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="model5SName"> The String to use. </param>
        /// <param name="parameters"> The Model5 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model5SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model5SName"/> or <paramref name="parameters"/> is null. </exception>
        public static async Task<Response<Model5>> CreateOrUpdateModel5Async(this ResourceGroup resourceGroup, string model5SName, Model5 parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model5SName, nameof(model5SName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            return await GetExtensionClient(resourceGroup).CreateOrUpdateModel5Async(model5SName, parameters, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s/{model5sName}
        /// Operation Id: Model5s_CreateOrUpdate
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="model5SName"> The String to use. </param>
        /// <param name="parameters"> The Model5 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model5SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model5SName"/> or <paramref name="parameters"/> is null. </exception>
        public static Response<Model5> CreateOrUpdateModel5(this ResourceGroup resourceGroup, string model5SName, Model5 parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model5SName, nameof(model5SName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            return GetExtensionClient(resourceGroup).CreateOrUpdateModel5(model5SName, parameters, cancellationToken);
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s/{model5sName}
        /// Operation Id: Model5s_Get
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="model5SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model5SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model5SName"/> is null. </exception>
        public static async Task<Response<Model5>> GetModel5Async(this ResourceGroup resourceGroup, string model5SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model5SName, nameof(model5SName));

            return await GetExtensionClient(resourceGroup).GetModel5Async(model5SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s/{model5sName}
        /// Operation Id: Model5s_Get
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="model5SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model5SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model5SName"/> is null. </exception>
        public static Response<Model5> GetModel5(this ResourceGroup resourceGroup, string model5SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model5SName, nameof(model5SName));

            return GetExtensionClient(resourceGroup).GetModel5(model5SName, cancellationToken);
        }

        #region Model2
        /// <summary> Gets an object representing a Model2 along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Model2" /> object. </returns>
        public static Model2 GetModel2(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                Model2.ValidateResourceId(id);
                return new Model2(client, id);
            }
            );
        }
        #endregion
    }
}
