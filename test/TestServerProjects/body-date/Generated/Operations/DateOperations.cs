// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace body_date
{
    internal partial class DateOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of DateOperations. </summary>
        public DateOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
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
            request.Uri.AppendPath("/date/null", false);
            return message;
        }
        /// <summary> Get null date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.GetNull");
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
                            var value = document.RootElement.GetDateTimeOffset("D");
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
        /// <summary> Get null date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.GetNull");
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
                            var value = document.RootElement.GetDateTimeOffset("D");
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
        internal HttpMessage CreateGetInvalidDateRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/date/invaliddate", false);
            return message;
        }
        /// <summary> Get invalid date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetInvalidDateAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.GetInvalidDate");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidDateRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("D");
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
        /// <summary> Get invalid date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetInvalidDate(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.GetInvalidDate");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidDateRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDateTimeOffset("D");
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
        internal HttpMessage CreateGetOverflowDateRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/date/overflowdate", false);
            return message;
        }
        /// <summary> Get overflow date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetOverflowDateAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.GetOverflowDate");
            scope.Start();
            try
            {
                using var message = CreateGetOverflowDateRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("D");
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
        /// <summary> Get overflow date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetOverflowDate(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.GetOverflowDate");
            scope.Start();
            try
            {
                using var message = CreateGetOverflowDateRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDateTimeOffset("D");
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
        internal HttpMessage CreateGetUnderflowDateRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/date/underflowdate", false);
            return message;
        }
        /// <summary> Get underflow date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetUnderflowDateAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.GetUnderflowDate");
            scope.Start();
            try
            {
                using var message = CreateGetUnderflowDateRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("D");
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
        /// <summary> Get underflow date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUnderflowDate(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.GetUnderflowDate");
            scope.Start();
            try
            {
                using var message = CreateGetUnderflowDateRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDateTimeOffset("D");
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
        internal HttpMessage CreatePutMaxDateRequest(DateTimeOffset dateBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/date/max", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(dateBody, "D");
            request.Content = content;
            return message;
        }
        /// <summary> Put max date value 9999-12-31. </summary>
        /// <param name="dateBody"> The date to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutMaxDateAsync(DateTimeOffset dateBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.PutMaxDate");
            scope.Start();
            try
            {
                using var message = CreatePutMaxDateRequest(dateBody);
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
        /// <summary> Put max date value 9999-12-31. </summary>
        /// <param name="dateBody"> The date to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutMaxDate(DateTimeOffset dateBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.PutMaxDate");
            scope.Start();
            try
            {
                using var message = CreatePutMaxDateRequest(dateBody);
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
        internal HttpMessage CreateGetMaxDateRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/date/max", false);
            return message;
        }
        /// <summary> Get max date value 9999-12-31. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetMaxDateAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.GetMaxDate");
            scope.Start();
            try
            {
                using var message = CreateGetMaxDateRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("D");
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
        /// <summary> Get max date value 9999-12-31. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetMaxDate(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.GetMaxDate");
            scope.Start();
            try
            {
                using var message = CreateGetMaxDateRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDateTimeOffset("D");
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
        internal HttpMessage CreatePutMinDateRequest(DateTimeOffset dateBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/date/min", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(dateBody, "D");
            request.Content = content;
            return message;
        }
        /// <summary> Put min date value 0000-01-01. </summary>
        /// <param name="dateBody"> The date to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutMinDateAsync(DateTimeOffset dateBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.PutMinDate");
            scope.Start();
            try
            {
                using var message = CreatePutMinDateRequest(dateBody);
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
        /// <summary> Put min date value 0000-01-01. </summary>
        /// <param name="dateBody"> The date to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutMinDate(DateTimeOffset dateBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.PutMinDate");
            scope.Start();
            try
            {
                using var message = CreatePutMinDateRequest(dateBody);
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
        internal HttpMessage CreateGetMinDateRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/date/min", false);
            return message;
        }
        /// <summary> Get min date value 0000-01-01. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetMinDateAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.GetMinDate");
            scope.Start();
            try
            {
                using var message = CreateGetMinDateRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("D");
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
        /// <summary> Get min date value 0000-01-01. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetMinDate(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DateOperations.GetMinDate");
            scope.Start();
            try
            {
                using var message = CreateGetMinDateRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = document.RootElement.GetDateTimeOffset("D");
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
