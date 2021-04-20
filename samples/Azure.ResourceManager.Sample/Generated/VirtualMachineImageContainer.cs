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
    /// <summary> A class representing collection of VirtualMachineImage and their operations over a [ParentResource]. </summary>
    public partial class VirtualMachineImageContainer : ResourceContainerBase<TenantResourceIdentifier, VirtualMachineImage, VirtualMachineImageData>
    {
        /// <summary> Initializes a new instance of VirtualMachineImageContainer class. </summary>
        /// <param name="resourceGroup"> The parent resource group. </param>
        internal VirtualMachineImageContainer(ResourceGroupOperations resourceGroup) : base(resourceGroup)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = new HttpPipeline(ClientOptions.Transport);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private VirtualMachineImagesRestOperations Operations => new VirtualMachineImagesRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;
        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => "Microsoft.Compute/locations";

        // Container level operations.

        /// <inheritdoc />
        public override ArmResponse<VirtualMachineImage> CreateOrUpdate(string name, VirtualMachineImageData resourceDetails, CancellationToken cancellationToken = default)
        {
            // This resource does not support PUT HTTP method.
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ArmResponse<VirtualMachineImage>> CreateOrUpdateAsync(string name, VirtualMachineImageData resourceDetails, CancellationToken cancellationToken = default)
        {
            // This resource does not support PUT HTTP method.
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override ArmOperation<VirtualMachineImage> StartCreateOrUpdate(string name, VirtualMachineImageData resourceDetails, CancellationToken cancellationToken = default)
        {
            // This resource does not support PUT HTTP method.
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ArmOperation<VirtualMachineImage>> StartCreateOrUpdateAsync(string name, VirtualMachineImageData resourceDetails, CancellationToken cancellationToken = default)
        {
            // This resource does not support PUT HTTP method.
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <param name="version"> A valid image SKU version. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<VirtualMachineImage> Get(string version, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineImage, VirtualMachineImageData>(
            Operations.Get(Id.Name, Id.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, version, cancellationToken: cancellationToken),
            data => new VirtualMachineImage(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="version"> A valid image SKU version. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<VirtualMachineImage>> GetAsync(string version, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineImage, VirtualMachineImageData>(
            await Operations.GetAsync(Id.Name, Id.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, version, cancellationToken: cancellationToken),
            data => new VirtualMachineImage(Parent, data));
        }

        /// <summary> Filters the list of todo: availability set for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var filters = new ResourceFilterCollection(VirtualMachineImageData.ResourceType);
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
            var filters = new ResourceFilterCollection(VirtualMachineImageData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary> Filters the list of todo: availability set for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of todo: availability set that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualMachineImage> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, VirtualMachineImage>(results, genericResource => new VirtualMachineImageOperations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of todo: availability set for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of todo: availability set that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualMachineImage> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, VirtualMachineImage>(results, genericResource => new VirtualMachineImageOperations(genericResource).Get().Value);
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, VirtualMachineImage, VirtualMachineImageData> Construct() { }
    }
}
