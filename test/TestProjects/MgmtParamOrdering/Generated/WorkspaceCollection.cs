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

namespace MgmtParamOrdering
{
    /// <summary> A class representing collection of Workspace and their operations over its parent. </summary>
    public partial class WorkspaceCollection : ArmCollection, IEnumerable<Workspace>, IAsyncEnumerable<Workspace>
    {
        private readonly ClientDiagnostics _workspaceClientDiagnostics;
        private readonly WorkspacesRestOperations _workspaceRestClient;

        /// <summary> Initializes a new instance of the <see cref="WorkspaceCollection"/> class for mocking. </summary>
        protected WorkspaceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="WorkspaceCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal WorkspaceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _workspaceClientDiagnostics = new ClientDiagnostics("MgmtParamOrdering", Workspace.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(Workspace.ResourceType, out string workspaceApiVersion);
            _workspaceRestClient = new WorkspacesRestOperations(_workspaceClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, workspaceApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a workspace with the specified parameters.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}
        /// Operation Id: Workspaces_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="workspaceName"> Name of Azure Machine Learning workspace. </param>
        /// <param name="parameters"> The parameters for creating or updating a machine learning workspace. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<Workspace>> CreateOrUpdateAsync(bool waitForCompletion, string workspaceName, WorkspaceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceName, nameof(workspaceName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _workspaceClientDiagnostics.CreateScope("WorkspaceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(Id.SubscriptionId, "Id.SubscriptionId");
                Argument.AssertNotNullOrEmpty(Id.ResourceGroupName, "Id.ResourceGroupName");
                Argument.AssertNotNullOrEmpty(workspaceName, "workspaceName");
                Argument.AssertNotNull(parameters, "parameters");
                using var message = _workspaceRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, workspaceName, parameters);
                return await ArmOperationHelpers.ProcessMessageAsync(Pipeline, message, _workspaceClientDiagnostics, waitForCompletion, new WorkspaceOperationSource(Client), "WorkspaceCollection.CreateOrUpdate", OperationFinalStateVia.Location, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates a workspace with the specified parameters.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}
        /// Operation Id: Workspaces_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="workspaceName"> Name of Azure Machine Learning workspace. </param>
        /// <param name="parameters"> The parameters for creating or updating a machine learning workspace. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<Workspace> CreateOrUpdate(bool waitForCompletion, string workspaceName, WorkspaceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceName, nameof(workspaceName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _workspaceClientDiagnostics.CreateScope("WorkspaceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(Id.SubscriptionId, "Id.SubscriptionId");
                Argument.AssertNotNullOrEmpty(Id.ResourceGroupName, "Id.ResourceGroupName");
                Argument.AssertNotNullOrEmpty(workspaceName, "workspaceName");
                Argument.AssertNotNull(parameters, "parameters");
                using var message = _workspaceRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, workspaceName, parameters);
                return ArmOperationHelpers.ProcessMessage(Pipeline, message, _workspaceClientDiagnostics, waitForCompletion, new WorkspaceOperationSource(Client), "WorkspaceCollection.CreateOrUpdate", OperationFinalStateVia.Location, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the properties of the specified machine learning workspace.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}
        /// Operation Id: Workspaces_Get
        /// </summary>
        /// <param name="workspaceName"> Name of Azure Machine Learning workspace. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceName"/> is null. </exception>
        public virtual async Task<Response<Workspace>> GetAsync(string workspaceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceName, nameof(workspaceName));

            using var scope = _workspaceClientDiagnostics.CreateScope("WorkspaceCollection.Get");
            scope.Start();
            try
            {
                var response = await _workspaceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, workspaceName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _workspaceClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Workspace(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the properties of the specified machine learning workspace.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}
        /// Operation Id: Workspaces_Get
        /// </summary>
        /// <param name="workspaceName"> Name of Azure Machine Learning workspace. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceName"/> is null. </exception>
        public virtual Response<Workspace> Get(string workspaceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceName, nameof(workspaceName));

            using var scope = _workspaceClientDiagnostics.CreateScope("WorkspaceCollection.Get");
            scope.Start();
            try
            {
                var response = _workspaceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, workspaceName, cancellationToken);
                if (response.Value == null)
                    throw _workspaceClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Workspace(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the properties of the specified machine learning workspace.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces
        /// Operation Id: Workspaces_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Workspace" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Workspace> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Workspace>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _workspaceClientDiagnostics.CreateScope("WorkspaceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _workspaceRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Workspace(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets the properties of the specified machine learning workspace.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces
        /// Operation Id: Workspaces_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Workspace" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Workspace> GetAll(CancellationToken cancellationToken = default)
        {
            Page<Workspace> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _workspaceClientDiagnostics.CreateScope("WorkspaceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _workspaceRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Workspace(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}
        /// Operation Id: Workspaces_Get
        /// </summary>
        /// <param name="workspaceName"> Name of Azure Machine Learning workspace. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string workspaceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceName, nameof(workspaceName));

            using var scope = _workspaceClientDiagnostics.CreateScope("WorkspaceCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(workspaceName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}
        /// Operation Id: Workspaces_Get
        /// </summary>
        /// <param name="workspaceName"> Name of Azure Machine Learning workspace. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceName"/> is null. </exception>
        public virtual Response<bool> Exists(string workspaceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceName, nameof(workspaceName));

            using var scope = _workspaceClientDiagnostics.CreateScope("WorkspaceCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(workspaceName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}
        /// Operation Id: Workspaces_Get
        /// </summary>
        /// <param name="workspaceName"> Name of Azure Machine Learning workspace. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceName"/> is null. </exception>
        public virtual async Task<Response<Workspace>> GetIfExistsAsync(string workspaceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceName, nameof(workspaceName));

            using var scope = _workspaceClientDiagnostics.CreateScope("WorkspaceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _workspaceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, workspaceName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<Workspace>(null, response.GetRawResponse());
                return Response.FromValue(new Workspace(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}
        /// Operation Id: Workspaces_Get
        /// </summary>
        /// <param name="workspaceName"> Name of Azure Machine Learning workspace. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceName"/> is null. </exception>
        public virtual Response<Workspace> GetIfExists(string workspaceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workspaceName, nameof(workspaceName));

            using var scope = _workspaceClientDiagnostics.CreateScope("WorkspaceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _workspaceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, workspaceName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<Workspace>(null, response.GetRawResponse());
                return Response.FromValue(new Workspace(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Workspace> IEnumerable<Workspace>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Workspace> IAsyncEnumerable<Workspace>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
