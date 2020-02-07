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

namespace body_integer
{
    internal partial class IntOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of IntOperations. </summary>
        public IntOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
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
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/int/null", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null Int value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<int>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetNull");
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
                            var value = document.RootElement.GetInt32();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get null Int value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<int> GetNull(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetNull");
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
                            var value = document.RootElement.GetInt32();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetInvalidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/int/invalid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get invalid Int value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<int>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetInvalid");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetInt32();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get invalid Int value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<int> GetInvalid(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetInvalid");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetInt32();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetOverflowInt32Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/int/overflowint32", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get overflow Int32 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<int>> GetOverflowInt32Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetOverflowInt32");
            scope.Start();
            try
            {
                using var message = CreateGetOverflowInt32Request();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetInt32();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get overflow Int32 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<int> GetOverflowInt32(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetOverflowInt32");
            scope.Start();
            try
            {
                using var message = CreateGetOverflowInt32Request();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetInt32();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetUnderflowInt32Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/int/underflowint32", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get underflow Int32 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<int>> GetUnderflowInt32Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetUnderflowInt32");
            scope.Start();
            try
            {
                using var message = CreateGetUnderflowInt32Request();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetInt32();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get underflow Int32 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<int> GetUnderflowInt32(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetUnderflowInt32");
            scope.Start();
            try
            {
                using var message = CreateGetUnderflowInt32Request();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetInt32();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetOverflowInt64Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/int/overflowint64", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get overflow Int64 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<long>> GetOverflowInt64Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetOverflowInt64");
            scope.Start();
            try
            {
                using var message = CreateGetOverflowInt64Request();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetInt64();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get overflow Int64 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<long> GetOverflowInt64(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetOverflowInt64");
            scope.Start();
            try
            {
                using var message = CreateGetOverflowInt64Request();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetInt64();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetUnderflowInt64Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/int/underflowint64", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get underflow Int64 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<long>> GetUnderflowInt64Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetUnderflowInt64");
            scope.Start();
            try
            {
                using var message = CreateGetUnderflowInt64Request();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetInt64();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get underflow Int64 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<long> GetUnderflowInt64(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetUnderflowInt64");
            scope.Start();
            try
            {
                using var message = CreateGetUnderflowInt64Request();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetInt64();
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutMax32Request(int intBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/int/max/32", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(intBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put max int32 value. </summary>
        /// <param name="intBody"> The integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutMax32Async(int intBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("IntOperations.PutMax32");
            scope.Start();
            try
            {
                using var message = CreatePutMax32Request(intBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put max int32 value. </summary>
        /// <param name="intBody"> The integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutMax32(int intBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("IntOperations.PutMax32");
            scope.Start();
            try
            {
                using var message = CreatePutMax32Request(intBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutMax64Request(long intBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/int/max/64", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(intBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put max int64 value. </summary>
        /// <param name="intBody"> The integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutMax64Async(long intBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("IntOperations.PutMax64");
            scope.Start();
            try
            {
                using var message = CreatePutMax64Request(intBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put max int64 value. </summary>
        /// <param name="intBody"> The integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutMax64(long intBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("IntOperations.PutMax64");
            scope.Start();
            try
            {
                using var message = CreatePutMax64Request(intBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutMin32Request(int intBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/int/min/32", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(intBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put min int32 value. </summary>
        /// <param name="intBody"> The integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutMin32Async(int intBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("IntOperations.PutMin32");
            scope.Start();
            try
            {
                using var message = CreatePutMin32Request(intBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put min int32 value. </summary>
        /// <param name="intBody"> The integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutMin32(int intBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("IntOperations.PutMin32");
            scope.Start();
            try
            {
                using var message = CreatePutMin32Request(intBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutMin64Request(long intBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/int/min/64", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteNumberValue(intBody);
            request.Content = content;
            return message;
        }
        /// <summary> Put min int64 value. </summary>
        /// <param name="intBody"> The integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutMin64Async(long intBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("IntOperations.PutMin64");
            scope.Start();
            try
            {
                using var message = CreatePutMin64Request(intBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put min int64 value. </summary>
        /// <param name="intBody"> The integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutMin64(long intBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("IntOperations.PutMin64");
            scope.Start();
            try
            {
                using var message = CreatePutMin64Request(intBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetUnixTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/int/unixtime", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get datetime encoded as Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetUnixTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetUnixTime");
            scope.Start();
            try
            {
                using var message = CreateGetUnixTimeRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("U");
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get datetime encoded as Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUnixTime(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetUnixTime");
            scope.Start();
            try
            {
                using var message = CreateGetUnixTimeRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDateTimeOffset("U");
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutUnixTimeDateRequest(DateTimeOffset intBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/int/unixtime", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(intBody, "U");
            request.Content = content;
            return message;
        }
        /// <summary> Put datetime encoded as Unix time. </summary>
        /// <param name="intBody"> The unixtime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutUnixTimeDateAsync(DateTimeOffset intBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("IntOperations.PutUnixTimeDate");
            scope.Start();
            try
            {
                using var message = CreatePutUnixTimeDateRequest(intBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put datetime encoded as Unix time. </summary>
        /// <param name="intBody"> The unixtime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutUnixTimeDate(DateTimeOffset intBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("IntOperations.PutUnixTimeDate");
            scope.Start();
            try
            {
                using var message = CreatePutUnixTimeDateRequest(intBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetInvalidUnixTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/int/invalidunixtime", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get invalid Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetInvalidUnixTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetInvalidUnixTime");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidUnixTimeRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("U");
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get invalid Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetInvalidUnixTime(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetInvalidUnixTime");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidUnixTimeRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDateTimeOffset("U");
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetNullUnixTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/int/nullunixtime", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetNullUnixTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetNullUnixTime");
            scope.Start();
            try
            {
                using var message = CreateGetNullUnixTimeRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("U");
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get null Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetNullUnixTime(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IntOperations.GetNullUnixTime");
            scope.Start();
            try
            {
                using var message = CreateGetNullUnixTimeRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDateTimeOffset("U");
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
