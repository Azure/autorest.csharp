// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace azure_special_properties
{
    /// <summary> The SkipUrlEncoding service client. </summary>
    public partial class SkipUrlEncodingClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal SkipUrlEncodingRestClient RestClient { get; }

        /// <summary> Initializes a new instance of SkipUrlEncodingClient for mocking. </summary>
        protected SkipUrlEncodingClient()
        {
        }

        /// <summary> Initializes a new instance of SkipUrlEncodingClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal SkipUrlEncodingClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new SkipUrlEncodingRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get method with unencoded path parameter with value 'path1/path2/path3'. </summary>
        /// <param name="unencodedPathParam"> Unencoded path parameter with value 'path1/path2/path3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetMethodPathValidAsync(string unencodedPathParam, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SkipUrlEncodingClient.GetMethodPathValid");
            scope.Start();
            try
            {
                return await RestClient.GetMethodPathValidAsync(unencodedPathParam, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with unencoded path parameter with value 'path1/path2/path3'. </summary>
        /// <param name="unencodedPathParam"> Unencoded path parameter with value 'path1/path2/path3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetMethodPathValid(string unencodedPathParam, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SkipUrlEncodingClient.GetMethodPathValid");
            scope.Start();
            try
            {
                return RestClient.GetMethodPathValid(unencodedPathParam, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with unencoded path parameter with value 'path1/path2/path3'. </summary>
        /// <param name="unencodedPathParam"> Unencoded path parameter with value 'path1/path2/path3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetPathValidAsync(string unencodedPathParam, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SkipUrlEncodingClient.GetPathValid");
            scope.Start();
            try
            {
                return await RestClient.GetPathValidAsync(unencodedPathParam, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with unencoded path parameter with value 'path1/path2/path3'. </summary>
        /// <param name="unencodedPathParam"> Unencoded path parameter with value 'path1/path2/path3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetPathValid(string unencodedPathParam, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SkipUrlEncodingClient.GetPathValid");
            scope.Start();
            try
            {
                return RestClient.GetPathValid(unencodedPathParam, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with unencoded path parameter with value 'path1/path2/path3'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetSwaggerPathValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SkipUrlEncodingClient.GetSwaggerPathValid");
            scope.Start();
            try
            {
                return await RestClient.GetSwaggerPathValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with unencoded path parameter with value 'path1/path2/path3'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetSwaggerPathValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SkipUrlEncodingClient.GetSwaggerPathValid");
            scope.Start();
            try
            {
                return RestClient.GetSwaggerPathValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </summary>
        /// <param name="q1"> Unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetMethodQueryValidAsync(string q1, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SkipUrlEncodingClient.GetMethodQueryValid");
            scope.Start();
            try
            {
                return await RestClient.GetMethodQueryValidAsync(q1, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </summary>
        /// <param name="q1"> Unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetMethodQueryValid(string q1, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SkipUrlEncodingClient.GetMethodQueryValid");
            scope.Start();
            try
            {
                return RestClient.GetMethodQueryValid(q1, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with unencoded query parameter with value null. </summary>
        /// <param name="q1"> Unencoded query parameter with value null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetMethodQueryNullAsync(string q1 = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SkipUrlEncodingClient.GetMethodQueryNull");
            scope.Start();
            try
            {
                return await RestClient.GetMethodQueryNullAsync(q1, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with unencoded query parameter with value null. </summary>
        /// <param name="q1"> Unencoded query parameter with value null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetMethodQueryNull(string q1 = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SkipUrlEncodingClient.GetMethodQueryNull");
            scope.Start();
            try
            {
                return RestClient.GetMethodQueryNull(q1, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </summary>
        /// <param name="q1"> Unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetPathQueryValidAsync(string q1, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SkipUrlEncodingClient.GetPathQueryValid");
            scope.Start();
            try
            {
                return await RestClient.GetPathQueryValidAsync(q1, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </summary>
        /// <param name="q1"> Unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetPathQueryValid(string q1, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SkipUrlEncodingClient.GetPathQueryValid");
            scope.Start();
            try
            {
                return RestClient.GetPathQueryValid(q1, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetSwaggerQueryValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SkipUrlEncodingClient.GetSwaggerQueryValid");
            scope.Start();
            try
            {
                return await RestClient.GetSwaggerQueryValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetSwaggerQueryValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SkipUrlEncodingClient.GetSwaggerQueryValid");
            scope.Start();
            try
            {
                return RestClient.GetSwaggerQueryValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
