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
    /// A class representing a collection of <see cref="BlobContainerResource" /> and their operations.
    /// Each <see cref="BlobContainerResource" /> in the collection will belong to the same instance of <see cref="BlobServiceResource" />.
    /// To get a <see cref="BlobContainerCollection" /> instance call the GetBlobContainers method from an instance of <see cref="BlobServiceResource" />.
    /// </summary>
    public partial class BlobContainerCollection : ArmCollection, IEnumerable<BlobContainerResource>, IAsyncEnumerable<BlobContainerResource>
    {
        private readonly ClientDiagnostics _blobContainerClientDiagnostics;
        private readonly BlobContainersRestOperations _blobContainerRestClient;

        /// <summary> Initializes a new instance of the <see cref="BlobContainerCollection"/> class for mocking. </summary>
        protected BlobContainerCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="BlobContainerCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal BlobContainerCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _blobContainerClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Storage", BlobContainerResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(BlobContainerResource.ResourceType, out string blobContainerApiVersion);
            _blobContainerRestClient = new BlobContainersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, blobContainerApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != BlobServiceResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, BlobServiceResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates a new container under the specified account as described by request body. The container resource includes metadata and properties for that container. It does not include a list of the blobs contained by the container.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="data"> Properties of the blob container to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<BlobContainerResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string containerName, BlobContainerData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _blobContainerRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, containerName, data, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation<BlobContainerResource>(Response.FromValue(new BlobContainerResource(Client, response), response.GetRawResponse()));
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
        /// Creates a new container under the specified account as described by request body. The container resource includes metadata and properties for that container. It does not include a list of the blobs contained by the container.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="data"> Properties of the blob container to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<BlobContainerResource> CreateOrUpdate(WaitUntil waitUntil, string containerName, BlobContainerData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _blobContainerRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, containerName, data, cancellationToken);
                var operation = new StorageArmOperation<BlobContainerResource>(Response.FromValue(new BlobContainerResource(Client, response), response.GetRawResponse()));
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
        /// Gets properties of a specified container.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> is null. </exception>
        public virtual async Task<Response<BlobContainerResource>> GetAsync(string containerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.Get");
            scope.Start();
            try
            {
                var response = await _blobContainerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, containerName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BlobContainerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets properties of a specified container.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> is null. </exception>
        public virtual Response<BlobContainerResource> Get(string containerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.Get");
            scope.Start();
            try
            {
                var response = _blobContainerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, containerName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BlobContainerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all containers and does not support a prefix like data plane. Also SRP today does not return continuation token.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only container names starting with the filter will be listed. </param>
        /// <param name="include"> Optional, used to include the properties for soft deleted blob containers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BlobContainerResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BlobContainerResource> GetAllAsync(int? maxpagesize = null, string filter = null, ListContainersInclude? include = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _blobContainerRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, pageSizeHint, filter, include);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _blobContainerRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, pageSizeHint, filter, include);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new BlobContainerResource(Client, BlobContainerData.DeserializeBlobContainerData(e)), _blobContainerClientDiagnostics, Pipeline, "BlobContainerCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all containers and does not support a prefix like data plane. Also SRP today does not return continuation token.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only container names starting with the filter will be listed. </param>
        /// <param name="include"> Optional, used to include the properties for soft deleted blob containers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BlobContainerResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BlobContainerResource> GetAll(int? maxpagesize = null, string filter = null, ListContainersInclude? include = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _blobContainerRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, pageSizeHint, filter, include);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _blobContainerRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, pageSizeHint, filter, include);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new BlobContainerResource(Client, BlobContainerData.DeserializeBlobContainerData(e)), _blobContainerClientDiagnostics, Pipeline, "BlobContainerCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string containerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.Exists");
            scope.Start();
            try
            {
                var response = await _blobContainerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, containerName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> is null. </exception>
        public virtual Response<bool> Exists(string containerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.Exists");
            scope.Start();
            try
            {
                var response = _blobContainerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, containerName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<BlobContainerResource> IEnumerable<BlobContainerResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<BlobContainerResource> IAsyncEnumerable<BlobContainerResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
