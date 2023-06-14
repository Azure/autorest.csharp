// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using lro.Models;

namespace lro
{
    /// <summary> The LROsCustomHeader service client. </summary>
    public partial class LROsCustomHeaderClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal LROsCustomHeaderRestClient RestClient { get; }

        /// <summary> Initializes a new instance of LROsCustomHeaderClient for mocking. </summary>
        protected LROsCustomHeaderClient()
        {
        }

        /// <summary> Initializes a new instance of LROsCustomHeaderClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal LROsCustomHeaderClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new LROsCustomHeaderRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsCustomHeaderPutAsyncRetrySucceededOperation> StartPutAsyncRetrySucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.StartPutAsyncRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutAsyncRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsCustomHeaderPutAsyncRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRetrySucceededRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsCustomHeaderPutAsyncRetrySucceededOperation StartPutAsyncRetrySucceeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.StartPutAsyncRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutAsyncRetrySucceeded(product, cancellationToken);
                return new LROsCustomHeaderPutAsyncRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRetrySucceededRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsCustomHeaderPut201CreatingSucceeded200Operation> StartPut201CreatingSucceeded200Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.StartPut201CreatingSucceeded200");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Put201CreatingSucceeded200Async(product, cancellationToken).ConfigureAwait(false);
                return new LROsCustomHeaderPut201CreatingSucceeded200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePut201CreatingSucceeded200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsCustomHeaderPut201CreatingSucceeded200Operation StartPut201CreatingSucceeded200(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.StartPut201CreatingSucceeded200");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Put201CreatingSucceeded200(product, cancellationToken);
                return new LROsCustomHeaderPut201CreatingSucceeded200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePut201CreatingSucceeded200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running post request, service returns a 202 to the initial request, with 'Location' and 'Retry-After' headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsCustomHeaderPost202Retry200Operation> StartPost202Retry200Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.StartPost202Retry200");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Post202Retry200Async(product, cancellationToken).ConfigureAwait(false);
                return new LROsCustomHeaderPost202Retry200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePost202Retry200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running post request, service returns a 202 to the initial request, with 'Location' and 'Retry-After' headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsCustomHeaderPost202Retry200Operation StartPost202Retry200(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.StartPost202Retry200");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Post202Retry200(product, cancellationToken);
                return new LROsCustomHeaderPost202Retry200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePost202Retry200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsCustomHeaderPostAsyncRetrySucceededOperation> StartPostAsyncRetrySucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.StartPostAsyncRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PostAsyncRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsCustomHeaderPostAsyncRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRetrySucceededRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsCustomHeaderPostAsyncRetrySucceededOperation StartPostAsyncRetrySucceeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.StartPostAsyncRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PostAsyncRetrySucceeded(product, cancellationToken);
                return new LROsCustomHeaderPostAsyncRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRetrySucceededRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
