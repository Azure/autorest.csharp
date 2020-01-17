// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace body_byte
{
    internal partial class ByteOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of ByteOperations. </summary>
        public ByteOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/byte/null", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null byte value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<byte[]>> GetNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ByteOperations.GetNull");
            scope.Start();
            try
            {
                using var message = CreateGetNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetBytesFromBase64();
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
        /// <summary> Get null byte value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ByteOperations.GetNull");
            scope.Start();
            try
            {
                using var message = CreateGetNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetBytesFromBase64();
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
        internal HttpMessage CreateGetEmptyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/byte/empty", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get empty byte value &apos;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<byte[]>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ByteOperations.GetEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetBytesFromBase64();
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
        /// <summary> Get empty byte value &apos;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetEmpty(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ByteOperations.GetEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetBytesFromBase64();
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
        internal HttpMessage CreateGetNonAsciiRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/byte/nonAscii", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<byte[]>> GetNonAsciiAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ByteOperations.GetNonAscii");
            scope.Start();
            try
            {
                using var message = CreateGetNonAsciiRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetBytesFromBase64();
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
        /// <summary> Get non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetNonAscii(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ByteOperations.GetNonAscii");
            scope.Start();
            try
            {
                using var message = CreateGetNonAsciiRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetBytesFromBase64();
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
        internal HttpMessage CreatePutNonAsciiRequest(byte[] byteBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/byte/nonAscii", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBase64StringValue(byteBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </summary>
        /// <param name="byteBody"> Base64-encoded non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutNonAsciiAsync(byte[] byteBody, CancellationToken cancellationToken = default)
        {
            if (byteBody == null)
            {
                throw new ArgumentNullException(nameof(byteBody));
            }

            using var scope = clientDiagnostics.CreateScope("ByteOperations.PutNonAscii");
            scope.Start();
            try
            {
                using var message = CreatePutNonAsciiRequest(byteBody);
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
        /// <summary> Put non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </summary>
        /// <param name="byteBody"> Base64-encoded non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNonAscii(byte[] byteBody, CancellationToken cancellationToken = default)
        {
            if (byteBody == null)
            {
                throw new ArgumentNullException(nameof(byteBody));
            }

            using var scope = clientDiagnostics.CreateScope("ByteOperations.PutNonAscii");
            scope.Start();
            try
            {
                using var message = CreatePutNonAsciiRequest(byteBody);
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
        internal HttpMessage CreateGetInvalidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/byte/invalid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get invalid byte value &apos;:::SWAGGER::::&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<byte[]>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ByteOperations.GetInvalid");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetBytesFromBase64();
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
        /// <summary> Get invalid byte value &apos;:::SWAGGER::::&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetInvalid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ByteOperations.GetInvalid");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetBytesFromBase64();
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
