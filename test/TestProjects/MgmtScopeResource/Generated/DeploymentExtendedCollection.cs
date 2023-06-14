// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    /// <summary>
    /// A class representing a collection of <see cref="DeploymentExtendedResource" /> and their operations.
    /// Each <see cref="DeploymentExtendedResource" /> in the collection will belong to the same instance of <see cref="SubscriptionResource" />, <see cref="ResourceGroupResource" />, <see cref="ManagementGroupResource" /> or <see cref="TenantResource" />.
    /// To get a <see cref="DeploymentExtendedCollection" /> instance call the GetDeploymentExtendeds method from an instance of <see cref="SubscriptionResource" />, <see cref="ResourceGroupResource" />, <see cref="ManagementGroupResource" /> or <see cref="TenantResource" />.
    /// </summary>
    public partial class DeploymentExtendedCollection : ArmCollection, IEnumerable<DeploymentExtendedResource>, IAsyncEnumerable<DeploymentExtendedResource>
    {
        private readonly ClientDiagnostics _deploymentExtendedDeploymentsClientDiagnostics;
        private readonly DeploymentsRestOperations _deploymentExtendedDeploymentsRestClient;

        /// <summary> Initializes a new instance of the <see cref="DeploymentExtendedCollection"/> class for mocking. </summary>
        protected DeploymentExtendedCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DeploymentExtendedCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DeploymentExtendedCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _deploymentExtendedDeploymentsClientDiagnostics = new ClientDiagnostics("MgmtScopeResource", DeploymentExtendedResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(DeploymentExtendedResource.ResourceType, out string deploymentExtendedDeploymentsApiVersion);
            _deploymentExtendedDeploymentsRestClient = new DeploymentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, deploymentExtendedDeploymentsApiVersion);
        }

        /// <summary>
        /// You can provide the template and parameters directly in the request or link to JSON files.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_CreateOrUpdateAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="deployment"> Additional parameters supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> or <paramref name="deployment"/> is null. </exception>
        public virtual async Task<ArmOperation<DeploymentExtendedResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string deploymentName, Deployment deployment, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(deployment, nameof(deployment));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _deploymentExtendedDeploymentsRestClient.CreateOrUpdateAtScopeAsync(Id, deploymentName, deployment, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtScopeResourceArmOperation<DeploymentExtendedResource>(new DeploymentExtendedOperationSource(Client), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateCreateOrUpdateAtScopeRequest(Id, deploymentName, deployment).Request, response, OperationFinalStateVia.Location);
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
        /// You can provide the template and parameters directly in the request or link to JSON files.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_CreateOrUpdateAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="deployment"> Additional parameters supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> or <paramref name="deployment"/> is null. </exception>
        public virtual ArmOperation<DeploymentExtendedResource> CreateOrUpdate(WaitUntil waitUntil, string deploymentName, Deployment deployment, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(deployment, nameof(deployment));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _deploymentExtendedDeploymentsRestClient.CreateOrUpdateAtScope(Id, deploymentName, deployment, cancellationToken);
                var operation = new MgmtScopeResourceArmOperation<DeploymentExtendedResource>(new DeploymentExtendedOperationSource(Client), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateCreateOrUpdateAtScopeRequest(Id, deploymentName, deployment).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public virtual async Task<Response<DeploymentExtendedResource>> GetAsync(string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.Get");
            scope.Start();
            try
            {
                var response = await _deploymentExtendedDeploymentsRestClient.GetAtScopeAsync(Id, deploymentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeploymentExtendedResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public virtual Response<DeploymentExtendedResource> Get(string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.Get");
            scope.Start();
            try
            {
                var response = _deploymentExtendedDeploymentsRestClient.GetAtScope(Id, deploymentName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeploymentExtendedResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get all the deployments at the given scope.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_ListAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. For example, you can use $filter=provisioningState eq '{state}'. </param>
        /// <param name="top"> The number of results to get. If null is passed, returns all deployments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeploymentExtendedResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DeploymentExtendedResource> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Azure.Core.HttpMessage FirstPageRequest(int? pageSizeHint) => _deploymentExtendedDeploymentsRestClient.CreateListAtScopeRequest(Id, filter, top);
            Azure.Core.HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _deploymentExtendedDeploymentsRestClient.CreateListAtScopeNextPageRequest(nextLink, Id, filter, top);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new DeploymentExtendedResource(Client, DeploymentExtendedData.DeserializeDeploymentExtendedData(e)), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, "DeploymentExtendedCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Get all the deployments at the given scope.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_ListAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. For example, you can use $filter=provisioningState eq '{state}'. </param>
        /// <param name="top"> The number of results to get. If null is passed, returns all deployments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeploymentExtendedResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DeploymentExtendedResource> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Azure.Core.HttpMessage FirstPageRequest(int? pageSizeHint) => _deploymentExtendedDeploymentsRestClient.CreateListAtScopeRequest(Id, filter, top);
            Azure.Core.HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _deploymentExtendedDeploymentsRestClient.CreateListAtScopeNextPageRequest(nextLink, Id, filter, top);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new DeploymentExtendedResource(Client, DeploymentExtendedData.DeserializeDeploymentExtendedData(e)), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, "DeploymentExtendedCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.Exists");
            scope.Start();
            try
            {
                var response = await _deploymentExtendedDeploymentsRestClient.GetAtScopeAsync(Id, deploymentName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public virtual Response<bool> Exists(string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.Exists");
            scope.Start();
            try
            {
                var response = _deploymentExtendedDeploymentsRestClient.GetAtScope(Id, deploymentName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DeploymentExtendedResource> IEnumerable<DeploymentExtendedResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DeploymentExtendedResource> IAsyncEnumerable<DeploymentExtendedResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
