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
            var requestContext = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? _) => _tableOperations.RestClient.CreateQueryRequest(Enum1.Three0, new QueryOptions { Format = _format });
            static (List<TableResponseProperties>?, string?) ParseResponse(Response response)
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var items = TableQueryResponse.DeserializeTableQueryResponse(document.RootElement).Value.ToList();
                var nextLink = new TableInternalQueryHeaders(response).XMsContinuationNextTableName;
                return (items, nextLink);
            }

            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, ParseResponse, _tableOperations.Diagnostics, _tableOperations.Pipeline, $"{nameof(TableServiceClient)}.Query", requestContext);
        }
    }
}
