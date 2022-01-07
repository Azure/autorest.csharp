// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace Azure_Special_Properties
{
    /// <summary> The SubscriptionInCredentials service client. </summary>
    public partial class SubscriptionInCredentialsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal SubscriptionInCredentialsRestClient RestClient { get; }

        /// <summary> Initializes a new instance of SubscriptionInCredentialsClient for mocking. </summary>
        protected SubscriptionInCredentialsClient()
        {
        }

        /// <summary> Initializes a new instance of SubscriptionInCredentialsClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="subscriptionId"> The subscription id, which appears in the path, always modeled in credentials. The value is always &apos;1234-5678-9012-3456&apos;. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        internal SubscriptionInCredentialsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, Uri endpoint = null, string apiVersion = "2015-07-01-preview")
        {
            RestClient = new SubscriptionInCredentialsRestClient(clientDiagnostics, pipeline, subscriptionId, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to &apos;1234-5678-9012-3456&apos; to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostMethodGlobalValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInCredentialsClient.PostMethodGlobalValid");
            scope.Start();
            try
            {
                return await RestClient.PostMethodGlobalValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to &apos;1234-5678-9012-3456&apos; to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostMethodGlobalValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInCredentialsClient.PostMethodGlobalValid");
            scope.Start();
            try
            {
                return RestClient.PostMethodGlobalValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to null, and client-side validation should prevent you from making this call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostMethodGlobalNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInCredentialsClient.PostMethodGlobalNull");
            scope.Start();
            try
            {
                return await RestClient.PostMethodGlobalNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to null, and client-side validation should prevent you from making this call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostMethodGlobalNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInCredentialsClient.PostMethodGlobalNull");
            scope.Start();
            try
            {
                return RestClient.PostMethodGlobalNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to &apos;1234-5678-9012-3456&apos; to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostMethodGlobalNotProvidedValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInCredentialsClient.PostMethodGlobalNotProvidedValid");
            scope.Start();
            try
            {
                return await RestClient.PostMethodGlobalNotProvidedValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to &apos;1234-5678-9012-3456&apos; to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostMethodGlobalNotProvidedValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInCredentialsClient.PostMethodGlobalNotProvidedValid");
            scope.Start();
            try
            {
                return RestClient.PostMethodGlobalNotProvidedValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to &apos;1234-5678-9012-3456&apos; to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostPathGlobalValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInCredentialsClient.PostPathGlobalValid");
            scope.Start();
            try
            {
                return await RestClient.PostPathGlobalValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to &apos;1234-5678-9012-3456&apos; to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostPathGlobalValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInCredentialsClient.PostPathGlobalValid");
            scope.Start();
            try
            {
                return RestClient.PostPathGlobalValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to &apos;1234-5678-9012-3456&apos; to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostSwaggerGlobalValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInCredentialsClient.PostSwaggerGlobalValid");
            scope.Start();
            try
            {
                return await RestClient.PostSwaggerGlobalValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to &apos;1234-5678-9012-3456&apos; to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostSwaggerGlobalValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInCredentialsClient.PostSwaggerGlobalValid");
            scope.Start();
            try
            {
                return RestClient.PostSwaggerGlobalValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
