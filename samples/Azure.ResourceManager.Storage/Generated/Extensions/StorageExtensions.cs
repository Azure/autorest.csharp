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
using Azure.ResourceManager.Storage.Mocking;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Storage. </summary>
    public static partial class StorageExtensions
    {
        private static MockableStorageArmClient GetMockableStorageArmClient(ArmClient client)
        {
            Argument.AssertNotNull(client, nameof(client));

            return client.GetCachedClient(client0 => new MockableStorageArmClient(client0));
        }

        private static MockableStorageResourceGroupResource GetMockableStorageResourceGroupResource(ArmResource resource)
        {
            Argument.AssertNotNull(resource, nameof(resource));

            return resource.GetCachedClient(client => new MockableStorageResourceGroupResource(client, resource.Id));
        }

        private static MockableStorageSubscriptionResource GetMockableStorageSubscriptionResource(ArmResource resource)
        {
            Argument.AssertNotNull(resource, nameof(resource));

            return resource.GetCachedClient(client => new MockableStorageSubscriptionResource(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing a <see cref="BlobServiceResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="BlobServiceResource.CreateResourceIdentifier" /> to create a <see cref="BlobServiceResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageArmClient.GetBlobServiceResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="BlobServiceResource" /> object. </returns>
        public static BlobServiceResource GetBlobServiceResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableStorageArmClient(client).GetBlobServiceResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="BlobContainerResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="BlobContainerResource.CreateResourceIdentifier" /> to create a <see cref="BlobContainerResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageArmClient.GetBlobContainerResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="BlobContainerResource" /> object. </returns>
        public static BlobContainerResource GetBlobContainerResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableStorageArmClient(client).GetBlobContainerResource(id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="ImmutabilityPolicyResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ImmutabilityPolicyResource.CreateResourceIdentifier" /> to create an <see cref="ImmutabilityPolicyResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageArmClient.GetImmutabilityPolicyResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ImmutabilityPolicyResource" /> object. </returns>
        public static ImmutabilityPolicyResource GetImmutabilityPolicyResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableStorageArmClient(client).GetImmutabilityPolicyResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="FileServiceResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FileServiceResource.CreateResourceIdentifier" /> to create a <see cref="FileServiceResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageArmClient.GetFileServiceResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="FileServiceResource" /> object. </returns>
        public static FileServiceResource GetFileServiceResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableStorageArmClient(client).GetFileServiceResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="FileShareResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FileShareResource.CreateResourceIdentifier" /> to create a <see cref="FileShareResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageArmClient.GetFileShareResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="FileShareResource" /> object. </returns>
        public static FileShareResource GetFileShareResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableStorageArmClient(client).GetFileShareResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="StorageAccountResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="StorageAccountResource.CreateResourceIdentifier" /> to create a <see cref="StorageAccountResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageArmClient.GetStorageAccountResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="StorageAccountResource" /> object. </returns>
        public static StorageAccountResource GetStorageAccountResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableStorageArmClient(client).GetStorageAccountResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="DeletedAccountResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DeletedAccountResource.CreateResourceIdentifier" /> to create a <see cref="DeletedAccountResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageArmClient.GetDeletedAccountResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="DeletedAccountResource" /> object. </returns>
        public static DeletedAccountResource GetDeletedAccountResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableStorageArmClient(client).GetDeletedAccountResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="ManagementPolicyResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ManagementPolicyResource.CreateResourceIdentifier" /> to create a <see cref="ManagementPolicyResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageArmClient.GetManagementPolicyResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ManagementPolicyResource" /> object. </returns>
        public static ManagementPolicyResource GetManagementPolicyResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableStorageArmClient(client).GetManagementPolicyResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="BlobInventoryPolicyResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="BlobInventoryPolicyResource.CreateResourceIdentifier" /> to create a <see cref="BlobInventoryPolicyResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageArmClient.GetBlobInventoryPolicyResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="BlobInventoryPolicyResource" /> object. </returns>
        public static BlobInventoryPolicyResource GetBlobInventoryPolicyResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableStorageArmClient(client).GetBlobInventoryPolicyResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="StoragePrivateEndpointConnectionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="StoragePrivateEndpointConnectionResource.CreateResourceIdentifier" /> to create a <see cref="StoragePrivateEndpointConnectionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageArmClient.GetStoragePrivateEndpointConnectionResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="StoragePrivateEndpointConnectionResource" /> object. </returns>
        public static StoragePrivateEndpointConnectionResource GetStoragePrivateEndpointConnectionResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableStorageArmClient(client).GetStoragePrivateEndpointConnectionResource(id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="ObjectReplicationPolicyResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ObjectReplicationPolicyResource.CreateResourceIdentifier" /> to create an <see cref="ObjectReplicationPolicyResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageArmClient.GetObjectReplicationPolicyResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ObjectReplicationPolicyResource" /> object. </returns>
        public static ObjectReplicationPolicyResource GetObjectReplicationPolicyResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableStorageArmClient(client).GetObjectReplicationPolicyResource(id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="EncryptionScopeResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="EncryptionScopeResource.CreateResourceIdentifier" /> to create an <see cref="EncryptionScopeResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageArmClient.GetEncryptionScopeResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="EncryptionScopeResource" /> object. </returns>
        public static EncryptionScopeResource GetEncryptionScopeResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableStorageArmClient(client).GetEncryptionScopeResource(id);
        }

        /// <summary>
        /// Gets a collection of StorageAccountResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageResourceGroupResource.GetStorageAccounts()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of StorageAccountResources and their operations over a StorageAccountResource. </returns>
        public static StorageAccountCollection GetStorageAccounts(this ResourceGroupResource resourceGroupResource)
        {
            return GetMockableStorageResourceGroupResource(resourceGroupResource).GetStorageAccounts();
        }

        /// <summary>
        /// Returns the properties for the specified storage account including but not limited to name, SKU name, location, and account status. The ListKeys operation should be used to retrieve storage keys.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_GetProperties</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageResourceGroupResource.GetStorageAccountAsync(string,StorageAccountExpand?,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="expand"> May be used to expand the properties within account's properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="accountName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="accountName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<StorageAccountResource>> GetStorageAccountAsync(this ResourceGroupResource resourceGroupResource, string accountName, StorageAccountExpand? expand = null, CancellationToken cancellationToken = default)
        {
            return await GetMockableStorageResourceGroupResource(resourceGroupResource).GetStorageAccountAsync(accountName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns the properties for the specified storage account including but not limited to name, SKU name, location, and account status. The ListKeys operation should be used to retrieve storage keys.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_GetProperties</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageResourceGroupResource.GetStorageAccount(string,StorageAccountExpand?,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="expand"> May be used to expand the properties within account's properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="accountName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="accountName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<StorageAccountResource> GetStorageAccount(this ResourceGroupResource resourceGroupResource, string accountName, StorageAccountExpand? expand = null, CancellationToken cancellationToken = default)
        {
            return GetMockableStorageResourceGroupResource(resourceGroupResource).GetStorageAccount(accountName, expand, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of DeletedAccountResources in the SubscriptionResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageSubscriptionResource.GetDeletedAccounts()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An object representing collection of DeletedAccountResources and their operations over a DeletedAccountResource. </returns>
        public static DeletedAccountCollection GetDeletedAccounts(this SubscriptionResource subscriptionResource)
        {
            return GetMockableStorageSubscriptionResource(subscriptionResource).GetDeletedAccounts();
        }

        /// <summary>
        /// Get properties of specified deleted account resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DeletedAccounts_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageSubscriptionResource.GetDeletedAccountAsync(AzureLocation,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="deletedAccountName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deletedAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<DeletedAccountResource>> GetDeletedAccountAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            return await GetMockableStorageSubscriptionResource(subscriptionResource).GetDeletedAccountAsync(location, deletedAccountName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get properties of specified deleted account resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DeletedAccounts_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageSubscriptionResource.GetDeletedAccount(AzureLocation,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="deletedAccountName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deletedAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<DeletedAccountResource> GetDeletedAccount(this SubscriptionResource subscriptionResource, AzureLocation location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            return GetMockableStorageSubscriptionResource(subscriptionResource).GetDeletedAccount(location, deletedAccountName, cancellationToken);
        }

        /// <summary>
        /// Lists the available SKUs supported by Microsoft.Storage for given subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Storage/skus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Skus_List</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageSubscriptionResource.GetSkus(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="StorageSkuInformation" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<StorageSkuInformation> GetSkusAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetMockableStorageSubscriptionResource(subscriptionResource).GetSkusAsync(cancellationToken);
        }

        /// <summary>
        /// Lists the available SKUs supported by Microsoft.Storage for given subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Storage/skus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Skus_List</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageSubscriptionResource.GetSkus(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="StorageSkuInformation" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<StorageSkuInformation> GetSkus(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetMockableStorageSubscriptionResource(subscriptionResource).GetSkus(cancellationToken);
        }

        /// <summary>
        /// Lists all the storage accounts available under the subscription. Note that storage keys are not returned; use the ListKeys operation for this.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Storage/storageAccounts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_List</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageSubscriptionResource.GetStorageAccounts(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="StorageAccountResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<StorageAccountResource> GetStorageAccountsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetMockableStorageSubscriptionResource(subscriptionResource).GetStorageAccountsAsync(cancellationToken);
        }

        /// <summary>
        /// Lists all the storage accounts available under the subscription. Note that storage keys are not returned; use the ListKeys operation for this.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Storage/storageAccounts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_List</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageSubscriptionResource.GetStorageAccounts(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="StorageAccountResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<StorageAccountResource> GetStorageAccounts(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetMockableStorageSubscriptionResource(subscriptionResource).GetStorageAccounts(cancellationToken);
        }

        /// <summary>
        /// Gets the current usage count and the limit for the resources of the location under the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/usages</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Usages_ListByLocation</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageSubscriptionResource.GetUsagesByLocation(AzureLocation,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location of the Azure Storage resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="StorageUsage" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<StorageUsage> GetUsagesByLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetMockableStorageSubscriptionResource(subscriptionResource).GetUsagesByLocationAsync(location, cancellationToken);
        }

        /// <summary>
        /// Gets the current usage count and the limit for the resources of the location under the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/usages</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Usages_ListByLocation</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableStorageSubscriptionResource.GetUsagesByLocation(AzureLocation,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location of the Azure Storage resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="StorageUsage" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<StorageUsage> GetUsagesByLocation(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetMockableStorageSubscriptionResource(subscriptionResource).GetUsagesByLocation(location, cancellationToken);
        }
    }
}
