// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace body_datetime_rfc1123
{
    internal partial class Datetimerfc1123Operations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of Datetimerfc1123Operations. </summary>
        public Datetimerfc1123Operations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
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
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/datetimerfc1123/null", false);
            return message;
        }
        /// <summary> Get null datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.GetNull");
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
                            var value = document.RootElement.GetDateTimeOffset("R");
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
        /// <summary> Get null datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.GetNull");
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
                            var value = document.RootElement.GetDateTimeOffset("R");
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
        internal HttpMessage CreateGetInvalidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/datetimerfc1123/invalid", false);
            return message;
        }
        /// <summary> Get invalid datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.GetInvalid");
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
                            var value = document.RootElement.GetDateTimeOffset("R");
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
        /// <summary> Get invalid datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetInvalid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.GetInvalid");
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
                            var value = document.RootElement.GetDateTimeOffset("R");
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
        internal HttpMessage CreateGetOverflowRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/datetimerfc1123/overflow", false);
            return message;
        }
        /// <summary> Get overflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetOverflowAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.GetOverflow");
            scope.Start();
            try
            {
                using var message = CreateGetOverflowRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("R");
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
        /// <summary> Get overflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetOverflow(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.GetOverflow");
            scope.Start();
            try
            {
                using var message = CreateGetOverflowRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDateTimeOffset("R");
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
        internal HttpMessage CreateGetUnderflowRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/datetimerfc1123/underflow", false);
            return message;
        }
        /// <summary> Get underflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetUnderflowAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.GetUnderflow");
            scope.Start();
            try
            {
                using var message = CreateGetUnderflowRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("R");
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
        /// <summary> Get underflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUnderflow(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.GetUnderflow");
            scope.Start();
            try
            {
                using var message = CreateGetUnderflowRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDateTimeOffset("R");
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
        internal HttpMessage CreatePutUtcMaxDateTimeRequest(DateTimeOffset datetimeBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/datetimerfc1123/max", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "R");
            request.Content = content;
            return message;
        }
        /// <summary> Put max datetime value Fri, 31 Dec 9999 23:59:59 GMT. </summary>
        /// <param name="datetimeBody"> The date-time to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutUtcMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.PutUtcMaxDateTime");
            scope.Start();
            try
            {
                using var message = CreatePutUtcMaxDateTimeRequest(datetimeBody);
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
        /// <summary> Put max datetime value Fri, 31 Dec 9999 23:59:59 GMT. </summary>
        /// <param name="datetimeBody"> The date-time to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutUtcMaxDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.PutUtcMaxDateTime");
            scope.Start();
            try
            {
                using var message = CreatePutUtcMaxDateTimeRequest(datetimeBody);
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
        internal HttpMessage CreateGetUtcLowercaseMaxDateTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/datetimerfc1123/max/lowercase", false);
            return message;
        }
        /// <summary> Get max datetime value fri, 31 dec 9999 23:59:59 gmt. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetUtcLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.GetUtcLowercaseMaxDateTime");
            scope.Start();
            try
            {
                using var message = CreateGetUtcLowercaseMaxDateTimeRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("R");
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
        /// <summary> Get max datetime value fri, 31 dec 9999 23:59:59 gmt. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUtcLowercaseMaxDateTime(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.GetUtcLowercaseMaxDateTime");
            scope.Start();
            try
            {
                using var message = CreateGetUtcLowercaseMaxDateTimeRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDateTimeOffset("R");
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
        internal HttpMessage CreateGetUtcUppercaseMaxDateTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/datetimerfc1123/max/uppercase", false);
            return message;
        }
        /// <summary> Get max datetime value FRI, 31 DEC 9999 23:59:59 GMT. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetUtcUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.GetUtcUppercaseMaxDateTime");
            scope.Start();
            try
            {
                using var message = CreateGetUtcUppercaseMaxDateTimeRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("R");
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
        /// <summary> Get max datetime value FRI, 31 DEC 9999 23:59:59 GMT. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUtcUppercaseMaxDateTime(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.GetUtcUppercaseMaxDateTime");
            scope.Start();
            try
            {
                using var message = CreateGetUtcUppercaseMaxDateTimeRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDateTimeOffset("R");
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
        internal HttpMessage CreatePutUtcMinDateTimeRequest(DateTimeOffset datetimeBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/datetimerfc1123/min", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "R");
            request.Content = content;
            return message;
        }
        /// <summary> Put min datetime value Mon, 1 Jan 0001 00:00:00 GMT. </summary>
        /// <param name="datetimeBody"> The date-time to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutUtcMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.PutUtcMinDateTime");
            scope.Start();
            try
            {
                using var message = CreatePutUtcMinDateTimeRequest(datetimeBody);
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
        /// <summary> Put min datetime value Mon, 1 Jan 0001 00:00:00 GMT. </summary>
        /// <param name="datetimeBody"> The date-time to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutUtcMinDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.PutUtcMinDateTime");
            scope.Start();
            try
            {
                using var message = CreatePutUtcMinDateTimeRequest(datetimeBody);
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
        internal HttpMessage CreateGetUtcMinDateTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/datetimerfc1123/min", false);
            return message;
        }
        /// <summary> Get min datetime value Mon, 1 Jan 0001 00:00:00 GMT. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetUtcMinDateTimeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.GetUtcMinDateTime");
            scope.Start();
            try
            {
                using var message = CreateGetUtcMinDateTimeRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("R");
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
        /// <summary> Get min datetime value Mon, 1 Jan 0001 00:00:00 GMT. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUtcMinDateTime(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("Datetimerfc1123Operations.GetUtcMinDateTime");
            scope.Start();
            try
            {
                using var message = CreateGetUtcMinDateTimeRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDateTimeOffset("R");
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
