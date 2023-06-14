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
    /// <summary> The ApiVersionLocal service client. </summary>
    public partial class ApiVersionLocalClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ApiVersionLocalRestClient RestClient { get; }

        /// <summary> Initializes a new instance of ApiVersionLocalClient for mocking. </summary>
        protected ApiVersionLocalClient()
        {
        }

        /// <summary> Initializes a new instance of ApiVersionLocalClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal ApiVersionLocalClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new ApiVersionLocalRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = '2.0' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetMethodLocalValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionLocalClient.GetMethodLocalValid");
            scope.Start();
            try
            {
                return await RestClient.GetMethodLocalValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = '2.0' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetMethodLocalValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionLocalClient.GetMethodLocalValid");
            scope.Start();
            try
            {
                return RestClient.GetMethodLocalValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = null to succeed. </summary>
        /// <param name="apiVersion"> This should appear as a method parameter, use value null, this should result in no serialized parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetMethodLocalNullAsync(string apiVersion = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionLocalClient.GetMethodLocalNull");
            scope.Start();
            try
            {
                return await RestClient.GetMethodLocalNullAsync(apiVersion, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = null to succeed. </summary>
        /// <param name="apiVersion"> This should appear as a method parameter, use value null, this should result in no serialized parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetMethodLocalNull(string apiVersion = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionLocalClient.GetMethodLocalNull");
            scope.Start();
            try
            {
                return RestClient.GetMethodLocalNull(apiVersion, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = '2.0' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetPathLocalValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionLocalClient.GetPathLocalValid");
            scope.Start();
            try
            {
                return await RestClient.GetPathLocalValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = '2.0' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetPathLocalValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionLocalClient.GetPathLocalValid");
            scope.Start();
            try
            {
                return RestClient.GetPathLocalValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = '2.0' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetSwaggerLocalValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionLocalClient.GetSwaggerLocalValid");
            scope.Start();
            try
            {
                return await RestClient.GetSwaggerLocalValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get method with api-version modeled in the method.  pass in api-version = '2.0' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetSwaggerLocalValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionLocalClient.GetSwaggerLocalValid");
            scope.Start();
            try
            {
                return RestClient.GetSwaggerLocalValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
