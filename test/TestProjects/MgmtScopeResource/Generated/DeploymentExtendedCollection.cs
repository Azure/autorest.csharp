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
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    /// <summary> A class representing collection of DeploymentExtended and their operations over its parent. </summary>
    public partial class DeploymentExtendedCollection : ArmCollection, IEnumerable<DeploymentExtended>, IAsyncEnumerable<DeploymentExtended>
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
            _deploymentExtendedDeploymentsClientDiagnostics = new ClientDiagnostics("MgmtScopeResource", DeploymentExtended.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(DeploymentExtended.ResourceType, out string deploymentExtendedDeploymentsApiVersion);
            _deploymentExtendedDeploymentsRestClient = new DeploymentsRestOperations(_deploymentExtendedDeploymentsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, deploymentExtendedDeploymentsApiVersion);
        }

        /// RequestPath: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
        /// ContextualPath: /{scope}
        /// OperationId: Deployments_CreateOrUpdateAtScope
        /// <summary> You can provide the template and parameters directly in the request or link to JSON files. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="parameters"> Additional parameters supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<DeploymentExtendedCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string deploymentName, Deployment parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _deploymentExtendedDeploymentsRestClient.CreateOrUpdateAtScopeAsync(Id, deploymentName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new DeploymentExtendedCreateOrUpdateOperation(ArmClient, _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateCreateOrUpdateAtScopeRequest(Id, deploymentName, parameters).Request, response);
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

        /// RequestPath: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
        /// ContextualPath: /{scope}
        /// OperationId: Deployments_CreateOrUpdateAtScope
        /// <summary> You can provide the template and parameters directly in the request or link to JSON files. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="parameters"> Additional parameters supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual DeploymentExtendedCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string deploymentName, Deployment parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _deploymentExtendedDeploymentsRestClient.CreateOrUpdateAtScope(Id, deploymentName, parameters, cancellationToken);
                var operation = new DeploymentExtendedCreateOrUpdateOperation(ArmClient, _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateCreateOrUpdateAtScopeRequest(Id, deploymentName, parameters).Request, response);
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

        /// RequestPath: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
        /// ContextualPath: /{scope}
        /// OperationId: Deployments_GetAtScope
        /// <summary> Gets a deployment. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public async virtual Task<Response<DeploymentExtended>> GetAsync(string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.Get");
            scope.Start();
            try
            {
                var response = await _deploymentExtendedDeploymentsRestClient.GetAtScopeAsync(Id, deploymentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _deploymentExtendedDeploymentsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DeploymentExtended(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
        /// ContextualPath: /{scope}
        /// OperationId: Deployments_GetAtScope
        /// <summary> Gets a deployment. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public virtual Response<DeploymentExtended> Get(string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.Get");
            scope.Start();
            try
            {
                var response = _deploymentExtendedDeploymentsRestClient.GetAtScope(Id, deploymentName, cancellationToken);
                if (response.Value == null)
                    throw _deploymentExtendedDeploymentsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeploymentExtended(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{scope}/providers/Microsoft.Resources/deployments
        /// ContextualPath: /{scope}
        /// OperationId: Deployments_ListAtScope
        /// <summary> Get all the deployments at the given scope. </summary>
        /// <param name="filter"> The filter to apply on the operation. For example, you can use $filter=provisioningState eq &apos;{state}&apos;. </param>
        /// <param name="top"> The number of results to get. If null is passed, returns all deployments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeploymentExtended" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DeploymentExtended> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DeploymentExtended>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _deploymentExtendedDeploymentsRestClient.ListAtScopeAsync(Id, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeploymentExtended(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DeploymentExtended>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _deploymentExtendedDeploymentsRestClient.ListAtScopeNextPageAsync(nextLink, Id, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeploymentExtended(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /{scope}/providers/Microsoft.Resources/deployments
        /// ContextualPath: /{scope}
        /// OperationId: Deployments_ListAtScope
        /// <summary> Get all the deployments at the given scope. </summary>
        /// <param name="filter"> The filter to apply on the operation. For example, you can use $filter=provisioningState eq &apos;{state}&apos;. </param>
        /// <param name="top"> The number of results to get. If null is passed, returns all deployments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeploymentExtended" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DeploymentExtended> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<DeploymentExtended> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _deploymentExtendedDeploymentsRestClient.ListAtScope(Id, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeploymentExtended(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DeploymentExtended> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _deploymentExtendedDeploymentsRestClient.ListAtScopeNextPage(nextLink, Id, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeploymentExtended(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
        /// ContextualPath: /{scope}
        /// OperationId: Deployments_GetAtScope
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(deploymentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
        /// ContextualPath: /{scope}
        /// OperationId: Deployments_GetAtScope
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public virtual Response<bool> Exists(string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(deploymentName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
        /// ContextualPath: /{scope}
        /// OperationId: Deployments_GetAtScope
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public async virtual Task<Response<DeploymentExtended>> GetIfExistsAsync(string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _deploymentExtendedDeploymentsRestClient.GetAtScopeAsync(Id, deploymentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<DeploymentExtended>(null, response.GetRawResponse());
                return Response.FromValue(new DeploymentExtended(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
        /// ContextualPath: /{scope}
        /// OperationId: Deployments_GetAtScope
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public virtual Response<DeploymentExtended> GetIfExists(string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _deploymentExtendedDeploymentsRestClient.GetAtScope(Id, deploymentName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<DeploymentExtended>(null, response.GetRawResponse());
                return Response.FromValue(new DeploymentExtended(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DeploymentExtended> IEnumerable<DeploymentExtended>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DeploymentExtended> IAsyncEnumerable<DeploymentExtended>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
