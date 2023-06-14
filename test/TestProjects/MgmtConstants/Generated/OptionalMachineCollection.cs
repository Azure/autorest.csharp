// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using MgmtConstants.Models;

namespace MgmtConstants
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
            _optionalMachineOptionalsClientDiagnostics = new ClientDiagnostics("MgmtConstants", OptionalMachineResource.ResourceType.Namespace, Diagnostics);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="optionalStringQuery"> The StringConstant to use. </param>
        /// <param name="optionalBooleanQuery"> The BooleanConstant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<OptionalMachineResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, OptionalMachineData data, StringConstant? optionalStringQuery = null, bool? optionalBooleanQuery = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _optionalMachineOptionalsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, name, data, optionalStringQuery, optionalBooleanQuery, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtConstantsArmOperation<OptionalMachineResource>(new OptionalMachineOperationSource(Client), _optionalMachineOptionalsClientDiagnostics, Pipeline, _optionalMachineOptionalsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, name, data, optionalStringQuery, optionalBooleanQuery).Request, response, OperationFinalStateVia.Location);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="optionalStringQuery"> The StringConstant to use. </param>
        /// <param name="optionalBooleanQuery"> The BooleanConstant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<OptionalMachineResource> CreateOrUpdate(WaitUntil waitUntil, string name, OptionalMachineData data, StringConstant? optionalStringQuery = null, bool? optionalBooleanQuery = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _optionalMachineOptionalsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, name, data, optionalStringQuery, optionalBooleanQuery, cancellationToken);
                var operation = new MgmtConstantsArmOperation<OptionalMachineResource>(new OptionalMachineOperationSource(Client), _optionalMachineOptionalsClientDiagnostics, Pipeline, _optionalMachineOptionalsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, name, data, optionalStringQuery, optionalBooleanQuery).Request, response, OperationFinalStateVia.Location);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Get</description>
        /// </item>
        /// </list>
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Get</description>
        /// </item>
        /// </list>
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OptionalMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<OptionalMachineResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _optionalMachineOptionalsRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _optionalMachineOptionalsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new OptionalMachineResource(Client, OptionalMachineData.DeserializeOptionalMachineData(e)), _optionalMachineOptionalsClientDiagnostics, Pipeline, "OptionalMachineCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified resource group. Use the nextLink property in the response to get the next page of virtual machines.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OptionalMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<OptionalMachineResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _optionalMachineOptionalsRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _optionalMachineOptionalsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new OptionalMachineResource(Client, OptionalMachineData.DeserializeOptionalMachineData(e)), _optionalMachineOptionalsClientDiagnostics, Pipeline, "OptionalMachineCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Get</description>
        /// </item>
        /// </list>
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Get</description>
        /// </item>
        /// </list>
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
