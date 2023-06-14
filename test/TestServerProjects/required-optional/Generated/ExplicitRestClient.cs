// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using required_optional.Models;

namespace required_optional
{
    internal partial class ExplicitRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of ExplicitRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public ExplicitRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreatePutOptionalBinaryBodyRequest(Stream bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/explicit/optional/binary-body", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (bodyParameter != null)
            {
                request.Headers.Add("Content-Type", "application/octet-stream");
                request.Content = RequestContent.Create(bodyParameter);
            }
            return message;
        }

        /// <summary> Test explicitly optional body parameter. </summary>
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

        /// <summary> Test explicitly optional body parameter. </summary>
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

        internal HttpMessage CreatePutRequiredBinaryBodyRequest(Stream bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/explicit/required/binary-body", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/octet-stream");
            request.Content = RequestContent.Create(bodyParameter);
            return message;
        }

        /// <summary> Test explicitly required body parameter. </summary>
        /// <param name="bodyParameter"> The Stream to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public async Task<Response> PutRequiredBinaryBodyAsync(Stream bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePutRequiredBinaryBodyRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly required body parameter. </summary>
        /// <param name="bodyParameter"> The Stream to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public Response PutRequiredBinaryBody(Stream bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePutRequiredBinaryBodyRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostRequiredIntegerParameterRequest(int bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/requied/integer/parameter", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(bodyParameter);
            request.Content = content;
            return message;
        }

        /// <summary> Test explicitly required integer. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostRequiredIntegerParameterAsync(int bodyParameter, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostRequiredIntegerParameterRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly required integer. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostRequiredIntegerParameter(int bodyParameter, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostRequiredIntegerParameterRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostOptionalIntegerParameterRequest(int? bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/optional/integer/parameter", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (bodyParameter != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteNumberValue(bodyParameter.Value);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Test explicitly optional integer. Please put null. </summary>
        /// <param name="bodyParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostOptionalIntegerParameterAsync(int? bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalIntegerParameterRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly optional integer. Please put null. </summary>
        /// <param name="bodyParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostOptionalIntegerParameter(int? bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalIntegerParameterRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostRequiredIntegerPropertyRequest(IntWrapper bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/requied/integer/property", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(bodyParameter);
            request.Content = content;
            return message;
        }

        /// <summary> Test explicitly required integer. Please put a valid int-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The IntWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public async Task<Response> PostRequiredIntegerPropertyAsync(IntWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePostRequiredIntegerPropertyRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly required integer. Please put a valid int-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The IntWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public Response PostRequiredIntegerProperty(IntWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePostRequiredIntegerPropertyRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostOptionalIntegerPropertyRequest(IntOptionalWrapper bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/optional/integer/property", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (bodyParameter != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(bodyParameter);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Test explicitly optional integer. Please put a valid int-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The IntOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostOptionalIntegerPropertyAsync(IntOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalIntegerPropertyRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly optional integer. Please put a valid int-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The IntOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostOptionalIntegerProperty(IntOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalIntegerPropertyRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostRequiredIntegerHeaderRequest(int headerParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/requied/integer/header", false);
            request.Uri = uri;
            request.Headers.Add("headerParameter", headerParameter);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Test explicitly required integer. Please put a header 'headerParameter' =&gt; null and the client library should throw before the request is sent. </summary>
        /// <param name="headerParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostRequiredIntegerHeaderAsync(int headerParameter, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostRequiredIntegerHeaderRequest(headerParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly required integer. Please put a header 'headerParameter' =&gt; null and the client library should throw before the request is sent. </summary>
        /// <param name="headerParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostRequiredIntegerHeader(int headerParameter, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostRequiredIntegerHeaderRequest(headerParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostOptionalIntegerHeaderRequest(int? headerParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/optional/integer/header", false);
            request.Uri = uri;
            if (headerParameter != null)
            {
                request.Headers.Add("headerParameter", headerParameter.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Test explicitly optional integer. Please put a header 'headerParameter' =&gt; null. </summary>
        /// <param name="headerParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostOptionalIntegerHeaderAsync(int? headerParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalIntegerHeaderRequest(headerParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly optional integer. Please put a header 'headerParameter' =&gt; null. </summary>
        /// <param name="headerParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostOptionalIntegerHeader(int? headerParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalIntegerHeaderRequest(headerParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostRequiredStringParameterRequest(string bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/requied/string/parameter", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(bodyParameter);
            request.Content = content;
            return message;
        }

        /// <summary> Test explicitly required string. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public async Task<Response> PostRequiredStringParameterAsync(string bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePostRequiredStringParameterRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly required string. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public Response PostRequiredStringParameter(string bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePostRequiredStringParameterRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostOptionalStringParameterRequest(string bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/optional/string/parameter", false);
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

        /// <summary> Test explicitly optional string. Please put null. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostOptionalStringParameterAsync(string bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalStringParameterRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly optional string. Please put null. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostOptionalStringParameter(string bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalStringParameterRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostRequiredStringPropertyRequest(StringWrapper bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/requied/string/property", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(bodyParameter);
            request.Content = content;
            return message;
        }

        /// <summary> Test explicitly required string. Please put a valid string-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The StringWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public async Task<Response> PostRequiredStringPropertyAsync(StringWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePostRequiredStringPropertyRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly required string. Please put a valid string-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The StringWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public Response PostRequiredStringProperty(StringWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePostRequiredStringPropertyRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostOptionalStringPropertyRequest(StringOptionalWrapper bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/optional/string/property", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (bodyParameter != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(bodyParameter);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Test explicitly optional integer. Please put a valid string-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The StringOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostOptionalStringPropertyAsync(StringOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalStringPropertyRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly optional integer. Please put a valid string-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The StringOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostOptionalStringProperty(StringOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalStringPropertyRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostRequiredStringHeaderRequest(string headerParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/requied/string/header", false);
            request.Uri = uri;
            request.Headers.Add("headerParameter", headerParameter);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Test explicitly required string. Please put a header 'headerParameter' =&gt; null and the client library should throw before the request is sent. </summary>
        /// <param name="headerParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headerParameter"/> is null. </exception>
        public async Task<Response> PostRequiredStringHeaderAsync(string headerParameter, CancellationToken cancellationToken = default)
        {
            if (headerParameter == null)
            {
                throw new ArgumentNullException(nameof(headerParameter));
            }

            using var message = CreatePostRequiredStringHeaderRequest(headerParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly required string. Please put a header 'headerParameter' =&gt; null and the client library should throw before the request is sent. </summary>
        /// <param name="headerParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headerParameter"/> is null. </exception>
        public Response PostRequiredStringHeader(string headerParameter, CancellationToken cancellationToken = default)
        {
            if (headerParameter == null)
            {
                throw new ArgumentNullException(nameof(headerParameter));
            }

            using var message = CreatePostRequiredStringHeaderRequest(headerParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostOptionalStringHeaderRequest(string bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/optional/string/header", false);
            request.Uri = uri;
            if (bodyParameter != null)
            {
                request.Headers.Add("bodyParameter", bodyParameter);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Test explicitly optional string. Please put a header 'headerParameter' =&gt; null. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostOptionalStringHeaderAsync(string bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalStringHeaderRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly optional string. Please put a header 'headerParameter' =&gt; null. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostOptionalStringHeader(string bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalStringHeaderRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostRequiredClassParameterRequest(Product bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/requied/class/parameter", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(bodyParameter);
            request.Content = content;
            return message;
        }

        /// <summary> Test explicitly required complex object. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The Product to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public async Task<Response> PostRequiredClassParameterAsync(Product bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePostRequiredClassParameterRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly required complex object. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The Product to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public Response PostRequiredClassParameter(Product bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePostRequiredClassParameterRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostOptionalClassParameterRequest(Product bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/optional/class/parameter", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (bodyParameter != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(bodyParameter);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Test explicitly optional complex object. Please put null. </summary>
        /// <param name="bodyParameter"> The Product to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostOptionalClassParameterAsync(Product bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalClassParameterRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly optional complex object. Please put null. </summary>
        /// <param name="bodyParameter"> The Product to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostOptionalClassParameter(Product bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalClassParameterRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostRequiredClassPropertyRequest(ClassWrapper bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/requied/class/property", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(bodyParameter);
            request.Content = content;
            return message;
        }

        /// <summary> Test explicitly required complex object. Please put a valid class-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The ClassWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public async Task<Response> PostRequiredClassPropertyAsync(ClassWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePostRequiredClassPropertyRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly required complex object. Please put a valid class-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The ClassWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public Response PostRequiredClassProperty(ClassWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePostRequiredClassPropertyRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostOptionalClassPropertyRequest(ClassOptionalWrapper bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/optional/class/property", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (bodyParameter != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(bodyParameter);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Test explicitly optional complex object. Please put a valid class-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The ClassOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostOptionalClassPropertyAsync(ClassOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalClassPropertyRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly optional complex object. Please put a valid class-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The ClassOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostOptionalClassProperty(ClassOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalClassPropertyRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostRequiredArrayParameterRequest(IEnumerable<string> bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/requied/array/parameter", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in bodyParameter)
            {
                content.JsonWriter.WriteStringValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Test explicitly required array. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The ArrayOfPostContentSchemaItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public async Task<Response> PostRequiredArrayParameterAsync(IEnumerable<string> bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePostRequiredArrayParameterRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly required array. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The ArrayOfPostContentSchemaItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public Response PostRequiredArrayParameter(IEnumerable<string> bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePostRequiredArrayParameterRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostOptionalArrayParameterRequest(IEnumerable<string> bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/optional/array/parameter", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (bodyParameter != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (var item in bodyParameter)
                {
                    content.JsonWriter.WriteStringValue(item);
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;
            }
            return message;
        }

        /// <summary> Test explicitly optional array. Please put null. </summary>
        /// <param name="bodyParameter"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostOptionalArrayParameterAsync(IEnumerable<string> bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalArrayParameterRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly optional array. Please put null. </summary>
        /// <param name="bodyParameter"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostOptionalArrayParameter(IEnumerable<string> bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalArrayParameterRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostRequiredArrayPropertyRequest(ArrayWrapper bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/requied/array/property", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(bodyParameter);
            request.Content = content;
            return message;
        }

        /// <summary> Test explicitly required array. Please put a valid array-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The ArrayWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public async Task<Response> PostRequiredArrayPropertyAsync(ArrayWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePostRequiredArrayPropertyRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly required array. Please put a valid array-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The ArrayWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        public Response PostRequiredArrayProperty(ArrayWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            if (bodyParameter == null)
            {
                throw new ArgumentNullException(nameof(bodyParameter));
            }

            using var message = CreatePostRequiredArrayPropertyRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostOptionalArrayPropertyRequest(ArrayOptionalWrapper bodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/optional/array/property", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (bodyParameter != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(bodyParameter);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Test explicitly optional array. Please put a valid array-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The ArrayOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostOptionalArrayPropertyAsync(ArrayOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalArrayPropertyRequest(bodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly optional array. Please put a valid array-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The ArrayOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostOptionalArrayProperty(ArrayOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalArrayPropertyRequest(bodyParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostRequiredArrayHeaderRequest(IEnumerable<string> headerParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/requied/array/header", false);
            request.Uri = uri;
            request.Headers.AddDelimited("headerParameter", headerParameter, ",");
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Test explicitly required array. Please put a header 'headerParameter' =&gt; null and the client library should throw before the request is sent. </summary>
        /// <param name="headerParameter"> The ArrayOfPost0ItemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headerParameter"/> is null. </exception>
        public async Task<Response> PostRequiredArrayHeaderAsync(IEnumerable<string> headerParameter, CancellationToken cancellationToken = default)
        {
            if (headerParameter == null)
            {
                throw new ArgumentNullException(nameof(headerParameter));
            }

            using var message = CreatePostRequiredArrayHeaderRequest(headerParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly required array. Please put a header 'headerParameter' =&gt; null and the client library should throw before the request is sent. </summary>
        /// <param name="headerParameter"> The ArrayOfPost0ItemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headerParameter"/> is null. </exception>
        public Response PostRequiredArrayHeader(IEnumerable<string> headerParameter, CancellationToken cancellationToken = default)
        {
            if (headerParameter == null)
            {
                throw new ArgumentNullException(nameof(headerParameter));
            }

            using var message = CreatePostRequiredArrayHeaderRequest(headerParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostOptionalArrayHeaderRequest(IEnumerable<string> headerParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/reqopt/optional/array/header", false);
            request.Uri = uri;
            if (headerParameter != null)
            {
                request.Headers.AddDelimited("headerParameter", headerParameter, ",");
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Test explicitly optional integer. Please put a header 'headerParameter' =&gt; null. </summary>
        /// <param name="headerParameter"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostOptionalArrayHeaderAsync(IEnumerable<string> headerParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalArrayHeaderRequest(headerParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test explicitly optional integer. Please put a header 'headerParameter' =&gt; null. </summary>
        /// <param name="headerParameter"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostOptionalArrayHeader(IEnumerable<string> headerParameter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePostOptionalArrayHeaderRequest(headerParameter);
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
