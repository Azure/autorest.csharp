// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
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
    /// <summary> A Class representing a RecordSetAaaaResource along with the instance operations that can be performed on it. </summary>
    public partial class RecordSetAaaaResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="RecordSetAaaaResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA/{relativeRecordSetName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _recordSetAaaaResourceRecordSetsClientDiagnostics;
        private readonly RecordSetsRestOperations _recordSetAaaaResourceRecordSetsRestClient;
        private readonly RecordSetResourceData _data;

        /// <summary> Initializes a new instance of the <see cref="RecordSetAaaaResource"/> class for mocking. </summary>
        protected RecordSetAaaaResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "RecordSetAaaaResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal RecordSetAaaaResource(ArmClient client, RecordSetResourceData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="RecordSetAaaaResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal RecordSetAaaaResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _recordSetAaaaResourceRecordSetsClientDiagnostics = new ClientDiagnostics("MgmtExpandResourceTypes", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string recordSetAaaaResourceRecordSetsApiVersion);
            _recordSetAaaaResourceRecordSetsRestClient = new RecordSetsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, recordSetAaaaResourceRecordSetsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/dnsZones/AAAA";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual RecordSetResourceData Data
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

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA/{relativeRecordSetName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RecordSetAaaaResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _recordSetAaaaResourceRecordSetsClientDiagnostics.CreateScope("RecordSetAaaaResource.Get");
            scope.Start();
            try
            {
                var response = await _recordSetAaaaResourceRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "AAAA".ToRecordType(), Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RecordSetAaaaResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA/{relativeRecordSetName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RecordSetAaaaResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _recordSetAaaaResourceRecordSetsClientDiagnostics.CreateScope("RecordSetAaaaResource.Get");
            scope.Start();
            try
            {
                var response = _recordSetAaaaResourceRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "AAAA".ToRecordType(), Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RecordSetAaaaResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a record set from a DNS zone. This operation cannot be undone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA/{relativeRecordSetName}
        /// Operation Id: RecordSets_Delete
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always delete the current record set. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _recordSetAaaaResourceRecordSetsClientDiagnostics.CreateScope("RecordSetAaaaResource.Delete");
            scope.Start();
            try
            {
                var response = await _recordSetAaaaResourceRecordSetsRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "AAAA".ToRecordType(), Id.Name, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtExpandResourceTypesArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
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
        /// Deletes a record set from a DNS zone. This operation cannot be undone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA/{relativeRecordSetName}
        /// Operation Id: RecordSets_Delete
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always delete the current record set. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _recordSetAaaaResourceRecordSetsClientDiagnostics.CreateScope("RecordSetAaaaResource.Delete");
            scope.Start();
            try
            {
                var response = _recordSetAaaaResourceRecordSetsRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "AAAA".ToRecordType(), Id.Name, ifMatch, cancellationToken);
                var operation = new MgmtExpandResourceTypesArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
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
        /// Updates a record set within a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA/{relativeRecordSetName}
        /// Operation Id: RecordSets_Update
        /// </summary>
        /// <param name="parameters"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual async Task<Response<RecordSetAaaaResource>> UpdateAsync(RecordSetResourceData parameters, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _recordSetAaaaResourceRecordSetsClientDiagnostics.CreateScope("RecordSetAaaaResource.Update");
            scope.Start();
            try
            {
                var response = await _recordSetAaaaResourceRecordSetsRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "AAAA".ToRecordType(), Id.Name, parameters, ifMatch, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new RecordSetAaaaResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates a record set within a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA/{relativeRecordSetName}
        /// Operation Id: RecordSets_Update
        /// </summary>
        /// <param name="parameters"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual Response<RecordSetAaaaResource> Update(RecordSetResourceData parameters, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _recordSetAaaaResourceRecordSetsClientDiagnostics.CreateScope("RecordSetAaaaResource.Update");
            scope.Start();
            try
            {
                var response = _recordSetAaaaResourceRecordSetsRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "AAAA".ToRecordType(), Id.Name, parameters, ifMatch, cancellationToken);
                return Response.FromValue(new RecordSetAaaaResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
