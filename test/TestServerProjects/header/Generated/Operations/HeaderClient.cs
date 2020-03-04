// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using header.Models;

namespace header
{
    public partial class HeaderClient
    {
        internal HeaderRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of HeaderClient. </summary>
        internal HeaderClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new HeaderRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Send a post request with header value &quot;User-Agent&quot;: &quot;overwrite&quot;. </summary>
        /// <param name="userAgent"> Send a post request with header value &quot;User-Agent&quot;: &quot;overwrite&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamExistingKeyAsync(string userAgent, CancellationToken cancellationToken = default)
        {
            return await RestClient.ParamExistingKeyAsync(userAgent, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a post request with header value &quot;User-Agent&quot;: &quot;overwrite&quot;. </summary>
        /// <param name="userAgent"> Send a post request with header value &quot;User-Agent&quot;: &quot;overwrite&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamExistingKey(string userAgent, CancellationToken cancellationToken = default)
        {
            return RestClient.ParamExistingKey(userAgent, cancellationToken);
        }
        /// <summary> Get a response with header value &quot;User-Agent&quot;: &quot;overwrite&quot;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResponseExistingKeyAsync(CancellationToken cancellationToken = default)
        {
            return (await RestClient.ResponseExistingKeyAsync(cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get a response with header value &quot;User-Agent&quot;: &quot;overwrite&quot;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ResponseExistingKey(CancellationToken cancellationToken = default)
        {
            return RestClient.ResponseExistingKey(cancellationToken).GetRawResponse();
        }
        /// <summary> Send a post request with header value &quot;Content-Type&quot;: &quot;text/html&quot;. </summary>
        /// <param name="contentType"> Send a post request with header value &quot;Content-Type&quot;: &quot;text/html&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamProtectedKeyAsync(string contentType, CancellationToken cancellationToken = default)
        {
            return await RestClient.ParamProtectedKeyAsync(contentType, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a post request with header value &quot;Content-Type&quot;: &quot;text/html&quot;. </summary>
        /// <param name="contentType"> Send a post request with header value &quot;Content-Type&quot;: &quot;text/html&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamProtectedKey(string contentType, CancellationToken cancellationToken = default)
        {
            return RestClient.ParamProtectedKey(contentType, cancellationToken);
        }
        /// <summary> Get a response with header value &quot;Content-Type&quot;: &quot;text/html&quot;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResponseProtectedKeyAsync(CancellationToken cancellationToken = default)
        {
            return (await RestClient.ResponseProtectedKeyAsync(cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get a response with header value &quot;Content-Type&quot;: &quot;text/html&quot;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ResponseProtectedKey(CancellationToken cancellationToken = default)
        {
            return RestClient.ResponseProtectedKey(cancellationToken).GetRawResponse();
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 1 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 1 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamIntegerAsync(string scenario, int value, CancellationToken cancellationToken = default)
        {
            return await RestClient.ParamIntegerAsync(scenario, value, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 1 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 1 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamInteger(string scenario, int value, CancellationToken cancellationToken = default)
        {
            return RestClient.ParamInteger(scenario, value, cancellationToken);
        }
        /// <summary> Get a response with header value &quot;value&quot;: 1 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResponseIntegerAsync(string scenario, CancellationToken cancellationToken = default)
        {
            return (await RestClient.ResponseIntegerAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get a response with header value &quot;value&quot;: 1 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ResponseInteger(string scenario, CancellationToken cancellationToken = default)
        {
            return RestClient.ResponseInteger(scenario, cancellationToken).GetRawResponse();
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 105 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 105 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamLongAsync(string scenario, long value, CancellationToken cancellationToken = default)
        {
            return await RestClient.ParamLongAsync(scenario, value, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 105 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 105 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamLong(string scenario, long value, CancellationToken cancellationToken = default)
        {
            return RestClient.ParamLong(scenario, value, cancellationToken);
        }
        /// <summary> Get a response with header value &quot;value&quot;: 105 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResponseLongAsync(string scenario, CancellationToken cancellationToken = default)
        {
            return (await RestClient.ResponseLongAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get a response with header value &quot;value&quot;: 105 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ResponseLong(string scenario, CancellationToken cancellationToken = default)
        {
            return RestClient.ResponseLong(scenario, cancellationToken).GetRawResponse();
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 0.07 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 0.07 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamFloatAsync(string scenario, float value, CancellationToken cancellationToken = default)
        {
            return await RestClient.ParamFloatAsync(scenario, value, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 0.07 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 0.07 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamFloat(string scenario, float value, CancellationToken cancellationToken = default)
        {
            return RestClient.ParamFloat(scenario, value, cancellationToken);
        }
        /// <summary> Get a response with header value &quot;value&quot;: 0.07 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResponseFloatAsync(string scenario, CancellationToken cancellationToken = default)
        {
            return (await RestClient.ResponseFloatAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get a response with header value &quot;value&quot;: 0.07 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ResponseFloat(string scenario, CancellationToken cancellationToken = default)
        {
            return RestClient.ResponseFloat(scenario, cancellationToken).GetRawResponse();
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 7e120 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 7e120 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamDoubleAsync(string scenario, double value, CancellationToken cancellationToken = default)
        {
            return await RestClient.ParamDoubleAsync(scenario, value, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot;, &quot;value&quot;: 7e120 or &quot;scenario&quot;: &quot;negative&quot;, &quot;value&quot;: -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values 7e120 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamDouble(string scenario, double value, CancellationToken cancellationToken = default)
        {
            return RestClient.ParamDouble(scenario, value, cancellationToken);
        }
        /// <summary> Get a response with header value &quot;value&quot;: 7e120 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResponseDoubleAsync(string scenario, CancellationToken cancellationToken = default)
        {
            return (await RestClient.ResponseDoubleAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get a response with header value &quot;value&quot;: 7e120 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ResponseDouble(string scenario, CancellationToken cancellationToken = default)
        {
            return RestClient.ResponseDouble(scenario, cancellationToken).GetRawResponse();
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;true&quot;, &quot;value&quot;: true or &quot;scenario&quot;: &quot;false&quot;, &quot;value&quot;: false. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values true or false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamBoolAsync(string scenario, bool value, CancellationToken cancellationToken = default)
        {
            return await RestClient.ParamBoolAsync(scenario, value, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;true&quot;, &quot;value&quot;: true or &quot;scenario&quot;: &quot;false&quot;, &quot;value&quot;: false. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values true or false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamBool(string scenario, bool value, CancellationToken cancellationToken = default)
        {
            return RestClient.ParamBool(scenario, value, cancellationToken);
        }
        /// <summary> Get a response with header value &quot;value&quot;: true or false. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResponseBoolAsync(string scenario, CancellationToken cancellationToken = default)
        {
            return (await RestClient.ResponseBoolAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get a response with header value &quot;value&quot;: true or false. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ResponseBool(string scenario, CancellationToken cancellationToken = default)
        {
            return RestClient.ResponseBool(scenario, cancellationToken).GetRawResponse();
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;The quick brown fox jumps over the lazy dog&quot; or &quot;scenario&quot;: &quot;null&quot;, &quot;value&quot;: null or &quot;scenario&quot;: &quot;empty&quot;, &quot;value&quot;: &quot;&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;The quick brown fox jumps over the lazy dog&quot; or null or &quot;&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamStringAsync(string scenario, string value, CancellationToken cancellationToken = default)
        {
            return await RestClient.ParamStringAsync(scenario, value, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;The quick brown fox jumps over the lazy dog&quot; or &quot;scenario&quot;: &quot;null&quot;, &quot;value&quot;: null or &quot;scenario&quot;: &quot;empty&quot;, &quot;value&quot;: &quot;&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;The quick brown fox jumps over the lazy dog&quot; or null or &quot;&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamString(string scenario, string value, CancellationToken cancellationToken = default)
        {
            return RestClient.ParamString(scenario, value, cancellationToken);
        }
        /// <summary> Get a response with header values &quot;The quick brown fox jumps over the lazy dog&quot; or null or &quot;&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResponseStringAsync(string scenario, CancellationToken cancellationToken = default)
        {
            return (await RestClient.ResponseStringAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get a response with header values &quot;The quick brown fox jumps over the lazy dog&quot; or null or &quot;&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ResponseString(string scenario, CancellationToken cancellationToken = default)
        {
            return RestClient.ResponseString(scenario, cancellationToken).GetRawResponse();
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;2010-01-01&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;0001-01-01&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;2010-01-01&quot; or &quot;0001-01-01&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamDateAsync(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            return await RestClient.ParamDateAsync(scenario, value, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;2010-01-01&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;0001-01-01&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;2010-01-01&quot; or &quot;0001-01-01&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamDate(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            return RestClient.ParamDate(scenario, value, cancellationToken);
        }
        /// <summary> Get a response with header values &quot;2010-01-01&quot; or &quot;0001-01-01&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResponseDateAsync(string scenario, CancellationToken cancellationToken = default)
        {
            return (await RestClient.ResponseDateAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get a response with header values &quot;2010-01-01&quot; or &quot;0001-01-01&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ResponseDate(string scenario, CancellationToken cancellationToken = default)
        {
            return RestClient.ResponseDate(scenario, cancellationToken).GetRawResponse();
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;2010-01-01T12:34:56Z&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;0001-01-01T00:00:00Z&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;2010-01-01T12:34:56Z&quot; or &quot;0001-01-01T00:00:00Z&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamDatetimeAsync(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            return await RestClient.ParamDatetimeAsync(scenario, value, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;2010-01-01T12:34:56Z&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;0001-01-01T00:00:00Z&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;2010-01-01T12:34:56Z&quot; or &quot;0001-01-01T00:00:00Z&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamDatetime(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            return RestClient.ParamDatetime(scenario, value, cancellationToken);
        }
        /// <summary> Get a response with header values &quot;2010-01-01T12:34:56Z&quot; or &quot;0001-01-01T00:00:00Z&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResponseDatetimeAsync(string scenario, CancellationToken cancellationToken = default)
        {
            return (await RestClient.ResponseDatetimeAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get a response with header values &quot;2010-01-01T12:34:56Z&quot; or &quot;0001-01-01T00:00:00Z&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ResponseDatetime(string scenario, CancellationToken cancellationToken = default)
        {
            return RestClient.ResponseDatetime(scenario, cancellationToken).GetRawResponse();
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;Wed, 01 Jan 2010 12:34:56 GMT&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;Mon, 01 Jan 0001 00:00:00 GMT&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;Wed, 01 Jan 2010 12:34:56 GMT&quot; or &quot;Mon, 01 Jan 0001 00:00:00 GMT&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamDatetimeRfc1123Async(string scenario, DateTimeOffset? value, CancellationToken cancellationToken = default)
        {
            return await RestClient.ParamDatetimeRfc1123Async(scenario, value, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;Wed, 01 Jan 2010 12:34:56 GMT&quot; or &quot;scenario&quot;: &quot;min&quot;, &quot;value&quot;: &quot;Mon, 01 Jan 0001 00:00:00 GMT&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;Wed, 01 Jan 2010 12:34:56 GMT&quot; or &quot;Mon, 01 Jan 0001 00:00:00 GMT&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamDatetimeRfc1123(string scenario, DateTimeOffset? value, CancellationToken cancellationToken = default)
        {
            return RestClient.ParamDatetimeRfc1123(scenario, value, cancellationToken);
        }
        /// <summary> Get a response with header values &quot;Wed, 01 Jan 2010 12:34:56 GMT&quot; or &quot;Mon, 01 Jan 0001 00:00:00 GMT&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResponseDatetimeRfc1123Async(string scenario, CancellationToken cancellationToken = default)
        {
            return (await RestClient.ResponseDatetimeRfc1123Async(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get a response with header values &quot;Wed, 01 Jan 2010 12:34:56 GMT&quot; or &quot;Mon, 01 Jan 0001 00:00:00 GMT&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ResponseDatetimeRfc1123(string scenario, CancellationToken cancellationToken = default)
        {
            return RestClient.ResponseDatetimeRfc1123(scenario, cancellationToken).GetRawResponse();
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;P123DT22H14M12.011S&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;P123DT22H14M12.011S&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamDurationAsync(string scenario, TimeSpan value, CancellationToken cancellationToken = default)
        {
            return await RestClient.ParamDurationAsync(scenario, value, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;P123DT22H14M12.011S&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;P123DT22H14M12.011S&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamDuration(string scenario, TimeSpan value, CancellationToken cancellationToken = default)
        {
            return RestClient.ParamDuration(scenario, value, cancellationToken);
        }
        /// <summary> Get a response with header values &quot;P123DT22H14M12.011S&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResponseDurationAsync(string scenario, CancellationToken cancellationToken = default)
        {
            return (await RestClient.ResponseDurationAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get a response with header values &quot;P123DT22H14M12.011S&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ResponseDuration(string scenario, CancellationToken cancellationToken = default)
        {
            return RestClient.ResponseDuration(scenario, cancellationToken).GetRawResponse();
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;啊齄丂狛狜隣郎隣兀﨩&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;啊齄丂狛狜隣郎隣兀﨩&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamByteAsync(string scenario, byte[] value, CancellationToken cancellationToken = default)
        {
            return await RestClient.ParamByteAsync(scenario, value, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;啊齄丂狛狜隣郎隣兀﨩&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &quot;啊齄丂狛狜隣郎隣兀﨩&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamByte(string scenario, byte[] value, CancellationToken cancellationToken = default)
        {
            return RestClient.ParamByte(scenario, value, cancellationToken);
        }
        /// <summary> Get a response with header values &quot;啊齄丂狛狜隣郎隣兀﨩&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResponseByteAsync(string scenario, CancellationToken cancellationToken = default)
        {
            return (await RestClient.ResponseByteAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get a response with header values &quot;啊齄丂狛狜隣郎隣兀﨩&quot;. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ResponseByte(string scenario, CancellationToken cancellationToken = default)
        {
            return RestClient.ResponseByte(scenario, cancellationToken).GetRawResponse();
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;GREY&quot; or &quot;scenario&quot;: &quot;null&quot;, &quot;value&quot;: null. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &apos;GREY&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ParamEnumAsync(string scenario, GreyscaleColors? value, CancellationToken cancellationToken = default)
        {
            return await RestClient.ParamEnumAsync(scenario, value, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a post request with header values &quot;scenario&quot;: &quot;valid&quot;, &quot;value&quot;: &quot;GREY&quot; or &quot;scenario&quot;: &quot;null&quot;, &quot;value&quot;: null. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="value"> Send a post request with header values &apos;GREY&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ParamEnum(string scenario, GreyscaleColors? value, CancellationToken cancellationToken = default)
        {
            return RestClient.ParamEnum(scenario, value, cancellationToken);
        }
        /// <summary> Get a response with header values &quot;GREY&quot; or null. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResponseEnumAsync(string scenario, CancellationToken cancellationToken = default)
        {
            return (await RestClient.ResponseEnumAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get a response with header values &quot;GREY&quot; or null. </summary>
        /// <param name="scenario"> Send a post request with header values &quot;scenario&quot;: &quot;positive&quot; or &quot;negative&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ResponseEnum(string scenario, CancellationToken cancellationToken = default)
        {
            return RestClient.ResponseEnum(scenario, cancellationToken).GetRawResponse();
        }
        /// <summary> Send x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> CustomRequestIdAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.CustomRequestIdAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response CustomRequestId(CancellationToken cancellationToken = default)
        {
            return RestClient.CustomRequestId(cancellationToken);
        }
    }
}
