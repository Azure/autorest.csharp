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
    /// A class representing a collection of <see cref="SubParentWithLocResource" /> and their operations.
    /// Each <see cref="SubParentWithLocResource" /> in the collection will belong to the same instance of <see cref="SubscriptionResource" />.
    /// To get a <see cref="SubParentWithLocCollection" /> instance call the GetSubParentWithLocs method from an instance of <see cref="SubscriptionResource" />.
    /// </summary>
    public partial class SubParentWithLocCollection : ArmCollection, IEnumerable<SubParentWithLocResource>, IAsyncEnumerable<SubParentWithLocResource>
    {
        private readonly ClientDiagnostics _subParentWithLocClientDiagnostics;
        private readonly SubParentWithLocsRestOperations _subParentWithLocRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubParentWithLocCollection"/> class for mocking. </summary>
        protected SubParentWithLocCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubParentWithLocCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SubParentWithLocCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _subParentWithLocClientDiagnostics = new ClientDiagnostics("MgmtListMethods", SubParentWithLocResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SubParentWithLocResource.ResourceType, out string subParentWithLocApiVersion);
            _subParentWithLocRestClient = new SubParentWithLocsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, subParentWithLocApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SubscriptionResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SubscriptionResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs/{subParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParentWithLocs_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SubParentWithLocResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string subParentWithLocName, SubParentWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subParentWithLocName, nameof(subParentWithLocName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _subParentWithLocClientDiagnostics.CreateScope("SubParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _subParentWithLocRestClient.CreateOrUpdateAsync(Id.SubscriptionId, subParentWithLocName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<SubParentWithLocResource>(Response.FromValue(new SubParentWithLocResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs/{subParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParentWithLocs_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SubParentWithLocResource> CreateOrUpdate(WaitUntil waitUntil, string subParentWithLocName, SubParentWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subParentWithLocName, nameof(subParentWithLocName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _subParentWithLocClientDiagnostics.CreateScope("SubParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _subParentWithLocRestClient.CreateOrUpdate(Id.SubscriptionId, subParentWithLocName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<SubParentWithLocResource>(Response.FromValue(new SubParentWithLocResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs/{subParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> is null. </exception>
        public virtual async Task<Response<SubParentWithLocResource>> GetAsync(string subParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subParentWithLocName, nameof(subParentWithLocName));

            using var scope = _subParentWithLocClientDiagnostics.CreateScope("SubParentWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = await _subParentWithLocRestClient.GetAsync(Id.SubscriptionId, subParentWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubParentWithLocResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs/{subParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> is null. </exception>
        public virtual Response<SubParentWithLocResource> Get(string subParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subParentWithLocName, nameof(subParentWithLocName));

            using var scope = _subParentWithLocClientDiagnostics.CreateScope("SubParentWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = _subParentWithLocRestClient.Get(Id.SubscriptionId, subParentWithLocName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubParentWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParentWithLocs_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubParentWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubParentWithLocResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _subParentWithLocRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _subParentWithLocRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SubParentWithLocResource(Client, SubParentWithLocData.DeserializeSubParentWithLocData(e)), _subParentWithLocClientDiagnostics, Pipeline, "SubParentWithLocCollection.GetAll", "value", "nextLink");
        }

        /// <summary>
        /// Lists all
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParentWithLocs_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubParentWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubParentWithLocResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _subParentWithLocRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _subParentWithLocRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SubParentWithLocResource(Client, SubParentWithLocData.DeserializeSubParentWithLocData(e)), _subParentWithLocClientDiagnostics, Pipeline, "SubParentWithLocCollection.GetAll", "value", "nextLink");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs/{subParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string subParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subParentWithLocName, nameof(subParentWithLocName));

            using var scope = _subParentWithLocClientDiagnostics.CreateScope("SubParentWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = await _subParentWithLocRestClient.GetAsync(Id.SubscriptionId, subParentWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs/{subParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> is null. </exception>
        public virtual Response<bool> Exists(string subParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subParentWithLocName, nameof(subParentWithLocName));

            using var scope = _subParentWithLocClientDiagnostics.CreateScope("SubParentWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = _subParentWithLocRestClient.Get(Id.SubscriptionId, subParentWithLocName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SubParentWithLocResource> IEnumerable<SubParentWithLocResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SubParentWithLocResource> IAsyncEnumerable<SubParentWithLocResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
