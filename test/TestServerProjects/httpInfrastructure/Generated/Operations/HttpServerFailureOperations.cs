// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace httpInfrastructure
{
    internal partial class HttpServerFailureOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of HttpServerFailureOperations. </summary>
        public HttpServerFailureOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateHead501Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/failure/server/501", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Head501Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HttpServerFailureOperations.Head501");
            scope.Start();
            try
            {
                using var message = CreateHead501Request();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
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
        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head501(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HttpServerFailureOperations.Head501");
            scope.Start();
            try
            {
                using var message = CreateHead501Request();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
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
        internal HttpMessage CreateGet501Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/failure/server/501", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get501Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HttpServerFailureOperations.Get501");
            scope.Start();
            try
            {
                using var message = CreateGet501Request();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
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
        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get501(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HttpServerFailureOperations.Get501");
            scope.Start();
            try
            {
                using var message = CreateGet501Request();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
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
        internal HttpMessage CreatePost505Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/failure/server/505", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }
        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Post505Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HttpServerFailureOperations.Post505");
            scope.Start();
            try
            {
                using var message = CreatePost505Request();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
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
        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post505(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HttpServerFailureOperations.Post505");
            scope.Start();
            try
            {
                using var message = CreatePost505Request();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
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
        internal HttpMessage CreateDelete505Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/failure/server/505", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }
        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete505Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HttpServerFailureOperations.Delete505");
            scope.Start();
            try
            {
                using var message = CreateDelete505Request();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
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
        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete505(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HttpServerFailureOperations.Delete505");
            scope.Start();
            try
            {
                using var message = CreateDelete505Request();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
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
