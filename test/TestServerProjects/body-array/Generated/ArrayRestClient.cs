// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using body_array.Models;

namespace body_array
{
    internal partial class ArrayRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of ArrayRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public ArrayRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateGetNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/null", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null array value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<int>>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<int> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<int> array = new List<int>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt32());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null array value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<int>> GetNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<int> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<int> array = new List<int>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt32());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetInvalidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/invalid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get invalid array [1, 2, 3. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<int>>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetInvalidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<int> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<int> array = new List<int>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt32());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get invalid array [1, 2, 3. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<int>> GetInvalid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetInvalidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<int> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<int> array = new List<int>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt32());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetEmptyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/empty", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get empty array value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<int>>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetEmptyRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<int> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<int> array = new List<int>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt32());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get empty array value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<int>> GetEmpty(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetEmptyRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<int> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<int> array = new List<int>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt32());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutEmptyRequest(IEnumerable<string> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/empty", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Set array value empty []. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutEmptyAsync(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutEmptyRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set array value empty []. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutEmpty(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutEmptyRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetBooleanTfftRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/boolean/tfft", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get boolean array value [true, false, false, true]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<bool>>> GetBooleanTfftAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBooleanTfftRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<bool> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<bool> array = new List<bool>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetBoolean());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get boolean array value [true, false, false, true]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<bool>> GetBooleanTfft(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBooleanTfftRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<bool> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<bool> array = new List<bool>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetBoolean());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutBooleanTfftRequest(IEnumerable<bool> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/boolean/tfft", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteBooleanValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Set array value empty [true, false, false, true]. </summary>
        /// <param name="arrayBody"> The ArrayOfBoolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutBooleanTfftAsync(IEnumerable<bool> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutBooleanTfftRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set array value empty [true, false, false, true]. </summary>
        /// <param name="arrayBody"> The ArrayOfBoolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutBooleanTfft(IEnumerable<bool> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutBooleanTfftRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetBooleanInvalidNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/boolean/true.null.false", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get boolean array value [true, null, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<bool>>> GetBooleanInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBooleanInvalidNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<bool> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<bool> array = new List<bool>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetBoolean());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get boolean array value [true, null, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<bool>> GetBooleanInvalidNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBooleanInvalidNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<bool> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<bool> array = new List<bool>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetBoolean());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetBooleanInvalidStringRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/boolean/true.boolean.false", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get boolean array value [true, 'boolean', false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<bool>>> GetBooleanInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBooleanInvalidStringRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<bool> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<bool> array = new List<bool>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetBoolean());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get boolean array value [true, 'boolean', false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<bool>> GetBooleanInvalidString(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBooleanInvalidStringRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<bool> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<bool> array = new List<bool>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetBoolean());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetIntegerValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/integer/1.-1.3.300", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<int>>> GetIntegerValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetIntegerValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<int> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<int> array = new List<int>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt32());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<int>> GetIntegerValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetIntegerValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<int> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<int> array = new List<int>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt32());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutIntegerValidRequest(IEnumerable<int> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/integer/1.-1.3.300", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteNumberValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutIntegerValidAsync(IEnumerable<int> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutIntegerValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutIntegerValid(IEnumerable<int> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutIntegerValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetIntInvalidNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/integer/1.null.zero", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get integer array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<int>>> GetIntInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetIntInvalidNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<int> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<int> array = new List<int>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt32());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get integer array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<int>> GetIntInvalidNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetIntInvalidNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<int> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<int> array = new List<int>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt32());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetIntInvalidStringRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/integer/1.integer.0", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get integer array value [1, 'integer', 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<int>>> GetIntInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetIntInvalidStringRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<int> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<int> array = new List<int>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt32());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get integer array value [1, 'integer', 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<int>> GetIntInvalidString(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetIntInvalidStringRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<int> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<int> array = new List<int>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt32());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetLongValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/long/1.-1.3.300", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<long>>> GetLongValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLongValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<long> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<long> array = new List<long>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt64());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<long>> GetLongValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLongValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<long> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<long> array = new List<long>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt64());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutLongValidRequest(IEnumerable<long> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/long/1.-1.3.300", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteNumberValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutLongValidAsync(IEnumerable<long> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutLongValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutLongValid(IEnumerable<long> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutLongValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetLongInvalidNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/long/1.null.zero", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get long array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<long>>> GetLongInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLongInvalidNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<long> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<long> array = new List<long>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt64());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get long array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<long>> GetLongInvalidNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLongInvalidNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<long> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<long> array = new List<long>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt64());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetLongInvalidStringRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/long/1.integer.0", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get long array value [1, 'integer', 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<long>>> GetLongInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLongInvalidStringRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<long> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<long> array = new List<long>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt64());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get long array value [1, 'integer', 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<long>> GetLongInvalidString(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLongInvalidStringRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<long> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<long> array = new List<long>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetInt64());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetFloatValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/float/0--0.01-1.2e20", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<float>>> GetFloatValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetFloatValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<float> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<float> array = new List<float>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetSingle());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<float>> GetFloatValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetFloatValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<float> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<float> array = new List<float>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetSingle());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutFloatValidRequest(IEnumerable<float> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/float/0--0.01-1.2e20", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteNumberValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutFloatValidAsync(IEnumerable<float> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutFloatValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutFloatValid(IEnumerable<float> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutFloatValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetFloatInvalidNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/float/0.0-null-1.2e20", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<float>>> GetFloatInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetFloatInvalidNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<float> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<float> array = new List<float>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetSingle());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<float>> GetFloatInvalidNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetFloatInvalidNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<float> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<float> array = new List<float>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetSingle());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetFloatInvalidStringRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/float/1.number.0", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get boolean array value [1.0, 'number', 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<float>>> GetFloatInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetFloatInvalidStringRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<float> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<float> array = new List<float>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetSingle());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get boolean array value [1.0, 'number', 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<float>> GetFloatInvalidString(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetFloatInvalidStringRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<float> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<float> array = new List<float>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetSingle());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDoubleValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/double/0--0.01-1.2e20", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<double>>> GetDoubleValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDoubleValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<double> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<double> array = new List<double>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDouble());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<double>> GetDoubleValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDoubleValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<double> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<double> array = new List<double>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDouble());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutDoubleValidRequest(IEnumerable<double> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/double/0--0.01-1.2e20", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteNumberValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutDoubleValidAsync(IEnumerable<double> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutDoubleValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutDoubleValid(IEnumerable<double> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutDoubleValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDoubleInvalidNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/double/0.0-null-1.2e20", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<double>>> GetDoubleInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDoubleInvalidNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<double> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<double> array = new List<double>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDouble());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<double>> GetDoubleInvalidNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDoubleInvalidNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<double> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<double> array = new List<double>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDouble());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDoubleInvalidStringRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/double/1.number.0", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get boolean array value [1.0, 'number', 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<double>>> GetDoubleInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDoubleInvalidStringRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<double> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<double> array = new List<double>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDouble());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get boolean array value [1.0, 'number', 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<double>> GetDoubleInvalidString(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDoubleInvalidStringRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<double> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<double> array = new List<double>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDouble());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetStringValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/string/foo1.foo2.foo3", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get string array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<string>>> GetStringValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetStringValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<string> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<string> array = new List<string>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetString());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get string array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<string>> GetStringValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetStringValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<string> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<string> array = new List<string>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetString());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutStringValidRequest(IEnumerable<string> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/string/foo1.foo2.foo3", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Set array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="arrayBody"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutStringValidAsync(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutStringValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="arrayBody"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutStringValid(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutStringValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetEnumValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/enum/foo1.foo2.foo3", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get enum array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<FooEnum>>> GetEnumValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetEnumValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<FooEnum> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<FooEnum> array = new List<FooEnum>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetString().ToFooEnum());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get enum array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<FooEnum>> GetEnumValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetEnumValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<FooEnum> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<FooEnum> array = new List<FooEnum>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetString().ToFooEnum());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutEnumValidRequest(IEnumerable<FooEnum> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/enum/foo1.foo2.foo3", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item.ToSerialString());
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Set array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="arrayBody"> The ArrayOfFooEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutEnumValidAsync(IEnumerable<FooEnum> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutEnumValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="arrayBody"> The ArrayOfFooEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutEnumValid(IEnumerable<FooEnum> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutEnumValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetStringEnumValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/string-enum/foo1.foo2.foo3", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get enum array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<Enum0>>> GetStringEnumValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetStringEnumValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Enum0> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<Enum0> array = new List<Enum0>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(new Enum0(item.GetString()));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get enum array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<Enum0>> GetStringEnumValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetStringEnumValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Enum0> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<Enum0> array = new List<Enum0>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(new Enum0(item.GetString()));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutStringEnumValidRequest(IEnumerable<Enum1> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/string-enum/foo1.foo2.foo3", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item.ToString());
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Set array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="arrayBody"> The ArrayOfpathsBqqpc7ArrayPrimStringEnumFoo1Foo2Foo3PutRequestbodyContentApplicationJsonSchemaItems to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutStringEnumValidAsync(IEnumerable<Enum1> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutStringEnumValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="arrayBody"> The ArrayOfpathsBqqpc7ArrayPrimStringEnumFoo1Foo2Foo3PutRequestbodyContentApplicationJsonSchemaItems to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutStringEnumValid(IEnumerable<Enum1> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutStringEnumValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetStringWithNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/string/foo.null.foo2", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get string array value ['foo', null, 'foo2']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<string>>> GetStringWithNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetStringWithNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<string> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<string> array = new List<string>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetString());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get string array value ['foo', null, 'foo2']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<string>> GetStringWithNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetStringWithNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<string> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<string> array = new List<string>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetString());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetStringWithInvalidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/string/foo.123.foo2", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get string array value ['foo', 123, 'foo2']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<string>>> GetStringWithInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetStringWithInvalidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<string> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<string> array = new List<string>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetString());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get string array value ['foo', 123, 'foo2']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<string>> GetStringWithInvalid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetStringWithInvalidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<string> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<string> array = new List<string>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetString());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetUuidValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/uuid/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get uuid array value ['6dcc7237-45fe-45c4-8a6b-3a8a3f625652', 'd1399005-30f7-40d6-8da6-dd7c89ad34db', 'f42f6aa1-a5bc-4ddf-907e-5f915de43205']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<Guid>>> GetUuidValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUuidValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Guid> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<Guid> array = new List<Guid>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetGuid());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get uuid array value ['6dcc7237-45fe-45c4-8a6b-3a8a3f625652', 'd1399005-30f7-40d6-8da6-dd7c89ad34db', 'f42f6aa1-a5bc-4ddf-907e-5f915de43205']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<Guid>> GetUuidValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUuidValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Guid> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<Guid> array = new List<Guid>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetGuid());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutUuidValidRequest(IEnumerable<Guid> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/uuid/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Set array value  ['6dcc7237-45fe-45c4-8a6b-3a8a3f625652', 'd1399005-30f7-40d6-8da6-dd7c89ad34db', 'f42f6aa1-a5bc-4ddf-907e-5f915de43205']. </summary>
        /// <param name="arrayBody"> The ArrayOfUuid to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutUuidValidAsync(IEnumerable<Guid> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutUuidValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set array value  ['6dcc7237-45fe-45c4-8a6b-3a8a3f625652', 'd1399005-30f7-40d6-8da6-dd7c89ad34db', 'f42f6aa1-a5bc-4ddf-907e-5f915de43205']. </summary>
        /// <param name="arrayBody"> The ArrayOfUuid to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutUuidValid(IEnumerable<Guid> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutUuidValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetUuidInvalidCharsRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/uuid/invalidchars", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get uuid array value ['6dcc7237-45fe-45c4-8a6b-3a8a3f625652', 'foo']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<Guid>>> GetUuidInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUuidInvalidCharsRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Guid> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<Guid> array = new List<Guid>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetGuid());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get uuid array value ['6dcc7237-45fe-45c4-8a6b-3a8a3f625652', 'foo']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<Guid>> GetUuidInvalidChars(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUuidInvalidCharsRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Guid> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<Guid> array = new List<Guid>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetGuid());
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDateValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/date/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get integer array value ['2000-12-01', '1980-01-02', '1492-10-12']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<DateTimeOffset>>> GetDateValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDateValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<DateTimeOffset> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<DateTimeOffset> array = new List<DateTimeOffset>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDateTimeOffset("D"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get integer array value ['2000-12-01', '1980-01-02', '1492-10-12']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<DateTimeOffset>> GetDateValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDateValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<DateTimeOffset> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<DateTimeOffset> array = new List<DateTimeOffset>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDateTimeOffset("D"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutDateValidRequest(IEnumerable<DateTimeOffset> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/date/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item, "D");
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Set array value  ['2000-12-01', '1980-01-02', '1492-10-12']. </summary>
        /// <param name="arrayBody"> The ArrayOfDate to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutDateValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutDateValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set array value  ['2000-12-01', '1980-01-02', '1492-10-12']. </summary>
        /// <param name="arrayBody"> The ArrayOfDate to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutDateValid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutDateValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDateInvalidNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/date/invalidnull", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get date array value ['2012-01-01', null, '1776-07-04']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<DateTimeOffset>>> GetDateInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDateInvalidNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<DateTimeOffset> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<DateTimeOffset> array = new List<DateTimeOffset>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDateTimeOffset("D"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get date array value ['2012-01-01', null, '1776-07-04']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<DateTimeOffset>> GetDateInvalidNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDateInvalidNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<DateTimeOffset> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<DateTimeOffset> array = new List<DateTimeOffset>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDateTimeOffset("D"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDateInvalidCharsRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/date/invalidchars", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get date array value ['2011-03-22', 'date']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<DateTimeOffset>>> GetDateInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDateInvalidCharsRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<DateTimeOffset> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<DateTimeOffset> array = new List<DateTimeOffset>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDateTimeOffset("D"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get date array value ['2011-03-22', 'date']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<DateTimeOffset>> GetDateInvalidChars(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDateInvalidCharsRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<DateTimeOffset> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<DateTimeOffset> array = new List<DateTimeOffset>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDateTimeOffset("D"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDateTimeValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/date-time/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get date-time array value ['2000-12-01t00:00:01z', '1980-01-02T00:11:35+01:00', '1492-10-12T10:15:01-08:00']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<DateTimeOffset>>> GetDateTimeValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDateTimeValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<DateTimeOffset> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<DateTimeOffset> array = new List<DateTimeOffset>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDateTimeOffset("O"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get date-time array value ['2000-12-01t00:00:01z', '1980-01-02T00:11:35+01:00', '1492-10-12T10:15:01-08:00']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<DateTimeOffset>> GetDateTimeValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDateTimeValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<DateTimeOffset> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<DateTimeOffset> array = new List<DateTimeOffset>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDateTimeOffset("O"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutDateTimeValidRequest(IEnumerable<DateTimeOffset> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/date-time/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item, "O");
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Set array value  ['2000-12-01t00:00:01z', '1980-01-02T00:11:35+01:00', '1492-10-12T10:15:01-08:00']. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutDateTimeValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutDateTimeValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set array value  ['2000-12-01t00:00:01z', '1980-01-02T00:11:35+01:00', '1492-10-12T10:15:01-08:00']. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutDateTimeValid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutDateTimeValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDateTimeInvalidNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/date-time/invalidnull", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get date array value ['2000-12-01t00:00:01z', null]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<DateTimeOffset>>> GetDateTimeInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDateTimeInvalidNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<DateTimeOffset> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<DateTimeOffset> array = new List<DateTimeOffset>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDateTimeOffset("O"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get date array value ['2000-12-01t00:00:01z', null]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<DateTimeOffset>> GetDateTimeInvalidNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDateTimeInvalidNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<DateTimeOffset> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<DateTimeOffset> array = new List<DateTimeOffset>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDateTimeOffset("O"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDateTimeInvalidCharsRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/date-time/invalidchars", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get date array value ['2000-12-01t00:00:01z', 'date-time']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<DateTimeOffset>>> GetDateTimeInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDateTimeInvalidCharsRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<DateTimeOffset> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<DateTimeOffset> array = new List<DateTimeOffset>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDateTimeOffset("O"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get date array value ['2000-12-01t00:00:01z', 'date-time']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<DateTimeOffset>> GetDateTimeInvalidChars(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDateTimeInvalidCharsRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<DateTimeOffset> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<DateTimeOffset> array = new List<DateTimeOffset>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDateTimeOffset("O"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDateTimeRfc1123ValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/date-time-rfc1123/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get date-time array value ['Fri, 01 Dec 2000 00:00:01 GMT', 'Wed, 02 Jan 1980 00:11:35 GMT', 'Wed, 12 Oct 1492 10:15:01 GMT']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<DateTimeOffset>>> GetDateTimeRfc1123ValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDateTimeRfc1123ValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<DateTimeOffset> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<DateTimeOffset> array = new List<DateTimeOffset>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDateTimeOffset("R"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get date-time array value ['Fri, 01 Dec 2000 00:00:01 GMT', 'Wed, 02 Jan 1980 00:11:35 GMT', 'Wed, 12 Oct 1492 10:15:01 GMT']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<DateTimeOffset>> GetDateTimeRfc1123Valid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDateTimeRfc1123ValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<DateTimeOffset> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<DateTimeOffset> array = new List<DateTimeOffset>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetDateTimeOffset("R"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutDateTimeRfc1123ValidRequest(IEnumerable<DateTimeOffset> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/date-time-rfc1123/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item, "R");
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Set array value  ['Fri, 01 Dec 2000 00:00:01 GMT', 'Wed, 02 Jan 1980 00:11:35 GMT', 'Wed, 12 Oct 1492 10:15:01 GMT']. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutDateTimeRfc1123ValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutDateTimeRfc1123ValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set array value  ['Fri, 01 Dec 2000 00:00:01 GMT', 'Wed, 02 Jan 1980 00:11:35 GMT', 'Wed, 12 Oct 1492 10:15:01 GMT']. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutDateTimeRfc1123Valid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutDateTimeRfc1123ValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDurationValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/duration/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get duration array value ['P123DT22H14M12.011S', 'P5DT1H0M0S']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<TimeSpan>>> GetDurationValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDurationValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<TimeSpan> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<TimeSpan> array = new List<TimeSpan>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetTimeSpan("P"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get duration array value ['P123DT22H14M12.011S', 'P5DT1H0M0S']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<TimeSpan>> GetDurationValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDurationValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<TimeSpan> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<TimeSpan> array = new List<TimeSpan>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetTimeSpan("P"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutDurationValidRequest(IEnumerable<TimeSpan> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/duration/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item, "P");
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Set array value  ['P123DT22H14M12.011S', 'P5DT1H0M0S']. </summary>
        /// <param name="arrayBody"> The ArrayOfDuration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutDurationValidAsync(IEnumerable<TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutDurationValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set array value  ['P123DT22H14M12.011S', 'P5DT1H0M0S']. </summary>
        /// <param name="arrayBody"> The ArrayOfDuration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutDurationValid(IEnumerable<TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutDurationValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetByteValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/byte/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get byte array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each item encoded in base64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<byte[]>>> GetByteValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetByteValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<byte[]> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<byte[]> array = new List<byte[]>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetBytesFromBase64("D"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get byte array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each item encoded in base64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<byte[]>> GetByteValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetByteValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<byte[]> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<byte[]> array = new List<byte[]>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetBytesFromBase64("D"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutByteValidRequest(IEnumerable<byte[]> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/byte/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteBase64StringValue(item, "D");
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Put the array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each elementencoded in base 64. </summary>
        /// <param name="arrayBody"> The ArrayOfByteArray to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutByteValidAsync(IEnumerable<byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutByteValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put the array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each elementencoded in base 64. </summary>
        /// <param name="arrayBody"> The ArrayOfByteArray to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutByteValid(IEnumerable<byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutByteValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetByteInvalidNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/byte/invalidnull", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get byte array value [hex(AB, AC, AD), null] with the first item base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<byte[]>>> GetByteInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetByteInvalidNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<byte[]> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<byte[]> array = new List<byte[]>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetBytesFromBase64("D"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get byte array value [hex(AB, AC, AD), null] with the first item base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<byte[]>> GetByteInvalidNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetByteInvalidNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<byte[]> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<byte[]> array = new List<byte[]>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetBytesFromBase64("D"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetBase64UrlRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/prim/base64url/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get array value ['a string that gets encoded with base64url', 'test string' 'Lorem ipsum'] with the items base64url encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<byte[]>>> GetBase64UrlAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBase64UrlRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<byte[]> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<byte[]> array = new List<byte[]>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetBytesFromBase64("U"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get array value ['a string that gets encoded with base64url', 'test string' 'Lorem ipsum'] with the items base64url encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<byte[]>> GetBase64Url(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBase64UrlRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<byte[]> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<byte[]> array = new List<byte[]>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetBytesFromBase64("U"));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetComplexNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/complex/null", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get array of complex type null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<Product>>> GetComplexNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplexNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Product> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<Product> array = new List<Product>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(Product.DeserializeProduct(item));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get array of complex type null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<Product>> GetComplexNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplexNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Product> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<Product> array = new List<Product>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(Product.DeserializeProduct(item));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetComplexEmptyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/complex/empty", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get empty array of complex type []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<Product>>> GetComplexEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplexEmptyRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Product> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<Product> array = new List<Product>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(Product.DeserializeProduct(item));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get empty array of complex type []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<Product>> GetComplexEmpty(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplexEmptyRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Product> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<Product> array = new List<Product>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(Product.DeserializeProduct(item));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetComplexItemNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/complex/itemnull", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get array of complex type with null item [{'integer': 1 'string': '2'}, null, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<Product>>> GetComplexItemNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplexItemNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Product> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<Product> array = new List<Product>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(Product.DeserializeProduct(item));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get array of complex type with null item [{'integer': 1 'string': '2'}, null, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<Product>> GetComplexItemNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplexItemNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Product> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<Product> array = new List<Product>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(Product.DeserializeProduct(item));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetComplexItemEmptyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/complex/itemempty", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get array of complex type with empty item [{'integer': 1 'string': '2'}, {}, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<Product>>> GetComplexItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplexItemEmptyRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Product> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<Product> array = new List<Product>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(Product.DeserializeProduct(item));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get array of complex type with empty item [{'integer': 1 'string': '2'}, {}, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<Product>> GetComplexItemEmpty(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplexItemEmptyRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Product> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<Product> array = new List<Product>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(Product.DeserializeProduct(item));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetComplexValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/complex/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get array of complex type with [{'integer': 1 'string': '2'}, {'integer': 3, 'string': '4'}, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<Product>>> GetComplexValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplexValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Product> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<Product> array = new List<Product>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(Product.DeserializeProduct(item));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get array of complex type with [{'integer': 1 'string': '2'}, {'integer': 3, 'string': '4'}, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<Product>> GetComplexValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplexValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Product> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<Product> array = new List<Product>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(Product.DeserializeProduct(item));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutComplexValidRequest(IEnumerable<Product> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/complex/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteObjectValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Put an array of complex type with values [{'integer': 1 'string': '2'}, {'integer': 3, 'string': '4'}, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="arrayBody"> The ArrayOfProduct to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutComplexValidAsync(IEnumerable<Product> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutComplexValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put an array of complex type with values [{'integer': 1 'string': '2'}, {'integer': 3, 'string': '4'}, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="arrayBody"> The ArrayOfProduct to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutComplexValid(IEnumerable<Product> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutComplexValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetArrayNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/array/null", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a null array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<IList<string>>>> GetArrayNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetArrayNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IList<string>> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<IList<string>> array = new List<IList<string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                List<string> array0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    array0.Add(item0.GetString());
                                }
                                array.Add(array0);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a null array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<IList<string>>> GetArrayNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetArrayNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IList<string>> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<IList<string>> array = new List<IList<string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                List<string> array0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    array0.Add(item0.GetString());
                                }
                                array.Add(array0);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetArrayEmptyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/array/empty", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an empty array []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<IList<string>>>> GetArrayEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetArrayEmptyRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IList<string>> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<IList<string>> array = new List<IList<string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                List<string> array0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    array0.Add(item0.GetString());
                                }
                                array.Add(array0);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an empty array []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<IList<string>>> GetArrayEmpty(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetArrayEmptyRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IList<string>> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<IList<string>> array = new List<IList<string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                List<string> array0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    array0.Add(item0.GetString());
                                }
                                array.Add(array0);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetArrayItemNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/array/itemnull", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an array of array of strings [['1', '2', '3'], null, ['7', '8', '9']]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<IList<string>>>> GetArrayItemNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetArrayItemNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IList<string>> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<IList<string>> array = new List<IList<string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                List<string> array0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    array0.Add(item0.GetString());
                                }
                                array.Add(array0);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an array of array of strings [['1', '2', '3'], null, ['7', '8', '9']]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<IList<string>>> GetArrayItemNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetArrayItemNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IList<string>> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<IList<string>> array = new List<IList<string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                List<string> array0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    array0.Add(item0.GetString());
                                }
                                array.Add(array0);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetArrayItemEmptyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/array/itemempty", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an array of array of strings [['1', '2', '3'], [], ['7', '8', '9']]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<IList<string>>>> GetArrayItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetArrayItemEmptyRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IList<string>> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<IList<string>> array = new List<IList<string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                List<string> array0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    array0.Add(item0.GetString());
                                }
                                array.Add(array0);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an array of array of strings [['1', '2', '3'], [], ['7', '8', '9']]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<IList<string>>> GetArrayItemEmpty(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetArrayItemEmptyRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IList<string>> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<IList<string>> array = new List<IList<string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                List<string> array0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    array0.Add(item0.GetString());
                                }
                                array.Add(array0);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetArrayValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/array/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an array of array of strings [['1', '2', '3'], ['4', '5', '6'], ['7', '8', '9']]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<IList<string>>>> GetArrayValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetArrayValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IList<string>> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<IList<string>> array = new List<IList<string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                List<string> array0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    array0.Add(item0.GetString());
                                }
                                array.Add(array0);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an array of array of strings [['1', '2', '3'], ['4', '5', '6'], ['7', '8', '9']]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<IList<string>>> GetArrayValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetArrayValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IList<string>> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<IList<string>> array = new List<IList<string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                List<string> array0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    array0.Add(item0.GetString());
                                }
                                array.Add(array0);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutArrayValidRequest(IEnumerable<IList<string>> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/array/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                if (item == null)
                {
                    content.JsonWriter.WriteNullValue();
                    continue;
                }
                content.JsonWriter.WriteStartArray();
                foreach (var item0 in item)
                {
                    content.JsonWriter.WriteStringValue(item0);
                }
                content.JsonWriter.WriteEndArray();
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Put An array of array of strings [['1', '2', '3'], ['4', '5', '6'], ['7', '8', '9']]. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutArrayValidAsync(IEnumerable<IList<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutArrayValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put An array of array of strings [['1', '2', '3'], ['4', '5', '6'], ['7', '8', '9']]. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutArrayValid(IEnumerable<IList<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutArrayValidRequest(arrayBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDictionaryNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/dictionary/null", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an array of Dictionaries with value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<IDictionary<string, string>>>> GetDictionaryNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDictionaryNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IDictionary<string, string>> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<IDictionary<string, string>> array = new List<IDictionary<string, string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    dictionary.Add(property.Name, property.Value.GetString());
                                }
                                array.Add(dictionary);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an array of Dictionaries with value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<IDictionary<string, string>>> GetDictionaryNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDictionaryNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IDictionary<string, string>> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<IDictionary<string, string>> array = new List<IDictionary<string, string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    dictionary.Add(property.Name, property.Value.GetString());
                                }
                                array.Add(dictionary);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDictionaryEmptyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/dictionary/empty", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<IDictionary<string, string>>>> GetDictionaryEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDictionaryEmptyRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IDictionary<string, string>> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<IDictionary<string, string>> array = new List<IDictionary<string, string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    dictionary.Add(property.Name, property.Value.GetString());
                                }
                                array.Add(dictionary);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<IDictionary<string, string>>> GetDictionaryEmpty(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDictionaryEmptyRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IDictionary<string, string>> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<IDictionary<string, string>> array = new List<IDictionary<string, string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    dictionary.Add(property.Name, property.Value.GetString());
                                }
                                array.Add(dictionary);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDictionaryItemNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/dictionary/itemnull", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, null, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<IDictionary<string, string>>>> GetDictionaryItemNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDictionaryItemNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IDictionary<string, string>> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<IDictionary<string, string>> array = new List<IDictionary<string, string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    dictionary.Add(property.Name, property.Value.GetString());
                                }
                                array.Add(dictionary);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, null, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<IDictionary<string, string>>> GetDictionaryItemNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDictionaryItemNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IDictionary<string, string>> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<IDictionary<string, string>> array = new List<IDictionary<string, string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    dictionary.Add(property.Name, property.Value.GetString());
                                }
                                array.Add(dictionary);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDictionaryItemEmptyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/dictionary/itemempty", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, {}, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<IDictionary<string, string>>>> GetDictionaryItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDictionaryItemEmptyRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IDictionary<string, string>> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<IDictionary<string, string>> array = new List<IDictionary<string, string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    dictionary.Add(property.Name, property.Value.GetString());
                                }
                                array.Add(dictionary);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, {}, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<IDictionary<string, string>>> GetDictionaryItemEmpty(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDictionaryItemEmptyRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IDictionary<string, string>> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<IDictionary<string, string>> array = new List<IDictionary<string, string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    dictionary.Add(property.Name, property.Value.GetString());
                                }
                                array.Add(dictionary);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDictionaryValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/dictionary/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, {'4': 'four', '5': 'five', '6': 'six'}, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<IDictionary<string, string>>>> GetDictionaryValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDictionaryValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IDictionary<string, string>> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<IDictionary<string, string>> array = new List<IDictionary<string, string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    dictionary.Add(property.Name, property.Value.GetString());
                                }
                                array.Add(dictionary);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, {'4': 'four', '5': 'five', '6': 'six'}, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<IDictionary<string, string>>> GetDictionaryValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDictionaryValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<IDictionary<string, string>> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<IDictionary<string, string>> array = new List<IDictionary<string, string>>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            if (item.ValueKind == JsonValueKind.Null)
                            {
                                array.Add(null);
                            }
                            else
                            {
                                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    dictionary.Add(property.Name, property.Value.GetString());
                                }
                                array.Add(dictionary);
                            }
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutDictionaryValidRequest(IEnumerable<IDictionary<string, string>> arrayBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/array/dictionary/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                if (item == null)
                {
                    content.JsonWriter.WriteNullValue();
                    continue;
                }
                content.JsonWriter.WriteStartObject();
                foreach (var item0 in item)
                {
                    content.JsonWriter.WritePropertyName(item0.Key);
                    content.JsonWriter.WriteStringValue(item0.Value);
                }
                content.JsonWriter.WriteEndObject();
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, {'4': 'four', '5': 'five', '6': 'six'}, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="arrayBody"> The ArrayOfDictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public async Task<Response> PutDictionaryValidAsync(IEnumerable<IDictionary<string, string>> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutDictionaryValidRequest(arrayBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, {'4': 'four', '5': 'five', '6': 'six'}, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="arrayBody"> The ArrayOfDictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayBody"/> is null. </exception>
        public Response PutDictionaryValid(IEnumerable<IDictionary<string, string>> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var message = CreatePutDictionaryValidRequest(arrayBody);
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
