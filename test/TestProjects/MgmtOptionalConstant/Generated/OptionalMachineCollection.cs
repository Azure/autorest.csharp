// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using MgmtOptionalConstant.Models;

namespace MgmtOptionalConstant
{
    /// <summary>
    /// A class representing a collection of <see cref="OptionalMachineResource" /> and their operations.
    /// Each <see cref="OptionalMachineResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get an <see cref="OptionalMachineCollection" /> instance call the GetOptionalMachines method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class OptionalMachineCollection : ArmCollection, IEnumerable<OptionalMachineResource>, IAsyncEnumerable<OptionalMachineResource>
    {
        private readonly ClientDiagnostics _optionalMachineOptionalsClientDiagnostics;
        private readonly OptionalsRestOperations _optionalMachineOptionalsRestClient;

        /// <summary> Initializes a new instance of the <see cref="OptionalMachineCollection"/> class for mocking. </summary>
        protected OptionalMachineCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="OptionalMachineCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal OptionalMachineCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _optionalMachineOptionalsClientDiagnostics = new ClientDiagnostics("MgmtOptionalConstant", OptionalMachineResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(OptionalMachineResource.ResourceType, out string optionalMachineOptionalsApiVersion);
            _optionalMachineOptionalsRestClient = new OptionalsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, optionalMachineOptionalsApiVersion);
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
        /// The operation to create or update a virtual machine. Please note some properties can be set only during virtual machine creation.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}
        /// Operation Id: Optionals_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<OptionalMachineResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, OptionalMachineData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _optionalMachineOptionalsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtOptionalConstantArmOperation<OptionalMachineResource>(new OptionalMachineOperationSource(Client), _optionalMachineOptionalsClientDiagnostics, Pipeline, _optionalMachineOptionalsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, name, data).Request, response, OperationFinalStateVia.Location);
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
        /// The operation to create or update a virtual machine. Please note some properties can be set only during virtual machine creation.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}
        /// Operation Id: Optionals_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<OptionalMachineResource> CreateOrUpdate(WaitUntil waitUntil, string name, OptionalMachineData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _optionalMachineOptionalsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken);
                var operation = new MgmtOptionalConstantArmOperation<OptionalMachineResource>(new OptionalMachineOperationSource(Client), _optionalMachineOptionalsClientDiagnostics, Pipeline, _optionalMachineOptionalsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, name, data).Request, response, OperationFinalStateVia.Location);
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
        /// Retrieves information about the model view or the instance view of a virtual machine.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}
        /// Operation Id: Optionals_Get
        /// </summary>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<OptionalMachineResource>> GetAsync(string name, OptionalMachineExpand? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineCollection.Get");
            scope.Start();
            try
            {
                var response = await _optionalMachineOptionalsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new OptionalMachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about the model view or the instance view of a virtual machine.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}
        /// Operation Id: Optionals_Get
        /// </summary>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<OptionalMachineResource> Get(string name, OptionalMachineExpand? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineCollection.Get");
            scope.Start();
            try
            {
                var response = _optionalMachineOptionalsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new OptionalMachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified resource group. Use the nextLink property in the response to get the next page of virtual machines.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines
        /// Operation Id: Optionals_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OptionalMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<OptionalMachineResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<OptionalMachineResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _optionalMachineOptionalsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new OptionalMachineResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<OptionalMachineResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _optionalMachineOptionalsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new OptionalMachineResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified resource group. Use the nextLink property in the response to get the next page of virtual machines.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines
        /// Operation Id: Optionals_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OptionalMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<OptionalMachineResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<OptionalMachineResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _optionalMachineOptionalsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new OptionalMachineResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<OptionalMachineResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _optionalMachineOptionalsRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new OptionalMachineResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}
        /// Operation Id: Optionals_Get
        /// </summary>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, OptionalMachineExpand? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineCollection.Exists");
            scope.Start();
            try
            {
                var response = await _optionalMachineOptionalsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}
        /// Operation Id: Optionals_Get
        /// </summary>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, OptionalMachineExpand? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineCollection.Exists");
            scope.Start();
            try
            {
                var response = _optionalMachineOptionalsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<OptionalMachineResource> IEnumerable<OptionalMachineResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<OptionalMachineResource> IAsyncEnumerable<OptionalMachineResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
