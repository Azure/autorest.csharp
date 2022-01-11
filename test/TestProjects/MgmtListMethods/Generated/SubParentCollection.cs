// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A class representing collection of SubParent and their operations over its parent. </summary>
    public partial class SubParentCollection : ArmCollection, IEnumerable<SubParent>, IAsyncEnumerable<SubParent>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SubParentsRestOperations _subParentsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubParentCollection"/> class for mocking. </summary>
        protected SubParentCollection()
        {
        }

        /// <summary> Initializes a new instance of SubParentCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SubParentCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _subParentsRestClient = new SubParentsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents/{subParentName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SubParents_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="subParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual SubParentCreateOrUpdateOperation CreateOrUpdate(string subParentName, SubParentData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (subParentName == null)
            {
                throw new ArgumentNullException(nameof(subParentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _subParentsRestClient.CreateOrUpdate(Id.SubscriptionId, subParentName, parameters, cancellationToken);
                var operation = new SubParentCreateOrUpdateOperation(Parent, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents/{subParentName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SubParents_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="subParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<SubParentCreateOrUpdateOperation> CreateOrUpdateAsync(string subParentName, SubParentData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (subParentName == null)
            {
                throw new ArgumentNullException(nameof(subParentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _subParentsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, subParentName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SubParentCreateOrUpdateOperation(Parent, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents/{subParentName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SubParents_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="subParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> is null. </exception>
        public virtual Response<SubParent> Get(string subParentName, CancellationToken cancellationToken = default)
        {
            if (subParentName == null)
            {
                throw new ArgumentNullException(nameof(subParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentCollection.Get");
            scope.Start();
            try
            {
                var response = _subParentsRestClient.Get(Id.SubscriptionId, subParentName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubParent(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents/{subParentName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SubParents_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="subParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> is null. </exception>
        public async virtual Task<Response<SubParent>> GetAsync(string subParentName, CancellationToken cancellationToken = default)
        {
            if (subParentName == null)
            {
                throw new ArgumentNullException(nameof(subParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _subParentsRestClient.GetAsync(Id.SubscriptionId, subParentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SubParent(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> is null. </exception>
        public virtual Response<SubParent> GetIfExists(string subParentName, CancellationToken cancellationToken = default)
        {
            if (subParentName == null)
            {
                throw new ArgumentNullException(nameof(subParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _subParentsRestClient.Get(Id.SubscriptionId, subParentName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<SubParent>(null, response.GetRawResponse())
                    : Response.FromValue(new SubParent(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> is null. </exception>
        public async virtual Task<Response<SubParent>> GetIfExistsAsync(string subParentName, CancellationToken cancellationToken = default)
        {
            if (subParentName == null)
            {
                throw new ArgumentNullException(nameof(subParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _subParentsRestClient.GetAsync(Id.SubscriptionId, subParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<SubParent>(null, response.GetRawResponse())
                    : Response.FromValue(new SubParent(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> is null. </exception>
        public virtual Response<bool> Exists(string subParentName, CancellationToken cancellationToken = default)
        {
            if (subParentName == null)
            {
                throw new ArgumentNullException(nameof(subParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentCollection.Exists");
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

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string subParentName, CancellationToken cancellationToken = default)
        {
            if (subParentName == null)
            {
                throw new ArgumentNullException(nameof(subParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentCollection.ExistsAsync");
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SubParents_List
        /// <summary> Lists all. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubParent" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubParent> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SubParent> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _subParentsRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParent(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubParent> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _subParentsRestClient.ListNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParent(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SubParents_List
        /// <summary> Lists all. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubParent" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubParent> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SubParent>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _subParentsRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParent(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubParent>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _subParentsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParent(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="SubParent" /> for this subscription represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubParentCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SubParent.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as Subscription, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SubParent" /> for this subscription represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubParentCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SubParent.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as Subscription, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SubParent> IEnumerable<SubParent>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SubParent> IAsyncEnumerable<SubParent>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, SubParent, SubParentData> Construct() { }
    }
}
