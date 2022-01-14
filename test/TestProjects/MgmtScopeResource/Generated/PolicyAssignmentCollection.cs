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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Resources;
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    /// <summary> A class representing collection of PolicyAssignment and their operations over its parent. </summary>
    public partial class PolicyAssignmentCollection : ArmCollection, IEnumerable<PolicyAssignment>, IAsyncEnumerable<PolicyAssignment>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly PolicyAssignmentsRestOperations _policyAssignmentsRestClient;

        /// <summary> Initializes a new instance of the <see cref="PolicyAssignmentCollection"/> class for mocking. </summary>
        protected PolicyAssignmentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PolicyAssignmentCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal PolicyAssignmentCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _policyAssignmentsRestClient = new PolicyAssignmentsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        // Collection level operations.

        /// RequestPath: /{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}
        /// ContextualPath: /{scope}
        /// OperationId: PolicyAssignments_Create
        /// <summary> This operation creates or updates a policy assignment with the given scope and name. Policy assignments apply to all resources contained within their scope. For example, when you assign a policy at resource group scope, that policy applies to all resources in the group. </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment. </param>
        /// <param name="parameters"> Parameters for the policy assignment. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual PolicyAssignmentCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string policyAssignmentName, PolicyAssignmentData parameters, CancellationToken cancellationToken = default)
        {
            if (policyAssignmentName == null)
            {
                throw new ArgumentNullException(nameof(policyAssignmentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _policyAssignmentsRestClient.Create(Id, policyAssignmentName, parameters, cancellationToken);
                var operation = new PolicyAssignmentCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}
        /// ContextualPath: /{scope}
        /// OperationId: PolicyAssignments_Create
        /// <summary> This operation creates or updates a policy assignment with the given scope and name. Policy assignments apply to all resources contained within their scope. For example, when you assign a policy at resource group scope, that policy applies to all resources in the group. </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment. </param>
        /// <param name="parameters"> Parameters for the policy assignment. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<PolicyAssignmentCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string policyAssignmentName, PolicyAssignmentData parameters, CancellationToken cancellationToken = default)
        {
            if (policyAssignmentName == null)
            {
                throw new ArgumentNullException(nameof(policyAssignmentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _policyAssignmentsRestClient.CreateAsync(Id, policyAssignmentName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new PolicyAssignmentCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}
        /// ContextualPath: /{scope}
        /// OperationId: PolicyAssignments_Get
        /// <summary> This operation retrieves a single policy assignment, given its name and the scope it was created at. </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        public virtual Response<PolicyAssignment> Get(string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            if (policyAssignmentName == null)
            {
                throw new ArgumentNullException(nameof(policyAssignmentName));
            }

            using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.Get");
            scope.Start();
            try
            {
                var response = _policyAssignmentsRestClient.Get(Id, policyAssignmentName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PolicyAssignment(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}
        /// ContextualPath: /{scope}
        /// OperationId: PolicyAssignments_Get
        /// <summary> This operation retrieves a single policy assignment, given its name and the scope it was created at. </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        public async virtual Task<Response<PolicyAssignment>> GetAsync(string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            if (policyAssignmentName == null)
            {
                throw new ArgumentNullException(nameof(policyAssignmentName));
            }

            using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.Get");
            scope.Start();
            try
            {
                var response = await _policyAssignmentsRestClient.GetAsync(Id, policyAssignmentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new PolicyAssignment(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        public virtual Response<PolicyAssignment> GetIfExists(string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            if (policyAssignmentName == null)
            {
                throw new ArgumentNullException(nameof(policyAssignmentName));
            }

            using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _policyAssignmentsRestClient.Get(Id, policyAssignmentName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<PolicyAssignment>(null, response.GetRawResponse());
                return Response.FromValue(new PolicyAssignment(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        public async virtual Task<Response<PolicyAssignment>> GetIfExistsAsync(string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            if (policyAssignmentName == null)
            {
                throw new ArgumentNullException(nameof(policyAssignmentName));
            }

            using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _policyAssignmentsRestClient.GetAsync(Id, policyAssignmentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<PolicyAssignment>(null, response.GetRawResponse());
                return Response.FromValue(new PolicyAssignment(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        public virtual Response<bool> Exists(string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            if (policyAssignmentName == null)
            {
                throw new ArgumentNullException(nameof(policyAssignmentName));
            }

            using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(policyAssignmentName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            if (policyAssignmentName == null)
            {
                throw new ArgumentNullException(nameof(policyAssignmentName));
            }

            using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(policyAssignmentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: PolicyAssignments_ListForResourceGroup
        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/policyAssignments
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}
        /// OperationId: PolicyAssignments_ListForResource
        /// RequestPath: /providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyAssignments
        /// ContextualPath: /providers/Microsoft.Management/managementGroups/{managementGroupId}
        /// OperationId: PolicyAssignments_ListForManagementGroup
        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: PolicyAssignments_List
        /// <summary> This operation retrieves the list of all policy assignments associated with the given resource group in the given subscription that match the optional given $filter. Valid values for $filter are: &apos;atScope()&apos;, &apos;atExactScope()&apos; or &apos;policyDefinitionId eq &apos;{value}&apos;&apos;. If $filter is not provided, the unfiltered list includes all policy assignments associated with the resource group, including those that apply directly or apply from containing scopes, as well as any applied to resources contained within the resource group. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the resource group, which is everything in the unfiltered list except those applied to resources contained within the resource group. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the resource group. If $filter=policyDefinitionId eq &apos;{value}&apos; is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the resource group. </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: &apos;atScope()&apos;, &apos;atExactScope()&apos; or &apos;policyDefinitionId eq &apos;{value}&apos;&apos;. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq &apos;{value}&apos; is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyAssignment" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicyAssignment> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (Id.ResourceType == ResourceGroup.ResourceType)
            {
                Page<PolicyAssignment> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = _policyAssignmentsRestClient.ListForResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, filter, top, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                Page<PolicyAssignment> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = _policyAssignmentsRestClient.ListForResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, top, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
            }
            else if (Id.ResourceType == ManagementGroup.ResourceType)
            {
                Page<PolicyAssignment> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = _policyAssignmentsRestClient.ListForManagementGroup(Id.Name, filter, top, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                Page<PolicyAssignment> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = _policyAssignmentsRestClient.ListForManagementGroupNextPage(nextLink, Id.Name, filter, top, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
            }
            else if (Id.ResourceType == Subscription.ResourceType)
            {
                Page<PolicyAssignment> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = _policyAssignmentsRestClient.List(Id.SubscriptionId, filter, top, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                Page<PolicyAssignment> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = _policyAssignmentsRestClient.ListNextPage(nextLink, Id.SubscriptionId, filter, top, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
            }
            else
            {
                Page<PolicyAssignment> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = _policyAssignmentsRestClient.ListForResource(Id.SubscriptionId, Id.ResourceGroupName, Id.ResourceType.Namespace, Id.Parent.SubstringAfterProviderNamespace(), Id.ResourceType.GetLastType(), Id.Name, filter, top, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                Page<PolicyAssignment> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = _policyAssignmentsRestClient.ListForResourceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.ResourceType.Namespace, Id.Parent.SubstringAfterProviderNamespace(), Id.ResourceType.GetLastType(), Id.Name, filter, top, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: PolicyAssignments_ListForResourceGroup
        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/policyAssignments
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}
        /// OperationId: PolicyAssignments_ListForResource
        /// RequestPath: /providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyAssignments
        /// ContextualPath: /providers/Microsoft.Management/managementGroups/{managementGroupId}
        /// OperationId: PolicyAssignments_ListForManagementGroup
        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: PolicyAssignments_List
        /// <summary> This operation retrieves the list of all policy assignments associated with the given resource group in the given subscription that match the optional given $filter. Valid values for $filter are: &apos;atScope()&apos;, &apos;atExactScope()&apos; or &apos;policyDefinitionId eq &apos;{value}&apos;&apos;. If $filter is not provided, the unfiltered list includes all policy assignments associated with the resource group, including those that apply directly or apply from containing scopes, as well as any applied to resources contained within the resource group. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the resource group, which is everything in the unfiltered list except those applied to resources contained within the resource group. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the resource group. If $filter=policyDefinitionId eq &apos;{value}&apos; is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the resource group. </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: &apos;atScope()&apos;, &apos;atExactScope()&apos; or &apos;policyDefinitionId eq &apos;{value}&apos;&apos;. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq &apos;{value}&apos; is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyAssignment" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicyAssignment> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (Id.ResourceType == ResourceGroup.ResourceType)
            {
                async Task<Page<PolicyAssignment>> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = await _policyAssignmentsRestClient.ListForResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                async Task<Page<PolicyAssignment>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = await _policyAssignmentsRestClient.ListForResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
            }
            else if (Id.ResourceType == ManagementGroup.ResourceType)
            {
                async Task<Page<PolicyAssignment>> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = await _policyAssignmentsRestClient.ListForManagementGroupAsync(Id.Name, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                async Task<Page<PolicyAssignment>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = await _policyAssignmentsRestClient.ListForManagementGroupNextPageAsync(nextLink, Id.Name, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
            }
            else if (Id.ResourceType == Subscription.ResourceType)
            {
                async Task<Page<PolicyAssignment>> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = await _policyAssignmentsRestClient.ListAsync(Id.SubscriptionId, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                async Task<Page<PolicyAssignment>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = await _policyAssignmentsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
            }
            else
            {
                async Task<Page<PolicyAssignment>> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = await _policyAssignmentsRestClient.ListForResourceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.ResourceType.Namespace, Id.Parent.SubstringAfterProviderNamespace(), Id.ResourceType.GetLastType(), Id.Name, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                async Task<Page<PolicyAssignment>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("PolicyAssignmentCollection.GetAll");
                    scope.Start();
                    try
                    {
                        var response = await _policyAssignmentsRestClient.ListForResourceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.ResourceType.Namespace, Id.Parent.SubstringAfterProviderNamespace(), Id.ResourceType.GetLastType(), Id.Name, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyAssignment(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
            }
        }

        IEnumerator<PolicyAssignment> IEnumerable<PolicyAssignment>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PolicyAssignment> IAsyncEnumerable<PolicyAssignment>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, PolicyAssignment, PolicyAssignmentData> Construct() { }
    }
}
