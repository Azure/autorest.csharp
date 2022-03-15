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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace SubscriptionExtensions
{
    /// <summary> A class representing collection of Oven and their operations over its parent. </summary>
    public partial class OvenCollection : ArmCollection, IEnumerable<OvenResource>, IAsyncEnumerable<OvenResource>
    {
        private readonly ClientDiagnostics _ovenResourceOvensClientDiagnostics;
        private readonly OvensRestOperations _ovenResourceOvensRestClient;

        /// <summary> Initializes a new instance of the <see cref="OvenCollection"/> class for mocking. </summary>
        protected OvenCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="OvenCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal OvenCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _ovenResourceOvensClientDiagnostics = new ClientDiagnostics("SubscriptionExtensions", OvenResource.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(OvenResource.ResourceType, out string ovenResourceOvensApiVersion);
            _ovenResourceOvensRestClient = new OvensRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, ovenResourceOvensApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// The operation to create or update a virtual machine. Please note some properties can be set only during virtual machine creation.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/ovens/{ovenName}
        /// Operation Id: Ovens_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ovenName"> The name of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ovenName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ovenName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<OvenResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ovenName, OvenResourceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ovenName, nameof(ovenName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _ovenResourceOvensClientDiagnostics.CreateScope("OvenCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _ovenResourceOvensRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, ovenName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SubscriptionExtensionsArmOperation<OvenResource>(new OvenResourceOperationSource(Client), _ovenResourceOvensClientDiagnostics, Pipeline, _ovenResourceOvensRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, ovenName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ovenName"> The name of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ovenName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ovenName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<OvenResource> CreateOrUpdate(WaitUntil waitUntil, string ovenName, OvenResourceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ovenName, nameof(ovenName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _ovenResourceOvensClientDiagnostics.CreateScope("OvenCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _ovenResourceOvensRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, ovenName, parameters, cancellationToken);
                var operation = new SubscriptionExtensionsArmOperation<OvenResource>(new OvenResourceOperationSource(Client), _ovenResourceOvensClientDiagnostics, Pipeline, _ovenResourceOvensRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, ovenName, parameters).Request, response, OperationFinalStateVia.Location);
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

            using var scope = _ovenResourceOvensClientDiagnostics.CreateScope("OvenCollection.Get");
            scope.Start();
            try
            {
                var response = await _ovenResourceOvensRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, ovenName, cancellationToken).ConfigureAwait(false);
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

            using var scope = _ovenResourceOvensClientDiagnostics.CreateScope("OvenCollection.Get");
            scope.Start();
            try
            {
                var response = _ovenResourceOvensRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, ovenName, cancellationToken);
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
                using var scope = _ovenResourceOvensClientDiagnostics.CreateScope("OvenCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _ovenResourceOvensRestClient.ListAllAsync(Id.SubscriptionId, Id.ResourceGroupName, statusOnly, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _ovenResourceOvensClientDiagnostics.CreateScope("OvenCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _ovenResourceOvensRestClient.ListAllNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, statusOnly, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _ovenResourceOvensClientDiagnostics.CreateScope("OvenCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _ovenResourceOvensRestClient.ListAll(Id.SubscriptionId, Id.ResourceGroupName, statusOnly, cancellationToken: cancellationToken);
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
                using var scope = _ovenResourceOvensClientDiagnostics.CreateScope("OvenCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _ovenResourceOvensRestClient.ListAllNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, statusOnly, cancellationToken: cancellationToken);
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

            using var scope = _ovenResourceOvensClientDiagnostics.CreateScope("OvenCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(ovenName, cancellationToken: cancellationToken).ConfigureAwait(false);
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

            using var scope = _ovenResourceOvensClientDiagnostics.CreateScope("OvenCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(ovenName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/ovens/{ovenName}
        /// Operation Id: Ovens_Get
        /// </summary>
        /// <param name="ovenName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ovenName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ovenName"/> is null. </exception>
        public virtual async Task<Response<OvenResource>> GetIfExistsAsync(string ovenName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ovenName, nameof(ovenName));

            using var scope = _ovenResourceOvensClientDiagnostics.CreateScope("OvenCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _ovenResourceOvensRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, ovenName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<OvenResource>(null, response.GetRawResponse());
                return Response.FromValue(new OvenResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/ovens/{ovenName}
        /// Operation Id: Ovens_Get
        /// </summary>
        /// <param name="ovenName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ovenName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ovenName"/> is null. </exception>
        public virtual Response<OvenResource> GetIfExists(string ovenName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ovenName, nameof(ovenName));

            using var scope = _ovenResourceOvensClientDiagnostics.CreateScope("OvenCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _ovenResourceOvensRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, ovenName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<OvenResource>(null, response.GetRawResponse());
                return Response.FromValue(new OvenResource(Client, response.Value), response.GetRawResponse());
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
