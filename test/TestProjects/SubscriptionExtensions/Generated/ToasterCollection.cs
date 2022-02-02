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
        private readonly ClientDiagnostics _toasterClientDiagnostics;
        private readonly ToastersRestOperations _toasterRestClient;

        /// <summary> Initializes a new instance of the <see cref="ToasterCollection"/> class for mocking. </summary>
        protected ToasterCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ToasterCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ToasterCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _toasterClientDiagnostics = new ClientDiagnostics("SubscriptionExtensions", Toaster.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(Toaster.ResourceType, out string toasterApiVersion);
            _toasterRestClient = new ToastersRestOperations(_toasterClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, toasterApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters/{toasterName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Toasters_CreateOrUpdate
        /// <summary> Create or update an availability set. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="toasterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ToasterCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string toasterName, ToasterData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(toasterName, nameof(toasterName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _toasterClientDiagnostics.CreateScope("ToasterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _toasterRestClient.CreateOrUpdateAsync(Id.SubscriptionId, toasterName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ToasterCreateOrUpdateOperation(ArmClient, response);
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
        /// OperationId: Toasters_CreateOrUpdate
        /// <summary> Create or update an availability set. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="toasterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ToasterCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string toasterName, ToasterData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(toasterName, nameof(toasterName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _toasterClientDiagnostics.CreateScope("ToasterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _toasterRestClient.CreateOrUpdate(Id.SubscriptionId, toasterName, parameters, cancellationToken);
                var operation = new ToasterCreateOrUpdateOperation(ArmClient, response);
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
        /// OperationId: Toasters_Get
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="toasterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> is null. </exception>
        public async virtual Task<Response<Toaster>> GetAsync(string toasterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(toasterName, nameof(toasterName));

            using var scope = _toasterClientDiagnostics.CreateScope("ToasterCollection.Get");
            scope.Start();
            try
            {
                var response = await _toasterRestClient.GetAsync(Id.SubscriptionId, toasterName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _toasterClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Toaster(ArmClient, response.Value), response.GetRawResponse());
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
        /// <exception cref="ArgumentException"> <paramref name="toasterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> is null. </exception>
        public virtual Response<Toaster> Get(string toasterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(toasterName, nameof(toasterName));

            using var scope = _toasterClientDiagnostics.CreateScope("ToasterCollection.Get");
            scope.Start();
            try
            {
                var response = _toasterRestClient.Get(Id.SubscriptionId, toasterName, cancellationToken);
                if (response.Value == null)
                    throw _toasterClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Toaster(ArmClient, response.Value), response.GetRawResponse());
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
        /// <returns> An async collection of <see cref="Toaster" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Toaster> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Toaster>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _toasterClientDiagnostics.CreateScope("ToasterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _toasterRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Toaster(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
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
                using var scope = _toasterClientDiagnostics.CreateScope("ToasterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _toasterRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Toaster(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters/{toasterName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Toasters_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="toasterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string toasterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(toasterName, nameof(toasterName));

            using var scope = _toasterClientDiagnostics.CreateScope("ToasterCollection.Exists");
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters/{toasterName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Toasters_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="toasterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> is null. </exception>
        public virtual Response<bool> Exists(string toasterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(toasterName, nameof(toasterName));

            using var scope = _toasterClientDiagnostics.CreateScope("ToasterCollection.Exists");
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters/{toasterName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Toasters_Get
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="toasterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> is null. </exception>
        public async virtual Task<Response<Toaster>> GetIfExistsAsync(string toasterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(toasterName, nameof(toasterName));

            using var scope = _toasterClientDiagnostics.CreateScope("ToasterCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _toasterRestClient.GetAsync(Id.SubscriptionId, toasterName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<Toaster>(null, response.GetRawResponse());
                return Response.FromValue(new Toaster(ArmClient, response.Value), response.GetRawResponse());
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
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="toasterName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="toasterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="toasterName"/> is null. </exception>
        public virtual Response<Toaster> GetIfExists(string toasterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(toasterName, nameof(toasterName));

            using var scope = _toasterClientDiagnostics.CreateScope("ToasterCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _toasterRestClient.Get(Id.SubscriptionId, toasterName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<Toaster>(null, response.GetRawResponse());
                return Response.FromValue(new Toaster(ArmClient, response.Value), response.GetRawResponse());
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
    }
}
