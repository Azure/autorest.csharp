// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtAcronymMapping
{
    /// <summary>
    /// A class representing a collection of <see cref="VirtualMachineScaleSetResource"/> and their operations.
    /// Each <see cref="VirtualMachineScaleSetResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="VirtualMachineScaleSetCollection"/> instance call the GetVirtualMachineScaleSets method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class VirtualMachineScaleSetCollection : ArmCollection, IEnumerable<VirtualMachineScaleSetResource>, IAsyncEnumerable<VirtualMachineScaleSetResource>
    {
        private readonly ClientDiagnostics _virtualMachineScaleSetClientDiagnostics;
        private readonly VirtualMachineScaleSetsRestOperations _virtualMachineScaleSetRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetCollection"/> class for mocking. </summary>
        protected VirtualMachineScaleSetCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VirtualMachineScaleSetCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualMachineScaleSetClientDiagnostics = new ClientDiagnostics("MgmtAcronymMapping", VirtualMachineScaleSetResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(VirtualMachineScaleSetResource.ResourceType, out string virtualMachineScaleSetApiVersion);
            _virtualMachineScaleSetRestClient = new VirtualMachineScaleSetsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, virtualMachineScaleSetApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VirtualMachineScaleSetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set to create or update. </param>
        /// <param name="data"> The scale set object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmScaleSetName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<VirtualMachineScaleSetResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string vmScaleSetName, VirtualMachineScaleSetData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, vmScaleSetName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtAcronymMappingArmOperation<VirtualMachineScaleSetResource>(new VirtualMachineScaleSetOperationSource(Client), _virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, vmScaleSetName, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VirtualMachineScaleSetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set to create or update. </param>
        /// <param name="data"> The scale set object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmScaleSetName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<VirtualMachineScaleSetResource> CreateOrUpdate(WaitUntil waitUntil, string vmScaleSetName, VirtualMachineScaleSetData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, vmScaleSetName, data, cancellationToken);
                var operation = new MgmtAcronymMappingArmOperation<VirtualMachineScaleSetResource>(new VirtualMachineScaleSetOperationSource(Client), _virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, vmScaleSetName, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Display information about a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VirtualMachineScaleSetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vmScaleSetName"> The name of the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmScaleSetName"/> is null. </exception>
        public virtual async Task<Response<VirtualMachineScaleSetResource>> GetAsync(string vmScaleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, vmScaleSetName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Display information about a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VirtualMachineScaleSetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vmScaleSetName"> The name of the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmScaleSetName"/> is null. </exception>
        public virtual Response<VirtualMachineScaleSetResource> Get(string vmScaleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, vmScaleSetName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all VM scale sets under a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VirtualMachineScaleSetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSetResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineScaleSetResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineScaleSetResource(Client, VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(e)), _virtualMachineScaleSetClientDiagnostics, Pipeline, "VirtualMachineScaleSetCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets a list of all VM scale sets under a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VirtualMachineScaleSetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineScaleSetResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineScaleSetResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineScaleSetResource(Client, VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(e)), _virtualMachineScaleSetClientDiagnostics, Pipeline, "VirtualMachineScaleSetCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VirtualMachineScaleSetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vmScaleSetName"> The name of the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmScaleSetName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string vmScaleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetCollection.Exists");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, vmScaleSetName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VirtualMachineScaleSetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vmScaleSetName"> The name of the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmScaleSetName"/> is null. </exception>
        public virtual Response<bool> Exists(string vmScaleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetCollection.Exists");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, vmScaleSetName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VirtualMachineScaleSetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vmScaleSetName"> The name of the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmScaleSetName"/> is null. </exception>
        public virtual async Task<NullableResponse<VirtualMachineScaleSetResource>> GetIfExistsAsync(string vmScaleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, vmScaleSetName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<VirtualMachineScaleSetResource>(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="VirtualMachineScaleSetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vmScaleSetName"> The name of the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmScaleSetName"/> is null. </exception>
        public virtual NullableResponse<VirtualMachineScaleSetResource> GetIfExists(string vmScaleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, vmScaleSetName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<VirtualMachineScaleSetResource>(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VirtualMachineScaleSetResource> IEnumerable<VirtualMachineScaleSetResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VirtualMachineScaleSetResource> IAsyncEnumerable<VirtualMachineScaleSetResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
