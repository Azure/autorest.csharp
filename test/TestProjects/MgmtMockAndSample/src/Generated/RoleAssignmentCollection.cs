// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
using Azure.ResourceManager.Resources;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    /// <summary>
    /// A class representing a collection of <see cref="RoleAssignmentResource" /> and their operations.
    /// Each <see cref="RoleAssignmentResource" /> in the collection will belong to the same instance of <see cref="ArmResource" />.
    /// To get a <see cref="RoleAssignmentCollection" /> instance call the GetRoleAssignments method from an instance of <see cref="ArmResource" />.
    /// </summary>
    public partial class RoleAssignmentCollection : ArmCollection, IEnumerable<RoleAssignmentResource>, IAsyncEnumerable<RoleAssignmentResource>
    {
        private readonly ClientDiagnostics _roleAssignmentClientDiagnostics;
        private readonly RoleAssignmentsRestOperations _roleAssignmentRestClient;

        /// <summary> Initializes a new instance of the <see cref="RoleAssignmentCollection"/> class for mocking. </summary>
        protected RoleAssignmentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="RoleAssignmentCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal RoleAssignmentCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _roleAssignmentClientDiagnostics = new ClientDiagnostics("MgmtMockAndSample", RoleAssignmentResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(RoleAssignmentResource.ResourceType, out string roleAssignmentApiVersion);
            _roleAssignmentRestClient = new RoleAssignmentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, roleAssignmentApiVersion);
        }

        /// <summary>
        /// Creates a role assignment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="roleAssignmentName"> A GUID for the role assignment to create. The name must be unique and different for each role assignment. </param>
        /// <param name="content"> Parameters for the role assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="roleAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentName"/> or <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation<RoleAssignmentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string roleAssignmentName, RoleAssignmentCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(roleAssignmentName, nameof(roleAssignmentName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _roleAssignmentClientDiagnostics.CreateScope("RoleAssignmentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _roleAssignmentRestClient.CreateAsync(Id, roleAssignmentName, content, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtMockAndSampleArmOperation<RoleAssignmentResource>(Response.FromValue(new RoleAssignmentResource(Client, response), response.GetRawResponse()));
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
        /// Creates a role assignment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="roleAssignmentName"> A GUID for the role assignment to create. The name must be unique and different for each role assignment. </param>
        /// <param name="content"> Parameters for the role assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="roleAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentName"/> or <paramref name="content"/> is null. </exception>
        public virtual ArmOperation<RoleAssignmentResource> CreateOrUpdate(WaitUntil waitUntil, string roleAssignmentName, RoleAssignmentCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(roleAssignmentName, nameof(roleAssignmentName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _roleAssignmentClientDiagnostics.CreateScope("RoleAssignmentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _roleAssignmentRestClient.Create(Id, roleAssignmentName, content, cancellationToken);
                var operation = new MgmtMockAndSampleArmOperation<RoleAssignmentResource>(Response.FromValue(new RoleAssignmentResource(Client, response), response.GetRawResponse()));
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
        /// Get the specified role assignment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="roleAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentName"/> is null. </exception>
        public virtual async Task<Response<RoleAssignmentResource>> GetAsync(string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(roleAssignmentName, nameof(roleAssignmentName));

            using var scope = _roleAssignmentClientDiagnostics.CreateScope("RoleAssignmentCollection.Get");
            scope.Start();
            try
            {
                var response = await _roleAssignmentRestClient.GetAsync(Id, roleAssignmentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RoleAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the specified role assignment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="roleAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentName"/> is null. </exception>
        public virtual Response<RoleAssignmentResource> Get(string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(roleAssignmentName, nameof(roleAssignmentName));

            using var scope = _roleAssignmentClientDiagnostics.CreateScope("RoleAssignmentCollection.Get");
            scope.Start();
            try
            {
                var response = _roleAssignmentRestClient.Get(Id, roleAssignmentName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RoleAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets role assignments for a resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/roleAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_ListForResource</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Authorization/roleAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_ListForResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/roleAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_List</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_ListForScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Use $filter=atScope() to return all role assignments at or above the scope. Use $filter=principalId eq {id} to return all role assignments at, above or below the scope for the specified principal. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="RoleAssignmentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RoleAssignmentResource> GetAllAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            if (Id.ResourceType == ResourceGroupResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _roleAssignmentRestClient.CreateListForResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName, filter);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _roleAssignmentRestClient.CreateListForResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter);
                return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new RoleAssignmentResource(Client, RoleAssignmentData.DeserializeRoleAssignmentData(e)), _roleAssignmentClientDiagnostics, Pipeline, "RoleAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
            else if (Id.ResourceType == SubscriptionResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _roleAssignmentRestClient.CreateListRequest(Id.SubscriptionId, filter);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _roleAssignmentRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, filter);
                return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new RoleAssignmentResource(Client, RoleAssignmentData.DeserializeRoleAssignmentData(e)), _roleAssignmentClientDiagnostics, Pipeline, "RoleAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
            else if (Id.ResourceType == "")
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _roleAssignmentRestClient.CreateListForScopeRequest(Id, filter);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _roleAssignmentRestClient.CreateListForScopeNextPageRequest(nextLink, Id, filter);
                return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new RoleAssignmentResource(Client, RoleAssignmentData.DeserializeRoleAssignmentData(e)), _roleAssignmentClientDiagnostics, Pipeline, "RoleAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
            else
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _roleAssignmentRestClient.CreateListForResourceRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.ResourceType.Namespace, Id.Parent.SubstringAfterProviderNamespace(), new ResourceType(Id.ResourceType.GetLastType()), Id.Name, filter);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _roleAssignmentRestClient.CreateListForResourceNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.ResourceType.Namespace, Id.Parent.SubstringAfterProviderNamespace(), new ResourceType(Id.ResourceType.GetLastType()), Id.Name, filter);
                return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new RoleAssignmentResource(Client, RoleAssignmentData.DeserializeRoleAssignmentData(e)), _roleAssignmentClientDiagnostics, Pipeline, "RoleAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
        }

        /// <summary>
        /// Gets role assignments for a resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/roleAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_ListForResource</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Authorization/roleAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_ListForResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/roleAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_List</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_ListForScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Use $filter=atScope() to return all role assignments at or above the scope. Use $filter=principalId eq {id} to return all role assignments at, above or below the scope for the specified principal. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RoleAssignmentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RoleAssignmentResource> GetAll(string filter = null, CancellationToken cancellationToken = default)
        {
            if (Id.ResourceType == ResourceGroupResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _roleAssignmentRestClient.CreateListForResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName, filter);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _roleAssignmentRestClient.CreateListForResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter);
                return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new RoleAssignmentResource(Client, RoleAssignmentData.DeserializeRoleAssignmentData(e)), _roleAssignmentClientDiagnostics, Pipeline, "RoleAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
            else if (Id.ResourceType == SubscriptionResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _roleAssignmentRestClient.CreateListRequest(Id.SubscriptionId, filter);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _roleAssignmentRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, filter);
                return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new RoleAssignmentResource(Client, RoleAssignmentData.DeserializeRoleAssignmentData(e)), _roleAssignmentClientDiagnostics, Pipeline, "RoleAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
            else if (Id.ResourceType == "")
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _roleAssignmentRestClient.CreateListForScopeRequest(Id, filter);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _roleAssignmentRestClient.CreateListForScopeNextPageRequest(nextLink, Id, filter);
                return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new RoleAssignmentResource(Client, RoleAssignmentData.DeserializeRoleAssignmentData(e)), _roleAssignmentClientDiagnostics, Pipeline, "RoleAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
            else
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => _roleAssignmentRestClient.CreateListForResourceRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.ResourceType.Namespace, Id.Parent.SubstringAfterProviderNamespace(), new ResourceType(Id.ResourceType.GetLastType()), Id.Name, filter);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _roleAssignmentRestClient.CreateListForResourceNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.ResourceType.Namespace, Id.Parent.SubstringAfterProviderNamespace(), new ResourceType(Id.ResourceType.GetLastType()), Id.Name, filter);
                return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new RoleAssignmentResource(Client, RoleAssignmentData.DeserializeRoleAssignmentData(e)), _roleAssignmentClientDiagnostics, Pipeline, "RoleAssignmentCollection.GetAll", "value", "nextLink", cancellationToken);
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="roleAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(roleAssignmentName, nameof(roleAssignmentName));

            using var scope = _roleAssignmentClientDiagnostics.CreateScope("RoleAssignmentCollection.Exists");
            scope.Start();
            try
            {
                var response = await _roleAssignmentRestClient.GetAsync(Id, roleAssignmentName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="roleAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentName"/> is null. </exception>
        public virtual Response<bool> Exists(string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(roleAssignmentName, nameof(roleAssignmentName));

            using var scope = _roleAssignmentClientDiagnostics.CreateScope("RoleAssignmentCollection.Exists");
            scope.Start();
            try
            {
                var response = _roleAssignmentRestClient.Get(Id, roleAssignmentName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<RoleAssignmentResource> IEnumerable<RoleAssignmentResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<RoleAssignmentResource> IAsyncEnumerable<RoleAssignmentResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
