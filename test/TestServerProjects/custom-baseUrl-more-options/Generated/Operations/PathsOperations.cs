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
        internal HttpMessage CreateGetEmptyRequest(string vault, string secret, string keyName, string? keyVersion)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{vault}{secret}{dnsSuffix}"));
            request.Uri.AppendPath("/customuri/", false);
            request.Uri.AppendPath(subscriptionId, true);
            request.Uri.AppendPath("/", false);
            request.Uri.AppendPath(keyName, true);
            if (keyVersion != null)
            {
                request.Uri.AppendQuery("keyVersion", keyVersion, true);
            }
            return message;
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

            using var scope = clientDiagnostics.CreateScope("PathsOperations.GetEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyRequest(vault, secret, keyName, keyVersion);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public Response GetEmpty(string vault, string secret, string keyName, string? keyVersion, CancellationToken cancellationToken = default)
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

            using var scope = clientDiagnostics.CreateScope("PathsOperations.GetEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyRequest(vault, secret, keyName, keyVersion);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
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
