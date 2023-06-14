// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using header.Models;

namespace header
{
    internal partial class HeaderRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of HeaderRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public HeaderRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateParamExistingKeyRequest(string userAgent)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/existingkey", false);
            request.Uri = uri;
            request.Headers.Add("User-Agent", userAgent);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a post request with header value "User-Agent": "overwrite". </summary>
        /// <param name="userAgent"> Send a post request with header value "User-Agent": "overwrite". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userAgent"/> is null. </exception>
        public async Task<Response> ParamExistingKeyAsync(string userAgent, CancellationToken cancellationToken = default)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            using var message = CreateParamExistingKeyRequest(userAgent);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a post request with header value "User-Agent": "overwrite". </summary>
        /// <param name="userAgent"> Send a post request with header value "User-Agent": "overwrite". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userAgent"/> is null. </exception>
        public Response ParamExistingKey(string userAgent, CancellationToken cancellationToken = default)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            using var message = CreateParamExistingKeyRequest(userAgent);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateResponseExistingKeyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/existingkey", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a response with header value "User-Agent": "overwrite". </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HeaderResponseExistingKeyHeaders>> ResponseExistingKeyAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateResponseExistingKeyRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderResponseExistingKeyHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a response with header value "User-Agent": "overwrite". </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HeaderResponseExistingKeyHeaders> ResponseExistingKey(CancellationToken cancellationToken = default)
        {
            using var message = CreateResponseExistingKeyRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderResponseExistingKeyHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateParamProtectedKeyRequest(string contentType)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/protectedkey", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a post request with header value "Content-Type": "text/html". </summary>
        /// <param name="contentType"> Send a post request with header value "Content-Type": "text/html". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contentType"/> is null. </exception>
        public async Task<Response> ParamProtectedKeyAsync(string contentType, CancellationToken cancellationToken = default)
        {
            if (contentType == null)
            {
                throw new ArgumentNullException(nameof(contentType));
            }

            using var message = CreateParamProtectedKeyRequest(contentType);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a post request with header value "Content-Type": "text/html". </summary>
        /// <param name="contentType"> Send a post request with header value "Content-Type": "text/html". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contentType"/> is null. </exception>
        public Response ParamProtectedKey(string contentType, CancellationToken cancellationToken = default)
        {
            if (contentType == null)
            {
                throw new ArgumentNullException(nameof(contentType));
            }

            using var message = CreateParamProtectedKeyRequest(contentType);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateResponseProtectedKeyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/protectedkey", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a response with header value "Content-Type": "text/html". </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HeaderResponseProtectedKeyHeaders>> ResponseProtectedKeyAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateResponseProtectedKeyRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderResponseProtectedKeyHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a response with header value "Content-Type": "text/html". </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HeaderResponseProtectedKeyHeaders> ResponseProtectedKey(CancellationToken cancellationToken = default)
        {
            using var message = CreateResponseProtectedKeyRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderResponseProtectedKeyHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateParamIntegerRequest(string scenario, int value)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/integer", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 1 or "scenario": "negative", "value": -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 1 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<Response> ParamIntegerAsync(string scenario, int value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamIntegerRequest(scenario, value);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 1 or "scenario": "negative", "value": -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 1 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public Response ParamInteger(string scenario, int value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamIntegerRequest(scenario, value);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateResponseIntegerRequest(string scenario)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/integer", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a response with header value "value": 1 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderResponseIntegerHeaders>> ResponseIntegerAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseIntegerRequest(scenario);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderResponseIntegerHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a response with header value "value": 1 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public ResponseWithHeaders<HeaderResponseIntegerHeaders> ResponseInteger(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseIntegerRequest(scenario);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderResponseIntegerHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateParamLongRequest(string scenario, long value)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/long", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 105 or "scenario": "negative", "value": -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 105 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<Response> ParamLongAsync(string scenario, long value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamLongRequest(scenario, value);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 105 or "scenario": "negative", "value": -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 105 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public Response ParamLong(string scenario, long value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamLongRequest(scenario, value);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateResponseLongRequest(string scenario)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/long", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a response with header value "value": 105 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderResponseLongHeaders>> ResponseLongAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseLongRequest(scenario);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderResponseLongHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a response with header value "value": 105 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public ResponseWithHeaders<HeaderResponseLongHeaders> ResponseLong(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseLongRequest(scenario);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderResponseLongHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateParamFloatRequest(string scenario, float value)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/float", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 0.07 or "scenario": "negative", "value": -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 0.07 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<Response> ParamFloatAsync(string scenario, float value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamFloatRequest(scenario, value);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 0.07 or "scenario": "negative", "value": -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 0.07 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public Response ParamFloat(string scenario, float value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamFloatRequest(scenario, value);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateResponseFloatRequest(string scenario)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/float", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a response with header value "value": 0.07 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderResponseFloatHeaders>> ResponseFloatAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseFloatRequest(scenario);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderResponseFloatHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a response with header value "value": 0.07 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public ResponseWithHeaders<HeaderResponseFloatHeaders> ResponseFloat(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseFloatRequest(scenario);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderResponseFloatHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateParamDoubleRequest(string scenario, double value)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/double", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 7e120 or "scenario": "negative", "value": -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 7e120 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<Response> ParamDoubleAsync(string scenario, double value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamDoubleRequest(scenario, value);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 7e120 or "scenario": "negative", "value": -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 7e120 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public Response ParamDouble(string scenario, double value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamDoubleRequest(scenario, value);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateResponseDoubleRequest(string scenario)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/double", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a response with header value "value": 7e120 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderResponseDoubleHeaders>> ResponseDoubleAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseDoubleRequest(scenario);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderResponseDoubleHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a response with header value "value": 7e120 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public ResponseWithHeaders<HeaderResponseDoubleHeaders> ResponseDouble(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseDoubleRequest(scenario);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderResponseDoubleHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateParamBoolRequest(string scenario, bool value)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/bool", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a post request with header values "scenario": "true", "value": true or "scenario": "false", "value": false. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "true" or "false". </param>
        /// <param name="value"> Send a post request with header values true or false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<Response> ParamBoolAsync(string scenario, bool value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamBoolRequest(scenario, value);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a post request with header values "scenario": "true", "value": true or "scenario": "false", "value": false. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "true" or "false". </param>
        /// <param name="value"> Send a post request with header values true or false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public Response ParamBool(string scenario, bool value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamBoolRequest(scenario, value);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateResponseBoolRequest(string scenario)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/bool", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a response with header value "value": true or false. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "true" or "false". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderResponseBoolHeaders>> ResponseBoolAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseBoolRequest(scenario);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderResponseBoolHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a response with header value "value": true or false. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "true" or "false". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public ResponseWithHeaders<HeaderResponseBoolHeaders> ResponseBool(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseBoolRequest(scenario);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderResponseBoolHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateParamStringRequest(string scenario, string value)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/string", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            if (value != null)
            {
                request.Headers.Add("value", value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "The quick brown fox jumps over the lazy dog" or "scenario": "null", "value": null or "scenario": "empty", "value": "". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="value"> Send a post request with header values "The quick brown fox jumps over the lazy dog" or null or "". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<Response> ParamStringAsync(string scenario, string value = null, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamStringRequest(scenario, value);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "The quick brown fox jumps over the lazy dog" or "scenario": "null", "value": null or "scenario": "empty", "value": "". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="value"> Send a post request with header values "The quick brown fox jumps over the lazy dog" or null or "". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public Response ParamString(string scenario, string value = null, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamStringRequest(scenario, value);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateResponseStringRequest(string scenario)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/string", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a response with header values "The quick brown fox jumps over the lazy dog" or null or "". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderResponseStringHeaders>> ResponseStringAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseStringRequest(scenario);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderResponseStringHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a response with header values "The quick brown fox jumps over the lazy dog" or null or "". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public ResponseWithHeaders<HeaderResponseStringHeaders> ResponseString(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseStringRequest(scenario);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderResponseStringHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateParamDateRequest(string scenario, DateTimeOffset value)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/date", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value, "D");
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "2010-01-01" or "scenario": "min", "value": "0001-01-01". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "2010-01-01" or "0001-01-01". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<Response> ParamDateAsync(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamDateRequest(scenario, value);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "2010-01-01" or "scenario": "min", "value": "0001-01-01". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "2010-01-01" or "0001-01-01". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public Response ParamDate(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamDateRequest(scenario, value);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateResponseDateRequest(string scenario)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/date", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a response with header values "2010-01-01" or "0001-01-01". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderResponseDateHeaders>> ResponseDateAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseDateRequest(scenario);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderResponseDateHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a response with header values "2010-01-01" or "0001-01-01". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public ResponseWithHeaders<HeaderResponseDateHeaders> ResponseDate(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseDateRequest(scenario);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderResponseDateHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateParamDatetimeRequest(string scenario, DateTimeOffset value)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/datetime", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value, "O");
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "2010-01-01T12:34:56Z" or "scenario": "min", "value": "0001-01-01T00:00:00Z". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "2010-01-01T12:34:56Z" or "0001-01-01T00:00:00Z". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<Response> ParamDatetimeAsync(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamDatetimeRequest(scenario, value);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "2010-01-01T12:34:56Z" or "scenario": "min", "value": "0001-01-01T00:00:00Z". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "2010-01-01T12:34:56Z" or "0001-01-01T00:00:00Z". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public Response ParamDatetime(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamDatetimeRequest(scenario, value);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateResponseDatetimeRequest(string scenario)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/datetime", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a response with header values "2010-01-01T12:34:56Z" or "0001-01-01T00:00:00Z". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderResponseDatetimeHeaders>> ResponseDatetimeAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseDatetimeRequest(scenario);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderResponseDatetimeHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a response with header values "2010-01-01T12:34:56Z" or "0001-01-01T00:00:00Z". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public ResponseWithHeaders<HeaderResponseDatetimeHeaders> ResponseDatetime(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseDatetimeRequest(scenario);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderResponseDatetimeHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateParamDatetimeRfc1123Request(string scenario, DateTimeOffset? value)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/datetimerfc1123", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            if (value != null)
            {
                request.Headers.Add("value", value.Value, "R");
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "Wed, 01 Jan 2010 12:34:56 GMT" or "scenario": "min", "value": "Mon, 01 Jan 0001 00:00:00 GMT". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "Wed, 01 Jan 2010 12:34:56 GMT" or "Mon, 01 Jan 0001 00:00:00 GMT". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<Response> ParamDatetimeRfc1123Async(string scenario, DateTimeOffset? value = null, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamDatetimeRfc1123Request(scenario, value);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "Wed, 01 Jan 2010 12:34:56 GMT" or "scenario": "min", "value": "Mon, 01 Jan 0001 00:00:00 GMT". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "Wed, 01 Jan 2010 12:34:56 GMT" or "Mon, 01 Jan 0001 00:00:00 GMT". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public Response ParamDatetimeRfc1123(string scenario, DateTimeOffset? value = null, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamDatetimeRfc1123Request(scenario, value);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateResponseDatetimeRfc1123Request(string scenario)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/datetimerfc1123", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a response with header values "Wed, 01 Jan 2010 12:34:56 GMT" or "Mon, 01 Jan 0001 00:00:00 GMT". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderResponseDatetimeRfc1123Headers>> ResponseDatetimeRfc1123Async(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseDatetimeRfc1123Request(scenario);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderResponseDatetimeRfc1123Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a response with header values "Wed, 01 Jan 2010 12:34:56 GMT" or "Mon, 01 Jan 0001 00:00:00 GMT". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public ResponseWithHeaders<HeaderResponseDatetimeRfc1123Headers> ResponseDatetimeRfc1123(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseDatetimeRfc1123Request(scenario);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderResponseDatetimeRfc1123Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateParamDurationRequest(string scenario, TimeSpan value)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/duration", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value, "P");
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "P123DT22H14M12.011S". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="value"> Send a post request with header values "P123DT22H14M12.011S". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<Response> ParamDurationAsync(string scenario, TimeSpan value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamDurationRequest(scenario, value);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "P123DT22H14M12.011S". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="value"> Send a post request with header values "P123DT22H14M12.011S". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public Response ParamDuration(string scenario, TimeSpan value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamDurationRequest(scenario, value);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateResponseDurationRequest(string scenario)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/duration", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a response with header values "P123DT22H14M12.011S". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderResponseDurationHeaders>> ResponseDurationAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseDurationRequest(scenario);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderResponseDurationHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a response with header values "P123DT22H14M12.011S". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public ResponseWithHeaders<HeaderResponseDurationHeaders> ResponseDuration(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseDurationRequest(scenario);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderResponseDurationHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateParamByteRequest(string scenario, byte[] value)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/byte", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value, "D");
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "啊齄丂狛狜隣郎隣兀﨩". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="value"> Send a post request with header values "啊齄丂狛狜隣郎隣兀﨩". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> or <paramref name="value"/> is null. </exception>
        public async Task<Response> ParamByteAsync(string scenario, byte[] value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            using var message = CreateParamByteRequest(scenario, value);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "啊齄丂狛狜隣郎隣兀﨩". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="value"> Send a post request with header values "啊齄丂狛狜隣郎隣兀﨩". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> or <paramref name="value"/> is null. </exception>
        public Response ParamByte(string scenario, byte[] value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            using var message = CreateParamByteRequest(scenario, value);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateResponseByteRequest(string scenario)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/byte", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a response with header values "啊齄丂狛狜隣郎隣兀﨩". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderResponseByteHeaders>> ResponseByteAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseByteRequest(scenario);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderResponseByteHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a response with header values "啊齄丂狛狜隣郎隣兀﨩". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public ResponseWithHeaders<HeaderResponseByteHeaders> ResponseByte(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseByteRequest(scenario);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderResponseByteHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateParamEnumRequest(string scenario, GreyscaleColors? value)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/enum", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            if (value != null)
            {
                request.Headers.Add("value", value.Value.ToSerialString());
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "GREY" or "scenario": "null", "value": null. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="value"> Send a post request with header values 'GREY'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<Response> ParamEnumAsync(string scenario, GreyscaleColors? value = null, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamEnumRequest(scenario, value);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "GREY" or "scenario": "null", "value": null. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="value"> Send a post request with header values 'GREY'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public Response ParamEnum(string scenario, GreyscaleColors? value = null, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateParamEnumRequest(scenario, value);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateResponseEnumRequest(string scenario)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/enum", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a response with header values "GREY" or null. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderResponseEnumHeaders>> ResponseEnumAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseEnumRequest(scenario);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderResponseEnumHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a response with header values "GREY" or null. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        public ResponseWithHeaders<HeaderResponseEnumHeaders> ResponseEnum(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var message = CreateResponseEnumRequest(scenario);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderResponseEnumHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCustomRequestIdRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/custom/x-ms-client-request-id/9C4D50EE-2D56-4CD3-8152-34347DC9F2B0", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> CustomRequestIdAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateCustomRequestIdRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response CustomRequestId(CancellationToken cancellationToken = default)
        {
            using var message = CreateCustomRequestIdRequest();
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
