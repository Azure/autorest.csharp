// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of VirtualMachineScaleSetRollingUpgrade and their operations over a [ParentResource]. </summary>
    public partial class VirtualMachineScaleSetRollingUpgradeContainer : ResourceContainerBase<TenantResourceIdentifier, VirtualMachineScaleSetRollingUpgrade, VirtualMachineScaleSetRollingUpgradeData>
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetRollingUpgradeContainer class. </summary>
        /// <param name="resourceGroup"> The parent resource group. </param>
        internal VirtualMachineScaleSetRollingUpgradeContainer(ResourceGroupOperations resourceGroup) : base(resourceGroup)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = new HttpPipeline(ClientOptions.Transport);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private VirtualMachineScaleSetRollingUpgradesRestOperations Operations => new VirtualMachineScaleSetRollingUpgradesRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <inheritdoc />
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        public override ArmResponse<VirtualMachineScaleSetRollingUpgrade> CreateOrUpdate(string name, VirtualMachineScaleSetRollingUpgradeData resourceDetails, CancellationToken cancellationToken = default)
        {
            // This resource does not support PUT HTTP method.
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ArmResponse<VirtualMachineScaleSetRollingUpgrade>> CreateOrUpdateAsync(string name, VirtualMachineScaleSetRollingUpgradeData resourceDetails, CancellationToken cancellationToken = default)
        {
            // This resource does not support PUT HTTP method.
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override ArmOperation<VirtualMachineScaleSetRollingUpgrade> StartCreateOrUpdate(string name, VirtualMachineScaleSetRollingUpgradeData resourceDetails, CancellationToken cancellationToken = default)
        {
            // This resource does not support PUT HTTP method.
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ArmOperation<VirtualMachineScaleSetRollingUpgrade>> StartCreateOrUpdateAsync(string name, VirtualMachineScaleSetRollingUpgradeData resourceDetails, CancellationToken cancellationToken = default)
        {
            // This resource does not support PUT HTTP method.
            throw new NotImplementedException();
        }

        /// <summary> Filters the list of todo: availability set for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var filters = new ResourceFilterCollection(VirtualMachineScaleSetRollingUpgradeData.ResourceType);
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
            var filters = new ResourceFilterCollection(VirtualMachineScaleSetRollingUpgradeData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary> Filters the list of todo: availability set for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of todo: availability set that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualMachineScaleSetRollingUpgrade> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, VirtualMachineScaleSetRollingUpgrade>(results, genericResource => new VirtualMachineScaleSetRollingUpgradeOperations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of todo: availability set for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of todo: availability set that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualMachineScaleSetRollingUpgrade> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, VirtualMachineScaleSetRollingUpgrade>(results, genericResource => new VirtualMachineScaleSetRollingUpgradeOperations(genericResource).Get().Value);
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, VirtualMachineScaleSetRollingUpgrade, VirtualMachineScaleSetRollingUpgradeData> Construct() { }
    }
}
