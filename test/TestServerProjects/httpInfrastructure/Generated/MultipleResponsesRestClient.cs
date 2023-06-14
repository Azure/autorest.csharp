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
using httpInfrastructure.Models;

namespace httpInfrastructure
{
    internal partial class MultipleResponsesRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of MultipleResponsesRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public MultipleResponsesRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateGet200Model204NoModelDefaultError200ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/200/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<MyException>> Get200Model204NoModelDefaultError200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model204NoModelDefaultError200ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((MyException)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError200Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model204NoModelDefaultError200ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((MyException)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200Model204NoModelDefaultError204ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/204/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<MyException>> Get200Model204NoModelDefaultError204ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model204NoModelDefaultError204ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((MyException)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError204Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model204NoModelDefaultError204ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((MyException)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200Model204NoModelDefaultError201InvalidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/201/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 201 response with valid payload: {'statusCode': '201'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<MyException>> Get200Model204NoModelDefaultError201InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model204NoModelDefaultError201InvalidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((MyException)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 201 response with valid payload: {'statusCode': '201'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError201Invalid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model204NoModelDefaultError201InvalidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((MyException)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200Model204NoModelDefaultError202NoneRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/202/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 202 response with no payload:. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<MyException>> Get200Model204NoModelDefaultError202NoneAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model204NoModelDefaultError202NoneRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((MyException)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 202 response with no payload:. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError202None(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model204NoModelDefaultError202NoneRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((MyException)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200Model204NoModelDefaultError400ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/400/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 400 response with valid error payload: {'status': 400, 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<MyException>> Get200Model204NoModelDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model204NoModelDefaultError400ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((MyException)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 400 response with valid error payload: {'status': 400, 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model204NoModelDefaultError400ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((MyException)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200Model201ModelDefaultError200ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/201/B/default/Error/response/200/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<object>> Get200Model201ModelDefaultError200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model201ModelDefaultError200ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 201:
                    {
                        B value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = B.DeserializeB(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<object> Get200Model201ModelDefaultError200Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model201ModelDefaultError200ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 201:
                    {
                        B value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = B.DeserializeB(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200Model201ModelDefaultError201ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/201/B/default/Error/response/201/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 201 response with valid payload: {'statusCode': '201', 'textStatusCode': 'Created'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<object>> Get200Model201ModelDefaultError201ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model201ModelDefaultError201ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 201:
                    {
                        B value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = B.DeserializeB(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 201 response with valid payload: {'statusCode': '201', 'textStatusCode': 'Created'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<object> Get200Model201ModelDefaultError201Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model201ModelDefaultError201ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 201:
                    {
                        B value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = B.DeserializeB(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200Model201ModelDefaultError400ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/201/B/default/Error/response/400/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<object>> Get200Model201ModelDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model201ModelDefaultError400ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 201:
                    {
                        B value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = B.DeserializeB(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<object> Get200Model201ModelDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Model201ModelDefaultError400ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 201:
                    {
                        B value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = B.DeserializeB(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200ModelA201ModelC404ModelDDefaultError200ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/201/C/404/D/default/Error/response/200/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<object>> Get200ModelA201ModelC404ModelDDefaultError200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA201ModelC404ModelDDefaultError200ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 201:
                    {
                        C value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = C.DeserializeC(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 404:
                    {
                        D value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = D.DeserializeD(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<object> Get200ModelA201ModelC404ModelDDefaultError200Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA201ModelC404ModelDDefaultError200ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 201:
                    {
                        C value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = C.DeserializeC(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 404:
                    {
                        D value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = D.DeserializeD(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200ModelA201ModelC404ModelDDefaultError201ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/201/C/404/D/default/Error/response/201/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 200 response with valid payload: {'httpCode': '201'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<object>> Get200ModelA201ModelC404ModelDDefaultError201ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA201ModelC404ModelDDefaultError201ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 201:
                    {
                        C value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = C.DeserializeC(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 404:
                    {
                        D value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = D.DeserializeD(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 200 response with valid payload: {'httpCode': '201'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<object> Get200ModelA201ModelC404ModelDDefaultError201Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA201ModelC404ModelDDefaultError201ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 201:
                    {
                        C value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = C.DeserializeC(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 404:
                    {
                        D value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = D.DeserializeD(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200ModelA201ModelC404ModelDDefaultError404ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/201/C/404/D/default/Error/response/404/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 200 response with valid payload: {'httpStatusCode': '404'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<object>> Get200ModelA201ModelC404ModelDDefaultError404ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA201ModelC404ModelDDefaultError404ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 201:
                    {
                        C value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = C.DeserializeC(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 404:
                    {
                        D value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = D.DeserializeD(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 200 response with valid payload: {'httpStatusCode': '404'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<object> Get200ModelA201ModelC404ModelDDefaultError404Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA201ModelC404ModelDDefaultError404ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 201:
                    {
                        C value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = C.DeserializeC(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 404:
                    {
                        D value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = D.DeserializeD(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200ModelA201ModelC404ModelDDefaultError400ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/201/C/404/D/default/Error/response/400/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<object>> Get200ModelA201ModelC404ModelDDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA201ModelC404ModelDDefaultError400ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 201:
                    {
                        C value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = C.DeserializeC(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 404:
                    {
                        D value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = D.DeserializeD(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<object> Get200ModelA201ModelC404ModelDDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA201ModelC404ModelDDefaultError400ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 201:
                    {
                        C value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = C.DeserializeC(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                case 404:
                    {
                        D value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = D.DeserializeD(document.RootElement);
                        return Response.FromValue<object>(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet202None204NoneDefaultError202NoneRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/202/none/204/none/default/Error/response/202/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 202 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Get202None204NoneDefaultError202NoneAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet202None204NoneDefaultError202NoneRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 202 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultError202None(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet202None204NoneDefaultError202NoneRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet202None204NoneDefaultError204NoneRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/202/none/204/none/default/Error/response/204/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Get202None204NoneDefaultError204NoneAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet202None204NoneDefaultError204NoneRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultError204None(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet202None204NoneDefaultError204NoneRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet202None204NoneDefaultError400ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/202/none/204/none/default/Error/response/400/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Get202None204NoneDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet202None204NoneDefaultError400ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet202None204NoneDefaultError400ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet202None204NoneDefaultNone202InvalidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/202/none/204/none/default/none/response/202/invalid", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Send a 202 response with an unexpected payload {'property': 'value'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Get202None204NoneDefaultNone202InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet202None204NoneDefaultNone202InvalidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 202 response with an unexpected payload {'property': 'value'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultNone202Invalid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet202None204NoneDefaultNone202InvalidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet202None204NoneDefaultNone204NoneRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/202/none/204/none/default/none/response/204/none", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Get202None204NoneDefaultNone204NoneAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet202None204NoneDefaultNone204NoneRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultNone204None(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet202None204NoneDefaultNone204NoneRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet202None204NoneDefaultNone400NoneRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/202/none/204/none/default/none/response/400/none", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Get202None204NoneDefaultNone400NoneAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet202None204NoneDefaultNone400NoneRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultNone400None(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet202None204NoneDefaultNone400NoneRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet202None204NoneDefaultNone400InvalidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/202/none/204/none/default/none/response/400/invalid", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Send a 400 response with an unexpected payload {'property': 'value'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Get202None204NoneDefaultNone400InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet202None204NoneDefaultNone400InvalidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 400 response with an unexpected payload {'property': 'value'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultNone400Invalid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet202None204NoneDefaultNone400InvalidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDefaultModelA200ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/A/response/200/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<MyException>> GetDefaultModelA200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultModelA200ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> GetDefaultModelA200Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultModelA200ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDefaultModelA200NoneRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/A/response/200/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<MyException>> GetDefaultModelA200NoneAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultModelA200NoneRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> GetDefaultModelA200None(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultModelA200NoneRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDefaultModelA400ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/A/response/400/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 400 response with valid payload: {'statusCode': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetDefaultModelA400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultModelA400ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 400 response with valid payload: {'statusCode': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultModelA400Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultModelA400ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDefaultModelA400NoneRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/A/response/400/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetDefaultModelA400NoneAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultModelA400NoneRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultModelA400None(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultModelA400NoneRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDefaultNone200InvalidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/none/response/200/invalid", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Send a 200 response with invalid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetDefaultNone200InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultNone200InvalidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 200 response with invalid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultNone200Invalid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultNone200InvalidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDefaultNone200NoneRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/none/response/200/none", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetDefaultNone200NoneAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultNone200NoneRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultNone200None(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultNone200NoneRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDefaultNone400InvalidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/none/response/400/invalid", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Send a 400 response with valid payload: {'statusCode': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetDefaultNone400InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultNone400InvalidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 400 response with valid payload: {'statusCode': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultNone400Invalid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultNone400InvalidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDefaultNone400NoneRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/none/response/400/none", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetDefaultNone400NoneAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultNone400NoneRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultNone400None(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDefaultNone400NoneRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200ModelA200NoneRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/response/200/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 200 response with no payload, when a payload is expected - client should return a null object of thde type for model A. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<MyException>> Get200ModelA200NoneAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA200NoneRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 200 response with no payload, when a payload is expected - client should return a null object of thde type for model A. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA200None(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA200NoneRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200ModelA200ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/response/200/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 200 response with payload {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<MyException>> Get200ModelA200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA200ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 200 response with payload {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA200Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA200ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200ModelA200InvalidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/response/200/invalid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 200 response with invalid payload {'statusCodeInvalid': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<MyException>> Get200ModelA200InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA200InvalidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 200 response with invalid payload {'statusCodeInvalid': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA200Invalid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA200InvalidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200ModelA400NoneRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/response/400/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 400 response with no payload client should treat as an http error with no error model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<MyException>> Get200ModelA400NoneAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA400NoneRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 400 response with no payload client should treat as an http error with no error model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA400None(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA400NoneRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200ModelA400ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/response/400/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 200 response with payload {'statusCode': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<MyException>> Get200ModelA400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA400ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 200 response with payload {'statusCode': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA400Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA400ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200ModelA400InvalidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/response/400/invalid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 200 response with invalid payload {'statusCodeInvalid': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<MyException>> Get200ModelA400InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA400InvalidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 200 response with invalid payload {'statusCodeInvalid': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA400Invalid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA400InvalidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200ModelA202ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/response/202/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send a 202 response with payload {'statusCode': '202'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<MyException>> Get200ModelA202ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA202ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send a 202 response with payload {'statusCode': '202'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA202Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200ModelA202ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MyException value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MyException.DeserializeMyException(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
