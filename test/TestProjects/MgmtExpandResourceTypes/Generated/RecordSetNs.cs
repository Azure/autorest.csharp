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
    /// <summary> A Class representing a RecordSetNs along with the instance operations that can be performed on it. </summary>
    public partial class RecordSetNs : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="RecordSetNs"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NS/{relativeRecordSetName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _recordSetNsRecordSetsClientDiagnostics;
        private readonly RecordSetsRestOperations _recordSetNsRecordSetsRestClient;
        private readonly RecordSetData _data;

        /// <summary> Initializes a new instance of the <see cref="RecordSetNs"/> class for mocking. </summary>
        protected RecordSetNs()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "RecordSetNs"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal RecordSetNs(ArmClient client, RecordSetData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="RecordSetNs"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal RecordSetNs(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _recordSetNsRecordSetsClientDiagnostics = new ClientDiagnostics("MgmtExpandResourceTypes", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string recordSetNsRecordSetsApiVersion);
            _recordSetNsRecordSetsRestClient = new RecordSetsRestOperations(_recordSetNsRecordSetsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, recordSetNsRecordSetsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/dnsZones/NS";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual RecordSetData Data
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NS/{relativeRecordSetName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<RecordSetNs>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _recordSetNsRecordSetsClientDiagnostics.CreateScope("RecordSetNs.Get");
            scope.Start();
            try
            {
                var response = await _recordSetNsRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "NS".ToRecordType(), Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _recordSetNsRecordSetsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new RecordSetNs(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NS/{relativeRecordSetName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RecordSetNs> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _recordSetNsRecordSetsClientDiagnostics.CreateScope("RecordSetNs.Get");
            scope.Start();
            try
            {
                var response = _recordSetNsRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "NS".ToRecordType(), Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _recordSetNsRecordSetsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RecordSetNs(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a record set from a DNS zone. This operation cannot be undone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NS/{relativeRecordSetName}
        /// Operation Id: RecordSets_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always delete the current record set. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _recordSetNsRecordSetsClientDiagnostics.CreateScope("RecordSetNs.Delete");
            scope.Start();
            try
            {
                var response = await _recordSetNsRecordSetsRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "NS".ToRecordType(), Id.Name, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtExpandResourceTypesArmOperation(response);
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
        /// Deletes a record set from a DNS zone. This operation cannot be undone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NS/{relativeRecordSetName}
        /// Operation Id: RecordSets_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always delete the current record set. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _recordSetNsRecordSetsClientDiagnostics.CreateScope("RecordSetNs.Delete");
            scope.Start();
            try
            {
                var response = _recordSetNsRecordSetsRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "NS".ToRecordType(), Id.Name, ifMatch, cancellationToken);
                var operation = new MgmtExpandResourceTypesArmOperation(response);
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
        /// Updates a record set within a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NS/{relativeRecordSetName}
        /// Operation Id: RecordSets_Update
        /// </summary>
        /// <param name="parameters"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<RecordSetNs>> UpdateAsync(RecordSetData parameters, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _recordSetNsRecordSetsClientDiagnostics.CreateScope("RecordSetNs.Update");
            scope.Start();
            try
            {
                var response = await _recordSetNsRecordSetsRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "NS".ToRecordType(), Id.Name, parameters, ifMatch, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new RecordSetNs(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates a record set within a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/NS/{relativeRecordSetName}
        /// Operation Id: RecordSets_Update
        /// </summary>
        /// <param name="parameters"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual Response<RecordSetNs> Update(RecordSetData parameters, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _recordSetNsRecordSetsClientDiagnostics.CreateScope("RecordSetNs.Update");
            scope.Start();
            try
            {
                var response = _recordSetNsRecordSetsRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "NS".ToRecordType(), Id.Name, parameters, ifMatch, cancellationToken);
                return Response.FromValue(new RecordSetNs(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
