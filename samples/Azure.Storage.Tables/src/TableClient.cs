// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Tables.Models;

namespace Azure.Storage.Tables
{
    /// <summary>
    /// A <see cref="TableClient"/> represents a Client to the Azure.
    /// </summary>
    public class TableClient
    {
        private readonly string _table;
        private readonly ResponseFormat _format;
        private readonly TableInternalClient _tableOperations;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableClient"/> for mocking.
        /// </summary>
        protected TableClient() { }

        internal TableClient(string table, TableInternalClient tableOperations)
        {
            _tableOperations = tableOperations;
            _table = table;
            _format = ResponseFormat.ApplicationJsonOdataFullmetadata;
        }

        /// <summary>
        /// Insert into a table entity.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <param name="cancellationToken">The cancellationToken to use.</param>
        public virtual async Task<Response<IReadOnlyDictionary<string, object>>> InsertAsync(IDictionary<string, object> entity, CancellationToken cancellationToken = default)
        {
            Response<IReadOnlyDictionary<string, object>> response =
                await _tableOperations.InsertEntityAsync(Enum1.Three0, _table,
                        tableEntityProperties: entity,
                        queryOptions: new QueryOptions() { Format = _format },cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

            return response;
        }
        /// <summary>
        /// Insert into a table entity.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <param name="cancellationToken">The cancellationToken to use.</param>
        public virtual Response<IReadOnlyDictionary<string, object>> Insert(IDictionary<string, object> entity, CancellationToken cancellationToken = default)
        {
            Response<IReadOnlyDictionary<string, object>> response =
                _tableOperations.InsertEntity(Enum1.Three0, _table,
                        tableEntityProperties: entity,
                        queryOptions: new QueryOptions() { Format = _format }, cancellationToken: cancellationToken);

            return response;
        }

        /// <summary>
        /// Updates a table entity.
        /// </summary>
        /// <param name="partitionKey">The partiionKey to use.</param>
        /// <param name="rowKey">The rowKey to use.</param>
        /// <param name="entity">The entity to use.</param>
        /// <param name="cancellationToken">The cancellationToken to use.</param>
        public virtual async Task<Response> UpdateAsync(string partitionKey, string rowKey, IDictionary<string, object> entity, CancellationToken cancellationToken= default)
        {
            return await _tableOperations.UpdateEntityAsync(Enum1.Three0, _table, partitionKey, rowKey,
                tableEntityProperties: entity,
                queryOptions:new QueryOptions() { Format = _format },
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates a table entity.
        /// </summary>
        /// <param name="partitionKey">The partiionKey to use.</param>
        /// <param name="rowKey">The rowKey to use.</param>
        /// <param name="entity">The entity to use.</param>
        /// <param name="cancellationToken">The cancellationToken to use.</param>
        public virtual  Response Update(string partitionKey, string rowKey, IDictionary<string, object> entity, CancellationToken cancellationToken = default)
        {
            return  _tableOperations.UpdateEntity(Enum1.Three0, _table, partitionKey, rowKey,
                tableEntityProperties: entity,
                queryOptions: new QueryOptions() { Format = _format },
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Query a table entity.
        /// </summary>
        /// <param name="select">The select to use.</param>
        /// <param name="filter">The filter to use.</param>
        /// <param name="limit">The limit to use.</param>
        /// <param name="cancellationToken">The cancellationToken to use.</param>
        public virtual AsyncPageable<IDictionary<string, object>> QueryAsync(string select = null, string filter = null, int? limit = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? _) => _tableOperations.RestClient.CreateQueryEntitiesRequest(Enum1.Three0, _table, null, new QueryOptions { Format = _format, Top = limit, Filter = filter, Select = select});
            static (List<IDictionary<string, object>>?, string?) ParseResponse(Response response)
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var items = TableEntityQueryResponse.DeserializeTableEntityQueryResponse(document.RootElement).Value.ToList();
                var nextLink = new TableInternalQueryEntitiesHeaders(response).XMsContinuationNextPartitionKey;
                return (items, nextLink);
            }

            var requestContext = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, ParseResponse, _tableOperations.Diagnostics, _tableOperations.Pipeline, $"{nameof(TableClient)}.Query", requestContext);
        }

        /// <summary>
        /// Query a table entity.
        /// </summary>
        /// <param name="select">The select to use.</param>
        /// <param name="filter">The filter to use.</param>
        /// <param name="limit">The limit to use.</param>
        /// <param name="cancellationToken">The cancellationToken to use.</param>
        public virtual Pageable<IDictionary<string, object>> Query(string select = null, string filter = null, int? limit = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? _) => _tableOperations.RestClient.CreateQueryEntitiesRequest(Enum1.Three0, _table, null, new QueryOptions { Format = _format, Top = limit, Filter = filter, Select = select });
            static (List<IDictionary<string, object>>?, string?) ParseResponse(Response response)
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var items = TableEntityQueryResponse.DeserializeTableEntityQueryResponse(document.RootElement).Value.ToList();
                var nextLink = new TableInternalQueryEntitiesHeaders(response).XMsContinuationNextPartitionKey;
                return (items, nextLink);
            }

            var requestContext = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            return PageableHelpers.CreatePageable(FirstPageRequest, null, ParseResponse, _tableOperations.Diagnostics, _tableOperations.Pipeline, $"{nameof(TableClient)}.Query", requestContext);
        }
    }
}
