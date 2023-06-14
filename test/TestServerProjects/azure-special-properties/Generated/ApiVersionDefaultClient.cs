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
    /// <summary> The ApiVersionDefault service client. </summary>
    public partial class ApiVersionDefaultClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ApiVersionDefaultRestClient RestClient { get; }

        /// <summary> Initializes a new instance of ApiVersionDefaultClient for mocking. </summary>
        protected ApiVersionDefaultClient()
        {
        }

        /// <summary> Initializes a new instance of ApiVersionDefaultClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        internal ApiVersionDefaultClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null, string apiVersion = "2015-07-01-preview")
        {
            RestClient = new ApiVersionDefaultRestClient(clientDiagnostics, pipeline, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> GET method with api-version modeled in global settings. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetMethodGlobalValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionDefaultClient.GetMethodGlobalValid");
            scope.Start();
            try
            {
                return await RestClient.GetMethodGlobalValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> GET method with api-version modeled in global settings. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetMethodGlobalValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionDefaultClient.GetMethodGlobalValid");
            scope.Start();
            try
            {
                return RestClient.GetMethodGlobalValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> GET method with api-version modeled in global settings. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetMethodGlobalNotProvidedValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionDefaultClient.GetMethodGlobalNotProvidedValid");
            scope.Start();
            try
            {
                return await RestClient.GetMethodGlobalNotProvidedValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> GET method with api-version modeled in global settings. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetMethodGlobalNotProvidedValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionDefaultClient.GetMethodGlobalNotProvidedValid");
            scope.Start();
            try
            {
                return RestClient.GetMethodGlobalNotProvidedValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> GET method with api-version modeled in global settings. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetPathGlobalValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionDefaultClient.GetPathGlobalValid");
            scope.Start();
            try
            {
                return await RestClient.GetPathGlobalValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> GET method with api-version modeled in global settings. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetPathGlobalValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionDefaultClient.GetPathGlobalValid");
            scope.Start();
            try
            {
                return RestClient.GetPathGlobalValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> GET method with api-version modeled in global settings. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetSwaggerGlobalValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionDefaultClient.GetSwaggerGlobalValid");
            scope.Start();
            try
            {
                return await RestClient.GetSwaggerGlobalValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> GET method with api-version modeled in global settings. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetSwaggerGlobalValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionDefaultClient.GetSwaggerGlobalValid");
            scope.Start();
            try
            {
                return RestClient.GetSwaggerGlobalValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
