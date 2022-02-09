// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Management.Storage.Models;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage
{
    /// <summary> A class representing collection of BlobContainer and their operations over its parent. </summary>
    public partial class BlobContainerCollection : ArmCollection, IEnumerable<BlobContainer>, IAsyncEnumerable<BlobContainer>
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
            _blobContainerClientDiagnostics = new ClientDiagnostics("Azure.Management.Storage", BlobContainer.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(BlobContainer.ResourceType, out string blobContainerApiVersion);
            _blobContainerRestClient = new BlobContainersRestOperations(_blobContainerClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, blobContainerApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != BlobService.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, BlobService.ResourceType), nameof(id));
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/{BlobServicesName}
        /// OperationId: BlobContainers_Create
        /// <summary> Creates a new container under the specified account as described by request body. The container resource includes metadata and properties for that container. It does not include a list of the blobs contained by the container. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="blobContainer"> Properties of the blob container to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> or <paramref name="blobContainer"/> is null. </exception>
        public async virtual Task<ArmOperation<BlobContainer>> CreateOrUpdateAsync(bool waitForCompletion, string containerName, BlobContainerData blobContainer, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));
            if (blobContainer == null)
            {
                throw new ArgumentNullException(nameof(blobContainer));
            }

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _blobContainerRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, containerName, blobContainer, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation<BlobContainer>(Response.FromValue(new BlobContainer(Client, response), response.GetRawResponse()));
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/{BlobServicesName}
        /// OperationId: BlobContainers_Create
        /// <summary> Creates a new container under the specified account as described by request body. The container resource includes metadata and properties for that container. It does not include a list of the blobs contained by the container. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="blobContainer"> Properties of the blob container to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> or <paramref name="blobContainer"/> is null. </exception>
        public virtual ArmOperation<BlobContainer> CreateOrUpdate(bool waitForCompletion, string containerName, BlobContainerData blobContainer, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));
            if (blobContainer == null)
            {
                throw new ArgumentNullException(nameof(blobContainer));
            }

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _blobContainerRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, containerName, blobContainer, cancellationToken);
                var operation = new StorageArmOperation<BlobContainer>(Response.FromValue(new BlobContainer(Client, response), response.GetRawResponse()));
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/{BlobServicesName}
        /// OperationId: BlobContainers_Get
        /// <summary> Gets properties of a specified container. </summary>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> is null. </exception>
        public async virtual Task<Response<BlobContainer>> GetAsync(string containerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.Get");
            scope.Start();
            try
            {
                var response = await _blobContainerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, containerName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _blobContainerClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new BlobContainer(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/{BlobServicesName}
        /// OperationId: BlobContainers_Get
        /// <summary> Gets properties of a specified container. </summary>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> is null. </exception>
        public virtual Response<BlobContainer> Get(string containerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.Get");
            scope.Start();
            try
            {
                var response = _blobContainerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, containerName, cancellationToken);
                if (response.Value == null)
                    throw _blobContainerClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BlobContainer(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/{BlobServicesName}
        /// OperationId: BlobContainers_List
        /// <summary> Lists all containers and does not support a prefix like data plane. Also SRP today does not return continuation token. </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only container names starting with the filter will be listed. </param>
        /// <param name="include"> Optional, used to include the properties for soft deleted blob containers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BlobContainer" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BlobContainer> GetAllAsync(int? maxpagesize = null, string filter = null, ListContainersInclude? include = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<BlobContainer>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _blobContainerRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, pageSizeHint, filter, include, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new BlobContainer(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<BlobContainer>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _blobContainerRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, pageSizeHint, filter, include, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new BlobContainer(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/{BlobServicesName}
        /// OperationId: BlobContainers_List
        /// <summary> Lists all containers and does not support a prefix like data plane. Also SRP today does not return continuation token. </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only container names starting with the filter will be listed. </param>
        /// <param name="include"> Optional, used to include the properties for soft deleted blob containers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BlobContainer" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BlobContainer> GetAll(int? maxpagesize = null, string filter = null, ListContainersInclude? include = null, CancellationToken cancellationToken = default)
        {
            Page<BlobContainer> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _blobContainerRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, pageSizeHint, filter, include, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new BlobContainer(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<BlobContainer> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _blobContainerRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, pageSizeHint, filter, include, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new BlobContainer(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/{BlobServicesName}
        /// OperationId: BlobContainers_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string containerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(containerName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/{BlobServicesName}
        /// OperationId: BlobContainers_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> is null. </exception>
        public virtual Response<bool> Exists(string containerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(containerName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/{BlobServicesName}
        /// OperationId: BlobContainers_Get
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> is null. </exception>
        public async virtual Task<Response<BlobContainer>> GetIfExistsAsync(string containerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _blobContainerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, containerName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<BlobContainer>(null, response.GetRawResponse());
                return Response.FromValue(new BlobContainer(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/{BlobServicesName}
        /// OperationId: BlobContainers_Get
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> is null. </exception>
        public virtual Response<BlobContainer> GetIfExists(string containerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _blobContainerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, containerName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<BlobContainer>(null, response.GetRawResponse());
                return Response.FromValue(new BlobContainer(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<BlobContainer> IEnumerable<BlobContainer>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<BlobContainer> IAsyncEnumerable<BlobContainer>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
