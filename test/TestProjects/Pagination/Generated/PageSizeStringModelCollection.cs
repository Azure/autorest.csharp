// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
using Azure.ResourceManager.Resources;

namespace Pagination
{
    /// <summary>
    /// A class representing a collection of <see cref="PageSizeStringModelResource" /> and their operations.
    /// Each <see cref="PageSizeStringModelResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="PageSizeStringModelCollection" /> instance call the GetPageSizeStringModels method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class PageSizeStringModelCollection : ArmCollection, IEnumerable<PageSizeStringModelResource>, IAsyncEnumerable<PageSizeStringModelResource>
    {
        private readonly ClientDiagnostics _pageSizeStringModelClientDiagnostics;
        private readonly PageSizeStringModelsRestOperations _pageSizeStringModelRestClient;

        /// <summary> Initializes a new instance of the <see cref="PageSizeStringModelCollection"/> class for mocking. </summary>
        protected PageSizeStringModelCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PageSizeStringModelCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal PageSizeStringModelCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _pageSizeStringModelClientDiagnostics = new ClientDiagnostics("Pagination", PageSizeStringModelResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(PageSizeStringModelResource.ResourceType, out string pageSizeStringModelApiVersion);
            _pageSizeStringModelRestClient = new PageSizeStringModelsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, pageSizeStringModelApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeStringModel/{name}
        /// Operation Id: PageSizeStringModels_Put
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="data"> The PageSizeStringModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<PageSizeStringModelResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, PageSizeStringModelData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _pageSizeStringModelClientDiagnostics.CreateScope("PageSizeStringModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _pageSizeStringModelRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken).ConfigureAwait(false);
                var operation = new PaginationArmOperation<PageSizeStringModelResource>(Response.FromValue(new PageSizeStringModelResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeStringModel/{name}
        /// Operation Id: PageSizeStringModels_Put
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="data"> The PageSizeStringModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<PageSizeStringModelResource> CreateOrUpdate(WaitUntil waitUntil, string name, PageSizeStringModelData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _pageSizeStringModelClientDiagnostics.CreateScope("PageSizeStringModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _pageSizeStringModelRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken);
                var operation = new PaginationArmOperation<PageSizeStringModelResource>(Response.FromValue(new PageSizeStringModelResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeStringModel/{name}
        /// Operation Id: PageSizeStringModels_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<PageSizeStringModelResource>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeStringModelClientDiagnostics.CreateScope("PageSizeStringModelCollection.Get");
            scope.Start();
            try
            {
                var response = await _pageSizeStringModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeStringModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeStringModel/{name}
        /// Operation Id: PageSizeStringModels_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<PageSizeStringModelResource> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeStringModelClientDiagnostics.CreateScope("PageSizeStringModelCollection.Get");
            scope.Start();
            try
            {
                var response = _pageSizeStringModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeStringModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeStringModel
        /// Operation Id: PageSizeStringModels_List
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PageSizeStringModelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PageSizeStringModelResource> GetAllAsync(string maxpagesize = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _pageSizeStringModelRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, maxpagesize);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _pageSizeStringModelRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, maxpagesize);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new PageSizeStringModelResource(Client, PageSizeStringModelData.DeserializePageSizeStringModelData(e)), _pageSizeStringModelClientDiagnostics, Pipeline, "PageSizeStringModelCollection.GetAll", "value", "nextLink");
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeStringModel
        /// Operation Id: PageSizeStringModels_List
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PageSizeStringModelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PageSizeStringModelResource> GetAll(string maxpagesize = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _pageSizeStringModelRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, maxpagesize);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _pageSizeStringModelRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, maxpagesize);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new PageSizeStringModelResource(Client, PageSizeStringModelData.DeserializePageSizeStringModelData(e)), _pageSizeStringModelClientDiagnostics, Pipeline, "PageSizeStringModelCollection.GetAll", "value", "nextLink");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeStringModel/{name}
        /// Operation Id: PageSizeStringModels_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeStringModelClientDiagnostics.CreateScope("PageSizeStringModelCollection.Exists");
            scope.Start();
            try
            {
                var response = await _pageSizeStringModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeStringModel/{name}
        /// Operation Id: PageSizeStringModels_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeStringModelClientDiagnostics.CreateScope("PageSizeStringModelCollection.Exists");
            scope.Start();
            try
            {
                var response = _pageSizeStringModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PageSizeStringModelResource> IEnumerable<PageSizeStringModelResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PageSizeStringModelResource> IAsyncEnumerable<PageSizeStringModelResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
