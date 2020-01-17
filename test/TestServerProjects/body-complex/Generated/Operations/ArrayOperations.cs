// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    internal partial class ArrayOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of ArrayOperations. </summary>
        public ArrayOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
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
            uri.AppendPath("/complex/array/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types with array property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ArrayWrapper>> GetValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetValid");
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
                            var value = ArrayWrapper.DeserializeArrayWrapper(document.RootElement);
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
        /// <summary> Get complex types with array property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ArrayWrapper> GetValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetValid");
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
                            var value = ArrayWrapper.DeserializeArrayWrapper(document.RootElement);
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
        internal HttpMessage CreatePutValidRequest(ArrayWrapper complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/array/valid", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types with array property. </summary>
        /// <param name="complexBody"> Please put an array with 4 items: &quot;1, 2, 3, 4&quot;, &quot;&quot;, null, &quot;&amp;S#$(*Y&quot;, &quot;The quick brown fox jumps over the lazy dog&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutValidAsync(ArrayWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutValid");
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
        /// <summary> Put complex types with array property. </summary>
        /// <param name="complexBody"> Please put an array with 4 items: &quot;1, 2, 3, 4&quot;, &quot;&quot;, null, &quot;&amp;S#$(*Y&quot;, &quot;The quick brown fox jumps over the lazy dog&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutValid(ArrayWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutValid");
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
        internal HttpMessage CreateGetEmptyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/array/empty", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types with array property which is empty. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ArrayWrapper>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetEmpty");
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
                            var value = ArrayWrapper.DeserializeArrayWrapper(document.RootElement);
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
        /// <summary> Get complex types with array property which is empty. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ArrayWrapper> GetEmpty(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetEmpty");
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
                            var value = ArrayWrapper.DeserializeArrayWrapper(document.RootElement);
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
        internal HttpMessage CreatePutEmptyRequest(ArrayWrapper complexBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/array/empty", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put complex types with array property which is empty. </summary>
        /// <param name="complexBody"> Please put an array with 4 items: &quot;1, 2, 3, 4&quot;, &quot;&quot;, null, &quot;&amp;S#$(*Y&quot;, &quot;The quick brown fox jumps over the lazy dog&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyAsync(ArrayWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutEmpty");
            scope.Start();
            try
            {
                using var message = CreatePutEmptyRequest(complexBody);
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
        /// <summary> Put complex types with array property which is empty. </summary>
        /// <param name="complexBody"> Please put an array with 4 items: &quot;1, 2, 3, 4&quot;, &quot;&quot;, null, &quot;&amp;S#$(*Y&quot;, &quot;The quick brown fox jumps over the lazy dog&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmpty(ArrayWrapper complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutEmpty");
            scope.Start();
            try
            {
                using var message = CreatePutEmptyRequest(complexBody);
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
        internal HttpMessage CreateGetNotProvidedRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/complex/array/notprovided", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get complex types with array property while server doesn&apos;t provide a response payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ArrayWrapper>> GetNotProvidedAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetNotProvided");
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
                            var value = ArrayWrapper.DeserializeArrayWrapper(document.RootElement);
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
        /// <summary> Get complex types with array property while server doesn&apos;t provide a response payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ArrayWrapper> GetNotProvided(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetNotProvided");
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
                            var value = ArrayWrapper.DeserializeArrayWrapper(document.RootElement);
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
