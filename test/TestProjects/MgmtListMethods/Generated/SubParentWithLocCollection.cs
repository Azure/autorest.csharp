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
    /// <summary> A class representing collection of SubParentWithLoc and their operations over its parent. </summary>
    public partial class SubParentWithLocCollection : ArmCollection, IEnumerable<SubParentWithLoc>, IAsyncEnumerable<SubParentWithLoc>

    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SubParentWithLocsRestOperations _subParentWithLocsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubParentWithLocCollection"/> class for mocking. </summary>
        protected SubParentWithLocCollection()
        {
        }

        /// <summary> Initializes a new instance of SubParentWithLocCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SubParentWithLocCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _subParentWithLocsRestClient = new SubParentWithLocsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => Subscription.ResourceType;

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs/{subParentWithLocName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SubParentWithLocs_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual SubParentWithLocCreateOrUpdateOperation CreateOrUpdate(string subParentWithLocName, SubParentWithLocData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (subParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithLocName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _subParentWithLocsRestClient.CreateOrUpdate(Id.SubscriptionId, subParentWithLocName, parameters, cancellationToken);
                var operation = new SubParentWithLocCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs/{subParentWithLocName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SubParentWithLocs_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<SubParentWithLocCreateOrUpdateOperation> CreateOrUpdateAsync(string subParentWithLocName, SubParentWithLocData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (subParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithLocName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _subParentWithLocsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, subParentWithLocName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SubParentWithLocCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs/{subParentWithLocName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SubParentWithLocs_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> is null. </exception>
        public virtual Response<SubParentWithLoc> Get(string subParentWithLocName, CancellationToken cancellationToken = default)
        {
            if (subParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = _subParentWithLocsRestClient.Get(Id.SubscriptionId, subParentWithLocName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubParentWithLoc(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs/{subParentWithLocName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SubParentWithLocs_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> is null. </exception>
        public async virtual Task<Response<SubParentWithLoc>> GetAsync(string subParentWithLocName, CancellationToken cancellationToken = default)
        {
            if (subParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = await _subParentWithLocsRestClient.GetAsync(Id.SubscriptionId, subParentWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SubParentWithLoc(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> is null. </exception>
        public virtual Response<SubParentWithLoc> GetIfExists(string subParentWithLocName, CancellationToken cancellationToken = default)
        {
            if (subParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _subParentWithLocsRestClient.Get(Id.SubscriptionId, subParentWithLocName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<SubParentWithLoc>(null, response.GetRawResponse())
                    : Response.FromValue(new SubParentWithLoc(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> is null. </exception>
        public async virtual Task<Response<SubParentWithLoc>> GetIfExistsAsync(string subParentWithLocName, CancellationToken cancellationToken = default)
        {
            if (subParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithLocCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _subParentWithLocsRestClient.GetAsync(Id.SubscriptionId, subParentWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<SubParentWithLoc>(null, response.GetRawResponse())
                    : Response.FromValue(new SubParentWithLoc(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> is null. </exception>
        public virtual Response<bool> Exists(string subParentWithLocName, CancellationToken cancellationToken = default)
        {
            if (subParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(subParentWithLocName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string subParentWithLocName, CancellationToken cancellationToken = default)
        {
            if (subParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithLocCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(subParentWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SubParentWithLocs_List
        /// <summary> Lists all. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubParentWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubParentWithLoc> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SubParentWithLoc> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _subParentWithLocsRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParentWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubParentWithLoc> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _subParentWithLocsRestClient.ListNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParentWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SubParentWithLocs_List
        /// <summary> Lists all. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubParentWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubParentWithLoc> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SubParentWithLoc>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _subParentWithLocsRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParentWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubParentWithLoc>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _subParentWithLocsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParentWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="SubParentWithLoc" /> for this subscription represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubParentWithLocCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SubParentWithLoc.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as Subscription, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SubParentWithLoc" /> for this subscription represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubParentWithLocCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SubParentWithLoc.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as Subscription, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SubParentWithLoc> IEnumerable<SubParentWithLoc>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SubParentWithLoc> IAsyncEnumerable<SubParentWithLoc>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, SubParentWithLoc, SubParentWithLocData> Construct() { }
    }
}
