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

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing a collection of <see cref="SubParentResource" /> and their operations.
    /// Each <see cref="SubParentResource" /> in the collection will belong to the same instance of <see cref="SubscriptionResource" />.
    /// To get a <see cref="SubParentCollection" /> instance call the GetSubParents method from an instance of <see cref="SubscriptionResource" />.
    /// </summary>
    public partial class SubParentCollection : ArmCollection, IEnumerable<SubParentResource>, IAsyncEnumerable<SubParentResource>
    {
        private readonly ClientDiagnostics _subParentClientDiagnostics;
        private readonly SubParentsRestOperations _subParentRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubParentCollection"/> class for mocking. </summary>
        protected SubParentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubParentCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SubParentCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _subParentClientDiagnostics = new ClientDiagnostics("MgmtListMethods", SubParentResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SubParentResource.ResourceType, out string subParentApiVersion);
            _subParentRestClient = new SubParentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, subParentApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents/{subParentName}
        /// Operation Id: SubParents_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="subParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<SubParentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string subParentName, SubParentData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subParentName, nameof(subParentName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _subParentRestClient.CreateOrUpdateAsync(Id.SubscriptionId, subParentName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<SubParentResource>(Response.FromValue(new SubParentResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents/{subParentName}
        /// Operation Id: SubParents_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="subParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<SubParentResource> CreateOrUpdate(WaitUntil waitUntil, string subParentName, SubParentData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subParentName, nameof(subParentName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _subParentRestClient.CreateOrUpdate(Id.SubscriptionId, subParentName, parameters, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<SubParentResource>(Response.FromValue(new SubParentResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents/{subParentName}
        /// Operation Id: SubParents_Get
        /// </summary>
        /// <param name="subParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> is null. </exception>
        public virtual async Task<Response<SubParentResource>> GetAsync(string subParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subParentName, nameof(subParentName));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _subParentRestClient.GetAsync(Id.SubscriptionId, subParentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents/{subParentName}
        /// Operation Id: SubParents_Get
        /// </summary>
        /// <param name="subParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> is null. </exception>
        public virtual Response<SubParentResource> Get(string subParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subParentName, nameof(subParentName));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.Get");
            scope.Start();
            try
            {
                var response = _subParentRestClient.Get(Id.SubscriptionId, subParentName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents
        /// Operation Id: SubParents_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubParentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubParentResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SubParentResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _subParentRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParentResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubParentResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _subParentRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParentResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents
        /// Operation Id: SubParents_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubParentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubParentResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SubParentResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _subParentRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParentResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubParentResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _subParentRestClient.ListNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParentResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents/{subParentName}
        /// Operation Id: SubParents_Get
        /// </summary>
        /// <param name="subParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string subParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subParentName, nameof(subParentName));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(subParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents/{subParentName}
        /// Operation Id: SubParents_Get
        /// </summary>
        /// <param name="subParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> is null. </exception>
        public virtual Response<bool> Exists(string subParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subParentName, nameof(subParentName));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(subParentName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents/{subParentName}
        /// Operation Id: SubParents_Get
        /// </summary>
        /// <param name="subParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> is null. </exception>
        public virtual async Task<Response<SubParentResource>> GetIfExistsAsync(string subParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subParentName, nameof(subParentName));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _subParentRestClient.GetAsync(Id.SubscriptionId, subParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SubParentResource>(null, response.GetRawResponse());
                return Response.FromValue(new SubParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents/{subParentName}
        /// Operation Id: SubParents_Get
        /// </summary>
        /// <param name="subParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> is null. </exception>
        public virtual Response<SubParentResource> GetIfExists(string subParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subParentName, nameof(subParentName));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _subParentRestClient.Get(Id.SubscriptionId, subParentName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SubParentResource>(null, response.GetRawResponse());
                return Response.FromValue(new SubParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SubParentResource> IEnumerable<SubParentResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SubParentResource> IAsyncEnumerable<SubParentResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
