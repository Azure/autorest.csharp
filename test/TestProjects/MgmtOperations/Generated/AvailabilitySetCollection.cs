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

namespace MgmtOperations
{
    /// <summary> A class representing collection of AvailabilitySet and their operations over its parent. </summary>
    public partial class AvailabilitySetCollection : ArmCollection, IEnumerable<AvailabilitySetResource>, IAsyncEnumerable<AvailabilitySetResource>
    {
        private readonly ClientDiagnostics _availabilitySetResourceAvailabilitySetsClientDiagnostics;
        private readonly AvailabilitySetsRestOperations _availabilitySetResourceAvailabilitySetsRestClient;

        /// <summary> Initializes a new instance of the <see cref="AvailabilitySetCollection"/> class for mocking. </summary>
        protected AvailabilitySetCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AvailabilitySetCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AvailabilitySetCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _availabilitySetResourceAvailabilitySetsClientDiagnostics = new ClientDiagnostics("MgmtOperations", AvailabilitySetResource.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(AvailabilitySetResource.ResourceType, out string availabilitySetResourceAvailabilitySetsApiVersion);
            _availabilitySetResourceAvailabilitySetsRestClient = new AvailabilitySetsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, availabilitySetResourceAvailabilitySetsApiVersion);
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
        /// Create or update an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<AvailabilitySetResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string availabilitySetName, AvailabilitySetResourceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _availabilitySetResourceAvailabilitySetsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, availabilitySetName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtOperationsArmOperation<AvailabilitySetResource>(Response.FromValue(new AvailabilitySetResource(Client, response), response.GetRawResponse()));
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
        /// Create or update an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<AvailabilitySetResource> CreateOrUpdate(WaitUntil waitUntil, string availabilitySetName, AvailabilitySetResourceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _availabilitySetResourceAvailabilitySetsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, availabilitySetName, parameters, cancellationToken);
                var operation = new MgmtOperationsArmOperation<AvailabilitySetResource>(Response.FromValue(new AvailabilitySetResource(Client, response), response.GetRawResponse()));
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
        /// Retrieves information about an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        public virtual async Task<Response<AvailabilitySetResource>> GetAsync(string availabilitySetName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetCollection.Get");
            scope.Start();
            try
            {
                var response = await _availabilitySetResourceAvailabilitySetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, availabilitySetName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AvailabilitySetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        public virtual Response<AvailabilitySetResource> Get(string availabilitySetName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetCollection.Get");
            scope.Start();
            try
            {
                var response = _availabilitySetResourceAvailabilitySetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, availabilitySetName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AvailabilitySetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets
        /// Operation Id: AvailabilitySets_List
        /// </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AvailabilitySetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AvailabilitySetResource> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<AvailabilitySetResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _availabilitySetResourceAvailabilitySetsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AvailabilitySetResource(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets
        /// Operation Id: AvailabilitySets_List
        /// </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AvailabilitySetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AvailabilitySetResource> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<AvailabilitySetResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _availabilitySetResourceAvailabilitySetsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AvailabilitySetResource(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string availabilitySetName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(availabilitySetName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        public virtual Response<bool> Exists(string availabilitySetName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(availabilitySetName, expand: expand, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        public virtual async Task<Response<AvailabilitySetResource>> GetIfExistsAsync(string availabilitySetName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _availabilitySetResourceAvailabilitySetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, availabilitySetName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<AvailabilitySetResource>(null, response.GetRawResponse());
                return Response.FromValue(new AvailabilitySetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        public virtual Response<AvailabilitySetResource> GetIfExists(string availabilitySetName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _availabilitySetResourceAvailabilitySetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, availabilitySetName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<AvailabilitySetResource>(null, response.GetRawResponse());
                return Response.FromValue(new AvailabilitySetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AvailabilitySetResource> IEnumerable<AvailabilitySetResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AvailabilitySetResource> IAsyncEnumerable<AvailabilitySetResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
