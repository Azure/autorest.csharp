// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtOperations
{
    /// <summary>
    /// A class representing a collection of <see cref="AvailabilitySetGrandChildResource" /> and their operations.
    /// Each <see cref="AvailabilitySetGrandChildResource" /> in the collection will belong to the same instance of <see cref="AvailabilitySetChildResource" />.
    /// To get an <see cref="AvailabilitySetGrandChildCollection" /> instance call the GetAvailabilitySetGrandChildren method from an instance of <see cref="AvailabilitySetChildResource" />.
    /// </summary>
    public partial class AvailabilitySetGrandChildCollection : ArmCollection, IEnumerable<AvailabilitySetGrandChildResource>, IAsyncEnumerable<AvailabilitySetGrandChildResource>
    {
        private readonly ClientDiagnostics _availabilitySetGrandChildavailabilitySetGrandChildClientDiagnostics;
        private readonly AvailabilitySetGrandChildRestOperations _availabilitySetGrandChildavailabilitySetGrandChildRestClient;

        /// <summary> Initializes a new instance of the <see cref="AvailabilitySetGrandChildCollection"/> class for mocking. </summary>
        protected AvailabilitySetGrandChildCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AvailabilitySetGrandChildCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AvailabilitySetGrandChildCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _availabilitySetGrandChildavailabilitySetGrandChildClientDiagnostics = new ClientDiagnostics("MgmtOperations", AvailabilitySetGrandChildResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(AvailabilitySetGrandChildResource.ResourceType, out string availabilitySetGrandChildavailabilitySetGrandChildApiVersion);
            _availabilitySetGrandChildavailabilitySetGrandChildRestClient = new AvailabilitySetGrandChildRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, availabilitySetGrandChildavailabilitySetGrandChildApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != AvailabilitySetChildResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, AvailabilitySetChildResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}/availabilitySetGrandChildren/{availabilitySetGrandChildName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>availabilitySetGrandChild_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="data"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetGrandChildName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetGrandChildName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<AvailabilitySetGrandChildResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string availabilitySetGrandChildName, AvailabilitySetGrandChildData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetGrandChildName, nameof(availabilitySetGrandChildName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _availabilitySetGrandChildavailabilitySetGrandChildClientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _availabilitySetGrandChildavailabilitySetGrandChildRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, availabilitySetGrandChildName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtOperationsArmOperation<AvailabilitySetGrandChildResource>(Response.FromValue(new AvailabilitySetGrandChildResource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}/availabilitySetGrandChildren/{availabilitySetGrandChildName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>availabilitySetGrandChild_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="data"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetGrandChildName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetGrandChildName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<AvailabilitySetGrandChildResource> CreateOrUpdate(WaitUntil waitUntil, string availabilitySetGrandChildName, AvailabilitySetGrandChildData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetGrandChildName, nameof(availabilitySetGrandChildName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _availabilitySetGrandChildavailabilitySetGrandChildClientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _availabilitySetGrandChildavailabilitySetGrandChildRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, availabilitySetGrandChildName, data, cancellationToken);
                var operation = new MgmtOperationsArmOperation<AvailabilitySetGrandChildResource>(Response.FromValue(new AvailabilitySetGrandChildResource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}/availabilitySetGrandChildren/{availabilitySetGrandChildName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>availabilitySetGrandChild_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetGrandChildName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetGrandChildName"/> is null. </exception>
        public virtual async Task<Response<AvailabilitySetGrandChildResource>> GetAsync(string availabilitySetGrandChildName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetGrandChildName, nameof(availabilitySetGrandChildName));

            using var scope = _availabilitySetGrandChildavailabilitySetGrandChildClientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.Get");
            scope.Start();
            try
            {
                var response = await _availabilitySetGrandChildavailabilitySetGrandChildRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, availabilitySetGrandChildName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AvailabilitySetGrandChildResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}/availabilitySetGrandChildren/{availabilitySetGrandChildName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>availabilitySetGrandChild_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetGrandChildName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetGrandChildName"/> is null. </exception>
        public virtual Response<AvailabilitySetGrandChildResource> Get(string availabilitySetGrandChildName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetGrandChildName, nameof(availabilitySetGrandChildName));

            using var scope = _availabilitySetGrandChildavailabilitySetGrandChildClientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.Get");
            scope.Start();
            try
            {
                var response = _availabilitySetGrandChildavailabilitySetGrandChildRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, availabilitySetGrandChildName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AvailabilitySetGrandChildResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}/availabilitySetGrandChildren</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>availabilitySetGrandChild_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AvailabilitySetGrandChildResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AvailabilitySetGrandChildResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _availabilitySetGrandChildavailabilitySetGrandChildRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new AvailabilitySetGrandChildResource(Client, AvailabilitySetGrandChildData.DeserializeAvailabilitySetGrandChildData(e)), _availabilitySetGrandChildavailabilitySetGrandChildClientDiagnostics, Pipeline, "AvailabilitySetGrandChildCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}/availabilitySetGrandChildren</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>availabilitySetGrandChild_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AvailabilitySetGrandChildResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AvailabilitySetGrandChildResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _availabilitySetGrandChildavailabilitySetGrandChildRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new AvailabilitySetGrandChildResource(Client, AvailabilitySetGrandChildData.DeserializeAvailabilitySetGrandChildData(e)), _availabilitySetGrandChildavailabilitySetGrandChildClientDiagnostics, Pipeline, "AvailabilitySetGrandChildCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}/availabilitySetGrandChildren/{availabilitySetGrandChildName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>availabilitySetGrandChild_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetGrandChildName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetGrandChildName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string availabilitySetGrandChildName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetGrandChildName, nameof(availabilitySetGrandChildName));

            using var scope = _availabilitySetGrandChildavailabilitySetGrandChildClientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.Exists");
            scope.Start();
            try
            {
                var response = await _availabilitySetGrandChildavailabilitySetGrandChildRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, availabilitySetGrandChildName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}/availabilitySetGrandChildren/{availabilitySetGrandChildName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>availabilitySetGrandChild_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetGrandChildName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetGrandChildName"/> is null. </exception>
        public virtual Response<bool> Exists(string availabilitySetGrandChildName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetGrandChildName, nameof(availabilitySetGrandChildName));

            using var scope = _availabilitySetGrandChildavailabilitySetGrandChildClientDiagnostics.CreateScope("AvailabilitySetGrandChildCollection.Exists");
            scope.Start();
            try
            {
                var response = _availabilitySetGrandChildavailabilitySetGrandChildRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, availabilitySetGrandChildName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AvailabilitySetGrandChildResource> IEnumerable<AvailabilitySetGrandChildResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AvailabilitySetGrandChildResource> IAsyncEnumerable<AvailabilitySetGrandChildResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
