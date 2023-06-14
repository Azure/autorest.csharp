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

namespace body_number
{
    internal partial class NumberRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of NumberRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public NumberRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
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
            uri.AppendPath("/number/null", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<float?>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        float? value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = document.RootElement.GetSingle();
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<float?> GetNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        float? value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = document.RootElement.GetSingle();
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetInvalidFloatRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/invalidfloat", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get invalid float Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<float>> GetInvalidFloatAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetInvalidFloatRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        float value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetSingle();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get invalid float Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<float> GetInvalidFloat(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetInvalidFloatRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        float value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetSingle();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetInvalidDoubleRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/invaliddouble", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get invalid double Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<double>> GetInvalidDoubleAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetInvalidDoubleRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        double value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDouble();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get invalid double Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetInvalidDouble(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetInvalidDoubleRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        double value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDouble();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetInvalidDecimalRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/invaliddecimal", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get invalid decimal Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<decimal>> GetInvalidDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetInvalidDecimalRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        decimal value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDecimal();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get invalid decimal Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetInvalidDecimal(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetInvalidDecimalRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        decimal value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDecimal();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutBigFloatRequest(float numberBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/big/float/3.402823e+20", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(numberBody);
            request.Content = content;
            return message;
        }

        /// <summary> Put big float value 3.402823e+20. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutBigFloatAsync(float numberBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutBigFloatRequest(numberBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put big float value 3.402823e+20. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigFloat(float numberBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutBigFloatRequest(numberBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetBigFloatRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/big/float/3.402823e+20", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get big float value 3.402823e+20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<float>> GetBigFloatAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBigFloatRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        float value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetSingle();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get big float value 3.402823e+20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<float> GetBigFloat(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBigFloatRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        float value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetSingle();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutBigDoubleRequest(double numberBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/big/double/2.5976931e+101", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(numberBody);
            request.Content = content;
            return message;
        }

        /// <summary> Put big double value 2.5976931e+101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutBigDoubleAsync(double numberBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutBigDoubleRequest(numberBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put big double value 2.5976931e+101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDouble(double numberBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutBigDoubleRequest(numberBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetBigDoubleRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/big/double/2.5976931e+101", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get big double value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<double>> GetBigDoubleAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBigDoubleRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        double value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDouble();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get big double value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetBigDouble(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBigDoubleRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        double value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDouble();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutBigDoublePositiveDecimalRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/big/double/99999999.99", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(99999999.99);
            request.Content = content;
            return message;
        }

        /// <summary> Put big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutBigDoublePositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutBigDoublePositiveDecimalRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDoublePositiveDecimal(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutBigDoublePositiveDecimalRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetBigDoublePositiveDecimalRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/big/double/99999999.99", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<double>> GetBigDoublePositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBigDoublePositiveDecimalRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        double value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDouble();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetBigDoublePositiveDecimal(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBigDoublePositiveDecimalRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        double value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDouble();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutBigDoubleNegativeDecimalRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/big/double/-99999999.99", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(-99999999.99);
            request.Content = content;
            return message;
        }

        /// <summary> Put big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutBigDoubleNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutBigDoubleNegativeDecimalRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDoubleNegativeDecimal(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutBigDoubleNegativeDecimalRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetBigDoubleNegativeDecimalRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/big/double/-99999999.99", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<double>> GetBigDoubleNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBigDoubleNegativeDecimalRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        double value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDouble();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetBigDoubleNegativeDecimal(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBigDoubleNegativeDecimalRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        double value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDouble();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutBigDecimalRequest(decimal numberBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/big/decimal/2.5976931e+101", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(numberBody);
            request.Content = content;
            return message;
        }

        /// <summary> Put big decimal value 2.5976931e+101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutBigDecimalAsync(decimal numberBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutBigDecimalRequest(numberBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put big decimal value 2.5976931e+101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDecimal(decimal numberBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutBigDecimalRequest(numberBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetBigDecimalRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/big/decimal/2.5976931e+101", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get big decimal value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<decimal>> GetBigDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBigDecimalRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        decimal value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDecimal();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get big decimal value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetBigDecimal(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBigDecimalRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        decimal value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDecimal();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutBigDecimalPositiveDecimalRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/big/decimal/99999999.99", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(99999999.99M);
            request.Content = content;
            return message;
        }

        /// <summary> Put big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutBigDecimalPositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutBigDecimalPositiveDecimalRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDecimalPositiveDecimal(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutBigDecimalPositiveDecimalRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetBigDecimalPositiveDecimalRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/big/decimal/99999999.99", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<decimal>> GetBigDecimalPositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBigDecimalPositiveDecimalRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        decimal value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDecimal();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetBigDecimalPositiveDecimal(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBigDecimalPositiveDecimalRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        decimal value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDecimal();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutBigDecimalNegativeDecimalRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/big/decimal/-99999999.99", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(-99999999.99M);
            request.Content = content;
            return message;
        }

        /// <summary> Put big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutBigDecimalNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutBigDecimalNegativeDecimalRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDecimalNegativeDecimal(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutBigDecimalNegativeDecimalRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetBigDecimalNegativeDecimalRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/big/decimal/-99999999.99", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<decimal>> GetBigDecimalNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBigDecimalNegativeDecimalRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        decimal value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDecimal();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetBigDecimalNegativeDecimal(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBigDecimalNegativeDecimalRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        decimal value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDecimal();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutSmallFloatRequest(float numberBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/small/float/3.402823e-20", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(numberBody);
            request.Content = content;
            return message;
        }

        /// <summary> Put small float value 3.402823e-20. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutSmallFloatAsync(float numberBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutSmallFloatRequest(numberBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put small float value 3.402823e-20. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutSmallFloat(float numberBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutSmallFloatRequest(numberBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetSmallFloatRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/small/float/3.402823e-20", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get big double value 3.402823e-20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<double>> GetSmallFloatAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSmallFloatRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        double value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDouble();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get big double value 3.402823e-20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetSmallFloat(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSmallFloatRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        double value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDouble();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutSmallDoubleRequest(double numberBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/small/double/2.5976931e-101", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(numberBody);
            request.Content = content;
            return message;
        }

        /// <summary> Put small double value 2.5976931e-101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutSmallDoubleAsync(double numberBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutSmallDoubleRequest(numberBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put small double value 2.5976931e-101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutSmallDouble(double numberBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutSmallDoubleRequest(numberBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetSmallDoubleRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/small/double/2.5976931e-101", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get big double value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<double>> GetSmallDoubleAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSmallDoubleRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        double value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDouble();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get big double value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetSmallDouble(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSmallDoubleRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        double value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDouble();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutSmallDecimalRequest(decimal numberBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/small/decimal/2.5976931e-101", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(numberBody);
            request.Content = content;
            return message;
        }

        /// <summary> Put small decimal value 2.5976931e-101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutSmallDecimalAsync(decimal numberBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutSmallDecimalRequest(numberBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put small decimal value 2.5976931e-101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutSmallDecimal(decimal numberBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutSmallDecimalRequest(numberBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetSmallDecimalRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/number/small/decimal/2.5976931e-101", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get small decimal value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<decimal>> GetSmallDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSmallDecimalRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        decimal value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetDecimal();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get small decimal value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetSmallDecimal(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSmallDecimalRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        decimal value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetDecimal();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
