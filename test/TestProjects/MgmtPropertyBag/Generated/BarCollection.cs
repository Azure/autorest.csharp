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
using MgmtPropertyBag.Models;

namespace MgmtPropertyBag
{
    /// <summary>
    /// A class representing a collection of <see cref="BarResource" /> and their operations.
    /// Each <see cref="BarResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="BarCollection" /> instance call the GetBars method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class BarCollection : ArmCollection, IEnumerable<BarResource>, IAsyncEnumerable<BarResource>
    {
        private readonly ClientDiagnostics _barClientDiagnostics;
        private readonly BarsRestOperations _barRestClient;

        /// <summary> Initializes a new instance of the <see cref="BarCollection"/> class for mocking. </summary>
        protected BarCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="BarCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal BarCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _barClientDiagnostics = new ClientDiagnostics("MgmtPropertyBag", BarResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(BarResource.ResourceType, out string barApiVersion);
            _barRestClient = new BarsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, barApiVersion);
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
        /// Create a bar with five optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="barName"> The bar name. </param>
        /// <param name="data"> The bar parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of &quot;*&quot; can be used for If-Match to unconditionally apply the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="barName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="barName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<BarResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string barName, BarData data, string filter = null, int? top = null, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(barName, nameof(barName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _barClientDiagnostics.CreateScope("BarCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _barRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, barName, data, filter, top, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtPropertyBagArmOperation<BarResource>(Response.FromValue(new BarResource(Client, response), response.GetRawResponse()));
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
        /// Create a bar with five optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="barName"> The bar name. </param>
        /// <param name="data"> The bar parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of &quot;*&quot; can be used for If-Match to unconditionally apply the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="barName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="barName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<BarResource> CreateOrUpdate(WaitUntil waitUntil, string barName, BarData data, string filter = null, int? top = null, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(barName, nameof(barName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _barClientDiagnostics.CreateScope("BarCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _barRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, barName, data, filter, top, ifMatch, cancellationToken);
                var operation = new MgmtPropertyBagArmOperation<BarResource>(Response.FromValue(new BarResource(Client, response), response.GetRawResponse()));
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
        /// Gets a specific bar with one required header parameter and four optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<BarResource>> GetAsync(BarCollectionGetOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _barClientDiagnostics.CreateScope("BarCollection.Get");
            scope.Start();
            try
            {
                var response = await _barRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, options.BarName, options.IfMatch, options.Filter, options.Top, options.Maxpagesize, options.Skip, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BarResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a specific bar with one required header parameter and four optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<BarResource> Get(BarCollectionGetOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _barClientDiagnostics.CreateScope("BarCollection.Get");
            scope.Start();
            try
            {
                var response = _barRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, options.BarName, options.IfMatch, options.Filter, options.Top, options.Maxpagesize, options.Skip, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BarResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of bar with one optional header parameter and five optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BarResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BarResource> GetAllAsync(BarCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new BarCollectionGetAllOptions();

            HttpMessage FirstPageRequest(int? pageSizeHint) => _barRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, options.IfMatch, options.Filter, options.Top, options.IfNoneMatch, options.Maxpagesize, options.Skip);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new BarResource(Client, BarData.DeserializeBarData(e)), _barClientDiagnostics, Pipeline, "BarCollection.GetAll", "", null, cancellationToken);
        }

        /// <summary>
        /// Gets a list of bar with one optional header parameter and five optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BarResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BarResource> GetAll(BarCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new BarCollectionGetAllOptions();

            HttpMessage FirstPageRequest(int? pageSizeHint) => _barRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, options.IfMatch, options.Filter, options.Top, options.IfNoneMatch, options.Maxpagesize, options.Skip);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new BarResource(Client, BarData.DeserializeBarData(e)), _barClientDiagnostics, Pipeline, "BarCollection.GetAll", "", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(BarCollectionExistsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _barClientDiagnostics.CreateScope("BarCollection.Exists");
            scope.Start();
            try
            {
                var response = await _barRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, options.BarName, options.IfMatch, options.Filter, options.Top, options.Maxpagesize, options.Skip, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<bool> Exists(BarCollectionExistsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _barClientDiagnostics.CreateScope("BarCollection.Exists");
            scope.Start();
            try
            {
                var response = _barRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, options.BarName, options.IfMatch, options.Filter, options.Top, options.Maxpagesize, options.Skip, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<BarResource> IEnumerable<BarResource>.GetEnumerator()
        {
            return GetAll(options: null).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll(options: null).GetEnumerator();
        }

        IAsyncEnumerator<BarResource> IAsyncEnumerable<BarResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(options: null, cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
