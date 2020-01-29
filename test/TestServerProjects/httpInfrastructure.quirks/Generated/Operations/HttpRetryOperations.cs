// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace httpInfrastructure.quirks
{
    internal partial class HttpRetryOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of HttpRetryOperations. </summary>
        public HttpRetryOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateHead408Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Head;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/retry/408", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Return 408 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Head408Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Head408");
            scope.Start();
            try
            {
                using var message = CreateHead408Request();
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
        /// <summary> Return 408 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head408(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Head408");
            scope.Start();
            try
            {
                using var message = CreateHead408Request();
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
        internal HttpMessage CreatePut500Request(bool? booleanValue)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/retry/500", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(booleanValue.Value);
            request.Content = content;
            return message;
        }
        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="booleanValue"> Simple boolean value true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Put500Async(bool? booleanValue, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Put500");
            scope.Start();
            try
            {
                using var message = CreatePut500Request(booleanValue);
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
        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="booleanValue"> Simple boolean value true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put500(bool? booleanValue, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Put500");
            scope.Start();
            try
            {
                using var message = CreatePut500Request(booleanValue);
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
        internal HttpMessage CreatePatch500Request(bool? booleanValue)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/retry/500", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(booleanValue.Value);
            request.Content = content;
            return message;
        }
        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="booleanValue"> Simple boolean value true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Patch500Async(bool? booleanValue, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Patch500");
            scope.Start();
            try
            {
                using var message = CreatePatch500Request(booleanValue);
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
        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="booleanValue"> Simple boolean value true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch500(bool? booleanValue, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Patch500");
            scope.Start();
            try
            {
                using var message = CreatePatch500Request(booleanValue);
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
        internal HttpMessage CreateGet502Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/retry/502", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get502Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Get502");
            scope.Start();
            try
            {
                using var message = CreateGet502Request();
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
        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get502(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Get502");
            scope.Start();
            try
            {
                using var message = CreateGet502Request();
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
        internal HttpMessage CreateOptions502Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Options;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/retry/502", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<bool>> Options502Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Options502");
            scope.Start();
            try
            {
                using var message = CreateOptions502Request();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetBoolean();
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
        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> Options502(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Options502");
            scope.Start();
            try
            {
                using var message = CreateOptions502Request();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetBoolean();
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
        internal HttpMessage CreatePost503Request(bool? booleanValue)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/retry/503", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(booleanValue.Value);
            request.Content = content;
            return message;
        }
        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="booleanValue"> Simple boolean value true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Post503Async(bool? booleanValue, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Post503");
            scope.Start();
            try
            {
                using var message = CreatePost503Request(booleanValue);
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
        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="booleanValue"> Simple boolean value true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post503(bool? booleanValue, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Post503");
            scope.Start();
            try
            {
                using var message = CreatePost503Request(booleanValue);
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
        internal HttpMessage CreateDelete503Request(bool? booleanValue)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/retry/503", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(booleanValue.Value);
            request.Content = content;
            return message;
        }
        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="booleanValue"> Simple boolean value true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete503Async(bool? booleanValue, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Delete503");
            scope.Start();
            try
            {
                using var message = CreateDelete503Request(booleanValue);
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
        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="booleanValue"> Simple boolean value true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete503(bool? booleanValue, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Delete503");
            scope.Start();
            try
            {
                using var message = CreateDelete503Request(booleanValue);
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
        internal HttpMessage CreatePut504Request(bool? booleanValue)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/retry/504", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(booleanValue.Value);
            request.Content = content;
            return message;
        }
        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="booleanValue"> Simple boolean value true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Put504Async(bool? booleanValue, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Put504");
            scope.Start();
            try
            {
                using var message = CreatePut504Request(booleanValue);
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
        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="booleanValue"> Simple boolean value true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put504(bool? booleanValue, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Put504");
            scope.Start();
            try
            {
                using var message = CreatePut504Request(booleanValue);
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
        internal HttpMessage CreatePatch504Request(bool? booleanValue)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/retry/504", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(booleanValue.Value);
            request.Content = content;
            return message;
        }
        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="booleanValue"> Simple boolean value true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Patch504Async(bool? booleanValue, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Patch504");
            scope.Start();
            try
            {
                using var message = CreatePatch504Request(booleanValue);
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
        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="booleanValue"> Simple boolean value true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch504(bool? booleanValue, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HttpRetryOperations.Patch504");
            scope.Start();
            try
            {
                using var message = CreatePatch504Request(booleanValue);
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
