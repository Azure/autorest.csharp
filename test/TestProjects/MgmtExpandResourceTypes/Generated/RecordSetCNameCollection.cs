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
using MgmtExpandResourceTypes.Models;

namespace MgmtExpandResourceTypes
{
    /// <summary> A class representing collection of RecordSetCName and their operations over its parent. </summary>
    public partial class RecordSetCNameCollection : ArmCollection, IEnumerable<RecordSetCName>, IAsyncEnumerable<RecordSetCName>
    {
        private readonly ClientDiagnostics _recordSetCNameRecordSetsClientDiagnostics;
        private readonly RecordSetsRestOperations _recordSetCNameRecordSetsRestClient;

        /// <summary> Initializes a new instance of the <see cref="RecordSetCNameCollection"/> class for mocking. </summary>
        protected RecordSetCNameCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="RecordSetCNameCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal RecordSetCNameCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _recordSetCNameRecordSetsClientDiagnostics = new ClientDiagnostics("MgmtExpandResourceTypes", RecordSetCName.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(RecordSetCName.ResourceType, out string recordSetCNameRecordSetsApiVersion);
            _recordSetCNameRecordSetsRestClient = new RecordSetsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, recordSetCNameRecordSetsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Zone.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Zone.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a record set within a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME/{relativeRecordSetName}
        /// Operation Id: RecordSets_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="parameters"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relativeRecordSetName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<RecordSetCName>> CreateOrUpdateAsync(WaitUntil waitUntil, string relativeRecordSetName, RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _recordSetCNameRecordSetsClientDiagnostics.CreateScope("RecordSetCNameCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _recordSetCNameRecordSetsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CNAME".ToRecordType(), relativeRecordSetName, parameters, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtExpandResourceTypesArmOperation<RecordSetCName>(Response.FromValue(new RecordSetCName(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME/{relativeRecordSetName}
        /// Operation Id: RecordSets_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="parameters"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relativeRecordSetName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<RecordSetCName> CreateOrUpdate(WaitUntil waitUntil, string relativeRecordSetName, RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _recordSetCNameRecordSetsClientDiagnostics.CreateScope("RecordSetCNameCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _recordSetCNameRecordSetsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CNAME".ToRecordType(), relativeRecordSetName, parameters, ifMatch, ifNoneMatch, cancellationToken);
                var operation = new MgmtExpandResourceTypesArmOperation<RecordSetCName>(Response.FromValue(new RecordSetCName(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME/{relativeRecordSetName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relativeRecordSetName"/> is null. </exception>
        public virtual async Task<Response<RecordSetCName>> GetAsync(string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var scope = _recordSetCNameRecordSetsClientDiagnostics.CreateScope("RecordSetCNameCollection.Get");
            scope.Start();
            try
            {
                var response = await _recordSetCNameRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CNAME".ToRecordType(), relativeRecordSetName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RecordSetCName(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME/{relativeRecordSetName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relativeRecordSetName"/> is null. </exception>
        public virtual Response<RecordSetCName> Get(string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var scope = _recordSetCNameRecordSetsClientDiagnostics.CreateScope("RecordSetCNameCollection.Get");
            scope.Start();
            try
            {
                var response = _recordSetCNameRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CNAME".ToRecordType(), relativeRecordSetName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RecordSetCName(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the record sets of a specified type in a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME
        /// Operation Id: RecordSets_ListByType
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="RecordSetCName" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RecordSetCName> GetAllAsync(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<RecordSetCName>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _recordSetCNameRecordSetsClientDiagnostics.CreateScope("RecordSetCNameCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _recordSetCNameRecordSetsRestClient.ListByTypeAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CNAME".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new RecordSetCName(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<RecordSetCName>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _recordSetCNameRecordSetsClientDiagnostics.CreateScope("RecordSetCNameCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _recordSetCNameRecordSetsRestClient.ListByTypeNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CNAME".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new RecordSetCName(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the record sets of a specified type in a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME
        /// Operation Id: RecordSets_ListByType
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RecordSetCName" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RecordSetCName> GetAll(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Page<RecordSetCName> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _recordSetCNameRecordSetsClientDiagnostics.CreateScope("RecordSetCNameCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _recordSetCNameRecordSetsRestClient.ListByType(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CNAME".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new RecordSetCName(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<RecordSetCName> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _recordSetCNameRecordSetsClientDiagnostics.CreateScope("RecordSetCNameCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _recordSetCNameRecordSetsRestClient.ListByTypeNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CNAME".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new RecordSetCName(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME/{relativeRecordSetName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relativeRecordSetName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var scope = _recordSetCNameRecordSetsClientDiagnostics.CreateScope("RecordSetCNameCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(relativeRecordSetName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME/{relativeRecordSetName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relativeRecordSetName"/> is null. </exception>
        public virtual Response<bool> Exists(string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var scope = _recordSetCNameRecordSetsClientDiagnostics.CreateScope("RecordSetCNameCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(relativeRecordSetName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME/{relativeRecordSetName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relativeRecordSetName"/> is null. </exception>
        public virtual async Task<Response<RecordSetCName>> GetIfExistsAsync(string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var scope = _recordSetCNameRecordSetsClientDiagnostics.CreateScope("RecordSetCNameCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _recordSetCNameRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CNAME".ToRecordType(), relativeRecordSetName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<RecordSetCName>(null, response.GetRawResponse());
                return Response.FromValue(new RecordSetCName(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/CNAME/{relativeRecordSetName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="relativeRecordSetName"/> is null. </exception>
        public virtual Response<RecordSetCName> GetIfExists(string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var scope = _recordSetCNameRecordSetsClientDiagnostics.CreateScope("RecordSetCNameCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _recordSetCNameRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CNAME".ToRecordType(), relativeRecordSetName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<RecordSetCName>(null, response.GetRawResponse());
                return Response.FromValue(new RecordSetCName(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<RecordSetCName> IEnumerable<RecordSetCName>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<RecordSetCName> IAsyncEnumerable<RecordSetCName>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
