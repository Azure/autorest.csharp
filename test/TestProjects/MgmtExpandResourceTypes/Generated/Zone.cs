// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
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

namespace MgmtExpandResourceTypes
{
    /// <summary> A Class representing a Zone along with the instance operations that can be performed on it. </summary>
    public partial class Zone : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="Zone"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _zoneClientDiagnostics;
        private readonly ZonesRestOperations _zoneRestClient;
        private readonly ClientDiagnostics _recordSetsClientDiagnostics;
        private readonly RecordSetsRestOperations _recordSetsRestClient;
        private readonly ZoneData _data;

        /// <summary> Initializes a new instance of the <see cref="Zone"/> class for mocking. </summary>
        protected Zone()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "Zone"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal Zone(ArmClient client, ZoneData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="Zone"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Zone(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _zoneClientDiagnostics = new ClientDiagnostics("MgmtExpandResourceTypes", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string zoneApiVersion);
            _zoneRestClient = new ZonesRestOperations(_zoneClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, zoneApiVersion);
            _recordSetsClientDiagnostics = new ClientDiagnostics("MgmtExpandResourceTypes", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
            _recordSetsRestClient = new RecordSetsRestOperations(_recordSetsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/dnsZones";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ZoneData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets a collection of RecordSetAs in the RecordSetA. </summary>
        /// <returns> An object representing collection of RecordSetAs and their operations over a RecordSetA. </returns>
        public virtual RecordSetACollection GetRecordSetAs()
        {
            return new RecordSetACollection(Client, Id);
        }

        /// <summary> Gets a collection of RecordSetAaaas in the RecordSetAaaa. </summary>
        /// <returns> An object representing collection of RecordSetAaaas and their operations over a RecordSetAaaa. </returns>
        public virtual RecordSetAaaaCollection GetRecordSetAaaas()
        {
            return new RecordSetAaaaCollection(Client, Id);
        }

        /// <summary> Gets a collection of RecordSetCaas in the RecordSetCaa. </summary>
        /// <returns> An object representing collection of RecordSetCaas and their operations over a RecordSetCaa. </returns>
        public virtual RecordSetCaaCollection GetRecordSetCaas()
        {
            return new RecordSetCaaCollection(Client, Id);
        }

        /// <summary> Gets a collection of RecordSetCNames in the RecordSetCName. </summary>
        /// <returns> An object representing collection of RecordSetCNames and their operations over a RecordSetCName. </returns>
        public virtual RecordSetCNameCollection GetRecordSetCNames()
        {
            return new RecordSetCNameCollection(Client, Id);
        }

        /// <summary> Gets a collection of RecordSetMxes in the RecordSetMx. </summary>
        /// <returns> An object representing collection of RecordSetMxes and their operations over a RecordSetMx. </returns>
        public virtual RecordSetMxCollection GetRecordSetMxes()
        {
            return new RecordSetMxCollection(Client, Id);
        }

        /// <summary> Gets a collection of RecordSetNs in the RecordSetNs. </summary>
        /// <returns> An object representing collection of RecordSetNs and their operations over a RecordSetNs. </returns>
        public virtual RecordSetNsCollection GetRecordSetNs()
        {
            return new RecordSetNsCollection(Client, Id);
        }

        /// <summary> Gets a collection of RecordSetPtrs in the RecordSetPtr. </summary>
        /// <returns> An object representing collection of RecordSetPtrs and their operations over a RecordSetPtr. </returns>
        public virtual RecordSetPtrCollection GetRecordSetPtrs()
        {
            return new RecordSetPtrCollection(Client, Id);
        }

        /// <summary> Gets a collection of RecordSetSoas in the RecordSetSoa. </summary>
        /// <returns> An object representing collection of RecordSetSoas and their operations over a RecordSetSoa. </returns>
        public virtual RecordSetSoaCollection GetRecordSetSoas()
        {
            return new RecordSetSoaCollection(Client, Id);
        }

        /// <summary> Gets a collection of RecordSetSrvs in the RecordSetSrv. </summary>
        /// <returns> An object representing collection of RecordSetSrvs and their operations over a RecordSetSrv. </returns>
        public virtual RecordSetSrvCollection GetRecordSetSrvs()
        {
            return new RecordSetSrvCollection(Client, Id);
        }

        /// <summary> Gets a collection of RecordSetTxts in the RecordSetTxt. </summary>
        /// <returns> An object representing collection of RecordSetTxts and their operations over a RecordSetTxt. </returns>
        public virtual RecordSetTxtCollection GetRecordSetTxts()
        {
            return new RecordSetTxtCollection(Client, Id);
        }

        /// <summary>
        /// Gets a DNS zone. Retrieves the zone properties, but not the record sets within the zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<Zone>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _zoneClientDiagnostics.CreateScope("Zone.Get");
            scope.Start();
            try
            {
                var response = await _zoneRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Zone> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _zoneClientDiagnostics.CreateScope("Zone.Get");
            scope.Start();
            try
            {
                var response = _zoneRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
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
        /// Deletes a DNS zone. WARNING: All DNS records in the zone will also be deleted. This operation cannot be undone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always delete the current zone. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _zoneClientDiagnostics.CreateScope("Zone.Delete");
            scope.Start();
            try
            {
                var response = await _zoneRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtExpandResourceTypesArmOperation(_zoneClientDiagnostics, Pipeline, _zoneRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ifMatch), response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a DNS zone. WARNING: All DNS records in the zone will also be deleted. This operation cannot be undone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always delete the current zone. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _zoneClientDiagnostics.CreateScope("Zone.Delete");
            scope.Start();
            try
            {
                var response = _zoneRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ifMatch, cancellationToken);
                var operation = new MgmtExpandResourceTypesArmOperation(_zoneClientDiagnostics, Pipeline, _zoneRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ifMatch), response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all record sets in a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/recordsets
        /// Operation Id: RecordSets_ListByDnsZone
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="RecordSetA" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RecordSetA> GetRecordSetsAsync(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<RecordSetA>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("Zone.GetRecordSets");
                scope.Start();
                try
                {
                    var response = await _recordSetsRestClient.ListByDnsZoneAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new RecordSetA(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<RecordSetA>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("Zone.GetRecordSets");
                scope.Start();
                try
                {
                    var response = await _recordSetsRestClient.ListByDnsZoneNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new RecordSetA(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all record sets in a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/recordsets
        /// Operation Id: RecordSets_ListByDnsZone
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RecordSetA" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RecordSetA> GetRecordSets(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Page<RecordSetA> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("Zone.GetRecordSets");
                scope.Start();
                try
                {
                    var response = _recordSetsRestClient.ListByDnsZone(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new RecordSetA(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<RecordSetA> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("Zone.GetRecordSets");
                scope.Start();
                try
                {
                    var response = _recordSetsRestClient.ListByDnsZoneNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new RecordSetA(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all record sets in a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/all
        /// Operation Id: RecordSets_ListAllByDnsZone
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordSetNameSuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="RecordSetA" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RecordSetA> GetAllRecordSetsAsync(int? top = null, string recordSetNameSuffix = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<RecordSetA>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("Zone.GetAllRecordSets");
                scope.Start();
                try
                {
                    var response = await _recordSetsRestClient.ListAllByDnsZoneAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordSetNameSuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new RecordSetA(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<RecordSetA>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("Zone.GetAllRecordSets");
                scope.Start();
                try
                {
                    var response = await _recordSetsRestClient.ListAllByDnsZoneNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordSetNameSuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new RecordSetA(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all record sets in a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/all
        /// Operation Id: RecordSets_ListAllByDnsZone
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordSetNameSuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RecordSetA" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RecordSetA> GetAllRecordSets(int? top = null, string recordSetNameSuffix = null, CancellationToken cancellationToken = default)
        {
            Page<RecordSetA> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("Zone.GetAllRecordSets");
                scope.Start();
                try
                {
                    var response = _recordSetsRestClient.ListAllByDnsZone(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordSetNameSuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new RecordSetA(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<RecordSetA> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("Zone.GetAllRecordSets");
                scope.Start();
                try
                {
                    var response = _recordSetsRestClient.ListAllByDnsZoneNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordSetNameSuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new RecordSetA(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public async virtual Task<Response<Zone>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _zoneClientDiagnostics.CreateScope("Zone.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues[key] = value;
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _zoneRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new Zone(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<Zone> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _zoneClientDiagnostics.CreateScope("Zone.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues[key] = value;
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _zoneRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new Zone(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public async virtual Task<Response<Zone>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _zoneClientDiagnostics.CreateScope("Zone.SetTags");
            scope.Start();
            try
            {
                await TagResource.DeleteAsync(true, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _zoneRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new Zone(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<Zone> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _zoneClientDiagnostics.CreateScope("Zone.SetTags");
            scope.Start();
            try
            {
                TagResource.Delete(true, cancellationToken: cancellationToken);
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _zoneRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new Zone(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public async virtual Task<Response<Zone>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _zoneClientDiagnostics.CreateScope("Zone.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.Remove(key);
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _zoneRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new Zone(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<Zone> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _zoneClientDiagnostics.CreateScope("Zone.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues.Remove(key);
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _zoneRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new Zone(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
