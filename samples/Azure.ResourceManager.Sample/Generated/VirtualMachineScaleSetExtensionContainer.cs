// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of VirtualMachineScaleSetExtension and their operations over a VirtualMachineScaleSet. </summary>
    public partial class VirtualMachineScaleSetExtensionContainer : ResourceContainerBase<ResourceIdentifier, VirtualMachineScaleSetExtension, VirtualMachineScaleSetExtensionData>
    {
        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetExtensionContainer"/> class for mocking. </summary>
        protected VirtualMachineScaleSetExtensionContainer()
        {
        }

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
        private VirtualMachineScaleSetExtensionsRestOperations _restClient => new VirtualMachineScaleSetExtensionsRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => VirtualMachineScaleSetOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create VM scale set Extension operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public Response<VirtualMachineScaleSetExtension> CreateOrUpdate(string vmssExtensionName, VirtualMachineScaleSetExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (vmssExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmssExtensionName));
                }
                if (extensionParameters == null)
                {
                    throw new ArgumentNullException(nameof(extensionParameters));
                }

                return StartCreateOrUpdate(vmssExtensionName, extensionParameters, cancellationToken: cancellationToken).WaitForCompletion() as Response<VirtualMachineScaleSetExtension>;
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
        public async Task<Response<VirtualMachineScaleSetExtension>> CreateOrUpdateAsync(string vmssExtensionName, VirtualMachineScaleSetExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (vmssExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmssExtensionName));
                }
                if (extensionParameters == null)
                {
                    throw new ArgumentNullException(nameof(extensionParameters));
                }

                var operation = await StartCreateOrUpdateAsync(vmssExtensionName, extensionParameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as Response<VirtualMachineScaleSetExtension>;
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
        public Operation<VirtualMachineScaleSetExtension> StartCreateOrUpdate(string vmssExtensionName, VirtualMachineScaleSetExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (vmssExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmssExtensionName));
                }
                if (extensionParameters == null)
                {
                    throw new ArgumentNullException(nameof(extensionParameters));
                }

                var originalResponse = _restClient.CreateOrUpdate(Id.ResourceGroupName, Id.Parent.Name, vmssExtensionName, extensionParameters, cancellationToken: cancellationToken);
                var operation = new VirtualMachineScaleSetExtensionsCreateOrUpdateOperation(
                _clientDiagnostics, _pipeline, _restClient.CreateCreateOrUpdateRequest(
                Id.ResourceGroupName, Id.Parent.Name, vmssExtensionName, extensionParameters).Request,
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
        public async Task<Operation<VirtualMachineScaleSetExtension>> StartCreateOrUpdateAsync(string vmssExtensionName, VirtualMachineScaleSetExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (vmssExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmssExtensionName));
                }
                if (extensionParameters == null)
                {
                    throw new ArgumentNullException(nameof(extensionParameters));
                }

                var originalResponse = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Parent.Name, vmssExtensionName, extensionParameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                var operation = new VirtualMachineScaleSetExtensionsCreateOrUpdateOperation(
                _clientDiagnostics, _pipeline, _restClient.CreateCreateOrUpdateRequest(
                Id.ResourceGroupName, Id.Parent.Name, vmssExtensionName, extensionParameters).Request,
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
        public override Response<VirtualMachineScaleSetExtension> Get(string vmssExtensionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.Get");
            scope.Start();
            try
            {
                if (vmssExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmssExtensionName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Parent.Name, vmssExtensionName, cancellationToken: cancellationToken);
                return Response.FromValue(new VirtualMachineScaleSetExtension(Parent, response.Value), response.GetRawResponse());
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
        public async override Task<Response<VirtualMachineScaleSetExtension>> GetAsync(string vmssExtensionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.Get");
            scope.Start();
            try
            {
                if (vmssExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmssExtensionName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Name, vmssExtensionName, cancellationToken: cancellationToken);
                return Response.FromValue(new VirtualMachineScaleSetExtension(Parent, response.Value), response.GetRawResponse());
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
                var filters = new ResourceFilterCollection(VirtualMachineScaleSetExtensionOperations.ResourceType);
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
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachineScaleSetExtensionOperations.ResourceType);
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
        public Pageable<VirtualMachineScaleSetExtension> List(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(nameFilter))
            {
                Page<VirtualMachineScaleSetExtension> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.List");
                    scope.Start();
                    try
                    {
                        var response = _restClient.List(Id.ResourceGroupName, Id.Parent.Name, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetExtension(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                Page<VirtualMachineScaleSetExtension> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.List");
                    scope.Start();
                    try
                    {
                        var response = _restClient.ListNextPage(nextLink, Id.ResourceGroupName, Id.Parent.Name, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetExtension(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
            }
            else
            {
                var results = ListAsGenericResource(nameFilter, top, cancellationToken);
                return new PhWrappingPageable<GenericResource, VirtualMachineScaleSetExtension>(results, genericResource => new VirtualMachineScaleSetExtensionOperations(genericResource).Get().Value);
            }
        }

        /// <summary> Filters the list of <see cref="VirtualMachineScaleSetExtension" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSetExtension" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualMachineScaleSetExtension> ListAsync(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(nameFilter))
            {
                async Task<Page<VirtualMachineScaleSetExtension>> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.List");
                    scope.Start();
                    try
                    {
                        var response = await _restClient.ListAsync(Id.ResourceGroupName, Id.Parent.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetExtension(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                async Task<Page<VirtualMachineScaleSetExtension>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetExtensionContainer.List");
                    scope.Start();
                    try
                    {
                        var response = await _restClient.ListNextPageAsync(nextLink, Id.ResourceGroupName, Id.Parent.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetExtension(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
            }
            else
            {
                var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
                return new PhWrappingAsyncPageable<GenericResource, VirtualMachineScaleSetExtension>(results, genericResource => new VirtualMachineScaleSetExtensionOperations(genericResource).Get().Value);
            }
        }

        // Builders.
        // public ArmBuilder<ResourceIdentifier, VirtualMachineScaleSetExtension, VirtualMachineScaleSetExtensionData> Construct() { }
    }
}
