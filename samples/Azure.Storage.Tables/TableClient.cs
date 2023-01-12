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
    public class TableClient
    {
        private readonly string _table;
        private readonly ResponseFormat _format;
        private readonly TableInternalClient _tableOperations;

        internal TableClient(string table, TableInternalClient tableOperations)
        {
            _tableOperations = tableOperations;
            _table = table;
            _format = ResponseFormat.ApplicationJsonOdataFullmetadata;
        }

        public async Task<Response<IReadOnlyDictionary<string, object>>> InsertAsync(IDictionary<string, object> entity, CancellationToken cancellationToken = default)
        {
            Response<IReadOnlyDictionary<string, object>> response =
                await _tableOperations.InsertEntityAsync(Enum1.Three0, _table,
                        tableEntityProperties: entity,
                        queryOptions: new QueryOptions() { Format = _format },cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

            return response;
        }

        public async Task<Response> UpdateAsync(string partitionKey, string rowKey, IDictionary<string, object> entity, CancellationToken cancellationToken= default)
        {
            return await _tableOperations.UpdateEntityAsync(Enum1.Three0, _table, partitionKey, rowKey,
                tableEntityProperties: entity,
                queryOptions:new QueryOptions() { Format = _format },
                cancellationToken: cancellationToken);
        }

        public AsyncPageable<IDictionary<string, object>> QueryAsync(string select = null, string filter = null, int? limit = null, CancellationToken cancellationToken = default)
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
    }
}
