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
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of VirtualMachineScaleSetVM and their operations over its parent. </summary>
    public partial class VirtualMachineScaleSetVMContainer : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly VirtualMachineScaleSetVMsRestOperations _virtualMachineScaleSetVMsRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetVMContainer"/> class for mocking. </summary>
        protected VirtualMachineScaleSetVMContainer()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal VirtualMachineScaleSetVMContainer(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _virtualMachineScaleSetVMsRestClient = new VirtualMachineScaleSetVMsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => "Microsoft.Compute/virtualMachineScaleSets";

        // Container level operations.

        /// <summary> Updates a virtual machine of a VM scale set. </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Update Virtual Machine Scale Sets VM operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> or <paramref name="parameters"/> is null. </exception>
        public virtual VirtualMachineScaleSetVMUpdateOperation CreateOrUpdate(string instanceId, VirtualMachineScaleSetVMData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (instanceId == null)
            {
                throw new ArgumentNullException(nameof(instanceId));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVMContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMsRestClient.Update(Id.ResourceGroupName, Id.Name, instanceId, parameters, cancellationToken);
                var operation = new VirtualMachineScaleSetVMUpdateOperation(Parent, _clientDiagnostics, Pipeline, _virtualMachineScaleSetVMsRestClient.CreateUpdateRequest(Id.ResourceGroupName, Id.Name, instanceId, parameters).Request, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates a virtual machine of a VM scale set. </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Update Virtual Machine Scale Sets VM operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<VirtualMachineScaleSetVMUpdateOperation> CreateOrUpdateAsync(string instanceId, VirtualMachineScaleSetVMData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (instanceId == null)
            {
                throw new ArgumentNullException(nameof(instanceId));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVMContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMsRestClient.UpdateAsync(Id.ResourceGroupName, Id.Name, instanceId, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new VirtualMachineScaleSetVMUpdateOperation(Parent, _clientDiagnostics, Pipeline, _virtualMachineScaleSetVMsRestClient.CreateUpdateRequest(Id.ResourceGroupName, Id.Name, instanceId, parameters).Request, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a virtual machine from a VM scale set. </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public virtual Response<VirtualMachineScaleSetVM> Get(string instanceId, CancellationToken cancellationToken = default)
        {
            if (instanceId == null)
            {
                throw new ArgumentNullException(nameof(instanceId));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVMContainer.Get");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMsRestClient.Get(Id.ResourceGroupName, Id.Name, instanceId, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetVM(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a virtual machine from a VM scale set. </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public async virtual Task<Response<VirtualMachineScaleSetVM>> GetAsync(string instanceId, CancellationToken cancellationToken = default)
        {
            if (instanceId == null)
            {
                throw new ArgumentNullException(nameof(instanceId));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVMContainer.Get");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMsRestClient.GetAsync(Id.ResourceGroupName, Id.Name, instanceId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VirtualMachineScaleSetVM(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public virtual Response<VirtualMachineScaleSetVM> GetIfExists(string instanceId, CancellationToken cancellationToken = default)
        {
            if (instanceId == null)
            {
                throw new ArgumentNullException(nameof(instanceId));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVMContainer.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMsRestClient.Get(Id.ResourceGroupName, Id.Name, instanceId, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<VirtualMachineScaleSetVM>(null, response.GetRawResponse())
                    : Response.FromValue(new VirtualMachineScaleSetVM(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public async virtual Task<Response<VirtualMachineScaleSetVM>> GetIfExistsAsync(string instanceId, CancellationToken cancellationToken = default)
        {
            if (instanceId == null)
            {
                throw new ArgumentNullException(nameof(instanceId));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVMContainer.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMsRestClient.GetAsync(Id.ResourceGroupName, Id.Name, instanceId, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<VirtualMachineScaleSetVM>(null, response.GetRawResponse())
                    : Response.FromValue(new VirtualMachineScaleSetVM(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public virtual Response<bool> CheckIfExists(string instanceId, CancellationToken cancellationToken = default)
        {
            if (instanceId == null)
            {
                throw new ArgumentNullException(nameof(instanceId));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVMContainer.CheckIfExists");
            scope.Start();
            try
            {
                var response = GetIfExists(instanceId, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string instanceId, CancellationToken cancellationToken = default)
        {
            if (instanceId == null)
            {
                throw new ArgumentNullException(nameof(instanceId));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVMContainer.CheckIfExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(instanceId, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list of all virtual machines in a VM scale sets. </summary>
        /// <param name="filter"> The filter to apply to the operation. Allowed values are &apos;startswith(instanceView/statuses/code, &apos;PowerState&apos;) eq true&apos;, &apos;properties/latestModelApplied eq true&apos;, &apos;properties/latestModelApplied eq false&apos;. </param>
        /// <param name="select"> The list parameters. Allowed values are &apos;instanceView&apos;, &apos;instanceView/statuses&apos;. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineScaleSetVM" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineScaleSetVM> GetAll(string filter = null, string select = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Page<VirtualMachineScaleSetVM> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVMContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineScaleSetVMsRestClient.List(Id.ResourceGroupName, Id.Name, filter, select, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVM(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualMachineScaleSetVM> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVMContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineScaleSetVMsRestClient.ListNextPage(nextLink, Id.ResourceGroupName, Id.Name, filter, select, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVM(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets a list of all virtual machines in a VM scale sets. </summary>
        /// <param name="filter"> The filter to apply to the operation. Allowed values are &apos;startswith(instanceView/statuses/code, &apos;PowerState&apos;) eq true&apos;, &apos;properties/latestModelApplied eq true&apos;, &apos;properties/latestModelApplied eq false&apos;. </param>
        /// <param name="select"> The list parameters. Allowed values are &apos;instanceView&apos;, &apos;instanceView/statuses&apos;. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSetVM" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineScaleSetVM> GetAllAsync(string filter = null, string select = null, string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualMachineScaleSetVM>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVMContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineScaleSetVMsRestClient.ListAsync(Id.ResourceGroupName, Id.Name, filter, select, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVM(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualMachineScaleSetVM>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVMContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineScaleSetVMsRestClient.ListNextPageAsync(nextLink, Id.ResourceGroupName, Id.Name, filter, select, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVM(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, VirtualMachineScaleSetVM, VirtualMachineScaleSetVMData> Construct() { }
    }
}
