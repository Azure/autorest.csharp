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

namespace body_datetime
{
    internal partial class DatetimeRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of DatetimeRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public DatetimeRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
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
            uri.AppendPath("/datetime/null", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DateTimeOffset?>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset? value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = document.RootElement.GetDateTimeOffset("O");
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset?> GetNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset? value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = document.RootElement.GetDateTimeOffset("O");
                        }
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
            uri.AppendPath("/datetime/invalid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get invalid datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DateTimeOffset>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetInvalidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get invalid datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetInvalid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetInvalidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetOverflowRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/overflow", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get overflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DateTimeOffset>> GetOverflowAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetOverflowRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get overflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetOverflow(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetOverflowRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetUnderflowRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/underflow", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get underflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DateTimeOffset>> GetUnderflowAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUnderflowRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get underflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUnderflow(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUnderflowRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutUtcMaxDateTimeRequest(DateTimeOffset datetimeBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/max/utc", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "O");
            request.Content = content;
            return message;
        }

        /// <summary> Put max datetime value 9999-12-31T23:59:59.999Z. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutUtcMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutUtcMaxDateTimeRequest(datetimeBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put max datetime value 9999-12-31T23:59:59.999Z. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutUtcMaxDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutUtcMaxDateTimeRequest(datetimeBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutUtcMaxDateTime7DigitsRequest(DateTimeOffset datetimeBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/max/utc7ms", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "O");
            request.Content = content;
            return message;
        }

        /// <summary> Put max datetime value 9999-12-31T23:59:59.9999999Z. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> This is against the recommendation that asks for 3 digits, but allow to test what happens in that scenario. </remarks>
        public async Task<Response> PutUtcMaxDateTime7DigitsAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutUtcMaxDateTime7DigitsRequest(datetimeBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put max datetime value 9999-12-31T23:59:59.9999999Z. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> This is against the recommendation that asks for 3 digits, but allow to test what happens in that scenario. </remarks>
        public Response PutUtcMaxDateTime7Digits(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutUtcMaxDateTime7DigitsRequest(datetimeBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetUtcLowercaseMaxDateTimeRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/max/utc/lowercase", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get max datetime value 9999-12-31t23:59:59.999z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DateTimeOffset>> GetUtcLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUtcLowercaseMaxDateTimeRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get max datetime value 9999-12-31t23:59:59.999z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUtcLowercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUtcLowercaseMaxDateTimeRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetUtcUppercaseMaxDateTimeRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/max/utc/uppercase", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get max datetime value 9999-12-31T23:59:59.999Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DateTimeOffset>> GetUtcUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUtcUppercaseMaxDateTimeRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get max datetime value 9999-12-31T23:59:59.999Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUtcUppercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUtcUppercaseMaxDateTimeRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetUtcUppercaseMaxDateTime7DigitsRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/max/utc7ms/uppercase", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get max datetime value 9999-12-31T23:59:59.9999999Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> This is against the recommendation that asks for 3 digits, but allow to test what happens in that scenario. </remarks>
        public async Task<Response<DateTimeOffset>> GetUtcUppercaseMaxDateTime7DigitsAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUtcUppercaseMaxDateTime7DigitsRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get max datetime value 9999-12-31T23:59:59.9999999Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> This is against the recommendation that asks for 3 digits, but allow to test what happens in that scenario. </remarks>
        public Response<DateTimeOffset> GetUtcUppercaseMaxDateTime7Digits(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUtcUppercaseMaxDateTime7DigitsRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutLocalPositiveOffsetMaxDateTimeRequest(DateTimeOffset datetimeBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/max/localpositiveoffset", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "O");
            request.Content = content;
            return message;
        }

        /// <summary> Put max datetime value with positive numoffset 9999-12-31t23:59:59.999+14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutLocalPositiveOffsetMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutLocalPositiveOffsetMaxDateTimeRequest(datetimeBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put max datetime value with positive numoffset 9999-12-31t23:59:59.999+14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLocalPositiveOffsetMaxDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutLocalPositiveOffsetMaxDateTimeRequest(datetimeBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetLocalPositiveOffsetLowercaseMaxDateTimeRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/max/localpositiveoffset/lowercase", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31t23:59:59.999+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DateTimeOffset>> GetLocalPositiveOffsetLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLocalPositiveOffsetLowercaseMaxDateTimeRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31t23:59:59.999+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetLocalPositiveOffsetLowercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLocalPositiveOffsetLowercaseMaxDateTimeRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetLocalPositiveOffsetUppercaseMaxDateTimeRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/max/localpositiveoffset/uppercase", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31T23:59:59.999+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DateTimeOffset>> GetLocalPositiveOffsetUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLocalPositiveOffsetUppercaseMaxDateTimeRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31T23:59:59.999+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetLocalPositiveOffsetUppercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLocalPositiveOffsetUppercaseMaxDateTimeRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutLocalNegativeOffsetMaxDateTimeRequest(DateTimeOffset datetimeBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/max/localnegativeoffset", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "O");
            request.Content = content;
            return message;
        }

        /// <summary> Put max datetime value with positive numoffset 9999-12-31t23:59:59.999-14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutLocalNegativeOffsetMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutLocalNegativeOffsetMaxDateTimeRequest(datetimeBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put max datetime value with positive numoffset 9999-12-31t23:59:59.999-14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLocalNegativeOffsetMaxDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutLocalNegativeOffsetMaxDateTimeRequest(datetimeBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetLocalNegativeOffsetUppercaseMaxDateTimeRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/max/localnegativeoffset/uppercase", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31T23:59:59.999-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DateTimeOffset>> GetLocalNegativeOffsetUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLocalNegativeOffsetUppercaseMaxDateTimeRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31T23:59:59.999-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetLocalNegativeOffsetUppercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLocalNegativeOffsetUppercaseMaxDateTimeRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetLocalNegativeOffsetLowercaseMaxDateTimeRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/max/localnegativeoffset/lowercase", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31t23:59:59.999-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DateTimeOffset>> GetLocalNegativeOffsetLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLocalNegativeOffsetLowercaseMaxDateTimeRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31t23:59:59.999-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetLocalNegativeOffsetLowercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLocalNegativeOffsetLowercaseMaxDateTimeRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutUtcMinDateTimeRequest(DateTimeOffset datetimeBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/min/utc", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "O");
            request.Content = content;
            return message;
        }

        /// <summary> Put min datetime value 0001-01-01T00:00:00Z. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutUtcMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutUtcMinDateTimeRequest(datetimeBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put min datetime value 0001-01-01T00:00:00Z. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutUtcMinDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutUtcMinDateTimeRequest(datetimeBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetUtcMinDateTimeRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/min/utc", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DateTimeOffset>> GetUtcMinDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUtcMinDateTimeRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUtcMinDateTime(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUtcMinDateTimeRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutLocalPositiveOffsetMinDateTimeRequest(DateTimeOffset datetimeBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/min/localpositiveoffset", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "O");
            request.Content = content;
            return message;
        }

        /// <summary> Put min datetime value 0001-01-01T00:00:00+14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutLocalPositiveOffsetMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutLocalPositiveOffsetMinDateTimeRequest(datetimeBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put min datetime value 0001-01-01T00:00:00+14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLocalPositiveOffsetMinDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutLocalPositiveOffsetMinDateTimeRequest(datetimeBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetLocalPositiveOffsetMinDateTimeRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/min/localpositiveoffset", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DateTimeOffset>> GetLocalPositiveOffsetMinDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLocalPositiveOffsetMinDateTimeRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetLocalPositiveOffsetMinDateTime(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLocalPositiveOffsetMinDateTimeRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutLocalNegativeOffsetMinDateTimeRequest(DateTimeOffset datetimeBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/min/localnegativeoffset", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "O");
            request.Content = content;
            return message;
        }

        /// <summary> Put min datetime value 0001-01-01T00:00:00-14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutLocalNegativeOffsetMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutLocalNegativeOffsetMinDateTimeRequest(datetimeBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put min datetime value 0001-01-01T00:00:00-14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLocalNegativeOffsetMinDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutLocalNegativeOffsetMinDateTimeRequest(datetimeBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetLocalNegativeOffsetMinDateTimeRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/min/localnegativeoffset", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DateTimeOffset>> GetLocalNegativeOffsetMinDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLocalNegativeOffsetMinDateTimeRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetLocalNegativeOffsetMinDateTime(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLocalNegativeOffsetMinDateTimeRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetLocalNoOffsetMinDateTimeRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/min/localnooffset", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DateTimeOffset>> GetLocalNoOffsetMinDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLocalNoOffsetMinDateTimeRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetLocalNoOffsetMinDateTime(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLocalNoOffsetMinDateTimeRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DateTimeOffset value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDateTimeOffset("O");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
