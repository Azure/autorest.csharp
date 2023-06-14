// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using url.Models;

namespace url
{
    internal partial class PathsRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of PathsRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public PathsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateGetBooleanTrueRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/bool/true/", false);
            uri.AppendPath(true, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get true Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetBooleanTrueAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBooleanTrueRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get true Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetBooleanTrue(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBooleanTrueRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetBooleanFalseRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/bool/false/", false);
            uri.AppendPath(false, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get false Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetBooleanFalseAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBooleanFalseRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get false Boolean value on path. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetBooleanFalse(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBooleanFalseRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetIntOneMillionRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/int/1000000/", false);
            uri.AppendPath(1000000, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get '1000000' integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetIntOneMillionAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetIntOneMillionRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get '1000000' integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetIntOneMillion(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetIntOneMillionRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetIntNegativeOneMillionRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/int/-1000000/", false);
            uri.AppendPath(-1000000, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get '-1000000' integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetIntNegativeOneMillionAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetIntNegativeOneMillionRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get '-1000000' integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetIntNegativeOneMillion(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetIntNegativeOneMillionRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetTenBillionRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/long/10000000000/", false);
            uri.AppendPath(10000000000L, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get '10000000000' 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetTenBillionAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetTenBillionRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get '10000000000' 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetTenBillion(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetTenBillionRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetNegativeTenBillionRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/long/-10000000000/", false);
            uri.AppendPath(-10000000000L, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get '-10000000000' 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetNegativeTenBillionAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNegativeTenBillionRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get '-10000000000' 64 bit integer value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetNegativeTenBillion(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNegativeTenBillionRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateFloatScientificPositiveRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/float/1.034E+20/", false);
            uri.AppendPath(1.034E+20F, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get '1.034E+20' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> FloatScientificPositiveAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateFloatScientificPositiveRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get '1.034E+20' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response FloatScientificPositive(CancellationToken cancellationToken = default)
        {
            using var message = CreateFloatScientificPositiveRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateFloatScientificNegativeRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/float/-1.034E-20/", false);
            uri.AppendPath(-1.034E-20F, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get '-1.034E-20' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> FloatScientificNegativeAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateFloatScientificNegativeRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get '-1.034E-20' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response FloatScientificNegative(CancellationToken cancellationToken = default)
        {
            using var message = CreateFloatScientificNegativeRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDoubleDecimalPositiveRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/double/9999999.999/", false);
            uri.AppendPath(9999999.999, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get '9999999.999' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> DoubleDecimalPositiveAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDoubleDecimalPositiveRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get '9999999.999' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DoubleDecimalPositive(CancellationToken cancellationToken = default)
        {
            using var message = CreateDoubleDecimalPositiveRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDoubleDecimalNegativeRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/double/-9999999.999/", false);
            uri.AppendPath(-9999999.999, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get '-9999999.999' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> DoubleDecimalNegativeAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDoubleDecimalNegativeRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get '-9999999.999' numeric value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DoubleDecimalNegative(CancellationToken cancellationToken = default)
        {
            using var message = CreateDoubleDecimalNegativeRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateStringUnicodeRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/string/unicode/", false);
            uri.AppendPath("啊齄丂狛狜隣郎隣兀﨩", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get '啊齄丂狛狜隣郎隣兀﨩' multi-byte string value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> StringUnicodeAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateStringUnicodeRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get '啊齄丂狛狜隣郎隣兀﨩' multi-byte string value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringUnicode(CancellationToken cancellationToken = default)
        {
            using var message = CreateStringUnicodeRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateStringUrlEncodedRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/string/begin%21%2A%27%28%29%3B%3A%40%20%26%3D%2B%24%2C%2F%3F%23%5B%5Dend/", false);
            uri.AppendPath("begin!*'();:@ &=+$,/?#[]end", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get 'begin!*'();:@ &amp;=+$,/?#[]end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> StringUrlEncodedAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateStringUrlEncodedRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get 'begin!*'();:@ &amp;=+$,/?#[]end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringUrlEncoded(CancellationToken cancellationToken = default)
        {
            using var message = CreateStringUrlEncodedRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateStringUrlNonEncodedRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/string/begin!*'();:@&=+$,end/", false);
            uri.AppendPath("begin!*'();:@&=+$,end", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get 'begin!*'();:@&amp;=+$,end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> https://tools.ietf.org/html/rfc3986#appendix-A 'path' accept any 'pchar' not encoded. </remarks>
        public async Task<Response> StringUrlNonEncodedAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateStringUrlNonEncodedRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get 'begin!*'();:@&amp;=+$,end. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> https://tools.ietf.org/html/rfc3986#appendix-A 'path' accept any 'pchar' not encoded. </remarks>
        public Response StringUrlNonEncoded(CancellationToken cancellationToken = default)
        {
            using var message = CreateStringUrlNonEncodedRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateStringEmptyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/string/empty/", false);
            uri.AppendPath("", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get ''. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> StringEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateStringEmptyRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get ''. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringEmpty(CancellationToken cancellationToken = default)
        {
            using var message = CreateStringEmptyRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateStringNullRequest(string stringPath)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/string/null/", false);
            uri.AppendPath(stringPath, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null (should throw). </summary>
        /// <param name="stringPath"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="stringPath"/> is null. </exception>
        public async Task<Response> StringNullAsync(string stringPath, CancellationToken cancellationToken = default)
        {
            if (stringPath == null)
            {
                throw new ArgumentNullException(nameof(stringPath));
            }

            using var message = CreateStringNullRequest(stringPath);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 400:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null (should throw). </summary>
        /// <param name="stringPath"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="stringPath"/> is null. </exception>
        public Response StringNull(string stringPath, CancellationToken cancellationToken = default)
        {
            if (stringPath == null)
            {
                throw new ArgumentNullException(nameof(stringPath));
            }

            using var message = CreateStringNullRequest(stringPath);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 400:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateEnumValidRequest(UriColor enumPath)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/enum/green%20color/", false);
            uri.AppendPath(enumPath.ToSerialString(), true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get using uri with 'green color' in path parameter. </summary>
        /// <param name="enumPath"> send the value green. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> EnumValidAsync(UriColor enumPath, CancellationToken cancellationToken = default)
        {
            using var message = CreateEnumValidRequest(enumPath);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get using uri with 'green color' in path parameter. </summary>
        /// <param name="enumPath"> send the value green. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response EnumValid(UriColor enumPath, CancellationToken cancellationToken = default)
        {
            using var message = CreateEnumValidRequest(enumPath);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateEnumNullRequest(UriColor enumPath)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/string/null/", false);
            uri.AppendPath(enumPath.ToSerialString(), true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null (should throw on the client before the request is sent on wire). </summary>
        /// <param name="enumPath"> send null should throw. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> EnumNullAsync(UriColor enumPath, CancellationToken cancellationToken = default)
        {
            using var message = CreateEnumNullRequest(enumPath);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 400:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null (should throw on the client before the request is sent on wire). </summary>
        /// <param name="enumPath"> send null should throw. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response EnumNull(UriColor enumPath, CancellationToken cancellationToken = default)
        {
            using var message = CreateEnumNullRequest(enumPath);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 400:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateByteMultiByteRequest(byte[] bytePath)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/byte/multibyte/", false);
            uri.AppendPath(bytePath, "D", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </summary>
        /// <param name="bytePath"> '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bytePath"/> is null. </exception>
        public async Task<Response> ByteMultiByteAsync(byte[] bytePath, CancellationToken cancellationToken = default)
        {
            if (bytePath == null)
            {
                throw new ArgumentNullException(nameof(bytePath));
            }

            using var message = CreateByteMultiByteRequest(bytePath);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </summary>
        /// <param name="bytePath"> '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bytePath"/> is null. </exception>
        public Response ByteMultiByte(byte[] bytePath, CancellationToken cancellationToken = default)
        {
            if (bytePath == null)
            {
                throw new ArgumentNullException(nameof(bytePath));
            }

            using var message = CreateByteMultiByteRequest(bytePath);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateByteEmptyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/byte/empty/", false);
            uri.AppendPath(new byte[] { }, "D", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get '' as byte array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> ByteEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateByteEmptyRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get '' as byte array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ByteEmpty(CancellationToken cancellationToken = default)
        {
            using var message = CreateByteEmptyRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateByteNullRequest(byte[] bytePath)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/byte/null/", false);
            uri.AppendPath(bytePath, "D", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null as byte array (should throw). </summary>
        /// <param name="bytePath"> null as byte array (should throw). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bytePath"/> is null. </exception>
        public async Task<Response> ByteNullAsync(byte[] bytePath, CancellationToken cancellationToken = default)
        {
            if (bytePath == null)
            {
                throw new ArgumentNullException(nameof(bytePath));
            }

            using var message = CreateByteNullRequest(bytePath);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 400:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null as byte array (should throw). </summary>
        /// <param name="bytePath"> null as byte array (should throw). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bytePath"/> is null. </exception>
        public Response ByteNull(byte[] bytePath, CancellationToken cancellationToken = default)
        {
            if (bytePath == null)
            {
                throw new ArgumentNullException(nameof(bytePath));
            }

            using var message = CreateByteNullRequest(bytePath);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 400:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDateValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/date/2012-01-01/", false);
            uri.AppendPath(new DateTimeOffset(2012, 1, 1, 0, 0, 0, 0, TimeSpan.Zero), "D", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get '2012-01-01' as date. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> DateValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDateValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get '2012-01-01' as date. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateDateValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDateNullRequest(DateTimeOffset datePath)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/date/null/", false);
            uri.AppendPath(datePath, "D", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null as date - this should throw or be unusable on the client side, depending on date representation. </summary>
        /// <param name="datePath"> null as date (should throw). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> DateNullAsync(DateTimeOffset datePath, CancellationToken cancellationToken = default)
        {
            using var message = CreateDateNullRequest(datePath);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 400:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null as date - this should throw or be unusable on the client side, depending on date representation. </summary>
        /// <param name="datePath"> null as date (should throw). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateNull(DateTimeOffset datePath, CancellationToken cancellationToken = default)
        {
            using var message = CreateDateNullRequest(datePath);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 400:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDateTimeValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/datetime/2012-01-01T01%3A01%3A01Z/", false);
            uri.AppendPath(new DateTimeOffset(2012, 1, 1, 1, 1, 1, 0, TimeSpan.Zero), "O", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get '2012-01-01T01:01:01Z' as date-time. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> DateTimeValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateDateTimeValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get '2012-01-01T01:01:01Z' as date-time. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateTimeValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateDateTimeValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDateTimeNullRequest(DateTimeOffset dateTimePath)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/datetime/null/", false);
            uri.AppendPath(dateTimePath, "O", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null as date-time, should be disallowed or throw depending on representation of date-time. </summary>
        /// <param name="dateTimePath"> null as date-time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> DateTimeNullAsync(DateTimeOffset dateTimePath, CancellationToken cancellationToken = default)
        {
            using var message = CreateDateTimeNullRequest(dateTimePath);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 400:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null as date-time, should be disallowed or throw depending on representation of date-time. </summary>
        /// <param name="dateTimePath"> null as date-time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateTimeNull(DateTimeOffset dateTimePath, CancellationToken cancellationToken = default)
        {
            using var message = CreateDateTimeNullRequest(dateTimePath);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 400:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateBase64UrlRequest(byte[] base64UrlPath)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/string/bG9yZW0/", false);
            uri.AppendPath(base64UrlPath, "U", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get 'lorem' encoded value as 'bG9yZW0' (base64url). </summary>
        /// <param name="base64UrlPath"> base64url encoded value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="base64UrlPath"/> is null. </exception>
        public async Task<Response> Base64UrlAsync(byte[] base64UrlPath, CancellationToken cancellationToken = default)
        {
            if (base64UrlPath == null)
            {
                throw new ArgumentNullException(nameof(base64UrlPath));
            }

            using var message = CreateBase64UrlRequest(base64UrlPath);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get 'lorem' encoded value as 'bG9yZW0' (base64url). </summary>
        /// <param name="base64UrlPath"> base64url encoded value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="base64UrlPath"/> is null. </exception>
        public Response Base64Url(byte[] base64UrlPath, CancellationToken cancellationToken = default)
        {
            if (base64UrlPath == null)
            {
                throw new ArgumentNullException(nameof(base64UrlPath));
            }

            using var message = CreateBase64UrlRequest(base64UrlPath);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateArrayCsvInPathRequest(IEnumerable<string> arrayPath)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/array/ArrayPath1%2cbegin%21%2A%27%28%29%3B%3A%40%20%26%3D%2B%24%2C%2F%3F%23%5B%5Dend%2c%2c/", false);
            uri.AppendPath(arrayPath, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an array of string ['ArrayPath1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </summary>
        /// <param name="arrayPath"> an array of string ['ArrayPath1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayPath"/> is null. </exception>
        public async Task<Response> ArrayCsvInPathAsync(IEnumerable<string> arrayPath, CancellationToken cancellationToken = default)
        {
            if (arrayPath == null)
            {
                throw new ArgumentNullException(nameof(arrayPath));
            }

            using var message = CreateArrayCsvInPathRequest(arrayPath);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an array of string ['ArrayPath1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </summary>
        /// <param name="arrayPath"> an array of string ['ArrayPath1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayPath"/> is null. </exception>
        public Response ArrayCsvInPath(IEnumerable<string> arrayPath, CancellationToken cancellationToken = default)
        {
            if (arrayPath == null)
            {
                throw new ArgumentNullException(nameof(arrayPath));
            }

            using var message = CreateArrayCsvInPathRequest(arrayPath);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateUnixTimeUrlRequest(DateTimeOffset unixTimeUrlPath)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/int/1460505600/", false);
            uri.AppendPath(unixTimeUrlPath, "U", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get the date 2016-04-13 encoded value as '1460505600' (Unix time). </summary>
        /// <param name="unixTimeUrlPath"> Unix time encoded value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> UnixTimeUrlAsync(DateTimeOffset unixTimeUrlPath, CancellationToken cancellationToken = default)
        {
            using var message = CreateUnixTimeUrlRequest(unixTimeUrlPath);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get the date 2016-04-13 encoded value as '1460505600' (Unix time). </summary>
        /// <param name="unixTimeUrlPath"> Unix time encoded value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response UnixTimeUrl(DateTimeOffset unixTimeUrlPath, CancellationToken cancellationToken = default)
        {
            using var message = CreateUnixTimeUrlRequest(unixTimeUrlPath);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
