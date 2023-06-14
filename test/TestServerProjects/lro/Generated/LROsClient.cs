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
    /// <summary> The LROs service client. </summary>
    public partial class LROsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal LROsRestClient RestClient { get; }

        /// <summary> Initializes a new instance of LROsClient for mocking. </summary>
        protected LROsClient()
        {
        }

        /// <summary> Initializes a new instance of LROsClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal LROsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new LROsRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPut200SucceededOperation> StartPut200SucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut200Succeeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Put200SucceededAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPut200SucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePut200SucceededRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPut200SucceededOperation StartPut200Succeeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut200Succeeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Put200Succeeded(product, cancellationToken);
                return new LROsPut200SucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePut200SucceededRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request with location header. We should not have any subsequent calls after receiving this first response. </summary>
        /// <param name="product"> Product to patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPatch200SucceededIgnoreHeadersOperation> StartPatch200SucceededIgnoreHeadersAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPatch200SucceededIgnoreHeaders");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Patch200SucceededIgnoreHeadersAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPatch200SucceededIgnoreHeadersOperation(_clientDiagnostics, _pipeline, RestClient.CreatePatch200SucceededIgnoreHeadersRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request with location header. We should not have any subsequent calls after receiving this first response. </summary>
        /// <param name="product"> Product to patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPatch200SucceededIgnoreHeadersOperation StartPatch200SucceededIgnoreHeaders(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPatch200SucceededIgnoreHeaders");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Patch200SucceededIgnoreHeaders(product, cancellationToken);
                return new LROsPatch200SucceededIgnoreHeadersOperation(_clientDiagnostics, _pipeline, RestClient.CreatePatch200SucceededIgnoreHeadersRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running patch request, service returns a 201 to the initial request with async header. </summary>
        /// <param name="product"> Product to patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPatch201RetryWithAsyncHeaderOperation> StartPatch201RetryWithAsyncHeaderAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPatch201RetryWithAsyncHeader");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Patch201RetryWithAsyncHeaderAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPatch201RetryWithAsyncHeaderOperation(_clientDiagnostics, _pipeline, RestClient.CreatePatch201RetryWithAsyncHeaderRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running patch request, service returns a 201 to the initial request with async header. </summary>
        /// <param name="product"> Product to patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPatch201RetryWithAsyncHeaderOperation StartPatch201RetryWithAsyncHeader(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPatch201RetryWithAsyncHeader");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Patch201RetryWithAsyncHeader(product, cancellationToken);
                return new LROsPatch201RetryWithAsyncHeaderOperation(_clientDiagnostics, _pipeline, RestClient.CreatePatch201RetryWithAsyncHeaderRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running patch request, service returns a 202 to the initial request with async and location header. </summary>
        /// <param name="product"> Product to patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPatch202RetryWithAsyncAndLocationHeaderOperation> StartPatch202RetryWithAsyncAndLocationHeaderAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPatch202RetryWithAsyncAndLocationHeader");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Patch202RetryWithAsyncAndLocationHeaderAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPatch202RetryWithAsyncAndLocationHeaderOperation(_clientDiagnostics, _pipeline, RestClient.CreatePatch202RetryWithAsyncAndLocationHeaderRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running patch request, service returns a 202 to the initial request with async and location header. </summary>
        /// <param name="product"> Product to patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPatch202RetryWithAsyncAndLocationHeaderOperation StartPatch202RetryWithAsyncAndLocationHeader(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPatch202RetryWithAsyncAndLocationHeader");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Patch202RetryWithAsyncAndLocationHeader(product, cancellationToken);
                return new LROsPatch202RetryWithAsyncAndLocationHeaderOperation(_clientDiagnostics, _pipeline, RestClient.CreatePatch202RetryWithAsyncAndLocationHeaderRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPut201SucceededOperation> StartPut201SucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut201Succeeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Put201SucceededAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPut201SucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePut201SucceededRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPut201SucceededOperation StartPut201Succeeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut201Succeeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Put201Succeeded(product, cancellationToken);
                return new LROsPut201SucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePut201SucceededRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 202 with empty body to first request, returns a 200 with body [{ 'id': '100', 'name': 'foo' }]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPost202ListOperation> StartPost202ListAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPost202List");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Post202ListAsync(cancellationToken).ConfigureAwait(false);
                return new LROsPost202ListOperation(_clientDiagnostics, _pipeline, RestClient.CreatePost202ListRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 202 with empty body to first request, returns a 200 with body [{ 'id': '100', 'name': 'foo' }]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPost202ListOperation StartPost202List(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPost202List");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Post202List(cancellationToken);
                return new LROsPost202ListOperation(_clientDiagnostics, _pipeline, RestClient.CreatePost202ListRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that does not contain ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPut200SucceededNoStateOperation> StartPut200SucceededNoStateAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut200SucceededNoState");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Put200SucceededNoStateAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPut200SucceededNoStateOperation(_clientDiagnostics, _pipeline, RestClient.CreatePut200SucceededNoStateRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that does not contain ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPut200SucceededNoStateOperation StartPut200SucceededNoState(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut200SucceededNoState");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Put200SucceededNoState(product, cancellationToken);
                return new LROsPut200SucceededNoStateOperation(_clientDiagnostics, _pipeline, RestClient.CreatePut200SucceededNoStateRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 202 to the initial request, with a location header that points to a polling URL that returns a 200 and an entity that doesn't contains ProvisioningState. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPut202Retry200Operation> StartPut202Retry200Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut202Retry200");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Put202Retry200Async(product, cancellationToken).ConfigureAwait(false);
                return new LROsPut202Retry200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePut202Retry200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 202 to the initial request, with a location header that points to a polling URL that returns a 200 and an entity that doesn't contains ProvisioningState. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPut202Retry200Operation StartPut202Retry200(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut202Retry200");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Put202Retry200(product, cancellationToken);
                return new LROsPut202Retry200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePut202Retry200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPut201CreatingSucceeded200Operation> StartPut201CreatingSucceeded200Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut201CreatingSucceeded200");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Put201CreatingSucceeded200Async(product, cancellationToken).ConfigureAwait(false);
                return new LROsPut201CreatingSucceeded200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePut201CreatingSucceeded200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPut201CreatingSucceeded200Operation StartPut201CreatingSucceeded200(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut201CreatingSucceeded200");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Put201CreatingSucceeded200(product, cancellationToken);
                return new LROsPut201CreatingSucceeded200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePut201CreatingSucceeded200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Updating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPut200UpdatingSucceeded204Operation> StartPut200UpdatingSucceeded204Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut200UpdatingSucceeded204");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Put200UpdatingSucceeded204Async(product, cancellationToken).ConfigureAwait(false);
                return new LROsPut200UpdatingSucceeded204Operation(_clientDiagnostics, _pipeline, RestClient.CreatePut200UpdatingSucceeded204Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Updating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPut200UpdatingSucceeded204Operation StartPut200UpdatingSucceeded204(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut200UpdatingSucceeded204");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Put200UpdatingSucceeded204(product, cancellationToken);
                return new LROsPut200UpdatingSucceeded204Operation(_clientDiagnostics, _pipeline, RestClient.CreatePut200UpdatingSucceeded204Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Created’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPut201CreatingFailed200Operation> StartPut201CreatingFailed200Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut201CreatingFailed200");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Put201CreatingFailed200Async(product, cancellationToken).ConfigureAwait(false);
                return new LROsPut201CreatingFailed200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePut201CreatingFailed200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Created’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPut201CreatingFailed200Operation StartPut201CreatingFailed200(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut201CreatingFailed200");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Put201CreatingFailed200(product, cancellationToken);
                return new LROsPut201CreatingFailed200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePut201CreatingFailed200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPut200Acceptedcanceled200Operation> StartPut200Acceptedcanceled200Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut200Acceptedcanceled200");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Put200Acceptedcanceled200Async(product, cancellationToken).ConfigureAwait(false);
                return new LROsPut200Acceptedcanceled200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePut200Acceptedcanceled200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPut200Acceptedcanceled200Operation StartPut200Acceptedcanceled200(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPut200Acceptedcanceled200");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Put200Acceptedcanceled200(product, cancellationToken);
                return new LROsPut200Acceptedcanceled200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePut200Acceptedcanceled200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 202 to the initial request with location header. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPutNoHeaderInRetryOperation> StartPutNoHeaderInRetryAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutNoHeaderInRetry");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutNoHeaderInRetryAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPutNoHeaderInRetryOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutNoHeaderInRetryRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 202 to the initial request with location header. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPutNoHeaderInRetryOperation StartPutNoHeaderInRetry(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutNoHeaderInRetry");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutNoHeaderInRetry(product, cancellationToken);
                return new LROsPutNoHeaderInRetryOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutNoHeaderInRetryRequest(product).Request, originalResponse);
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
        public virtual async Task<LROsPutAsyncRetrySucceededOperation> StartPutAsyncRetrySucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutAsyncRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutAsyncRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPutAsyncRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRetrySucceededRequest(product).Request, originalResponse);
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
        public virtual LROsPutAsyncRetrySucceededOperation StartPutAsyncRetrySucceeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutAsyncRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutAsyncRetrySucceeded(product, cancellationToken);
                return new LROsPutAsyncRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRetrySucceededRequest(product).Request, originalResponse);
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
        public virtual async Task<LROsPutAsyncNoRetrySucceededOperation> StartPutAsyncNoRetrySucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutAsyncNoRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPutAsyncNoRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncNoRetrySucceededRequest(product).Request, originalResponse);
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
        public virtual LROsPutAsyncNoRetrySucceededOperation StartPutAsyncNoRetrySucceeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutAsyncNoRetrySucceeded(product, cancellationToken);
                return new LROsPutAsyncNoRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncNoRetrySucceededRequest(product).Request, originalResponse);
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
        public virtual async Task<LROsPutAsyncRetryFailedOperation> StartPutAsyncRetryFailedAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutAsyncRetryFailed");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutAsyncRetryFailedAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPutAsyncRetryFailedOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRetryFailedRequest(product).Request, originalResponse);
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
        public virtual LROsPutAsyncRetryFailedOperation StartPutAsyncRetryFailed(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutAsyncRetryFailed");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutAsyncRetryFailed(product, cancellationToken);
                return new LROsPutAsyncRetryFailedOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRetryFailedRequest(product).Request, originalResponse);
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
        public virtual async Task<LROsPutAsyncNoRetrycanceledOperation> StartPutAsyncNoRetrycanceledAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutAsyncNoRetrycanceled");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutAsyncNoRetrycanceledAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPutAsyncNoRetrycanceledOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncNoRetrycanceledRequest(product).Request, originalResponse);
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
        public virtual LROsPutAsyncNoRetrycanceledOperation StartPutAsyncNoRetrycanceled(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutAsyncNoRetrycanceled");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutAsyncNoRetrycanceled(product, cancellationToken);
                return new LROsPutAsyncNoRetrycanceledOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncNoRetrycanceledRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 202 to the initial request with Azure-AsyncOperation header. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPutAsyncNoHeaderInRetryOperation> StartPutAsyncNoHeaderInRetryAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutAsyncNoHeaderInRetry");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutAsyncNoHeaderInRetryAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPutAsyncNoHeaderInRetryOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncNoHeaderInRetryRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 202 to the initial request with Azure-AsyncOperation header. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPutAsyncNoHeaderInRetryOperation StartPutAsyncNoHeaderInRetry(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutAsyncNoHeaderInRetry");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutAsyncNoHeaderInRetry(product, cancellationToken);
                return new LROsPutAsyncNoHeaderInRetryOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncNoHeaderInRetryRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPutNonResourceOperation> StartPutNonResourceAsync(Sku sku = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutNonResource");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutNonResourceAsync(sku, cancellationToken).ConfigureAwait(false);
                return new LROsPutNonResourceOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutNonResourceRequest(sku).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPutNonResourceOperation StartPutNonResource(Sku sku = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutNonResource");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutNonResource(sku, cancellationToken);
                return new LROsPutNonResourceOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutNonResourceRequest(sku).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> Sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPutAsyncNonResourceOperation> StartPutAsyncNonResourceAsync(Sku sku = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutAsyncNonResource");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutAsyncNonResourceAsync(sku, cancellationToken).ConfigureAwait(false);
                return new LROsPutAsyncNonResourceOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncNonResourceRequest(sku).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> Sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPutAsyncNonResourceOperation StartPutAsyncNonResource(Sku sku = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutAsyncNonResource");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutAsyncNonResource(sku, cancellationToken);
                return new LROsPutAsyncNonResourceOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncNonResourceRequest(sku).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPutSubResourceOperation> StartPutSubResourceAsync(SubProduct product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutSubResource");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutSubResourceAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPutSubResourceOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutSubResourceRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPutSubResourceOperation StartPutSubResource(SubProduct product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutSubResource");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutSubResource(product, cancellationToken);
                return new LROsPutSubResourceOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutSubResourceRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPutAsyncSubResourceOperation> StartPutAsyncSubResourceAsync(SubProduct product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutAsyncSubResource");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutAsyncSubResourceAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPutAsyncSubResourceOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncSubResourceRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPutAsyncSubResourceOperation StartPutAsyncSubResource(SubProduct product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPutAsyncSubResource");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutAsyncSubResource(product, cancellationToken);
                return new LROsPutAsyncSubResourceOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncSubResourceRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsDeleteProvisioning202Accepted200SucceededOperation> StartDeleteProvisioning202Accepted200SucceededAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteProvisioning202Accepted200Succeeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteProvisioning202Accepted200SucceededAsync(cancellationToken).ConfigureAwait(false);
                return new LROsDeleteProvisioning202Accepted200SucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteProvisioning202Accepted200SucceededRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsDeleteProvisioning202Accepted200SucceededOperation StartDeleteProvisioning202Accepted200Succeeded(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteProvisioning202Accepted200Succeeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteProvisioning202Accepted200Succeeded(cancellationToken);
                return new LROsDeleteProvisioning202Accepted200SucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteProvisioning202Accepted200SucceededRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsDeleteProvisioning202DeletingFailed200Operation> StartDeleteProvisioning202DeletingFailed200Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteProvisioning202DeletingFailed200");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteProvisioning202DeletingFailed200Async(cancellationToken).ConfigureAwait(false);
                return new LROsDeleteProvisioning202DeletingFailed200Operation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteProvisioning202DeletingFailed200Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsDeleteProvisioning202DeletingFailed200Operation StartDeleteProvisioning202DeletingFailed200(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteProvisioning202DeletingFailed200");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteProvisioning202DeletingFailed200(cancellationToken);
                return new LROsDeleteProvisioning202DeletingFailed200Operation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteProvisioning202DeletingFailed200Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsDeleteProvisioning202Deletingcanceled200Operation> StartDeleteProvisioning202Deletingcanceled200Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteProvisioning202Deletingcanceled200");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteProvisioning202Deletingcanceled200Async(cancellationToken).ConfigureAwait(false);
                return new LROsDeleteProvisioning202Deletingcanceled200Operation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteProvisioning202Deletingcanceled200Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsDeleteProvisioning202Deletingcanceled200Operation StartDeleteProvisioning202Deletingcanceled200(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteProvisioning202Deletingcanceled200");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteProvisioning202Deletingcanceled200(cancellationToken);
                return new LROsDeleteProvisioning202Deletingcanceled200Operation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteProvisioning202Deletingcanceled200Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete succeeds and returns right away. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsDelete204SucceededOperation> StartDelete204SucceededAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDelete204Succeeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Delete204SucceededAsync(cancellationToken).ConfigureAwait(false);
                return new LROsDelete204SucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreateDelete204SucceededRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete succeeds and returns right away. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsDelete204SucceededOperation StartDelete204Succeeded(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDelete204Succeeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Delete204Succeeded(cancellationToken);
                return new LROsDelete204SucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreateDelete204SucceededRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsDelete202Retry200Operation> StartDelete202Retry200Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDelete202Retry200");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Delete202Retry200Async(cancellationToken).ConfigureAwait(false);
                return new LROsDelete202Retry200Operation(_clientDiagnostics, _pipeline, RestClient.CreateDelete202Retry200Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsDelete202Retry200Operation StartDelete202Retry200(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDelete202Retry200");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Delete202Retry200(cancellationToken);
                return new LROsDelete202Retry200Operation(_clientDiagnostics, _pipeline, RestClient.CreateDelete202Retry200Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsDelete202NoRetry204Operation> StartDelete202NoRetry204Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDelete202NoRetry204");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Delete202NoRetry204Async(cancellationToken).ConfigureAwait(false);
                return new LROsDelete202NoRetry204Operation(_clientDiagnostics, _pipeline, RestClient.CreateDelete202NoRetry204Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsDelete202NoRetry204Operation StartDelete202NoRetry204(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDelete202NoRetry204");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Delete202NoRetry204(cancellationToken);
                return new LROsDelete202NoRetry204Operation(_clientDiagnostics, _pipeline, RestClient.CreateDelete202NoRetry204Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a location header in the initial request. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsDeleteNoHeaderInRetryOperation> StartDeleteNoHeaderInRetryAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteNoHeaderInRetry");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteNoHeaderInRetryAsync(cancellationToken).ConfigureAwait(false);
                return new LROsDeleteNoHeaderInRetryOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteNoHeaderInRetryRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a location header in the initial request. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsDeleteNoHeaderInRetryOperation StartDeleteNoHeaderInRetry(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteNoHeaderInRetry");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteNoHeaderInRetry(cancellationToken);
                return new LROsDeleteNoHeaderInRetryOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteNoHeaderInRetryRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns an Azure-AsyncOperation header in the initial request. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsDeleteAsyncNoHeaderInRetryOperation> StartDeleteAsyncNoHeaderInRetryAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteAsyncNoHeaderInRetry");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteAsyncNoHeaderInRetryAsync(cancellationToken).ConfigureAwait(false);
                return new LROsDeleteAsyncNoHeaderInRetryOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncNoHeaderInRetryRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns an Azure-AsyncOperation header in the initial request. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsDeleteAsyncNoHeaderInRetryOperation StartDeleteAsyncNoHeaderInRetry(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteAsyncNoHeaderInRetry");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteAsyncNoHeaderInRetry(cancellationToken);
                return new LROsDeleteAsyncNoHeaderInRetryOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncNoHeaderInRetryRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsDeleteAsyncRetrySucceededOperation> StartDeleteAsyncRetrySucceededAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteAsyncRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteAsyncRetrySucceededAsync(cancellationToken).ConfigureAwait(false);
                return new LROsDeleteAsyncRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRetrySucceededRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsDeleteAsyncRetrySucceededOperation StartDeleteAsyncRetrySucceeded(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteAsyncRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteAsyncRetrySucceeded(cancellationToken);
                return new LROsDeleteAsyncRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRetrySucceededRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsDeleteAsyncNoRetrySucceededOperation> StartDeleteAsyncNoRetrySucceededAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteAsyncNoRetrySucceededAsync(cancellationToken).ConfigureAwait(false);
                return new LROsDeleteAsyncNoRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncNoRetrySucceededRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsDeleteAsyncNoRetrySucceededOperation StartDeleteAsyncNoRetrySucceeded(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteAsyncNoRetrySucceeded(cancellationToken);
                return new LROsDeleteAsyncNoRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncNoRetrySucceededRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsDeleteAsyncRetryFailedOperation> StartDeleteAsyncRetryFailedAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteAsyncRetryFailed");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteAsyncRetryFailedAsync(cancellationToken).ConfigureAwait(false);
                return new LROsDeleteAsyncRetryFailedOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRetryFailedRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsDeleteAsyncRetryFailedOperation StartDeleteAsyncRetryFailed(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteAsyncRetryFailed");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteAsyncRetryFailed(cancellationToken);
                return new LROsDeleteAsyncRetryFailedOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRetryFailedRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsDeleteAsyncRetrycanceledOperation> StartDeleteAsyncRetrycanceledAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteAsyncRetrycanceled");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteAsyncRetrycanceledAsync(cancellationToken).ConfigureAwait(false);
                return new LROsDeleteAsyncRetrycanceledOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRetrycanceledRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsDeleteAsyncRetrycanceledOperation StartDeleteAsyncRetrycanceled(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartDeleteAsyncRetrycanceled");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteAsyncRetrycanceled(cancellationToken);
                return new LROsDeleteAsyncRetrycanceledOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRetrycanceledRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with 'Location' header. Poll returns a 200 with a response body after success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPost200WithPayloadOperation> StartPost200WithPayloadAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPost200WithPayload");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Post200WithPayloadAsync(cancellationToken).ConfigureAwait(false);
                return new LROsPost200WithPayloadOperation(_clientDiagnostics, _pipeline, RestClient.CreatePost200WithPayloadRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with 'Location' header. Poll returns a 200 with a response body after success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPost200WithPayloadOperation StartPost200WithPayload(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPost200WithPayload");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Post200WithPayload(cancellationToken);
                return new LROsPost200WithPayloadOperation(_clientDiagnostics, _pipeline, RestClient.CreatePost200WithPayloadRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with 'Location' and 'Retry-After' headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPost202Retry200Operation> StartPost202Retry200Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPost202Retry200");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Post202Retry200Async(product, cancellationToken).ConfigureAwait(false);
                return new LROsPost202Retry200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePost202Retry200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with 'Location' and 'Retry-After' headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPost202Retry200Operation StartPost202Retry200(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPost202Retry200");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Post202Retry200(product, cancellationToken);
                return new LROsPost202Retry200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePost202Retry200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with 'Location' header, 204 with noresponse body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPost202NoRetry204Operation> StartPost202NoRetry204Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPost202NoRetry204");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Post202NoRetry204Async(product, cancellationToken).ConfigureAwait(false);
                return new LROsPost202NoRetry204Operation(_clientDiagnostics, _pipeline, RestClient.CreatePost202NoRetry204Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request, with 'Location' header, 204 with noresponse body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPost202NoRetry204Operation StartPost202NoRetry204(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPost202NoRetry204");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Post202NoRetry204(product, cancellationToken);
                return new LROsPost202NoRetry204Operation(_clientDiagnostics, _pipeline, RestClient.CreatePost202NoRetry204Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it's success. Should poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPostDoubleHeadersFinalLocationGetOperation> StartPostDoubleHeadersFinalLocationGetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPostDoubleHeadersFinalLocationGet");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PostDoubleHeadersFinalLocationGetAsync(cancellationToken).ConfigureAwait(false);
                return new LROsPostDoubleHeadersFinalLocationGetOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostDoubleHeadersFinalLocationGetRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it's success. Should poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPostDoubleHeadersFinalLocationGetOperation StartPostDoubleHeadersFinalLocationGet(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPostDoubleHeadersFinalLocationGet");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PostDoubleHeadersFinalLocationGet(cancellationToken);
                return new LROsPostDoubleHeadersFinalLocationGetOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostDoubleHeadersFinalLocationGetRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it's success. Should NOT poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPostDoubleHeadersFinalAzureHeaderGetOperation> StartPostDoubleHeadersFinalAzureHeaderGetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPostDoubleHeadersFinalAzureHeaderGet");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PostDoubleHeadersFinalAzureHeaderGetAsync(cancellationToken).ConfigureAwait(false);
                return new LROsPostDoubleHeadersFinalAzureHeaderGetOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostDoubleHeadersFinalAzureHeaderGetRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it's success. Should NOT poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPostDoubleHeadersFinalAzureHeaderGetOperation StartPostDoubleHeadersFinalAzureHeaderGet(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPostDoubleHeadersFinalAzureHeaderGet");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PostDoubleHeadersFinalAzureHeaderGet(cancellationToken);
                return new LROsPostDoubleHeadersFinalAzureHeaderGetOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostDoubleHeadersFinalAzureHeaderGetRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it's success. Should NOT poll Location to get the final object if you support initial Autorest behavior. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LROsPostDoubleHeadersFinalAzureHeaderGetDefaultOperation> StartPostDoubleHeadersFinalAzureHeaderGetDefaultAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPostDoubleHeadersFinalAzureHeaderGetDefault");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PostDoubleHeadersFinalAzureHeaderGetDefaultAsync(cancellationToken).ConfigureAwait(false);
                return new LROsPostDoubleHeadersFinalAzureHeaderGetDefaultOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostDoubleHeadersFinalAzureHeaderGetDefaultRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it's success. Should NOT poll Location to get the final object if you support initial Autorest behavior. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LROsPostDoubleHeadersFinalAzureHeaderGetDefaultOperation StartPostDoubleHeadersFinalAzureHeaderGetDefault(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPostDoubleHeadersFinalAzureHeaderGetDefault");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PostDoubleHeadersFinalAzureHeaderGetDefault(cancellationToken);
                return new LROsPostDoubleHeadersFinalAzureHeaderGetDefaultOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostDoubleHeadersFinalAzureHeaderGetDefaultRequest().Request, originalResponse);
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
        public virtual async Task<LROsPostAsyncRetrySucceededOperation> StartPostAsyncRetrySucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPostAsyncRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PostAsyncRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPostAsyncRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRetrySucceededRequest(product).Request, originalResponse);
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
        public virtual LROsPostAsyncRetrySucceededOperation StartPostAsyncRetrySucceeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPostAsyncRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PostAsyncRetrySucceeded(product, cancellationToken);
                return new LROsPostAsyncRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRetrySucceededRequest(product).Request, originalResponse);
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
        public virtual async Task<LROsPostAsyncNoRetrySucceededOperation> StartPostAsyncNoRetrySucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPostAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PostAsyncNoRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPostAsyncNoRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncNoRetrySucceededRequest(product).Request, originalResponse);
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
        public virtual LROsPostAsyncNoRetrySucceededOperation StartPostAsyncNoRetrySucceeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPostAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PostAsyncNoRetrySucceeded(product, cancellationToken);
                return new LROsPostAsyncNoRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncNoRetrySucceededRequest(product).Request, originalResponse);
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
        public virtual async Task<LROsPostAsyncRetryFailedOperation> StartPostAsyncRetryFailedAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPostAsyncRetryFailed");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PostAsyncRetryFailedAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPostAsyncRetryFailedOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRetryFailedRequest(product).Request, originalResponse);
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
        public virtual LROsPostAsyncRetryFailedOperation StartPostAsyncRetryFailed(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPostAsyncRetryFailed");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PostAsyncRetryFailed(product, cancellationToken);
                return new LROsPostAsyncRetryFailedOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRetryFailedRequest(product).Request, originalResponse);
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
        public virtual async Task<LROsPostAsyncRetrycanceledOperation> StartPostAsyncRetrycanceledAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPostAsyncRetrycanceled");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PostAsyncRetrycanceledAsync(product, cancellationToken).ConfigureAwait(false);
                return new LROsPostAsyncRetrycanceledOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRetrycanceledRequest(product).Request, originalResponse);
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
        public virtual LROsPostAsyncRetrycanceledOperation StartPostAsyncRetrycanceled(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LROsClient.StartPostAsyncRetrycanceled");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PostAsyncRetrycanceled(product, cancellationToken);
                return new LROsPostAsyncRetrycanceledOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRetrycanceledRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
