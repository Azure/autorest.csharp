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
    /// <summary> A class representing collection of ExactMatchModel3 and their operations over a ResourceGroup. </summary>
    public partial class ExactMatchModel3Container : ResourceContainerBase<TenantResourceIdentifier, ExactMatchModel3, ExactMatchModel3Data>
    {
        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel3Container"/> class for mocking. </summary>
        protected ExactMatchModel3Container()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel3Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ExactMatchModel3Container(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private ExactMatchModel3SRestOperations Operations => new ExactMatchModel3SRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;
        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel3 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmResponse<ExactMatchModel3> CreateOrUpdate(string exactMatchModel3SName, ExactMatchModel3Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.CreateOrUpdate");
            scope.Start();
            try
            {
                return StartCreateOrUpdate(exactMatchModel3SName, parameters, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<ExactMatchModel3>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel3 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmResponse<ExactMatchModel3>> CreateOrUpdateAsync(string exactMatchModel3SName, ExactMatchModel3Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.CreateOrUpdateAsync");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(exactMatchModel3SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as ArmResponse<ExactMatchModel3>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel3 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmOperation<ExactMatchModel3> StartCreateOrUpdate(string exactMatchModel3SName, ExactMatchModel3Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = Operations.Put(Id.ResourceGroupName, exactMatchModel3SName, parameters, cancellationToken: cancellationToken);
                return new PhArmOperation<ExactMatchModel3, ExactMatchModel3Data>(
                originalResponse,
                data => new ExactMatchModel3(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel3 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmOperation<ExactMatchModel3>> StartCreateOrUpdateAsync(string exactMatchModel3SName, ExactMatchModel3Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.StartCreateOrUpdateAsync");
            scope.Start();
            try
            {
                var originalResponse = await Operations.PutAsync(Id.ResourceGroupName, exactMatchModel3SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new PhArmOperation<ExactMatchModel3, ExactMatchModel3Data>(
                originalResponse,
                data => new ExactMatchModel3(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public override ArmResponse<ExactMatchModel3> Get(string resourceName, CancellationToken cancellationToken = default)
        {
            // This resource does not support Get operation.
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ArmResponse<ExactMatchModel3>> GetAsync(string resourceName, CancellationToken cancellationToken = default)
        {
            // This resource does not support Get operation.
            throw new NotImplementedException();
        }

        /// <summary> Filters the list of ExactMatchModel3 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel3Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ExactMatchModel3 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.ListAsGenericResourceAsync");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel3Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ExactMatchModel3" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="ExactMatchModel3" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<ExactMatchModel3> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.List");
            scope.Start();
            try
            {
                var results = ListAsGenericResource(nameFilter, top, cancellationToken);
                return new PhWrappingPageable<GenericResource, ExactMatchModel3>(results, genericResource => new ExactMatchModel3Operations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ExactMatchModel3" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="ExactMatchModel3" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ExactMatchModel3> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.ListAsync");
            scope.Start();
            try
            {
                var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
                return new PhWrappingAsyncPageable<GenericResource, ExactMatchModel3>(results, genericResource => new ExactMatchModel3Operations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, ExactMatchModel3, ExactMatchModel3Data> Construct() { }
    }
}
