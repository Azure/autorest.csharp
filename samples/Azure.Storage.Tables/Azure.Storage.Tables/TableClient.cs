using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Tables
{
    public class TableClient
    {
        private readonly string _table;
        private readonly ResponseFormat _format;
        private readonly int _operationTimeout;
        private readonly TableOperations _tableOperations;

        internal TableClient(string table, TableOperations tableOperations)
        {
            _tableOperations = tableOperations;
            _table = table;
            _format = ResponseFormat.ApplicationJsonOdataFullmetadata;
            _operationTimeout = 100;
        }

        public async Task<Response<IDictionary<string, object>>> InsertAsync(IDictionary<string, object> entity, CancellationToken cancellationToken = default)
        {
            ResponseWithHeaders<IDictionary<string, object>, InsertEntityHeaders> response =
                await _tableOperations.InsertEntityAsync(_operationTimeout, string.Empty, _format, _table, entity, cancellationToken)
                    .ConfigureAwait(false);

            return response;
        }

        public async Task<Response> UpdateAsync(string partitionKey, string rowKey, IDictionary<string, object> entity, CancellationToken cancellationToken= default)
        {
            return (await _tableOperations.UpdateEntityAsync(_operationTimeout, string.Empty, _format, _table, partitionKey, rowKey, entity, cancellationToken)).GetRawResponse();
        }

        public AsyncPageable<IDictionary<string, object>> QueryAsync(string select = null, string filter = null, int? limit = null, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(async tableName =>
            {
                var response = await _tableOperations.QueryEntitiesAsync(_operationTimeout, string.Empty, _format, limit, @select, filter, _table, cancellationToken);
                return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
            });
        }
    }
}