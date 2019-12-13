// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace custom_baseUrl
{
    internal static class PathsOperations
    {
        public static async ValueTask<Response> GetEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string accountName, string host = "host", CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("custom_baseUrl.GetEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"http://{accountName}{host}"));
                request.Uri.AppendPath("/customuri", false);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        return response;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
