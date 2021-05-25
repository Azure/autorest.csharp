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

namespace ExactMatchInheritance
{
    /// <summary> A class representing collection of ExactMatchModel1 and their operations over a ResourceGroup. </summary>
    public partial class ExactMatchModel1Container : ContainerBase<ResourceGroupResourceIdentifier>
    {
        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel1Container"/> class for mocking. </summary>
        protected ExactMatchModel1Container()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel1Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ExactMatchModel1Container(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private ExactMatchModel1SRestOperations _restClient => new ExactMatchModel1SRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update a ExactMatchModel1. Please note some properties can be set only during creation. </summary>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public Response<ExactMatchModel1> CreateOrUpdate(string exactMatchModel1SName, ExactMatchModel1Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.CreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel1SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(exactMatchModel1SName, parameters, cancellationToken: cancellationToken).WaitForCompletion();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ExactMatchModel1. Please note some properties can be set only during creation. </summary>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<Response<ExactMatchModel1>> CreateOrUpdateAsync(string exactMatchModel1SName, ExactMatchModel1Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.CreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel1SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(exactMatchModel1SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ExactMatchModel1. Please note some properties can be set only during creation. </summary>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ExactMatchModel1SPutOperation StartCreateOrUpdate(string exactMatchModel1SName, ExactMatchModel1Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel1SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.Put(Id.ResourceGroupName, exactMatchModel1SName, parameters, cancellationToken: cancellationToken);
                return new ExactMatchModel1SPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ExactMatchModel1. Please note some properties can be set only during creation. </summary>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ExactMatchModel1SPutOperation> StartCreateOrUpdateAsync(string exactMatchModel1SName, ExactMatchModel1Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel1SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.PutAsync(Id.ResourceGroupName, exactMatchModel1SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new ExactMatchModel1SPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ExactMatchModel1 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel1Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ExactMatchModel1 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel1Operations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, ExactMatchModel1, ExactMatchModel1Data> Construct() { }
    }
}
