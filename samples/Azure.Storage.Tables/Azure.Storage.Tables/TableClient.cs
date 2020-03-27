using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Tables.Models;

namespace Azure.Storage.Tables
{
    public class TableClient
    {
        private readonly string _table;
        private readonly ResponseFormat _format;
        private readonly int _operationTimeout;
        private readonly TableInternalClient _tableOperations;

        internal TableClient(string table, TableInternalClient tableOperations)
        {
            _tableOperations = tableOperations;
            _table = table;
            _format = ResponseFormat.ApplicationJsonOdataFullmetadata;
            _operationTimeout = 100;
        }

        public async Task<Response<IReadOnlyDictionary<string, object>>> InsertAsync(IDictionary<string, object> entity, CancellationToken cancellationToken = default)
        {
            Response<IReadOnlyDictionary<string, object>> response =
                await _tableOperations.InsertEntityAsync(_operationTimeout, string.Empty,_table, entity, new QueryOptions() { Format = _format }, cancellationToken)
                    .ConfigureAwait(false);

            return response;
        }

        public async Task<Response> UpdateAsync(string partitionKey, string rowKey, IDictionary<string, object> entity, CancellationToken cancellationToken= default)
        {
            return await _tableOperations.UpdateEntityAsync(_operationTimeout, string.Empty, _table, partitionKey, rowKey, entity, new QueryOptions() { Format = _format }, cancellationToken);
        }

        public AsyncPageable<IDictionary<string, object>> QueryAsync(string select = null, string filter = null, int? limit = null, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(async tableName =>
            {
                var response = await _tableOperations.RestClient.QueryEntitiesAsync(_operationTimeout, string.Empty, _table,  new QueryOptions() { Format = _format, Top = limit, Filter = filter, Select = @select},  cancellationToken);
                return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
            },(_, __) => throw new NotImplementedException());
        }
    }
}
