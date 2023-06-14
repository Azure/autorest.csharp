// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace azure_special_properties
{
    internal partial class ApiVersionLocalRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of ApiVersionLocalRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public ApiVersionLocalRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateGetMethodLocalValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/apiVersion/method/string/none/query/local/2.0", false);
            uri.AppendQuery("api-version", "2.0", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = '2.0' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetMethodLocalValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMethodLocalValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = '2.0' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetMethodLocalValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMethodLocalValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMethodLocalNullRequest(string apiVersion)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/apiVersion/method/string/none/query/local/null", false);
            if (apiVersion != null)
            {
                uri.AppendQuery("api-version", apiVersion, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = null to succeed. </summary>
        /// <param name="apiVersion"> This should appear as a method parameter, use value null, this should result in no serialized parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetMethodLocalNullAsync(string apiVersion = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMethodLocalNullRequest(apiVersion);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = null to succeed. </summary>
        /// <param name="apiVersion"> This should appear as a method parameter, use value null, this should result in no serialized parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetMethodLocalNull(string apiVersion = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMethodLocalNullRequest(apiVersion);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetPathLocalValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/apiVersion/path/string/none/query/local/2.0", false);
            uri.AppendQuery("api-version", "2.0", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = '2.0' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetPathLocalValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetPathLocalValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = '2.0' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetPathLocalValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetPathLocalValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetSwaggerLocalValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/apiVersion/swagger/string/none/query/local/2.0", false);
            uri.AppendQuery("api-version", "2.0", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = '2.0' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetSwaggerLocalValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSwaggerLocalValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = '2.0' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetSwaggerLocalValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSwaggerLocalValidRequest();
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
