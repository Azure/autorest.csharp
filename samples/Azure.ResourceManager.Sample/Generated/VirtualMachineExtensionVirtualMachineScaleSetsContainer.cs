// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of VirtualMachineExtensionVirtualMachineScaleSets and their operations over a VirtualMachineScaleSet. </summary>
    public partial class VirtualMachineExtensionVirtualMachineScaleSetsContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, VirtualMachineExtensionVirtualMachineScaleSets, VirtualMachineExtensionData>
    {
        /// <summary> Initializes a new instance of the <see cref="VirtualMachineExtensionVirtualMachineScaleSetsContainer"/> class for mocking. </summary>
        protected VirtualMachineExtensionVirtualMachineScaleSetsContainer()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineExtensionVirtualMachineScaleSetsContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal VirtualMachineExtensionVirtualMachineScaleSetsContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private VirtualMachineScaleSetVMExtensionsRestOperations _restClient => new VirtualMachineScaleSetVMExtensionsRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => VirtualMachineScaleSetOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update a VirtualMachineExtensionVirtualMachineScaleSets. Please note some properties can be set only during creation. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public Response<VirtualMachineExtensionVirtualMachineScaleSets> CreateOrUpdate(string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetsContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (vmExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmExtensionName));
                }
                if (extensionParameters == null)
                {
                    throw new ArgumentNullException(nameof(extensionParameters));
                }

                return StartCreateOrUpdate(vmExtensionName, extensionParameters, cancellationToken: cancellationToken).WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a VirtualMachineExtensionVirtualMachineScaleSets. Please note some properties can be set only during creation. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<Response<VirtualMachineExtensionVirtualMachineScaleSets>> CreateOrUpdateAsync(string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetsContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (vmExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmExtensionName));
                }
                if (extensionParameters == null)
                {
                    throw new ArgumentNullException(nameof(extensionParameters));
                }

                var operation = await StartCreateOrUpdateAsync(vmExtensionName, extensionParameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a VirtualMachineExtensionVirtualMachineScaleSets. Please note some properties can be set only during creation. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public VirtualMachineScaleSetVMExtensionsCreateOrUpdateOperation StartCreateOrUpdate(string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetsContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (vmExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmExtensionName));
                }
                if (extensionParameters == null)
                {
                    throw new ArgumentNullException(nameof(extensionParameters));
                }

                var originalResponse = _restClient.CreateOrUpdate(Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters, cancellationToken: cancellationToken);
                return new VirtualMachineScaleSetVMExtensionsCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a VirtualMachineExtensionVirtualMachineScaleSets. Please note some properties can be set only during creation. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<VirtualMachineScaleSetVMExtensionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetsContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (vmExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmExtensionName));
                }
                if (extensionParameters == null)
                {
                    throw new ArgumentNullException(nameof(extensionParameters));
                }

                var originalResponse = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new VirtualMachineScaleSetVMExtensionsCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public Response<VirtualMachineExtensionVirtualMachineScaleSets> Get(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetsContainer.Get");
            scope.Start();
            try
            {
                if (vmExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmExtensionName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(new VirtualMachineExtensionVirtualMachineScaleSets(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<Response<VirtualMachineExtensionVirtualMachineScaleSets>> GetAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetsContainer.Get");
            scope.Start();
            try
            {
                if (vmExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmExtensionName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new VirtualMachineExtensionVirtualMachineScaleSets(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of VirtualMachineExtensionVirtualMachineScaleSets for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetsContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachineExtensionVirtualMachineScaleSetsOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of VirtualMachineExtensionVirtualMachineScaleSets for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetsContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachineExtensionVirtualMachineScaleSetsOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to get all extensions of an instance in Virtual Machine Scaleset. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<VirtualMachineExtensionVirtualMachineScaleSets>>> ListAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetsContainer.List");
            scope.Start();
            try
            {
                var response = await _restClient.ListAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value.Select(data => new VirtualMachineExtensionVirtualMachineScaleSets(Parent, data)).ToArray() as IReadOnlyList<VirtualMachineExtensionVirtualMachineScaleSets>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to get all extensions of an instance in Virtual Machine Scaleset. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<VirtualMachineExtensionVirtualMachineScaleSets>> List(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetsContainer.List");
            scope.Start();
            try
            {
                var response = _restClient.List(Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken);
                return Response.FromValue(response.Value.Value.Select(data => new VirtualMachineExtensionVirtualMachineScaleSets(Parent, data)).ToArray() as IReadOnlyList<VirtualMachineExtensionVirtualMachineScaleSets>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceGroupResourceIdentifier, VirtualMachineExtensionVirtualMachineScaleSets, VirtualMachineExtensionData> Construct() { }
    }
}
