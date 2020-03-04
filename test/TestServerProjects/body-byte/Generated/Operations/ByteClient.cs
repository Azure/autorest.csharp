// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace body_byte
{
    public partial class ByteClient
    {
        internal ByteRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of ByteClient. </summary>
        internal ByteClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new ByteRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get null byte value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<byte[]>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null byte value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetNull(cancellationToken);
        }
        /// <summary> Get empty byte value &apos;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<byte[]>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get empty byte value &apos;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetEmpty(CancellationToken cancellationToken = default)
        {
            return RestClient.GetEmpty(cancellationToken);
        }
        /// <summary> Get non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<byte[]>> GetNonAsciiAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetNonAsciiAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetNonAscii(CancellationToken cancellationToken = default)
        {
            return RestClient.GetNonAscii(cancellationToken);
        }
        /// <summary> Put non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </summary>
        /// <param name="byteBody"> Base64-encoded non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutNonAsciiAsync(byte[] byteBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutNonAsciiAsync(byteBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </summary>
        /// <param name="byteBody"> Base64-encoded non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNonAscii(byte[] byteBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutNonAscii(byteBody, cancellationToken);
        }
        /// <summary> Get invalid byte value &apos;:::SWAGGER::::&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<byte[]>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetInvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get invalid byte value &apos;:::SWAGGER::::&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetInvalid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetInvalid(cancellationToken);
        }
    }
}
