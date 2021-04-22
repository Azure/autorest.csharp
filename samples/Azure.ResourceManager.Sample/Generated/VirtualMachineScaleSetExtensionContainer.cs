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

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of VirtualMachineScaleSetExtension and their operations over a [ParentResource]. </summary>
    public partial class VirtualMachineScaleSetExtensionContainer : ResourceContainerBase<TenantResourceIdentifier, VirtualMachineScaleSetExtension, VirtualMachineScaleSetExtensionData>
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetExtensionContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal VirtualMachineScaleSetExtensionContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private VirtualMachineScaleSetExtensionsRestOperations Operations => new VirtualMachineScaleSetExtensionsRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;
        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => VirtualMachineScaleSetOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create VM scale set Extension operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<VirtualMachineScaleSetExtension> CreateOrUpdate(string vmssExtensionName, VirtualMachineScaleSetExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                return StartCreateOrUpdate(vmssExtensionName, extensionParameters, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<VirtualMachineScaleSetExtension>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create VM scale set Extension operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<VirtualMachineScaleSetExtension>> CreateOrUpdateAsync(string vmssExtensionName, VirtualMachineScaleSetExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.CreateOrUpdateAsync");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(vmssExtensionName, extensionParameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as ArmResponse<VirtualMachineScaleSetExtension>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create VM scale set Extension operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmOperation<VirtualMachineScaleSetExtension> StartCreateOrUpdate(string vmssExtensionName, VirtualMachineScaleSetExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = Operations.CreateOrUpdate(Id.ResourceGroupName, Id.Name, vmssExtensionName, extensionParameters, cancellationToken: cancellationToken);
                var operation = new VirtualMachineScaleSetExtensionCreateOrUpdateOperation(
                _clientDiagnostics, _pipeline, Operations.CreateCreateOrUpdateRequest(
                Id.ResourceGroupName, Id.Name, vmssExtensionName, extensionParameters).Request,
                originalResponse);
                return new PhArmOperation<VirtualMachineScaleSetExtension, VirtualMachineScaleSetExtensionData>(
                operation,
                data => new VirtualMachineScaleSetExtension(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create VM scale set Extension operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmOperation<VirtualMachineScaleSetExtension>> StartCreateOrUpdateAsync(string vmssExtensionName, VirtualMachineScaleSetExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.StartCreateOrUpdateAsync");
            scope.Start();
            try
            {
                var originalResponse = await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Name, vmssExtensionName, extensionParameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                var operation = new VirtualMachineScaleSetExtensionCreateOrUpdateOperation(
                _clientDiagnostics, _pipeline, Operations.CreateCreateOrUpdateRequest(
                Id.ResourceGroupName, Id.Name, vmssExtensionName, extensionParameters).Request,
                originalResponse);
                return new PhArmOperation<VirtualMachineScaleSetExtension, VirtualMachineScaleSetExtensionData>(
                operation,
                data => new VirtualMachineScaleSetExtension(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<VirtualMachineScaleSetExtension> Get(string vmssExtensionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.Get");
            scope.Start();
            try
            {
                return new PhArmResponse<VirtualMachineScaleSetExtension, VirtualMachineScaleSetExtensionData>(
                Operations.Get(Id.ResourceGroupName, Id.Name, vmssExtensionName, cancellationToken: cancellationToken),
                data => new VirtualMachineScaleSetExtension(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<VirtualMachineScaleSetExtension>> GetAsync(string vmssExtensionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.GetAsync");
            scope.Start();
            try
            {
                return new PhArmResponse<VirtualMachineScaleSetExtension, VirtualMachineScaleSetExtensionData>(
                await Operations.GetAsync(Id.ResourceGroupName, Id.Name, vmssExtensionName, cancellationToken: cancellationToken),
                data => new VirtualMachineScaleSetExtension(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of VirtualMachineScaleSetExtension for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachineScaleSetExtensionData.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of VirtualMachineScaleSetExtension for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.ListAsGenericResourceAsync");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachineScaleSetExtensionData.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="VirtualMachineScaleSetExtension" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="VirtualMachineScaleSetExtension" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualMachineScaleSetExtension> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.List");
            scope.Start();
            try
            {
                var results = ListAsGenericResource(nameFilter, top, cancellationToken);
                return new PhWrappingPageable<GenericResource, VirtualMachineScaleSetExtension>(results, genericResource => new VirtualMachineScaleSetExtensionOperations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="VirtualMachineScaleSetExtension" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSetExtension" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualMachineScaleSetExtension> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.ListAsync");
            scope.Start();
            try
            {
                var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
                return new PhWrappingAsyncPageable<GenericResource, VirtualMachineScaleSetExtension>(results, genericResource => new VirtualMachineScaleSetExtensionOperations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, VirtualMachineScaleSetExtension, VirtualMachineScaleSetExtensionData> Construct() { }
    }
}
