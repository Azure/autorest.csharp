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
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of VirtualMachineExtensionVirtualMachineScaleSet and their operations over a VirtualMachineScaleSet. </summary>
    public partial class VirtualMachineExtensionVirtualMachineScaleSetContainer : ResourceContainer
    {
        /// <summary> Initializes a new instance of the <see cref="VirtualMachineExtensionVirtualMachineScaleSetContainer"/> class for mocking. </summary>
        protected VirtualMachineExtensionVirtualMachineScaleSetContainer()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineExtensionVirtualMachineScaleSetContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal VirtualMachineExtensionVirtualMachineScaleSetContainer(ResourceOperations parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private VirtualMachineScaleSetVMExtensionsRestOperations _restClient => new VirtualMachineScaleSetVMExtensionsRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => VirtualMachineScaleSetOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update the VMSS VM extension. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> or <paramref name="extensionParameters"/> is null. </exception>
        public virtual Response<VirtualMachineExtensionVirtualMachineScaleSet> CreateOrUpdate(string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }
            if (extensionParameters == null)
            {
                throw new ArgumentNullException(nameof(extensionParameters));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(vmExtensionName, extensionParameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update the VMSS VM extension. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> or <paramref name="extensionParameters"/> is null. </exception>
        public async virtual Task<Response<VirtualMachineExtensionVirtualMachineScaleSet>> CreateOrUpdateAsync(string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }
            if (extensionParameters == null)
            {
                throw new ArgumentNullException(nameof(extensionParameters));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(vmExtensionName, extensionParameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update the VMSS VM extension. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> or <paramref name="extensionParameters"/> is null. </exception>
        public virtual VirtualMachineScaleSetVMExtensionsCreateOrUpdateOperation StartCreateOrUpdate(string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }
            if (extensionParameters == null)
            {
                throw new ArgumentNullException(nameof(extensionParameters));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters, cancellationToken);
                return new VirtualMachineScaleSetVMExtensionsCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update the VMSS VM extension. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> or <paramref name="extensionParameters"/> is null. </exception>
        public async virtual Task<VirtualMachineScaleSetVMExtensionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }
            if (extensionParameters == null)
            {
                throw new ArgumentNullException(nameof(extensionParameters));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters, cancellationToken).ConfigureAwait(false);
                return new VirtualMachineScaleSetVMExtensionsCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters).Request, response);
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
        public virtual Response<VirtualMachineExtensionVirtualMachineScaleSet> Get(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetContainer.Get");
            scope.Start();
            try
            {
                if (vmExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmExtensionName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(new VirtualMachineExtensionVirtualMachineScaleSet(Parent, response.Value), response.GetRawResponse());
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
        public async virtual Task<Response<VirtualMachineExtensionVirtualMachineScaleSet>> GetAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetContainer.Get");
            scope.Start();
            try
            {
                if (vmExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmExtensionName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new VirtualMachineExtensionVirtualMachineScaleSet(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual VirtualMachineExtensionVirtualMachineScaleSet TryGet(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetContainer.TryGet");
            scope.Start();
            try
            {
                if (vmExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmExtensionName));
                }

                return Get(vmExtensionName, expand, cancellationToken: cancellationToken).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<VirtualMachineExtensionVirtualMachineScaleSet> TryGetAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetContainer.TryGet");
            scope.Start();
            try
            {
                if (vmExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmExtensionName));
                }

                return await GetAsync(vmExtensionName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool CheckIfExists(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (vmExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmExtensionName));
                }

                return TryGet(vmExtensionName, expand, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> CheckIfExistsAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (vmExtensionName == null)
                {
                    throw new ArgumentNullException(nameof(vmExtensionName));
                }

                return await TryGetAsync(vmExtensionName, expand, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
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
        public virtual async Task<Response<IReadOnlyList<VirtualMachineExtensionVirtualMachineScaleSet>>> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetContainer.GetAll");
            scope.Start();
            try
            {
                var response = await _restClient.GetAllAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value.Select(data => new VirtualMachineExtensionVirtualMachineScaleSet(Parent, data)).ToArray() as IReadOnlyList<VirtualMachineExtensionVirtualMachineScaleSet>, response.GetRawResponse());
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
        public virtual Response<IReadOnlyList<VirtualMachineExtensionVirtualMachineScaleSet>> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetContainer.GetAll");
            scope.Start();
            try
            {
                var response = _restClient.GetAll(Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken);
                return Response.FromValue(response.Value.Value.Select(data => new VirtualMachineExtensionVirtualMachineScaleSet(Parent, data)).ToArray() as IReadOnlyList<VirtualMachineExtensionVirtualMachineScaleSet>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="VirtualMachineExtensionVirtualMachineScaleSet" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> GetAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetContainer.GetAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachineExtensionVirtualMachineScaleSetOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="VirtualMachineExtensionVirtualMachineScaleSet" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> GetAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionVirtualMachineScaleSetContainer.GetAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachineExtensionVirtualMachineScaleSetOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceIdentifier, VirtualMachineExtensionVirtualMachineScaleSet, VirtualMachineExtensionData> Construct() { }
    }
}
