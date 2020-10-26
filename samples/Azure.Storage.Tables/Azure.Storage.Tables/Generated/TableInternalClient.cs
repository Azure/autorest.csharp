// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.Storage.Tables.Models;

namespace Azure.Storage.Tables
{
    /// <summary> The TableInternal service client. </summary>
    internal partial class TableInternalClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal TableInternalRestClient RestClient { get; }
        /// <summary> Initializes a new instance of TableInternalClient for mocking. </summary>
        protected TableInternalClient()
        {
        }
        /// <summary> Initializes a new instance of TableInternalClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="url"> The URL of the service account or table that is the targe of the desired operation. </param>
        /// <param name="version"> Specifies the version of the operation to use for this request. </param>
        internal TableInternalClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url, string version = "2018-10-10")
        {
            RestClient = new TableInternalRestClient(clientDiagnostics, pipeline, url, version);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Queries tables under the given account. </summary>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TableQueryResponse>> QueryAsync(QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.Query");
            scope.Start();
            try
            {
                return await RestClient.QueryAsync(queryOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queries tables under the given account. </summary>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TableQueryResponse> Query(QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.Query");
            scope.Start();
            try
            {
                return RestClient.Query(queryOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new table under the given account. </summary>
        /// <param name="tableProperties"> The Table properties. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TableResponse>> CreateAsync(TableProperties tableProperties, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.Create");
            scope.Start();
            try
            {
                return await RestClient.CreateAsync(tableProperties, queryOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new table under the given account. </summary>
        /// <param name="tableProperties"> The Table properties. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TableResponse> Create(TableProperties tableProperties, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.Create");
            scope.Start();
            try
            {
                return RestClient.Create(tableProperties, queryOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation permanently deletes the specified table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteAsync(string table, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.Delete");
            scope.Start();
            try
            {
                return (await RestClient.DeleteAsync(table, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation permanently deletes the specified table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete(string table, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.Delete");
            scope.Start();
            try
            {
                return RestClient.Delete(table, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queries entities in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TableEntityQueryResponse>> QueryEntitiesAsync(string table, int? timeout = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.QueryEntities");
            scope.Start();
            try
            {
                return await RestClient.QueryEntitiesAsync(table, timeout, queryOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queries entities in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TableEntityQueryResponse> QueryEntities(string table, int? timeout = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.QueryEntities");
            scope.Start();
            try
            {
                return RestClient.QueryEntities(table, timeout, queryOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queries entities in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TableEntityQueryResponse>> QueryEntitiesWithPartitionAndRowKeyAsync(string table, string partitionKey, string rowKey, int? timeout = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.QueryEntitiesWithPartitionAndRowKey");
            scope.Start();
            try
            {
                return await RestClient.QueryEntitiesWithPartitionAndRowKeyAsync(table, partitionKey, rowKey, timeout, queryOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queries entities in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TableEntityQueryResponse> QueryEntitiesWithPartitionAndRowKey(string table, string partitionKey, string rowKey, int? timeout = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.QueryEntitiesWithPartitionAndRowKey");
            scope.Start();
            try
            {
                return RestClient.QueryEntitiesWithPartitionAndRowKey(table, partitionKey, rowKey, timeout, queryOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update entity in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> UpdateEntityAsync(string table, string partitionKey, string rowKey, int? timeout = null, IDictionary<string, object> tableEntityProperties = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.UpdateEntity");
            scope.Start();
            try
            {
                return (await RestClient.UpdateEntityAsync(table, partitionKey, rowKey, timeout, tableEntityProperties, queryOptions, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update entity in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response UpdateEntity(string table, string partitionKey, string rowKey, int? timeout = null, IDictionary<string, object> tableEntityProperties = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.UpdateEntity");
            scope.Start();
            try
            {
                return RestClient.UpdateEntity(table, partitionKey, rowKey, timeout, tableEntityProperties, queryOptions, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes the specified entity in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteEntityAsync(string table, string partitionKey, string rowKey, int? timeout = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.DeleteEntity");
            scope.Start();
            try
            {
                return (await RestClient.DeleteEntityAsync(table, partitionKey, rowKey, timeout, queryOptions, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes the specified entity in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeleteEntity(string table, string partitionKey, string rowKey, int? timeout = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.DeleteEntity");
            scope.Start();
            try
            {
                return RestClient.DeleteEntity(table, partitionKey, rowKey, timeout, queryOptions, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Insert entity in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, object>>> InsertEntityAsync(string table, int? timeout = null, IDictionary<string, object> tableEntityProperties = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.InsertEntity");
            scope.Start();
            try
            {
                return await RestClient.InsertEntityAsync(table, timeout, tableEntityProperties, queryOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Insert entity in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, object>> InsertEntity(string table, int? timeout = null, IDictionary<string, object> tableEntityProperties = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.InsertEntity");
            scope.Start();
            try
            {
                return RestClient.InsertEntity(table, timeout, tableEntityProperties, queryOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used wit Shared Access Signatures. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<SignedIdentifier>>> GetAccessPolicyAsync(string table, int? timeout = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.GetAccessPolicy");
            scope.Start();
            try
            {
                return await RestClient.GetAccessPolicyAsync(table, timeout, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used wit Shared Access Signatures. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<SignedIdentifier>> GetAccessPolicy(string table, int? timeout = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.GetAccessPolicy");
            scope.Start();
            try
            {
                return RestClient.GetAccessPolicy(table, timeout, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="tableAcl"> the acls for the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> SetAccessPolicyAsync(string table, int? timeout = null, IEnumerable<SignedIdentifier> tableAcl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.SetAccessPolicy");
            scope.Start();
            try
            {
                return (await RestClient.SetAccessPolicyAsync(table, timeout, tableAcl, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="tableAcl"> the acls for the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response SetAccessPolicy(string table, int? timeout = null, IEnumerable<SignedIdentifier> tableAcl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.SetAccessPolicy");
            scope.Start();
            try
            {
                return RestClient.SetAccessPolicy(table, timeout, tableAcl, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
