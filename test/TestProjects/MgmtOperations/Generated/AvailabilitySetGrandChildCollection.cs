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
using Azure.ResourceManager.Core;
using MgmtOperations.Models;

namespace MgmtOperations
{
    /// <summary> A class representing collection of AvailabilitySetGrandChild and their operations over its parent. </summary>
    public partial class AvailabilitySetGrandChildCollection : ArmCollection, IEnumerable<AvailabilitySetGrandChild>, IAsyncEnumerable<AvailabilitySetGrandChild>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly AvailabilitySetGrandChildRestOperations _availabilitySetGrandChildRestClient;

        /// <summary> Initializes a new instance of the <see cref="AvailabilitySetGrandChildCollection"/> class for mocking. </summary>
        protected AvailabilitySetGrandChildCollection()
        {
        }

        /// <summary> Initializes a new instance of AvailabilitySetGrandChildCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal AvailabilitySetGrandChildCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _availabilitySetGrandChildRestClient = new AvailabilitySetGrandChildRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != AvailabilitySetChild.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, AvailabilitySetChild.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}/availabilitySetGrandChildren/{availabilitySetGrandChildName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}
        /// OperationId: availabilitySetGrandChild_CreateOrUpdate
        /// <summary> Create or update an availability set. </summary>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetGrandChildName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual AvailabilitySetGrandChildCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string availabilitySetGrandChildName, AvailabilitySetGrandChildData parameters, CancellationToken cancellationToken = default)
        {
            if (availabilitySetGrandChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetGrandChildName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _availabilitySetGrandChildRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, availabilitySetGrandChildName, parameters, cancellationToken);
                var operation = new AvailabilitySetGrandChildCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}/availabilitySetGrandChildren/{availabilitySetGrandChildName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}
        /// OperationId: availabilitySetGrandChild_CreateOrUpdate
        /// <summary> Create or update an availability set. </summary>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetGrandChildName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<AvailabilitySetGrandChildCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string availabilitySetGrandChildName, AvailabilitySetGrandChildData parameters, CancellationToken cancellationToken = default)
        {
            if (availabilitySetGrandChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetGrandChildName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _availabilitySetGrandChildRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, availabilitySetGrandChildName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new AvailabilitySetGrandChildCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}/availabilitySetGrandChildren/{availabilitySetGrandChildName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}
        /// OperationId: availabilitySetGrandChild_Get
        /// <summary> Retrieves information about an availability set. </summary>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetGrandChildName"/> is null. </exception>
        public virtual Response<AvailabilitySetGrandChild> Get(string availabilitySetGrandChildName, CancellationToken cancellationToken = default)
        {
            if (availabilitySetGrandChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetGrandChildName));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.Get");
            scope.Start();
            try
            {
                var response = _availabilitySetGrandChildRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, availabilitySetGrandChildName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AvailabilitySetGrandChild(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}/availabilitySetGrandChildren/{availabilitySetGrandChildName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}
        /// OperationId: availabilitySetGrandChild_Get
        /// <summary> Retrieves information about an availability set. </summary>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetGrandChildName"/> is null. </exception>
        public async virtual Task<Response<AvailabilitySetGrandChild>> GetAsync(string availabilitySetGrandChildName, CancellationToken cancellationToken = default)
        {
            if (availabilitySetGrandChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetGrandChildName));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.Get");
            scope.Start();
            try
            {
                var response = await _availabilitySetGrandChildRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, availabilitySetGrandChildName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new AvailabilitySetGrandChild(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetGrandChildName"/> is null. </exception>
        public virtual Response<AvailabilitySetGrandChild> GetIfExists(string availabilitySetGrandChildName, CancellationToken cancellationToken = default)
        {
            if (availabilitySetGrandChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetGrandChildName));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _availabilitySetGrandChildRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, availabilitySetGrandChildName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<AvailabilitySetGrandChild>(null, response.GetRawResponse())
                    : Response.FromValue(new AvailabilitySetGrandChild(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetGrandChildName"/> is null. </exception>
        public async virtual Task<Response<AvailabilitySetGrandChild>> GetIfExistsAsync(string availabilitySetGrandChildName, CancellationToken cancellationToken = default)
        {
            if (availabilitySetGrandChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetGrandChildName));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _availabilitySetGrandChildRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, availabilitySetGrandChildName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<AvailabilitySetGrandChild>(null, response.GetRawResponse())
                    : Response.FromValue(new AvailabilitySetGrandChild(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetGrandChildName"/> is null. </exception>
        public virtual Response<bool> Exists(string availabilitySetGrandChildName, CancellationToken cancellationToken = default)
        {
            if (availabilitySetGrandChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetGrandChildName));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(availabilitySetGrandChildName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetGrandChildName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string availabilitySetGrandChildName, CancellationToken cancellationToken = default)
        {
            if (availabilitySetGrandChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetGrandChildName));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(availabilitySetGrandChildName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}/availabilitySetGrandChildren
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}
        /// OperationId: availabilitySetGrandChild_List
        /// <summary> Retrieves information about an availability set. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AvailabilitySetGrandChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AvailabilitySetGrandChild> GetAll(CancellationToken cancellationToken = default)
        {
            Page<AvailabilitySetGrandChild> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _availabilitySetGrandChildRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AvailabilitySetGrandChild(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}/availabilitySetGrandChildren
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}
        /// OperationId: availabilitySetGrandChild_List
        /// <summary> Retrieves information about an availability set. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AvailabilitySetGrandChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AvailabilitySetGrandChild> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<AvailabilitySetGrandChild>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _availabilitySetGrandChildRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AvailabilitySetGrandChild(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        IEnumerator<AvailabilitySetGrandChild> IEnumerable<AvailabilitySetGrandChild>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AvailabilitySetGrandChild> IAsyncEnumerable<AvailabilitySetGrandChild>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, AvailabilitySetGrandChild, AvailabilitySetGrandChildData> Construct() { }
    }
}
