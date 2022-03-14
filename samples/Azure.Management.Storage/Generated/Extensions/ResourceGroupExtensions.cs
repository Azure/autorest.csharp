// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Management.Storage.Models;
using Azure.ResourceManager.Resources;

namespace Azure.Management.Storage
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    public static partial class ResourceGroupExtensions
    {
        private static ResourceGroupExtensionClient GetExtensionClient(ResourceGroup resourceGroup)
        {
            return resourceGroup.GetCachedClient((client) =>
            {
                return new ResourceGroupExtensionClient(client, resourceGroup.Id);
            }
            );
        }

        /// <summary> Gets a collection of StorageAccounts in the StorageAccount. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of StorageAccounts and their operations over a StorageAccount. </returns>
        public static StorageAccountCollection GetStorageAccounts(this ResourceGroup resourceGroup)
        {
            return GetExtensionClient(resourceGroup).GetStorageAccounts();
        }

        /// <summary>
        /// Returns the properties for the specified storage account including but not limited to name, SKU name, location, and account status. The ListKeys operation should be used to retrieve storage keys.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}
        /// Operation Id: StorageAccounts_GetProperties
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="expand"> May be used to expand the properties within account&apos;s properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="accountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> is null. </exception>
        public static async Task<Response<StorageAccount>> GetStorageAccountAsync(this ResourceGroup resourceGroup, string accountName, StorageAccountExpand? expand = null, CancellationToken cancellationToken = default)
        {
            return await resourceGroup.GetStorageAccounts().GetAsync(accountName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns the properties for the specified storage account including but not limited to name, SKU name, location, and account status. The ListKeys operation should be used to retrieve storage keys.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}
        /// Operation Id: StorageAccounts_GetProperties
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="expand"> May be used to expand the properties within account&apos;s properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="accountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> is null. </exception>
        public static Response<StorageAccount> GetStorageAccount(this ResourceGroup resourceGroup, string accountName, StorageAccountExpand? expand = null, CancellationToken cancellationToken = default)
        {
            return resourceGroup.GetStorageAccounts().Get(accountName, expand, cancellationToken);
        }
    }
}
