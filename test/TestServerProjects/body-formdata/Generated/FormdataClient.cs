// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace body_formdata
{
    /// <summary> The Formdata service client. </summary>
    public partial class FormdataClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal FormdataRestClient RestClient { get; }

        /// <summary> Initializes a new instance of FormdataClient for mocking. </summary>
        protected FormdataClient()
        {
        }

        /// <summary> Initializes a new instance of FormdataClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal FormdataClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new FormdataRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Upload file. </summary>
        /// <param name="fileContent"> File to upload. </param>
        /// <param name="fileName"> File name to upload. Name has to be spelled exactly as written here. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Stream>> UploadFileAsync(Stream fileContent, string fileName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FormdataClient.UploadFile");
            scope.Start();
            try
            {
                return await RestClient.UploadFileAsync(fileContent, fileName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Upload file. </summary>
        /// <param name="fileContent"> File to upload. </param>
        /// <param name="fileName"> File name to upload. Name has to be spelled exactly as written here. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Stream> UploadFile(Stream fileContent, string fileName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FormdataClient.UploadFile");
            scope.Start();
            try
            {
                return RestClient.UploadFile(fileContent, fileName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Upload file. </summary>
        /// <param name="fileContent"> File to upload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Stream>> UploadFileViaBodyAsync(Stream fileContent, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FormdataClient.UploadFileViaBody");
            scope.Start();
            try
            {
                return await RestClient.UploadFileViaBodyAsync(fileContent, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Upload file. </summary>
        /// <param name="fileContent"> File to upload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Stream> UploadFileViaBody(Stream fileContent, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FormdataClient.UploadFileViaBody");
            scope.Start();
            try
            {
                return RestClient.UploadFileViaBody(fileContent, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Upload multiple files. </summary>
        /// <param name="fileContent"> Files to upload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Stream>> UploadFilesAsync(IEnumerable<Stream> fileContent, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FormdataClient.UploadFiles");
            scope.Start();
            try
            {
                return await RestClient.UploadFilesAsync(fileContent, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Upload multiple files. </summary>
        /// <param name="fileContent"> Files to upload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Stream> UploadFiles(IEnumerable<Stream> fileContent, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FormdataClient.UploadFiles");
            scope.Start();
            try
            {
                return RestClient.UploadFiles(fileContent, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
