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

namespace MgmtParamOrdering
{
    /// <summary> A class representing collection of DedicatedHostGroup and their operations over its parent. </summary>
    public partial class DedicatedHostGroupCollection : ArmCollection, IEnumerable<DedicatedHostGroupResource>, IAsyncEnumerable<DedicatedHostGroupResource>
    {
        private readonly ClientDiagnostics _dedicatedHostGroupResourceDedicatedHostGroupsClientDiagnostics;
        private readonly DedicatedHostGroupsRestOperations _dedicatedHostGroupResourceDedicatedHostGroupsRestClient;

        /// <summary> Initializes a new instance of the <see cref="DedicatedHostGroupCollection"/> class for mocking. </summary>
        protected DedicatedHostGroupCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DedicatedHostGroupCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DedicatedHostGroupCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _dedicatedHostGroupResourceDedicatedHostGroupsClientDiagnostics = new ClientDiagnostics("MgmtParamOrdering", DedicatedHostGroupResource.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(DedicatedHostGroupResource.ResourceType, out string dedicatedHostGroupResourceDedicatedHostGroupsApiVersion);
            _dedicatedHostGroupResourceDedicatedHostGroupsRestClient = new DedicatedHostGroupsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, dedicatedHostGroupResourceDedicatedHostGroupsApiVersion);
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
        /// Create or update a dedicated host group. For details of Dedicated Host and Dedicated Host Groups please see [Dedicated Host Documentation] (https://go.microsoft.com/fwlink/?linkid=2082596)
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}
        /// Operation Id: DedicatedHostGroups_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Dedicated Host Group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostGroupName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<DedicatedHostGroupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string hostGroupName, DedicatedHostGroupResourceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostGroupName, nameof(hostGroupName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _dedicatedHostGroupResourceDedicatedHostGroupsClientDiagnostics.CreateScope("DedicatedHostGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _dedicatedHostGroupResourceDedicatedHostGroupsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, hostGroupName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtParamOrderingArmOperation<DedicatedHostGroupResource>(Response.FromValue(new DedicatedHostGroupResource(Client, response), response.GetRawResponse()));
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
        /// Create or update a dedicated host group. For details of Dedicated Host and Dedicated Host Groups please see [Dedicated Host Documentation] (https://go.microsoft.com/fwlink/?linkid=2082596)
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}
        /// Operation Id: DedicatedHostGroups_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Dedicated Host Group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostGroupName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<DedicatedHostGroupResource> CreateOrUpdate(WaitUntil waitUntil, string hostGroupName, DedicatedHostGroupResourceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostGroupName, nameof(hostGroupName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _dedicatedHostGroupResourceDedicatedHostGroupsClientDiagnostics.CreateScope("DedicatedHostGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _dedicatedHostGroupResourceDedicatedHostGroupsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, hostGroupName, parameters, cancellationToken);
                var operation = new MgmtParamOrderingArmOperation<DedicatedHostGroupResource>(Response.FromValue(new DedicatedHostGroupResource(Client, response), response.GetRawResponse()));
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
        /// Retrieves information about a dedicated host group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}
        /// Operation Id: DedicatedHostGroups_Get
        /// </summary>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostGroupName"/> is null. </exception>
        public virtual async Task<Response<DedicatedHostGroupResource>> GetAsync(string hostGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostGroupName, nameof(hostGroupName));

            using var scope = _dedicatedHostGroupResourceDedicatedHostGroupsClientDiagnostics.CreateScope("DedicatedHostGroupCollection.Get");
            scope.Start();
            try
            {
                var response = await _dedicatedHostGroupResourceDedicatedHostGroupsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, hostGroupName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DedicatedHostGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about a dedicated host group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}
        /// Operation Id: DedicatedHostGroups_Get
        /// </summary>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostGroupName"/> is null. </exception>
        public virtual Response<DedicatedHostGroupResource> Get(string hostGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostGroupName, nameof(hostGroupName));

            using var scope = _dedicatedHostGroupResourceDedicatedHostGroupsClientDiagnostics.CreateScope("DedicatedHostGroupCollection.Get");
            scope.Start();
            try
            {
                var response = _dedicatedHostGroupResourceDedicatedHostGroupsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, hostGroupName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DedicatedHostGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about a dedicated host group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups
        /// Operation Id: DedicatedHostGroups_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DedicatedHostGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DedicatedHostGroupResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DedicatedHostGroupResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dedicatedHostGroupResourceDedicatedHostGroupsClientDiagnostics.CreateScope("DedicatedHostGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dedicatedHostGroupResourceDedicatedHostGroupsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DedicatedHostGroupResource(Client, value)), null, response.GetRawResponse());
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
        /// Retrieves information about a dedicated host group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups
        /// Operation Id: DedicatedHostGroups_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DedicatedHostGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DedicatedHostGroupResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<DedicatedHostGroupResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dedicatedHostGroupResourceDedicatedHostGroupsClientDiagnostics.CreateScope("DedicatedHostGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dedicatedHostGroupResourceDedicatedHostGroupsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DedicatedHostGroupResource(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}
        /// Operation Id: DedicatedHostGroups_Get
        /// </summary>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostGroupName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string hostGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostGroupName, nameof(hostGroupName));

            using var scope = _dedicatedHostGroupResourceDedicatedHostGroupsClientDiagnostics.CreateScope("DedicatedHostGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(hostGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}
        /// Operation Id: DedicatedHostGroups_Get
        /// </summary>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostGroupName"/> is null. </exception>
        public virtual Response<bool> Exists(string hostGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostGroupName, nameof(hostGroupName));

            using var scope = _dedicatedHostGroupResourceDedicatedHostGroupsClientDiagnostics.CreateScope("DedicatedHostGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(hostGroupName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}
        /// Operation Id: DedicatedHostGroups_Get
        /// </summary>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostGroupName"/> is null. </exception>
        public virtual async Task<Response<DedicatedHostGroupResource>> GetIfExistsAsync(string hostGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostGroupName, nameof(hostGroupName));

            using var scope = _dedicatedHostGroupResourceDedicatedHostGroupsClientDiagnostics.CreateScope("DedicatedHostGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _dedicatedHostGroupResourceDedicatedHostGroupsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, hostGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<DedicatedHostGroupResource>(null, response.GetRawResponse());
                return Response.FromValue(new DedicatedHostGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}
        /// Operation Id: DedicatedHostGroups_Get
        /// </summary>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostGroupName"/> is null. </exception>
        public virtual Response<DedicatedHostGroupResource> GetIfExists(string hostGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostGroupName, nameof(hostGroupName));

            using var scope = _dedicatedHostGroupResourceDedicatedHostGroupsClientDiagnostics.CreateScope("DedicatedHostGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _dedicatedHostGroupResourceDedicatedHostGroupsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, hostGroupName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<DedicatedHostGroupResource>(null, response.GetRawResponse());
                return Response.FromValue(new DedicatedHostGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DedicatedHostGroupResource> IEnumerable<DedicatedHostGroupResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DedicatedHostGroupResource> IAsyncEnumerable<DedicatedHostGroupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
