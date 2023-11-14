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
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtPagination
{
    /// <summary>
    /// A class representing a collection of <see cref="PageSizeDecimalModelResource" /> and their operations.
    /// Each <see cref="PageSizeDecimalModelResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="PageSizeDecimalModelCollection" /> instance call the GetPageSizeDecimalModels method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class PageSizeDecimalModelCollection : ArmCollection, IEnumerable<PageSizeDecimalModelResource>, IAsyncEnumerable<PageSizeDecimalModelResource>
    {
        private readonly ClientDiagnostics _pageSizeDecimalModelClientDiagnostics;
        private readonly PageSizeDecimalModelsRestOperations _pageSizeDecimalModelRestClient;

        /// <summary> Initializes a new instance of the <see cref="PageSizeDecimalModelCollection"/> class for mocking. </summary>
        protected PageSizeDecimalModelCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PageSizeDecimalModelCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal PageSizeDecimalModelCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _pageSizeDecimalModelClientDiagnostics = new ClientDiagnostics("MgmtPagination", PageSizeDecimalModelResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(PageSizeDecimalModelResource.ResourceType, out string pageSizeDecimalModelApiVersion);
            _pageSizeDecimalModelRestClient = new PageSizeDecimalModelsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, pageSizeDecimalModelApiVersion);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeDecimalModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeDecimalModels_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The string to use. </param>
        /// <param name="data"> The PageSizeDecimalModelData to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<PageSizeDecimalModelResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, PageSizeDecimalModelData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _pageSizeDecimalModelClientDiagnostics.CreateScope("PageSizeDecimalModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _pageSizeDecimalModelRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtPaginationArmOperation<PageSizeDecimalModelResource>(Response.FromValue(new PageSizeDecimalModelResource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeDecimalModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeDecimalModels_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The string to use. </param>
        /// <param name="data"> The PageSizeDecimalModelData to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<PageSizeDecimalModelResource> CreateOrUpdate(WaitUntil waitUntil, string name, PageSizeDecimalModelData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _pageSizeDecimalModelClientDiagnostics.CreateScope("PageSizeDecimalModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _pageSizeDecimalModelRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken);
                var operation = new MgmtPaginationArmOperation<PageSizeDecimalModelResource>(Response.FromValue(new PageSizeDecimalModelResource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeDecimalModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeDecimalModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<PageSizeDecimalModelResource>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeDecimalModelClientDiagnostics.CreateScope("PageSizeDecimalModelCollection.Get");
            scope.Start();
            try
            {
                var response = await _pageSizeDecimalModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeDecimalModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeDecimalModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeDecimalModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<PageSizeDecimalModelResource> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeDecimalModelClientDiagnostics.CreateScope("PageSizeDecimalModelCollection.Get");
            scope.Start();
            try
            {
                var response = _pageSizeDecimalModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeDecimalModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeDecimalModel</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeDecimalModels_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PageSizeDecimalModelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PageSizeDecimalModelResource> GetAllAsync(decimal? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _pageSizeDecimalModelRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _pageSizeDecimalModelRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new PageSizeDecimalModelResource(Client, PageSizeDecimalModelData.DeserializePageSizeDecimalModelData(e)), _pageSizeDecimalModelClientDiagnostics, Pipeline, "PageSizeDecimalModelCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeDecimalModel</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeDecimalModels_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PageSizeDecimalModelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PageSizeDecimalModelResource> GetAll(decimal? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _pageSizeDecimalModelRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _pageSizeDecimalModelRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new PageSizeDecimalModelResource(Client, PageSizeDecimalModelData.DeserializePageSizeDecimalModelData(e)), _pageSizeDecimalModelClientDiagnostics, Pipeline, "PageSizeDecimalModelCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeDecimalModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeDecimalModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeDecimalModelClientDiagnostics.CreateScope("PageSizeDecimalModelCollection.Exists");
            scope.Start();
            try
            {
                var response = await _pageSizeDecimalModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeDecimalModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeDecimalModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeDecimalModelClientDiagnostics.CreateScope("PageSizeDecimalModelCollection.Exists");
            scope.Start();
            try
            {
                var response = _pageSizeDecimalModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeDecimalModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeDecimalModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<NullableResponse<PageSizeDecimalModelResource>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeDecimalModelClientDiagnostics.CreateScope("PageSizeDecimalModelCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _pageSizeDecimalModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<PageSizeDecimalModelResource>(response.GetRawResponse());
                return Response.FromValue(new PageSizeDecimalModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeDecimalModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeDecimalModels_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual NullableResponse<PageSizeDecimalModelResource> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeDecimalModelClientDiagnostics.CreateScope("PageSizeDecimalModelCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _pageSizeDecimalModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<PageSizeDecimalModelResource>(response.GetRawResponse());
                return Response.FromValue(new PageSizeDecimalModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PageSizeDecimalModelResource> IEnumerable<PageSizeDecimalModelResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PageSizeDecimalModelResource> IAsyncEnumerable<PageSizeDecimalModelResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
