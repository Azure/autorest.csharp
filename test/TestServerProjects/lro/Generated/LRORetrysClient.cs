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
    /// <summary> The LRORetrys service client. </summary>
    public partial class LRORetrysClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal LRORetrysRestClient RestClient { get; }

        /// <summary> Initializes a new instance of LRORetrysClient for mocking. </summary>
        protected LRORetrysClient()
        {
        }

        /// <summary> Initializes a new instance of LRORetrysClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal LRORetrysClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new LRORetrysRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Long running put request, service returns a 500, then a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LRORetrysPut201CreatingSucceeded200Operation> StartPut201CreatingSucceeded200Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.StartPut201CreatingSucceeded200");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Put201CreatingSucceeded200Async(product, cancellationToken).ConfigureAwait(false);
                return new LRORetrysPut201CreatingSucceeded200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePut201CreatingSucceeded200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 500, then a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LRORetrysPut201CreatingSucceeded200Operation StartPut201CreatingSucceeded200(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.StartPut201CreatingSucceeded200");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Put201CreatingSucceeded200(product, cancellationToken);
                return new LRORetrysPut201CreatingSucceeded200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePut201CreatingSucceeded200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 500, then a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LRORetrysPutAsyncRelativeRetrySucceededOperation> StartPutAsyncRelativeRetrySucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.StartPutAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PutAsyncRelativeRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
                return new LRORetrysPutAsyncRelativeRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRelativeRetrySucceededRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 500, then a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LRORetrysPutAsyncRelativeRetrySucceededOperation StartPutAsyncRelativeRetrySucceeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.StartPutAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PutAsyncRelativeRetrySucceeded(product, cancellationToken);
                return new LRORetrysPutAsyncRelativeRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePutAsyncRelativeRetrySucceededRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 500, then a  202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LRORetrysDeleteProvisioning202Accepted200SucceededOperation> StartDeleteProvisioning202Accepted200SucceededAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.StartDeleteProvisioning202Accepted200Succeeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteProvisioning202Accepted200SucceededAsync(cancellationToken).ConfigureAwait(false);
                return new LRORetrysDeleteProvisioning202Accepted200SucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteProvisioning202Accepted200SucceededRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 500, then a  202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LRORetrysDeleteProvisioning202Accepted200SucceededOperation StartDeleteProvisioning202Accepted200Succeeded(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.StartDeleteProvisioning202Accepted200Succeeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteProvisioning202Accepted200Succeeded(cancellationToken);
                return new LRORetrysDeleteProvisioning202Accepted200SucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteProvisioning202Accepted200SucceededRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LRORetrysDelete202Retry200Operation> StartDelete202Retry200Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.StartDelete202Retry200");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Delete202Retry200Async(cancellationToken).ConfigureAwait(false);
                return new LRORetrysDelete202Retry200Operation(_clientDiagnostics, _pipeline, RestClient.CreateDelete202Retry200Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LRORetrysDelete202Retry200Operation StartDelete202Retry200(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.StartDelete202Retry200");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Delete202Retry200(cancellationToken);
                return new LRORetrysDelete202Retry200Operation(_clientDiagnostics, _pipeline, RestClient.CreateDelete202Retry200Request().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LRORetrysDeleteAsyncRelativeRetrySucceededOperation> StartDeleteAsyncRelativeRetrySucceededAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.StartDeleteAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteAsyncRelativeRetrySucceededAsync(cancellationToken).ConfigureAwait(false);
                return new LRORetrysDeleteAsyncRelativeRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRelativeRetrySucceededRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LRORetrysDeleteAsyncRelativeRetrySucceededOperation StartDeleteAsyncRelativeRetrySucceeded(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.StartDeleteAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.DeleteAsyncRelativeRetrySucceeded(cancellationToken);
                return new LRORetrysDeleteAsyncRelativeRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteAsyncRelativeRetrySucceededRequest().Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with 'Location' and 'Retry-After' headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LRORetrysPost202Retry200Operation> StartPost202Retry200Async(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.StartPost202Retry200");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.Post202Retry200Async(product, cancellationToken).ConfigureAwait(false);
                return new LRORetrysPost202Retry200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePost202Retry200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with 'Location' and 'Retry-After' headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LRORetrysPost202Retry200Operation StartPost202Retry200(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.StartPost202Retry200");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Post202Retry200(product, cancellationToken);
                return new LRORetrysPost202Retry200Operation(_clientDiagnostics, _pipeline, RestClient.CreatePost202Retry200Request(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<LRORetrysPostAsyncRelativeRetrySucceededOperation> StartPostAsyncRelativeRetrySucceededAsync(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.StartPostAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PostAsyncRelativeRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
                return new LRORetrysPostAsyncRelativeRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRelativeRetrySucceededRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual LRORetrysPostAsyncRelativeRetrySucceededOperation StartPostAsyncRelativeRetrySucceeded(Product product = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.StartPostAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PostAsyncRelativeRetrySucceeded(product, cancellationToken);
                return new LRORetrysPostAsyncRelativeRetrySucceededOperation(_clientDiagnostics, _pipeline, RestClient.CreatePostAsyncRelativeRetrySucceededRequest(product).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
