// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using lro.Models;

namespace lro
{
    internal partial class LrosaDsRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of LrosaDsRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public LrosaDsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreatePutNonRetry400Request(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/nonretryerror/put/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running put request, service returns a 400 to the initial request. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutNonRetry400Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNonRetry400Request(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 400 to the initial request. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNonRetry400(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNonRetry400Request(product);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutNonRetry201Creating400Request(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/nonretryerror/put/201/creating/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running put request, service returns a Product with 'ProvisioningState' = 'Creating' and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutNonRetry201Creating400Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNonRetry201Creating400Request(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a Product with 'ProvisioningState' = 'Creating' and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNonRetry201Creating400(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNonRetry201Creating400Request(product);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutNonRetry201Creating400InvalidJsonRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/nonretryerror/put/201/creating/400/invalidjson", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running put request, service returns a Product with 'ProvisioningState' = 'Creating' and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutNonRetry201Creating400InvalidJsonAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNonRetry201Creating400InvalidJsonRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a Product with 'ProvisioningState' = 'Creating' and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNonRetry201Creating400InvalidJson(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNonRetry201Creating400InvalidJsonRequest(product);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutAsyncRelativeRetry400Request(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/nonretryerror/putasync/retry/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running put request, service returns a 200 with ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsPutAsyncRelativeRetry400Headers>> PutAsyncRelativeRetry400Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncRelativeRetry400Request(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsPutAsyncRelativeRetry400Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 200 with ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsPutAsyncRelativeRetry400Headers> PutAsyncRelativeRetry400(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncRelativeRetry400Request(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsPutAsyncRelativeRetry400Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteNonRetry400Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/nonretryerror/delete/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 400 with an error body. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsDeleteNonRetry400Headers>> DeleteNonRetry400Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteNonRetry400Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsDeleteNonRetry400Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns a 400 with an error body. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsDeleteNonRetry400Headers> DeleteNonRetry400(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteNonRetry400Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsDeleteNonRetry400Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDelete202NonRetry400Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/nonretryerror/delete/202/retry/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 with a location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsDelete202NonRetry400Headers>> Delete202NonRetry400Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete202NonRetry400Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsDelete202NonRetry400Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns a 202 with a location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsDelete202NonRetry400Headers> Delete202NonRetry400(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete202NonRetry400Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsDelete202NonRetry400Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteAsyncRelativeRetry400Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/nonretryerror/deleteasync/retry/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsDeleteAsyncRelativeRetry400Headers>> DeleteAsyncRelativeRetry400Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncRelativeRetry400Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsDeleteAsyncRelativeRetry400Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsDeleteAsyncRelativeRetry400Headers> DeleteAsyncRelativeRetry400(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncRelativeRetry400Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsDeleteAsyncRelativeRetry400Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostNonRetry400Request(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/nonretryerror/post/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running post request, service returns a 400 with no error body. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsPostNonRetry400Headers>> PostNonRetry400Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostNonRetry400Request(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsPostNonRetry400Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 400 with no error body. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsPostNonRetry400Headers> PostNonRetry400(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostNonRetry400Request(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsPostNonRetry400Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost202NonRetry400Request(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/nonretryerror/post/202/retry/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running post request, service returns a 202 with a location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsPost202NonRetry400Headers>> Post202NonRetry400Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePost202NonRetry400Request(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsPost202NonRetry400Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 with a location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsPost202NonRetry400Headers> Post202NonRetry400(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePost202NonRetry400Request(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsPost202NonRetry400Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostAsyncRelativeRetry400Request(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/nonretryerror/postasync/retry/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running post request, service returns a 202 to the initial request Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsPostAsyncRelativeRetry400Headers>> PostAsyncRelativeRetry400Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncRelativeRetry400Request(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsPostAsyncRelativeRetry400Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsPostAsyncRelativeRetry400Headers> PostAsyncRelativeRetry400(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncRelativeRetry400Request(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsPostAsyncRelativeRetry400Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutError201NoProvisioningStatePayloadRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/put/201/noprovisioningstatepayload", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running put request, service returns a 201 to the initial request with no payload. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutError201NoProvisioningStatePayloadAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutError201NoProvisioningStatePayloadRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request with no payload. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutError201NoProvisioningStatePayload(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutError201NoProvisioningStatePayloadRequest(product);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutAsyncRelativeRetryNoStatusRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/putasync/retry/nostatus", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsPutAsyncRelativeRetryNoStatusHeaders>> PutAsyncRelativeRetryNoStatusAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncRelativeRetryNoStatusRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsPutAsyncRelativeRetryNoStatusHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsPutAsyncRelativeRetryNoStatusHeaders> PutAsyncRelativeRetryNoStatus(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncRelativeRetryNoStatusRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsPutAsyncRelativeRetryNoStatusHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutAsyncRelativeRetryNoStatusPayloadRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/putasync/retry/nostatuspayload", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsPutAsyncRelativeRetryNoStatusPayloadHeaders>> PutAsyncRelativeRetryNoStatusPayloadAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncRelativeRetryNoStatusPayloadRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsPutAsyncRelativeRetryNoStatusPayloadHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsPutAsyncRelativeRetryNoStatusPayloadHeaders> PutAsyncRelativeRetryNoStatusPayload(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncRelativeRetryNoStatusPayloadRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsPutAsyncRelativeRetryNoStatusPayloadHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDelete204SucceededRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/delete/204/nolocation", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 204 to the initial request, indicating success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Delete204SucceededAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete204SucceededRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns a 204 to the initial request, indicating success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete204Succeeded(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete204SucceededRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteAsyncRelativeRetryNoStatusRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/deleteasync/retry/nostatus", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsDeleteAsyncRelativeRetryNoStatusHeaders>> DeleteAsyncRelativeRetryNoStatusAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncRelativeRetryNoStatusRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsDeleteAsyncRelativeRetryNoStatusHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsDeleteAsyncRelativeRetryNoStatusHeaders> DeleteAsyncRelativeRetryNoStatus(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncRelativeRetryNoStatusRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsDeleteAsyncRelativeRetryNoStatusHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost202NoLocationRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/post/202/nolocation", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, without a location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsPost202NoLocationHeaders>> Post202NoLocationAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePost202NoLocationRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsPost202NoLocationHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, without a location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsPost202NoLocationHeaders> Post202NoLocation(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePost202NoLocationRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsPost202NoLocationHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostAsyncRelativeRetryNoPayloadRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/postasync/retry/nopayload", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsPostAsyncRelativeRetryNoPayloadHeaders>> PostAsyncRelativeRetryNoPayloadAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncRelativeRetryNoPayloadRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsPostAsyncRelativeRetryNoPayloadHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsPostAsyncRelativeRetryNoPayloadHeaders> PostAsyncRelativeRetryNoPayload(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncRelativeRetryNoPayloadRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsPostAsyncRelativeRetryNoPayloadHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut200InvalidJsonRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/put/200/invalidjson", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that is not a valid json. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put200InvalidJsonAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut200InvalidJsonRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that is not a valid json. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put200InvalidJson(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut200InvalidJsonRequest(product);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutAsyncRelativeRetryInvalidHeaderRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/putasync/retry/invalidheader", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsPutAsyncRelativeRetryInvalidHeaderHeaders>> PutAsyncRelativeRetryInvalidHeaderAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncRelativeRetryInvalidHeaderRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsPutAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsPutAsyncRelativeRetryInvalidHeaderHeaders> PutAsyncRelativeRetryInvalidHeader(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncRelativeRetryInvalidHeaderRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsPutAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutAsyncRelativeRetryInvalidJsonPollingRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/putasync/retry/invalidjsonpolling", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsPutAsyncRelativeRetryInvalidJsonPollingHeaders>> PutAsyncRelativeRetryInvalidJsonPollingAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncRelativeRetryInvalidJsonPollingRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsPutAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsPutAsyncRelativeRetryInvalidJsonPollingHeaders> PutAsyncRelativeRetryInvalidJsonPolling(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncRelativeRetryInvalidJsonPollingRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsPutAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDelete202RetryInvalidHeaderRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/delete/202/retry/invalidheader", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request receing a reponse with an invalid 'Location' and 'Retry-After' headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsDelete202RetryInvalidHeaderHeaders>> Delete202RetryInvalidHeaderAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete202RetryInvalidHeaderRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsDelete202RetryInvalidHeaderHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request receing a reponse with an invalid 'Location' and 'Retry-After' headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsDelete202RetryInvalidHeaderHeaders> Delete202RetryInvalidHeader(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete202RetryInvalidHeaderRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsDelete202RetryInvalidHeaderHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteAsyncRelativeRetryInvalidHeaderRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/deleteasync/retry/invalidheader", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsDeleteAsyncRelativeRetryInvalidHeaderHeaders>> DeleteAsyncRelativeRetryInvalidHeaderAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncRelativeRetryInvalidHeaderRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsDeleteAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsDeleteAsyncRelativeRetryInvalidHeaderHeaders> DeleteAsyncRelativeRetryInvalidHeader(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncRelativeRetryInvalidHeaderRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsDeleteAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteAsyncRelativeRetryInvalidJsonPollingRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/deleteasync/retry/invalidjsonpolling", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsDeleteAsyncRelativeRetryInvalidJsonPollingHeaders>> DeleteAsyncRelativeRetryInvalidJsonPollingAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncRelativeRetryInvalidJsonPollingRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsDeleteAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsDeleteAsyncRelativeRetryInvalidJsonPollingHeaders> DeleteAsyncRelativeRetryInvalidJsonPolling(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncRelativeRetryInvalidJsonPollingRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsDeleteAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost202RetryInvalidHeaderRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/post/202/retry/invalidheader", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with invalid 'Location' and 'Retry-After' headers. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsPost202RetryInvalidHeaderHeaders>> Post202RetryInvalidHeaderAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePost202RetryInvalidHeaderRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsPost202RetryInvalidHeaderHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with invalid 'Location' and 'Retry-After' headers. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsPost202RetryInvalidHeaderHeaders> Post202RetryInvalidHeader(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePost202RetryInvalidHeaderRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsPost202RetryInvalidHeaderHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostAsyncRelativeRetryInvalidHeaderRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/postasync/retry/invalidheader", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsPostAsyncRelativeRetryInvalidHeaderHeaders>> PostAsyncRelativeRetryInvalidHeaderAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncRelativeRetryInvalidHeaderRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsPostAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsPostAsyncRelativeRetryInvalidHeaderHeaders> PostAsyncRelativeRetryInvalidHeader(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncRelativeRetryInvalidHeaderRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsPostAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostAsyncRelativeRetryInvalidJsonPollingRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/error/postasync/retry/invalidjsonpolling", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (product != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(product);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LrosaDsPostAsyncRelativeRetryInvalidJsonPollingHeaders>> PostAsyncRelativeRetryInvalidJsonPollingAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncRelativeRetryInvalidJsonPollingRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LrosaDsPostAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LrosaDsPostAsyncRelativeRetryInvalidJsonPollingHeaders> PostAsyncRelativeRetryInvalidJsonPolling(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncRelativeRetryInvalidJsonPollingRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LrosaDsPostAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
