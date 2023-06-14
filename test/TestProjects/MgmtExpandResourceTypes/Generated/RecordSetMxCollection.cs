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
using MgmtExpandResourceTypes.Models;

namespace MgmtExpandResourceTypes
{
    /// <summary>
    /// A class representing a collection of <see cref="RecordSetMxResource" /> and their operations.
    /// Each <see cref="RecordSetMxResource" /> in the collection will belong to the same instance of <see cref="ZoneResource" />.
    /// To get a <see cref="RecordSetMxCollection" /> instance call the GetRecordSetMxes method from an instance of <see cref="ZoneResource" />.
    /// </summary>
    public partial class RecordSetMxCollection : ArmCollection, IEnumerable<RecordSetMxResource>, IAsyncEnumerable<RecordSetMxResource>
    {
        private readonly ClientDiagnostics _recordSetMxRecordSetsClientDiagnostics;
        private readonly RecordSetsRestOperations _recordSetMxRecordSetsRestClient;

        /// <summary> Initializes a new instance of the <see cref="RecordSetMxCollection"/> class for mocking. </summary>
        protected RecordSetMxCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="RecordSetMxCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal RecordSetMxCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _recordSetMxRecordSetsClientDiagnostics = new ClientDiagnostics("MgmtExpandResourceTypes", RecordSetMxResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(RecordSetMxResource.ResourceType, out string recordSetMxRecordSetsApiVersion);
            _recordSetMxRecordSetsRestClient = new RecordSetsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, recordSetMxRecordSetsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ZoneResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ZoneResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a record set within a DNS zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<RecordSetMxResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string relativeRecordSetName, RecordSetData data, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _recordSetMxRecordSetsClientDiagnostics.CreateScope("RecordSetMxCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _recordSetMxRecordSetsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), relativeRecordSetName, data, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtExpandResourceTypesArmOperation<RecordSetMxResource>(Response.FromValue(new RecordSetMxResource(Client, response), response.GetRawResponse()));
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
        /// Creates or updates a record set within a DNS zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<RecordSetMxResource> CreateOrUpdate(WaitUntil waitUntil, string relativeRecordSetName, RecordSetData data, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _recordSetMxRecordSetsClientDiagnostics.CreateScope("RecordSetMxCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _recordSetMxRecordSetsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), relativeRecordSetName, data, ifMatch, ifNoneMatch, cancellationToken);
                var operation = new MgmtExpandResourceTypesArmOperation<RecordSetMxResource>(Response.FromValue(new RecordSetMxResource(Client, response), response.GetRawResponse()));
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
        /// Gets a record set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relativeRecordSetName"/> is null. </exception>
        public virtual async Task<Response<RecordSetMxResource>> GetAsync(string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var scope = _recordSetMxRecordSetsClientDiagnostics.CreateScope("RecordSetMxCollection.Get");
            scope.Start();
            try
            {
                var response = await _recordSetMxRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), relativeRecordSetName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RecordSetMxResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a record set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relativeRecordSetName"/> is null. </exception>
        public virtual Response<RecordSetMxResource> Get(string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var scope = _recordSetMxRecordSetsClientDiagnostics.CreateScope("RecordSetMxCollection.Get");
            scope.Start();
            try
            {
                var response = _recordSetMxRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), relativeRecordSetName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RecordSetMxResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the record sets of a specified type in a DNS zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_ListByType</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="RecordSetMxResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RecordSetMxResource> GetAllAsync(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _recordSetMxRecordSetsRestClient.CreateListByTypeRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), top, recordsetnamesuffix);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _recordSetMxRecordSetsRestClient.CreateListByTypeNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), top, recordsetnamesuffix);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new RecordSetMxResource(Client, RecordSetData.DeserializeRecordSetData(e)), _recordSetMxRecordSetsClientDiagnostics, Pipeline, "RecordSetMxCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists the record sets of a specified type in a DNS zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_ListByType</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RecordSetMxResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RecordSetMxResource> GetAll(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _recordSetMxRecordSetsRestClient.CreateListByTypeRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), top, recordsetnamesuffix);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _recordSetMxRecordSetsRestClient.CreateListByTypeNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), top, recordsetnamesuffix);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new RecordSetMxResource(Client, RecordSetData.DeserializeRecordSetData(e)), _recordSetMxRecordSetsClientDiagnostics, Pipeline, "RecordSetMxCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relativeRecordSetName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var scope = _recordSetMxRecordSetsClientDiagnostics.CreateScope("RecordSetMxCollection.Exists");
            scope.Start();
            try
            {
                var response = await _recordSetMxRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), relativeRecordSetName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relativeRecordSetName"/> is null. </exception>
        public virtual Response<bool> Exists(string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var scope = _recordSetMxRecordSetsClientDiagnostics.CreateScope("RecordSetMxCollection.Exists");
            scope.Start();
            try
            {
                var response = _recordSetMxRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), relativeRecordSetName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<RecordSetMxResource> IEnumerable<RecordSetMxResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<RecordSetMxResource> IAsyncEnumerable<RecordSetMxResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
