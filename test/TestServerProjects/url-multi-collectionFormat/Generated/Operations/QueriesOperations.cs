// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
        /// <summary> Initializes a new instance of QueriesOperations. </summary>
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
        internal HttpMessage CreateArrayStringMultiNullRequest(IEnumerable<string> arrayQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/array/multi/string/null", false);
            if (arrayQuery != null)
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get a null array of string using the multi-array format. </summary>
        /// <param name="arrayQuery"> a null array of string using the multi-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringMultiNullAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringMultiNull");
            scope.Start();
            try
            {
                using var message = CreateArrayStringMultiNullRequest(arrayQuery);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get a null array of string using the multi-array format. </summary>
        /// <param name="arrayQuery"> a null array of string using the multi-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringMultiNull(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringMultiNull");
            scope.Start();
            try
            {
                using var message = CreateArrayStringMultiNullRequest(arrayQuery);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateArrayStringMultiEmptyRequest(IEnumerable<string> arrayQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/array/multi/string/empty", false);
            if (arrayQuery != null)
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an empty array [] of string using the multi-array format. </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the multi-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringMultiEmptyAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringMultiEmpty");
            scope.Start();
            try
            {
                using var message = CreateArrayStringMultiEmptyRequest(arrayQuery);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get an empty array [] of string using the multi-array format. </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the multi-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringMultiEmpty(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringMultiEmpty");
            scope.Start();
            try
            {
                using var message = CreateArrayStringMultiEmptyRequest(arrayQuery);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateArrayStringMultiValidRequest(IEnumerable<string> arrayQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/queries/array/multi/string/valid", false);
            if (arrayQuery != null)
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the mult-array format. </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the multi-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringMultiValidAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringMultiValid");
            scope.Start();
            try
            {
                using var message = CreateArrayStringMultiValidRequest(arrayQuery);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the mult-array format. </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the multi-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringMultiValid(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("QueriesOperations.ArrayStringMultiValid");
            scope.Start();
            try
            {
                using var message = CreateArrayStringMultiValidRequest(arrayQuery);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
