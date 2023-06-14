// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A class representing a collection of <see cref="BlobInventoryPolicyResource" /> and their operations.
    /// Each <see cref="BlobInventoryPolicyResource" /> in the collection will belong to the same instance of <see cref="StorageAccountResource" />.
    /// To get a <see cref="BlobInventoryPolicyCollection" /> instance call the GetBlobInventoryPolicies method from an instance of <see cref="StorageAccountResource" />.
    /// </summary>
    public partial class BlobInventoryPolicyCollection : ArmCollection, IEnumerable<BlobInventoryPolicyResource>, IAsyncEnumerable<BlobInventoryPolicyResource>
    {
        private readonly ClientDiagnostics _blobInventoryPolicyClientDiagnostics;
        private readonly BlobInventoryPoliciesRestOperations _blobInventoryPolicyRestClient;

        /// <summary> Initializes a new instance of the <see cref="BlobInventoryPolicyCollection"/> class for mocking. </summary>
        protected BlobInventoryPolicyCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="BlobInventoryPolicyCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal BlobInventoryPolicyCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _blobInventoryPolicyClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Storage", BlobInventoryPolicyResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(BlobInventoryPolicyResource.ResourceType, out string blobInventoryPolicyApiVersion);
            _blobInventoryPolicyRestClient = new BlobInventoryPoliciesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, blobInventoryPolicyApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != StorageAccountResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, StorageAccountResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Sets the blob inventory policy to the specified storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobInventoryPolicies_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="blobInventoryPolicyName"> The name of the storage account blob inventory policy. It should always be 'default'. </param>
        /// <param name="data"> The blob inventory policy set to a storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<BlobInventoryPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, BlobInventoryPolicyName blobInventoryPolicyName, BlobInventoryPolicyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _blobInventoryPolicyClientDiagnostics.CreateScope("BlobInventoryPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _blobInventoryPolicyRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, blobInventoryPolicyName, data, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation<BlobInventoryPolicyResource>(Response.FromValue(new BlobInventoryPolicyResource(Client, response), response.GetRawResponse()));
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
        /// Sets the blob inventory policy to the specified storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobInventoryPolicies_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="blobInventoryPolicyName"> The name of the storage account blob inventory policy. It should always be 'default'. </param>
        /// <param name="data"> The blob inventory policy set to a storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<BlobInventoryPolicyResource> CreateOrUpdate(WaitUntil waitUntil, BlobInventoryPolicyName blobInventoryPolicyName, BlobInventoryPolicyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _blobInventoryPolicyClientDiagnostics.CreateScope("BlobInventoryPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _blobInventoryPolicyRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, blobInventoryPolicyName, data, cancellationToken);
                var operation = new StorageArmOperation<BlobInventoryPolicyResource>(Response.FromValue(new BlobInventoryPolicyResource(Client, response), response.GetRawResponse()));
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
        public virtual async Task<Response<BlobInventoryPolicyResource>> GetAsync(BlobInventoryPolicyName blobInventoryPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _blobInventoryPolicyClientDiagnostics.CreateScope("BlobInventoryPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = await _blobInventoryPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, blobInventoryPolicyName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BlobInventoryPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        public virtual Response<BlobInventoryPolicyResource> Get(BlobInventoryPolicyName blobInventoryPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _blobInventoryPolicyClientDiagnostics.CreateScope("BlobInventoryPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = _blobInventoryPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, blobInventoryPolicyName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BlobInventoryPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the blob inventory policy associated with the specified storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobInventoryPolicies_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BlobInventoryPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BlobInventoryPolicyResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _blobInventoryPolicyRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new BlobInventoryPolicyResource(Client, BlobInventoryPolicyData.DeserializeBlobInventoryPolicyData(e)), _blobInventoryPolicyClientDiagnostics, Pipeline, "BlobInventoryPolicyCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Gets the blob inventory policy associated with the specified storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobInventoryPolicies_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BlobInventoryPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BlobInventoryPolicyResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _blobInventoryPolicyRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new BlobInventoryPolicyResource(Client, BlobInventoryPolicyData.DeserializeBlobInventoryPolicyData(e)), _blobInventoryPolicyClientDiagnostics, Pipeline, "BlobInventoryPolicyCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        public virtual async Task<Response<bool>> ExistsAsync(BlobInventoryPolicyName blobInventoryPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _blobInventoryPolicyClientDiagnostics.CreateScope("BlobInventoryPolicyCollection.Exists");
            scope.Start();
            try
            {
                var response = await _blobInventoryPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, blobInventoryPolicyName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        public virtual Response<bool> Exists(BlobInventoryPolicyName blobInventoryPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _blobInventoryPolicyClientDiagnostics.CreateScope("BlobInventoryPolicyCollection.Exists");
            scope.Start();
            try
            {
                var response = _blobInventoryPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, blobInventoryPolicyName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<BlobInventoryPolicyResource> IEnumerable<BlobInventoryPolicyResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<BlobInventoryPolicyResource> IAsyncEnumerable<BlobInventoryPolicyResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
