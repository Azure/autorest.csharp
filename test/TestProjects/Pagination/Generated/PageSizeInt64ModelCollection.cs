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
    /// A class representing a collection of <see cref="PageSizeInt64ModelResource" /> and their operations.
    /// Each <see cref="PageSizeInt64ModelResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="PageSizeInt64ModelCollection" /> instance call the GetPageSizeInt64Models method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class PageSizeInt64ModelCollection : ArmCollection, IEnumerable<PageSizeInt64ModelResource>, IAsyncEnumerable<PageSizeInt64ModelResource>
    {
        private readonly ClientDiagnostics _pageSizeInt64ModelClientDiagnostics;
        private readonly PageSizeInt64ModelsRestOperations _pageSizeInt64ModelRestClient;

        /// <summary> Initializes a new instance of the <see cref="PageSizeInt64ModelCollection"/> class for mocking. </summary>
        protected PageSizeInt64ModelCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PageSizeInt64ModelCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal PageSizeInt64ModelCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _pageSizeInt64ModelClientDiagnostics = new ClientDiagnostics("Pagination", PageSizeInt64ModelResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(PageSizeInt64ModelResource.ResourceType, out string pageSizeInt64ModelApiVersion);
            _pageSizeInt64ModelRestClient = new PageSizeInt64ModelsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, pageSizeInt64ModelApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt64Model/{name}
        /// Operation Id: PageSizeInt64Models_Put
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="parameters"> The PageSizeInt64Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<PageSizeInt64ModelResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, PageSizeInt64ModelData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _pageSizeInt64ModelClientDiagnostics.CreateScope("PageSizeInt64ModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _pageSizeInt64ModelRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, name, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new PaginationArmOperation<PageSizeInt64ModelResource>(Response.FromValue(new PageSizeInt64ModelResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt64Model/{name}
        /// Operation Id: PageSizeInt64Models_Put
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="parameters"> The PageSizeInt64Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<PageSizeInt64ModelResource> CreateOrUpdate(WaitUntil waitUntil, string name, PageSizeInt64ModelData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _pageSizeInt64ModelClientDiagnostics.CreateScope("PageSizeInt64ModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _pageSizeInt64ModelRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, name, parameters, cancellationToken);
                var operation = new PaginationArmOperation<PageSizeInt64ModelResource>(Response.FromValue(new PageSizeInt64ModelResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt64Model/{name}
        /// Operation Id: PageSizeInt64Models_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<PageSizeInt64ModelResource>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeInt64ModelClientDiagnostics.CreateScope("PageSizeInt64ModelCollection.Get");
            scope.Start();
            try
            {
                var response = await _pageSizeInt64ModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeInt64ModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt64Model/{name}
        /// Operation Id: PageSizeInt64Models_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<PageSizeInt64ModelResource> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeInt64ModelClientDiagnostics.CreateScope("PageSizeInt64ModelCollection.Get");
            scope.Start();
            try
            {
                var response = _pageSizeInt64ModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeInt64ModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt64Model
        /// Operation Id: PageSizeInt64Models_List
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PageSizeInt64ModelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PageSizeInt64ModelResource> GetAllAsync(long? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PageSizeInt64ModelResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _pageSizeInt64ModelClientDiagnostics.CreateScope("PageSizeInt64ModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _pageSizeInt64ModelRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeInt64ModelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PageSizeInt64ModelResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _pageSizeInt64ModelClientDiagnostics.CreateScope("PageSizeInt64ModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _pageSizeInt64ModelRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeInt64ModelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt64Model
        /// Operation Id: PageSizeInt64Models_List
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PageSizeInt64ModelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PageSizeInt64ModelResource> GetAll(long? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            Page<PageSizeInt64ModelResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _pageSizeInt64ModelClientDiagnostics.CreateScope("PageSizeInt64ModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _pageSizeInt64ModelRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeInt64ModelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PageSizeInt64ModelResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _pageSizeInt64ModelClientDiagnostics.CreateScope("PageSizeInt64ModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _pageSizeInt64ModelRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeInt64ModelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt64Model/{name}
        /// Operation Id: PageSizeInt64Models_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeInt64ModelClientDiagnostics.CreateScope("PageSizeInt64ModelCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt64Model/{name}
        /// Operation Id: PageSizeInt64Models_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeInt64ModelClientDiagnostics.CreateScope("PageSizeInt64ModelCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(name, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt64Model/{name}
        /// Operation Id: PageSizeInt64Models_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<PageSizeInt64ModelResource>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeInt64ModelClientDiagnostics.CreateScope("PageSizeInt64ModelCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _pageSizeInt64ModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<PageSizeInt64ModelResource>(null, response.GetRawResponse());
                return Response.FromValue(new PageSizeInt64ModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeInt64Model/{name}
        /// Operation Id: PageSizeInt64Models_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<PageSizeInt64ModelResource> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeInt64ModelClientDiagnostics.CreateScope("PageSizeInt64ModelCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _pageSizeInt64ModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<PageSizeInt64ModelResource>(null, response.GetRawResponse());
                return Response.FromValue(new PageSizeInt64ModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PageSizeInt64ModelResource> IEnumerable<PageSizeInt64ModelResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PageSizeInt64ModelResource> IAsyncEnumerable<PageSizeInt64ModelResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
