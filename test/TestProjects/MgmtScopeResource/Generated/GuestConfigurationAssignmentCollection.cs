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

namespace MgmtScopeResource
{
    /// <summary>
    /// A class representing a collection of <see cref="GuestConfigurationAssignmentResource" /> and their operations.
    /// Each <see cref="GuestConfigurationAssignmentResource" /> in the collection will belong to the same instance of <see cref="ArmResource" />.
    /// To get a <see cref="GuestConfigurationAssignmentCollection" /> instance call the GetGuestConfigurationAssignments method from an instance of <see cref="ArmResource" />.
    /// </summary>
    public partial class GuestConfigurationAssignmentCollection : ArmCollection, IEnumerable<GuestConfigurationAssignmentResource>, IAsyncEnumerable<GuestConfigurationAssignmentResource>
    {
        private readonly ClientDiagnostics _guestConfigurationAssignmentClientDiagnostics;
        private readonly GuestConfigurationAssignmentsRestOperations _guestConfigurationAssignmentRestClient;

        /// <summary> Initializes a new instance of the <see cref="GuestConfigurationAssignmentCollection"/> class for mocking. </summary>
        protected GuestConfigurationAssignmentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="GuestConfigurationAssignmentCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal GuestConfigurationAssignmentCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _guestConfigurationAssignmentClientDiagnostics = new ClientDiagnostics("MgmtScopeResource", GuestConfigurationAssignmentResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(GuestConfigurationAssignmentResource.ResourceType, out string guestConfigurationAssignmentApiVersion);
            _guestConfigurationAssignmentRestClient = new GuestConfigurationAssignmentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, guestConfigurationAssignmentApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != "Microsoft.Compute/virtualMachines")
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, "Microsoft.Compute/virtualMachines"), nameof(id));
        }

        /// <summary>
        /// Creates an association between a VM and guest configuration
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GuestConfigurationAssignments_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="guestConfigurationAssignmentName"> Name of the guest configuration assignment. </param>
        /// <param name="data"> Parameters supplied to the create or update guest configuration assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="guestConfigurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="guestConfigurationAssignmentName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<GuestConfigurationAssignmentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string guestConfigurationAssignmentName, GuestConfigurationAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(guestConfigurationAssignmentName, nameof(guestConfigurationAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _guestConfigurationAssignmentClientDiagnostics.CreateScope("GuestConfigurationAssignmentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _guestConfigurationAssignmentRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, guestConfigurationAssignmentName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtScopeResourceArmOperation<GuestConfigurationAssignmentResource>(Response.FromValue(new GuestConfigurationAssignmentResource(Client, response), response.GetRawResponse()));
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
        /// Creates an association between a VM and guest configuration
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GuestConfigurationAssignments_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="guestConfigurationAssignmentName"> Name of the guest configuration assignment. </param>
        /// <param name="data"> Parameters supplied to the create or update guest configuration assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="guestConfigurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="guestConfigurationAssignmentName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<GuestConfigurationAssignmentResource> CreateOrUpdate(WaitUntil waitUntil, string guestConfigurationAssignmentName, GuestConfigurationAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(guestConfigurationAssignmentName, nameof(guestConfigurationAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _guestConfigurationAssignmentClientDiagnostics.CreateScope("GuestConfigurationAssignmentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _guestConfigurationAssignmentRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, guestConfigurationAssignmentName, data, cancellationToken);
                var operation = new MgmtScopeResourceArmOperation<GuestConfigurationAssignmentResource>(Response.FromValue(new GuestConfigurationAssignmentResource(Client, response), response.GetRawResponse()));
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
        /// Get information about a guest configuration assignment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GuestConfigurationAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="guestConfigurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="guestConfigurationAssignmentName"/> is null. </exception>
        public virtual async Task<Response<GuestConfigurationAssignmentResource>> GetAsync(string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(guestConfigurationAssignmentName, nameof(guestConfigurationAssignmentName));

            using var scope = _guestConfigurationAssignmentClientDiagnostics.CreateScope("GuestConfigurationAssignmentCollection.Get");
            scope.Start();
            try
            {
                var response = await _guestConfigurationAssignmentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, guestConfigurationAssignmentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new GuestConfigurationAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get information about a guest configuration assignment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GuestConfigurationAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="guestConfigurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="guestConfigurationAssignmentName"/> is null. </exception>
        public virtual Response<GuestConfigurationAssignmentResource> Get(string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(guestConfigurationAssignmentName, nameof(guestConfigurationAssignmentName));

            using var scope = _guestConfigurationAssignmentClientDiagnostics.CreateScope("GuestConfigurationAssignmentCollection.Get");
            scope.Start();
            try
            {
                var response = _guestConfigurationAssignmentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, guestConfigurationAssignmentName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new GuestConfigurationAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List all guest configuration assignments for a virtual machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GuestConfigurationAssignments_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="GuestConfigurationAssignmentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GuestConfigurationAssignmentResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _guestConfigurationAssignmentRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new GuestConfigurationAssignmentResource(Client, GuestConfigurationAssignmentData.DeserializeGuestConfigurationAssignmentData(e)), _guestConfigurationAssignmentClientDiagnostics, Pipeline, "GuestConfigurationAssignmentCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// List all guest configuration assignments for a virtual machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GuestConfigurationAssignments_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GuestConfigurationAssignmentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GuestConfigurationAssignmentResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _guestConfigurationAssignmentRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new GuestConfigurationAssignmentResource(Client, GuestConfigurationAssignmentData.DeserializeGuestConfigurationAssignmentData(e)), _guestConfigurationAssignmentClientDiagnostics, Pipeline, "GuestConfigurationAssignmentCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GuestConfigurationAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="guestConfigurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="guestConfigurationAssignmentName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(guestConfigurationAssignmentName, nameof(guestConfigurationAssignmentName));

            using var scope = _guestConfigurationAssignmentClientDiagnostics.CreateScope("GuestConfigurationAssignmentCollection.Exists");
            scope.Start();
            try
            {
                var response = await _guestConfigurationAssignmentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, guestConfigurationAssignmentName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GuestConfigurationAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="guestConfigurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="guestConfigurationAssignmentName"/> is null. </exception>
        public virtual Response<bool> Exists(string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(guestConfigurationAssignmentName, nameof(guestConfigurationAssignmentName));

            using var scope = _guestConfigurationAssignmentClientDiagnostics.CreateScope("GuestConfigurationAssignmentCollection.Exists");
            scope.Start();
            try
            {
                var response = _guestConfigurationAssignmentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, guestConfigurationAssignmentName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<GuestConfigurationAssignmentResource> IEnumerable<GuestConfigurationAssignmentResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<GuestConfigurationAssignmentResource> IAsyncEnumerable<GuestConfigurationAssignmentResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
