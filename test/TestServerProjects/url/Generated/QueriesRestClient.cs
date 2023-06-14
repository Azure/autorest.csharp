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
    internal partial class QueriesRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of QueriesRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public QueriesRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
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
            uri.AppendPath("/queries/bool/true", false);
            uri.AppendQuery("boolQuery", true, true);
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
            uri.AppendPath("/queries/bool/false", false);
            uri.AppendQuery("boolQuery", false, true);
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

        internal HttpMessage CreateGetBooleanNullRequest(bool? boolQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/bool/null", false);
            if (boolQuery != null)
            {
                uri.AppendQuery("boolQuery", boolQuery.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null Boolean value on query (query string should be absent). </summary>
        /// <param name="boolQuery"> null boolean value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetBooleanNullAsync(bool? boolQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBooleanNullRequest(boolQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null Boolean value on query (query string should be absent). </summary>
        /// <param name="boolQuery"> null boolean value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetBooleanNull(bool? boolQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBooleanNullRequest(boolQuery);
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
            uri.AppendPath("/queries/int/1000000", false);
            uri.AppendQuery("intQuery", 1000000, true);
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
            uri.AppendPath("/queries/int/-1000000", false);
            uri.AppendQuery("intQuery", -1000000, true);
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

        internal HttpMessage CreateGetIntNullRequest(int? intQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/int/null", false);
            if (intQuery != null)
            {
                uri.AppendQuery("intQuery", intQuery.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null integer value (no query parameter). </summary>
        /// <param name="intQuery"> null integer value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetIntNullAsync(int? intQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetIntNullRequest(intQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null integer value (no query parameter). </summary>
        /// <param name="intQuery"> null integer value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetIntNull(int? intQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetIntNullRequest(intQuery);
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
            uri.AppendPath("/queries/long/10000000000", false);
            uri.AppendQuery("longQuery", 10000000000L, true);
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
            uri.AppendPath("/queries/long/-10000000000", false);
            uri.AppendQuery("longQuery", -10000000000L, true);
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

        internal HttpMessage CreateGetLongNullRequest(long? longQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/long/null", false);
            if (longQuery != null)
            {
                uri.AppendQuery("longQuery", longQuery.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get 'null 64 bit integer value (no query param in uri). </summary>
        /// <param name="longQuery"> null 64 bit integer value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetLongNullAsync(long? longQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLongNullRequest(longQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get 'null 64 bit integer value (no query param in uri). </summary>
        /// <param name="longQuery"> null 64 bit integer value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetLongNull(long? longQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLongNullRequest(longQuery);
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
            uri.AppendPath("/queries/float/1.034E+20", false);
            uri.AppendQuery("floatQuery", 1.034E+20F, true);
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
            uri.AppendPath("/queries/float/-1.034E-20", false);
            uri.AppendQuery("floatQuery", -1.034E-20F, true);
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

        internal HttpMessage CreateFloatNullRequest(float? floatQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/float/null", false);
            if (floatQuery != null)
            {
                uri.AppendQuery("floatQuery", floatQuery.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null numeric value (no query parameter). </summary>
        /// <param name="floatQuery"> null numeric value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> FloatNullAsync(float? floatQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateFloatNullRequest(floatQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null numeric value (no query parameter). </summary>
        /// <param name="floatQuery"> null numeric value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response FloatNull(float? floatQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateFloatNullRequest(floatQuery);
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
            uri.AppendPath("/queries/double/9999999.999", false);
            uri.AppendQuery("doubleQuery", 9999999.999, true);
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
            uri.AppendPath("/queries/double/-9999999.999", false);
            uri.AppendQuery("doubleQuery", -9999999.999, true);
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

        internal HttpMessage CreateDoubleNullRequest(double? doubleQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/double/null", false);
            if (doubleQuery != null)
            {
                uri.AppendQuery("doubleQuery", doubleQuery.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null numeric value (no query parameter). </summary>
        /// <param name="doubleQuery"> null numeric value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> DoubleNullAsync(double? doubleQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateDoubleNullRequest(doubleQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null numeric value (no query parameter). </summary>
        /// <param name="doubleQuery"> null numeric value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DoubleNull(double? doubleQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateDoubleNullRequest(doubleQuery);
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
            uri.AppendPath("/queries/string/unicode/", false);
            uri.AppendQuery("stringQuery", "啊齄丂狛狜隣郎隣兀﨩", true);
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
            uri.AppendPath("/queries/string/begin%21%2A%27%28%29%3B%3A%40%20%26%3D%2B%24%2C%2F%3F%23%5B%5Dend", false);
            uri.AppendQuery("stringQuery", "begin!*'();:@ &=+$,/?#[]end", true);
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

        internal HttpMessage CreateStringEmptyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/string/empty", false);
            uri.AppendQuery("stringQuery", "", true);
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

        internal HttpMessage CreateStringNullRequest(string stringQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/string/null", false);
            if (stringQuery != null)
            {
                uri.AppendQuery("stringQuery", stringQuery, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null (no query parameter in url). </summary>
        /// <param name="stringQuery"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> StringNullAsync(string stringQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateStringNullRequest(stringQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null (no query parameter in url). </summary>
        /// <param name="stringQuery"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response StringNull(string stringQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateStringNullRequest(stringQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateEnumValidRequest(UriColor? enumQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/enum/green%20color", false);
            if (enumQuery != null)
            {
                uri.AppendQuery("enumQuery", enumQuery.Value.ToSerialString(), true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get using uri with query parameter 'green color'. </summary>
        /// <param name="enumQuery"> 'green color' enum value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> EnumValidAsync(UriColor? enumQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateEnumValidRequest(enumQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get using uri with query parameter 'green color'. </summary>
        /// <param name="enumQuery"> 'green color' enum value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response EnumValid(UriColor? enumQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateEnumValidRequest(enumQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateEnumNullRequest(UriColor? enumQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/enum/null", false);
            if (enumQuery != null)
            {
                uri.AppendQuery("enumQuery", enumQuery.Value.ToSerialString(), true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null (no query parameter in url). </summary>
        /// <param name="enumQuery"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> EnumNullAsync(UriColor? enumQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateEnumNullRequest(enumQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null (no query parameter in url). </summary>
        /// <param name="enumQuery"> null string value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response EnumNull(UriColor? enumQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateEnumNullRequest(enumQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateByteMultiByteRequest(byte[] byteQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/byte/multibyte", false);
            if (byteQuery != null)
            {
                uri.AppendQuery("byteQuery", byteQuery, "D", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </summary>
        /// <param name="byteQuery"> '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> ByteMultiByteAsync(byte[] byteQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateByteMultiByteRequest(byteQuery);
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
        /// <param name="byteQuery"> '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ByteMultiByte(byte[] byteQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateByteMultiByteRequest(byteQuery);
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
            uri.AppendPath("/queries/byte/empty", false);
            uri.AppendQuery("byteQuery", new byte[] { }, "D", true);
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

        internal HttpMessage CreateByteNullRequest(byte[] byteQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/byte/null", false);
            if (byteQuery != null)
            {
                uri.AppendQuery("byteQuery", byteQuery, "D", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null as byte array (no query parameters in uri). </summary>
        /// <param name="byteQuery"> null as byte array (no query parameters in uri). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> ByteNullAsync(byte[] byteQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateByteNullRequest(byteQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null as byte array (no query parameters in uri). </summary>
        /// <param name="byteQuery"> null as byte array (no query parameters in uri). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ByteNull(byte[] byteQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateByteNullRequest(byteQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
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
            uri.AppendPath("/queries/date/2012-01-01", false);
            uri.AppendQuery("dateQuery", new DateTimeOffset(2012, 1, 1, 0, 0, 0, 0, TimeSpan.Zero), "D", true);
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

        internal HttpMessage CreateDateNullRequest(DateTimeOffset? dateQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/date/null", false);
            if (dateQuery != null)
            {
                uri.AppendQuery("dateQuery", dateQuery.Value, "D", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null as date - this should result in no query parameters in uri. </summary>
        /// <param name="dateQuery"> null as date (no query parameters in uri). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> DateNullAsync(DateTimeOffset? dateQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateDateNullRequest(dateQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null as date - this should result in no query parameters in uri. </summary>
        /// <param name="dateQuery"> null as date (no query parameters in uri). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateNull(DateTimeOffset? dateQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateDateNullRequest(dateQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
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
            uri.AppendPath("/queries/datetime/2012-01-01T01%3A01%3A01Z", false);
            uri.AppendQuery("dateTimeQuery", new DateTimeOffset(2012, 1, 1, 1, 1, 1, 0, TimeSpan.Zero), "O", true);
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

        internal HttpMessage CreateDateTimeNullRequest(DateTimeOffset? dateTimeQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/datetime/null", false);
            if (dateTimeQuery != null)
            {
                uri.AppendQuery("dateTimeQuery", dateTimeQuery.Value, "O", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null as date-time, should result in no query parameters in uri. </summary>
        /// <param name="dateTimeQuery"> null as date-time (no query parameters). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> DateTimeNullAsync(DateTimeOffset? dateTimeQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateDateTimeNullRequest(dateTimeQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null as date-time, should result in no query parameters in uri. </summary>
        /// <param name="dateTimeQuery"> null as date-time (no query parameters). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DateTimeNull(DateTimeOffset? dateTimeQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateDateTimeNullRequest(dateTimeQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateArrayStringCsvValidRequest(IEnumerable<string> arrayQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/csv/string/valid", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> ArrayStringCsvValidAsync(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateArrayStringCsvValidRequest(arrayQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringCsvValid(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateArrayStringCsvValidRequest(arrayQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateArrayStringCsvNullRequest(IEnumerable<string> arrayQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/csv/string/null", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a null array of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> a null array of string using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> ArrayStringCsvNullAsync(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateArrayStringCsvNullRequest(arrayQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a null array of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> a null array of string using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringCsvNull(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateArrayStringCsvNullRequest(arrayQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateArrayStringCsvEmptyRequest(IEnumerable<string> arrayQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/csv/string/empty", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an empty array [] of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> ArrayStringCsvEmptyAsync(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateArrayStringCsvEmptyRequest(arrayQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an empty array [] of string using the csv-array format. </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the csv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringCsvEmpty(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateArrayStringCsvEmptyRequest(arrayQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateArrayStringNoCollectionFormatEmptyRequest(IEnumerable<string> arrayQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/none/string/empty", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Array query has no defined collection format, should default to csv. Pass in ['hello', 'nihao', 'bonjour'] for the 'arrayQuery' parameter to the service. </summary>
        /// <param name="arrayQuery"> Array-typed query parameter. Pass in ['hello', 'nihao', 'bonjour']. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> ArrayStringNoCollectionFormatEmptyAsync(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateArrayStringNoCollectionFormatEmptyRequest(arrayQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Array query has no defined collection format, should default to csv. Pass in ['hello', 'nihao', 'bonjour'] for the 'arrayQuery' parameter to the service. </summary>
        /// <param name="arrayQuery"> Array-typed query parameter. Pass in ['hello', 'nihao', 'bonjour']. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringNoCollectionFormatEmpty(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateArrayStringNoCollectionFormatEmptyRequest(arrayQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateArrayStringSsvValidRequest(IEnumerable<string> arrayQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/ssv/string/valid", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, " ", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the ssv-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the ssv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> ArrayStringSsvValidAsync(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateArrayStringSsvValidRequest(arrayQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the ssv-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the ssv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringSsvValid(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateArrayStringSsvValidRequest(arrayQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateArrayStringTsvValidRequest(IEnumerable<string> arrayQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/tsv/string/valid", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, "\t", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the tsv-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the tsv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> ArrayStringTsvValidAsync(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateArrayStringTsvValidRequest(arrayQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the tsv-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the tsv-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringTsvValid(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateArrayStringTsvValidRequest(arrayQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateArrayStringPipesValidRequest(IEnumerable<string> arrayQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/pipes/string/valid", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, "|", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the pipes-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the pipes-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> ArrayStringPipesValidAsync(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateArrayStringPipesValidRequest(arrayQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the pipes-array format. </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the pipes-array format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ArrayStringPipesValid(IEnumerable<string> arrayQuery = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateArrayStringPipesValidRequest(arrayQuery);
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
