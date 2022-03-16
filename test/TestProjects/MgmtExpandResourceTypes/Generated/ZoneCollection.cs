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
            _zoneClientDiagnostics = new ClientDiagnostics("MgmtExpandResourceTypes", ZoneResource.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ZoneResource.ResourceType, out string zoneApiVersion);
            _zoneRestClient = new ZonesRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, zoneApiVersion);
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
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="parameters"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always overwrite the current zone. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new DNS zone to be created, but to prevent updating an existing zone. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<ZoneResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string zoneName, ZoneData parameters, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _zoneRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, zoneName, parameters, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="parameters"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always overwrite the current zone. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new DNS zone to be created, but to prevent updating an existing zone. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ZoneResource> CreateOrUpdate(WaitUntil waitUntil, string zoneName, ZoneData parameters, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _zoneRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, zoneName, parameters, ifMatch, ifNoneMatch, cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones
        /// Operation Id: Zones_ListByResourceGroup
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ZoneResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ZoneResource> GetAllAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ZoneResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _zoneRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ZoneResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ZoneResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _zoneRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ZoneResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <returns> A collection of <see cref="ZoneResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ZoneResource> GetAll(int? top = null, CancellationToken cancellationToken = default)
        {
            Page<ZoneResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _zoneRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ZoneResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ZoneResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _zoneRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ZoneResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        public virtual async Task<Response<ZoneResource>> GetIfExistsAsync(string zoneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _zoneRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, zoneName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ZoneResource>(null, response.GetRawResponse());
                return Response.FromValue(new ZoneResource(Client, response.Value), response.GetRawResponse());
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
        public virtual Response<ZoneResource> GetIfExists(string zoneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var scope = _zoneClientDiagnostics.CreateScope("ZoneCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _zoneRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, zoneName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ZoneResource>(null, response.GetRawResponse());
                return Response.FromValue(new ZoneResource(Client, response.Value), response.GetRawResponse());
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
