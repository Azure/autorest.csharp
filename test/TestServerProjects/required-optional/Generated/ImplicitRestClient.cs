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

namespace required_optional
{
    internal partial class ImplicitRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _requiredGlobalPath;
        private readonly string _requiredGlobalQuery;
        private readonly Uri _endpoint;
        private readonly int? _optionalGlobalQuery;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of ImplicitRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="requiredGlobalPath"> number of items to skip. </param>
        /// <param name="requiredGlobalQuery"> number of items to skip. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="optionalGlobalQuery"> number of items to skip. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="requiredGlobalPath"/> or <paramref name="requiredGlobalQuery"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="requiredGlobalPath"/> is an empty string, and was expected to be non-empty. </exception>
        public ImplicitRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string requiredGlobalPath, string requiredGlobalQuery, Uri endpoint = null, int? optionalGlobalQuery = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _requiredGlobalPath = requiredGlobalPath ?? throw new ArgumentNullException(nameof(requiredGlobalPath));
            _requiredGlobalQuery = requiredGlobalQuery ?? throw new ArgumentNullException(nameof(requiredGlobalQuery));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
            _optionalGlobalQuery = optionalGlobalQuery;
        }

        internal HttpMessage CreateGetRequiredPathRequest(string pathParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/implicit/required/path/", false);
            uri.AppendPath(pathParameter, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Test implicitly required path parameter. </summary>
        /// <param name="pathParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathParameter"/> is null. </exception>
        public async Task<Response> GetRequiredPathAsync(string pathParameter, CancellationToken cancellationToken = default)
        {
            if (pathParameter == null)
            {
                throw new ArgumentNullException(nameof(pathParameter));
            }

            using var message = CreateGetRequiredPathRequest(pathParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test implicitly required path parameter. </summary>
        /// <param name="pathParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathParameter"/> is null. </exception>
        public Response GetRequiredPath(string pathParameter, CancellationToken cancellationToken = default)
        {
            if (pathParameter == null)
            {
                throw new ArgumentNullException(nameof(pathParameter));
            }

            using var message = CreateGetRequiredPathRequest(pathParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutOptionalQueryRequest(string queryParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/implicit/optional/query", false);
            if (queryParameter != null)
            {
                uri.AppendQuery("queryParameter", queryParameter, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Test implicitly optional query parameter. </summary>
        /// <param name="queryParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutOptionalQueryAsync(string queryParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutOptionalQueryRequest(queryParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test implicitly optional query parameter. </summary>
        /// <param name="queryParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutOptionalQuery(string queryParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutOptionalQueryRequest(queryParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutOptionalHeaderRequest(string queryParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/implicit/optional/header", false);
            request.Uri = uri;
            if (queryParameter != null)
            {
                request.Headers.Add("queryParameter", queryParameter);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Test implicitly optional header parameter. </summary>
        /// <param name="queryParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutOptionalHeaderAsync(string queryParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutOptionalHeaderRequest(queryParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test implicitly optional header parameter. </summary>
        /// <param name="queryParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutOptionalHeader(string queryParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutOptionalHeaderRequest(queryParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutOptionalBodyRequest(string bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/implicit/optional/body", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (bodyParameter != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStringValue(bodyParameter);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Test implicitly optional body parameter. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutOptionalBodyAsync(string bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutOptionalBodyRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test implicitly optional body parameter. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutOptionalBody(string bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutOptionalBodyRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutOptionalBinaryBodyRequest(Stream bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/implicit/optional/binary-body", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (bodyParameter != null)
            {
                request.Headers.Add("Content-Type", "application/octet-stream");
                request.Content = RequestContent.Create(bodyParameter);
            }
            return message;
        }

        /// <summary> Test implicitly optional body parameter. </summary>
        /// <param name="bodyParameter"> The Stream to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutOptionalBinaryBodyAsync(Stream bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutOptionalBinaryBodyRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test implicitly optional body parameter. </summary>
        /// <param name="bodyParameter"> The Stream to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutOptionalBinaryBody(Stream bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutOptionalBinaryBodyRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequiredGlobalPathRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/global/required/path/", false);
            uri.AppendPath(_requiredGlobalPath, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Test implicitly required path parameter. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetRequiredGlobalPathAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetRequiredGlobalPathRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test implicitly required path parameter. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetRequiredGlobalPath(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetRequiredGlobalPathRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequiredGlobalQueryRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/global/required/query", false);
            uri.AppendQuery("required-global-query", _requiredGlobalQuery, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Test implicitly required query parameter. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetRequiredGlobalQueryAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetRequiredGlobalQueryRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test implicitly required query parameter. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetRequiredGlobalQuery(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetRequiredGlobalQueryRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetOptionalGlobalQueryRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/global/optional/query", false);
            if (_optionalGlobalQuery != null)
            {
                uri.AppendQuery("optional-global-query", _optionalGlobalQuery.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Test implicitly optional query parameter. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetOptionalGlobalQueryAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetOptionalGlobalQueryRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test implicitly optional query parameter. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetOptionalGlobalQuery(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetOptionalGlobalQueryRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
