// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using MgmtExpandResourceTypes.Models;

namespace MgmtExpandResourceTypes
{
    /// <summary> A class representing collection of Zone and their operations over its parent. </summary>
    public partial class ZoneCollection : ArmCollection, IEnumerable<Zone>, IAsyncEnumerable<Zone>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ZonesRestOperations _zonesRestClient;

        /// <summary> Initializes a new instance of the <see cref="ZoneCollection"/> class for mocking. </summary>
        protected ZoneCollection()
        {
        }

        /// <summary> Initializes a new instance of ZoneCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ZoneCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _zonesRestClient = new ZonesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(nameof(id), string.Format("Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Zones_CreateOrUpdate
        /// <summary> Creates or updates a DNS zone. Does not modify DNS records within the zone. </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="parameters"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always overwrite the current zone. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new DNS zone to be created, but to prevent updating an existing zone. Other values will be ignored. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ZoneCreateOrUpdateOperation CreateOrUpdate(string zoneName, ZoneData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (zoneName == null)
            {
                throw new ArgumentNullException(nameof(zoneName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ZoneCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _zonesRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, zoneName, parameters, ifMatch, ifNoneMatch, cancellationToken);
                var operation = new ZoneCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Zones_CreateOrUpdate
        /// <summary> Creates or updates a DNS zone. Does not modify DNS records within the zone. </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="parameters"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always overwrite the current zone. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new DNS zone to be created, but to prevent updating an existing zone. Other values will be ignored. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ZoneCreateOrUpdateOperation> CreateOrUpdateAsync(string zoneName, ZoneData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (zoneName == null)
            {
                throw new ArgumentNullException(nameof(zoneName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ZoneCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _zonesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, zoneName, parameters, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
                var operation = new ZoneCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Zones_Get
        /// <summary> Gets a DNS zone. Retrieves the zone properties, but not the record sets within the zone. </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        public virtual Response<Zone> Get(string zoneName, CancellationToken cancellationToken = default)
        {
            if (zoneName == null)
            {
                throw new ArgumentNullException(nameof(zoneName));
            }

            using var scope = _clientDiagnostics.CreateScope("ZoneCollection.Get");
            scope.Start();
            try
            {
                var response = _zonesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, zoneName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Zone(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Zones_Get
        /// <summary> Gets a DNS zone. Retrieves the zone properties, but not the record sets within the zone. </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        public async virtual Task<Response<Zone>> GetAsync(string zoneName, CancellationToken cancellationToken = default)
        {
            if (zoneName == null)
            {
                throw new ArgumentNullException(nameof(zoneName));
            }

            using var scope = _clientDiagnostics.CreateScope("ZoneCollection.Get");
            scope.Start();
            try
            {
                var response = await _zonesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, zoneName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Zone(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        public virtual Response<Zone> GetIfExists(string zoneName, CancellationToken cancellationToken = default)
        {
            if (zoneName == null)
            {
                throw new ArgumentNullException(nameof(zoneName));
            }

            using var scope = _clientDiagnostics.CreateScope("ZoneCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _zonesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, zoneName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<Zone>(null, response.GetRawResponse())
                    : Response.FromValue(new Zone(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        public async virtual Task<Response<Zone>> GetIfExistsAsync(string zoneName, CancellationToken cancellationToken = default)
        {
            if (zoneName == null)
            {
                throw new ArgumentNullException(nameof(zoneName));
            }

            using var scope = _clientDiagnostics.CreateScope("ZoneCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _zonesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, zoneName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<Zone>(null, response.GetRawResponse())
                    : Response.FromValue(new Zone(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        public virtual Response<bool> Exists(string zoneName, CancellationToken cancellationToken = default)
        {
            if (zoneName == null)
            {
                throw new ArgumentNullException(nameof(zoneName));
            }

            using var scope = _clientDiagnostics.CreateScope("ZoneCollection.Exists");
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

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string zoneName, CancellationToken cancellationToken = default)
        {
            if (zoneName == null)
            {
                throw new ArgumentNullException(nameof(zoneName));
            }

            using var scope = _clientDiagnostics.CreateScope("ZoneCollection.ExistsAsync");
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Zones_ListByResourceGroup
        /// <summary> Lists the DNS zones within a resource group. </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Zone" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Zone> GetAll(int? top = null, CancellationToken cancellationToken = default)
        {
            Page<Zone> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _zonesRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Zone(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Zone> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _zonesRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Zone(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Zones_ListByResourceGroup
        /// <summary> Lists the DNS zones within a resource group. </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Zone" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Zone> GetAllAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<Zone>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _zonesRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Zone(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Zone>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _zonesRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Zone(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="Zone" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ZoneCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(Zone.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="Zone" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ZoneCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(Zone.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
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

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, Zone, ZoneData> Construct() { }
    }
}
