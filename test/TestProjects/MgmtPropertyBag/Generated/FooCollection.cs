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
using Azure.ResourceManager.Resources;
using MgmtPropertyBag.Models;

namespace MgmtPropertyBag
{
    /// <summary>
    /// A class representing a collection of <see cref="FooResource" /> and their operations.
    /// Each <see cref="FooResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="FooCollection" /> instance call the GetFoos method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class FooCollection : ArmCollection, IEnumerable<FooResource>, IAsyncEnumerable<FooResource>
    {
        private readonly ClientDiagnostics _fooClientDiagnostics;
        private readonly FoosRestOperations _fooRestClient;

        /// <summary> Initializes a new instance of the <see cref="FooCollection"/> class for mocking. </summary>
        protected FooCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FooCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FooCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fooClientDiagnostics = new ClientDiagnostics("MgmtPropertyBag", FooResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(FooResource.ResourceType, out string fooApiVersion);
            _fooRestClient = new FoosRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, fooApiVersion);
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
        /// Create foo with four optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fooName"> The foo name. </param>
        /// <param name="data"> The foo parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="orderby"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fooName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fooName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<FooResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string fooName, FooData data, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fooName, nameof(fooName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fooClientDiagnostics.CreateScope("FooCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fooRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, fooName, data, filter, top, orderby, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtPropertyBagArmOperation<FooResource>(Response.FromValue(new FooResource(Client, response), response.GetRawResponse()));
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
        /// Create foo with four optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fooName"> The foo name. </param>
        /// <param name="data"> The foo parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="orderby"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fooName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fooName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<FooResource> CreateOrUpdate(WaitUntil waitUntil, string fooName, FooData data, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fooName, nameof(fooName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fooClientDiagnostics.CreateScope("FooCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fooRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, fooName, data, filter, top, orderby, cancellationToken);
                var operation = new MgmtPropertyBagArmOperation<FooResource>(Response.FromValue(new FooResource(Client, response), response.GetRawResponse()));
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
        /// Gets a specific foo with five optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<FooResource>> GetAsync(FooCollectionGetOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _fooClientDiagnostics.CreateScope("FooCollection.Get");
            scope.Start();
            try
            {
                var response = await _fooRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, options.FooName, options.Filter, options.Top, options.Orderby, options.IfMatch, options.Skip, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FooResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a specific foo with five optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<FooResource> Get(FooCollectionGetOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _fooClientDiagnostics.CreateScope("FooCollection.Get");
            scope.Start();
            try
            {
                var response = _fooRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, options.FooName, options.Filter, options.Top, options.Orderby, options.IfMatch, options.Skip, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FooResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of foo with six optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FooResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FooResource> GetAllAsync(FooCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new FooCollectionGetAllOptions();

            HttpMessage FirstPageRequest(int? pageSizeHint) => _fooRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, options.Filter, options.Top, options.Orderby, options.IfMatch, options.Maxpagesize, options.Skip);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new FooResource(Client, FooData.DeserializeFooData(e)), _fooClientDiagnostics, Pipeline, "FooCollection.GetAll", "", null, cancellationToken);
        }

        /// <summary>
        /// Gets a list of foo with six optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FooResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FooResource> GetAll(FooCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new FooCollectionGetAllOptions();

            HttpMessage FirstPageRequest(int? pageSizeHint) => _fooRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, options.Filter, options.Top, options.Orderby, options.IfMatch, options.Maxpagesize, options.Skip);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new FooResource(Client, FooData.DeserializeFooData(e)), _fooClientDiagnostics, Pipeline, "FooCollection.GetAll", "", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(FooCollectionExistsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _fooClientDiagnostics.CreateScope("FooCollection.Exists");
            scope.Start();
            try
            {
                var response = await _fooRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, options.FooName, options.Filter, options.Top, options.Orderby, options.IfMatch, options.Skip, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<bool> Exists(FooCollectionExistsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _fooClientDiagnostics.CreateScope("FooCollection.Exists");
            scope.Start();
            try
            {
                var response = _fooRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, options.FooName, options.Filter, options.Top, options.Orderby, options.IfMatch, options.Skip, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<FooResource> IEnumerable<FooResource>.GetEnumerator()
        {
            return GetAll(options: null).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll(options: null).GetEnumerator();
        }

        IAsyncEnumerator<FooResource> IAsyncEnumerable<FooResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(options: null, cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
