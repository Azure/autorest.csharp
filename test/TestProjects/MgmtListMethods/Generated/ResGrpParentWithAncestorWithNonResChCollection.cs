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

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing a collection of <see cref="ResGrpParentWithAncestorWithNonResChResource" /> and their operations.
    /// Each <see cref="ResGrpParentWithAncestorWithNonResChResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="ResGrpParentWithAncestorWithNonResChCollection" /> instance call the GetResGrpParentWithAncestorWithNonResChes method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class ResGrpParentWithAncestorWithNonResChCollection : ArmCollection, IEnumerable<ResGrpParentWithAncestorWithNonResChResource>, IAsyncEnumerable<ResGrpParentWithAncestorWithNonResChResource>
    {
        private readonly ClientDiagnostics _resGrpParentWithAncestorWithNonResChClientDiagnostics;
        private readonly ResGrpParentWithAncestorWithNonResChesRestOperations _resGrpParentWithAncestorWithNonResChRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorWithNonResChCollection"/> class for mocking. </summary>
        protected ResGrpParentWithAncestorWithNonResChCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorWithNonResChCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ResGrpParentWithAncestorWithNonResChCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _resGrpParentWithAncestorWithNonResChClientDiagnostics = new ClientDiagnostics("MgmtListMethods", ResGrpParentWithAncestorWithNonResChResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResGrpParentWithAncestorWithNonResChResource.ResourceType, out string resGrpParentWithAncestorWithNonResChApiVersion);
            _resGrpParentWithAncestorWithNonResChRestClient = new ResGrpParentWithAncestorWithNonResChesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, resGrpParentWithAncestorWithNonResChApiVersion);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChes_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ResGrpParentWithAncestorWithNonResChResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string resGrpParentWithAncestorWithNonResChName, ResGrpParentWithAncestorWithNonResChData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChName, nameof(resGrpParentWithAncestorWithNonResChName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<ResGrpParentWithAncestorWithNonResChResource>(Response.FromValue(new ResGrpParentWithAncestorWithNonResChResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChes_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ResGrpParentWithAncestorWithNonResChResource> CreateOrUpdate(WaitUntil waitUntil, string resGrpParentWithAncestorWithNonResChName, ResGrpParentWithAncestorWithNonResChData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChName, nameof(resGrpParentWithAncestorWithNonResChName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<ResGrpParentWithAncestorWithNonResChResource>(Response.FromValue(new ResGrpParentWithAncestorWithNonResChResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public virtual async Task<Response<ResGrpParentWithAncestorWithNonResChResource>> GetAsync(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChName, nameof(resGrpParentWithAncestorWithNonResChName));

            using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResChResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestorWithNonResChResource> Get(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChName, nameof(resGrpParentWithAncestorWithNonResChName));

            using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResChResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChes_ListTest</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestorWithNonResChResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _resGrpParentWithAncestorWithNonResChRestClient.CreateListTestRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _resGrpParentWithAncestorWithNonResChRestClient.CreateListTestNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ResGrpParentWithAncestorWithNonResChResource(Client, ResGrpParentWithAncestorWithNonResChData.DeserializeResGrpParentWithAncestorWithNonResChData(e)), _resGrpParentWithAncestorWithNonResChClientDiagnostics, Pipeline, "ResGrpParentWithAncestorWithNonResChCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChes_ListTest</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestorWithNonResChResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _resGrpParentWithAncestorWithNonResChRestClient.CreateListTestRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _resGrpParentWithAncestorWithNonResChRestClient.CreateListTestNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ResGrpParentWithAncestorWithNonResChResource(Client, ResGrpParentWithAncestorWithNonResChData.DeserializeResGrpParentWithAncestorWithNonResChData(e)), _resGrpParentWithAncestorWithNonResChClientDiagnostics, Pipeline, "ResGrpParentWithAncestorWithNonResChCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChName, nameof(resGrpParentWithAncestorWithNonResChName));

            using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public virtual Response<bool> Exists(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChName, nameof(resGrpParentWithAncestorWithNonResChName));

            using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ResGrpParentWithAncestorWithNonResChResource> IEnumerable<ResGrpParentWithAncestorWithNonResChResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ResGrpParentWithAncestorWithNonResChResource> IAsyncEnumerable<ResGrpParentWithAncestorWithNonResChResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
