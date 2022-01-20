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
using MgmtKeyvault.Models;

namespace MgmtKeyvault
{
    /// <summary> A class representing collection of ManagedHsm and their operations over its parent. </summary>
    public partial class ManagedHsmCollection : ArmCollection, IEnumerable<ManagedHsm>, IAsyncEnumerable<ManagedHsm>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ManagedHsmsRestOperations _managedHsmsRestClient;

        /// <summary> Initializes a new instance of the <see cref="ManagedHsmCollection"/> class for mocking. </summary>
        protected ManagedHsmCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ManagedHsmCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ManagedHsmCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics("MgmtKeyvault", ManagedHsm.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(ManagedHsm.ResourceType, out string apiVersion);
            _managedHsmsRestClient = new ManagedHsmsRestOperations(_clientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, apiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ManagedHsms_CreateOrUpdate
        /// <summary> Create or update a managed HSM Pool in the specified subscription. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="name"> Name of the managed HSM Pool. </param>
        /// <param name="parameters"> Parameters to create or update the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is null or empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ManagedHsmCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string name, ManagedHsmData parameters, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"Parameter {nameof(name)} cannot be null or empty", nameof(name));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagedHsmCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _managedHsmsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, name, parameters, cancellationToken);
                var operation = new ManagedHsmCreateOrUpdateOperation(ArmClient, _clientDiagnostics, Pipeline, _managedHsmsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, name, parameters).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ManagedHsms_CreateOrUpdate
        /// <summary> Create or update a managed HSM Pool in the specified subscription. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="name"> Name of the managed HSM Pool. </param>
        /// <param name="parameters"> Parameters to create or update the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is null or empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ManagedHsmCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string name, ManagedHsmData parameters, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"Parameter {nameof(name)} cannot be null or empty", nameof(name));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagedHsmCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _managedHsmsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, name, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ManagedHsmCreateOrUpdateOperation(ArmClient, _clientDiagnostics, Pipeline, _managedHsmsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, name, parameters).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ManagedHsms_Get
        /// <summary> Gets the specified managed HSM Pool. </summary>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is null or empty. </exception>
        public virtual Response<ManagedHsm> Get(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"Parameter {nameof(name)} cannot be null or empty", nameof(name));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagedHsmCollection.Get");
            scope.Start();
            try
            {
                var response = _managedHsmsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedHsm(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ManagedHsms_Get
        /// <summary> Gets the specified managed HSM Pool. </summary>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is null or empty. </exception>
        public async virtual Task<Response<ManagedHsm>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"Parameter {nameof(name)} cannot be null or empty", nameof(name));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagedHsmCollection.Get");
            scope.Start();
            try
            {
                var response = await _managedHsmsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ManagedHsm(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is null or empty. </exception>
        public virtual Response<ManagedHsm> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"Parameter {nameof(name)} cannot be null or empty", nameof(name));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagedHsmCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _managedHsmsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ManagedHsm>(null, response.GetRawResponse());
                return Response.FromValue(new ManagedHsm(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is null or empty. </exception>
        public async virtual Task<Response<ManagedHsm>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"Parameter {nameof(name)} cannot be null or empty", nameof(name));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagedHsmCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _managedHsmsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ManagedHsm>(null, response.GetRawResponse());
                return Response.FromValue(new ManagedHsm(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is null or empty. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"Parameter {nameof(name)} cannot be null or empty", nameof(name));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagedHsmCollection.Exists");
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

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is null or empty. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"Parameter {nameof(name)} cannot be null or empty", nameof(name));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagedHsmCollection.Exists");
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ManagedHsms_ListByResourceGroup
        /// <summary> The List operation gets information about the managed HSM Pools associated with the subscription and within the specified resource group. </summary>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedHsm" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagedHsm> GetAll(int? top = null, CancellationToken cancellationToken = default)
        {
            Page<ManagedHsm> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagedHsmCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managedHsmsRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedHsm(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagedHsm> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagedHsmCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managedHsmsRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedHsm(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ManagedHsms_ListByResourceGroup
        /// <summary> The List operation gets information about the managed HSM Pools associated with the subscription and within the specified resource group. </summary>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedHsm" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagedHsm> GetAllAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedHsm>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagedHsmCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managedHsmsRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedHsm(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagedHsm>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagedHsmCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managedHsmsRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedHsm(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="ManagedHsm" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagedHsmCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ManagedHsm.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ManagedHsm" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagedHsmCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ManagedHsm.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ManagedHsm> IEnumerable<ManagedHsm>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ManagedHsm> IAsyncEnumerable<ManagedHsm>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
