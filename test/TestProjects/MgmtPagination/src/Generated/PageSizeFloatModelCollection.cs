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
    /// A class representing a collection of <see cref="PageSizeFloatModelResource"/> and their operations.
    /// Each <see cref="PageSizeFloatModelResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="PageSizeFloatModelCollection"/> instance call the GetPageSizeFloatModels method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class PageSizeFloatModelCollection : ArmCollection, IEnumerable<PageSizeFloatModelResource>, IAsyncEnumerable<PageSizeFloatModelResource>
    {
        private readonly ClientDiagnostics _pageSizeFloatModelClientDiagnostics;
        private readonly PageSizeFloatModelsRestOperations _pageSizeFloatModelRestClient;

        /// <summary> Initializes a new instance of the <see cref="PageSizeFloatModelCollection"/> class for mocking. </summary>
        protected PageSizeFloatModelCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PageSizeFloatModelCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal PageSizeFloatModelCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _pageSizeFloatModelClientDiagnostics = new ClientDiagnostics("MgmtPagination", PageSizeFloatModelResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(PageSizeFloatModelResource.ResourceType, out string pageSizeFloatModelApiVersion);
            _pageSizeFloatModelRestClient = new PageSizeFloatModelsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, pageSizeFloatModelApiVersion);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeFloatModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeFloatModels_Put</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PageSizeFloatModelResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="PageSizeFloatModelData"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<PageSizeFloatModelResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, PageSizeFloatModelData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _pageSizeFloatModelClientDiagnostics.CreateScope("PageSizeFloatModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _pageSizeFloatModelRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken).ConfigureAwait(false);
                var uri = _pageSizeFloatModelRestClient.CreatePutRequestUri(Id.SubscriptionId, Id.ResourceGroupName, name, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new MgmtPaginationArmOperation<PageSizeFloatModelResource>(Response.FromValue(new PageSizeFloatModelResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeFloatModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeFloatModels_Put</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PageSizeFloatModelResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="PageSizeFloatModelData"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<PageSizeFloatModelResource> CreateOrUpdate(WaitUntil waitUntil, string name, PageSizeFloatModelData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _pageSizeFloatModelClientDiagnostics.CreateScope("PageSizeFloatModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _pageSizeFloatModelRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken);
                var uri = _pageSizeFloatModelRestClient.CreatePutRequestUri(Id.SubscriptionId, Id.ResourceGroupName, name, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new MgmtPaginationArmOperation<PageSizeFloatModelResource>(Response.FromValue(new PageSizeFloatModelResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeFloatModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeFloatModels_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PageSizeFloatModelResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<PageSizeFloatModelResource>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeFloatModelClientDiagnostics.CreateScope("PageSizeFloatModelCollection.Get");
            scope.Start();
            try
            {
                var response = await _pageSizeFloatModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeFloatModelResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeFloatModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeFloatModels_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PageSizeFloatModelResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<PageSizeFloatModelResource> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeFloatModelClientDiagnostics.CreateScope("PageSizeFloatModelCollection.Get");
            scope.Start();
            try
            {
                var response = _pageSizeFloatModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeFloatModelResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeFloatModel</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeFloatModels_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PageSizeFloatModelResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PageSizeFloatModelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PageSizeFloatModelResource> GetAllAsync(float? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _pageSizeFloatModelRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _pageSizeFloatModelRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new PageSizeFloatModelResource(Client, PageSizeFloatModelData.DeserializePageSizeFloatModelData(e)), _pageSizeFloatModelClientDiagnostics, Pipeline, "PageSizeFloatModelCollection.GetAll", "value", "nextLink", maxpagesize, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeFloatModel</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeFloatModels_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PageSizeFloatModelResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PageSizeFloatModelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PageSizeFloatModelResource> GetAll(float? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _pageSizeFloatModelRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _pageSizeFloatModelRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new PageSizeFloatModelResource(Client, PageSizeFloatModelData.DeserializePageSizeFloatModelData(e)), _pageSizeFloatModelClientDiagnostics, Pipeline, "PageSizeFloatModelCollection.GetAll", "value", "nextLink", maxpagesize, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeFloatModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeFloatModels_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PageSizeFloatModelResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeFloatModelClientDiagnostics.CreateScope("PageSizeFloatModelCollection.Exists");
            scope.Start();
            try
            {
                var response = await _pageSizeFloatModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeFloatModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeFloatModels_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PageSizeFloatModelResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeFloatModelClientDiagnostics.CreateScope("PageSizeFloatModelCollection.Exists");
            scope.Start();
            try
            {
                var response = _pageSizeFloatModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeFloatModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeFloatModels_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PageSizeFloatModelResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<NullableResponse<PageSizeFloatModelResource>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeFloatModelClientDiagnostics.CreateScope("PageSizeFloatModelCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _pageSizeFloatModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<PageSizeFloatModelResource>(response.GetRawResponse());
                return Response.FromValue(new PageSizeFloatModelResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeFloatModel/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PageSizeFloatModels_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PageSizeFloatModelResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual NullableResponse<PageSizeFloatModelResource> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeFloatModelClientDiagnostics.CreateScope("PageSizeFloatModelCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _pageSizeFloatModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<PageSizeFloatModelResource>(response.GetRawResponse());
                return Response.FromValue(new PageSizeFloatModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PageSizeFloatModelResource> IEnumerable<PageSizeFloatModelResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PageSizeFloatModelResource> IAsyncEnumerable<PageSizeFloatModelResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
