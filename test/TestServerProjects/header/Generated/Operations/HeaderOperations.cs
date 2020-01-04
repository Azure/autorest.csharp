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
        /// <summary> Initializes a new instance of HeaderOperations. </summary>
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
        /// <summary> Send a post request with header value &quot;User-Agent&quot;: &quot;overwrite&quot;. </summary>
        /// <param name="userAgent"> Send a post request with header value &quot;User-Agent&quot;: &quot;overwrite&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamExistingKeyAsync(string userAgent, CancellationToken cancellationToken = default)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            using var scope = clientDiagnostics.CreateScope("header.ParamExistingKey");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/existingkey", false);
                request.Headers.Add("User-Agent", userAgent);
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
        /// <summary> Get a response with header value &quot;User-Agent&quot;: &quot;overwrite&quot;. </summary>
        public async ValueTask<ResponseWithHeaders<ResponseExistingKeyHeaders>> ResponseExistingKeyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("header.ResponseExistingKey");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/existingkey", false);
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
        /// <summary> Send a post request with header value &quot;Content-Type&quot;: &quot;text/html&quot;. </summary>
        /// <param name="contentType"> Send a post request with header value &quot;Content-Type&quot;: &quot;text/html&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamProtectedKeyAsync(string contentType, CancellationToken cancellationToken = default)
        {
            if (contentType == null)
            {
                throw new ArgumentNullException(nameof(contentType));
            }

            using var scope = clientDiagnostics.CreateScope("header.ParamProtectedKey");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/protectedkey", false);
                request.Headers.Add("Content-Type", contentType);
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
        /// <summary> Get a response with header value &quot;Content-Type&quot;: &quot;text/html&quot;. </summary>
        public async ValueTask<ResponseWithHeaders<ResponseProtectedKeyHeaders>> ResponseProtectedKeyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("header.ResponseProtectedKey");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/protectedkey", false);
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 1 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="value"> Send a post request with header values 1 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamIntegerAsync(string scenario, int value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ParamInteger");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/integer", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value);
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
        /// <summary> Get a response with header value &quot;value&quot;: 1 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ResponseIntegerHeaders>> ResponseIntegerAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ResponseInteger");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/integer", false);
                request.Headers.Add("scenario", scenario);
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 105 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="value"> Send a post request with header values 105 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamLongAsync(string scenario, long value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ParamLong");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/long", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value);
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
        /// <summary> Get a response with header value &quot;value&quot;: 105 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ResponseLongHeaders>> ResponseLongAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ResponseLong");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/long", false);
                request.Headers.Add("scenario", scenario);
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 0.07 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="value"> Send a post request with header values 0.07 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamFloatAsync(string scenario, float value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ParamFloat");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/float", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value);
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
        /// <summary> Get a response with header value &quot;value&quot;: 0.07 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ResponseFloatHeaders>> ResponseFloatAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ResponseFloat");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/float", false);
                request.Headers.Add("scenario", scenario);
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 7e120 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="value"> Send a post request with header values 7e120 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamDoubleAsync(string scenario, double value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ParamDouble");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/double", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value);
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
        /// <summary> Get a response with header value &quot;value&quot;: 7e120 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ResponseDoubleHeaders>> ResponseDoubleAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ResponseDouble");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/double", false);
                request.Headers.Add("scenario", scenario);
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;true&quot;, &quot;value&quot;: true or &quot;scenario&quot;: &quot;false&quot;, &quot;value&quot;: false. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="value"> Send a post request with header values true or false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamBoolAsync(string scenario, bool value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ParamBool");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/bool", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value);
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
        /// <summary> Get a response with header value &quot;value&quot;: true or false. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ResponseBoolHeaders>> ResponseBoolAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ResponseBool");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/bool", false);
                request.Headers.Add("scenario", scenario);
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;The quick brown fox jumps over the lazy dog&quot; or &quot;scenario&quot;: &quot;null&quot;, &quot;value&quot;: null or &quot;scenario&quot;: &quot;empty&quot;, &quot;value&quot;: &quot;&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="value"> Send a post request with header values &quot;The quick brown fox jumps over the lazy dog&quot; or null or &quot;&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamStringAsync(string scenario, string? value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ParamString");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/string", false);
                request.Headers.Add("scenario", scenario);
                if (value != null)
                {
                    request.Headers.Add("value", value);
                }
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
        /// <summary> Get a response with header values &quot;The quick brown fox jumps over the lazy dog&quot; or null or &quot;&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ResponseStringHeaders>> ResponseStringAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ResponseString");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/string", false);
                request.Headers.Add("scenario", scenario);
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;2010-01-01&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;0001-01-01&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="value"> Send a post request with header values &quot;2010-01-01&quot; or &quot;0001-01-01&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamDateAsync(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ParamDate");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/date", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value, "D");
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
        /// <summary> Get a response with header values &quot;2010-01-01&quot; or &quot;0001-01-01&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ResponseDateHeaders>> ResponseDateAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ResponseDate");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/date", false);
                request.Headers.Add("scenario", scenario);
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;2010-01-01T12:34:56Z&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;0001-01-01T00:00:00Z&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="value"> Send a post request with header values &quot;2010-01-01T12:34:56Z&quot; or &quot;0001-01-01T00:00:00Z&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamDatetimeAsync(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ParamDatetime");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/datetime", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value, "S");
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
        /// <summary> Get a response with header values &quot;2010-01-01T12:34:56Z&quot; or &quot;0001-01-01T00:00:00Z&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ResponseDatetimeHeaders>> ResponseDatetimeAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ResponseDatetime");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/datetime", false);
                request.Headers.Add("scenario", scenario);
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;Wed, 01 Jan 2010 12:34:56 GMT&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;Mon, 01 Jan 0001 00:00:00 GMT&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="value"> Send a post request with header values &quot;Wed, 01 Jan 2010 12:34:56 GMT&quot; or &quot;Mon, 01 Jan 0001 00:00:00 GMT&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamDatetimeRfc1123Async(string scenario, DateTimeOffset? value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ParamDatetimeRfc1123");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/datetimerfc1123", false);
                request.Headers.Add("scenario", scenario);
                if (value != null)
                {
                    request.Headers.Add("value", value.Value, "R");
                }
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
        /// <summary> Get a response with header values &quot;Wed, 01 Jan 2010 12:34:56 GMT&quot; or &quot;Mon, 01 Jan 0001 00:00:00 GMT&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ResponseDatetimeRfc1123Headers>> ResponseDatetimeRfc1123Async(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ResponseDatetimeRfc1123");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/datetimerfc1123", false);
                request.Headers.Add("scenario", scenario);
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;P123DT22H14M12.011S&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="value"> Send a post request with header values &quot;P123DT22H14M12.011S&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamDurationAsync(string scenario, TimeSpan value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ParamDuration");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/duration", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value, "P");
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
        /// <summary> Get a response with header values &quot;P123DT22H14M12.011S&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ResponseDurationHeaders>> ResponseDurationAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ResponseDuration");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/duration", false);
                request.Headers.Add("scenario", scenario);
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;啊齄丂狛狜隣郎隣兀﨩&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="value"> Send a post request with header values &quot;啊齄丂狛狜隣郎隣兀﨩&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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

            using var scope = clientDiagnostics.CreateScope("header.ParamByte");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/byte", false);
                request.Headers.Add("scenario", scenario);
                request.Headers.Add("value", value);
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
        /// <summary> Get a response with header values &quot;啊齄丂狛狜隣郎隣兀﨩&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ResponseByteHeaders>> ResponseByteAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ResponseByte");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/byte", false);
                request.Headers.Add("scenario", scenario);
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;GREY&quot; or &quot;scenario&quot;: &quot;null&quot;, &quot;value&quot;: null. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="value"> Send a post request with header values &apos;GREY&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamEnumAsync(string scenario, GreyscaleColors? value, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ParamEnum");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/param/prim/enum", false);
                request.Headers.Add("scenario", scenario);
                if (value != null)
                {
                    request.Headers.Add("value", value.Value);
                }
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
        /// <summary> Get a response with header values &quot;GREY&quot; or null. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ResponseEnumHeaders>> ResponseEnumAsync(string scenario, CancellationToken cancellationToken = default)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            using var scope = clientDiagnostics.CreateScope("header.ResponseEnum");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/response/prim/enum", false);
                request.Headers.Add("scenario", scenario);
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
        /// <summary> Send x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request. </summary>
        public async ValueTask<Response> CustomRequestIdAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("header.CustomRequestId");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/header/custom/x-ms-client-request-id/9C4D50EE-2D56-4CD3-8152-34347DC9F2B0", false);
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
