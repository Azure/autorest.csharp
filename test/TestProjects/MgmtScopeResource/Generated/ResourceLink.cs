// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace MgmtScopeResource
{
    /// <summary> A Class representing a ResourceLink along with the instance operations that can be performed on it. </summary>
    public partial class ResourceLink : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ResourceLink"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string linkId)
        {
            var resourceId = $"{linkId}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _resourceLinkClientDiagnostics;
        private readonly ResourceLinksRestOperations _resourceLinkRestClient;
        private readonly ResourceLinkData _data;

        /// <summary> Initializes a new instance of the <see cref="ResourceLink"/> class for mocking. </summary>
        protected ResourceLink()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ResourceLink"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ResourceLink(ArmClient client, ResourceLinkData data) : this(client, new ResourceIdentifier(data.Id))
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceLink"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceLink(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _resourceLinkClientDiagnostics = new ClientDiagnostics("MgmtScopeResource", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string resourceLinkApiVersion);
            _resourceLinkRestClient = new ResourceLinksRestOperations(_resourceLinkClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, resourceLinkApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/links";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ResourceLinkData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// RequestPath: /{linkId}
        /// ContextualPath: /{linkId}
        /// OperationId: ResourceLinks_Get
        /// <summary> Gets a resource link with the specified ID. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ResourceLink>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _resourceLinkClientDiagnostics.CreateScope("ResourceLink.Get");
            scope.Start();
            try
            {
                var response = await _resourceLinkRestClient.GetAsync(Id, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _resourceLinkClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ResourceLink(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{linkId}
        /// ContextualPath: /{linkId}
        /// OperationId: ResourceLinks_Get
        /// <summary> Gets a resource link with the specified ID. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ResourceLink> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _resourceLinkClientDiagnostics.CreateScope("ResourceLink.Get");
            scope.Start();
            try
            {
                var response = _resourceLinkRestClient.Get(Id, cancellationToken);
                if (response.Value == null)
                    throw _resourceLinkClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResourceLink(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{linkId}
        /// ContextualPath: /{linkId}
        /// OperationId: ResourceLinks_Delete
        /// <summary> Deletes a resource link with the specified ID. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _resourceLinkClientDiagnostics.CreateScope("ResourceLink.Delete");
            scope.Start();
            try
            {
                var response = await _resourceLinkRestClient.DeleteAsync(Id, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtScopeResourceArmOperation(response);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{linkId}
        /// ContextualPath: /{linkId}
        /// OperationId: ResourceLinks_Delete
        /// <summary> Deletes a resource link with the specified ID. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _resourceLinkClientDiagnostics.CreateScope("ResourceLink.Delete");
            scope.Start();
            try
            {
                var response = _resourceLinkRestClient.Delete(Id, cancellationToken);
                var operation = new MgmtScopeResourceArmOperation(response);
                if (waitForCompletion)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
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
            using var scope = _resourceLinkClientDiagnostics.CreateScope("ResourceLink.GetAvailableLocations");
            scope.Start();
            try
            {
                return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
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
        public virtual IEnumerable<AzureLocation> GetAvailableLocations(CancellationToken cancellationToken = default)
        {
            using var scope = _resourceLinkClientDiagnostics.CreateScope("ResourceLink.GetAvailableLocations");
            scope.Start();
            try
            {
                return ListAvailableLocations(ResourceType, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
