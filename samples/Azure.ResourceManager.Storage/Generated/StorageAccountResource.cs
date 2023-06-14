// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A Class representing a StorageAccount along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="StorageAccountResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetStorageAccountResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetStorageAccount method.
    /// </summary>
    public partial class StorageAccountResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="StorageAccountResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _storageAccountClientDiagnostics;
        private readonly StorageAccountsRestOperations _storageAccountRestClient;
        private readonly ClientDiagnostics _privateLinkResourcesClientDiagnostics;
        private readonly PrivateLinkResourcesRestOperations _privateLinkResourcesRestClient;
        private readonly StorageAccountData _data;

        /// <summary> Initializes a new instance of the <see cref="StorageAccountResource"/> class for mocking. </summary>
        protected StorageAccountResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "StorageAccountResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal StorageAccountResource(ArmClient client, StorageAccountData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="StorageAccountResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal StorageAccountResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _storageAccountClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Storage", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string storageAccountApiVersion);
            _storageAccountRestClient = new StorageAccountsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, storageAccountApiVersion);
            _privateLinkResourcesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Storage", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _privateLinkResourcesRestClient = new PrivateLinkResourcesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual StorageAccountData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets an object representing a BlobServiceResource along with the instance operations that can be performed on it in the StorageAccount. </summary>
        /// <returns> Returns a <see cref="BlobServiceResource" /> object. </returns>
        public virtual BlobServiceResource GetBlobService()
        {
            return new BlobServiceResource(Client, Id.AppendChildResource("blobServices", "default"));
        }

        /// <summary> Gets an object representing a FileServiceResource along with the instance operations that can be performed on it in the StorageAccount. </summary>
        /// <returns> Returns a <see cref="FileServiceResource" /> object. </returns>
        public virtual FileServiceResource GetFileService()
        {
            return new FileServiceResource(Client, Id.AppendChildResource("fileServices", "default"));
        }

        /// <summary> Gets an object representing a ManagementPolicyResource along with the instance operations that can be performed on it in the StorageAccount. </summary>
        /// <returns> Returns a <see cref="ManagementPolicyResource" /> object. </returns>
        public virtual ManagementPolicyResource GetManagementPolicy()
        {
            return new ManagementPolicyResource(Client, Id.AppendChildResource("managementPolicies", "default"));
        }

        /// <summary> Gets a collection of BlobInventoryPolicyResources in the StorageAccount. </summary>
        /// <returns> An object representing collection of BlobInventoryPolicyResources and their operations over a BlobInventoryPolicyResource. </returns>
        public virtual BlobInventoryPolicyCollection GetBlobInventoryPolicies()
        {
            return GetCachedClient(Client => new BlobInventoryPolicyCollection(Client, Id));
        }

        /// <summary>
        /// Gets the blob inventory policy associated with the specified storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobInventoryPolicies_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="blobInventoryPolicyName"> The name of the storage account blob inventory policy. It should always be 'default'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<BlobInventoryPolicyResource>> GetBlobInventoryPolicyAsync(BlobInventoryPolicyName blobInventoryPolicyName, CancellationToken cancellationToken = default)
        {
            return await GetBlobInventoryPolicies().GetAsync(blobInventoryPolicyName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the blob inventory policy associated with the specified storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobInventoryPolicies_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="blobInventoryPolicyName"> The name of the storage account blob inventory policy. It should always be 'default'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<BlobInventoryPolicyResource> GetBlobInventoryPolicy(BlobInventoryPolicyName blobInventoryPolicyName, CancellationToken cancellationToken = default)
        {
            return GetBlobInventoryPolicies().Get(blobInventoryPolicyName, cancellationToken);
        }

        /// <summary> Gets a collection of StoragePrivateEndpointConnectionResources in the StorageAccount. </summary>
        /// <returns> An object representing collection of StoragePrivateEndpointConnectionResources and their operations over a StoragePrivateEndpointConnectionResource. </returns>
        public virtual StoragePrivateEndpointConnectionCollection GetStoragePrivateEndpointConnections()
        {
            return GetCachedClient(Client => new StoragePrivateEndpointConnectionCollection(Client, Id));
        }

        /// <summary>
        /// Gets the specified private endpoint connection associated with the storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PrivateEndpointConnections_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection associated with the Azure resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<StoragePrivateEndpointConnectionResource>> GetStoragePrivateEndpointConnectionAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return await GetStoragePrivateEndpointConnections().GetAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified private endpoint connection associated with the storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PrivateEndpointConnections_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection associated with the Azure resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<StoragePrivateEndpointConnectionResource> GetStoragePrivateEndpointConnection(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetStoragePrivateEndpointConnections().Get(privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Gets a collection of ObjectReplicationPolicyResources in the StorageAccount. </summary>
        /// <returns> An object representing collection of ObjectReplicationPolicyResources and their operations over a ObjectReplicationPolicyResource. </returns>
        public virtual ObjectReplicationPolicyCollection GetObjectReplicationPolicies()
        {
            return GetCachedClient(Client => new ObjectReplicationPolicyCollection(Client, Id));
        }

        /// <summary>
        /// Get the object replication policy of the storage account by policy ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ObjectReplicationPolicies_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectReplicationPolicyId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ObjectReplicationPolicyResource>> GetObjectReplicationPolicyAsync(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            return await GetObjectReplicationPolicies().GetAsync(objectReplicationPolicyId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the object replication policy of the storage account by policy ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ObjectReplicationPolicies_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectReplicationPolicyId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<ObjectReplicationPolicyResource> GetObjectReplicationPolicy(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            return GetObjectReplicationPolicies().Get(objectReplicationPolicyId, cancellationToken);
        }

        /// <summary> Gets a collection of EncryptionScopeResources in the StorageAccount. </summary>
        /// <returns> An object representing collection of EncryptionScopeResources and their operations over a EncryptionScopeResource. </returns>
        public virtual EncryptionScopeCollection GetEncryptionScopes()
        {
            return GetCachedClient(Client => new EncryptionScopeCollection(Client, Id));
        }

        /// <summary>
        /// Returns the properties for the specified encryption scope.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EncryptionScopes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<EncryptionScopeResource>> GetEncryptionScopeAsync(string encryptionScopeName, CancellationToken cancellationToken = default)
        {
            return await GetEncryptionScopes().GetAsync(encryptionScopeName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns the properties for the specified encryption scope.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EncryptionScopes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<EncryptionScopeResource> GetEncryptionScope(string encryptionScopeName, CancellationToken cancellationToken = default)
        {
            return GetEncryptionScopes().Get(encryptionScopeName, cancellationToken);
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
        /// </summary>
        /// <param name="expand"> May be used to expand the properties within account's properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<StorageAccountResource>> GetAsync(StorageAccountExpand? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.Get");
            scope.Start();
            try
            {
                var response = await _storageAccountRestClient.GetPropertiesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new StorageAccountResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// </summary>
        /// <param name="expand"> May be used to expand the properties within account's properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<StorageAccountResource> Get(StorageAccountExpand? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.Get");
            scope.Start();
            try
            {
                var response = _storageAccountRestClient.GetProperties(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new StorageAccountResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a storage account in Microsoft Azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.Delete");
            scope.Start();
            try
            {
                var response = await _storageAccountRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a storage account in Microsoft Azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.Delete");
            scope.Start();
            try
            {
                var response = _storageAccountRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new StorageArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The update operation can be used to update the SKU, encryption, access tier, or tags for a storage account. It can also be used to map the account to a custom domain. Only one custom domain is supported per storage account; the replacement/change of custom domain is not supported. In order to replace an old custom domain, the old value must be cleared/unregistered before a new value can be set. The update of multiple properties is supported. This call does not change the storage keys for the account. If you want to change the storage account keys, use the regenerate keys operation. The location and name of the storage account cannot be changed after creation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The parameters to provide for the updated account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<Response<StorageAccountResource>> UpdateAsync(StorageAccountPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.Update");
            scope.Start();
            try
            {
                var response = await _storageAccountRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new StorageAccountResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The update operation can be used to update the SKU, encryption, access tier, or tags for a storage account. It can also be used to map the account to a custom domain. Only one custom domain is supported per storage account; the replacement/change of custom domain is not supported. In order to replace an old custom domain, the old value must be cleared/unregistered before a new value can be set. The update of multiple properties is supported. This call does not change the storage keys for the account. If you want to change the storage account keys, use the regenerate keys operation. The location and name of the storage account cannot be changed after creation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The parameters to provide for the updated account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Response<StorageAccountResource> Update(StorageAccountPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.Update");
            scope.Start();
            try
            {
                var response = _storageAccountRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, cancellationToken);
                return Response.FromValue(new StorageAccountResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the access keys or Kerberos keys (if active directory enabled) for the specified storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/listKeys</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_ListKeys</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> Specifies type of the key to be listed. Possible value is kerb. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<StorageAccountListKeysResult>> GetKeysAsync(ListKeyExpand? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.GetKeys");
            scope.Start();
            try
            {
                var response = await _storageAccountRestClient.ListKeysAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the access keys or Kerberos keys (if active directory enabled) for the specified storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/listKeys</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_ListKeys</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> Specifies type of the key to be listed. Possible value is kerb. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<StorageAccountListKeysResult> GetKeys(ListKeyExpand? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.GetKeys");
            scope.Start();
            try
            {
                var response = _storageAccountRestClient.ListKeys(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Regenerates one of the access keys or Kerberos keys for the specified storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/regenerateKey</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_RegenerateKey</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Specifies name of the key which should be regenerated -- key1, key2, kerb1, kerb2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<StorageAccountListKeysResult>> RegenerateKeyAsync(StorageAccountRegenerateKeyContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.RegenerateKey");
            scope.Start();
            try
            {
                var response = await _storageAccountRestClient.RegenerateKeyAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Regenerates one of the access keys or Kerberos keys for the specified storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/regenerateKey</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_RegenerateKey</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Specifies name of the key which should be regenerated -- key1, key2, kerb1, kerb2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<StorageAccountListKeysResult> RegenerateKey(StorageAccountRegenerateKeyContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.RegenerateKey");
            scope.Start();
            try
            {
                var response = _storageAccountRestClient.RegenerateKey(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List SAS credentials of a storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListAccountSas</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_ListAccountSAS</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The parameters to provide to list SAS credentials for the storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<ListAccountSasResponse>> GetAccountSASAsync(AccountSasContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.GetAccountSAS");
            scope.Start();
            try
            {
                var response = await _storageAccountRestClient.ListAccountSASAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List SAS credentials of a storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListAccountSas</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_ListAccountSAS</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The parameters to provide to list SAS credentials for the storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<ListAccountSasResponse> GetAccountSAS(AccountSasContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.GetAccountSAS");
            scope.Start();
            try
            {
                var response = _storageAccountRestClient.ListAccountSAS(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List service SAS credentials of a specific resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListServiceSas</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_ListServiceSAS</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The parameters to provide to list service SAS credentials. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<ListServiceSasResponse>> GetServiceSASAsync(ServiceSasContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.GetServiceSAS");
            scope.Start();
            try
            {
                var response = await _storageAccountRestClient.ListServiceSASAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List service SAS credentials of a specific resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListServiceSas</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_ListServiceSAS</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The parameters to provide to list service SAS credentials. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<ListServiceSasResponse> GetServiceSAS(ServiceSasContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.GetServiceSAS");
            scope.Start();
            try
            {
                var response = _storageAccountRestClient.ListServiceSAS(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Failover request can be triggered for a storage account in case of availability issues. The failover occurs from the storage account's primary cluster to secondary cluster for RA-GRS accounts. The secondary cluster will become primary after failover.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/failover</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_Failover</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> FailoverAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.Failover");
            scope.Start();
            try
            {
                var response = await _storageAccountRestClient.FailoverAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation(_storageAccountClientDiagnostics, Pipeline, _storageAccountRestClient.CreateFailoverRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Failover request can be triggered for a storage account in case of availability issues. The failover occurs from the storage account's primary cluster to secondary cluster for RA-GRS accounts. The secondary cluster will become primary after failover.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/failover</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_Failover</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Failover(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.Failover");
            scope.Start();
            try
            {
                var response = _storageAccountRestClient.Failover(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new StorageArmOperation(_storageAccountClientDiagnostics, Pipeline, _storageAccountRestClient.CreateFailoverRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Live Migration of storage account to enable Hns
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/hnsonmigration</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_HierarchicalNamespaceMigration</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="requestType"> Required. Hierarchical namespace migration type can either be a hierarchical namespace validation request 'HnsOnValidationRequest' or a hydration request 'HnsOnHydrationRequest'. The validation request will validate the migration whereas the hydration request will migrate the account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requestType"/> is null. </exception>
        public virtual async Task<ArmOperation> HierarchicalNamespaceMigrationAsync(WaitUntil waitUntil, string requestType, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(requestType, nameof(requestType));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.HierarchicalNamespaceMigration");
            scope.Start();
            try
            {
                var response = await _storageAccountRestClient.HierarchicalNamespaceMigrationAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, requestType, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation(_storageAccountClientDiagnostics, Pipeline, _storageAccountRestClient.CreateHierarchicalNamespaceMigrationRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, requestType).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Live Migration of storage account to enable Hns
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/hnsonmigration</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_HierarchicalNamespaceMigration</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="requestType"> Required. Hierarchical namespace migration type can either be a hierarchical namespace validation request 'HnsOnValidationRequest' or a hydration request 'HnsOnHydrationRequest'. The validation request will validate the migration whereas the hydration request will migrate the account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requestType"/> is null. </exception>
        public virtual ArmOperation HierarchicalNamespaceMigration(WaitUntil waitUntil, string requestType, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(requestType, nameof(requestType));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.HierarchicalNamespaceMigration");
            scope.Start();
            try
            {
                var response = _storageAccountRestClient.HierarchicalNamespaceMigration(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, requestType, cancellationToken);
                var operation = new StorageArmOperation(_storageAccountClientDiagnostics, Pipeline, _storageAccountRestClient.CreateHierarchicalNamespaceMigrationRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, requestType).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Abort live Migration of storage account to enable Hns
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/aborthnsonmigration</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_AbortHierarchicalNamespaceMigration</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> AbortHierarchicalNamespaceMigrationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.AbortHierarchicalNamespaceMigration");
            scope.Start();
            try
            {
                var response = await _storageAccountRestClient.AbortHierarchicalNamespaceMigrationAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation(_storageAccountClientDiagnostics, Pipeline, _storageAccountRestClient.CreateAbortHierarchicalNamespaceMigrationRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Abort live Migration of storage account to enable Hns
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/aborthnsonmigration</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_AbortHierarchicalNamespaceMigration</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation AbortHierarchicalNamespaceMigration(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.AbortHierarchicalNamespaceMigration");
            scope.Start();
            try
            {
                var response = _storageAccountRestClient.AbortHierarchicalNamespaceMigration(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new StorageArmOperation(_storageAccountClientDiagnostics, Pipeline, _storageAccountRestClient.CreateAbortHierarchicalNamespaceMigrationRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restore blobs in the specified blob ranges
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/restoreBlobRanges</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_RestoreBlobRanges</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The parameters to provide for restore blob ranges. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<StorageAccountRestoreBlobRangesOperation> RestoreBlobRangesAsync(WaitUntil waitUntil, BlobRestoreContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.RestoreBlobRanges");
            scope.Start();
            try
            {
                var response = await _storageAccountRestClient.RestoreBlobRangesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken).ConfigureAwait(false);
                var operation = new StorageAccountRestoreBlobRangesOperation(new BlobRestoreStatusOperationSource(), _storageAccountClientDiagnostics, Pipeline, _storageAccountRestClient.CreateRestoreBlobRangesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restore blobs in the specified blob ranges
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/restoreBlobRanges</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_RestoreBlobRanges</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The parameters to provide for restore blob ranges. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual StorageAccountRestoreBlobRangesOperation RestoreBlobRanges(WaitUntil waitUntil, BlobRestoreContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.RestoreBlobRanges");
            scope.Start();
            try
            {
                var response = _storageAccountRestClient.RestoreBlobRanges(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken);
                var operation = new StorageAccountRestoreBlobRangesOperation(new BlobRestoreStatusOperationSource(), _storageAccountClientDiagnostics, Pipeline, _storageAccountRestClient.CreateRestoreBlobRangesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Revoke user delegation keys.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/revokeUserDelegationKeys</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_RevokeUserDelegationKeys</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> RevokeUserDelegationKeysAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.RevokeUserDelegationKeys");
            scope.Start();
            try
            {
                var response = await _storageAccountRestClient.RevokeUserDelegationKeysAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Revoke user delegation keys.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/revokeUserDelegationKeys</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_RevokeUserDelegationKeys</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response RevokeUserDelegationKeys(CancellationToken cancellationToken = default)
        {
            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.RevokeUserDelegationKeys");
            scope.Start();
            try
            {
                var response = _storageAccountRestClient.RevokeUserDelegationKeys(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the private link resources that need to be created for a storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateLinkResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PrivateLinkResources_ListByStorageAccount</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="StoragePrivateLinkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<StoragePrivateLinkResource> GetPrivateLinkResourcesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _privateLinkResourcesRestClient.CreateListByStorageAccountRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, StoragePrivateLinkResource.DeserializeStoragePrivateLinkResource, _privateLinkResourcesClientDiagnostics, Pipeline, "StorageAccountResource.GetPrivateLinkResources", "value", null, cancellationToken);
        }

        /// <summary>
        /// Gets the private link resources that need to be created for a storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateLinkResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PrivateLinkResources_ListByStorageAccount</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="StoragePrivateLinkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<StoragePrivateLinkResource> GetPrivateLinkResources(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _privateLinkResourcesRestClient.CreateListByStorageAccountRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, StoragePrivateLinkResource.DeserializeStoragePrivateLinkResource, _privateLinkResourcesClientDiagnostics, Pipeline, "StorageAccountResource.GetPrivateLinkResources", "value", null, cancellationToken);
        }

        /// <summary>
        /// Add a tag to the current resource.
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
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<StorageAccountResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.AddTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _storageAccountRestClient.GetPropertiesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new StorageAccountResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new StorageAccountPatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
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
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<StorageAccountResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.AddTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _storageAccountRestClient.GetProperties(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken);
                    return Response.FromValue(new StorageAccountResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new StorageAccountPatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = Update(patch, cancellationToken: cancellationToken);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
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
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<StorageAccountResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.SetTags");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _storageAccountRestClient.GetPropertiesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new StorageAccountResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new StorageAccountPatch();
                    patch.Tags.ReplaceWith(tags);
                    var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
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
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<StorageAccountResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.SetTags");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _storageAccountRestClient.GetProperties(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken);
                    return Response.FromValue(new StorageAccountResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new StorageAccountPatch();
                    patch.Tags.ReplaceWith(tags);
                    var result = Update(patch, cancellationToken: cancellationToken);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
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
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<StorageAccountResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.RemoveTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _storageAccountRestClient.GetPropertiesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new StorageAccountResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new StorageAccountPatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
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
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<StorageAccountResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _storageAccountClientDiagnostics.CreateScope("StorageAccountResource.RemoveTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _storageAccountRestClient.GetProperties(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken);
                    return Response.FromValue(new StorageAccountResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new StorageAccountPatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var result = Update(patch, cancellationToken: cancellationToken);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
