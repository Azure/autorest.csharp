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
using SubscriptionExtensions.Models;

namespace SubscriptionExtensions
{
    /// <summary> A class representing collection of Toaster and their operations over its parent. </summary>
    public partial class ToasterCollection : ArmCollection, IEnumerable<Toaster>, IAsyncEnumerable<Toaster>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ToastersRestOperations _toastersRestClient;

        /// <summary> Initializes a new instance of the <see cref="ToasterCollection"/> class for mocking. </summary>
        protected ToasterCollection()
        {
        }

        /// <summary> Initializes a new instance of ToasterCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ToasterCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _toastersRestClient = new ToastersRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters/{toasterName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Toasters_CreateOrUpdate
        /// <summary> Create or update an availability set. </summary>
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ToasterCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string toasterName, ToasterData parameters, CancellationToken cancellationToken = default)
        {
            if (toasterName == null)
            {
                throw new ArgumentNullException(nameof(toasterName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ToasterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _toastersRestClient.CreateOrUpdate(Id.SubscriptionId, toasterName, parameters, cancellationToken);
                var operation = new ToasterCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters/{toasterName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Toasters_CreateOrUpdate
        /// <summary> Create or update an availability set. </summary>
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ToasterCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string toasterName, ToasterData parameters, CancellationToken cancellationToken = default)
        {
            if (toasterName == null)
            {
                throw new ArgumentNullException(nameof(toasterName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ToasterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _toastersRestClient.CreateOrUpdateAsync(Id.SubscriptionId, toasterName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ToasterCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters/{toasterName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Toasters_Get
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> is null. </exception>
        public virtual Response<Toaster> Get(string toasterName, CancellationToken cancellationToken = default)
        {
            if (toasterName == null)
            {
                throw new ArgumentNullException(nameof(toasterName));
            }

            using var scope = _clientDiagnostics.CreateScope("ToasterCollection.Get");
            scope.Start();
            try
            {
                var response = _toastersRestClient.Get(Id.SubscriptionId, toasterName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Toaster(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters/{toasterName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Toasters_Get
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> is null. </exception>
        public async virtual Task<Response<Toaster>> GetAsync(string toasterName, CancellationToken cancellationToken = default)
        {
            if (toasterName == null)
            {
                throw new ArgumentNullException(nameof(toasterName));
            }

            using var scope = _clientDiagnostics.CreateScope("ToasterCollection.Get");
            scope.Start();
            try
            {
                var response = await _toastersRestClient.GetAsync(Id.SubscriptionId, toasterName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Toaster(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> is null. </exception>
        public virtual Response<Toaster> GetIfExists(string toasterName, CancellationToken cancellationToken = default)
        {
            if (toasterName == null)
            {
                throw new ArgumentNullException(nameof(toasterName));
            }

            using var scope = _clientDiagnostics.CreateScope("ToasterCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _toastersRestClient.Get(Id.SubscriptionId, toasterName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<Toaster>(null, response.GetRawResponse())
                    : Response.FromValue(new Toaster(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> is null. </exception>
        public async virtual Task<Response<Toaster>> GetIfExistsAsync(string toasterName, CancellationToken cancellationToken = default)
        {
            if (toasterName == null)
            {
                throw new ArgumentNullException(nameof(toasterName));
            }

            using var scope = _clientDiagnostics.CreateScope("ToasterCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _toastersRestClient.GetAsync(Id.SubscriptionId, toasterName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<Toaster>(null, response.GetRawResponse())
                    : Response.FromValue(new Toaster(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> is null. </exception>
        public virtual Response<bool> Exists(string toasterName, CancellationToken cancellationToken = default)
        {
            if (toasterName == null)
            {
                throw new ArgumentNullException(nameof(toasterName));
            }

            using var scope = _clientDiagnostics.CreateScope("ToasterCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(toasterName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string toasterName, CancellationToken cancellationToken = default)
        {
            if (toasterName == null)
            {
                throw new ArgumentNullException(nameof(toasterName));
            }

            using var scope = _clientDiagnostics.CreateScope("ToasterCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(toasterName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Toasters_List
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Toaster" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Toaster> GetAll(CancellationToken cancellationToken = default)
        {
            Page<Toaster> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ToasterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _toastersRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Toaster(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Toasters_List
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Toaster" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Toaster> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Toaster>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ToasterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _toastersRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Toaster(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Filters the list of <see cref="Toaster" /> for this subscription represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ToasterCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(Toaster.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as Subscription, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="Toaster" /> for this subscription represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ToasterCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(Toaster.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as Subscription, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Toaster> IEnumerable<Toaster>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Toaster> IAsyncEnumerable<Toaster>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, Toaster, ToasterData> Construct() { }
    }
}
