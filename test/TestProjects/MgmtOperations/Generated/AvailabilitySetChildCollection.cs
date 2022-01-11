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
    /// <summary> A class representing collection of AvailabilitySetChild and their operations over its parent. </summary>
    public partial class AvailabilitySetChildCollection : ArmCollection, IEnumerable<AvailabilitySetChild>, IAsyncEnumerable<AvailabilitySetChild>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly AvailabilitySetChildRestOperations _availabilitySetChildRestClient;

        /// <summary> Initializes a new instance of the <see cref="AvailabilitySetChildCollection"/> class for mocking. </summary>
        protected AvailabilitySetChildCollection()
        {
        }

        /// <summary> Initializes a new instance of AvailabilitySetChildCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal AvailabilitySetChildCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _availabilitySetChildRestClient = new AvailabilitySetChildRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != AvailabilitySet.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, AvailabilitySet.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// OperationId: availabilitySetChild_CreateOrUpdate
        /// <summary> Create or update an availability set. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual AvailabilitySetChildCreateOrUpdateOperation CreateOrUpdate(string availabilitySetChildName, AvailabilitySetChildData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (availabilitySetChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetChildName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _availabilitySetChildRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, availabilitySetChildName, parameters, cancellationToken);
                var operation = new AvailabilitySetChildCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// OperationId: availabilitySetChild_CreateOrUpdate
        /// <summary> Create or update an availability set. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<AvailabilitySetChildCreateOrUpdateOperation> CreateOrUpdateAsync(string availabilitySetChildName, AvailabilitySetChildData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (availabilitySetChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetChildName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _availabilitySetChildRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, availabilitySetChildName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new AvailabilitySetChildCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// OperationId: availabilitySetChild_Get
        /// <summary> Retrieves information about an availability set. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> is null. </exception>
        public virtual Response<AvailabilitySetChild> Get(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            if (availabilitySetChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetChildName));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildCollection.Get");
            scope.Start();
            try
            {
                var response = _availabilitySetChildRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, availabilitySetChildName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AvailabilitySetChild(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// OperationId: availabilitySetChild_Get
        /// <summary> Retrieves information about an availability set. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> is null. </exception>
        public async virtual Task<Response<AvailabilitySetChild>> GetAsync(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            if (availabilitySetChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetChildName));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildCollection.Get");
            scope.Start();
            try
            {
                var response = await _availabilitySetChildRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, availabilitySetChildName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new AvailabilitySetChild(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> is null. </exception>
        public virtual Response<AvailabilitySetChild> GetIfExists(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            if (availabilitySetChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetChildName));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _availabilitySetChildRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, availabilitySetChildName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<AvailabilitySetChild>(null, response.GetRawResponse())
                    : Response.FromValue(new AvailabilitySetChild(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> is null. </exception>
        public async virtual Task<Response<AvailabilitySetChild>> GetIfExistsAsync(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            if (availabilitySetChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetChildName));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _availabilitySetChildRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, availabilitySetChildName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<AvailabilitySetChild>(null, response.GetRawResponse())
                    : Response.FromValue(new AvailabilitySetChild(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> is null. </exception>
        public virtual Response<bool> Exists(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            if (availabilitySetChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetChildName));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(availabilitySetChildName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            if (availabilitySetChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetChildName));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(availabilitySetChildName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// OperationId: availabilitySetChild_List
        /// <summary> Retrieves information about an availability set. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AvailabilitySetChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AvailabilitySetChild> GetAll(CancellationToken cancellationToken = default)
        {
            Page<AvailabilitySetChild> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _availabilitySetChildRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AvailabilitySetChild(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// OperationId: availabilitySetChild_List
        /// <summary> Retrieves information about an availability set. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AvailabilitySetChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AvailabilitySetChild> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<AvailabilitySetChild>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _availabilitySetChildRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AvailabilitySetChild(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        IEnumerator<AvailabilitySetChild> IEnumerable<AvailabilitySetChild>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AvailabilitySetChild> IAsyncEnumerable<AvailabilitySetChild>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, AvailabilitySetChild, AvailabilitySetChildData> Construct() { }
    }
}
