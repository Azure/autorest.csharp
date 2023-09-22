// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Sample
{
    /// <summary>
    /// A class representing a collection of <see cref="ProximityPlacementGroupResource" /> and their operations.
    /// Each <see cref="ProximityPlacementGroupResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="ProximityPlacementGroupCollection" /> instance call the GetProximityPlacementGroups method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class ProximityPlacementGroupCollection : ArmCollection, IEnumerable<ProximityPlacementGroupResource>, IAsyncEnumerable<ProximityPlacementGroupResource>
    {
        private readonly ClientDiagnostics _proximityPlacementGroupClientDiagnostics;
        private readonly ProximityPlacementGroupsRestOperations _proximityPlacementGroupRestClient;

        /// <summary> Initializes a new instance of the <see cref="ProximityPlacementGroupCollection"/> class for mocking. </summary>
        protected ProximityPlacementGroupCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ProximityPlacementGroupCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ProximityPlacementGroupCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _proximityPlacementGroupClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sample", ProximityPlacementGroupResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ProximityPlacementGroupResource.ResourceType, out string proximityPlacementGroupApiVersion);
            _proximityPlacementGroupRestClient = new ProximityPlacementGroupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, proximityPlacementGroupApiVersion);
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
        /// Create or update a proximity placement group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="data"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ProximityPlacementGroupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string proximityPlacementGroupName, ProximityPlacementGroupData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _proximityPlacementGroupRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, proximityPlacementGroupName, data, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation<ProximityPlacementGroupResource>(Response.FromValue(new ProximityPlacementGroupResource(Client, response), response.GetRawResponse()));
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
        /// Create or update a proximity placement group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="data"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ProximityPlacementGroupResource> CreateOrUpdate(WaitUntil waitUntil, string proximityPlacementGroupName, ProximityPlacementGroupData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _proximityPlacementGroupRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, proximityPlacementGroupName, data, cancellationToken);
                var operation = new SampleArmOperation<ProximityPlacementGroupResource>(Response.FromValue(new ProximityPlacementGroupResource(Client, response), response.GetRawResponse()));
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
        /// Retrieves information about a proximity placement group .
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> is null. </exception>
        public virtual async Task<Response<ProximityPlacementGroupResource>> GetAsync(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.Get");
            scope.Start();
            try
            {
                var response = await _proximityPlacementGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, proximityPlacementGroupName, includeColocationStatus, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ProximityPlacementGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about a proximity placement group .
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> is null. </exception>
        public virtual Response<ProximityPlacementGroupResource> Get(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.Get");
            scope.Start();
            try
            {
                var response = _proximityPlacementGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, proximityPlacementGroupName, includeColocationStatus, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ProximityPlacementGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all proximity placement groups in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_ListByResourceGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ProximityPlacementGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ProximityPlacementGroupResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _proximityPlacementGroupRestClient.CreateListByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _proximityPlacementGroupRestClient.CreateListByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ProximityPlacementGroupResource(Client, ProximityPlacementGroupData.DeserializeProximityPlacementGroupData(e)), _proximityPlacementGroupClientDiagnostics, Pipeline, "ProximityPlacementGroupCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all proximity placement groups in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_ListByResourceGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ProximityPlacementGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ProximityPlacementGroupResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _proximityPlacementGroupRestClient.CreateListByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _proximityPlacementGroupRestClient.CreateListByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ProximityPlacementGroupResource(Client, ProximityPlacementGroupData.DeserializeProximityPlacementGroupData(e)), _proximityPlacementGroupClientDiagnostics, Pipeline, "ProximityPlacementGroupCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = await _proximityPlacementGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, proximityPlacementGroupName, includeColocationStatus, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> is null. </exception>
        public virtual Response<bool> Exists(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = _proximityPlacementGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, proximityPlacementGroupName, includeColocationStatus, cancellationToken: cancellationToken);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> is null. </exception>
        public virtual async Task<NullableResponse<ProximityPlacementGroupResource>> GetIfExistsAsync(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _proximityPlacementGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, proximityPlacementGroupName, includeColocationStatus, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<ProximityPlacementGroupResource>(response.GetRawResponse());
                return Response.FromValue(new ProximityPlacementGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> is null. </exception>
        public virtual NullableResponse<ProximityPlacementGroupResource> GetIfExists(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(proximityPlacementGroupName, nameof(proximityPlacementGroupName));

            using var scope = _proximityPlacementGroupClientDiagnostics.CreateScope("ProximityPlacementGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _proximityPlacementGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, proximityPlacementGroupName, includeColocationStatus, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<ProximityPlacementGroupResource>(response.GetRawResponse());
                return Response.FromValue(new ProximityPlacementGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ProximityPlacementGroupResource> IEnumerable<ProximityPlacementGroupResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ProximityPlacementGroupResource> IAsyncEnumerable<ProximityPlacementGroupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
