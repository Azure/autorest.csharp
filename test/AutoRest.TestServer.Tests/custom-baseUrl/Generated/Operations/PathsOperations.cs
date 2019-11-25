// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace custom_baseUrl.Operations.V100
{
    public static class PathsOperations
    {
        public static async ValueTask<Response> GetEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string accountName, string host = "host", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("custom_baseUrl.Operations.V100.GetEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"http://{accountName}{host}/customuri"));
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
