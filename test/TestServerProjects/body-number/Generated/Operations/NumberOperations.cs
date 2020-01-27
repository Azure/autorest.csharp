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
    internal partial class NumberOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of NumberOperations. </summary>
        public NumberOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/null", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<float>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetNull");
            scope.Start();
            try
            {
                using var message = CreateGetNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetSingle();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get null Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<float> GetNull(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetNull");
            scope.Start();
            try
            {
                using var message = CreateGetNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetSingle();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetInvalidFloatRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/invalidfloat", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get invalid float Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<float>> GetInvalidFloatAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetInvalidFloat");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidFloatRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetSingle();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get invalid float Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<float> GetInvalidFloat(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetInvalidFloat");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidFloatRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetSingle();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetInvalidDoubleRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/invaliddouble", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get invalid double Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetInvalidDoubleAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetInvalidDouble");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidDoubleRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDouble();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get invalid double Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetInvalidDouble(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetInvalidDouble");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidDoubleRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDouble();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetInvalidDecimalRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/invaliddecimal", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get invalid decimal Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetInvalidDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetInvalidDecimal");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidDecimalRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDecimal();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get invalid decimal Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetInvalidDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetInvalidDecimal");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidDecimalRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDecimal();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutBigFloatRequest(float numberBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/big/float/3.402823e+20", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(numberBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put big float value 3.402823e+20. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigFloatAsync(float numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutBigFloat");
            scope.Start();
            try
            {
                using var message = CreatePutBigFloatRequest(numberBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put big float value 3.402823e+20. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigFloat(float numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutBigFloat");
            scope.Start();
            try
            {
                using var message = CreatePutBigFloatRequest(numberBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetBigFloatRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/big/float/3.402823e+20", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get big float value 3.402823e+20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<float>> GetBigFloatAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetBigFloat");
            scope.Start();
            try
            {
                using var message = CreateGetBigFloatRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetSingle();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get big float value 3.402823e+20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<float> GetBigFloat(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetBigFloat");
            scope.Start();
            try
            {
                using var message = CreateGetBigFloatRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetSingle();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutBigDoubleRequest(double numberBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/big/double/2.5976931e+101", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(numberBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put big double value 2.5976931e+101. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDoubleAsync(double numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutBigDouble");
            scope.Start();
            try
            {
                using var message = CreatePutBigDoubleRequest(numberBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put big double value 2.5976931e+101. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDouble(double numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutBigDouble");
            scope.Start();
            try
            {
                using var message = CreatePutBigDoubleRequest(numberBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetBigDoubleRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/big/double/2.5976931e+101", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get big double value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetBigDoubleAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetBigDouble");
            scope.Start();
            try
            {
                using var message = CreateGetBigDoubleRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDouble();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get big double value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetBigDouble(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetBigDouble");
            scope.Start();
            try
            {
                using var message = CreateGetBigDoubleRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDouble();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutBigDoublePositiveDecimalRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/big/double/99999999.99", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(99999999.99);
            request.Content = content;
            return message;
        }
        /// <summary> Put big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDoublePositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutBigDoublePositiveDecimal");
            scope.Start();
            try
            {
                using var message = CreatePutBigDoublePositiveDecimalRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDoublePositiveDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutBigDoublePositiveDecimal");
            scope.Start();
            try
            {
                using var message = CreatePutBigDoublePositiveDecimalRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetBigDoublePositiveDecimalRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/big/double/99999999.99", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetBigDoublePositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetBigDoublePositiveDecimal");
            scope.Start();
            try
            {
                using var message = CreateGetBigDoublePositiveDecimalRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDouble();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetBigDoublePositiveDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetBigDoublePositiveDecimal");
            scope.Start();
            try
            {
                using var message = CreateGetBigDoublePositiveDecimalRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDouble();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutBigDoubleNegativeDecimalRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/big/double/-99999999.99", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(-99999999.99);
            request.Content = content;
            return message;
        }
        /// <summary> Put big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDoubleNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutBigDoubleNegativeDecimal");
            scope.Start();
            try
            {
                using var message = CreatePutBigDoubleNegativeDecimalRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDoubleNegativeDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutBigDoubleNegativeDecimal");
            scope.Start();
            try
            {
                using var message = CreatePutBigDoubleNegativeDecimalRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetBigDoubleNegativeDecimalRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/big/double/-99999999.99", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetBigDoubleNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetBigDoubleNegativeDecimal");
            scope.Start();
            try
            {
                using var message = CreateGetBigDoubleNegativeDecimalRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDouble();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetBigDoubleNegativeDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetBigDoubleNegativeDecimal");
            scope.Start();
            try
            {
                using var message = CreateGetBigDoubleNegativeDecimalRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDouble();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutBigDecimalRequest(decimal numberBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/big/decimal/2.5976931e+101", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(numberBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put big decimal value 2.5976931e+101. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDecimalAsync(decimal numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutBigDecimal");
            scope.Start();
            try
            {
                using var message = CreatePutBigDecimalRequest(numberBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put big decimal value 2.5976931e+101. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDecimal(decimal numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutBigDecimal");
            scope.Start();
            try
            {
                using var message = CreatePutBigDecimalRequest(numberBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetBigDecimalRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/big/decimal/2.5976931e+101", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get big decimal value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetBigDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetBigDecimal");
            scope.Start();
            try
            {
                using var message = CreateGetBigDecimalRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDecimal();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get big decimal value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetBigDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetBigDecimal");
            scope.Start();
            try
            {
                using var message = CreateGetBigDecimalRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDecimal();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutBigDecimalPositiveDecimalRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/big/decimal/99999999.99", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(99999999.99M);
            request.Content = content;
            return message;
        }
        /// <summary> Put big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDecimalPositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutBigDecimalPositiveDecimal");
            scope.Start();
            try
            {
                using var message = CreatePutBigDecimalPositiveDecimalRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDecimalPositiveDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutBigDecimalPositiveDecimal");
            scope.Start();
            try
            {
                using var message = CreatePutBigDecimalPositiveDecimalRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetBigDecimalPositiveDecimalRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/big/decimal/99999999.99", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetBigDecimalPositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetBigDecimalPositiveDecimal");
            scope.Start();
            try
            {
                using var message = CreateGetBigDecimalPositiveDecimalRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDecimal();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetBigDecimalPositiveDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetBigDecimalPositiveDecimal");
            scope.Start();
            try
            {
                using var message = CreateGetBigDecimalPositiveDecimalRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDecimal();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutBigDecimalNegativeDecimalRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/big/decimal/-99999999.99", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(-99999999.99M);
            request.Content = content;
            return message;
        }
        /// <summary> Put big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDecimalNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutBigDecimalNegativeDecimal");
            scope.Start();
            try
            {
                using var message = CreatePutBigDecimalNegativeDecimalRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDecimalNegativeDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutBigDecimalNegativeDecimal");
            scope.Start();
            try
            {
                using var message = CreatePutBigDecimalNegativeDecimalRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetBigDecimalNegativeDecimalRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/big/decimal/-99999999.99", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetBigDecimalNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetBigDecimalNegativeDecimal");
            scope.Start();
            try
            {
                using var message = CreateGetBigDecimalNegativeDecimalRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDecimal();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetBigDecimalNegativeDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetBigDecimalNegativeDecimal");
            scope.Start();
            try
            {
                using var message = CreateGetBigDecimalNegativeDecimalRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDecimal();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutSmallFloatRequest(float numberBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/small/float/3.402823e-20", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(numberBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put small float value 3.402823e-20. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutSmallFloatAsync(float numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutSmallFloat");
            scope.Start();
            try
            {
                using var message = CreatePutSmallFloatRequest(numberBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put small float value 3.402823e-20. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutSmallFloat(float numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutSmallFloat");
            scope.Start();
            try
            {
                using var message = CreatePutSmallFloatRequest(numberBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetSmallFloatRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/small/float/3.402823e-20", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get big double value 3.402823e-20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetSmallFloatAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetSmallFloat");
            scope.Start();
            try
            {
                using var message = CreateGetSmallFloatRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDouble();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get big double value 3.402823e-20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetSmallFloat(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetSmallFloat");
            scope.Start();
            try
            {
                using var message = CreateGetSmallFloatRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDouble();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutSmallDoubleRequest(double numberBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/small/double/2.5976931e-101", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(numberBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put small double value 2.5976931e-101. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutSmallDoubleAsync(double numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutSmallDouble");
            scope.Start();
            try
            {
                using var message = CreatePutSmallDoubleRequest(numberBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put small double value 2.5976931e-101. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutSmallDouble(double numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutSmallDouble");
            scope.Start();
            try
            {
                using var message = CreatePutSmallDoubleRequest(numberBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetSmallDoubleRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/small/double/2.5976931e-101", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get big double value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetSmallDoubleAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetSmallDouble");
            scope.Start();
            try
            {
                using var message = CreateGetSmallDoubleRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDouble();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get big double value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetSmallDouble(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetSmallDouble");
            scope.Start();
            try
            {
                using var message = CreateGetSmallDoubleRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDouble();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutSmallDecimalRequest(decimal numberBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/small/decimal/2.5976931e-101", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(numberBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put small decimal value 2.5976931e-101. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutSmallDecimalAsync(decimal numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutSmallDecimal");
            scope.Start();
            try
            {
                using var message = CreatePutSmallDecimalRequest(numberBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put small decimal value 2.5976931e-101. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutSmallDecimal(decimal numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("NumberOperations.PutSmallDecimal");
            scope.Start();
            try
            {
                using var message = CreatePutSmallDecimalRequest(numberBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetSmallDecimalRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/number/small/decimal/2.5976931e-101", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get small decimal value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetSmallDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetSmallDecimal");
            scope.Start();
            try
            {
                using var message = CreateGetSmallDecimalRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDecimal();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get small decimal value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetSmallDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("NumberOperations.GetSmallDecimal");
            scope.Start();
            try
            {
                using var message = CreateGetSmallDecimalRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDecimal();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
