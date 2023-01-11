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

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing a collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> and their operations.
    /// Each <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="ResGrpParentWithAncestorWithNonResChWithLocCollection" /> instance call the GetResGrpParentWithAncestorWithNonResChWithLocs method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class ResGrpParentWithAncestorWithNonResChWithLocCollection : ArmCollection, IEnumerable<ResGrpParentWithAncestorWithNonResChWithLocResource>, IAsyncEnumerable<ResGrpParentWithAncestorWithNonResChWithLocResource>
    {
        private readonly ClientDiagnostics _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics;
        private readonly ResGrpParentWithAncestorWithNonResChWithLocsRestOperations _resGrpParentWithAncestorWithNonResChWithLocRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorWithNonResChWithLocCollection"/> class for mocking. </summary>
        protected ResGrpParentWithAncestorWithNonResChWithLocCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorWithNonResChWithLocCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ResGrpParentWithAncestorWithNonResChWithLocCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics = new ClientDiagnostics("MgmtListMethods", ResGrpParentWithAncestorWithNonResChWithLocResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResGrpParentWithAncestorWithNonResChWithLocResource.ResourceType, out string resGrpParentWithAncestorWithNonResChWithLocApiVersion);
            _resGrpParentWithAncestorWithNonResChWithLocRestClient = new ResGrpParentWithAncestorWithNonResChWithLocsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, resGrpParentWithAncestorWithNonResChWithLocApiVersion);
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
        /// Create or update.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChWithLocs_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ResGrpParentWithAncestorWithNonResChWithLocResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string resGrpParentWithAncestorWithNonResChWithLocName, ResGrpParentWithAncestorWithNonResChWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChWithLocName, nameof(resGrpParentWithAncestorWithNonResChWithLocName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChWithLocRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChWithLocName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<ResGrpParentWithAncestorWithNonResChWithLocResource>(Response.FromValue(new ResGrpParentWithAncestorWithNonResChWithLocResource(Client, response), response.GetRawResponse()));
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
        /// Create or update.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChWithLocs_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ResGrpParentWithAncestorWithNonResChWithLocResource> CreateOrUpdate(WaitUntil waitUntil, string resGrpParentWithAncestorWithNonResChWithLocName, ResGrpParentWithAncestorWithNonResChWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChWithLocName, nameof(resGrpParentWithAncestorWithNonResChWithLocName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChWithLocRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChWithLocName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<ResGrpParentWithAncestorWithNonResChWithLocResource>(Response.FromValue(new ResGrpParentWithAncestorWithNonResChWithLocResource(Client, response), response.GetRawResponse()));
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
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual async Task<Response<ResGrpParentWithAncestorWithNonResChWithLocResource>> GetAsync(string resGrpParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChWithLocName, nameof(resGrpParentWithAncestorWithNonResChWithLocName));

            using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChWithLocRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResChWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestorWithNonResChWithLocResource> Get(string resGrpParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChWithLocName, nameof(resGrpParentWithAncestorWithNonResChWithLocName));

            using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChWithLocRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChWithLocName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResChWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChWithLocs_ListTest</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestorWithNonResChWithLocResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _resGrpParentWithAncestorWithNonResChWithLocRestClient.CreateListTestRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _resGrpParentWithAncestorWithNonResChWithLocRestClient.CreateListTestNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ResGrpParentWithAncestorWithNonResChWithLocResource(Client, ResGrpParentWithAncestorWithNonResChWithLocData.DeserializeResGrpParentWithAncestorWithNonResChWithLocData(e)), _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics, Pipeline, "ResGrpParentWithAncestorWithNonResChWithLocCollection.GetAll", "value", "nextLink");
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChWithLocs_ListTest</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestorWithNonResChWithLocResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _resGrpParentWithAncestorWithNonResChWithLocRestClient.CreateListTestRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _resGrpParentWithAncestorWithNonResChWithLocRestClient.CreateListTestNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ResGrpParentWithAncestorWithNonResChWithLocResource(Client, ResGrpParentWithAncestorWithNonResChWithLocData.DeserializeResGrpParentWithAncestorWithNonResChWithLocData(e)), _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics, Pipeline, "ResGrpParentWithAncestorWithNonResChWithLocCollection.GetAll", "value", "nextLink");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string resGrpParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChWithLocName, nameof(resGrpParentWithAncestorWithNonResChWithLocName));

            using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChWithLocRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<bool> Exists(string resGrpParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChWithLocName, nameof(resGrpParentWithAncestorWithNonResChWithLocName));

            using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChWithLocRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChWithLocName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ResGrpParentWithAncestorWithNonResChWithLocResource> IEnumerable<ResGrpParentWithAncestorWithNonResChWithLocResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ResGrpParentWithAncestorWithNonResChWithLocResource> IAsyncEnumerable<ResGrpParentWithAncestorWithNonResChWithLocResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
