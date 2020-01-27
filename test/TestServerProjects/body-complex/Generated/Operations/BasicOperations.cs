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
using body_complex.Models;

namespace body_complex
{
    internal partial class BasicOperations
    {
        private string host;
        private string ApiVersion;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of BasicOperations. </summary>
        public BasicOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", string ApiVersion = "2016-02-29")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (ApiVersion == null)
            {
                throw new ArgumentNullException(nameof(ApiVersion));
            }

            this.host = host;
            this.ApiVersion = ApiVersion;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/basic/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex type {id: 2, name: &apos;abc&apos;, color: &apos;YELLOW&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Basic>> GetValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BasicOperations.GetValid");
            scope.Start();
            try
            {
                using var message = CreateGetValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Basic.DeserializeBasic(document.RootElement);
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
        /// <summary> Get complex type {id: 2, name: &apos;abc&apos;, color: &apos;YELLOW&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Basic> GetValid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BasicOperations.GetValid");
            scope.Start();
            try
            {
                using var message = CreateGetValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Basic.DeserializeBasic(document.RootElement);
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
        internal HttpMessage CreatePutValidRequest(Basic complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/basic/valid", false);
            uri.AppendQuery("api-version", ApiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Please put {id: 2, name: &apos;abc&apos;, color: &apos;Magenta&apos;}. </summary>
        /// <param name="complexBody"> Please put {id: 2, name: &apos;abc&apos;, color: &apos;Magenta&apos;}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutValidAsync(Basic complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("BasicOperations.PutValid");
            scope.Start();
            try
            {
                using var message = CreatePutValidRequest(complexBody);
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
        /// <summary> Please put {id: 2, name: &apos;abc&apos;, color: &apos;Magenta&apos;}. </summary>
        /// <param name="complexBody"> Please put {id: 2, name: &apos;abc&apos;, color: &apos;Magenta&apos;}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutValid(Basic complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("BasicOperations.PutValid");
            scope.Start();
            try
            {
                using var message = CreatePutValidRequest(complexBody);
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
            uri.AppendPath("/complex/basic/invalid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get a basic complex type that is invalid for the local strong type. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Basic>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BasicOperations.GetInvalid");
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
                            var value = Basic.DeserializeBasic(document.RootElement);
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
        /// <summary> Get a basic complex type that is invalid for the local strong type. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Basic> GetInvalid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BasicOperations.GetInvalid");
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
                            var value = Basic.DeserializeBasic(document.RootElement);
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
            uri.AppendPath("/complex/basic/empty", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get a basic complex type that is empty. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Basic>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BasicOperations.GetEmpty");
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
                            var value = Basic.DeserializeBasic(document.RootElement);
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
        /// <summary> Get a basic complex type that is empty. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Basic> GetEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BasicOperations.GetEmpty");
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
                            var value = Basic.DeserializeBasic(document.RootElement);
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
        internal HttpMessage CreateGetNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/basic/null", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get a basic complex type whose properties are null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Basic>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BasicOperations.GetNull");
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
                            var value = Basic.DeserializeBasic(document.RootElement);
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
        /// <summary> Get a basic complex type whose properties are null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Basic> GetNull(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BasicOperations.GetNull");
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
                            var value = Basic.DeserializeBasic(document.RootElement);
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
        internal HttpMessage CreateGetNotProvidedRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/basic/notprovided", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get a basic complex type while the server doesn&apos;t provide a response payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Basic>> GetNotProvidedAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BasicOperations.GetNotProvided");
            scope.Start();
            try
            {
                using var message = CreateGetNotProvidedRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Basic.DeserializeBasic(document.RootElement);
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
        /// <summary> Get a basic complex type while the server doesn&apos;t provide a response payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Basic> GetNotProvided(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("BasicOperations.GetNotProvided");
            scope.Start();
            try
            {
                using var message = CreateGetNotProvidedRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Basic.DeserializeBasic(document.RootElement);
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
