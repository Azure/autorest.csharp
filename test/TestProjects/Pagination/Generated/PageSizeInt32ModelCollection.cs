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
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Pagination
{
    /// <summary>
    /// A class representing a collection of <see cref="PageSizeInt32ModelResource" /> and their operations.
    /// Each <see cref="PageSizeInt32ModelResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="PageSizeInt32ModelCollection" /> instance call the GetPageSizeInt32Models method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class PageSizeInt32ModelCollection : ArmCollection, IEnumerable<PageSizeInt32ModelResource>, IAsyncEnumerable<PageSizeInt32ModelResource>
    {
        private readonly ClientDiagnostics _pageSizeInt32ModelClientDiagnostics;
        private readonly PageSizeInt32ModelsRestOperations _pageSizeInt32ModelRestClient;

        /// <summary> Initializes a new instance of the <see cref="PageSizeInt32ModelCollection"/> class for mocking. </summary>
        protected PageSizeInt32ModelCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PageSizeInt32ModelCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal PageSizeInt32ModelCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _pageSizeInt32ModelClientDiagnostics = new ClientDiagnostics("Pagination", PageSizeInt32ModelResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(PageSizeInt32ModelResource.ResourceType, out string pageSizeInt32ModelApiVersion);
            _pageSizeInt32ModelRestClient = new PageSizeInt32ModelsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, pageSizeInt32ModelApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt32Model/{name}
        /// Operation Id: PageSizeInt32Models_Put
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="data"> The PageSizeInt32Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<PageSizeInt32ModelResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, PageSizeInt32ModelData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _pageSizeInt32ModelClientDiagnostics.CreateScope("PageSizeInt32ModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _pageSizeInt32ModelRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken).ConfigureAwait(false);
                var operation = new PaginationArmOperation<PageSizeInt32ModelResource>(Response.FromValue(new PageSizeInt32ModelResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt32Model/{name}
        /// Operation Id: PageSizeInt32Models_Put
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="data"> The PageSizeInt32Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<PageSizeInt32ModelResource> CreateOrUpdate(WaitUntil waitUntil, string name, PageSizeInt32ModelData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _pageSizeInt32ModelClientDiagnostics.CreateScope("PageSizeInt32ModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _pageSizeInt32ModelRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken);
                var operation = new PaginationArmOperation<PageSizeInt32ModelResource>(Response.FromValue(new PageSizeInt32ModelResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt32Model/{name}
        /// Operation Id: PageSizeInt32Models_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<PageSizeInt32ModelResource>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeInt32ModelClientDiagnostics.CreateScope("PageSizeInt32ModelCollection.Get");
            scope.Start();
            try
            {
                var response = await _pageSizeInt32ModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeInt32ModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt32Model/{name}
        /// Operation Id: PageSizeInt32Models_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<PageSizeInt32ModelResource> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeInt32ModelClientDiagnostics.CreateScope("PageSizeInt32ModelCollection.Get");
            scope.Start();
            try
            {
                var response = _pageSizeInt32ModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeInt32ModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt32Model
        /// Operation Id: PageSizeInt32Models_List
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PageSizeInt32ModelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PageSizeInt32ModelResource> GetAllAsync(int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PageSizeInt32ModelResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _pageSizeInt32ModelClientDiagnostics.CreateScope("PageSizeInt32ModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _pageSizeInt32ModelRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeInt32ModelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PageSizeInt32ModelResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _pageSizeInt32ModelClientDiagnostics.CreateScope("PageSizeInt32ModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _pageSizeInt32ModelRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeInt32ModelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt32Model
        /// Operation Id: PageSizeInt32Models_List
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PageSizeInt32ModelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PageSizeInt32ModelResource> GetAll(int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            Page<PageSizeInt32ModelResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _pageSizeInt32ModelClientDiagnostics.CreateScope("PageSizeInt32ModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _pageSizeInt32ModelRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeInt32ModelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PageSizeInt32ModelResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _pageSizeInt32ModelClientDiagnostics.CreateScope("PageSizeInt32ModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _pageSizeInt32ModelRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeInt32ModelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt32Model/{name}
        /// Operation Id: PageSizeInt32Models_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeInt32ModelClientDiagnostics.CreateScope("PageSizeInt32ModelCollection.Exists");
            scope.Start();
            try
            {
                var response = await _pageSizeInt32ModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt32Model/{name}
        /// Operation Id: PageSizeInt32Models_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeInt32ModelClientDiagnostics.CreateScope("PageSizeInt32ModelCollection.Exists");
            scope.Start();
            try
            {
                var response = _pageSizeInt32ModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PageSizeInt32ModelResource> IEnumerable<PageSizeInt32ModelResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PageSizeInt32ModelResource> IAsyncEnumerable<PageSizeInt32ModelResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
