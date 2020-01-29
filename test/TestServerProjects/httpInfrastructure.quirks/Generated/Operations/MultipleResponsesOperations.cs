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
using httpInfrastructure.quirks.Models;

namespace httpInfrastructure.quirks
{
    internal partial class MultipleResponsesOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of MultipleResponsesOperations. </summary>
        public MultipleResponsesOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGet200Model204NoModelDefaultError200ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/200/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model204NoModelDefaultError200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model204NoModelDefaultError200Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200Model204NoModelDefaultError200ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError200Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model204NoModelDefaultError200Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200Model204NoModelDefaultError200ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200Model204NoModelDefaultError204ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/204/none", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model204NoModelDefaultError204ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model204NoModelDefaultError204Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200Model204NoModelDefaultError204ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError204Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model204NoModelDefaultError204Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200Model204NoModelDefaultError204ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200Model204NoModelDefaultError201InvalidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/201/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 201 response with valid payload: {&apos;statusCode&apos;: &apos;201&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model204NoModelDefaultError201InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model204NoModelDefaultError201Invalid");
            scope.Start();
            try
            {
                using var message = CreateGet200Model204NoModelDefaultError201InvalidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 201 response with valid payload: {&apos;statusCode&apos;: &apos;201&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError201Invalid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model204NoModelDefaultError201Invalid");
            scope.Start();
            try
            {
                using var message = CreateGet200Model204NoModelDefaultError201InvalidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200Model204NoModelDefaultError202NoneRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/202/none", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 202 response with no payload:. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model204NoModelDefaultError202NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model204NoModelDefaultError202None");
            scope.Start();
            try
            {
                using var message = CreateGet200Model204NoModelDefaultError202NoneRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 202 response with no payload:. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError202None(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model204NoModelDefaultError202None");
            scope.Start();
            try
            {
                using var message = CreateGet200Model204NoModelDefaultError202NoneRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200Model204NoModelDefaultError400ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/400/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 400 response with valid error payload: {&apos;status&apos;: 400, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model204NoModelDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model204NoModelDefaultError400Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200Model204NoModelDefaultError400ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 400 response with valid error payload: {&apos;status&apos;: 400, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model204NoModelDefaultError400Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200Model204NoModelDefaultError400ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200Model201ModelDefaultError200ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/201/B/default/Error/response/200/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model201ModelDefaultError200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model201ModelDefaultError200Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200Model201ModelDefaultError200ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model201ModelDefaultError200Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model201ModelDefaultError200Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200Model201ModelDefaultError200ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200Model201ModelDefaultError201ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/201/B/default/Error/response/201/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 201 response with valid payload: {&apos;statusCode&apos;: &apos;201&apos;, &apos;textStatusCode&apos;: &apos;Created&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model201ModelDefaultError201ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model201ModelDefaultError201Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200Model201ModelDefaultError201ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 201 response with valid payload: {&apos;statusCode&apos;: &apos;201&apos;, &apos;textStatusCode&apos;: &apos;Created&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model201ModelDefaultError201Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model201ModelDefaultError201Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200Model201ModelDefaultError201ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200Model201ModelDefaultError400ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/201/B/default/Error/response/400/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 400 response with valid payload: {&apos;code&apos;: &apos;400&apos;, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model201ModelDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model201ModelDefaultError400Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200Model201ModelDefaultError400ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 400 response with valid payload: {&apos;code&apos;: &apos;400&apos;, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model201ModelDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200Model201ModelDefaultError400Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200Model201ModelDefaultError400ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200ModelA201ModelC404ModelDDefaultError200ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/201/C/404/D/default/Error/response/200/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA201ModelC404ModelDDefaultError200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA201ModelC404ModelDDefaultError200Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA201ModelC404ModelDDefaultError200ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA201ModelC404ModelDDefaultError200Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA201ModelC404ModelDDefaultError200Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA201ModelC404ModelDDefaultError200ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200ModelA201ModelC404ModelDDefaultError201ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/201/C/404/D/default/Error/response/201/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 200 response with valid payload: {&apos;httpCode&apos;: &apos;201&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA201ModelC404ModelDDefaultError201ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA201ModelC404ModelDDefaultError201Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA201ModelC404ModelDDefaultError201ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 200 response with valid payload: {&apos;httpCode&apos;: &apos;201&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA201ModelC404ModelDDefaultError201Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA201ModelC404ModelDDefaultError201Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA201ModelC404ModelDDefaultError201ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200ModelA201ModelC404ModelDDefaultError404ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/201/C/404/D/default/Error/response/404/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 200 response with valid payload: {&apos;httpStatusCode&apos;: &apos;404&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA201ModelC404ModelDDefaultError404ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA201ModelC404ModelDDefaultError404Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA201ModelC404ModelDDefaultError404ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 200 response with valid payload: {&apos;httpStatusCode&apos;: &apos;404&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA201ModelC404ModelDDefaultError404Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA201ModelC404ModelDDefaultError404Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA201ModelC404ModelDDefaultError404ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200ModelA201ModelC404ModelDDefaultError400ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/201/C/404/D/default/Error/response/400/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 400 response with valid payload: {&apos;code&apos;: &apos;400&apos;, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA201ModelC404ModelDDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA201ModelC404ModelDDefaultError400Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA201ModelC404ModelDDefaultError400ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 400 response with valid payload: {&apos;code&apos;: &apos;400&apos;, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA201ModelC404ModelDDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA201ModelC404ModelDDefaultError400Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA201ModelC404ModelDDefaultError400ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet202None204NoneDefaultError202NoneRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/202/none/204/none/default/Error/response/202/none", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 202 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get202None204NoneDefaultError202NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get202None204NoneDefaultError202None");
            scope.Start();
            try
            {
                using var message = CreateGet202None204NoneDefaultError202NoneRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Send a 202 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultError202None(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get202None204NoneDefaultError202None");
            scope.Start();
            try
            {
                using var message = CreateGet202None204NoneDefaultError202NoneRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreateGet202None204NoneDefaultError204NoneRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/202/none/204/none/default/Error/response/204/none", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get202None204NoneDefaultError204NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get202None204NoneDefaultError204None");
            scope.Start();
            try
            {
                using var message = CreateGet202None204NoneDefaultError204NoneRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultError204None(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get202None204NoneDefaultError204None");
            scope.Start();
            try
            {
                using var message = CreateGet202None204NoneDefaultError204NoneRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreateGet202None204NoneDefaultError400ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/202/none/204/none/default/Error/response/400/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 400 response with valid payload: {&apos;code&apos;: &apos;400&apos;, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get202None204NoneDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get202None204NoneDefaultError400Valid");
            scope.Start();
            try
            {
                using var message = CreateGet202None204NoneDefaultError400ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Send a 400 response with valid payload: {&apos;code&apos;: &apos;400&apos;, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get202None204NoneDefaultError400Valid");
            scope.Start();
            try
            {
                using var message = CreateGet202None204NoneDefaultError400ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreateGet202None204NoneDefaultNone202InvalidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/202/none/204/none/default/none/response/202/invalid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 202 response with an unexpected payload {&apos;property&apos;: &apos;value&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get202None204NoneDefaultNone202InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get202None204NoneDefaultNone202Invalid");
            scope.Start();
            try
            {
                using var message = CreateGet202None204NoneDefaultNone202InvalidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Send a 202 response with an unexpected payload {&apos;property&apos;: &apos;value&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultNone202Invalid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get202None204NoneDefaultNone202Invalid");
            scope.Start();
            try
            {
                using var message = CreateGet202None204NoneDefaultNone202InvalidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreateGet202None204NoneDefaultNone204NoneRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/202/none/204/none/default/none/response/204/none", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get202None204NoneDefaultNone204NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get202None204NoneDefaultNone204None");
            scope.Start();
            try
            {
                using var message = CreateGet202None204NoneDefaultNone204NoneRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultNone204None(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get202None204NoneDefaultNone204None");
            scope.Start();
            try
            {
                using var message = CreateGet202None204NoneDefaultNone204NoneRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreateGet202None204NoneDefaultNone400NoneRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/202/none/204/none/default/none/response/400/none", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get202None204NoneDefaultNone400NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get202None204NoneDefaultNone400None");
            scope.Start();
            try
            {
                using var message = CreateGet202None204NoneDefaultNone400NoneRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultNone400None(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get202None204NoneDefaultNone400None");
            scope.Start();
            try
            {
                using var message = CreateGet202None204NoneDefaultNone400NoneRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreateGet202None204NoneDefaultNone400InvalidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/202/none/204/none/default/none/response/400/invalid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 400 response with an unexpected payload {&apos;property&apos;: &apos;value&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get202None204NoneDefaultNone400InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get202None204NoneDefaultNone400Invalid");
            scope.Start();
            try
            {
                using var message = CreateGet202None204NoneDefaultNone400InvalidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Send a 400 response with an unexpected payload {&apos;property&apos;: &apos;value&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultNone400Invalid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get202None204NoneDefaultNone400Invalid");
            scope.Start();
            try
            {
                using var message = CreateGet202None204NoneDefaultNone400InvalidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreateGetDefaultModelA200ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/default/A/response/200/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetDefaultModelA200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultModelA200Valid");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultModelA200ValidRequest();
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
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultModelA200Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultModelA200Valid");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultModelA200ValidRequest();
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
        internal HttpMessage CreateGetDefaultModelA200NoneRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/default/A/response/200/none", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetDefaultModelA200NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultModelA200None");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultModelA200NoneRequest();
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
        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultModelA200None(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultModelA200None");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultModelA200NoneRequest();
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
        internal HttpMessage CreateGetDefaultModelA400ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/default/A/response/400/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 400 response with valid payload: {&apos;statusCode&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetDefaultModelA400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultModelA400Valid");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultModelA400ValidRequest();
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
        /// <summary> Send a 400 response with valid payload: {&apos;statusCode&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultModelA400Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultModelA400Valid");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultModelA400ValidRequest();
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
        internal HttpMessage CreateGetDefaultModelA400NoneRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/default/A/response/400/none", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetDefaultModelA400NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultModelA400None");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultModelA400NoneRequest();
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
        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultModelA400None(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultModelA400None");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultModelA400NoneRequest();
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
        internal HttpMessage CreateGetDefaultNone200InvalidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/default/none/response/200/invalid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 200 response with invalid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetDefaultNone200InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultNone200Invalid");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultNone200InvalidRequest();
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
        /// <summary> Send a 200 response with invalid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultNone200Invalid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultNone200Invalid");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultNone200InvalidRequest();
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
        internal HttpMessage CreateGetDefaultNone200NoneRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/default/none/response/200/none", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetDefaultNone200NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultNone200None");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultNone200NoneRequest();
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
        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultNone200None(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultNone200None");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultNone200NoneRequest();
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
        internal HttpMessage CreateGetDefaultNone400InvalidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/default/none/response/400/invalid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 400 response with valid payload: {&apos;statusCode&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetDefaultNone400InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultNone400Invalid");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultNone400InvalidRequest();
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
        /// <summary> Send a 400 response with valid payload: {&apos;statusCode&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultNone400Invalid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultNone400Invalid");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultNone400InvalidRequest();
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
        internal HttpMessage CreateGetDefaultNone400NoneRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/default/none/response/400/none", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetDefaultNone400NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultNone400None");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultNone400NoneRequest();
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
        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultNone400None(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.GetDefaultNone400None");
            scope.Start();
            try
            {
                using var message = CreateGetDefaultNone400NoneRequest();
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
        internal HttpMessage CreateGet200ModelA200NoneRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/response/200/none", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 200 response with no payload, when a payload is expected - client should return a null object of thde type for model A. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA200NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA200None");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA200NoneRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 200 response with no payload, when a payload is expected - client should return a null object of thde type for model A. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA200None(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA200None");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA200NoneRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200ModelA200ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/response/200/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 200 response with payload {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA200Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA200ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 200 response with payload {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA200Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA200Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA200ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200ModelA200InvalidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/response/200/invalid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 200 response with invalid payload {&apos;statusCodeInvalid&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA200InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA200Invalid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA200InvalidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 200 response with invalid payload {&apos;statusCodeInvalid&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA200Invalid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA200Invalid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA200InvalidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200ModelA400NoneRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/response/400/none", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 400 response with no payload client should treat as an http error with no error model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA400NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA400None");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA400NoneRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 400 response with no payload client should treat as an http error with no error model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA400None(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA400None");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA400NoneRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200ModelA400ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/response/400/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 200 response with payload {&apos;statusCode&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA400Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA400ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 200 response with payload {&apos;statusCode&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA400Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA400Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA400ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200ModelA400InvalidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/response/400/invalid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 200 response with invalid payload {&apos;statusCodeInvalid&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA400InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA400Invalid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA400InvalidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 200 response with invalid payload {&apos;statusCodeInvalid&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA400Invalid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA400Invalid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA400InvalidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        internal HttpMessage CreateGet200ModelA202ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/http/payloads/200/A/response/202/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send a 202 response with payload {&apos;statusCode&apos;: &apos;202&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA202ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA202Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA202ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
        /// <summary> Send a 202 response with payload {&apos;statusCode&apos;: &apos;202&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA202Valid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("MultipleResponsesOperations.Get200ModelA202Valid");
            scope.Start();
            try
            {
                using var message = CreateGet200ModelA202ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = MyException.DeserializeMyException(document.RootElement);
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
