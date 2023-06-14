// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using constants.Models;

namespace constants
{
    internal partial class ContantsRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly bool _headerConstant;
        private readonly int _queryConstant;
        private readonly string _pathConstant;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of ContantsRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="headerConstant"> Constant header property on the client that is a required parameter for operation 'constants_putClientConstants'. </param>
        /// <param name="queryConstant"> Constant query property on the client that is a required parameter for operation 'constants_putClientConstants'. </param>
        /// <param name="pathConstant"> Constant path property on the client that is a required parameter for operation 'constants_putClientConstants'. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="pathConstant"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="pathConstant"/> is an empty string, and was expected to be non-empty. </exception>
        public ContantsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null, bool headerConstant = true, int queryConstant = 100, string pathConstant = "path")
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
            _headerConstant = headerConstant;
            _queryConstant = queryConstant;
            _pathConstant = pathConstant ?? throw new ArgumentNullException(nameof(pathConstant));
        }

        internal HttpMessage CreatePutNoModelAsStringNoRequiredTwoValueNoDefaultRequest(NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum? input)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putNoModelAsStringNoRequiredTwoValueNoDefault", false);
            if (input != null)
            {
                uri.AppendQuery("input", input.Value.ToSerialString(), true);
            }
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutNoModelAsStringNoRequiredTwoValueNoDefaultAsync(NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringNoRequiredTwoValueNoDefaultRequest(input);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNoModelAsStringNoRequiredTwoValueNoDefault(NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringNoRequiredTwoValueNoDefaultRequest(input);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutNoModelAsStringNoRequiredTwoValueDefaultRequest(NoModelAsStringNoRequiredTwoValueDefaultOpEnum? input)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putNoModelAsStringNoRequiredTwoValueDefault", false);
            if (input != null)
            {
                uri.AppendQuery("input", input.Value.ToSerialString(), true);
            }
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringNoRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutNoModelAsStringNoRequiredTwoValueDefaultAsync(NoModelAsStringNoRequiredTwoValueDefaultOpEnum? input = NoModelAsStringNoRequiredTwoValueDefaultOpEnum.Value1, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringNoRequiredTwoValueDefaultRequest(input);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringNoRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNoModelAsStringNoRequiredTwoValueDefault(NoModelAsStringNoRequiredTwoValueDefaultOpEnum? input = NoModelAsStringNoRequiredTwoValueDefaultOpEnum.Value1, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringNoRequiredTwoValueDefaultRequest(input);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutNoModelAsStringNoRequiredOneValueNoDefaultRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putNoModelAsStringNoRequiredOneValueNoDefault", false);
            uri.AppendQuery("input", NoModelAsStringNoRequiredOneValueNoDefaultOpEnum.Value1.ToString(), true);
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutNoModelAsStringNoRequiredOneValueNoDefaultAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringNoRequiredOneValueNoDefaultRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNoModelAsStringNoRequiredOneValueNoDefault(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringNoRequiredOneValueNoDefaultRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutNoModelAsStringNoRequiredOneValueDefaultRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putNoModelAsStringNoRequiredOneValueDefault", false);
            uri.AppendQuery("input", NoModelAsStringNoRequiredOneValueDefaultOpEnum.Value1.ToString(), true);
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutNoModelAsStringNoRequiredOneValueDefaultAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringNoRequiredOneValueDefaultRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNoModelAsStringNoRequiredOneValueDefault(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringNoRequiredOneValueDefaultRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutNoModelAsStringRequiredTwoValueNoDefaultRequest(NoModelAsStringRequiredTwoValueNoDefaultOpEnum input)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putNoModelAsStringRequiredTwoValueNoDefault", false);
            uri.AppendQuery("input", input.ToSerialString(), true);
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutNoModelAsStringRequiredTwoValueNoDefaultAsync(NoModelAsStringRequiredTwoValueNoDefaultOpEnum input, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringRequiredTwoValueNoDefaultRequest(input);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNoModelAsStringRequiredTwoValueNoDefault(NoModelAsStringRequiredTwoValueNoDefaultOpEnum input, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringRequiredTwoValueNoDefaultRequest(input);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutNoModelAsStringRequiredTwoValueDefaultRequest(NoModelAsStringRequiredTwoValueDefaultOpEnum input)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putNoModelAsStringRequiredTwoValueDefault", false);
            uri.AppendQuery("input", input.ToSerialString(), true);
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutNoModelAsStringRequiredTwoValueDefaultAsync(NoModelAsStringRequiredTwoValueDefaultOpEnum input = NoModelAsStringRequiredTwoValueDefaultOpEnum.Value1, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringRequiredTwoValueDefaultRequest(input);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNoModelAsStringRequiredTwoValueDefault(NoModelAsStringRequiredTwoValueDefaultOpEnum input = NoModelAsStringRequiredTwoValueDefaultOpEnum.Value1, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringRequiredTwoValueDefaultRequest(input);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutNoModelAsStringRequiredOneValueNoDefaultRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putNoModelAsStringRequiredOneValueNoDefault", false);
            uri.AppendQuery("input", "value1", true);
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutNoModelAsStringRequiredOneValueNoDefaultAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringRequiredOneValueNoDefaultRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNoModelAsStringRequiredOneValueNoDefault(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringRequiredOneValueNoDefaultRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutNoModelAsStringRequiredOneValueDefaultRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putNoModelAsStringRequiredOneValueDefault", false);
            uri.AppendQuery("input", "value1", true);
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutNoModelAsStringRequiredOneValueDefaultAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringRequiredOneValueDefaultRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNoModelAsStringRequiredOneValueDefault(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNoModelAsStringRequiredOneValueDefaultRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutModelAsStringNoRequiredTwoValueNoDefaultRequest(ModelAsStringNoRequiredTwoValueNoDefaultOpEnum? input)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putModelAsStringNoRequiredTwoValueNoDefault", false);
            if (input != null)
            {
                uri.AppendQuery("input", input.Value.ToString(), true);
            }
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutModelAsStringNoRequiredTwoValueNoDefaultAsync(ModelAsStringNoRequiredTwoValueNoDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutModelAsStringNoRequiredTwoValueNoDefaultRequest(input);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutModelAsStringNoRequiredTwoValueNoDefault(ModelAsStringNoRequiredTwoValueNoDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutModelAsStringNoRequiredTwoValueNoDefaultRequest(input);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutModelAsStringNoRequiredTwoValueDefaultRequest(ModelAsStringNoRequiredTwoValueDefaultOpEnum? input)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putModelAsStringNoRequiredTwoValueDefault", false);
            if (input != null)
            {
                uri.AppendQuery("input", input.Value.ToString(), true);
            }
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutModelAsStringNoRequiredTwoValueDefaultAsync(ModelAsStringNoRequiredTwoValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            input ??= ModelAsStringNoRequiredTwoValueDefaultOpEnum.Value1;

            using var message = CreatePutModelAsStringNoRequiredTwoValueDefaultRequest(input);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutModelAsStringNoRequiredTwoValueDefault(ModelAsStringNoRequiredTwoValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            input ??= ModelAsStringNoRequiredTwoValueDefaultOpEnum.Value1;

            using var message = CreatePutModelAsStringNoRequiredTwoValueDefaultRequest(input);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutModelAsStringNoRequiredOneValueNoDefaultRequest(ModelAsStringNoRequiredOneValueNoDefaultOpEnum? input)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putModelAsStringNoRequiredOneValueNoDefault", false);
            if (input != null)
            {
                uri.AppendQuery("input", input.Value.ToString(), true);
            }
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredOneValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutModelAsStringNoRequiredOneValueNoDefaultAsync(ModelAsStringNoRequiredOneValueNoDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutModelAsStringNoRequiredOneValueNoDefaultRequest(input);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredOneValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutModelAsStringNoRequiredOneValueNoDefault(ModelAsStringNoRequiredOneValueNoDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutModelAsStringNoRequiredOneValueNoDefaultRequest(input);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutModelAsStringNoRequiredOneValueDefaultRequest(ModelAsStringNoRequiredOneValueDefaultOpEnum? input)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putModelAsStringNoRequiredOneValueDefault", false);
            if (input != null)
            {
                uri.AppendQuery("input", input.Value.ToString(), true);
            }
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredOneValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutModelAsStringNoRequiredOneValueDefaultAsync(ModelAsStringNoRequiredOneValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            input ??= ModelAsStringNoRequiredOneValueDefaultOpEnum.Value1;

            using var message = CreatePutModelAsStringNoRequiredOneValueDefaultRequest(input);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredOneValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutModelAsStringNoRequiredOneValueDefault(ModelAsStringNoRequiredOneValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            input ??= ModelAsStringNoRequiredOneValueDefaultOpEnum.Value1;

            using var message = CreatePutModelAsStringNoRequiredOneValueDefaultRequest(input);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutModelAsStringRequiredTwoValueNoDefaultRequest(ModelAsStringRequiredTwoValueNoDefaultOpEnum input)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putModelAsStringRequiredTwoValueNoDefault", false);
            uri.AppendQuery("input", input.ToString(), true);
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutModelAsStringRequiredTwoValueNoDefaultAsync(ModelAsStringRequiredTwoValueNoDefaultOpEnum input, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutModelAsStringRequiredTwoValueNoDefaultRequest(input);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutModelAsStringRequiredTwoValueNoDefault(ModelAsStringRequiredTwoValueNoDefaultOpEnum input, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutModelAsStringRequiredTwoValueNoDefaultRequest(input);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutModelAsStringRequiredTwoValueDefaultRequest(ModelAsStringRequiredTwoValueDefaultOpEnum? input)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putModelAsStringRequiredTwoValueDefault", false);
            if (input != null)
            {
                uri.AppendQuery("input", input.Value.ToString(), true);
            }
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutModelAsStringRequiredTwoValueDefaultAsync(ModelAsStringRequiredTwoValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            input ??= ModelAsStringRequiredTwoValueDefaultOpEnum.Value1;

            using var message = CreatePutModelAsStringRequiredTwoValueDefaultRequest(input);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutModelAsStringRequiredTwoValueDefault(ModelAsStringRequiredTwoValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            input ??= ModelAsStringRequiredTwoValueDefaultOpEnum.Value1;

            using var message = CreatePutModelAsStringRequiredTwoValueDefaultRequest(input);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutModelAsStringRequiredOneValueNoDefaultRequest(ModelAsStringRequiredOneValueNoDefaultOpEnum input)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putModelAsStringRequiredOneValueNoDefault", false);
            uri.AppendQuery("input", input.ToString(), true);
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredOneValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutModelAsStringRequiredOneValueNoDefaultAsync(ModelAsStringRequiredOneValueNoDefaultOpEnum input, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutModelAsStringRequiredOneValueNoDefaultRequest(input);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredOneValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutModelAsStringRequiredOneValueNoDefault(ModelAsStringRequiredOneValueNoDefaultOpEnum input, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutModelAsStringRequiredOneValueNoDefaultRequest(input);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutModelAsStringRequiredOneValueDefaultRequest(ModelAsStringRequiredOneValueDefaultOpEnum? input)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/putModelAsStringRequiredOneValueDefault", false);
            if (input != null)
            {
                uri.AppendQuery("input", input.Value.ToString(), true);
            }
            request.Uri = uri;
            return message;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredOneValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutModelAsStringRequiredOneValueDefaultAsync(ModelAsStringRequiredOneValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            input ??= ModelAsStringRequiredOneValueDefaultOpEnum.Value1;

            using var message = CreatePutModelAsStringRequiredOneValueDefaultRequest(input);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredOneValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutModelAsStringRequiredOneValueDefault(ModelAsStringRequiredOneValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            input ??= ModelAsStringRequiredOneValueDefaultOpEnum.Value1;

            using var message = CreatePutModelAsStringRequiredOneValueDefaultRequest(input);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutClientConstantsRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/constants/clientConstants/", false);
            uri.AppendPath(_pathConstant, true);
            uri.AppendQuery("query-constant", _queryConstant, true);
            request.Uri = uri;
            request.Headers.Add("header-constant", _headerConstant);
            return message;
        }

        /// <summary> Pass constants from the client to this function. Will pass in constant path, query, and header parameters. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutClientConstantsAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutClientConstantsRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Pass constants from the client to this function. Will pass in constant path, query, and header parameters. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutClientConstants(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutClientConstantsRequest();
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
