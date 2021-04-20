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
    /// <summary> A class representing collection of VirtualMachine and their operations over a [ParentResource]. </summary>
    public partial class VirtualMachineContainer : ResourceContainerBase<TenantResourceIdentifier, VirtualMachine, VirtualMachineData>
    {
        /// <summary> Initializes a new instance of VirtualMachineContainer class. </summary>
        /// <param name="resourceGroup"> The parent resource group. </param>
        internal VirtualMachineContainer(ResourceGroupOperations resourceGroup) : base(resourceGroup)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = new HttpPipeline(ClientOptions.Transport);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private VirtualMachinesRestOperations Operations => new VirtualMachinesRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;
        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<VirtualMachine> CreateOrUpdate(string vmName, VirtualMachineData parameters, CancellationToken cancellationToken = default)
        {
            return StartCreateOrUpdate(vmName, parameters, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<VirtualMachine>;
        }

        /// <inheritdoc />
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<VirtualMachine>> CreateOrUpdateAsync(string vmName, VirtualMachineData parameters, CancellationToken cancellationToken = default)
        {
            var operation = await StartCreateOrUpdateAsync(vmName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
            return operation.WaitForCompletion() as ArmResponse<VirtualMachine>;
        }

        /// <inheritdoc />
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmOperation<VirtualMachine> StartCreateOrUpdate(string vmName, VirtualMachineData parameters, CancellationToken cancellationToken = default)
        {
            var originalResponse = Operations.CreateOrUpdate(Id.ResourceGroupName, vmName, parameters, cancellationToken: cancellationToken);
            var operation = new VirtualMachineCreateOrUpdateOperation(
            _clientDiagnostics, _pipeline, Operations.CreateCreateOrUpdateRequest(
            Id.ResourceGroupName, vmName, parameters).Request,
            originalResponse);
            return new PhArmOperation<VirtualMachine, VirtualMachineData>(
            operation,
            data => new VirtualMachine(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmOperation<VirtualMachine>> StartCreateOrUpdateAsync(string vmName, VirtualMachineData parameters, CancellationToken cancellationToken = default)
        {
            var originalResponse = await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, vmName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
            var operation = new VirtualMachineCreateOrUpdateOperation(
            _clientDiagnostics, _pipeline, Operations.CreateCreateOrUpdateRequest(
            Id.ResourceGroupName, vmName, parameters).Request,
            originalResponse);
            return new PhArmOperation<VirtualMachine, VirtualMachineData>(
            operation,
            data => new VirtualMachine(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<VirtualMachine> Get(string vmName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachine, VirtualMachineData>(
            Operations.Get(Id.ResourceGroupName, vmName, cancellationToken: cancellationToken),
            data => new VirtualMachine(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<VirtualMachine>> GetAsync(string vmName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachine, VirtualMachineData>(
            await Operations.GetAsync(Id.ResourceGroupName, vmName, cancellationToken: cancellationToken),
            data => new VirtualMachine(Parent, data));
        }

        /// <summary> Filters the list of todo: availability set for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var filters = new ResourceFilterCollection(VirtualMachineData.ResourceType);
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
            var filters = new ResourceFilterCollection(VirtualMachineData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary> Filters the list of todo: availability set for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of todo: availability set that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualMachine> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, VirtualMachine>(results, genericResource => new VirtualMachineOperations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of todo: availability set for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of todo: availability set that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualMachine> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, VirtualMachine>(results, genericResource => new VirtualMachineOperations(genericResource).Get().Value);
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, VirtualMachine, VirtualMachineData> Construct() { }
    }
}
