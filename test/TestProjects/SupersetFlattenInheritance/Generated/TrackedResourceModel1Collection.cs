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
using Azure.ResourceManager.Resources;

namespace SupersetFlattenInheritance
{
    /// <summary>
    /// A class representing a collection of <see cref="TrackedResourceModel1Resource" /> and their operations.
    /// Each <see cref="TrackedResourceModel1Resource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="TrackedResourceModel1Collection" /> instance call the GetTrackedResourceModel1s method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class TrackedResourceModel1Collection : ArmCollection, IEnumerable<TrackedResourceModel1Resource>, IAsyncEnumerable<TrackedResourceModel1Resource>
    {
        private readonly ClientDiagnostics _trackedResourceModel1ClientDiagnostics;
        private readonly TrackedResourceModel1SRestOperations _trackedResourceModel1RestClient;

        /// <summary> Initializes a new instance of the <see cref="TrackedResourceModel1Collection"/> class for mocking. </summary>
        protected TrackedResourceModel1Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TrackedResourceModel1Collection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TrackedResourceModel1Collection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _trackedResourceModel1ClientDiagnostics = new ClientDiagnostics("SupersetFlattenInheritance", TrackedResourceModel1Resource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(TrackedResourceModel1Resource.ResourceType, out string trackedResourceModel1ApiVersion);
            _trackedResourceModel1RestClient = new TrackedResourceModel1SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, trackedResourceModel1ApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s/{trackedResourceModel1sName}
        /// Operation Id: TrackedResourceModel1s_Put
        /// </summary>
        /// <param name="waitUntil"> "WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="data"> The TrackedResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<TrackedResourceModel1Resource>> CreateOrUpdateAsync(WaitUntil waitUntil, string trackedResourceModel1SName, TrackedResourceModel1Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel1SName, nameof(trackedResourceModel1SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _trackedResourceModel1RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel1SName, data, cancellationToken).ConfigureAwait(false);
                var operation = new SupersetFlattenInheritanceArmOperation<TrackedResourceModel1Resource>(Response.FromValue(new TrackedResourceModel1Resource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s/{trackedResourceModel1sName}
        /// Operation Id: TrackedResourceModel1s_Put
        /// </summary>
        /// <param name="waitUntil"> "WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="data"> The TrackedResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<TrackedResourceModel1Resource> CreateOrUpdate(WaitUntil waitUntil, string trackedResourceModel1SName, TrackedResourceModel1Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel1SName, nameof(trackedResourceModel1SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _trackedResourceModel1RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel1SName, data, cancellationToken);
                var operation = new SupersetFlattenInheritanceArmOperation<TrackedResourceModel1Resource>(Response.FromValue(new TrackedResourceModel1Resource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s/{trackedResourceModel1sName}
        /// Operation Id: TrackedResourceModel1s_Get
        /// </summary>
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> is null. </exception>
        public virtual async Task<Response<TrackedResourceModel1Resource>> GetAsync(string trackedResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel1SName, nameof(trackedResourceModel1SName));

            using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.Get");
            scope.Start();
            try
            {
                var response = await _trackedResourceModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel1SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TrackedResourceModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s/{trackedResourceModel1sName}
        /// Operation Id: TrackedResourceModel1s_Get
        /// </summary>
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> is null. </exception>
        public virtual Response<TrackedResourceModel1Resource> Get(string trackedResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel1SName, nameof(trackedResourceModel1SName));

            using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.Get");
            scope.Start();
            try
            {
                var response = _trackedResourceModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel1SName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TrackedResourceModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s
        /// Operation Id: TrackedResourceModel1s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TrackedResourceModel1Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TrackedResourceModel1Resource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<TrackedResourceModel1Resource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = await _trackedResourceModel1RestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TrackedResourceModel1Resource(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s
        /// Operation Id: TrackedResourceModel1s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TrackedResourceModel1Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TrackedResourceModel1Resource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<TrackedResourceModel1Resource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = _trackedResourceModel1RestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TrackedResourceModel1Resource(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s/{trackedResourceModel1sName}
        /// Operation Id: TrackedResourceModel1s_Get
        /// </summary>
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string trackedResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel1SName, nameof(trackedResourceModel1SName));

            using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = await _trackedResourceModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s/{trackedResourceModel1sName}
        /// Operation Id: TrackedResourceModel1s_Get
        /// </summary>
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> is null. </exception>
        public virtual Response<bool> Exists(string trackedResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel1SName, nameof(trackedResourceModel1SName));

            using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = _trackedResourceModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel1SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TrackedResourceModel1Resource> IEnumerable<TrackedResourceModel1Resource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TrackedResourceModel1Resource> IAsyncEnumerable<TrackedResourceModel1Resource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
