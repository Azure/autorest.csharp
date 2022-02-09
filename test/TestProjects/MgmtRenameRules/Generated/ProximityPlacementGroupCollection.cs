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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace MgmtRenameRules
{
    /// <summary> A class representing collection of ProximityPlacementGroup and their operations over its parent. </summary>
    public partial class ProximityPlacementGroupCollection : ArmCollection, IEnumerable<ProximityPlacementGroup>, IAsyncEnumerable<ProximityPlacementGroup>
    {
        private readonly ClientDiagnostics _proximityPlacementGroupClientDiagnostics;
        private readonly ProximityPlacementGroupsRestOperations _proximityPlacementGroupRestClient;

        /// <summary> Initializes a new instance of the <see cref="ProximityPlacementGroupCollection"/> class for mocking. </summary>
        protected ProximityPlacementGroupCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ProximityPlacementGroupCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ProximityPlacementGroupCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _proximityPlacementGroupClientDiagnostics = new ClientDiagnostics("MgmtRenameRules", ProximityPlacementGroup.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ProximityPlacementGroup.ResourceType, out string proximityPlacementGroupApiVersion);
            _proximityPlacementGroupRestClient = new ProximityPlacementGroupsRestOperations(_proximityPlacementGroupClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, proximityPlacementGroupApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ProximityPlacementGroups_CreateOrUpdate
        /// <summary> Create or update a proximity placement group. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<ProximityPlacementGroup>> CreateOrUpdateAsync(bool waitForCompletion, string proximityPlacementGroupName, ProximityPlacementGroupData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _proximityPlacementGroupRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, proximityPlacementGroupName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation<ProximityPlacementGroup>(Response.FromValue(new ProximityPlacementGroup(Client, response), response.GetRawResponse()));
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ProximityPlacementGroups_CreateOrUpdate
        /// <summary> Create or update a proximity placement group. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ProximityPlacementGroup> CreateOrUpdate(bool waitForCompletion, string proximityPlacementGroupName, ProximityPlacementGroupData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _proximityPlacementGroupRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, proximityPlacementGroupName, parameters, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation<ProximityPlacementGroup>(Response.FromValue(new ProximityPlacementGroup(Client, response), response.GetRawResponse()));
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ProximityPlacementGroups_Get
        /// <summary> Retrieves information about a proximity placement group . </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> is null. </exception>
        public async virtual Task<Response<ProximityPlacementGroup>> GetAsync(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.Get");
            scope.Start();
            try
            {
                var response = await _proximityPlacementGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, proximityPlacementGroupName, includeColocationStatus, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _proximityPlacementGroupClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ProximityPlacementGroup(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ProximityPlacementGroups_Get
        /// <summary> Retrieves information about a proximity placement group . </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> is null. </exception>
        public virtual Response<ProximityPlacementGroup> Get(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.Get");
            scope.Start();
            try
            {
                var response = _proximityPlacementGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, proximityPlacementGroupName, includeColocationStatus, cancellationToken);
                if (response.Value == null)
                    throw _proximityPlacementGroupClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ProximityPlacementGroup(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ProximityPlacementGroups_ListByResourceGroup
        /// <summary> Lists all proximity placement groups in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ProximityPlacementGroup" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ProximityPlacementGroup> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ProximityPlacementGroup>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _proximityPlacementGroupRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ProximityPlacementGroup(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ProximityPlacementGroup>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _proximityPlacementGroupRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ProximityPlacementGroup(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ProximityPlacementGroups_ListByResourceGroup
        /// <summary> Lists all proximity placement groups in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ProximityPlacementGroup" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ProximityPlacementGroup> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ProximityPlacementGroup> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _proximityPlacementGroupRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ProximityPlacementGroup(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ProximityPlacementGroup> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _proximityPlacementGroupRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ProximityPlacementGroup(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ProximityPlacementGroups_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(proximityPlacementGroupName, includeColocationStatus: includeColocationStatus, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ProximityPlacementGroups_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> is null. </exception>
        public virtual Response<bool> Exists(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(proximityPlacementGroupName, includeColocationStatus: includeColocationStatus, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ProximityPlacementGroups_Get
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> is null. </exception>
        public async virtual Task<Response<ProximityPlacementGroup>> GetIfExistsAsync(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _proximityPlacementGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, proximityPlacementGroupName, includeColocationStatus, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ProximityPlacementGroup>(null, response.GetRawResponse());
                return Response.FromValue(new ProximityPlacementGroup(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ProximityPlacementGroups_Get
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> is null. </exception>
        public virtual Response<ProximityPlacementGroup> GetIfExists(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _proximityPlacementGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, proximityPlacementGroupName, includeColocationStatus, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ProximityPlacementGroup>(null, response.GetRawResponse());
                return Response.FromValue(new ProximityPlacementGroup(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ProximityPlacementGroup> IEnumerable<ProximityPlacementGroup>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ProximityPlacementGroup> IAsyncEnumerable<ProximityPlacementGroup>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
