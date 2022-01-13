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
using ExactMatchInheritance.Models;

namespace ExactMatchInheritance
{
    /// <summary> A class representing collection of ExactMatchModel5 and their operations over its parent. </summary>
    public partial class ExactMatchModel5Collection : ArmCollection, IEnumerable<ExactMatchModel5>, IAsyncEnumerable<ExactMatchModel5>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ExactMatchModel5SRestOperations _exactMatchModel5sRestClient;

        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel5Collection"/> class for mocking. </summary>
        protected ExactMatchModel5Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel5Collection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ExactMatchModel5Collection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _exactMatchModel5sRestClient = new ExactMatchModel5SRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel5s/{exactMatchModel5sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ExactMatchModel5s_Put
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel5 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel5SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ExactMatchModel5SPutOperation CreateOrUpdate(bool waitForCompletion, string exactMatchModel5SName, ExactMatchModel5Data parameters, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel5SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel5SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _exactMatchModel5sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, exactMatchModel5SName, parameters, cancellationToken);
                var operation = new ExactMatchModel5SPutOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel5s/{exactMatchModel5sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ExactMatchModel5s_Put
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel5 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel5SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ExactMatchModel5SPutOperation> CreateOrUpdateAsync(bool waitForCompletion, string exactMatchModel5SName, ExactMatchModel5Data parameters, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel5SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel5SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _exactMatchModel5sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, exactMatchModel5SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ExactMatchModel5SPutOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel5s/{exactMatchModel5sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ExactMatchModel5s_Get
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel5SName"/> is null. </exception>
        public virtual Response<ExactMatchModel5> Get(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel5SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel5SName));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Collection.Get");
            scope.Start();
            try
            {
                var response = _exactMatchModel5sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, exactMatchModel5SName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ExactMatchModel5(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel5s/{exactMatchModel5sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ExactMatchModel5s_Get
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel5SName"/> is null. </exception>
        public async virtual Task<Response<ExactMatchModel5>> GetAsync(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel5SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel5SName));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Collection.Get");
            scope.Start();
            try
            {
                var response = await _exactMatchModel5sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, exactMatchModel5SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ExactMatchModel5(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel5SName"/> is null. </exception>
        public virtual Response<ExactMatchModel5> GetIfExists(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel5SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel5SName));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _exactMatchModel5sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, exactMatchModel5SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ExactMatchModel5>(null, response.GetRawResponse());
                return Response.FromValue(new ExactMatchModel5(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel5SName"/> is null. </exception>
        public async virtual Task<Response<ExactMatchModel5>> GetIfExistsAsync(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel5SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel5SName));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _exactMatchModel5sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, exactMatchModel5SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ExactMatchModel5>(null, response.GetRawResponse());
                return Response.FromValue(new ExactMatchModel5(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel5SName"/> is null. </exception>
        public virtual Response<bool> Exists(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel5SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel5SName));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Collection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(exactMatchModel5SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel5SName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel5SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel5SName));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Collection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(exactMatchModel5SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel5s
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ExactMatchModel5s_List
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ExactMatchModel5" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ExactMatchModel5> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ExactMatchModel5> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Collection.GetAll");
                scope.Start();
                try
                {
                    var response = _exactMatchModel5sRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ExactMatchModel5(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel5s
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ExactMatchModel5s_List
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ExactMatchModel5" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ExactMatchModel5> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ExactMatchModel5>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Collection.GetAll");
                scope.Start();
                try
                {
                    var response = await _exactMatchModel5sRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ExactMatchModel5(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Filters the list of <see cref="ExactMatchModel5" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel5.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ExactMatchModel5" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel5.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ExactMatchModel5> IEnumerable<ExactMatchModel5>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ExactMatchModel5> IAsyncEnumerable<ExactMatchModel5>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, ExactMatchModel5, ExactMatchModel5Data> Construct() { }
    }
}
