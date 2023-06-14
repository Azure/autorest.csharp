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
    internal partial class LROsRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of LROsRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public LROsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreatePut200SucceededRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/put/200/succeeded", false);
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

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put200SucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut200SucceededRequest(product);
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

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put200Succeeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut200SucceededRequest(product);
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

        internal HttpMessage CreatePatch200SucceededIgnoreHeadersRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/patch/200/succeeded/ignoreheaders", false);
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

        /// <summary> Long running put request, service returns a 200 to the initial request with location header. We should not have any subsequent calls after receiving this first response. </summary>
        /// <param name="product"> Product to patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsPatch200SucceededIgnoreHeadersHeaders>> Patch200SucceededIgnoreHeadersAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch200SucceededIgnoreHeadersRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPatch200SucceededIgnoreHeadersHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request with location header. We should not have any subsequent calls after receiving this first response. </summary>
        /// <param name="product"> Product to patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsPatch200SucceededIgnoreHeadersHeaders> Patch200SucceededIgnoreHeaders(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch200SucceededIgnoreHeadersRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPatch200SucceededIgnoreHeadersHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePatch201RetryWithAsyncHeaderRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/patch/201/retry/onlyAsyncHeader", false);
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

        /// <summary> Long running patch request, service returns a 201 to the initial request with async header. </summary>
        /// <param name="product"> Product to patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsPatch201RetryWithAsyncHeaderHeaders>> Patch201RetryWithAsyncHeaderAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch201RetryWithAsyncHeaderRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPatch201RetryWithAsyncHeaderHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running patch request, service returns a 201 to the initial request with async header. </summary>
        /// <param name="product"> Product to patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsPatch201RetryWithAsyncHeaderHeaders> Patch201RetryWithAsyncHeader(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch201RetryWithAsyncHeaderRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPatch201RetryWithAsyncHeaderHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePatch202RetryWithAsyncAndLocationHeaderRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/patch/202/retry/asyncAndLocationHeader", false);
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

        /// <summary> Long running patch request, service returns a 202 to the initial request with async and location header. </summary>
        /// <param name="product"> Product to patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsPatch202RetryWithAsyncAndLocationHeaderHeaders>> Patch202RetryWithAsyncAndLocationHeaderAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch202RetryWithAsyncAndLocationHeaderRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPatch202RetryWithAsyncAndLocationHeaderHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running patch request, service returns a 202 to the initial request with async and location header. </summary>
        /// <param name="product"> Product to patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsPatch202RetryWithAsyncAndLocationHeaderHeaders> Patch202RetryWithAsyncAndLocationHeader(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch202RetryWithAsyncAndLocationHeaderRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPatch202RetryWithAsyncAndLocationHeaderHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut201SucceededRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/put/201/succeeded", false);
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

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put201SucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut201SucceededRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put201Succeeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut201SucceededRequest(product);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost202ListRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/list", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running put request, service returns a 202 with empty body to first request, returns a 200 with body [{ 'id': '100', 'name': 'foo' }]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsPost202ListHeaders>> Post202ListAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost202ListRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPost202ListHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 202 with empty body to first request, returns a 200 with body [{ 'id': '100', 'name': 'foo' }]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsPost202ListHeaders> Post202List(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost202ListRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPost202ListHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut200SucceededNoStateRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/put/200/succeeded/nostate", false);
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

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that does not contain ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put200SucceededNoStateAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut200SucceededNoStateRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that does not contain ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put200SucceededNoState(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut200SucceededNoStateRequest(product);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut202Retry200Request(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/put/202/retry/200", false);
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

        /// <summary> Long running put request, service returns a 202 to the initial request, with a location header that points to a polling URL that returns a 200 and an entity that doesn't contains ProvisioningState. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put202Retry200Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut202Retry200Request(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 202 to the initial request, with a location header that points to a polling URL that returns a 200 and an entity that doesn't contains ProvisioningState. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put202Retry200(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut202Retry200Request(product);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut201CreatingSucceeded200Request(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/put/201/creating/succeeded/200", false);
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

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put201CreatingSucceeded200Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut201CreatingSucceeded200Request(product);
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

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put201CreatingSucceeded200(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut201CreatingSucceeded200Request(product);
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

        internal HttpMessage CreatePut200UpdatingSucceeded204Request(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/put/200/updating/succeeded/200", false);
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

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Updating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put200UpdatingSucceeded204Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut200UpdatingSucceeded204Request(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Updating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put200UpdatingSucceeded204(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut200UpdatingSucceeded204Request(product);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut201CreatingFailed200Request(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/put/201/created/failed/200", false);
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

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Created’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put201CreatingFailed200Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut201CreatingFailed200Request(product);
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

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Created’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put201CreatingFailed200(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut201CreatingFailed200Request(product);
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

        internal HttpMessage CreatePut200Acceptedcanceled200Request(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/put/200/accepted/canceled/200", false);
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

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put200Acceptedcanceled200Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut200Acceptedcanceled200Request(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put200Acceptedcanceled200(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePut200Acceptedcanceled200Request(product);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutNoHeaderInRetryRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/put/noheader/202/200", false);
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

        /// <summary> Long running put request, service returns a 202 to the initial request with location header. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsPutNoHeaderInRetryHeaders>> PutNoHeaderInRetryAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoHeaderInRetryRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPutNoHeaderInRetryHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 202 to the initial request with location header. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsPutNoHeaderInRetryHeaders> PutNoHeaderInRetry(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoHeaderInRetryRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPutNoHeaderInRetryHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutAsyncRetrySucceededRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/putasync/retry/succeeded", false);
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
        public async Task<ResponseWithHeaders<LROsPutAsyncRetrySucceededHeaders>> PutAsyncRetrySucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncRetrySucceededRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPutAsyncRetrySucceededHeaders(message.Response);
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
        public ResponseWithHeaders<LROsPutAsyncRetrySucceededHeaders> PutAsyncRetrySucceeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncRetrySucceededRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPutAsyncRetrySucceededHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutAsyncNoRetrySucceededRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/putasync/noretry/succeeded", false);
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
        public async Task<ResponseWithHeaders<LROsPutAsyncNoRetrySucceededHeaders>> PutAsyncNoRetrySucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncNoRetrySucceededRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPutAsyncNoRetrySucceededHeaders(message.Response);
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
        public ResponseWithHeaders<LROsPutAsyncNoRetrySucceededHeaders> PutAsyncNoRetrySucceeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncNoRetrySucceededRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPutAsyncNoRetrySucceededHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutAsyncRetryFailedRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/putasync/retry/failed", false);
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
        public async Task<ResponseWithHeaders<LROsPutAsyncRetryFailedHeaders>> PutAsyncRetryFailedAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncRetryFailedRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPutAsyncRetryFailedHeaders(message.Response);
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
        public ResponseWithHeaders<LROsPutAsyncRetryFailedHeaders> PutAsyncRetryFailed(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncRetryFailedRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPutAsyncRetryFailedHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutAsyncNoRetrycanceledRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/putasync/noretry/canceled", false);
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
        public async Task<ResponseWithHeaders<LROsPutAsyncNoRetrycanceledHeaders>> PutAsyncNoRetrycanceledAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncNoRetrycanceledRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPutAsyncNoRetrycanceledHeaders(message.Response);
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
        public ResponseWithHeaders<LROsPutAsyncNoRetrycanceledHeaders> PutAsyncNoRetrycanceled(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncNoRetrycanceledRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPutAsyncNoRetrycanceledHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutAsyncNoHeaderInRetryRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/putasync/noheader/201/200", false);
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

        /// <summary> Long running put request, service returns a 202 to the initial request with Azure-AsyncOperation header. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsPutAsyncNoHeaderInRetryHeaders>> PutAsyncNoHeaderInRetryAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncNoHeaderInRetryRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPutAsyncNoHeaderInRetryHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 201:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request, service returns a 202 to the initial request with Azure-AsyncOperation header. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsPutAsyncNoHeaderInRetryHeaders> PutAsyncNoHeaderInRetry(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncNoHeaderInRetryRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPutAsyncNoHeaderInRetryHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 201:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutNonResourceRequest(Sku sku)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/putnonresource/202/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (sku != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(sku);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutNonResourceAsync(Sku sku = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNonResourceRequest(sku);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNonResource(Sku sku = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNonResourceRequest(sku);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutAsyncNonResourceRequest(Sku sku)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/putnonresourceasync/202/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (sku != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(sku);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> Sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutAsyncNonResourceAsync(Sku sku = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncNonResourceRequest(sku);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> Sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutAsyncNonResource(Sku sku = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncNonResourceRequest(sku);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutSubResourceRequest(SubProduct product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/putsubresource/202/200", false);
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

        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutSubResourceAsync(SubProduct product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutSubResourceRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutSubResource(SubProduct product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutSubResourceRequest(product);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutAsyncSubResourceRequest(SubProduct product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/putsubresourceasync/202/200", false);
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

        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutAsyncSubResourceAsync(SubProduct product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncSubResourceRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutAsyncSubResource(SubProduct product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutAsyncSubResourceRequest(product);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteProvisioning202Accepted200SucceededRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/delete/provisioning/202/accepted/200/succeeded", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsDeleteProvisioning202Accepted200SucceededHeaders>> DeleteProvisioning202Accepted200SucceededAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteProvisioning202Accepted200SucceededRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsDeleteProvisioning202Accepted200SucceededHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsDeleteProvisioning202Accepted200SucceededHeaders> DeleteProvisioning202Accepted200Succeeded(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteProvisioning202Accepted200SucceededRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsDeleteProvisioning202Accepted200SucceededHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteProvisioning202DeletingFailed200Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/delete/provisioning/202/deleting/200/failed", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsDeleteProvisioning202DeletingFailed200Headers>> DeleteProvisioning202DeletingFailed200Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteProvisioning202DeletingFailed200Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsDeleteProvisioning202DeletingFailed200Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsDeleteProvisioning202DeletingFailed200Headers> DeleteProvisioning202DeletingFailed200(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteProvisioning202DeletingFailed200Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsDeleteProvisioning202DeletingFailed200Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteProvisioning202Deletingcanceled200Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/delete/provisioning/202/deleting/200/canceled", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsDeleteProvisioning202Deletingcanceled200Headers>> DeleteProvisioning202Deletingcanceled200Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteProvisioning202Deletingcanceled200Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsDeleteProvisioning202Deletingcanceled200Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsDeleteProvisioning202Deletingcanceled200Headers> DeleteProvisioning202Deletingcanceled200(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteProvisioning202Deletingcanceled200Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsDeleteProvisioning202Deletingcanceled200Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
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
            uri.AppendPath("/lro/delete/204/succeeded", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete succeeds and returns right away. </summary>
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

        /// <summary> Long running delete succeeds and returns right away. </summary>
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

        internal HttpMessage CreateDelete202Retry200Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/delete/202/retry/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsDelete202Retry200Headers>> Delete202Retry200Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete202Retry200Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsDelete202Retry200Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsDelete202Retry200Headers> Delete202Retry200(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete202Retry200Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsDelete202Retry200Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDelete202NoRetry204Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/delete/202/noretry/204", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsDelete202NoRetry204Headers>> Delete202NoRetry204Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete202NoRetry204Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsDelete202NoRetry204Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsDelete202NoRetry204Headers> Delete202NoRetry204(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete202NoRetry204Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsDelete202NoRetry204Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteNoHeaderInRetryRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/delete/noheader", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a location header in the initial request. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsDeleteNoHeaderInRetryHeaders>> DeleteNoHeaderInRetryAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteNoHeaderInRetryRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsDeleteNoHeaderInRetryHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns a location header in the initial request. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsDeleteNoHeaderInRetryHeaders> DeleteNoHeaderInRetry(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteNoHeaderInRetryRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsDeleteNoHeaderInRetryHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteAsyncNoHeaderInRetryRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/deleteasync/noheader/202/204", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns an Azure-AsyncOperation header in the initial request. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsDeleteAsyncNoHeaderInRetryHeaders>> DeleteAsyncNoHeaderInRetryAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncNoHeaderInRetryRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsDeleteAsyncNoHeaderInRetryHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running delete request, service returns an Azure-AsyncOperation header in the initial request. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsDeleteAsyncNoHeaderInRetryHeaders> DeleteAsyncNoHeaderInRetry(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncNoHeaderInRetryRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsDeleteAsyncNoHeaderInRetryHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteAsyncRetrySucceededRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/deleteasync/retry/succeeded", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsDeleteAsyncRetrySucceededHeaders>> DeleteAsyncRetrySucceededAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncRetrySucceededRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsDeleteAsyncRetrySucceededHeaders(message.Response);
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
        public ResponseWithHeaders<LROsDeleteAsyncRetrySucceededHeaders> DeleteAsyncRetrySucceeded(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncRetrySucceededRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsDeleteAsyncRetrySucceededHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteAsyncNoRetrySucceededRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/deleteasync/noretry/succeeded", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsDeleteAsyncNoRetrySucceededHeaders>> DeleteAsyncNoRetrySucceededAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncNoRetrySucceededRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsDeleteAsyncNoRetrySucceededHeaders(message.Response);
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
        public ResponseWithHeaders<LROsDeleteAsyncNoRetrySucceededHeaders> DeleteAsyncNoRetrySucceeded(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncNoRetrySucceededRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsDeleteAsyncNoRetrySucceededHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteAsyncRetryFailedRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/deleteasync/retry/failed", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsDeleteAsyncRetryFailedHeaders>> DeleteAsyncRetryFailedAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncRetryFailedRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsDeleteAsyncRetryFailedHeaders(message.Response);
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
        public ResponseWithHeaders<LROsDeleteAsyncRetryFailedHeaders> DeleteAsyncRetryFailed(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncRetryFailedRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsDeleteAsyncRetryFailedHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteAsyncRetrycanceledRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/deleteasync/retry/canceled", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsDeleteAsyncRetrycanceledHeaders>> DeleteAsyncRetrycanceledAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncRetrycanceledRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsDeleteAsyncRetrycanceledHeaders(message.Response);
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
        public ResponseWithHeaders<LROsDeleteAsyncRetrycanceledHeaders> DeleteAsyncRetrycanceled(CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteAsyncRetrycanceledRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsDeleteAsyncRetrycanceledHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost200WithPayloadRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/post/payload/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with 'Location' header. Poll returns a 200 with a response body after success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Post200WithPayloadAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost200WithPayloadRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with 'Location' header. Poll returns a 200 with a response body after success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post200WithPayload(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost200WithPayloadRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost202Retry200Request(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/post/202/retry/200", false);
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

        /// <summary> Long running post request, service returns a 202 to the initial request, with 'Location' and 'Retry-After' headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsPost202Retry200Headers>> Post202Retry200Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePost202Retry200Request(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPost202Retry200Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with 'Location' and 'Retry-After' headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsPost202Retry200Headers> Post202Retry200(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePost202Retry200Request(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPost202Retry200Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost202NoRetry204Request(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/post/202/noretry/204", false);
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

        /// <summary> Long running post request, service returns a 202 to the initial request, with 'Location' header, 204 with noresponse body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LROsPost202NoRetry204Headers>> Post202NoRetry204Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePost202NoRetry204Request(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPost202NoRetry204Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with 'Location' header, 204 with noresponse body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsPost202NoRetry204Headers> Post202NoRetry204(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePost202NoRetry204Request(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPost202NoRetry204Headers(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostDoubleHeadersFinalLocationGetRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/LROPostDoubleHeadersFinalLocationGet", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it's success. Should poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostDoubleHeadersFinalLocationGetAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostDoubleHeadersFinalLocationGetRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it's success. Should poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostDoubleHeadersFinalLocationGet(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostDoubleHeadersFinalLocationGetRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostDoubleHeadersFinalAzureHeaderGetRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/LROPostDoubleHeadersFinalAzureHeaderGet", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it's success. Should NOT poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostDoubleHeadersFinalAzureHeaderGetAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostDoubleHeadersFinalAzureHeaderGetRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it's success. Should NOT poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostDoubleHeadersFinalAzureHeaderGet(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostDoubleHeadersFinalAzureHeaderGetRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostDoubleHeadersFinalAzureHeaderGetDefaultRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/LROPostDoubleHeadersFinalAzureHeaderGetDefault", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it's success. Should NOT poll Location to get the final object if you support initial Autorest behavior. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostDoubleHeadersFinalAzureHeaderGetDefaultAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostDoubleHeadersFinalAzureHeaderGetDefaultRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it's success. Should NOT poll Location to get the final object if you support initial Autorest behavior. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostDoubleHeadersFinalAzureHeaderGetDefault(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostDoubleHeadersFinalAzureHeaderGetDefaultRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostAsyncRetrySucceededRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/postasync/retry/succeeded", false);
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
        public async Task<ResponseWithHeaders<LROsPostAsyncRetrySucceededHeaders>> PostAsyncRetrySucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncRetrySucceededRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPostAsyncRetrySucceededHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsPostAsyncRetrySucceededHeaders> PostAsyncRetrySucceeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncRetrySucceededRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPostAsyncRetrySucceededHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostAsyncNoRetrySucceededRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/postasync/noretry/succeeded", false);
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
        public async Task<ResponseWithHeaders<LROsPostAsyncNoRetrySucceededHeaders>> PostAsyncNoRetrySucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncNoRetrySucceededRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPostAsyncNoRetrySucceededHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LROsPostAsyncNoRetrySucceededHeaders> PostAsyncNoRetrySucceeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncNoRetrySucceededRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPostAsyncNoRetrySucceededHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostAsyncRetryFailedRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/postasync/retry/failed", false);
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
        public async Task<ResponseWithHeaders<LROsPostAsyncRetryFailedHeaders>> PostAsyncRetryFailedAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncRetryFailedRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPostAsyncRetryFailedHeaders(message.Response);
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
        public ResponseWithHeaders<LROsPostAsyncRetryFailedHeaders> PostAsyncRetryFailed(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncRetryFailedRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPostAsyncRetryFailedHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostAsyncRetrycanceledRequest(Product product)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/postasync/retry/canceled", false);
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
        public async Task<ResponseWithHeaders<LROsPostAsyncRetrycanceledHeaders>> PostAsyncRetrycanceledAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncRetrycanceledRequest(product);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROsPostAsyncRetrycanceledHeaders(message.Response);
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
        public ResponseWithHeaders<LROsPostAsyncRetrycanceledHeaders> PostAsyncRetrycanceled(Product product = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostAsyncRetrycanceledRequest(product);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROsPostAsyncRetrycanceledHeaders(message.Response);
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
