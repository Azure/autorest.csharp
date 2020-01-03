// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using header.Models.V100;

namespace header
{
    internal partial class HeaderOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        public HeaderOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateParamExistingKeyRequest(string userAgent)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/param/existingkey", false);
            request.Headers.Add("User-Agent", userAgent);
            return message;
        }
        public async ValueTask<Response> ParamExistingKeyAsync(string userAgent, CancellationToken cancellationToken = default)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ParamExistingKey");
            scope.Start();
            try
            {
                using var message = CreateParamExistingKeyRequest(userAgent);
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
        internal HttpMessage CreateResponseExistingKeyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/response/existingkey", false);
            return message;
        }
        public async ValueTask<ResponseWithHeaders<ResponseExistingKeyHeaders>> ResponseExistingKeyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseExistingKey");
            scope.Start();
            try
            {
                using var message = CreateResponseExistingKeyRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseExistingKeyHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamProtectedKeyRequest(string contentType)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/param/protectedkey", false);
            request.Headers.Add("Content-Type", contentType);
            return message;
        }
        public async ValueTask<Response> ParamProtectedKeyAsync(string contentType, CancellationToken cancellationToken = default)
        {
            if (contentType == null)
            {
                throw new ArgumentNullException(nameof(contentType));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ParamProtectedKey");
            scope.Start();
            try
            {
                using var message = CreateParamProtectedKeyRequest(contentType);
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
        internal HttpMessage CreateResponseProtectedKeyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/response/protectedkey", false);
            return message;
        }
        public async ValueTask<ResponseWithHeaders<ResponseProtectedKeyHeaders>> ResponseProtectedKeyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseProtectedKey");
            scope.Start();
            try
            {
                using var message = CreateResponseProtectedKeyRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseProtectedKeyHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamIntegerRequest(string scenario, int value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/param/prim/integer", false);
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            return message;
        }
        public async ValueTask<Response> ParamIntegerAsync(string scenario, int value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ParamInteger");
            scope.Start();
            try
            {
                using var message = CreateParamIntegerRequest(scenario, value);
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
        internal HttpMessage CreateResponseIntegerRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/response/prim/integer", false);
            request.Headers.Add("scenario", scenario);
            return message;
        }
        public async ValueTask<ResponseWithHeaders<ResponseIntegerHeaders>> ResponseIntegerAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseInteger");
            scope.Start();
            try
            {
                using var message = CreateResponseIntegerRequest(scenario);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseIntegerHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamLongRequest(string scenario, long value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/param/prim/long", false);
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            return message;
        }
        public async ValueTask<Response> ParamLongAsync(string scenario, long value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ParamLong");
            scope.Start();
            try
            {
                using var message = CreateParamLongRequest(scenario, value);
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
        internal HttpMessage CreateResponseLongRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/response/prim/long", false);
            request.Headers.Add("scenario", scenario);
            return message;
        }
        public async ValueTask<ResponseWithHeaders<ResponseLongHeaders>> ResponseLongAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseLong");
            scope.Start();
            try
            {
                using var message = CreateResponseLongRequest(scenario);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseLongHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamFloatRequest(string scenario, float value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/param/prim/float", false);
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            return message;
        }
        public async ValueTask<Response> ParamFloatAsync(string scenario, float value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ParamFloat");
            scope.Start();
            try
            {
                using var message = CreateParamFloatRequest(scenario, value);
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
        internal HttpMessage CreateResponseFloatRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/response/prim/float", false);
            request.Headers.Add("scenario", scenario);
            return message;
        }
        public async ValueTask<ResponseWithHeaders<ResponseFloatHeaders>> ResponseFloatAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseFloat");
            scope.Start();
            try
            {
                using var message = CreateResponseFloatRequest(scenario);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseFloatHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamDoubleRequest(string scenario, double value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/param/prim/double", false);
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            return message;
        }
        public async ValueTask<Response> ParamDoubleAsync(string scenario, double value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ParamDouble");
            scope.Start();
            try
            {
                using var message = CreateParamDoubleRequest(scenario, value);
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
        internal HttpMessage CreateResponseDoubleRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/response/prim/double", false);
            request.Headers.Add("scenario", scenario);
            return message;
        }
        public async ValueTask<ResponseWithHeaders<ResponseDoubleHeaders>> ResponseDoubleAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseDouble");
            scope.Start();
            try
            {
                using var message = CreateResponseDoubleRequest(scenario);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseDoubleHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamBoolRequest(string scenario, bool value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/param/prim/bool", false);
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            return message;
        }
        public async ValueTask<Response> ParamBoolAsync(string scenario, bool value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ParamBool");
            scope.Start();
            try
            {
                using var message = CreateParamBoolRequest(scenario, value);
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
        internal HttpMessage CreateResponseBoolRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/response/prim/bool", false);
            request.Headers.Add("scenario", scenario);
            return message;
        }
        public async ValueTask<ResponseWithHeaders<ResponseBoolHeaders>> ResponseBoolAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseBool");
            scope.Start();
            try
            {
                using var message = CreateResponseBoolRequest(scenario);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseBoolHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamStringRequest(string scenario, string? value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/param/prim/string", false);
            request.Headers.Add("scenario", scenario);
            if (value != null)
            {
                request.Headers.Add("value", value);
            }
            return message;
        }
        public async ValueTask<Response> ParamStringAsync(string scenario, string? value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ParamString");
            scope.Start();
            try
            {
                using var message = CreateParamStringRequest(scenario, value);
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
        internal HttpMessage CreateResponseStringRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/response/prim/string", false);
            request.Headers.Add("scenario", scenario);
            return message;
        }
        public async ValueTask<ResponseWithHeaders<ResponseStringHeaders>> ResponseStringAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseString");
            scope.Start();
            try
            {
                using var message = CreateResponseStringRequest(scenario);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseStringHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamDateRequest(string scenario, DateTimeOffset value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/param/prim/date", false);
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value, "D");
            return message;
        }
        public async ValueTask<Response> ParamDateAsync(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ParamDate");
            scope.Start();
            try
            {
                using var message = CreateParamDateRequest(scenario, value);
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
        internal HttpMessage CreateResponseDateRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/response/prim/date", false);
            request.Headers.Add("scenario", scenario);
            return message;
        }
        public async ValueTask<ResponseWithHeaders<ResponseDateHeaders>> ResponseDateAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseDate");
            scope.Start();
            try
            {
                using var message = CreateResponseDateRequest(scenario);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseDateHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamDatetimeRequest(string scenario, DateTimeOffset value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/param/prim/datetime", false);
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value, "S");
            return message;
        }
        public async ValueTask<Response> ParamDatetimeAsync(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ParamDatetime");
            scope.Start();
            try
            {
                using var message = CreateParamDatetimeRequest(scenario, value);
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
        internal HttpMessage CreateResponseDatetimeRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/response/prim/datetime", false);
            request.Headers.Add("scenario", scenario);
            return message;
        }
        public async ValueTask<ResponseWithHeaders<ResponseDatetimeHeaders>> ResponseDatetimeAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseDatetime");
            scope.Start();
            try
            {
                using var message = CreateResponseDatetimeRequest(scenario);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseDatetimeHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamDatetimeRfc1123Request(string scenario, DateTimeOffset? value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/param/prim/datetimerfc1123", false);
            request.Headers.Add("scenario", scenario);
            if (value != null)
            {
                request.Headers.Add("value", value.Value, "R");
            }
            return message;
        }
        public async ValueTask<Response> ParamDatetimeRfc1123Async(string scenario, DateTimeOffset? value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ParamDatetimeRfc1123");
            scope.Start();
            try
            {
                using var message = CreateParamDatetimeRfc1123Request(scenario, value);
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
        internal HttpMessage CreateResponseDatetimeRfc1123Request(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/response/prim/datetimerfc1123", false);
            request.Headers.Add("scenario", scenario);
            return message;
        }
        public async ValueTask<ResponseWithHeaders<ResponseDatetimeRfc1123Headers>> ResponseDatetimeRfc1123Async(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseDatetimeRfc1123");
            scope.Start();
            try
            {
                using var message = CreateResponseDatetimeRfc1123Request(scenario);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseDatetimeRfc1123Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamDurationRequest(string scenario, TimeSpan value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/param/prim/duration", false);
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value, "P");
            return message;
        }
        public async ValueTask<Response> ParamDurationAsync(string scenario, TimeSpan value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ParamDuration");
            scope.Start();
            try
            {
                using var message = CreateParamDurationRequest(scenario, value);
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
        internal HttpMessage CreateResponseDurationRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/response/prim/duration", false);
            request.Headers.Add("scenario", scenario);
            return message;
        }
        public async ValueTask<ResponseWithHeaders<ResponseDurationHeaders>> ResponseDurationAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseDuration");
            scope.Start();
            try
            {
                using var message = CreateResponseDurationRequest(scenario);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseDurationHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamByteRequest(string scenario, byte[] value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/param/prim/byte", false);
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            return message;
        }
        public async ValueTask<Response> ParamByteAsync(string scenario, byte[] value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ParamByte");
            scope.Start();
            try
            {
                using var message = CreateParamByteRequest(scenario, value);
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
        internal HttpMessage CreateResponseByteRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/response/prim/byte", false);
            request.Headers.Add("scenario", scenario);
            return message;
        }
        public async ValueTask<ResponseWithHeaders<ResponseByteHeaders>> ResponseByteAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseByte");
            scope.Start();
            try
            {
                using var message = CreateResponseByteRequest(scenario);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseByteHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamEnumRequest(string scenario, GreyscaleColors? value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/param/prim/enum", false);
            request.Headers.Add("scenario", scenario);
            if (value != null)
            {
                request.Headers.Add("value", value.Value);
            }
            return message;
        }
        public async ValueTask<Response> ParamEnumAsync(string scenario, GreyscaleColors? value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ParamEnum");
            scope.Start();
            try
            {
                using var message = CreateParamEnumRequest(scenario, value);
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
        internal HttpMessage CreateResponseEnumRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/response/prim/enum", false);
            request.Headers.Add("scenario", scenario);
            return message;
        }
        public async ValueTask<ResponseWithHeaders<ResponseEnumHeaders>> ResponseEnumAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseEnum");
            scope.Start();
            try
            {
                using var message = CreateResponseEnumRequest(scenario);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseEnumHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateCustomRequestIdRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/header/custom/x-ms-client-request-id/9C4D50EE-2D56-4CD3-8152-34347DC9F2B0", false);
            return message;
        }
        public async ValueTask<Response> CustomRequestIdAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("HeaderOperations.CustomRequestId");
            scope.Start();
            try
            {
                using var message = CreateCustomRequestIdRequest();
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
    }
}
