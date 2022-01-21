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
using MgmtMultipleParentResource.Models;

namespace MgmtMultipleParentResource
{
    /// <summary> A class representing collection of AnotherParent and their operations over its parent. </summary>
    public partial class AnotherParentCollection : ArmCollection, IEnumerable<AnotherParent>, IAsyncEnumerable<AnotherParent>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly AnotherParentsRestOperations _anotherParentsRestClient;

        /// <summary> Initializes a new instance of the <see cref="AnotherParentCollection"/> class for mocking. </summary>
        protected AnotherParentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AnotherParentCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal AnotherParentCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics("MgmtMultipleParentResource", AnotherParent.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(AnotherParent.ResourceType, out string apiVersion);
            _anotherParentsRestClient = new AnotherParentsRestOperations(_clientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, apiVersion);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: AnotherParents_CreateOrUpdate
        /// <summary> The operation to create or update the run command. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="anotherName"> The name of the virtual machine where the run command should be created or updated. </param>
        /// <param name="anotherBody"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="anotherName"/> or <paramref name="anotherBody"/> is null. </exception>
        public virtual AnotherParentCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string anotherName, AnotherParentData anotherBody, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anotherName, nameof(anotherName));
            if (anotherBody == null)
            {
                throw new ArgumentNullException(nameof(anotherBody));
            }

            using var scope = _clientDiagnostics.CreateScope("AnotherParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _anotherParentsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, anotherName, anotherBody, cancellationToken);
                var operation = new AnotherParentCreateOrUpdateOperation(ArmClient, _clientDiagnostics, Pipeline, _anotherParentsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, anotherName, anotherBody).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: AnotherParents_CreateOrUpdate
        /// <summary> The operation to create or update the run command. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="anotherName"> The name of the virtual machine where the run command should be created or updated. </param>
        /// <param name="anotherBody"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="anotherName"/> or <paramref name="anotherBody"/> is null. </exception>
        public async virtual Task<AnotherParentCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string anotherName, AnotherParentData anotherBody, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anotherName, nameof(anotherName));
            if (anotherBody == null)
            {
                throw new ArgumentNullException(nameof(anotherBody));
            }

            using var scope = _clientDiagnostics.CreateScope("AnotherParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _anotherParentsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, anotherName, anotherBody, cancellationToken).ConfigureAwait(false);
                var operation = new AnotherParentCreateOrUpdateOperation(ArmClient, _clientDiagnostics, Pipeline, _anotherParentsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, anotherName, anotherBody).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: AnotherParents_Get
        /// <summary> The operation to get the run command. </summary>
        /// <param name="anotherName"> The name of the virtual machine containing the run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="anotherName"/> is null. </exception>
        public virtual Response<AnotherParent> Get(string anotherName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anotherName, nameof(anotherName));

            using var scope = _clientDiagnostics.CreateScope("AnotherParentCollection.Get");
            scope.Start();
            try
            {
                var response = _anotherParentsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, anotherName, expand, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AnotherParent(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: AnotherParents_Get
        /// <summary> The operation to get the run command. </summary>
        /// <param name="anotherName"> The name of the virtual machine containing the run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="anotherName"/> is null. </exception>
        public async virtual Task<Response<AnotherParent>> GetAsync(string anotherName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anotherName, nameof(anotherName));

            using var scope = _clientDiagnostics.CreateScope("AnotherParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _anotherParentsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, anotherName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new AnotherParent(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="anotherName"> The name of the virtual machine containing the run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="anotherName"/> is null. </exception>
        public virtual Response<AnotherParent> GetIfExists(string anotherName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anotherName, nameof(anotherName));

            using var scope = _clientDiagnostics.CreateScope("AnotherParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _anotherParentsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, anotherName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<AnotherParent>(null, response.GetRawResponse());
                return Response.FromValue(new AnotherParent(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="anotherName"> The name of the virtual machine containing the run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="anotherName"/> is null. </exception>
        public async virtual Task<Response<AnotherParent>> GetIfExistsAsync(string anotherName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anotherName, nameof(anotherName));

            using var scope = _clientDiagnostics.CreateScope("AnotherParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _anotherParentsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, anotherName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<AnotherParent>(null, response.GetRawResponse());
                return Response.FromValue(new AnotherParent(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="anotherName"> The name of the virtual machine containing the run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="anotherName"/> is null. </exception>
        public virtual Response<bool> Exists(string anotherName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anotherName, nameof(anotherName));

            using var scope = _clientDiagnostics.CreateScope("AnotherParentCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(anotherName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="anotherName"> The name of the virtual machine containing the run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="anotherName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string anotherName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anotherName, nameof(anotherName));

            using var scope = _clientDiagnostics.CreateScope("AnotherParentCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(anotherName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: AnotherParents_List
        /// <summary> The operation to get all run commands of a Virtual Machine. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AnotherParent" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AnotherParent> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<AnotherParent> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("AnotherParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _anotherParentsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AnotherParent(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<AnotherParent> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("AnotherParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _anotherParentsRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AnotherParent(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: AnotherParents_List
        /// <summary> The operation to get all run commands of a Virtual Machine. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AnotherParent" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AnotherParent> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<AnotherParent>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("AnotherParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _anotherParentsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AnotherParent(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<AnotherParent>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("AnotherParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _anotherParentsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AnotherParent(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="AnotherParent" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AnotherParentCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(AnotherParent.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="AnotherParent" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AnotherParentCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(AnotherParent.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AnotherParent> IEnumerable<AnotherParent>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AnotherParent> IAsyncEnumerable<AnotherParent>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
