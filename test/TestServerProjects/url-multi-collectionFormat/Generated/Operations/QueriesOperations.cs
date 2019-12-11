// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace url_multi_collectionFormat
{
    internal static class QueriesOperations
    {
        public static async ValueTask<Response> ArrayStringMultiNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<string> arrayQuery, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));

            using var scope = clientDiagnostics.CreateScope("url_multi_collectionFormat.ArrayStringMultiNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/queries/array/multi/string/null", false);
                if (arrayQuery != null)
                {
                    request.Uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
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
        public static async ValueTask<Response> ArrayStringMultiEmptyAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<string> arrayQuery, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));

            using var scope = clientDiagnostics.CreateScope("url_multi_collectionFormat.ArrayStringMultiEmpty");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/queries/array/multi/string/empty", false);
                if (arrayQuery != null)
                {
                    request.Uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
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
        public static async ValueTask<Response> ArrayStringMultiValidAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, IEnumerable<string> arrayQuery, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));

            using var scope = clientDiagnostics.CreateScope("url_multi_collectionFormat.ArrayStringMultiValid");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/queries/array/multi/string/valid", false);
                if (arrayQuery != null)
                {
                    request.Uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
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
