// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace body_file
{
    internal partial class FilesOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of FilesOperations. </summary>
        public FilesOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetFileRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/files/stream/nonempty", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get file. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Stream>> GetFileAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("FilesOperations.GetFile");
            scope.Start();
            try
            {
                using var message = CreateGetFileRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var value = message.ExtractResponseContent();
                            return Response.FromValue(value, message.Response);
                        }
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
        /// <summary> Get file. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Stream> GetFile(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("FilesOperations.GetFile");
            scope.Start();
            try
            {
                using var message = CreateGetFileRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var value = message.ExtractResponseContent();
                            return Response.FromValue(value, message.Response);
                        }
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
        internal HttpMessage CreateGetFileLargeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/files/stream/verylarge", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get a large file. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Stream>> GetFileLargeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("FilesOperations.GetFileLarge");
            scope.Start();
            try
            {
                using var message = CreateGetFileLargeRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var value = message.ExtractResponseContent();
                            return Response.FromValue(value, message.Response);
                        }
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
        /// <summary> Get a large file. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Stream> GetFileLarge(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("FilesOperations.GetFileLarge");
            scope.Start();
            try
            {
                using var message = CreateGetFileLargeRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var value = message.ExtractResponseContent();
                            return Response.FromValue(value, message.Response);
                        }
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
        internal HttpMessage CreateGetEmptyFileRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/files/stream/empty", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get empty file. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Stream>> GetEmptyFileAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("FilesOperations.GetEmptyFile");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyFileRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var value = message.ExtractResponseContent();
                            return Response.FromValue(value, message.Response);
                        }
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
        /// <summary> Get empty file. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Stream> GetEmptyFile(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("FilesOperations.GetEmptyFile");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyFileRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var value = message.ExtractResponseContent();
                            return Response.FromValue(value, message.Response);
                        }
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
