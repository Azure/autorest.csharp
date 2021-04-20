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
    /// <summary> A class representing collection of VirtualMachineExtension and their operations over a [ParentResource]. </summary>
    public partial class VirtualMachineExtensionContainer : ResourceContainerBase<TenantResourceIdentifier, VirtualMachineExtension, VirtualMachineExtensionData>
    {
        /// <summary> Initializes a new instance of VirtualMachineExtensionContainer class. </summary>
        /// <param name="resourceGroup"> The parent resource group. </param>
        internal VirtualMachineExtensionContainer(ResourceGroupOperations resourceGroup) : base(resourceGroup)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = new HttpPipeline(ClientOptions.Transport);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private VirtualMachineScaleSetVMExtensionsRestOperations Operations => new VirtualMachineScaleSetVMExtensionsRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;
        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => VirtualMachineScaleSetOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<VirtualMachineExtension> CreateOrUpdate(string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            return StartCreateOrUpdate(vmExtensionName, extensionParameters, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<VirtualMachineExtension>;
        }

        /// <inheritdoc />
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<VirtualMachineExtension>> CreateOrUpdateAsync(string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            var operation = await StartCreateOrUpdateAsync(vmExtensionName, extensionParameters, cancellationToken: cancellationToken).ConfigureAwait(false);
            return operation.WaitForCompletion() as ArmResponse<VirtualMachineExtension>;
        }

        /// <inheritdoc />
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmOperation<VirtualMachineExtension> StartCreateOrUpdate(string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            var originalResponse = Operations.CreateOrUpdate(Id.ResourceGroupName, Id.Name, Id.Parent.Name, vmExtensionName, extensionParameters, cancellationToken: cancellationToken);
            var operation = new VirtualMachineExtensionCreateOrUpdateOperation(
            _clientDiagnostics, _pipeline, Operations.CreateCreateOrUpdateRequest(
            Id.ResourceGroupName, Id.Name, Id.Parent.Name, vmExtensionName, extensionParameters).Request,
            originalResponse);
            return new PhArmOperation<VirtualMachineExtension, VirtualMachineExtensionData>(
            operation,
            data => new VirtualMachineExtension(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmOperation<VirtualMachineExtension>> StartCreateOrUpdateAsync(string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            var originalResponse = await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Name, Id.Parent.Name, vmExtensionName, extensionParameters, cancellationToken: cancellationToken).ConfigureAwait(false);
            var operation = new VirtualMachineExtensionCreateOrUpdateOperation(
            _clientDiagnostics, _pipeline, Operations.CreateCreateOrUpdateRequest(
            Id.ResourceGroupName, Id.Name, Id.Parent.Name, vmExtensionName, extensionParameters).Request,
            originalResponse);
            return new PhArmOperation<VirtualMachineExtension, VirtualMachineExtensionData>(
            operation,
            data => new VirtualMachineExtension(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<VirtualMachineExtension> Get(string vmExtensionName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineExtension, VirtualMachineExtensionData>(
            Operations.Get(Id.ResourceGroupName, Id.Name, Id.Parent.Name, vmExtensionName, cancellationToken: cancellationToken),
            data => new VirtualMachineExtension(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<VirtualMachineExtension>> GetAsync(string vmExtensionName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineExtension, VirtualMachineExtensionData>(
            await Operations.GetAsync(Id.ResourceGroupName, Id.Name, Id.Parent.Name, vmExtensionName, cancellationToken: cancellationToken),
            data => new VirtualMachineExtension(Parent, data));
        }

        /// <summary> Filters the list of todo: availability set for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var filters = new ResourceFilterCollection(VirtualMachineExtensionData.ResourceType);
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
            var filters = new ResourceFilterCollection(VirtualMachineExtensionData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary> Filters the list of todo: availability set for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of todo: availability set that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualMachineExtension> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, VirtualMachineExtension>(results, genericResource => new VirtualMachineExtensionOperations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of todo: availability set for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of todo: availability set that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualMachineExtension> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, VirtualMachineExtension>(results, genericResource => new VirtualMachineExtensionOperations(genericResource).Get().Value);
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, VirtualMachineExtension, VirtualMachineExtensionData> Construct() { }
    }
}
