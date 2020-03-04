// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace body_file
{
    public partial class FilesClient
    {
        internal FilesRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of FilesClient. </summary>
        internal FilesClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new FilesRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get file. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Stream>> GetFileAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetFileAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get file. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Stream> GetFile(CancellationToken cancellationToken = default)
        {
            return RestClient.GetFile(cancellationToken);
        }
        /// <summary> Get a large file. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Stream>> GetFileLargeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetFileLargeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a large file. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Stream> GetFileLarge(CancellationToken cancellationToken = default)
        {
            return RestClient.GetFileLarge(cancellationToken);
        }
        /// <summary> Get empty file. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Stream>> GetEmptyFileAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetEmptyFileAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get empty file. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Stream> GetEmptyFile(CancellationToken cancellationToken = default)
        {
            return RestClient.GetEmptyFile(cancellationToken);
        }
    }
}
