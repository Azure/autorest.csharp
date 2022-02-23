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

namespace MgmtExpandResourceTypes
{
    /// <summary> A class representing collection of Zone and their operations over its parent. </summary>
    public partial class ZoneCollection : ArmCollection, IEnumerable<Zone>, IAsyncEnumerable<Zone>
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
            _zoneClientDiagnostics = new ClientDiagnostics("MgmtExpandResourceTypes", Zone.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(Zone.ResourceType, out string zoneApiVersion);
            _zoneRestClient = new ZonesRestOperations(_zoneClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, zoneApiVersion);
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
        /// Creates or updates a DNS zone. Does not modify DNS records within the zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="parameters"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always overwrite the current zone. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new DNS zone to be created, but to prevent updating an existing zone. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<Zone>> CreateOrUpdateAsync(bool waitForCompletion, string zoneName, ZoneData parameters, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _zoneRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, zoneName, parameters, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
                return ArmOperationHelpers.FromResponse(new Zone(Client, response), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates a DNS zone. Does not modify DNS records within the zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="parameters"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always overwrite the current zone. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new DNS zone to be created, but to prevent updating an existing zone. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<Zone> CreateOrUpdate(bool waitForCompletion, string zoneName, ZoneData parameters, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _zoneRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, zoneName, parameters, ifMatch, ifNoneMatch, cancellationToken);
                return ArmOperationHelpers.FromResponse(new Zone(Client, response), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a DNS zone. Retrieves the zone properties, but not the record sets within the zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        public virtual async Task<Response<Zone>> GetAsync(string zoneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.Get");
            scope.Start();
            try
            {
                var response = await _zoneRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, zoneName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _zoneClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Zone(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a DNS zone. Retrieves the zone properties, but not the record sets within the zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        public virtual Response<Zone> Get(string zoneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.Get");
            scope.Start();
            try
            {
                var response = _zoneRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, zoneName, cancellationToken);
                if (response.Value == null)
                    throw _zoneClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Zone(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the DNS zones within a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones
        /// Operation Id: Zones_ListByResourceGroup
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Zone" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Zone> GetAllAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<Zone>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _zoneRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Zone(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Zone>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _zoneRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Zone(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists the DNS zones within a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones
        /// Operation Id: Zones_ListByResourceGroup
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Zone" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Zone> GetAll(int? top = null, CancellationToken cancellationToken = default)
        {
            Page<Zone> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _zoneRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Zone(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Zone> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _zoneRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Zone(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
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
                var response = await GetIfExistsAsync(zoneName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
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
                var response = GetIfExists(zoneName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        public virtual async Task<Response<Zone>> GetIfExistsAsync(string zoneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _zoneRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, zoneName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<Zone>(null, response.GetRawResponse());
                return Response.FromValue(new Zone(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        public virtual Response<Zone> GetIfExists(string zoneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _zoneRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, zoneName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<Zone>(null, response.GetRawResponse());
                return Response.FromValue(new Zone(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Zone> IEnumerable<Zone>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Zone> IAsyncEnumerable<Zone>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
