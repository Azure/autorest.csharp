// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Tables.Models;

namespace Azure.Storage.Tables
{
    internal partial class TableInternalRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _url;
        private readonly Enum0 _version;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of TableInternalRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="url"> The URL of the service account or table that is the targe of the desired operation. </param>
        /// <param name="version"> Specifies the version of the operation to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="url"/> is null. </exception>
        public TableInternalRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url, Enum0 version)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _url = url ?? throw new ArgumentNullException(nameof(url));
            _version = version;
        }

        internal HttpMessage CreateQueryRequest(Enum1 dataServiceVersion, QueryOptions queryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/Tables", false);
            if (queryOptions?.Format != null)
            {
                uri.AppendQuery("$format", queryOptions.Format.Value.ToString(), true);
            }
            if (queryOptions?.Top != null)
            {
                uri.AppendQuery("$top", queryOptions.Top.Value, true);
            }
            if (queryOptions?.Select != null)
            {
                uri.AppendQuery("$select", queryOptions.Select, true);
            }
            if (queryOptions?.Filter != null)
            {
                uri.AppendQuery("$filter", queryOptions.Filter, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", _version.ToString());
            request.Headers.Add("DataServiceVersion", dataServiceVersion.ToString());
            request.Headers.Add("Accept", "application/json;odata=nometadata");
            return message;
        }

        /// <summary> Queries tables under the given account. </summary>
        /// <param name="dataServiceVersion"> Specifies the data service version. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<TableQueryResponse, TableInternalQueryHeaders>> QueryAsync(Enum1 dataServiceVersion, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateQueryRequest(dataServiceVersion, queryOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new TableInternalQueryHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TableQueryResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = TableQueryResponse.DeserializeTableQueryResponse(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Queries tables under the given account. </summary>
        /// <param name="dataServiceVersion"> Specifies the data service version. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<TableQueryResponse, TableInternalQueryHeaders> Query(Enum1 dataServiceVersion, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateQueryRequest(dataServiceVersion, queryOptions);
            _pipeline.Send(message, cancellationToken);
            var headers = new TableInternalQueryHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TableQueryResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = TableQueryResponse.DeserializeTableQueryResponse(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCreateRequest(Enum1 dataServiceVersion, TableProperties tableProperties, QueryOptions queryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/Tables", false);
            if (queryOptions?.Format != null)
            {
                uri.AppendQuery("$format", queryOptions.Format.Value.ToString(), true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", _version.ToString());
            request.Headers.Add("DataServiceVersion", dataServiceVersion.ToString());
            request.Headers.Add("Accept", "application/json;odata=nometadata");
            request.Headers.Add("Content-Type", "application/json;odata=nometadata");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(tableProperties);
            request.Content = content;
            return message;
        }

        /// <summary> Creates a new table under the given account. </summary>
        /// <param name="dataServiceVersion"> Specifies the data service version. </param>
        /// <param name="tableProperties"> The Table properties. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tableProperties"/> is null. </exception>
        public async Task<ResponseWithHeaders<TableResponse, TableInternalCreateHeaders>> CreateAsync(Enum1 dataServiceVersion, TableProperties tableProperties, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            if (tableProperties == null)
            {
                throw new ArgumentNullException(nameof(tableProperties));
            }

            using var message = CreateCreateRequest(dataServiceVersion, tableProperties, queryOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new TableInternalCreateHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        TableResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = TableResponse.DeserializeTableResponse(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                case 204:
                    return ResponseWithHeaders.FromValue((TableResponse)null, headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates a new table under the given account. </summary>
        /// <param name="dataServiceVersion"> Specifies the data service version. </param>
        /// <param name="tableProperties"> The Table properties. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tableProperties"/> is null. </exception>
        public ResponseWithHeaders<TableResponse, TableInternalCreateHeaders> Create(Enum1 dataServiceVersion, TableProperties tableProperties, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            if (tableProperties == null)
            {
                throw new ArgumentNullException(nameof(tableProperties));
            }

            using var message = CreateCreateRequest(dataServiceVersion, tableProperties, queryOptions);
            _pipeline.Send(message, cancellationToken);
            var headers = new TableInternalCreateHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        TableResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = TableResponse.DeserializeTableResponse(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                case 204:
                    return ResponseWithHeaders.FromValue((TableResponse)null, headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteRequest(string table)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/Tables('", false);
            uri.AppendPath(table, true);
            uri.AppendPath("')", false);
            request.Uri = uri;
            request.Headers.Add("x-ms-version", _version.ToString());
            request.Headers.Add("Accept", "application/json;odata=nometadata");
            return message;
        }

        /// <summary> Operation permanently deletes the specified table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/> is null. </exception>
        public async Task<ResponseWithHeaders<TableInternalDeleteHeaders>> DeleteAsync(string table, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var message = CreateDeleteRequest(table);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new TableInternalDeleteHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 204:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Operation permanently deletes the specified table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/> is null. </exception>
        public ResponseWithHeaders<TableInternalDeleteHeaders> Delete(string table, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var message = CreateDeleteRequest(table);
            _pipeline.Send(message, cancellationToken);
            var headers = new TableInternalDeleteHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 204:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateQueryEntitiesRequest(Enum1 dataServiceVersion, string table, int? timeout, QueryOptions queryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            uri.AppendPath("()", false);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            if (queryOptions?.Format != null)
            {
                uri.AppendQuery("$format", queryOptions.Format.Value.ToString(), true);
            }
            if (queryOptions?.Top != null)
            {
                uri.AppendQuery("$top", queryOptions.Top.Value, true);
            }
            if (queryOptions?.Select != null)
            {
                uri.AppendQuery("$select", queryOptions.Select, true);
            }
            if (queryOptions?.Filter != null)
            {
                uri.AppendQuery("$filter", queryOptions.Filter, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", _version.ToString());
            request.Headers.Add("DataServiceVersion", dataServiceVersion.ToString());
            request.Headers.Add("Accept", "application/json;odata=nometadata");
            return message;
        }

        /// <summary> Queries entities in a table. </summary>
        /// <param name="dataServiceVersion"> Specifies the data service version. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/> is null. </exception>
        public async Task<ResponseWithHeaders<TableEntityQueryResponse, TableInternalQueryEntitiesHeaders>> QueryEntitiesAsync(Enum1 dataServiceVersion, string table, int? timeout = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var message = CreateQueryEntitiesRequest(dataServiceVersion, table, timeout, queryOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new TableInternalQueryEntitiesHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TableEntityQueryResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = TableEntityQueryResponse.DeserializeTableEntityQueryResponse(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Queries entities in a table. </summary>
        /// <param name="dataServiceVersion"> Specifies the data service version. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/> is null. </exception>
        public ResponseWithHeaders<TableEntityQueryResponse, TableInternalQueryEntitiesHeaders> QueryEntities(Enum1 dataServiceVersion, string table, int? timeout = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var message = CreateQueryEntitiesRequest(dataServiceVersion, table, timeout, queryOptions);
            _pipeline.Send(message, cancellationToken);
            var headers = new TableInternalQueryEntitiesHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TableEntityQueryResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = TableEntityQueryResponse.DeserializeTableEntityQueryResponse(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateQueryEntitiesWithPartitionAndRowKeyRequest(Enum1 dataServiceVersion, string table, string partitionKey, string rowKey, int? timeout, QueryOptions queryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            uri.AppendPath("(PartitionKey='", false);
            uri.AppendPath(partitionKey, true);
            uri.AppendPath("',RowKey='", false);
            uri.AppendPath(rowKey, true);
            uri.AppendPath("')", false);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            if (queryOptions?.Format != null)
            {
                uri.AppendQuery("$format", queryOptions.Format.Value.ToString(), true);
            }
            if (queryOptions?.Select != null)
            {
                uri.AppendQuery("$select", queryOptions.Select, true);
            }
            if (queryOptions?.Filter != null)
            {
                uri.AppendQuery("$filter", queryOptions.Filter, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", _version.ToString());
            request.Headers.Add("DataServiceVersion", dataServiceVersion.ToString());
            request.Headers.Add("Accept", "application/json;odata=nometadata");
            return message;
        }

        /// <summary> Queries entities in a table. </summary>
        /// <param name="dataServiceVersion"> Specifies the data service version. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/>, <paramref name="partitionKey"/> or <paramref name="rowKey"/> is null. </exception>
        public async Task<ResponseWithHeaders<TableEntityQueryResponse, TableInternalQueryEntitiesWithPartitionAndRowKeyHeaders>> QueryEntitiesWithPartitionAndRowKeyAsync(Enum1 dataServiceVersion, string table, string partitionKey, string rowKey, int? timeout = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (partitionKey == null)
            {
                throw new ArgumentNullException(nameof(partitionKey));
            }
            if (rowKey == null)
            {
                throw new ArgumentNullException(nameof(rowKey));
            }

            using var message = CreateQueryEntitiesWithPartitionAndRowKeyRequest(dataServiceVersion, table, partitionKey, rowKey, timeout, queryOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new TableInternalQueryEntitiesWithPartitionAndRowKeyHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TableEntityQueryResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = TableEntityQueryResponse.DeserializeTableEntityQueryResponse(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Queries entities in a table. </summary>
        /// <param name="dataServiceVersion"> Specifies the data service version. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/>, <paramref name="partitionKey"/> or <paramref name="rowKey"/> is null. </exception>
        public ResponseWithHeaders<TableEntityQueryResponse, TableInternalQueryEntitiesWithPartitionAndRowKeyHeaders> QueryEntitiesWithPartitionAndRowKey(Enum1 dataServiceVersion, string table, string partitionKey, string rowKey, int? timeout = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (partitionKey == null)
            {
                throw new ArgumentNullException(nameof(partitionKey));
            }
            if (rowKey == null)
            {
                throw new ArgumentNullException(nameof(rowKey));
            }

            using var message = CreateQueryEntitiesWithPartitionAndRowKeyRequest(dataServiceVersion, table, partitionKey, rowKey, timeout, queryOptions);
            _pipeline.Send(message, cancellationToken);
            var headers = new TableInternalQueryEntitiesWithPartitionAndRowKeyHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TableEntityQueryResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = TableEntityQueryResponse.DeserializeTableEntityQueryResponse(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateUpdateEntityRequest(Enum1 dataServiceVersion, string table, string partitionKey, string rowKey, int? timeout, IDictionary<string, object> tableEntityProperties, QueryOptions queryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            uri.AppendPath("(PartitionKey='", false);
            uri.AppendPath(partitionKey, true);
            uri.AppendPath("',RowKey='", false);
            uri.AppendPath(rowKey, true);
            uri.AppendPath("')", false);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            if (queryOptions?.Format != null)
            {
                uri.AppendQuery("$format", queryOptions.Format.Value.ToString(), true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", _version.ToString());
            request.Headers.Add("DataServiceVersion", dataServiceVersion.ToString());
            request.Headers.Add("Accept", "application/json;odata=nometadata");
            if (tableEntityProperties != null)
            {
                request.Headers.Add("Content-Type", "application/json;odata=nometadata");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in tableEntityProperties)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        content.JsonWriter.WriteNullValue();
                        continue;
                    }
                    content.JsonWriter.WriteObjectValue(item.Value);
                }
                content.JsonWriter.WriteEndObject();
                request.Content = content;
            }
            return message;
        }

        /// <summary> Update entity in a table. </summary>
        /// <param name="dataServiceVersion"> Specifies the data service version. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/>, <paramref name="partitionKey"/> or <paramref name="rowKey"/> is null. </exception>
        public async Task<ResponseWithHeaders<TableInternalUpdateEntityHeaders>> UpdateEntityAsync(Enum1 dataServiceVersion, string table, string partitionKey, string rowKey, int? timeout = null, IDictionary<string, object> tableEntityProperties = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (partitionKey == null)
            {
                throw new ArgumentNullException(nameof(partitionKey));
            }
            if (rowKey == null)
            {
                throw new ArgumentNullException(nameof(rowKey));
            }

            using var message = CreateUpdateEntityRequest(dataServiceVersion, table, partitionKey, rowKey, timeout, tableEntityProperties, queryOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new TableInternalUpdateEntityHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 204:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Update entity in a table. </summary>
        /// <param name="dataServiceVersion"> Specifies the data service version. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/>, <paramref name="partitionKey"/> or <paramref name="rowKey"/> is null. </exception>
        public ResponseWithHeaders<TableInternalUpdateEntityHeaders> UpdateEntity(Enum1 dataServiceVersion, string table, string partitionKey, string rowKey, int? timeout = null, IDictionary<string, object> tableEntityProperties = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (partitionKey == null)
            {
                throw new ArgumentNullException(nameof(partitionKey));
            }
            if (rowKey == null)
            {
                throw new ArgumentNullException(nameof(rowKey));
            }

            using var message = CreateUpdateEntityRequest(dataServiceVersion, table, partitionKey, rowKey, timeout, tableEntityProperties, queryOptions);
            _pipeline.Send(message, cancellationToken);
            var headers = new TableInternalUpdateEntityHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 204:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteEntityRequest(Enum1 dataServiceVersion, string table, string partitionKey, string rowKey, int? timeout, QueryOptions queryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            uri.AppendPath("(PartitionKey='", false);
            uri.AppendPath(partitionKey, true);
            uri.AppendPath("',RowKey='", false);
            uri.AppendPath(rowKey, true);
            uri.AppendPath("')", false);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            if (queryOptions?.Format != null)
            {
                uri.AppendQuery("$format", queryOptions.Format.Value.ToString(), true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", _version.ToString());
            request.Headers.Add("DataServiceVersion", dataServiceVersion.ToString());
            request.Headers.Add("Accept", "application/json;odata=nometadata");
            return message;
        }

        /// <summary> Deletes the specified entity in a table. </summary>
        /// <param name="dataServiceVersion"> Specifies the data service version. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/>, <paramref name="partitionKey"/> or <paramref name="rowKey"/> is null. </exception>
        public async Task<ResponseWithHeaders<TableInternalDeleteEntityHeaders>> DeleteEntityAsync(Enum1 dataServiceVersion, string table, string partitionKey, string rowKey, int? timeout = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (partitionKey == null)
            {
                throw new ArgumentNullException(nameof(partitionKey));
            }
            if (rowKey == null)
            {
                throw new ArgumentNullException(nameof(rowKey));
            }

            using var message = CreateDeleteEntityRequest(dataServiceVersion, table, partitionKey, rowKey, timeout, queryOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new TableInternalDeleteEntityHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 204:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Deletes the specified entity in a table. </summary>
        /// <param name="dataServiceVersion"> Specifies the data service version. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/>, <paramref name="partitionKey"/> or <paramref name="rowKey"/> is null. </exception>
        public ResponseWithHeaders<TableInternalDeleteEntityHeaders> DeleteEntity(Enum1 dataServiceVersion, string table, string partitionKey, string rowKey, int? timeout = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (partitionKey == null)
            {
                throw new ArgumentNullException(nameof(partitionKey));
            }
            if (rowKey == null)
            {
                throw new ArgumentNullException(nameof(rowKey));
            }

            using var message = CreateDeleteEntityRequest(dataServiceVersion, table, partitionKey, rowKey, timeout, queryOptions);
            _pipeline.Send(message, cancellationToken);
            var headers = new TableInternalDeleteEntityHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 204:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateInsertEntityRequest(Enum1 dataServiceVersion, string table, int? timeout, IDictionary<string, object> tableEntityProperties, QueryOptions queryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            if (queryOptions?.Format != null)
            {
                uri.AppendQuery("$format", queryOptions.Format.Value.ToString(), true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", _version.ToString());
            request.Headers.Add("DataServiceVersion", dataServiceVersion.ToString());
            request.Headers.Add("Accept", "application/json;odata=nometadata");
            if (tableEntityProperties != null)
            {
                request.Headers.Add("Content-Type", "application/json;odata=nometadata");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in tableEntityProperties)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        content.JsonWriter.WriteNullValue();
                        continue;
                    }
                    content.JsonWriter.WriteObjectValue(item.Value);
                }
                content.JsonWriter.WriteEndObject();
                request.Content = content;
            }
            return message;
        }

        /// <summary> Insert entity in a table. </summary>
        /// <param name="dataServiceVersion"> Specifies the data service version. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/> is null. </exception>
        public async Task<ResponseWithHeaders<IReadOnlyDictionary<string, object>, TableInternalInsertEntityHeaders>> InsertEntityAsync(Enum1 dataServiceVersion, string table, int? timeout = null, IDictionary<string, object> tableEntityProperties = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var message = CreateInsertEntityRequest(dataServiceVersion, table, timeout, tableEntityProperties, queryOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new TableInternalInsertEntityHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        IReadOnlyDictionary<string, object> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        foreach (var property in document.RootElement.EnumerateObject())
                        {
                            if (property.Value.ValueKind == JsonValueKind.Null)
                            {
                                dictionary.Add(property.Name, null);
                            }
                            else
                            {
                                dictionary.Add(property.Name, property.Value.GetObject());
                            }
                        }
                        value = dictionary;
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Insert entity in a table. </summary>
        /// <param name="dataServiceVersion"> Specifies the data service version. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/> is null. </exception>
        public ResponseWithHeaders<IReadOnlyDictionary<string, object>, TableInternalInsertEntityHeaders> InsertEntity(Enum1 dataServiceVersion, string table, int? timeout = null, IDictionary<string, object> tableEntityProperties = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var message = CreateInsertEntityRequest(dataServiceVersion, table, timeout, tableEntityProperties, queryOptions);
            _pipeline.Send(message, cancellationToken);
            var headers = new TableInternalInsertEntityHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        IReadOnlyDictionary<string, object> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        foreach (var property in document.RootElement.EnumerateObject())
                        {
                            if (property.Value.ValueKind == JsonValueKind.Null)
                            {
                                dictionary.Add(property.Name, null);
                            }
                            else
                            {
                                dictionary.Add(property.Name, property.Value.GetObject());
                            }
                        }
                        value = dictionary;
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetAccessPolicyRequest(string table, Enum3 comp, int? timeout)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            uri.AppendQuery("comp", comp.ToString(), true);
            request.Uri = uri;
            request.Headers.Add("x-ms-version", _version.ToString());
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used wit Shared Access Signatures. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="comp"> Required query string to handle stored access policies for the table that may be used with Shared Access Signatures. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/> is null. </exception>
        public async Task<ResponseWithHeaders<IReadOnlyList<SignedIdentifier>, TableInternalGetAccessPolicyHeaders>> GetAccessPolicyAsync(string table, Enum3 comp, int? timeout = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var message = CreateGetAccessPolicyRequest(table, comp, timeout);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new TableInternalGetAccessPolicyHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<SignedIdentifier> value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("SignedIdentifiers") is XElement signedIdentifiersElement)
                        {
                            var array = new List<SignedIdentifier>();
                            foreach (var e in signedIdentifiersElement.Elements("SignedIdentifier"))
                            {
                                array.Add(SignedIdentifier.DeserializeSignedIdentifier(e));
                            }
                            value = array;
                        }
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used wit Shared Access Signatures. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="comp"> Required query string to handle stored access policies for the table that may be used with Shared Access Signatures. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/> is null. </exception>
        public ResponseWithHeaders<IReadOnlyList<SignedIdentifier>, TableInternalGetAccessPolicyHeaders> GetAccessPolicy(string table, Enum3 comp, int? timeout = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var message = CreateGetAccessPolicyRequest(table, comp, timeout);
            _pipeline.Send(message, cancellationToken);
            var headers = new TableInternalGetAccessPolicyHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<SignedIdentifier> value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("SignedIdentifiers") is XElement signedIdentifiersElement)
                        {
                            var array = new List<SignedIdentifier>();
                            foreach (var e in signedIdentifiersElement.Elements("SignedIdentifier"))
                            {
                                array.Add(SignedIdentifier.DeserializeSignedIdentifier(e));
                            }
                            value = array;
                        }
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateSetAccessPolicyRequest(string table, Enum3 comp, int? timeout, IEnumerable<SignedIdentifier> tableAcl)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            uri.AppendQuery("comp", comp.ToString(), true);
            request.Uri = uri;
            request.Headers.Add("x-ms-version", _version.ToString());
            request.Headers.Add("Accept", "application/xml");
            if (tableAcl != null)
            {
                request.Headers.Add("Content-Type", "application/xml");
                var content = new XmlWriterContent();
                content.XmlWriter.WriteStartElement("SignedIdentifiers");
                foreach (var item in tableAcl)
                {
                    content.XmlWriter.WriteObjectValue(item, "SignedIdentifier");
                }
                content.XmlWriter.WriteEndElement();
                request.Content = content;
            }
            return message;
        }

        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="comp"> Required query string to handle stored access policies for the table that may be used with Shared Access Signatures. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="tableAcl"> the acls for the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/> is null. </exception>
        public async Task<ResponseWithHeaders<TableInternalSetAccessPolicyHeaders>> SetAccessPolicyAsync(string table, Enum3 comp, int? timeout = null, IEnumerable<SignedIdentifier> tableAcl = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var message = CreateSetAccessPolicyRequest(table, comp, timeout, tableAcl);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new TableInternalSetAccessPolicyHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 204:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="comp"> Required query string to handle stored access policies for the table that may be used with Shared Access Signatures. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="tableAcl"> the acls for the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/> is null. </exception>
        public ResponseWithHeaders<TableInternalSetAccessPolicyHeaders> SetAccessPolicy(string table, Enum3 comp, int? timeout = null, IEnumerable<SignedIdentifier> tableAcl = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var message = CreateSetAccessPolicyRequest(table, comp, timeout, tableAcl);
            _pipeline.Send(message, cancellationToken);
            var headers = new TableInternalSetAccessPolicyHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 204:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
