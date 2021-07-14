// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace MgmtSingleton
{
    /// <summary> A class representing collection of ParentResource and their operations over a ResourceGroup. </summary>
    public partial class ParentResourceContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, ParentResource, ParentResourceData>
    {
        /// <summary> Initializes a new instance of the <see cref="ParentResourceContainer"/> class for mocking. </summary>
        protected ParentResourceContainer()
        {
        }

        /// <summary> Initializes a new instance of ParentResourceContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ParentResourceContainer(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        /// <summary> Get the parent resource of this container. </summary>
        protected new ResourceOperationsBase Parent { get { return base.Parent as ResourceOperationsBase; } }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private ParentResourcesRestOperations _restClient => new ParentResourcesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update a ParentResource. Please note some properties can be set only during creation. </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="parameters"> The ParentResource to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ParentResource> CreateOrUpdate(string parentName, ParentResourceData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (parentName == null)
                {
                    throw new ArgumentNullException(nameof(parentName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(parentName, parameters, cancellationToken: cancellationToken).WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ParentResource. Please note some properties can be set only during creation. </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="parameters"> The ParentResource to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ParentResource>> CreateOrUpdateAsync(string parentName, ParentResourceData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (parentName == null)
                {
                    throw new ArgumentNullException(nameof(parentName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(parentName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ParentResource. Please note some properties can be set only during creation. </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="parameters"> The ParentResource to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual ParentResourcesCreateOrUpdateOperation StartCreateOrUpdate(string parentName, ParentResourceData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (parentName == null)
                {
                    throw new ArgumentNullException(nameof(parentName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.CreateOrUpdate(Id.ResourceGroupName, parentName, parameters, cancellationToken: cancellationToken);
                return new ParentResourcesCreateOrUpdateOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ParentResource. Please note some properties can be set only during creation. </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="parameters"> The ParentResource to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<ParentResourcesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string parentName, ParentResourceData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (parentName == null)
                {
                    throw new ArgumentNullException(nameof(parentName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, parentName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new ParentResourcesCreateOrUpdateOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ParentResource> Get(string parentName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.Get");
            scope.Start();
            try
            {
                if (parentName == null)
                {
                    throw new ArgumentNullException(nameof(parentName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, parentName, cancellationToken: cancellationToken);
                return Response.FromValue(new ParentResource(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ParentResource>> GetAsync(string parentName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.Get");
            scope.Start();
            try
            {
                if (parentName == null)
                {
                    throw new ArgumentNullException(nameof(parentName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, parentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ParentResource(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual ParentResource TryGet(string parentName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.TryGet");
            scope.Start();
            try
            {
                if (parentName == null)
                {
                    throw new ArgumentNullException(nameof(parentName));
                }

                return Get(parentName, cancellationToken: cancellationToken).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<ParentResource> TryGetAsync(string parentName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.TryGet");
            scope.Start();
            try
            {
                if (parentName == null)
                {
                    throw new ArgumentNullException(nameof(parentName));
                }

                return await GetAsync(parentName, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string parentName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.DoesExist");
            scope.Start();
            try
            {
                if (parentName == null)
                {
                    throw new ArgumentNullException(nameof(parentName));
                }

                return TryGet(parentName, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string parentName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.DoesExist");
            scope.Start();
            try
            {
                if (parentName == null)
                {
                    throw new ArgumentNullException(nameof(parentName));
                }

                return await TryGetAsync(parentName, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ParentResource for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ParentResourceOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ParentResource for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ParentResourceOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Singleton Test Parent Example. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<ParentResource>>> ListAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.List");
            scope.Start();
            try
            {
                var response = await _restClient.ListAsync(Id.ResourceGroupName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value.Select(data => new ParentResource(Parent, data)).ToArray() as IReadOnlyList<ParentResource>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Singleton Test Parent Example. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<ParentResource>> List(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.List");
            scope.Start();
            try
            {
                var response = _restClient.List(Id.ResourceGroupName, cancellationToken);
                return Response.FromValue(response.Value.Value.Select(data => new ParentResource(Parent, data)).ToArray() as IReadOnlyList<ParentResource>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceGroupResourceIdentifier, ParentResource, ParentResourceData> Construct() { }
    }
}
