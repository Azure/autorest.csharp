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
using MgmtExtensionCommonRestOperation.Models;

namespace MgmtExtensionCommonRestOperation
{
    /// <summary> A class representing collection of TypeOne and their operations over its parent. </summary>
    public partial class TypeOneCollection : ArmCollection, IEnumerable<TypeOne>, IAsyncEnumerable<TypeOne>
    {
        private readonly ClientDiagnostics _typeOneClientDiagnostics;
        private readonly CommonRestOperations _typeOneRestClient;

        /// <summary> Initializes a new instance of the <see cref="TypeOneCollection"/> class for mocking. </summary>
        protected TypeOneCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TypeOneCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal TypeOneCollection(ArmResource parent) : base(parent)
        {
            _typeOneClientDiagnostics = new ClientDiagnostics("MgmtExtensionCommonRestOperation", TypeOne.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(TypeOne.ResourceType, out string typeOneApiVersion);
            _typeOneRestClient = new CommonRestOperations(_typeOneClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, typeOneApiVersion);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Common_CreateOrUpdateTypeOne
        /// <summary> Description for Validate information for a certificate order. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="typeOne"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> or <paramref name="typeOne"/> is null. </exception>
        public virtual TypeOneCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string typeOneName, TypeOneData typeOne, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));
            if (typeOne == null)
            {
                throw new ArgumentNullException(nameof(typeOne));
            }

            using var scope = _typeOneClientDiagnostics.CreateScope("TypeOneCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _typeOneRestClient.CreateOrUpdateTypeOne(Id.SubscriptionId, Id.ResourceGroupName, typeOneName, typeOne, cancellationToken);
                var operation = new TypeOneCreateOrUpdateOperation(ArmClient, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Common_CreateOrUpdateTypeOne
        /// <summary> Description for Validate information for a certificate order. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="typeOne"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> or <paramref name="typeOne"/> is null. </exception>
        public async virtual Task<TypeOneCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string typeOneName, TypeOneData typeOne, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));
            if (typeOne == null)
            {
                throw new ArgumentNullException(nameof(typeOne));
            }

            using var scope = _typeOneClientDiagnostics.CreateScope("TypeOneCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _typeOneRestClient.CreateOrUpdateTypeOneAsync(Id.SubscriptionId, Id.ResourceGroupName, typeOneName, typeOne, cancellationToken).ConfigureAwait(false);
                var operation = new TypeOneCreateOrUpdateOperation(ArmClient, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Common_GetTypeOne
        /// <summary> Description for Validate information for a certificate order. </summary>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        public virtual Response<TypeOne> Get(string typeOneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));

            using var scope = _typeOneClientDiagnostics.CreateScope("TypeOneCollection.Get");
            scope.Start();
            try
            {
                var response = _typeOneRestClient.GetTypeOne(Id.SubscriptionId, Id.ResourceGroupName, typeOneName, cancellationToken);
                if (response.Value == null)
                    throw _typeOneClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TypeOne(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Common_GetTypeOne
        /// <summary> Description for Validate information for a certificate order. </summary>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        public async virtual Task<Response<TypeOne>> GetAsync(string typeOneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));

            using var scope = _typeOneClientDiagnostics.CreateScope("TypeOneCollection.Get");
            scope.Start();
            try
            {
                var response = await _typeOneRestClient.GetTypeOneAsync(Id.SubscriptionId, Id.ResourceGroupName, typeOneName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _typeOneClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new TypeOne(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        public virtual Response<TypeOne> GetIfExists(string typeOneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));

            using var scope = _typeOneClientDiagnostics.CreateScope("TypeOneCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _typeOneRestClient.GetTypeOne(Id.SubscriptionId, Id.ResourceGroupName, typeOneName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<TypeOne>(null, response.GetRawResponse());
                return Response.FromValue(new TypeOne(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        public async virtual Task<Response<TypeOne>> GetIfExistsAsync(string typeOneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));

            using var scope = _typeOneClientDiagnostics.CreateScope("TypeOneCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _typeOneRestClient.GetTypeOneAsync(Id.SubscriptionId, Id.ResourceGroupName, typeOneName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<TypeOne>(null, response.GetRawResponse());
                return Response.FromValue(new TypeOne(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        public virtual Response<bool> Exists(string typeOneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));

            using var scope = _typeOneClientDiagnostics.CreateScope("TypeOneCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(typeOneName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string typeOneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));

            using var scope = _typeOneClientDiagnostics.CreateScope("TypeOneCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(typeOneName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Common_ListTypeOnes
        /// <summary> Description for Validate information for a certificate order. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TypeOne" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TypeOne> GetAll(CancellationToken cancellationToken = default)
        {
            Page<TypeOne> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _typeOneClientDiagnostics.CreateScope("TypeOneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _typeOneRestClient.ListTypeOnes(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TypeOne(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Common_ListTypeOnes
        /// <summary> Description for Validate information for a certificate order. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TypeOne" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TypeOne> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<TypeOne>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _typeOneClientDiagnostics.CreateScope("TypeOneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _typeOneRestClient.ListTypeOnesAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TypeOne(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Filters the list of <see cref="TypeOne" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _typeOneClientDiagnostics.CreateScope("TypeOneCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(TypeOne.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="TypeOne" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _typeOneClientDiagnostics.CreateScope("TypeOneCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(TypeOne.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TypeOne> IEnumerable<TypeOne>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TypeOne> IAsyncEnumerable<TypeOne>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
