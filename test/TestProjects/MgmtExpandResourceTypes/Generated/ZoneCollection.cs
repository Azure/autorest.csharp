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
using Azure.ResourceManager.Resources;

namespace MgmtExpandResourceTypes
{
    /// <summary>
    /// A class representing a collection of <see cref="ZoneResource" /> and their operations.
    /// Each <see cref="ZoneResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="ZoneCollection" /> instance call the GetZones method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class ZoneCollection : ArmCollection, IEnumerable<ZoneResource>, IAsyncEnumerable<ZoneResource>
    {
        private readonly ClientDiagnostics _zoneClientDiagnostics;
        private readonly ZonesRestOperations _zoneRestClient;

        /// <summary> Initializes a new instance of the <see cref="ZoneCollection"/> class for mocking. </summary>
        protected ZoneCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ZoneCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ZoneCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _zoneClientDiagnostics = new ClientDiagnostics("MgmtExpandResourceTypes", ZoneResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ZoneResource.ResourceType, out string zoneApiVersion);
            _zoneRestClient = new ZonesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, zoneApiVersion);
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
        /// Creates or updates a DNS zone. Does not modify DNS records within the zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Zones_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always overwrite the current zone. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new DNS zone to be created, but to prevent updating an existing zone. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ZoneResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string zoneName, ZoneData data, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _zoneRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, zoneName, data, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtExpandResourceTypesArmOperation<ZoneResource>(Response.FromValue(new ZoneResource(Client, response), response.GetRawResponse()));
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
        /// Creates or updates a DNS zone. Does not modify DNS records within the zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Zones_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always overwrite the current zone. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new DNS zone to be created, but to prevent updating an existing zone. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ZoneResource> CreateOrUpdate(WaitUntil waitUntil, string zoneName, ZoneData data, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _zoneRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, zoneName, data, ifMatch, ifNoneMatch, cancellationToken);
                var operation = new MgmtExpandResourceTypesArmOperation<ZoneResource>(Response.FromValue(new ZoneResource(Client, response), response.GetRawResponse()));
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
        /// Gets a DNS zone. Retrieves the zone properties, but not the record sets within the zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Zones_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        public virtual async Task<Response<ZoneResource>> GetAsync(string zoneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.Get");
            scope.Start();
            try
            {
                var response = await _zoneRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, zoneName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ZoneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a DNS zone. Retrieves the zone properties, but not the record sets within the zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Zones_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        public virtual Response<ZoneResource> Get(string zoneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.Get");
            scope.Start();
            try
            {
                var response = _zoneRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, zoneName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ZoneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the DNS zones within a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Zones_ListByResourceGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ZoneResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ZoneResource> GetAllAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _zoneRestClient.CreateListByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _zoneRestClient.CreateListByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, top);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ZoneResource(Client, ZoneData.DeserializeZoneData(e)), _zoneClientDiagnostics, Pipeline, "ZoneCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists the DNS zones within a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Zones_ListByResourceGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ZoneResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ZoneResource> GetAll(int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _zoneRestClient.CreateListByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _zoneRestClient.CreateListByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, top);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ZoneResource(Client, ZoneData.DeserializeZoneData(e)), _zoneClientDiagnostics, Pipeline, "ZoneCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Zones_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string zoneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.Exists");
            scope.Start();
            try
            {
                var response = await _zoneRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, zoneName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Zones_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        public virtual Response<bool> Exists(string zoneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.Exists");
            scope.Start();
            try
            {
                var response = _zoneRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, zoneName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ZoneResource> IEnumerable<ZoneResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ZoneResource> IAsyncEnumerable<ZoneResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
