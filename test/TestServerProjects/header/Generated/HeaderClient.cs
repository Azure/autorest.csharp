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
    /// <summary> The Header service client. </summary>
    public partial class HeaderClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal HeaderRestClient RestClient { get; }

        /// <summary> Initializes a new instance of HeaderClient for mocking. </summary>
        protected HeaderClient()
        {
        }

        /// <summary> Initializes a new instance of HeaderClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal HeaderClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new HeaderRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Send a post request with header value "User-Agent": "overwrite". </summary>
        /// <param name="userAgent"> Send a post request with header value "User-Agent": "overwrite". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ParamExistingKeyAsync(string userAgent, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamExistingKey");
            scope.Start();
            try
            {
                return await RestClient.ParamExistingKeyAsync(userAgent, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header value "User-Agent": "overwrite". </summary>
        /// <param name="userAgent"> Send a post request with header value "User-Agent": "overwrite". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ParamExistingKey(string userAgent, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamExistingKey");
            scope.Start();
            try
            {
                return RestClient.ParamExistingKey(userAgent, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header value "User-Agent": "overwrite". </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResponseExistingKeyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseExistingKey");
            scope.Start();
            try
            {
                return (await RestClient.ResponseExistingKeyAsync(cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header value "User-Agent": "overwrite". </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResponseExistingKey(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseExistingKey");
            scope.Start();
            try
            {
                return RestClient.ResponseExistingKey(cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header value "Content-Type": "text/html". </summary>
        /// <param name="contentType"> Send a post request with header value "Content-Type": "text/html". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ParamProtectedKeyAsync(string contentType, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamProtectedKey");
            scope.Start();
            try
            {
                return await RestClient.ParamProtectedKeyAsync(contentType, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header value "Content-Type": "text/html". </summary>
        /// <param name="contentType"> Send a post request with header value "Content-Type": "text/html". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ParamProtectedKey(string contentType, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamProtectedKey");
            scope.Start();
            try
            {
                return RestClient.ParamProtectedKey(contentType, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header value "Content-Type": "text/html". </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResponseProtectedKeyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseProtectedKey");
            scope.Start();
            try
            {
                return (await RestClient.ResponseProtectedKeyAsync(cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header value "Content-Type": "text/html". </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResponseProtectedKey(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseProtectedKey");
            scope.Start();
            try
            {
                return RestClient.ResponseProtectedKey(cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 1 or "scenario": "negative", "value": -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 1 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ParamIntegerAsync(string scenario, int value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamInteger");
            scope.Start();
            try
            {
                return await RestClient.ParamIntegerAsync(scenario, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 1 or "scenario": "negative", "value": -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 1 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ParamInteger(string scenario, int value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamInteger");
            scope.Start();
            try
            {
                return RestClient.ParamInteger(scenario, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header value "value": 1 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResponseIntegerAsync(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseInteger");
            scope.Start();
            try
            {
                return (await RestClient.ResponseIntegerAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header value "value": 1 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResponseInteger(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseInteger");
            scope.Start();
            try
            {
                return RestClient.ResponseInteger(scenario, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 105 or "scenario": "negative", "value": -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 105 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ParamLongAsync(string scenario, long value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamLong");
            scope.Start();
            try
            {
                return await RestClient.ParamLongAsync(scenario, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 105 or "scenario": "negative", "value": -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 105 or -2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ParamLong(string scenario, long value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamLong");
            scope.Start();
            try
            {
                return RestClient.ParamLong(scenario, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header value "value": 105 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResponseLongAsync(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseLong");
            scope.Start();
            try
            {
                return (await RestClient.ResponseLongAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header value "value": 105 or -2. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResponseLong(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseLong");
            scope.Start();
            try
            {
                return RestClient.ResponseLong(scenario, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 0.07 or "scenario": "negative", "value": -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 0.07 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ParamFloatAsync(string scenario, float value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamFloat");
            scope.Start();
            try
            {
                return await RestClient.ParamFloatAsync(scenario, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 0.07 or "scenario": "negative", "value": -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 0.07 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ParamFloat(string scenario, float value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamFloat");
            scope.Start();
            try
            {
                return RestClient.ParamFloat(scenario, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header value "value": 0.07 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResponseFloatAsync(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseFloat");
            scope.Start();
            try
            {
                return (await RestClient.ResponseFloatAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header value "value": 0.07 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResponseFloat(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseFloat");
            scope.Start();
            try
            {
                return RestClient.ResponseFloat(scenario, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 7e120 or "scenario": "negative", "value": -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 7e120 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ParamDoubleAsync(string scenario, double value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamDouble");
            scope.Start();
            try
            {
                return await RestClient.ParamDoubleAsync(scenario, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "positive", "value": 7e120 or "scenario": "negative", "value": -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 7e120 or -3.0. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ParamDouble(string scenario, double value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamDouble");
            scope.Start();
            try
            {
                return RestClient.ParamDouble(scenario, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header value "value": 7e120 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResponseDoubleAsync(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseDouble");
            scope.Start();
            try
            {
                return (await RestClient.ResponseDoubleAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header value "value": 7e120 or -3.0. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResponseDouble(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseDouble");
            scope.Start();
            try
            {
                return RestClient.ResponseDouble(scenario, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "true", "value": true or "scenario": "false", "value": false. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "true" or "false". </param>
        /// <param name="value"> Send a post request with header values true or false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ParamBoolAsync(string scenario, bool value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamBool");
            scope.Start();
            try
            {
                return await RestClient.ParamBoolAsync(scenario, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "true", "value": true or "scenario": "false", "value": false. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "true" or "false". </param>
        /// <param name="value"> Send a post request with header values true or false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ParamBool(string scenario, bool value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamBool");
            scope.Start();
            try
            {
                return RestClient.ParamBool(scenario, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header value "value": true or false. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "true" or "false". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResponseBoolAsync(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseBool");
            scope.Start();
            try
            {
                return (await RestClient.ResponseBoolAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header value "value": true or false. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "true" or "false". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResponseBool(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseBool");
            scope.Start();
            try
            {
                return RestClient.ResponseBool(scenario, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "The quick brown fox jumps over the lazy dog" or "scenario": "null", "value": null or "scenario": "empty", "value": "". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="value"> Send a post request with header values "The quick brown fox jumps over the lazy dog" or null or "". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ParamStringAsync(string scenario, string value = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamString");
            scope.Start();
            try
            {
                return await RestClient.ParamStringAsync(scenario, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "The quick brown fox jumps over the lazy dog" or "scenario": "null", "value": null or "scenario": "empty", "value": "". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="value"> Send a post request with header values "The quick brown fox jumps over the lazy dog" or null or "". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ParamString(string scenario, string value = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamString");
            scope.Start();
            try
            {
                return RestClient.ParamString(scenario, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header values "The quick brown fox jumps over the lazy dog" or null or "". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResponseStringAsync(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseString");
            scope.Start();
            try
            {
                return (await RestClient.ResponseStringAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header values "The quick brown fox jumps over the lazy dog" or null or "". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResponseString(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseString");
            scope.Start();
            try
            {
                return RestClient.ResponseString(scenario, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "2010-01-01" or "scenario": "min", "value": "0001-01-01". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "2010-01-01" or "0001-01-01". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ParamDateAsync(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamDate");
            scope.Start();
            try
            {
                return await RestClient.ParamDateAsync(scenario, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "2010-01-01" or "scenario": "min", "value": "0001-01-01". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "2010-01-01" or "0001-01-01". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ParamDate(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamDate");
            scope.Start();
            try
            {
                return RestClient.ParamDate(scenario, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header values "2010-01-01" or "0001-01-01". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResponseDateAsync(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseDate");
            scope.Start();
            try
            {
                return (await RestClient.ResponseDateAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header values "2010-01-01" or "0001-01-01". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResponseDate(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseDate");
            scope.Start();
            try
            {
                return RestClient.ResponseDate(scenario, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "2010-01-01T12:34:56Z" or "scenario": "min", "value": "0001-01-01T00:00:00Z". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "2010-01-01T12:34:56Z" or "0001-01-01T00:00:00Z". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ParamDatetimeAsync(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamDatetime");
            scope.Start();
            try
            {
                return await RestClient.ParamDatetimeAsync(scenario, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "2010-01-01T12:34:56Z" or "scenario": "min", "value": "0001-01-01T00:00:00Z". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "2010-01-01T12:34:56Z" or "0001-01-01T00:00:00Z". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ParamDatetime(string scenario, DateTimeOffset value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamDatetime");
            scope.Start();
            try
            {
                return RestClient.ParamDatetime(scenario, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header values "2010-01-01T12:34:56Z" or "0001-01-01T00:00:00Z". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResponseDatetimeAsync(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseDatetime");
            scope.Start();
            try
            {
                return (await RestClient.ResponseDatetimeAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header values "2010-01-01T12:34:56Z" or "0001-01-01T00:00:00Z". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResponseDatetime(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseDatetime");
            scope.Start();
            try
            {
                return RestClient.ResponseDatetime(scenario, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "Wed, 01 Jan 2010 12:34:56 GMT" or "scenario": "min", "value": "Mon, 01 Jan 0001 00:00:00 GMT". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "Wed, 01 Jan 2010 12:34:56 GMT" or "Mon, 01 Jan 0001 00:00:00 GMT". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ParamDatetimeRfc1123Async(string scenario, DateTimeOffset? value = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamDatetimeRfc1123");
            scope.Start();
            try
            {
                return await RestClient.ParamDatetimeRfc1123Async(scenario, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "Wed, 01 Jan 2010 12:34:56 GMT" or "scenario": "min", "value": "Mon, 01 Jan 0001 00:00:00 GMT". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "Wed, 01 Jan 2010 12:34:56 GMT" or "Mon, 01 Jan 0001 00:00:00 GMT". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ParamDatetimeRfc1123(string scenario, DateTimeOffset? value = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamDatetimeRfc1123");
            scope.Start();
            try
            {
                return RestClient.ParamDatetimeRfc1123(scenario, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header values "Wed, 01 Jan 2010 12:34:56 GMT" or "Mon, 01 Jan 0001 00:00:00 GMT". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResponseDatetimeRfc1123Async(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseDatetimeRfc1123");
            scope.Start();
            try
            {
                return (await RestClient.ResponseDatetimeRfc1123Async(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header values "Wed, 01 Jan 2010 12:34:56 GMT" or "Mon, 01 Jan 0001 00:00:00 GMT". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResponseDatetimeRfc1123(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseDatetimeRfc1123");
            scope.Start();
            try
            {
                return RestClient.ResponseDatetimeRfc1123(scenario, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "P123DT22H14M12.011S". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="value"> Send a post request with header values "P123DT22H14M12.011S". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ParamDurationAsync(string scenario, TimeSpan value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamDuration");
            scope.Start();
            try
            {
                return await RestClient.ParamDurationAsync(scenario, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "P123DT22H14M12.011S". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="value"> Send a post request with header values "P123DT22H14M12.011S". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ParamDuration(string scenario, TimeSpan value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamDuration");
            scope.Start();
            try
            {
                return RestClient.ParamDuration(scenario, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header values "P123DT22H14M12.011S". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResponseDurationAsync(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseDuration");
            scope.Start();
            try
            {
                return (await RestClient.ResponseDurationAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header values "P123DT22H14M12.011S". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResponseDuration(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseDuration");
            scope.Start();
            try
            {
                return RestClient.ResponseDuration(scenario, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "啊齄丂狛狜隣郎隣兀﨩". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="value"> Send a post request with header values "啊齄丂狛狜隣郎隣兀﨩". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ParamByteAsync(string scenario, byte[] value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamByte");
            scope.Start();
            try
            {
                return await RestClient.ParamByteAsync(scenario, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "啊齄丂狛狜隣郎隣兀﨩". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="value"> Send a post request with header values "啊齄丂狛狜隣郎隣兀﨩". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ParamByte(string scenario, byte[] value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamByte");
            scope.Start();
            try
            {
                return RestClient.ParamByte(scenario, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header values "啊齄丂狛狜隣郎隣兀﨩". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResponseByteAsync(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseByte");
            scope.Start();
            try
            {
                return (await RestClient.ResponseByteAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header values "啊齄丂狛狜隣郎隣兀﨩". </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResponseByte(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseByte");
            scope.Start();
            try
            {
                return RestClient.ResponseByte(scenario, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "GREY" or "scenario": "null", "value": null. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="value"> Send a post request with header values 'GREY'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ParamEnumAsync(string scenario, GreyscaleColors? value = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamEnum");
            scope.Start();
            try
            {
                return await RestClient.ParamEnumAsync(scenario, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a post request with header values "scenario": "valid", "value": "GREY" or "scenario": "null", "value": null. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="value"> Send a post request with header values 'GREY'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ParamEnum(string scenario, GreyscaleColors? value = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ParamEnum");
            scope.Start();
            try
            {
                return RestClient.ParamEnum(scenario, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header values "GREY" or null. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResponseEnumAsync(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseEnum");
            scope.Start();
            try
            {
                return (await RestClient.ResponseEnumAsync(scenario, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a response with header values "GREY" or null. </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResponseEnum(string scenario, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.ResponseEnum");
            scope.Start();
            try
            {
                return RestClient.ResponseEnum(scenario, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> CustomRequestIdAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.CustomRequestId");
            scope.Start();
            try
            {
                return await RestClient.CustomRequestIdAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response CustomRequestId(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderClient.CustomRequestId");
            scope.Start();
            try
            {
                return RestClient.CustomRequestId(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
