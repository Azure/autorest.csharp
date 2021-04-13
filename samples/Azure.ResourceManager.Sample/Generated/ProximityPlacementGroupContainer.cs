// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of ProximityPlacementGroup and their operations over a [ParentResource]. </summary>
    public partial class ProximityPlacementGroupContainer : ResourceContainerBase<TenantResourceIdentifier, ProximityPlacementGroup, ProximityPlacementGroupData>
    {
        /// <summary> Initializes a new instance of ProximityPlacementGroupContainer class. </summary>
        /// <param name="resourceGroup"> The parent resource group. </param>
        internal ProximityPlacementGroupContainer(ResourceGroupOperations resourceGroup) : base(resourceGroup)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = new HttpPipeline(ClientOptions.Transport);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private ProximityPlacementGroupsRestOperations Operations => new ProximityPlacementGroupsRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <inheritdoc />
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<ProximityPlacementGroup> CreateOrUpdate(string proximityPlacementGroupName, ProximityPlacementGroupData parameters, CancellationToken cancellationToken = default)
        {
            return StartCreateOrUpdate(proximityPlacementGroupName, parameters, cancellationToken: cancellationToken).WaitForCompletion();
        }

        /// <inheritdoc />
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<ProximityPlacementGroup>> CreateOrUpdateAsync(string proximityPlacementGroupName, ProximityPlacementGroupData parameters, CancellationToken cancellationToken = default)
        {
            var operation = await StartCreateOrUpdateAsync(proximityPlacementGroupName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
            return operation.WaitForCompletion();
        }

        /// <inheritdoc />
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmOperation<ProximityPlacementGroup> StartCreateOrUpdate(string proximityPlacementGroupName, ProximityPlacementGroupData parameters, CancellationToken cancellationToken = default)
        {
            var originalResponse = Operations.CreateOrUpdate(Id.ResourceGroupName, proximityPlacementGroupName, parameters, cancellationToken: cancellationToken);
            return new ArmOperation<ProximityPlacementGroup, ProximityPlacementGroupData>(
            originalResponse,
            data => new ProximityPlacementGroup(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmOperation<ProximityPlacementGroup>> StartCreateOrUpdateAsync(string proximityPlacementGroupName, ProximityPlacementGroupData parameters, CancellationToken cancellationToken = default)
        {
            var originalResponse = await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, proximityPlacementGroupName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
            return new ArmOperation<ProximityPlacementGroup, ProximityPlacementGroupData>(
            originalResponse,
            data => new ProximityPlacementGroup(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<ProximityPlacementGroup> Get(string proximityPlacementGroupName, CancellationToken cancellationToken = default)
        {
            return new ArmResponse<ProximityPlacementGroup, ProximityPlacementGroupData>(
            Operations.Get(Id.ResourceGroupName, proximityPlacementGroupName, cancellationToken: cancellationToken),
            data => new ProximityPlacementGroup(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<ProximityPlacementGroup>> GetAsync(string proximityPlacementGroupName, CancellationToken cancellationToken = default)
        {
            return new ArmResponse<ProximityPlacementGroup, ProximityPlacementGroupData>(
            await Operations.GetAsync(Id.ResourceGroupName, proximityPlacementGroupName, cancellationToken: cancellationToken),
            data => new ProximityPlacementGroup(Parent, data));
        }

        /// <summary> Filters the list of todo: availability set for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var filters = new ResourceFilterCollection(ProximityPlacementGroupData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary> Filters the list of todo: availability set for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var filters = new ResourceFilterCollection(ProximityPlacementGroupData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary> Filters the list of todo: availability set for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of todo: availability set that may take multiple service requests to iterate over. </returns>
        public Pageable<ProximityPlacementGroup> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, ProximityPlacementGroup>(results, genericResource => new ProximityPlacementGroupOperations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of todo: availability set for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of todo: availability set that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ProximityPlacementGroup> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, ProximityPlacementGroup>(results, genericResource => new ProximityPlacementGroupOperations(genericResource).Get().Value);
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, ProximityPlacementGroup, ProximityPlacementGroupData> Construct() { }
    }
}
