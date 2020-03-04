// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace url_multi_collectionFormat
{
    public partial class QueriesClient
    {
        private QueriesRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of QueriesClient. </summary>
        internal QueriesClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new QueriesRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get a null array of string using the multi-array format. </summary>
        /// <param name="arrayQuery"> a null array of string using the multi-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringMultiNullAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return await restClient.ArrayStringMultiNullAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a null array of string using the multi-array format. </summary>
        /// <param name="arrayQuery"> a null array of string using the multi-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringMultiNull(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return restClient.ArrayStringMultiNull(arrayQuery, cancellationToken);
        }
        /// <summary> Get an empty array [] of string using the multi-array format. </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the multi-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringMultiEmptyAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return await restClient.ArrayStringMultiEmptyAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an empty array [] of string using the multi-array format. </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the multi-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringMultiEmpty(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return restClient.ArrayStringMultiEmpty(arrayQuery, cancellationToken);
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the mult-array format. </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the multi-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ArrayStringMultiValidAsync(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return await restClient.ArrayStringMultiValidAsync(arrayQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the mult-array format. </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the multi-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringMultiValid(IEnumerable<string> arrayQuery, CancellationToken cancellationToken = default)
        {
            return restClient.ArrayStringMultiValid(arrayQuery, cancellationToken);
        }
    }
}
