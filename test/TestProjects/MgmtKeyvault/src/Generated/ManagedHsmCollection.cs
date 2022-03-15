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

namespace MgmtKeyvault
{
    /// <summary> A class representing collection of ManagedHsm and their operations over its parent. </summary>
    public partial class ManagedHsmCollection : ArmCollection, IEnumerable<ManagedHsmResource>, IAsyncEnumerable<ManagedHsmResource>
    {
        private readonly ClientDiagnostics _managedHsmResourceManagedHsmsClientDiagnostics;
        private readonly ManagedHsmsRestOperations _managedHsmResourceManagedHsmsRestClient;

        /// <summary> Initializes a new instance of the <see cref="ManagedHsmCollection"/> class for mocking. </summary>
        protected ManagedHsmCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ManagedHsmCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ManagedHsmCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managedHsmResourceManagedHsmsClientDiagnostics = new ClientDiagnostics("MgmtKeyvault", ManagedHsmResource.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ManagedHsmResource.ResourceType, out string managedHsmResourceManagedHsmsApiVersion);
            _managedHsmResourceManagedHsmsRestClient = new ManagedHsmsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, managedHsmResourceManagedHsmsApiVersion);
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
        /// Create or update a managed HSM Pool in the specified subscription.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}
        /// Operation Id: ManagedHsms_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> Name of the managed HSM Pool. </param>
        /// <param name="parameters"> Parameters to create or update the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<ManagedHsmResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, ManagedHsmResourceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _managedHsmResourceManagedHsmsClientDiagnostics.CreateScope("ManagedHsmCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _managedHsmResourceManagedHsmsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, name, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtKeyvaultArmOperation<ManagedHsmResource>(new ManagedHsmResourceOperationSource(Client), _managedHsmResourceManagedHsmsClientDiagnostics, Pipeline, _managedHsmResourceManagedHsmsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, name, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Create or update a managed HSM Pool in the specified subscription.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}
        /// Operation Id: ManagedHsms_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> Name of the managed HSM Pool. </param>
        /// <param name="parameters"> Parameters to create or update the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ManagedHsmResource> CreateOrUpdate(WaitUntil waitUntil, string name, ManagedHsmResourceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _managedHsmResourceManagedHsmsClientDiagnostics.CreateScope("ManagedHsmCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _managedHsmResourceManagedHsmsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, name, parameters, cancellationToken);
                var operation = new MgmtKeyvaultArmOperation<ManagedHsmResource>(new ManagedHsmResourceOperationSource(Client), _managedHsmResourceManagedHsmsClientDiagnostics, Pipeline, _managedHsmResourceManagedHsmsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, name, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the specified managed HSM Pool.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}
        /// Operation Id: ManagedHsms_Get
        /// </summary>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<ManagedHsmResource>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _managedHsmResourceManagedHsmsClientDiagnostics.CreateScope("ManagedHsmCollection.Get");
            scope.Start();
            try
            {
                var response = await _managedHsmResourceManagedHsmsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedHsmResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified managed HSM Pool.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}
        /// Operation Id: ManagedHsms_Get
        /// </summary>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<ManagedHsmResource> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _managedHsmResourceManagedHsmsClientDiagnostics.CreateScope("ManagedHsmCollection.Get");
            scope.Start();
            try
            {
                var response = _managedHsmResourceManagedHsmsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedHsmResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The List operation gets information about the managed HSM Pools associated with the subscription and within the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs
        /// Operation Id: ManagedHsms_ListByResourceGroup
        /// </summary>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedHsmResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagedHsmResource> GetAllAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedHsmResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedHsmResourceManagedHsmsClientDiagnostics.CreateScope("ManagedHsmCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managedHsmResourceManagedHsmsRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedHsmResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagedHsmResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedHsmResourceManagedHsmsClientDiagnostics.CreateScope("ManagedHsmCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managedHsmResourceManagedHsmsRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedHsmResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// The List operation gets information about the managed HSM Pools associated with the subscription and within the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs
        /// Operation Id: ManagedHsms_ListByResourceGroup
        /// </summary>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedHsmResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagedHsmResource> GetAll(int? top = null, CancellationToken cancellationToken = default)
        {
            Page<ManagedHsmResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedHsmResourceManagedHsmsClientDiagnostics.CreateScope("ManagedHsmCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managedHsmResourceManagedHsmsRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedHsmResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagedHsmResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedHsmResourceManagedHsmsClientDiagnostics.CreateScope("ManagedHsmCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managedHsmResourceManagedHsmsRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedHsmResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}
        /// Operation Id: ManagedHsms_Get
        /// </summary>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _managedHsmResourceManagedHsmsClientDiagnostics.CreateScope("ManagedHsmCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}
        /// Operation Id: ManagedHsms_Get
        /// </summary>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _managedHsmResourceManagedHsmsClientDiagnostics.CreateScope("ManagedHsmCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(name, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}
        /// Operation Id: ManagedHsms_Get
        /// </summary>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<ManagedHsmResource>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _managedHsmResourceManagedHsmsClientDiagnostics.CreateScope("ManagedHsmCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _managedHsmResourceManagedHsmsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ManagedHsmResource>(null, response.GetRawResponse());
                return Response.FromValue(new ManagedHsmResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}
        /// Operation Id: ManagedHsms_Get
        /// </summary>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<ManagedHsmResource> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _managedHsmResourceManagedHsmsClientDiagnostics.CreateScope("ManagedHsmCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _managedHsmResourceManagedHsmsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ManagedHsmResource>(null, response.GetRawResponse());
                return Response.FromValue(new ManagedHsmResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ManagedHsmResource> IEnumerable<ManagedHsmResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ManagedHsmResource> IAsyncEnumerable<ManagedHsmResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
