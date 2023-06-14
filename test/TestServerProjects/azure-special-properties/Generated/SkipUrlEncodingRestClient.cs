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
    internal partial class SkipUrlEncodingRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of SkipUrlEncodingRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public SkipUrlEncodingRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateGetMethodPathValidRequest(string unencodedPathParam)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/skipUrlEncoding/method/path/valid/", false);
            uri.AppendPath(unencodedPathParam, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get method with unencoded path parameter with value 'path1/path2/path3'. </summary>
        /// <param name="unencodedPathParam"> Unencoded path parameter with value 'path1/path2/path3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="unencodedPathParam"/> is null. </exception>
        public async Task<Response> GetMethodPathValidAsync(string unencodedPathParam, CancellationToken cancellationToken = default)
        {
            if (unencodedPathParam == null)
            {
                throw new ArgumentNullException(nameof(unencodedPathParam));
            }

            using var message = CreateGetMethodPathValidRequest(unencodedPathParam);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get method with unencoded path parameter with value 'path1/path2/path3'. </summary>
        /// <param name="unencodedPathParam"> Unencoded path parameter with value 'path1/path2/path3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="unencodedPathParam"/> is null. </exception>
        public Response GetMethodPathValid(string unencodedPathParam, CancellationToken cancellationToken = default)
        {
            if (unencodedPathParam == null)
            {
                throw new ArgumentNullException(nameof(unencodedPathParam));
            }

            using var message = CreateGetMethodPathValidRequest(unencodedPathParam);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetPathValidRequest(string unencodedPathParam)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/skipUrlEncoding/path/path/valid/", false);
            uri.AppendPath(unencodedPathParam, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get method with unencoded path parameter with value 'path1/path2/path3'. </summary>
        /// <param name="unencodedPathParam"> Unencoded path parameter with value 'path1/path2/path3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="unencodedPathParam"/> is null. </exception>
        public async Task<Response> GetPathValidAsync(string unencodedPathParam, CancellationToken cancellationToken = default)
        {
            if (unencodedPathParam == null)
            {
                throw new ArgumentNullException(nameof(unencodedPathParam));
            }

            using var message = CreateGetPathValidRequest(unencodedPathParam);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get method with unencoded path parameter with value 'path1/path2/path3'. </summary>
        /// <param name="unencodedPathParam"> Unencoded path parameter with value 'path1/path2/path3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="unencodedPathParam"/> is null. </exception>
        public Response GetPathValid(string unencodedPathParam, CancellationToken cancellationToken = default)
        {
            if (unencodedPathParam == null)
            {
                throw new ArgumentNullException(nameof(unencodedPathParam));
            }

            using var message = CreateGetPathValidRequest(unencodedPathParam);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetSwaggerPathValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/skipUrlEncoding/swagger/path/valid/", false);
            uri.AppendPath("path1/path2/path3", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get method with unencoded path parameter with value 'path1/path2/path3'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetSwaggerPathValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSwaggerPathValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get method with unencoded path parameter with value 'path1/path2/path3'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetSwaggerPathValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSwaggerPathValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMethodQueryValidRequest(string q1)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/skipUrlEncoding/method/query/valid", false);
            uri.AppendQuery("q1", q1, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get method with unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </summary>
        /// <param name="q1"> Unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="q1"/> is null. </exception>
        public async Task<Response> GetMethodQueryValidAsync(string q1, CancellationToken cancellationToken = default)
        {
            if (q1 == null)
            {
                throw new ArgumentNullException(nameof(q1));
            }

            using var message = CreateGetMethodQueryValidRequest(q1);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get method with unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </summary>
        /// <param name="q1"> Unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="q1"/> is null. </exception>
        public Response GetMethodQueryValid(string q1, CancellationToken cancellationToken = default)
        {
            if (q1 == null)
            {
                throw new ArgumentNullException(nameof(q1));
            }

            using var message = CreateGetMethodQueryValidRequest(q1);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMethodQueryNullRequest(string q1)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/skipUrlEncoding/method/query/null", false);
            if (q1 != null)
            {
                uri.AppendQuery("q1", q1, false);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get method with unencoded query parameter with value null. </summary>
        /// <param name="q1"> Unencoded query parameter with value null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetMethodQueryNullAsync(string q1 = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMethodQueryNullRequest(q1);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get method with unencoded query parameter with value null. </summary>
        /// <param name="q1"> Unencoded query parameter with value null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetMethodQueryNull(string q1 = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMethodQueryNullRequest(q1);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetPathQueryValidRequest(string q1)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/skipUrlEncoding/path/query/valid", false);
            uri.AppendQuery("q1", q1, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get method with unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </summary>
        /// <param name="q1"> Unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="q1"/> is null. </exception>
        public async Task<Response> GetPathQueryValidAsync(string q1, CancellationToken cancellationToken = default)
        {
            if (q1 == null)
            {
                throw new ArgumentNullException(nameof(q1));
            }

            using var message = CreateGetPathQueryValidRequest(q1);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get method with unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </summary>
        /// <param name="q1"> Unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="q1"/> is null. </exception>
        public Response GetPathQueryValid(string q1, CancellationToken cancellationToken = default)
        {
            if (q1 == null)
            {
                throw new ArgumentNullException(nameof(q1));
            }

            using var message = CreateGetPathQueryValidRequest(q1);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetSwaggerQueryValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/skipUrlEncoding/swagger/query/valid", false);
            uri.AppendQuery("q1", "value1&q2=value2&q3=value3", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get method with unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetSwaggerQueryValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSwaggerQueryValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get method with unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetSwaggerQueryValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSwaggerQueryValidRequest();
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
