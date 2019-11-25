// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace custom_baseUrl_more_options.Operations.V100
{
    public static class PathsOperations
    {
        public static async ValueTask<Response> GetEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string vault, string secret, string keyName, string subscriptionId, string dnsSuffix = "host", string? keyVersion = default, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("custom_baseUrl_more_options.Operations.V100.GetEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{vault}{secret}{dnsSuffix}/customuri/{subscriptionId}/{keyName}"));
                if (keyVersion != null)
                {
                    request.Uri.AppendQuery("keyVersion", keyVersion.ToString()!);
                }
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
