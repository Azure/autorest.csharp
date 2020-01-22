// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using header.Models;

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
        internal HttpMessage CreateParamExistingKeyRequest(string userAgent)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/param/existingkey", false);
            request.Uri = uri;
            request.Headers.Add("User-Agent", userAgent);
            return message;
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
        /// <summary> Send a post request with header value &quot;User-Agent&quot;: &quot;overwrite&quot;. </summary>
        /// <param name="userAgent"> Send a post request with header value &quot;User-Agent&quot;: &quot;overwrite&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamExistingKey(string userAgent, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateResponseExistingKeyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/response/existingkey", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get a response with header value &quot;User-Agent&quot;: &quot;overwrite&quot;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <summary> Get a response with header value &quot;User-Agent&quot;: &quot;overwrite&quot;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ResponseExistingKeyHeaders> ResponseExistingKey(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseExistingKey");
            scope.Start();
            try
            {
                using var message = CreateResponseExistingKeyRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseExistingKeyHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamProtectedKeyRequest(string contentType)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/param/protectedkey", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", contentType);
            return message;
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
        /// <summary> Send a post request with header value &quot;Content-Type&quot;: &quot;text/html&quot;. </summary>
        /// <param name="contentType"> Send a post request with header value &quot;Content-Type&quot;: &quot;text/html&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamProtectedKey(string contentType, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateResponseProtectedKeyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/response/protectedkey", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get a response with header value &quot;Content-Type&quot;: &quot;text/html&quot;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <summary> Get a response with header value &quot;Content-Type&quot;: &quot;text/html&quot;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ResponseProtectedKeyHeaders> ResponseProtectedKey(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HeaderOperations.ResponseProtectedKey");
            scope.Start();
            try
            {
                using var message = CreateResponseProtectedKeyRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseProtectedKeyHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamIntegerRequest(string scenario, int value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/param/prim/integer", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            return message;
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 1 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 1 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 1 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 1 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamInteger(string scenario, int value, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateResponseIntegerRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/response/prim/integer", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            return message;
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
        /// <summary> Get a response with header value &quot;value&quot;: 1 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ResponseIntegerHeaders> ResponseInteger(string scenario, CancellationToken cancellationToken = default)
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
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseIntegerHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamLongRequest(string scenario, long value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/param/prim/long", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            return message;
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 105 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 105 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 105 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 105 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamLong(string scenario, long value, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateResponseLongRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/response/prim/long", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            return message;
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
        /// <summary> Get a response with header value &quot;value&quot;: 105 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ResponseLongHeaders> ResponseLong(string scenario, CancellationToken cancellationToken = default)
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
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseLongHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamFloatRequest(string scenario, float value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/param/prim/float", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            return message;
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 0.07 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 0.07 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 0.07 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 0.07 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamFloat(string scenario, float value, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateResponseFloatRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/response/prim/float", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            return message;
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
        /// <summary> Get a response with header value &quot;value&quot;: 0.07 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ResponseFloatHeaders> ResponseFloat(string scenario, CancellationToken cancellationToken = default)
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
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseFloatHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamDoubleRequest(string scenario, double value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/param/prim/double", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            return message;
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 7e120 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 7e120 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 7e120 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 7e120 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamDouble(string scenario, double value, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateResponseDoubleRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/response/prim/double", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            return message;
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
        /// <summary> Get a response with header value &quot;value&quot;: 7e120 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ResponseDoubleHeaders> ResponseDouble(string scenario, CancellationToken cancellationToken = default)
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
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseDoubleHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamBoolRequest(string scenario, bool value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/param/prim/bool", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            return message;
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;true&quot;, &quot;value&quot;: true or &quot;scenario&quot;: &quot;false&quot;, &quot;value&quot;: false. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values true or false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;true&quot;, &quot;value&quot;: true or &quot;scenario&quot;: &quot;false&quot;, &quot;value&quot;: false. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values true or false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamBool(string scenario, bool value, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateResponseBoolRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/response/prim/bool", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            return message;
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
        /// <summary> Get a response with header value &quot;value&quot;: true or false. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ResponseBoolHeaders> ResponseBool(string scenario, CancellationToken cancellationToken = default)
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
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseBoolHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamStringRequest(string scenario, string? value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/param/prim/string", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            if (value != null)
            {
                request.Headers.Add("value", value);
            }
            return message;
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;The quick brown fox jumps over the lazy dog&quot; or &quot;scenario&quot;: &quot;null&quot;, &quot;value&quot;: null or &quot;scenario&quot;: &quot;empty&quot;, &quot;value&quot;: &quot;&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;The quick brown fox jumps over the lazy dog&quot; or null or &quot;&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;The quick brown fox jumps over the lazy dog&quot; or &quot;scenario&quot;: &quot;null&quot;, &quot;value&quot;: null or &quot;scenario&quot;: &quot;empty&quot;, &quot;value&quot;: &quot;&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;The quick brown fox jumps over the lazy dog&quot; or null or &quot;&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamString(string scenario, string? value, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateResponseStringRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/response/prim/string", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            return message;
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
        /// <summary> Get a response with header values &quot;The quick brown fox jumps over the lazy dog&quot; or null or &quot;&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ResponseStringHeaders> ResponseString(string scenario, CancellationToken cancellationToken = default)
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
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseStringHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamDateRequest(string scenario, DateTimeOffset value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/param/prim/date", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value, "D");
            return message;
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;2010-01-01&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;0001-01-01&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;2010-01-01&quot; or &quot;0001-01-01&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;2010-01-01&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;0001-01-01&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;2010-01-01&quot; or &quot;0001-01-01&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamDate(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateResponseDateRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/response/prim/date", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            return message;
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
        /// <summary> Get a response with header values &quot;2010-01-01&quot; or &quot;0001-01-01&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ResponseDateHeaders> ResponseDate(string scenario, CancellationToken cancellationToken = default)
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
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseDateHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamDatetimeRequest(string scenario, DateTimeOffset value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/param/prim/datetime", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value, "S");
            return message;
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;2010-01-01T12:34:56Z&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;0001-01-01T00:00:00Z&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;2010-01-01T12:34:56Z&quot; or &quot;0001-01-01T00:00:00Z&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;2010-01-01T12:34:56Z&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;0001-01-01T00:00:00Z&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;2010-01-01T12:34:56Z&quot; or &quot;0001-01-01T00:00:00Z&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamDatetime(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateResponseDatetimeRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/response/prim/datetime", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            return message;
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
        /// <summary> Get a response with header values &quot;2010-01-01T12:34:56Z&quot; or &quot;0001-01-01T00:00:00Z&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ResponseDatetimeHeaders> ResponseDatetime(string scenario, CancellationToken cancellationToken = default)
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
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseDatetimeHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamDatetimeRfc1123Request(string scenario, DateTimeOffset? value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/param/prim/datetimerfc1123", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            if (value != null)
            {
                request.Headers.Add("value", value.Value, "R");
            }
            return message;
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;Wed, 01 Jan 2010 12:34:56 GMT&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;Mon, 01 Jan 0001 00:00:00 GMT&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;Wed, 01 Jan 2010 12:34:56 GMT&quot; or &quot;Mon, 01 Jan 0001 00:00:00 GMT&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;Wed, 01 Jan 2010 12:34:56 GMT&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;Mon, 01 Jan 0001 00:00:00 GMT&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;Wed, 01 Jan 2010 12:34:56 GMT&quot; or &quot;Mon, 01 Jan 0001 00:00:00 GMT&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamDatetimeRfc1123(string scenario, DateTimeOffset? value, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateResponseDatetimeRfc1123Request(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/response/prim/datetimerfc1123", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            return message;
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
        /// <summary> Get a response with header values &quot;Wed, 01 Jan 2010 12:34:56 GMT&quot; or &quot;Mon, 01 Jan 0001 00:00:00 GMT&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ResponseDatetimeRfc1123Headers> ResponseDatetimeRfc1123(string scenario, CancellationToken cancellationToken = default)
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
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseDatetimeRfc1123Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamDurationRequest(string scenario, TimeSpan value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/param/prim/duration", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value, "P");
            return message;
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;P123DT22H14M12.011S&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;P123DT22H14M12.011S&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;P123DT22H14M12.011S&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;P123DT22H14M12.011S&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamDuration(string scenario, TimeSpan value, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateResponseDurationRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/response/prim/duration", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            return message;
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
        /// <summary> Get a response with header values &quot;P123DT22H14M12.011S&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ResponseDurationHeaders> ResponseDuration(string scenario, CancellationToken cancellationToken = default)
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
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseDurationHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamByteRequest(string scenario, byte[] value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/param/prim/byte", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            return message;
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;啊齄丂狛狜隣郎隣兀﨩&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;啊齄丂狛狜隣郎隣兀﨩&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;啊齄丂狛狜隣郎隣兀﨩&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamByte(string scenario, byte[] value, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateResponseByteRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/response/prim/byte", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            return message;
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
        /// <summary> Get a response with header values &quot;啊齄丂狛狜隣郎隣兀﨩&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ResponseByteHeaders> ResponseByte(string scenario, CancellationToken cancellationToken = default)
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
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseByteHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateParamEnumRequest(string scenario, GreyscaleColors? value)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/param/prim/enum", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            if (value != null)
            {
                request.Headers.Add("value", value.Value);
            }
            return message;
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;GREY&quot; or &quot;scenario&quot;: &quot;null&quot;, &quot;value&quot;: null. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &apos;GREY&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;GREY&quot; or &quot;scenario&quot;: &quot;null&quot;, &quot;value&quot;: null. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &apos;GREY&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamEnum(string scenario, GreyscaleColors? value, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateResponseEnumRequest(string scenario)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/response/prim/enum", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            return message;
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
        /// <summary> Get a response with header values &quot;GREY&quot; or null. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ResponseEnumHeaders> ResponseEnum(string scenario, CancellationToken cancellationToken = default)
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
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new ResponseEnumHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
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
        internal HttpMessage CreateCustomRequestIdRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/header/custom/x-ms-client-request-id/9C4D50EE-2D56-4CD3-8152-34347DC9F2B0", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Send x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <summary> Send x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response CustomRequestId(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("HeaderOperations.CustomRequestId");
            scope.Start();
            try
            {
                using var message = CreateCustomRequestIdRequest();
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
    }
}
