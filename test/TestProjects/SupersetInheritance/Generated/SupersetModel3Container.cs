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

namespace SupersetInheritance
{
    /// <summary> A class representing collection of SupersetModel3 and their operations over a [ParentResource]. </summary>
    public partial class SupersetModel3Container : ResourceContainerBase<TenantResourceIdentifier, SupersetModel3, SupersetModel3Data>
    {
        /// <summary> Initializes a new instance of the <see cref="SupersetModel3Container"/> class for mocking. </summary>
        protected SupersetModel3Container()
        {
        }

        /// <summary> Initializes a new instance of SupersetModel3Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SupersetModel3Container(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private SupersetModel3SRestOperations Operations => new SupersetModel3SRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;
        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel3 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<SupersetModel3> CreateOrUpdate(string supersetModel3SName, SupersetModel3Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel3Container.CreateOrUpdate");
            scope.Start();
            try
            {
                return StartCreateOrUpdate(supersetModel3SName, parameters, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<SupersetModel3>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel3 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<SupersetModel3>> CreateOrUpdateAsync(string supersetModel3SName, SupersetModel3Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel3Container.CreateOrUpdateAsync");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(supersetModel3SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as ArmResponse<SupersetModel3>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel3 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmOperation<SupersetModel3> StartCreateOrUpdate(string supersetModel3SName, SupersetModel3Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel3Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = Operations.Put(Id.ResourceGroupName, supersetModel3SName, parameters, cancellationToken: cancellationToken);
                return new PhArmOperation<SupersetModel3, SupersetModel3Data>(
                originalResponse,
                data => new SupersetModel3(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel3 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmOperation<SupersetModel3>> StartCreateOrUpdateAsync(string supersetModel3SName, SupersetModel3Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel3Container.StartCreateOrUpdateAsync");
            scope.Start();
            try
            {
                var originalResponse = await Operations.PutAsync(Id.ResourceGroupName, supersetModel3SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new PhArmOperation<SupersetModel3, SupersetModel3Data>(
                originalResponse,
                data => new SupersetModel3(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public override ArmResponse<SupersetModel3> Get(string resourceName, CancellationToken cancellationToken = default)
        {
            // This resource does not support Get operation.
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ArmResponse<SupersetModel3>> GetAsync(string resourceName, CancellationToken cancellationToken = default)
        {
            // This resource does not support Get operation.
            throw new NotImplementedException();
        }

        /// <summary> Filters the list of SupersetModel3 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel3Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SupersetModel3Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of SupersetModel3 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel3Container.ListAsGenericResourceAsync");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SupersetModel3Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SupersetModel3" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="SupersetModel3" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<SupersetModel3> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel3Container.List");
            scope.Start();
            try
            {
                var results = ListAsGenericResource(nameFilter, top, cancellationToken);
                return new PhWrappingPageable<GenericResource, SupersetModel3>(results, genericResource => new SupersetModel3Operations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SupersetModel3" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="SupersetModel3" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<SupersetModel3> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel3Container.ListAsync");
            scope.Start();
            try
            {
                var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
                return new PhWrappingAsyncPageable<GenericResource, SupersetModel3>(results, genericResource => new SupersetModel3Operations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, SupersetModel3, SupersetModel3Data> Construct() { }
    }
}
