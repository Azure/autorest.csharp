// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.Storage.Tables.Models;

namespace Azure.Storage.Tables
{
    public partial class TableClient
    {
        internal TableRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of TableClient. </summary>
        internal TableClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url, string Version = "2018-10-10")
        {
            RestClient = new TableRestClient(clientDiagnostics, pipeline, url, Version);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Queries tables under the given account. </summary>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. &quot;$select=PolicyAssignmentId, ResourceId&quot;. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<TableQueryResponse>> QueryAsync(string requestId, ResponseFormat? format, int? top, string select, string filter, CancellationToken cancellationToken = default)
        {
            return await RestClient.QueryAsync(requestId, format, top, select, filter, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Queries tables under the given account. </summary>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. &quot;$select=PolicyAssignmentId, ResourceId&quot;. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<TableQueryResponse> Query(string requestId, ResponseFormat? format, int? top, string select, string filter, CancellationToken cancellationToken = default)
        {
            return RestClient.Query(requestId, format, top, select, filter, cancellationToken);
        }
        /// <summary> Creates a new table under the given account. </summary>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="tableProperties"> The Table properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<TableResponse>> CreateAsync(string requestId, ResponseFormat? format, TableProperties tableProperties, CancellationToken cancellationToken = default)
        {
            return await RestClient.CreateAsync(requestId, format, tableProperties, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Creates a new table under the given account. </summary>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="tableProperties"> The Table properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<TableResponse> Create(string requestId, ResponseFormat? format, TableProperties tableProperties, CancellationToken cancellationToken = default)
        {
            return RestClient.Create(requestId, format, tableProperties, cancellationToken);
        }
        /// <summary> Operation permanently deletes the specified table. </summary>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DeleteAsync(string requestId, string table, CancellationToken cancellationToken = default)
        {
            return (await RestClient.DeleteAsync(requestId, table, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Operation permanently deletes the specified table. </summary>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete(string requestId, string table, CancellationToken cancellationToken = default)
        {
            return RestClient.Delete(requestId, table, cancellationToken).GetRawResponse();
        }
        /// <summary> Queries entities in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. &quot;$select=PolicyAssignmentId, ResourceId&quot;. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<TableEntityQueryResponse>> QueryEntitiesAsync(int? timeout, string requestId, ResponseFormat? format, int? top, string select, string filter, string table, CancellationToken cancellationToken = default)
        {
            return await RestClient.QueryEntitiesAsync(timeout, requestId, format, top, select, filter, table, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Queries entities in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. &quot;$select=PolicyAssignmentId, ResourceId&quot;. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<TableEntityQueryResponse> QueryEntities(int? timeout, string requestId, ResponseFormat? format, int? top, string select, string filter, string table, CancellationToken cancellationToken = default)
        {
            return RestClient.QueryEntities(timeout, requestId, format, top, select, filter, table, cancellationToken);
        }
        /// <summary> Queries entities in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. &quot;$select=PolicyAssignmentId, ResourceId&quot;. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<TableEntityQueryResponse>> QueryEntitiesWithPartitionAndRowKeyAsync(int? timeout, string requestId, ResponseFormat? format, string select, string filter, string table, string partitionKey, string rowKey, CancellationToken cancellationToken = default)
        {
            return await RestClient.QueryEntitiesWithPartitionAndRowKeyAsync(timeout, requestId, format, select, filter, table, partitionKey, rowKey, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Queries entities in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. &quot;$select=PolicyAssignmentId, ResourceId&quot;. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<TableEntityQueryResponse> QueryEntitiesWithPartitionAndRowKey(int? timeout, string requestId, ResponseFormat? format, string select, string filter, string table, string partitionKey, string rowKey, CancellationToken cancellationToken = default)
        {
            return RestClient.QueryEntitiesWithPartitionAndRowKey(timeout, requestId, format, select, filter, table, partitionKey, rowKey, cancellationToken);
        }
        /// <summary> Update entity in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> UpdateEntityAsync(int? timeout, string requestId, ResponseFormat? format, string table, string partitionKey, string rowKey, IDictionary<string, object> tableEntityProperties, CancellationToken cancellationToken = default)
        {
            return (await RestClient.UpdateEntityAsync(timeout, requestId, format, table, partitionKey, rowKey, tableEntityProperties, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Update entity in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response UpdateEntity(int? timeout, string requestId, ResponseFormat? format, string table, string partitionKey, string rowKey, IDictionary<string, object> tableEntityProperties, CancellationToken cancellationToken = default)
        {
            return RestClient.UpdateEntity(timeout, requestId, format, table, partitionKey, rowKey, tableEntityProperties, cancellationToken).GetRawResponse();
        }
        /// <summary> Deletes the specified entity in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DeleteEntityAsync(int? timeout, string requestId, ResponseFormat? format, string table, string partitionKey, string rowKey, CancellationToken cancellationToken = default)
        {
            return (await RestClient.DeleteEntityAsync(timeout, requestId, format, table, partitionKey, rowKey, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Deletes the specified entity in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DeleteEntity(int? timeout, string requestId, ResponseFormat? format, string table, string partitionKey, string rowKey, CancellationToken cancellationToken = default)
        {
            return RestClient.DeleteEntity(timeout, requestId, format, table, partitionKey, rowKey, cancellationToken).GetRawResponse();
        }
        /// <summary> Insert entity in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, object>>> InsertEntityAsync(int? timeout, string requestId, ResponseFormat? format, string table, IDictionary<string, object> tableEntityProperties, CancellationToken cancellationToken = default)
        {
            return await RestClient.InsertEntityAsync(timeout, requestId, format, table, tableEntityProperties, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Insert entity in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, object>> InsertEntity(int? timeout, string requestId, ResponseFormat? format, string table, IDictionary<string, object> tableEntityProperties, CancellationToken cancellationToken = default)
        {
            return RestClient.InsertEntity(timeout, requestId, format, table, tableEntityProperties, cancellationToken);
        }
        /// <summary> Retrieves details about any stored access policies specified on the table that may be used wit Shared Access Signatures. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<SignedIdentifier>>> GetAccessPolicyAsync(int? timeout, string requestId, string table, CancellationToken cancellationToken = default)
        {
            return await RestClient.GetAccessPolicyAsync(timeout, requestId, table, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Retrieves details about any stored access policies specified on the table that may be used wit Shared Access Signatures. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<SignedIdentifier>> GetAccessPolicy(int? timeout, string requestId, string table, CancellationToken cancellationToken = default)
        {
            return RestClient.GetAccessPolicy(timeout, requestId, table, cancellationToken);
        }
        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="tableAcl"> the acls for the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> SetAccessPolicyAsync(int? timeout, string requestId, string table, IEnumerable<SignedIdentifier> tableAcl, CancellationToken cancellationToken = default)
        {
            return (await RestClient.SetAccessPolicyAsync(timeout, requestId, table, tableAcl, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="tableAcl"> the acls for the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response SetAccessPolicy(int? timeout, string requestId, string table, IEnumerable<SignedIdentifier> tableAcl, CancellationToken cancellationToken = default)
        {
            return RestClient.SetAccessPolicy(timeout, requestId, table, tableAcl, cancellationToken).GetRawResponse();
        }
    }
}
