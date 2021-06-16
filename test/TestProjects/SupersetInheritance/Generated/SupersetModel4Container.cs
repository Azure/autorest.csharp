// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace SupersetInheritance
{
    /// <summary> A class representing collection of SupersetModel4 and their operations over a ResourceGroup. </summary>
    public partial class SupersetModel4Container : ResourceContainerBase<ResourceGroupResourceIdentifier, SupersetModel4, SupersetModel4Data>
    {
        /// <summary> Initializes a new instance of the <see cref="SupersetModel4Container"/> class for mocking. </summary>
        protected SupersetModel4Container()
        {
        }

        /// <summary> Initializes a new instance of SupersetModel4Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SupersetModel4Container(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private SupersetModel4SRestOperations _restClient => new SupersetModel4SRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update a SupersetModel4. Please note some properties can be set only during creation. </summary>
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel4 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public Response<SupersetModel4> CreateOrUpdate(string supersetModel4SName, SupersetModel4Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.CreateOrUpdate");
            scope.Start();
            try
            {
                if (supersetModel4SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel4SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(supersetModel4SName, parameters, cancellationToken: cancellationToken).WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a SupersetModel4. Please note some properties can be set only during creation. </summary>
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel4 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<Response<SupersetModel4>> CreateOrUpdateAsync(string supersetModel4SName, SupersetModel4Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.CreateOrUpdate");
            scope.Start();
            try
            {
                if (supersetModel4SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel4SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(supersetModel4SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a SupersetModel4. Please note some properties can be set only during creation. </summary>
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel4 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public SupersetModel4SPutOperation StartCreateOrUpdate(string supersetModel4SName, SupersetModel4Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (supersetModel4SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel4SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.Put(Id.ResourceGroupName, supersetModel4SName, parameters, cancellationToken: cancellationToken);
                return new SupersetModel4SPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a SupersetModel4. Please note some properties can be set only during creation. </summary>
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel4 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<SupersetModel4SPutOperation> StartCreateOrUpdateAsync(string supersetModel4SName, SupersetModel4Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (supersetModel4SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel4SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.PutAsync(Id.ResourceGroupName, supersetModel4SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new SupersetModel4SPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public override Response<SupersetModel4> Get(string supersetModel4SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.Get");
            scope.Start();
            try
            {
                if (supersetModel4SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel4SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, supersetModel4SName, cancellationToken: cancellationToken);
                return Response.FromValue(new SupersetModel4(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async override Task<Response<SupersetModel4>> GetAsync(string supersetModel4SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.Get");
            scope.Start();
            try
            {
                if (supersetModel4SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel4SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, supersetModel4SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SupersetModel4(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of SupersetModel4 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SupersetModel4Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of SupersetModel4 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SupersetModel4Operations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, SupersetModel4, SupersetModel4Data> Construct() { }
    }
}
