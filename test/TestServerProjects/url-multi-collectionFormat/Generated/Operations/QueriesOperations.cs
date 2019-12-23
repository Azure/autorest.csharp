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
    internal partial class QueriesOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        public QueriesOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        public async ValueTask<Response> ArrayStringMultiNullAsync(ICollection<string>? arrayQuery, CancellationToken cancellationToken = default)
        {

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
        public async ValueTask<Response> ArrayStringMultiEmptyAsync(ICollection<string>? arrayQuery, CancellationToken cancellationToken = default)
        {

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
        public async ValueTask<Response> ArrayStringMultiValidAsync(ICollection<string>? arrayQuery, CancellationToken cancellationToken = default)
        {

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
