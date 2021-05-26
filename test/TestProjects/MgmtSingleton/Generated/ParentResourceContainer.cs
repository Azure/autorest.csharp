// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

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
        internal ParentResourceContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private ParentResourcesRestOperations _restClient => new ParentResourcesRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update a ParentResource. Please note some properties can be set only during creation. </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="parameters"> The ParentResource to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public Response<ParentResource> CreateOrUpdate(string parentName, ParentResourceData parameters, CancellationToken cancellationToken = default)
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
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<Response<ParentResource>> CreateOrUpdateAsync(string parentName, ParentResourceData parameters, CancellationToken cancellationToken = default)
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
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ParentResourcesCreateOrUpdateOperation StartCreateOrUpdate(string parentName, ParentResourceData parameters, CancellationToken cancellationToken = default)
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
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ParentResourcesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string parentName, ParentResourceData parameters, CancellationToken cancellationToken = default)
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

        /// <inheritdoc />
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override Response<ParentResource> Get(string parentName, CancellationToken cancellationToken = default)
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

        /// <inheritdoc />
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<Response<ParentResource>> GetAsync(string parentName, CancellationToken cancellationToken = default)
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

        /// <summary> Filters the list of <see cref="ParentResource" /> for this resource group. </summary>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="ParentResource" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<ParentResource> List(int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(null, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, ParentResource>(results, genericResource => new ParentResourceOperations(genericResource, genericResource.Id as ResourceGroupResourceIdentifier).Get().Value);
        }

        /// <summary> Filters the list of <see cref="ParentResource" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="ParentResource" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<ParentResource> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(null, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, ParentResource>(results, genericResource => new ParentResourceOperations(genericResource, genericResource.Id as ResourceGroupResourceIdentifier).Get().Value);
        }

        /// <summary> Filters the list of <see cref="ParentResource" /> for this resource group. </summary>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="ParentResource" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ParentResource> ListAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(null, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, ParentResource>(results, genericResource => new ParentResourceOperations(genericResource, genericResource.Id as ResourceGroupResourceIdentifier).Get().Value);
        }

        /// <summary> Filters the list of <see cref="ParentResource" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="ParentResource" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ParentResource> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(null, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, ParentResource>(results, genericResource => new ParentResourceOperations(genericResource, genericResource.Id as ResourceGroupResourceIdentifier).Get().Value);
        }

        /// <summary> Filters the list of ParentResource for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ParentResourceOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ParentResource for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ParentResourceContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ParentResourceOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
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
