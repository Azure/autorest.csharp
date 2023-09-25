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
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;

namespace MgmtScopeResource
{
    /// <summary>
    /// A class representing a collection of <see cref="FakePolicyAssignmentResource" /> and their operations.
    /// Each <see cref="FakePolicyAssignmentResource" /> in the collection will belong to the same instance of <see cref="ArmResource" />.
    /// To get a <see cref="FakePolicyAssignmentCollection" /> instance call the GetFakePolicyAssignments method from an instance of <see cref="ArmResource" />.
    /// </summary>
    public partial class FakePolicyAssignmentCollection : ArmCollection, IEnumerable<FakePolicyAssignmentResource>, IAsyncEnumerable<FakePolicyAssignmentResource>
    {
        private readonly ClientDiagnostics _fakePolicyAssignmentClientDiagnostics;
        private readonly FakePolicyAssignmentsRestOperations _fakePolicyAssignmentRestClient;

        /// <summary> Initializes a new instance of the <see cref="FakePolicyAssignmentCollection"/> class for mocking. </summary>
        protected FakePolicyAssignmentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FakePolicyAssignmentCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FakePolicyAssignmentCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fakePolicyAssignmentClientDiagnostics = new ClientDiagnostics("MgmtScopeResource", FakePolicyAssignmentResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(FakePolicyAssignmentResource.ResourceType, out string fakePolicyAssignmentApiVersion);
            _fakePolicyAssignmentRestClient = new FakePolicyAssignmentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, fakePolicyAssignmentApiVersion);
        }

        /// <summary>
        ///  This operation creates or updates a policy assignment with the given scope and name. Policy assignments apply to all resources contained within their scope. For example, when you assign a policy at resource group scope, that policy applies to all resources in the group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="policyAssignmentName"> The name of the policy assignment. </param>
        /// <param name="data"> Parameters for the policy assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<FakePolicyAssignmentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string policyAssignmentName, FakePolicyAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyAssignmentName, nameof(policyAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fakePolicyAssignmentClientDiagnostics.CreateScope("FakePolicyAssignmentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fakePolicyAssignmentRestClient.CreateAsync(Id, policyAssignmentName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtScopeResourceArmOperation<FakePolicyAssignmentResource>(Response.FromValue(new FakePolicyAssignmentResource(Client, response), response.GetRawResponse()));
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
        ///  This operation creates or updates a policy assignment with the given scope and name. Policy assignments apply to all resources contained within their scope. For example, when you assign a policy at resource group scope, that policy applies to all resources in the group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="policyAssignmentName"> The name of the policy assignment. </param>
        /// <param name="data"> Parameters for the policy assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<FakePolicyAssignmentResource> CreateOrUpdate(WaitUntil waitUntil, string policyAssignmentName, FakePolicyAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyAssignmentName, nameof(policyAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fakePolicyAssignmentClientDiagnostics.CreateScope("FakePolicyAssignmentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fakePolicyAssignmentRestClient.Create(Id, policyAssignmentName, data, cancellationToken);
                var operation = new MgmtScopeResourceArmOperation<FakePolicyAssignmentResource>(Response.FromValue(new FakePolicyAssignmentResource(Client, response), response.GetRawResponse()));
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
        /// This operation retrieves a single policy assignment, given its name and the scope it was created at.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        public virtual async Task<Response<FakePolicyAssignmentResource>> GetAsync(string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyAssignmentName, nameof(policyAssignmentName));

            using var scope = _fakePolicyAssignmentClientDiagnostics.CreateScope("FakePolicyAssignmentCollection.Get");
            scope.Start();
            try
            {
                var response = await _fakePolicyAssignmentRestClient.GetAsync(Id, policyAssignmentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakePolicyAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation retrieves a single policy assignment, given its name and the scope it was created at.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        public virtual Response<FakePolicyAssignmentResource> Get(string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyAssignmentName, nameof(policyAssignmentName));

            using var scope = _fakePolicyAssignmentClientDiagnostics.CreateScope("FakePolicyAssignmentCollection.Get");
            scope.Start();
            try
            {
                var response = _fakePolicyAssignmentRestClient.Get(Id, policyAssignmentName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakePolicyAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation retrieves the list of all policy assignments associated with the given resource group in the given subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the resource group, including those that apply directly or apply from containing scopes, as well as any applied to resources contained within the resource group. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the resource group, which is everything in the unfiltered list except those applied to resources contained within the resource group. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the resource group. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_ListForResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_ListForResource</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_ListForManagementGroup</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakePolicyAssignmentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakePolicyAssignmentResource> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (Id.ResourceType == ResourceGroupResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _fakePolicyAssignmentRestClient.CreateListForResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakePolicyAssignmentRestClient.CreateListForResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, top);
                return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FakePolicyAssignmentResource(Client, FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(e)), _fakePolicyAssignmentClientDiagnostics, Pipeline, "FakePolicyAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
            else if (Id.ResourceType == ManagementGroupResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _fakePolicyAssignmentRestClient.CreateListForManagementGroupRequest(Id.Name, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakePolicyAssignmentRestClient.CreateListForManagementGroupNextPageRequest(nextLink, Id.Name, filter, top);
                return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FakePolicyAssignmentResource(Client, FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(e)), _fakePolicyAssignmentClientDiagnostics, Pipeline, "FakePolicyAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
            else if (Id.ResourceType == SubscriptionResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _fakePolicyAssignmentRestClient.CreateListRequest(Id.SubscriptionId, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakePolicyAssignmentRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, filter, top);
                return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FakePolicyAssignmentResource(Client, FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(e)), _fakePolicyAssignmentClientDiagnostics, Pipeline, "FakePolicyAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
            else
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _fakePolicyAssignmentRestClient.CreateListForResourceRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.ResourceType.Namespace, Id.Parent.SubstringAfterProviderNamespace(), Id.ResourceType.GetLastType(), Id.Name, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakePolicyAssignmentRestClient.CreateListForResourceNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.ResourceType.Namespace, Id.Parent.SubstringAfterProviderNamespace(), Id.ResourceType.GetLastType(), Id.Name, filter, top);
                return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FakePolicyAssignmentResource(Client, FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(e)), _fakePolicyAssignmentClientDiagnostics, Pipeline, "FakePolicyAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
        }

        /// <summary>
        /// This operation retrieves the list of all policy assignments associated with the given resource group in the given subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the resource group, including those that apply directly or apply from containing scopes, as well as any applied to resources contained within the resource group. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the resource group, which is everything in the unfiltered list except those applied to resources contained within the resource group. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the resource group. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_ListForResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_ListForResource</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_ListForManagementGroup</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakePolicyAssignmentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakePolicyAssignmentResource> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (Id.ResourceType == ResourceGroupResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _fakePolicyAssignmentRestClient.CreateListForResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakePolicyAssignmentRestClient.CreateListForResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, top);
                return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FakePolicyAssignmentResource(Client, FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(e)), _fakePolicyAssignmentClientDiagnostics, Pipeline, "FakePolicyAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
            else if (Id.ResourceType == ManagementGroupResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _fakePolicyAssignmentRestClient.CreateListForManagementGroupRequest(Id.Name, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakePolicyAssignmentRestClient.CreateListForManagementGroupNextPageRequest(nextLink, Id.Name, filter, top);
                return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FakePolicyAssignmentResource(Client, FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(e)), _fakePolicyAssignmentClientDiagnostics, Pipeline, "FakePolicyAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
            else if (Id.ResourceType == SubscriptionResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _fakePolicyAssignmentRestClient.CreateListRequest(Id.SubscriptionId, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakePolicyAssignmentRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, filter, top);
                return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FakePolicyAssignmentResource(Client, FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(e)), _fakePolicyAssignmentClientDiagnostics, Pipeline, "FakePolicyAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
            else
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _fakePolicyAssignmentRestClient.CreateListForResourceRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.ResourceType.Namespace, Id.Parent.SubstringAfterProviderNamespace(), Id.ResourceType.GetLastType(), Id.Name, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakePolicyAssignmentRestClient.CreateListForResourceNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.ResourceType.Namespace, Id.Parent.SubstringAfterProviderNamespace(), Id.ResourceType.GetLastType(), Id.Name, filter, top);
                return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FakePolicyAssignmentResource(Client, FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(e)), _fakePolicyAssignmentClientDiagnostics, Pipeline, "FakePolicyAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyAssignmentName, nameof(policyAssignmentName));

            using var scope = _fakePolicyAssignmentClientDiagnostics.CreateScope("FakePolicyAssignmentCollection.Exists");
            scope.Start();
            try
            {
                var response = await _fakePolicyAssignmentRestClient.GetAsync(Id, policyAssignmentName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        public virtual Response<bool> Exists(string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyAssignmentName, nameof(policyAssignmentName));

            using var scope = _fakePolicyAssignmentClientDiagnostics.CreateScope("FakePolicyAssignmentCollection.Exists");
            scope.Start();
            try
            {
                var response = _fakePolicyAssignmentRestClient.Get(Id, policyAssignmentName, cancellationToken: cancellationToken);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        public virtual async Task<NullableResponse<FakePolicyAssignmentResource>> GetIfExistsAsync(string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyAssignmentName, nameof(policyAssignmentName));

            using var scope = _fakePolicyAssignmentClientDiagnostics.CreateScope("FakePolicyAssignmentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _fakePolicyAssignmentRestClient.GetAsync(Id, policyAssignmentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<FakePolicyAssignmentResource>(response.GetRawResponse());
                return Response.FromValue(new FakePolicyAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        public virtual NullableResponse<FakePolicyAssignmentResource> GetIfExists(string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyAssignmentName, nameof(policyAssignmentName));

            using var scope = _fakePolicyAssignmentClientDiagnostics.CreateScope("FakePolicyAssignmentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _fakePolicyAssignmentRestClient.Get(Id, policyAssignmentName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<FakePolicyAssignmentResource>(response.GetRawResponse());
                return Response.FromValue(new FakePolicyAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<FakePolicyAssignmentResource> IEnumerable<FakePolicyAssignmentResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FakePolicyAssignmentResource> IAsyncEnumerable<FakePolicyAssignmentResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
