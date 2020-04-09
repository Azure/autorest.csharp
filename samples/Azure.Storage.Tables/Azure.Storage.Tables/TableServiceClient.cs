// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Tables.Models;

namespace Azure.Storage.Tables
{
    public class TableServiceClient
    {
        private readonly TableInternalClient _tableOperations;
        private readonly ResponseFormat _format = ResponseFormat.ApplicationJsonOdataFullmetadata;

        public TableServiceClient(Uri endpoint, StorageSharedKeyCredential credential, TableClientOptions options = null)
        {
            options ??= new TableClientOptions();

            var endpoint1 = endpoint.ToString();
            var pipeline = HttpPipelineBuilder.Build(options, new TablesSharedKeyPipelinePolicy(credential));
            var diagnostics = new ClientDiagnostics(options);
            _tableOperations = new TableInternalClient(diagnostics, pipeline, endpoint1, "2019-02-02");
        }

        public TableClient GetTableClient(string tableName)
        {
            return new TableClient(tableName, _tableOperations);
        }

        public AsyncPageable<TableResponseProperties> GetTablesAsync(CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                var response = await _tableOperations.RestClient.QueryAsync(null, new QueryOptions() { Format = _format }, cancellationToken);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }, (_, __) => throw new NotImplementedException());
        }
    }
}
