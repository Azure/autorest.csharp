// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace body_datetime
{
    internal partial class DatetimeOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        public DatetimeOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
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
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/null", false);
            return message;
        }
        public async ValueTask<Response<DateTimeOffset>> GetNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.GetNull");
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
                            var value = document.RootElement.GetDateTimeOffset("S");
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
        internal HttpMessage CreateGetInvalidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/invalid", false);
            return message;
        }
        public async ValueTask<Response<DateTimeOffset>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.GetInvalid");
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
                            var value = document.RootElement.GetDateTimeOffset("S");
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
        internal HttpMessage CreateGetOverflowRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/overflow", false);
            return message;
        }
        public async ValueTask<Response<DateTimeOffset>> GetOverflowAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.GetOverflow");
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
                            var value = document.RootElement.GetDateTimeOffset("S");
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
        internal HttpMessage CreateGetUnderflowRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/underflow", false);
            return message;
        }
        public async ValueTask<Response<DateTimeOffset>> GetUnderflowAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.GetUnderflow");
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
                            var value = document.RootElement.GetDateTimeOffset("S");
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
        internal HttpMessage CreatePutUtcMaxDateTimeRequest(DateTimeOffset datetimeBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/max/utc", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "S");
            request.Content = content;
            return message;
        }
        public async ValueTask<Response> PutUtcMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.PutUtcMaxDateTime");
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
        internal HttpMessage CreateGetUtcLowercaseMaxDateTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/max/utc/lowercase", false);
            return message;
        }
        public async ValueTask<Response<DateTimeOffset>> GetUtcLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.GetUtcLowercaseMaxDateTime");
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
                            var value = document.RootElement.GetDateTimeOffset("S");
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
        internal HttpMessage CreateGetUtcUppercaseMaxDateTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/max/utc/uppercase", false);
            return message;
        }
        public async ValueTask<Response<DateTimeOffset>> GetUtcUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.GetUtcUppercaseMaxDateTime");
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
                            var value = document.RootElement.GetDateTimeOffset("S");
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
        internal HttpMessage CreatePutLocalPositiveOffsetMaxDateTimeRequest(DateTimeOffset datetimeBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/max/localpositiveoffset", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "S");
            request.Content = content;
            return message;
        }
        public async ValueTask<Response> PutLocalPositiveOffsetMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.PutLocalPositiveOffsetMaxDateTime");
            scope.Start();
            try
            {
                using var message = CreatePutLocalPositiveOffsetMaxDateTimeRequest(datetimeBody);
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
        internal HttpMessage CreateGetLocalPositiveOffsetLowercaseMaxDateTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/max/localpositiveoffset/lowercase", false);
            return message;
        }
        public async ValueTask<Response<DateTimeOffset>> GetLocalPositiveOffsetLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.GetLocalPositiveOffsetLowercaseMaxDateTime");
            scope.Start();
            try
            {
                using var message = CreateGetLocalPositiveOffsetLowercaseMaxDateTimeRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("S");
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
        internal HttpMessage CreateGetLocalPositiveOffsetUppercaseMaxDateTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/max/localpositiveoffset/uppercase", false);
            return message;
        }
        public async ValueTask<Response<DateTimeOffset>> GetLocalPositiveOffsetUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.GetLocalPositiveOffsetUppercaseMaxDateTime");
            scope.Start();
            try
            {
                using var message = CreateGetLocalPositiveOffsetUppercaseMaxDateTimeRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("S");
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
        internal HttpMessage CreatePutLocalNegativeOffsetMaxDateTimeRequest(DateTimeOffset datetimeBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/max/localnegativeoffset", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "S");
            request.Content = content;
            return message;
        }
        public async ValueTask<Response> PutLocalNegativeOffsetMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.PutLocalNegativeOffsetMaxDateTime");
            scope.Start();
            try
            {
                using var message = CreatePutLocalNegativeOffsetMaxDateTimeRequest(datetimeBody);
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
        internal HttpMessage CreateGetLocalNegativeOffsetUppercaseMaxDateTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/max/localnegativeoffset/uppercase", false);
            return message;
        }
        public async ValueTask<Response<DateTimeOffset>> GetLocalNegativeOffsetUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.GetLocalNegativeOffsetUppercaseMaxDateTime");
            scope.Start();
            try
            {
                using var message = CreateGetLocalNegativeOffsetUppercaseMaxDateTimeRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("S");
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
        internal HttpMessage CreateGetLocalNegativeOffsetLowercaseMaxDateTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/max/localnegativeoffset/lowercase", false);
            return message;
        }
        public async ValueTask<Response<DateTimeOffset>> GetLocalNegativeOffsetLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.GetLocalNegativeOffsetLowercaseMaxDateTime");
            scope.Start();
            try
            {
                using var message = CreateGetLocalNegativeOffsetLowercaseMaxDateTimeRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("S");
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
        internal HttpMessage CreatePutUtcMinDateTimeRequest(DateTimeOffset datetimeBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/min/utc", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "S");
            request.Content = content;
            return message;
        }
        public async ValueTask<Response> PutUtcMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.PutUtcMinDateTime");
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
        internal HttpMessage CreateGetUtcMinDateTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/min/utc", false);
            return message;
        }
        public async ValueTask<Response<DateTimeOffset>> GetUtcMinDateTimeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.GetUtcMinDateTime");
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
                            var value = document.RootElement.GetDateTimeOffset("S");
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
        internal HttpMessage CreatePutLocalPositiveOffsetMinDateTimeRequest(DateTimeOffset datetimeBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/min/localpositiveoffset", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "S");
            request.Content = content;
            return message;
        }
        public async ValueTask<Response> PutLocalPositiveOffsetMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.PutLocalPositiveOffsetMinDateTime");
            scope.Start();
            try
            {
                using var message = CreatePutLocalPositiveOffsetMinDateTimeRequest(datetimeBody);
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
        internal HttpMessage CreateGetLocalPositiveOffsetMinDateTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/min/localpositiveoffset", false);
            return message;
        }
        public async ValueTask<Response<DateTimeOffset>> GetLocalPositiveOffsetMinDateTimeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.GetLocalPositiveOffsetMinDateTime");
            scope.Start();
            try
            {
                using var message = CreateGetLocalPositiveOffsetMinDateTimeRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("S");
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
        internal HttpMessage CreatePutLocalNegativeOffsetMinDateTimeRequest(DateTimeOffset datetimeBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/min/localnegativeoffset", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(datetimeBody, "S");
            request.Content = content;
            return message;
        }
        public async ValueTask<Response> PutLocalNegativeOffsetMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.PutLocalNegativeOffsetMinDateTime");
            scope.Start();
            try
            {
                using var message = CreatePutLocalNegativeOffsetMinDateTimeRequest(datetimeBody);
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
        internal HttpMessage CreateGetLocalNegativeOffsetMinDateTimeRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/datetime/min/localnegativeoffset", false);
            return message;
        }
        public async ValueTask<Response<DateTimeOffset>> GetLocalNegativeOffsetMinDateTimeAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("DatetimeOperations.GetLocalNegativeOffsetMinDateTime");
            scope.Start();
            try
            {
                using var message = CreateGetLocalNegativeOffsetMinDateTimeRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = document.RootElement.GetDateTimeOffset("S");
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
