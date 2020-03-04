// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using lro.Models;

namespace lro
{
    public partial class LROsCustomHeaderClient
    {
        private LROsCustomHeaderRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of LROsCustomHeaderClient. </summary>
        internal LROsCustomHeaderClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new LROsCustomHeaderRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutAsyncRetrySucceededOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsCustomHeaderClient.PutAsyncRetrySucceeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
            (response, cancellationToken) =>
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return value;
            },
            async (response, cancellationToken) =>
            {
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var value = Product.DeserializeProduct(document.RootElement);
                return value;
            });
        }
        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutAsyncRetrySucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await restClient.PutAsyncRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncRetrySucceededOperation(originalResponse, () => restClient.CreatePutAsyncRetrySucceededRequest(product));
        }
        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncRetrySucceededOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = restClient.PutAsyncRetrySucceeded(product, cancellationToken);
            return CreatePutAsyncRetrySucceededOperation(originalResponse, () => restClient.CreatePutAsyncRetrySucceededRequest(product));
        }
        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePut201CreatingSucceeded200Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsCustomHeaderClient.Put201CreatingSucceeded200", OperationFinalStateVia.Location, createOriginalHttpMessage,
            (response, cancellationToken) =>
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return value;
            },
            async (response, cancellationToken) =>
            {
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var value = Product.DeserializeProduct(document.RootElement);
                return value;
            });
        }
        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut201CreatingSucceeded200OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await restClient.Put201CreatingSucceeded200Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePut201CreatingSucceeded200Operation(originalResponse, () => restClient.CreatePut201CreatingSucceeded200Request(product));
        }
        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut201CreatingSucceeded200Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = restClient.Put201CreatingSucceeded200(product, cancellationToken);
            return CreatePut201CreatingSucceeded200Operation(originalResponse, () => restClient.CreatePut201CreatingSucceeded200Request(product));
        }
        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreatePost202Retry200Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsCustomHeaderClient.Post202Retry200", OperationFinalStateVia.Location, createOriginalHttpMessage,
            (response, cancellationToken) =>
            {
                return response;
            },
            async (response, cancellationToken) =>
            {
                await Task.CompletedTask;
                return response;
            });
        }
        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPost202Retry200OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await restClient.Post202Retry200Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePost202Retry200Operation(originalResponse, () => restClient.CreatePost202Retry200Request(product));
        }
        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPost202Retry200Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = restClient.Post202Retry200(product, cancellationToken);
            return CreatePost202Retry200Operation(originalResponse, () => restClient.CreatePost202Retry200Request(product));
        }
        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreatePostAsyncRetrySucceededOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsCustomHeaderClient.PostAsyncRetrySucceeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
            (response, cancellationToken) =>
            {
                return response;
            },
            async (response, cancellationToken) =>
            {
                await Task.CompletedTask;
                return response;
            });
        }
        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPostAsyncRetrySucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await restClient.PostAsyncRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePostAsyncRetrySucceededOperation(originalResponse, () => restClient.CreatePostAsyncRetrySucceededRequest(product));
        }
        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPostAsyncRetrySucceededOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = restClient.PostAsyncRetrySucceeded(product, cancellationToken);
            return CreatePostAsyncRetrySucceededOperation(originalResponse, () => restClient.CreatePostAsyncRetrySucceededRequest(product));
        }
    }
}
