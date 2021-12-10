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
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly DeploymentsRestOperations _deploymentsRestClient;

        /// <summary> Initializes a new instance of the <see cref="DeploymentExtendedCollection"/> class for mocking. </summary>
        protected DeploymentExtendedCollection()
        {
        }

        /// <summary> Initializes a new instance of DeploymentExtendedCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal DeploymentExtendedCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _deploymentsRestClient = new DeploymentsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceIdentifier.Root.ResourceType;

        /// <summary> Verify that the input resource Id is a valid collection for this type. </summary>
        /// <param name="identifier"> The input resource Id to check. </param>
        protected override void ValidateResourceType(ResourceIdentifier identifier)
        {
        }

        // Collection level operations.

        /// RequestPath: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
        /// ContextualPath: /{scope}
        /// OperationId: Deployments_CreateOrUpdateAtScope
        /// <summary> You can provide the template and parameters directly in the request or link to JSON files. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="parameters"> Additional parameters supplied to the operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual DeploymentCreateOrUpdateAtScopeOperation CreateOrUpdate(bool waitForCompletion, string deploymentName, Deployment parameters, CancellationToken cancellationToken = default)
        {
            if (deploymentName == null)
            {
                throw new ArgumentNullException(nameof(deploymentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("DeploymentExtendedCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _deploymentsRestClient.CreateOrUpdateAtScope(Id, deploymentName, parameters, cancellationToken);
                var operation = new DeploymentCreateOrUpdateAtScopeOperation(Parent, _clientDiagnostics, Pipeline, _deploymentsRestClient.CreateCreateOrUpdateAtScopeRequest(Id, deploymentName, parameters).Request, response);
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
        /// OperationId: Deployments_CreateOrUpdateAtScope
        /// <summary> You can provide the template and parameters directly in the request or link to JSON files. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="parameters"> Additional parameters supplied to the operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<DeploymentCreateOrUpdateAtScopeOperation> CreateOrUpdateAsync(bool waitForCompletion, string deploymentName, Deployment parameters, CancellationToken cancellationToken = default)
        {
            if (deploymentName == null)
            {
                throw new ArgumentNullException(nameof(deploymentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("DeploymentExtendedCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _deploymentsRestClient.CreateOrUpdateAtScopeAsync(Id, deploymentName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new DeploymentCreateOrUpdateAtScopeOperation(Parent, _clientDiagnostics, Pipeline, _deploymentsRestClient.CreateCreateOrUpdateAtScopeRequest(Id, deploymentName, parameters).Request, response);
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
        /// OperationId: Deployments_GetAtScope
        /// <summary> Gets a deployment. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public virtual Response<DeploymentExtended> Get(string deploymentName, CancellationToken cancellationToken = default)
        {
            if (deploymentName == null)
            {
                throw new ArgumentNullException(nameof(deploymentName));
            }

            using var scope = _clientDiagnostics.CreateScope("DeploymentExtendedCollection.Get");
            scope.Start();
            try
            {
                var response = _deploymentsRestClient.GetAtScope(Id, deploymentName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeploymentExtended(Parent, response.Value), response.GetRawResponse());
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
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public async virtual Task<Response<DeploymentExtended>> GetAsync(string deploymentName, CancellationToken cancellationToken = default)
        {
            if (deploymentName == null)
            {
                throw new ArgumentNullException(nameof(deploymentName));
            }

            using var scope = _clientDiagnostics.CreateScope("DeploymentExtendedCollection.Get");
            scope.Start();
            try
            {
                var response = await _deploymentsRestClient.GetAtScopeAsync(Id, deploymentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DeploymentExtended(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public virtual Response<DeploymentExtended> GetIfExists(string deploymentName, CancellationToken cancellationToken = default)
        {
            if (deploymentName == null)
            {
                throw new ArgumentNullException(nameof(deploymentName));
            }

            using var scope = _clientDiagnostics.CreateScope("DeploymentExtendedCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _deploymentsRestClient.GetAtScope(Id, deploymentName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<DeploymentExtended>(null, response.GetRawResponse())
                    : Response.FromValue(new DeploymentExtended(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public async virtual Task<Response<DeploymentExtended>> GetIfExistsAsync(string deploymentName, CancellationToken cancellationToken = default)
        {
            if (deploymentName == null)
            {
                throw new ArgumentNullException(nameof(deploymentName));
            }

            using var scope = _clientDiagnostics.CreateScope("DeploymentExtendedCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _deploymentsRestClient.GetAtScopeAsync(Id, deploymentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<DeploymentExtended>(null, response.GetRawResponse())
                    : Response.FromValue(new DeploymentExtended(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public virtual Response<bool> CheckIfExists(string deploymentName, CancellationToken cancellationToken = default)
        {
            if (deploymentName == null)
            {
                throw new ArgumentNullException(nameof(deploymentName));
            }

            using var scope = _clientDiagnostics.CreateScope("DeploymentExtendedCollection.CheckIfExists");
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

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string deploymentName, CancellationToken cancellationToken = default)
        {
            if (deploymentName == null)
            {
                throw new ArgumentNullException(nameof(deploymentName));
            }

            using var scope = _clientDiagnostics.CreateScope("DeploymentExtendedCollection.CheckIfExistsAsync");
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

        /// RequestPath: /{scope}/providers/Microsoft.Resources/deployments/
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
                using var scope = _clientDiagnostics.CreateScope("DeploymentExtendedCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _deploymentsRestClient.ListAtScope(Id, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeploymentExtended(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DeploymentExtended> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DeploymentExtendedCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _deploymentsRestClient.ListAtScopeNextPage(nextLink, Id, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeploymentExtended(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /{scope}/providers/Microsoft.Resources/deployments/
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
                using var scope = _clientDiagnostics.CreateScope("DeploymentExtendedCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _deploymentsRestClient.ListAtScopeAsync(Id, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeploymentExtended(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DeploymentExtended>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DeploymentExtendedCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _deploymentsRestClient.ListAtScopeNextPageAsync(nextLink, Id, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeploymentExtended(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
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

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, DeploymentExtended, DeploymentExtendedData> Construct() { }
    }
}
