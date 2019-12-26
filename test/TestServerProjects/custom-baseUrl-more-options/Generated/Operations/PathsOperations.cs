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
    internal partial class PathsOperations
    {
        private string subscriptionId;
        private string dnsSuffix;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        public PathsOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, string dnsSuffix = "host")
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (dnsSuffix == null)
            {
                throw new ArgumentNullException(nameof(dnsSuffix));
            }

            this.subscriptionId = subscriptionId;
            this.dnsSuffix = dnsSuffix;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        public async ValueTask<Response> GetEmptyAsync(string vault, string secret, string keyName, string? keyVersion, CancellationToken cancellationToken = default)
        {
            if (vault == null)
            {
                throw new ArgumentNullException(nameof(vault));
            }
            if (secret == null)
            {
                throw new ArgumentNullException(nameof(secret));
            }
            if (keyName == null)
            {
                throw new ArgumentNullException(nameof(keyName));
            }

            using var scope = clientDiagnostics.CreateScope("custom_baseUrl_more_options.GetEmpty");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{vault}{secret}{dnsSuffix}"));
                request.Uri.AppendPath("/customuri/", false);
                request.Uri.AppendPath(subscriptionId, true);
                request.Uri.AppendPath("/", false);
                request.Uri.AppendPath(keyName, true);
                if (keyVersion != null)
                {
                    request.Uri.AppendQuery("keyVersion", keyVersion, true);
                }
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
