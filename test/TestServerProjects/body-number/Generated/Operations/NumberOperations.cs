// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <summary> Get null Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<float>> GetNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.GetNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/null", false);
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
        public async ValueTask<Response<float>> GetInvalidFloatAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.GetInvalidFloat");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/invalidfloat", false);
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
        /// <summary> Get invalid double Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetInvalidDoubleAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.GetInvalidDouble");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/invaliddouble", false);
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
        /// <summary> Get invalid decimal Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetInvalidDecimalAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.GetInvalidDecimal");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/invaliddecimal", false);
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
        /// <summary> Put big float value 3.402823e+20. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigFloatAsync(float numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.PutBigFloat");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/big/float/3.402823e+20", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteNumberValue(numberBody);
                request.Content = content;
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
        /// <summary> Get big float value 3.402823e+20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<float>> GetBigFloatAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.GetBigFloat");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/big/float/3.402823e+20", false);
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
        /// <summary> Put big double value 2.5976931e+101. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDoubleAsync(double numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.PutBigDouble");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/big/double/2.5976931e+101", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteNumberValue(numberBody);
                request.Content = content;
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
        /// <summary> Get big double value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetBigDoubleAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.GetBigDouble");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/big/double/2.5976931e+101", false);
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
        /// <summary> Put big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDoublePositiveDecimalAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.PutBigDoublePositiveDecimal");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/big/double/99999999.99", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteNumberValue(99999999.99);
                request.Content = content;
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
        /// <summary> Get big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetBigDoublePositiveDecimalAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.GetBigDoublePositiveDecimal");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/big/double/99999999.99", false);
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
        /// <summary> Put big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDoubleNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.PutBigDoubleNegativeDecimal");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/big/double/-99999999.99", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteNumberValue(-99999999.99);
                request.Content = content;
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
        /// <summary> Get big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetBigDoubleNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.GetBigDoubleNegativeDecimal");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/big/double/-99999999.99", false);
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
        /// <summary> Put big decimal value 2.5976931e+101. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDecimalAsync(decimal numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.PutBigDecimal");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/big/decimal/2.5976931e+101", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteNumberValue(numberBody);
                request.Content = content;
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
        /// <summary> Get big decimal value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetBigDecimalAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.GetBigDecimal");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/big/decimal/2.5976931e+101", false);
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
        /// <summary> Put big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDecimalPositiveDecimalAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.PutBigDecimalPositiveDecimal");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/big/decimal/99999999.99", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteNumberValue(99999999.99M);
                request.Content = content;
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
        /// <summary> Get big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetBigDecimalPositiveDecimalAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.GetBigDecimalPositiveDecimal");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/big/decimal/99999999.99", false);
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
        /// <summary> Put big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDecimalNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.PutBigDecimalNegativeDecimal");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/big/decimal/-99999999.99", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteNumberValue(-99999999.99M);
                request.Content = content;
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
        /// <summary> Get big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetBigDecimalNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.GetBigDecimalNegativeDecimal");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/big/decimal/-99999999.99", false);
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
        /// <summary> Put small float value 3.402823e-20. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutSmallFloatAsync(float numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.PutSmallFloat");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/small/float/3.402823e-20", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteNumberValue(numberBody);
                request.Content = content;
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
        /// <summary> Get big double value 3.402823e-20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetSmallFloatAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.GetSmallFloat");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/small/float/3.402823e-20", false);
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
        /// <summary> Put small double value 2.5976931e-101. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutSmallDoubleAsync(double numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.PutSmallDouble");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/small/double/2.5976931e-101", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteNumberValue(numberBody);
                request.Content = content;
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
        /// <summary> Get big double value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetSmallDoubleAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.GetSmallDouble");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/small/double/2.5976931e-101", false);
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
        /// <summary> Put small decimal value 2.5976931e-101. </summary>
        /// <param name="numberBody"> The number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutSmallDecimalAsync(decimal numberBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.PutSmallDecimal");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/small/decimal/2.5976931e-101", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteNumberValue(numberBody);
                request.Content = content;
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
        /// <summary> Get small decimal value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetSmallDecimalAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_number.GetSmallDecimal");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/number/small/decimal/2.5976931e-101", false);
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
    }
}
