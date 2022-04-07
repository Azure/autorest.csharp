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

namespace SubscriptionExtensions
{
    /// <summary>
    /// A class representing a collection of <see cref="OvenResource" /> and their operations.
    /// Each <see cref="OvenResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get an <see cref="OvenCollection" /> instance call the GetOvens method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class OvenCollection : ArmCollection, IEnumerable<OvenResource>, IAsyncEnumerable<OvenResource>
    {
        private readonly ClientDiagnostics _ovenClientDiagnostics;
        private readonly OvensRestOperations _ovenRestClient;

        /// <summary> Initializes a new instance of the <see cref="OvenCollection"/> class for mocking. </summary>
        protected OvenCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="OvenCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal OvenCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _ovenClientDiagnostics = new ClientDiagnostics("SubscriptionExtensions", OvenResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(OvenResource.ResourceType, out string ovenApiVersion);
            _ovenRestClient = new OvensRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, ovenApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/ovens/{ovenName}
        /// Operation Id: Ovens_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ovenName"> The name of the virtual machine. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ovenName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ovenName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<OvenResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ovenName, OvenData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ovenName, nameof(ovenName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _ovenClientDiagnostics.CreateScope("OvenCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _ovenRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, ovenName, data, cancellationToken).ConfigureAwait(false);
                var operation = new SubscriptionExtensionsArmOperation<OvenResource>(new OvenOperationSource(Client), _ovenClientDiagnostics, Pipeline, _ovenRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, ovenName, data).Request, response, OperationFinalStateVia.Location);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/ovens/{ovenName}
        /// Operation Id: Ovens_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ovenName"> The name of the virtual machine. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ovenName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ovenName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<OvenResource> CreateOrUpdate(WaitUntil waitUntil, string ovenName, OvenData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ovenName, nameof(ovenName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _ovenClientDiagnostics.CreateScope("OvenCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _ovenRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, ovenName, data, cancellationToken);
                var operation = new SubscriptionExtensionsArmOperation<OvenResource>(new OvenOperationSource(Client), _ovenClientDiagnostics, Pipeline, _ovenRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, ovenName, data).Request, response, OperationFinalStateVia.Location);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/ovens/{ovenName}
        /// Operation Id: Ovens_Get
        /// </summary>
        /// <param name="ovenName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ovenName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ovenName"/> is null. </exception>
        public virtual async Task<Response<OvenResource>> GetAsync(string ovenName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ovenName, nameof(ovenName));

            using var scope = _ovenClientDiagnostics.CreateScope("OvenCollection.Get");
            scope.Start();
            try
            {
                var response = await _ovenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, ovenName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new OvenResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/ovens/{ovenName}
        /// Operation Id: Ovens_Get
        /// </summary>
        /// <param name="ovenName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ovenName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ovenName"/> is null. </exception>
        public virtual Response<OvenResource> Get(string ovenName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ovenName, nameof(ovenName));

            using var scope = _ovenClientDiagnostics.CreateScope("OvenCollection.Get");
            scope.Start();
            try
            {
                var response = _ovenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, ovenName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new OvenResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/ovens
        /// Operation Id: Ovens_ListAll
        /// </summary>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OvenResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<OvenResource> GetAllAsync(string statusOnly = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<OvenResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _ovenClientDiagnostics.CreateScope("OvenCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _ovenRestClient.ListAllAsync(Id.SubscriptionId, Id.ResourceGroupName, statusOnly, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new OvenResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<OvenResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _ovenClientDiagnostics.CreateScope("OvenCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _ovenRestClient.ListAllNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, statusOnly, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new OvenResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/ovens
        /// Operation Id: Ovens_ListAll
        /// </summary>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OvenResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<OvenResource> GetAll(string statusOnly = null, CancellationToken cancellationToken = default)
        {
            Page<OvenResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _ovenClientDiagnostics.CreateScope("OvenCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _ovenRestClient.ListAll(Id.SubscriptionId, Id.ResourceGroupName, statusOnly, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new OvenResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<OvenResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _ovenClientDiagnostics.CreateScope("OvenCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _ovenRestClient.ListAllNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, statusOnly, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new OvenResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/ovens/{ovenName}
        /// Operation Id: Ovens_Get
        /// </summary>
        /// <param name="ovenName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ovenName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ovenName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string ovenName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ovenName, nameof(ovenName));

            using var scope = _ovenClientDiagnostics.CreateScope("OvenCollection.Exists");
            scope.Start();
            try
            {
                var response = await _ovenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, ovenName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/ovens/{ovenName}
        /// Operation Id: Ovens_Get
        /// </summary>
        /// <param name="ovenName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ovenName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ovenName"/> is null. </exception>
        public virtual Response<bool> Exists(string ovenName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ovenName, nameof(ovenName));

            using var scope = _ovenClientDiagnostics.CreateScope("OvenCollection.Exists");
            scope.Start();
            try
            {
                var response = _ovenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, ovenName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<OvenResource> IEnumerable<OvenResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<OvenResource> IAsyncEnumerable<OvenResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
