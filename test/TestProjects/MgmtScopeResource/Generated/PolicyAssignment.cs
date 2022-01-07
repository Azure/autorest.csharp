// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
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
    /// <summary> A Class representing a PolicyAssignment along with the instance operations that can be performed on it. </summary>
    public partial class PolicyAssignment : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="PolicyAssignment"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string scope, string policyAssignmentName)
        {
            var resourceId = $"/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}";
            return new ResourceIdentifier(resourceId);
        }
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly PolicyAssignmentsRestOperations _policyAssignmentsRestClient;
        private readonly PolicyAssignmentData _data;

        /// <summary> Initializes a new instance of the <see cref="PolicyAssignment"/> class for mocking. </summary>
        protected PolicyAssignment()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "PolicyAssignment"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal PolicyAssignment(ArmResource options, PolicyAssignmentData resource) : base(options, resource.Id)
        {
            HasData = true;
            _data = resource;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _policyAssignmentsRestClient = new PolicyAssignmentsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Initializes a new instance of the <see cref="PolicyAssignment"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal PolicyAssignment(ArmResource options, ResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _policyAssignmentsRestClient = new PolicyAssignmentsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Initializes a new instance of the <see cref="PolicyAssignment"/> class. </summary>
        /// <param name="clientOptions"> The client options to build client context. </param>
        /// <param name="credential"> The credential to build client context. </param>
        /// <param name="uri"> The uri to build client context. </param>
        /// <param name="pipeline"> The pipeline to build client context. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal PolicyAssignment(ArmClientOptions clientOptions, TokenCredential credential, Uri uri, HttpPipeline pipeline, ResourceIdentifier id) : base(clientOptions, credential, uri, pipeline, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _policyAssignmentsRestClient = new PolicyAssignmentsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Authorization/policyAssignments";

        /// <summary> Gets the valid resource type for the operations. </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual PolicyAssignmentData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        /// RequestPath: /{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}
        /// ContextualPath: /{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}
        /// OperationId: PolicyAssignments_Get
        /// <summary> This operation retrieves a single policy assignment, given its name and the scope it was created at. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<PolicyAssignment>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolicyAssignment.Get");
            scope.Start();
            try
            {
                var response = await _policyAssignmentsRestClient.GetAsync(Id.Parent, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new PolicyAssignment(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}
        /// ContextualPath: /{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}
        /// OperationId: PolicyAssignments_Get
        /// <summary> This operation retrieves a single policy assignment, given its name and the scope it was created at. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PolicyAssignment> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolicyAssignment.Get");
            scope.Start();
            try
            {
                var response = _policyAssignmentsRestClient.Get(Id.Parent, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PolicyAssignment(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public async virtual Task<IEnumerable<AzureLocation>> GetAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public virtual IEnumerable<AzureLocation> GetAvailableLocations(CancellationToken cancellationToken = default)
        {
            return ListAvailableLocations(ResourceType, cancellationToken);
        }

        /// RequestPath: /{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}
        /// ContextualPath: /{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}
        /// OperationId: PolicyAssignments_Delete
        /// <summary> This operation deletes a policy assignment, given its name and the scope it was created in. The scope of a policy assignment is the part of its ID preceding &apos;/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}&apos;. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<PolicyAssignmentDeleteOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolicyAssignment.Delete");
            scope.Start();
            try
            {
                var response = await _policyAssignmentsRestClient.DeleteAsync(Id.Parent, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new PolicyAssignmentDeleteOperation(response);
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
        /// ContextualPath: /{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}
        /// OperationId: PolicyAssignments_Delete
        /// <summary> This operation deletes a policy assignment, given its name and the scope it was created in. The scope of a policy assignment is the part of its ID preceding &apos;/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}&apos;. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual PolicyAssignmentDeleteOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolicyAssignment.Delete");
            scope.Start();
            try
            {
                var response = _policyAssignmentsRestClient.Delete(Id.Parent, Id.Name, cancellationToken);
                var operation = new PolicyAssignmentDeleteOperation(response);
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
    }
}
