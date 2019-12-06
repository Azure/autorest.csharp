// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace custom_baseUrl_more_options
{
    public static class PathsOperations
    {
        public static async ValueTask<Response> GetEmptyAsync(HttpPipeline pipeline, string vault, string secret, string keyName, string subscriptionId, string? keyVersion, string dnsSuffix = "host", CancellationToken cancellationToken = default)
        {
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{vault}{secret}{dnsSuffix}"));
                request.Uri.AppendPath("/customuri/", false);
                request.Uri.AppendPath(subscriptionId.ToString()!, true);
                request.Uri.AppendPath("/", false);
                request.Uri.AppendPath(keyName.ToString()!, true);
                if (keyVersion != null)
                {
                    request.Uri.AppendQuery("keyVersion", keyVersion.ToString()!, true);
                }
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
