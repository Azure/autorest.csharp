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
    /// <summary> The LrosaDs service client. </summary>
    public partial class LrosaDsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal LrosaDsRestClient RestClient { get; }

        /// <summary> Initializes a new instance of LrosaDsClient for mocking. </summary>
        protected LrosaDsClient()
        {
        }

        /// <summary> Initializes a new instance of LrosaDsClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal LrosaDsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new LrosaDsRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Long running put request, service returns a 400 to the initial request. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPutNonRetry400Operation> StartPutNonRetry400Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutNonRetry400");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutNonRetry400Async(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPutNonRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreatePutNonRetry400Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 400 to the initial request. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPutNonRetry400Operation StartPutNonRetry400(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutNonRetry400");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutNonRetry400(product, cancellationToken);
                return new LrosaDsPutNonRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreatePutNonRetry400Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a Product with 'ProvisioningState' = 'Creating' and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPutNonRetry201Creating400Operation> StartPutNonRetry201Creating400Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutNonRetry201Creating400");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutNonRetry201Creating400Async(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPutNonRetry201Creating400Operation(_clientDiagnostics, _pipeline, RestClient.CreatePutNonRetry201Creating400Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a Product with 'ProvisioningState' = 'Creating' and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPutNonRetry201Creating400Operation StartPutNonRetry201Creating400(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutNonRetry201Creating400");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutNonRetry201Creating400(product, cancellationToken);
                return new LrosaDsPutNonRetry201Creating400Operation(_clientDiagnostics, _pipeline, RestClient.CreatePutNonRetry201Creating400Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a Product with 'ProvisioningState' = 'Creating' and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPutNonRetry201Creating400InvalidJsonOperation> StartPutNonRetry201Creating400InvalidJsonAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutNonRetry201Creating400InvalidJson");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutNonRetry201Creating400InvalidJsonAsync(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPutNonRetry201Creating400InvalidJsonOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutNonRetry201Creating400InvalidJsonRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a Product with 'ProvisioningState' = 'Creating' and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPutNonRetry201Creating400InvalidJsonOperation StartPutNonRetry201Creating400InvalidJson(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutNonRetry201Creating400InvalidJson");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutNonRetry201Creating400InvalidJson(product, cancellationToken);
                return new LrosaDsPutNonRetry201Creating400InvalidJsonOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutNonRetry201Creating400InvalidJsonRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 with ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPutAsyncRelativeRetry400Operation> StartPutAsyncRelativeRetry400Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutAsyncRelativeRetry400");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutAsyncRelativeRetry400Async(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPutAsyncRelativeRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRelativeRetry400Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 with ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPutAsyncRelativeRetry400Operation StartPutAsyncRelativeRetry400(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutAsyncRelativeRetry400");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutAsyncRelativeRetry400(product, cancellationToken);
                return new LrosaDsPutAsyncRelativeRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRelativeRetry400Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 400 with an error body. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsDeleteNonRetry400Operation> StartDeleteNonRetry400Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDeleteNonRetry400");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteNonRetry400Async(cancellationToken).ConfigureAwait(false);
                return new LrosaDsDeleteNonRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteNonRetry400Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 400 with an error body. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsDeleteNonRetry400Operation StartDeleteNonRetry400(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDeleteNonRetry400");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteNonRetry400(cancellationToken);
                return new LrosaDsDeleteNonRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteNonRetry400Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 with a location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsDelete202NonRetry400Operation> StartDelete202NonRetry400Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDelete202NonRetry400");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Delete202NonRetry400Async(cancellationToken).ConfigureAwait(false);
                return new LrosaDsDelete202NonRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreateDelete202NonRetry400Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 with a location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsDelete202NonRetry400Operation StartDelete202NonRetry400(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDelete202NonRetry400");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Delete202NonRetry400(cancellationToken);
                return new LrosaDsDelete202NonRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreateDelete202NonRetry400Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsDeleteAsyncRelativeRetry400Operation> StartDeleteAsyncRelativeRetry400Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDeleteAsyncRelativeRetry400");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteAsyncRelativeRetry400Async(cancellationToken).ConfigureAwait(false);
                return new LrosaDsDeleteAsyncRelativeRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRelativeRetry400Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsDeleteAsyncRelativeRetry400Operation StartDeleteAsyncRelativeRetry400(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDeleteAsyncRelativeRetry400");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteAsyncRelativeRetry400(cancellationToken);
                return new LrosaDsDeleteAsyncRelativeRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRelativeRetry400Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 400 with no error body. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPostNonRetry400Operation> StartPostNonRetry400Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPostNonRetry400");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PostNonRetry400Async(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPostNonRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreatePostNonRetry400Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 400 with no error body. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPostNonRetry400Operation StartPostNonRetry400(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPostNonRetry400");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PostNonRetry400(product, cancellationToken);
                return new LrosaDsPostNonRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreatePostNonRetry400Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 with a location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPost202NonRetry400Operation> StartPost202NonRetry400Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPost202NonRetry400");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Post202NonRetry400Async(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPost202NonRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreatePost202NonRetry400Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 with a location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPost202NonRetry400Operation StartPost202NonRetry400(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPost202NonRetry400");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Post202NonRetry400(product, cancellationToken);
                return new LrosaDsPost202NonRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreatePost202NonRetry400Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPostAsyncRelativeRetry400Operation> StartPostAsyncRelativeRetry400Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPostAsyncRelativeRetry400");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PostAsyncRelativeRetry400Async(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPostAsyncRelativeRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRelativeRetry400Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPostAsyncRelativeRetry400Operation StartPostAsyncRelativeRetry400(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPostAsyncRelativeRetry400");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PostAsyncRelativeRetry400(product, cancellationToken);
                return new LrosaDsPostAsyncRelativeRetry400Operation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRelativeRetry400Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request with no payload. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPutError201NoProvisioningStatePayloadOperation> StartPutError201NoProvisioningStatePayloadAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutError201NoProvisioningStatePayload");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutError201NoProvisioningStatePayloadAsync(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPutError201NoProvisioningStatePayloadOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutError201NoProvisioningStatePayloadRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request with no payload. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPutError201NoProvisioningStatePayloadOperation StartPutError201NoProvisioningStatePayload(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutError201NoProvisioningStatePayload");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutError201NoProvisioningStatePayload(product, cancellationToken);
                return new LrosaDsPutError201NoProvisioningStatePayloadOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutError201NoProvisioningStatePayloadRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPutAsyncRelativeRetryNoStatusOperation> StartPutAsyncRelativeRetryNoStatusAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutAsyncRelativeRetryNoStatus");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutAsyncRelativeRetryNoStatusAsync(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPutAsyncRelativeRetryNoStatusOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRelativeRetryNoStatusRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPutAsyncRelativeRetryNoStatusOperation StartPutAsyncRelativeRetryNoStatus(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutAsyncRelativeRetryNoStatus");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutAsyncRelativeRetryNoStatus(product, cancellationToken);
                return new LrosaDsPutAsyncRelativeRetryNoStatusOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRelativeRetryNoStatusRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPutAsyncRelativeRetryNoStatusPayloadOperation> StartPutAsyncRelativeRetryNoStatusPayloadAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutAsyncRelativeRetryNoStatusPayload");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutAsyncRelativeRetryNoStatusPayloadAsync(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPutAsyncRelativeRetryNoStatusPayloadOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRelativeRetryNoStatusPayloadRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPutAsyncRelativeRetryNoStatusPayloadOperation StartPutAsyncRelativeRetryNoStatusPayload(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutAsyncRelativeRetryNoStatusPayload");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutAsyncRelativeRetryNoStatusPayload(product, cancellationToken);
                return new LrosaDsPutAsyncRelativeRetryNoStatusPayloadOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRelativeRetryNoStatusPayloadRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 204 to the initial request, indicating success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsDelete204SucceededOperation> StartDelete204SucceededAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDelete204Succeeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Delete204SucceededAsync(cancellationToken).ConfigureAwait(false);
                return new LrosaDsDelete204SucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreateDelete204SucceededRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 204 to the initial request, indicating success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsDelete204SucceededOperation StartDelete204Succeeded(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDelete204Succeeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Delete204Succeeded(cancellationToken);
                return new LrosaDsDelete204SucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreateDelete204SucceededRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsDeleteAsyncRelativeRetryNoStatusOperation> StartDeleteAsyncRelativeRetryNoStatusAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDeleteAsyncRelativeRetryNoStatus");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteAsyncRelativeRetryNoStatusAsync(cancellationToken).ConfigureAwait(false);
                return new LrosaDsDeleteAsyncRelativeRetryNoStatusOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRelativeRetryNoStatusRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsDeleteAsyncRelativeRetryNoStatusOperation StartDeleteAsyncRelativeRetryNoStatus(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDeleteAsyncRelativeRetryNoStatus");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteAsyncRelativeRetryNoStatus(cancellationToken);
                return new LrosaDsDeleteAsyncRelativeRetryNoStatusOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRelativeRetryNoStatusRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, without a location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPost202NoLocationOperation> StartPost202NoLocationAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPost202NoLocation");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Post202NoLocationAsync(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPost202NoLocationOperation(_clientDiagnostics, _pipeline, RestClient.CreatePost202NoLocationRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, without a location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPost202NoLocationOperation StartPost202NoLocation(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPost202NoLocation");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Post202NoLocation(product, cancellationToken);
                return new LrosaDsPost202NoLocationOperation(_clientDiagnostics, _pipeline, RestClient.CreatePost202NoLocationRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPostAsyncRelativeRetryNoPayloadOperation> StartPostAsyncRelativeRetryNoPayloadAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPostAsyncRelativeRetryNoPayload");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PostAsyncRelativeRetryNoPayloadAsync(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPostAsyncRelativeRetryNoPayloadOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRelativeRetryNoPayloadRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPostAsyncRelativeRetryNoPayloadOperation StartPostAsyncRelativeRetryNoPayload(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPostAsyncRelativeRetryNoPayload");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PostAsyncRelativeRetryNoPayload(product, cancellationToken);
                return new LrosaDsPostAsyncRelativeRetryNoPayloadOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRelativeRetryNoPayloadRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that is not a valid json. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPut200InvalidJsonOperation> StartPut200InvalidJsonAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPut200InvalidJson");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Put200InvalidJsonAsync(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPut200InvalidJsonOperation(_clientDiagnostics, _pipeline, RestClient.CreatePut200InvalidJsonRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that is not a valid json. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPut200InvalidJsonOperation StartPut200InvalidJson(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPut200InvalidJson");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Put200InvalidJson(product, cancellationToken);
                return new LrosaDsPut200InvalidJsonOperation(_clientDiagnostics, _pipeline, RestClient.CreatePut200InvalidJsonRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPutAsyncRelativeRetryInvalidHeaderOperation> StartPutAsyncRelativeRetryInvalidHeaderAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutAsyncRelativeRetryInvalidHeaderAsync(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPutAsyncRelativeRetryInvalidHeaderOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRelativeRetryInvalidHeaderRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPutAsyncRelativeRetryInvalidHeaderOperation StartPutAsyncRelativeRetryInvalidHeader(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutAsyncRelativeRetryInvalidHeader(product, cancellationToken);
                return new LrosaDsPutAsyncRelativeRetryInvalidHeaderOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRelativeRetryInvalidHeaderRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPutAsyncRelativeRetryInvalidJsonPollingOperation> StartPutAsyncRelativeRetryInvalidJsonPollingAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutAsyncRelativeRetryInvalidJsonPollingAsync(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPutAsyncRelativeRetryInvalidJsonPollingOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRelativeRetryInvalidJsonPollingRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPutAsyncRelativeRetryInvalidJsonPollingOperation StartPutAsyncRelativeRetryInvalidJsonPolling(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPutAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutAsyncRelativeRetryInvalidJsonPolling(product, cancellationToken);
                return new LrosaDsPutAsyncRelativeRetryInvalidJsonPollingOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRelativeRetryInvalidJsonPollingRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request receing a reponse with an invalid 'Location' and 'Retry-After' headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsDelete202RetryInvalidHeaderOperation> StartDelete202RetryInvalidHeaderAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDelete202RetryInvalidHeader");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Delete202RetryInvalidHeaderAsync(cancellationToken).ConfigureAwait(false);
                return new LrosaDsDelete202RetryInvalidHeaderOperation(_clientDiagnostics, _pipeline, RestClient.CreateDelete202RetryInvalidHeaderRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request receing a reponse with an invalid 'Location' and 'Retry-After' headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsDelete202RetryInvalidHeaderOperation StartDelete202RetryInvalidHeader(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDelete202RetryInvalidHeader");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Delete202RetryInvalidHeader(cancellationToken);
                return new LrosaDsDelete202RetryInvalidHeaderOperation(_clientDiagnostics, _pipeline, RestClient.CreateDelete202RetryInvalidHeaderRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsDeleteAsyncRelativeRetryInvalidHeaderOperation> StartDeleteAsyncRelativeRetryInvalidHeaderAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDeleteAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteAsyncRelativeRetryInvalidHeaderAsync(cancellationToken).ConfigureAwait(false);
                return new LrosaDsDeleteAsyncRelativeRetryInvalidHeaderOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRelativeRetryInvalidHeaderRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsDeleteAsyncRelativeRetryInvalidHeaderOperation StartDeleteAsyncRelativeRetryInvalidHeader(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDeleteAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteAsyncRelativeRetryInvalidHeader(cancellationToken);
                return new LrosaDsDeleteAsyncRelativeRetryInvalidHeaderOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRelativeRetryInvalidHeaderRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsDeleteAsyncRelativeRetryInvalidJsonPollingOperation> StartDeleteAsyncRelativeRetryInvalidJsonPollingAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDeleteAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteAsyncRelativeRetryInvalidJsonPollingAsync(cancellationToken).ConfigureAwait(false);
                return new LrosaDsDeleteAsyncRelativeRetryInvalidJsonPollingOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRelativeRetryInvalidJsonPollingRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsDeleteAsyncRelativeRetryInvalidJsonPollingOperation StartDeleteAsyncRelativeRetryInvalidJsonPolling(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartDeleteAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteAsyncRelativeRetryInvalidJsonPolling(cancellationToken);
                return new LrosaDsDeleteAsyncRelativeRetryInvalidJsonPollingOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRelativeRetryInvalidJsonPollingRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with invalid 'Location' and 'Retry-After' headers. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPost202RetryInvalidHeaderOperation> StartPost202RetryInvalidHeaderAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPost202RetryInvalidHeader");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Post202RetryInvalidHeaderAsync(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPost202RetryInvalidHeaderOperation(_clientDiagnostics, _pipeline, RestClient.CreatePost202RetryInvalidHeaderRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with invalid 'Location' and 'Retry-After' headers. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPost202RetryInvalidHeaderOperation StartPost202RetryInvalidHeader(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPost202RetryInvalidHeader");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Post202RetryInvalidHeader(product, cancellationToken);
                return new LrosaDsPost202RetryInvalidHeaderOperation(_clientDiagnostics, _pipeline, RestClient.CreatePost202RetryInvalidHeaderRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPostAsyncRelativeRetryInvalidHeaderOperation> StartPostAsyncRelativeRetryInvalidHeaderAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPostAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PostAsyncRelativeRetryInvalidHeaderAsync(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPostAsyncRelativeRetryInvalidHeaderOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRelativeRetryInvalidHeaderRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPostAsyncRelativeRetryInvalidHeaderOperation StartPostAsyncRelativeRetryInvalidHeader(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPostAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PostAsyncRelativeRetryInvalidHeader(product, cancellationToken);
                return new LrosaDsPostAsyncRelativeRetryInvalidHeaderOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRelativeRetryInvalidHeaderRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LrosaDsPostAsyncRelativeRetryInvalidJsonPollingOperation> StartPostAsyncRelativeRetryInvalidJsonPollingAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPostAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PostAsyncRelativeRetryInvalidJsonPollingAsync(product, cancellationToken).ConfigureAwait(false);
                return new LrosaDsPostAsyncRelativeRetryInvalidJsonPollingOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRelativeRetryInvalidJsonPollingRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LrosaDsPostAsyncRelativeRetryInvalidJsonPollingOperation StartPostAsyncRelativeRetryInvalidJsonPolling(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LrosaDsClient.StartPostAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PostAsyncRelativeRetryInvalidJsonPolling(product, cancellationToken);
                return new LrosaDsPostAsyncRelativeRetryInvalidJsonPollingOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRelativeRetryInvalidJsonPollingRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
