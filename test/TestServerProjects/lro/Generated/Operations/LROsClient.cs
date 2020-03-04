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
    public partial class LROsClient
    {
        internal LROsRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of LROsClient. </summary>
        internal LROsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new LROsRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePut200SucceededOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.Put200Succeeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut200SucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Put200SucceededAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePut200SucceededOperation(originalResponse, () => RestClient.CreatePut200SucceededRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut200SucceededOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Put200Succeeded(product, cancellationToken);
            return CreatePut200SucceededOperation(originalResponse, () => RestClient.CreatePut200SucceededRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that does not contain ProvisioningState=’Succeeded’. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePut200SucceededNoStateOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.Put200SucceededNoState", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that does not contain ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut200SucceededNoStateOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Put200SucceededNoStateAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePut200SucceededNoStateOperation(originalResponse, () => RestClient.CreatePut200SucceededNoStateRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that does not contain ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut200SucceededNoStateOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Put200SucceededNoState(product, cancellationToken);
            return CreatePut200SucceededNoStateOperation(originalResponse, () => RestClient.CreatePut200SucceededNoStateRequest(product));
        }
        /// <summary> Long running put request, service returns a 202 to the initial request, with a location header that points to a polling URL that returns a 200 and an entity that doesn&apos;t contains ProvisioningState. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePut202Retry200Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.Put202Retry200", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 202 to the initial request, with a location header that points to a polling URL that returns a 200 and an entity that doesn&apos;t contains ProvisioningState. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut202Retry200OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Put202Retry200Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePut202Retry200Operation(originalResponse, () => RestClient.CreatePut202Retry200Request(product));
        }
        /// <summary> Long running put request, service returns a 202 to the initial request, with a location header that points to a polling URL that returns a 200 and an entity that doesn&apos;t contains ProvisioningState. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut202Retry200Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Put202Retry200(product, cancellationToken);
            return CreatePut202Retry200Operation(originalResponse, () => RestClient.CreatePut202Retry200Request(product));
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.Put201CreatingSucceeded200", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut201CreatingSucceeded200OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Put201CreatingSucceeded200Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePut201CreatingSucceeded200Operation(originalResponse, () => RestClient.CreatePut201CreatingSucceeded200Request(product));
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut201CreatingSucceeded200Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Put201CreatingSucceeded200(product, cancellationToken);
            return CreatePut201CreatingSucceeded200Operation(originalResponse, () => RestClient.CreatePut201CreatingSucceeded200Request(product));
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Updating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePut200UpdatingSucceeded204Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.Put200UpdatingSucceeded204", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Updating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut200UpdatingSucceeded204OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Put200UpdatingSucceeded204Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePut200UpdatingSucceeded204Operation(originalResponse, () => RestClient.CreatePut200UpdatingSucceeded204Request(product));
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Updating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut200UpdatingSucceeded204Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Put200UpdatingSucceeded204(product, cancellationToken);
            return CreatePut200UpdatingSucceeded204Operation(originalResponse, () => RestClient.CreatePut200UpdatingSucceeded204Request(product));
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Created’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePut201CreatingFailed200Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.Put201CreatingFailed200", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Created’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut201CreatingFailed200OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Put201CreatingFailed200Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePut201CreatingFailed200Operation(originalResponse, () => RestClient.CreatePut201CreatingFailed200Request(product));
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Created’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut201CreatingFailed200Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Put201CreatingFailed200(product, cancellationToken);
            return CreatePut201CreatingFailed200Operation(originalResponse, () => RestClient.CreatePut201CreatingFailed200Request(product));
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePut200Acceptedcanceled200Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.Put200Acceptedcanceled200", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut200Acceptedcanceled200OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Put200Acceptedcanceled200Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePut200Acceptedcanceled200Operation(originalResponse, () => RestClient.CreatePut200Acceptedcanceled200Request(product));
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut200Acceptedcanceled200Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Put200Acceptedcanceled200(product, cancellationToken);
            return CreatePut200Acceptedcanceled200Operation(originalResponse, () => RestClient.CreatePut200Acceptedcanceled200Request(product));
        }
        /// <summary> Long running put request, service returns a 202 to the initial request with location header. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutNoHeaderInRetryOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.PutNoHeaderInRetry", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 202 to the initial request with location header. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutNoHeaderInRetryOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutNoHeaderInRetryAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutNoHeaderInRetryOperation(originalResponse, () => RestClient.CreatePutNoHeaderInRetryRequest(product));
        }
        /// <summary> Long running put request, service returns a 202 to the initial request with location header. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutNoHeaderInRetryOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutNoHeaderInRetry(product, cancellationToken);
            return CreatePutNoHeaderInRetryOperation(originalResponse, () => RestClient.CreatePutNoHeaderInRetryRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.PutAsyncRetrySucceeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutAsyncRetrySucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutAsyncRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncRetrySucceededOperation(originalResponse, () => RestClient.CreatePutAsyncRetrySucceededRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncRetrySucceededOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutAsyncRetrySucceeded(product, cancellationToken);
            return CreatePutAsyncRetrySucceededOperation(originalResponse, () => RestClient.CreatePutAsyncRetrySucceededRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutAsyncNoRetrySucceededOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.PutAsyncNoRetrySucceeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutAsyncNoRetrySucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutAsyncNoRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncNoRetrySucceededOperation(originalResponse, () => RestClient.CreatePutAsyncNoRetrySucceededRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncNoRetrySucceededOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutAsyncNoRetrySucceeded(product, cancellationToken);
            return CreatePutAsyncNoRetrySucceededOperation(originalResponse, () => RestClient.CreatePutAsyncNoRetrySucceededRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutAsyncRetryFailedOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.PutAsyncRetryFailed", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutAsyncRetryFailedOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutAsyncRetryFailedAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncRetryFailedOperation(originalResponse, () => RestClient.CreatePutAsyncRetryFailedRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncRetryFailedOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutAsyncRetryFailed(product, cancellationToken);
            return CreatePutAsyncRetryFailedOperation(originalResponse, () => RestClient.CreatePutAsyncRetryFailedRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutAsyncNoRetrycanceledOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.PutAsyncNoRetrycanceled", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutAsyncNoRetrycanceledOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutAsyncNoRetrycanceledAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncNoRetrycanceledOperation(originalResponse, () => RestClient.CreatePutAsyncNoRetrycanceledRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncNoRetrycanceledOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutAsyncNoRetrycanceled(product, cancellationToken);
            return CreatePutAsyncNoRetrycanceledOperation(originalResponse, () => RestClient.CreatePutAsyncNoRetrycanceledRequest(product));
        }
        /// <summary> Long running put request, service returns a 202 to the initial request with Azure-AsyncOperation header. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutAsyncNoHeaderInRetryOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.PutAsyncNoHeaderInRetry", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 202 to the initial request with Azure-AsyncOperation header. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutAsyncNoHeaderInRetryOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutAsyncNoHeaderInRetryAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncNoHeaderInRetryOperation(originalResponse, () => RestClient.CreatePutAsyncNoHeaderInRetryRequest(product));
        }
        /// <summary> Long running put request, service returns a 202 to the initial request with Azure-AsyncOperation header. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncNoHeaderInRetryOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutAsyncNoHeaderInRetry(product, cancellationToken);
            return CreatePutAsyncNoHeaderInRetryOperation(originalResponse, () => RestClient.CreatePutAsyncNoHeaderInRetryRequest(product));
        }
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Sku> CreatePutNonResourceOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.PutNonResource", OperationFinalStateVia.Location, createOriginalHttpMessage,
            (response, cancellationToken) =>
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var value = Sku.DeserializeSku(document.RootElement);
                return value;
            },
            async (response, cancellationToken) =>
            {
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var value = Sku.DeserializeSku(document.RootElement);
                return value;
            });
        }
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Sku>> StartPutNonResourceOperationAsync(Sku sku, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutNonResourceAsync(sku, cancellationToken).ConfigureAwait(false);
            return CreatePutNonResourceOperation(originalResponse, () => RestClient.CreatePutNonResourceRequest(sku));
        }
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Sku> StartPutNonResourceOperation(Sku sku, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutNonResource(sku, cancellationToken);
            return CreatePutNonResourceOperation(originalResponse, () => RestClient.CreatePutNonResourceRequest(sku));
        }
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Sku> CreatePutAsyncNonResourceOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.PutAsyncNonResource", OperationFinalStateVia.Location, createOriginalHttpMessage,
            (response, cancellationToken) =>
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var value = Sku.DeserializeSku(document.RootElement);
                return value;
            },
            async (response, cancellationToken) =>
            {
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var value = Sku.DeserializeSku(document.RootElement);
                return value;
            });
        }
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Sku>> StartPutAsyncNonResourceOperationAsync(Sku sku, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutAsyncNonResourceAsync(sku, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncNonResourceOperation(originalResponse, () => RestClient.CreatePutAsyncNonResourceRequest(sku));
        }
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Sku> StartPutAsyncNonResourceOperation(Sku sku, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutAsyncNonResource(sku, cancellationToken);
            return CreatePutAsyncNonResourceOperation(originalResponse, () => RestClient.CreatePutAsyncNonResourceRequest(sku));
        }
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<SubProduct> CreatePutSubResourceOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.PutSubResource", OperationFinalStateVia.Location, createOriginalHttpMessage,
            (response, cancellationToken) =>
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var value = SubProduct.DeserializeSubProduct(document.RootElement);
                return value;
            },
            async (response, cancellationToken) =>
            {
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var value = SubProduct.DeserializeSubProduct(document.RootElement);
                return value;
            });
        }
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<SubProduct>> StartPutSubResourceOperationAsync(SubProduct product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutSubResourceAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutSubResourceOperation(originalResponse, () => RestClient.CreatePutSubResourceRequest(product));
        }
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<SubProduct> StartPutSubResourceOperation(SubProduct product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutSubResource(product, cancellationToken);
            return CreatePutSubResourceOperation(originalResponse, () => RestClient.CreatePutSubResourceRequest(product));
        }
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<SubProduct> CreatePutAsyncSubResourceOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsClient.PutAsyncSubResource", OperationFinalStateVia.Location, createOriginalHttpMessage,
            (response, cancellationToken) =>
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var value = SubProduct.DeserializeSubProduct(document.RootElement);
                return value;
            },
            async (response, cancellationToken) =>
            {
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var value = SubProduct.DeserializeSubProduct(document.RootElement);
                return value;
            });
        }
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<SubProduct>> StartPutAsyncSubResourceOperationAsync(SubProduct product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutAsyncSubResourceAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncSubResourceOperation(originalResponse, () => RestClient.CreatePutAsyncSubResourceRequest(product));
        }
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<SubProduct> StartPutAsyncSubResourceOperation(SubProduct product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutAsyncSubResource(product, cancellationToken);
            return CreatePutAsyncSubResourceOperation(originalResponse, () => RestClient.CreatePutAsyncSubResourceRequest(product));
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreateDeleteProvisioning202Accepted200SucceededOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsClient.DeleteProvisioning202Accepted200Succeeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartDeleteProvisioning202Accepted200SucceededOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteProvisioning202Accepted200SucceededAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteProvisioning202Accepted200SucceededOperation(originalResponse, () => RestClient.CreateDeleteProvisioning202Accepted200SucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartDeleteProvisioning202Accepted200SucceededOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteProvisioning202Accepted200Succeeded(cancellationToken);
            return CreateDeleteProvisioning202Accepted200SucceededOperation(originalResponse, () => RestClient.CreateDeleteProvisioning202Accepted200SucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreateDeleteProvisioning202DeletingFailed200Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsClient.DeleteProvisioning202DeletingFailed200", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartDeleteProvisioning202DeletingFailed200OperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteProvisioning202DeletingFailed200Async(cancellationToken).ConfigureAwait(false);
            return CreateDeleteProvisioning202DeletingFailed200Operation(originalResponse, () => RestClient.CreateDeleteProvisioning202DeletingFailed200Request());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartDeleteProvisioning202DeletingFailed200Operation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteProvisioning202DeletingFailed200(cancellationToken);
            return CreateDeleteProvisioning202DeletingFailed200Operation(originalResponse, () => RestClient.CreateDeleteProvisioning202DeletingFailed200Request());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreateDeleteProvisioning202Deletingcanceled200Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsClient.DeleteProvisioning202Deletingcanceled200", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartDeleteProvisioning202Deletingcanceled200OperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteProvisioning202Deletingcanceled200Async(cancellationToken).ConfigureAwait(false);
            return CreateDeleteProvisioning202Deletingcanceled200Operation(originalResponse, () => RestClient.CreateDeleteProvisioning202Deletingcanceled200Request());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartDeleteProvisioning202Deletingcanceled200Operation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteProvisioning202Deletingcanceled200(cancellationToken);
            return CreateDeleteProvisioning202Deletingcanceled200Operation(originalResponse, () => RestClient.CreateDeleteProvisioning202Deletingcanceled200Request());
        }
        /// <summary> Long running delete succeeds and returns right away. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDelete204SucceededOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsClient.Delete204Succeeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete succeeds and returns right away. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDelete204SucceededOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.Delete204SucceededAsync(cancellationToken).ConfigureAwait(false);
            return CreateDelete204SucceededOperation(originalResponse, () => RestClient.CreateDelete204SucceededRequest());
        }
        /// <summary> Long running delete succeeds and returns right away. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDelete204SucceededOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.Delete204Succeeded(cancellationToken);
            return CreateDelete204SucceededOperation(originalResponse, () => RestClient.CreateDelete204SucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreateDelete202Retry200Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsClient.Delete202Retry200", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartDelete202Retry200OperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.Delete202Retry200Async(cancellationToken).ConfigureAwait(false);
            return CreateDelete202Retry200Operation(originalResponse, () => RestClient.CreateDelete202Retry200Request());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartDelete202Retry200Operation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.Delete202Retry200(cancellationToken);
            return CreateDelete202Retry200Operation(originalResponse, () => RestClient.CreateDelete202Retry200Request());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreateDelete202NoRetry204Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsClient.Delete202NoRetry204", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartDelete202NoRetry204OperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.Delete202NoRetry204Async(cancellationToken).ConfigureAwait(false);
            return CreateDelete202NoRetry204Operation(originalResponse, () => RestClient.CreateDelete202NoRetry204Request());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartDelete202NoRetry204Operation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.Delete202NoRetry204(cancellationToken);
            return CreateDelete202NoRetry204Operation(originalResponse, () => RestClient.CreateDelete202NoRetry204Request());
        }
        /// <summary> Long running delete request, service returns a location header in the initial request. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDeleteNoHeaderInRetryOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsClient.DeleteNoHeaderInRetry", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a location header in the initial request. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteNoHeaderInRetryOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteNoHeaderInRetryAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteNoHeaderInRetryOperation(originalResponse, () => RestClient.CreateDeleteNoHeaderInRetryRequest());
        }
        /// <summary> Long running delete request, service returns a location header in the initial request. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteNoHeaderInRetryOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteNoHeaderInRetry(cancellationToken);
            return CreateDeleteNoHeaderInRetryOperation(originalResponse, () => RestClient.CreateDeleteNoHeaderInRetryRequest());
        }
        /// <summary> Long running delete request, service returns an Azure-AsyncOperation header in the initial request. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDeleteAsyncNoHeaderInRetryOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsClient.DeleteAsyncNoHeaderInRetry", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns an Azure-AsyncOperation header in the initial request. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteAsyncNoHeaderInRetryOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteAsyncNoHeaderInRetryAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncNoHeaderInRetryOperation(originalResponse, () => RestClient.CreateDeleteAsyncNoHeaderInRetryRequest());
        }
        /// <summary> Long running delete request, service returns an Azure-AsyncOperation header in the initial request. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncNoHeaderInRetryOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteAsyncNoHeaderInRetry(cancellationToken);
            return CreateDeleteAsyncNoHeaderInRetryOperation(originalResponse, () => RestClient.CreateDeleteAsyncNoHeaderInRetryRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDeleteAsyncRetrySucceededOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsClient.DeleteAsyncRetrySucceeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteAsyncRetrySucceededOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteAsyncRetrySucceededAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncRetrySucceededOperation(originalResponse, () => RestClient.CreateDeleteAsyncRetrySucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncRetrySucceededOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteAsyncRetrySucceeded(cancellationToken);
            return CreateDeleteAsyncRetrySucceededOperation(originalResponse, () => RestClient.CreateDeleteAsyncRetrySucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDeleteAsyncNoRetrySucceededOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsClient.DeleteAsyncNoRetrySucceeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteAsyncNoRetrySucceededOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteAsyncNoRetrySucceededAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncNoRetrySucceededOperation(originalResponse, () => RestClient.CreateDeleteAsyncNoRetrySucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncNoRetrySucceededOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteAsyncNoRetrySucceeded(cancellationToken);
            return CreateDeleteAsyncNoRetrySucceededOperation(originalResponse, () => RestClient.CreateDeleteAsyncNoRetrySucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDeleteAsyncRetryFailedOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsClient.DeleteAsyncRetryFailed", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteAsyncRetryFailedOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteAsyncRetryFailedAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncRetryFailedOperation(originalResponse, () => RestClient.CreateDeleteAsyncRetryFailedRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncRetryFailedOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteAsyncRetryFailed(cancellationToken);
            return CreateDeleteAsyncRetryFailedOperation(originalResponse, () => RestClient.CreateDeleteAsyncRetryFailedRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDeleteAsyncRetrycanceledOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsClient.DeleteAsyncRetrycanceled", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteAsyncRetrycanceledOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteAsyncRetrycanceledAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncRetrycanceledOperation(originalResponse, () => RestClient.CreateDeleteAsyncRetrycanceledRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncRetrycanceledOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteAsyncRetrycanceled(cancellationToken);
            return CreateDeleteAsyncRetrycanceledOperation(originalResponse, () => RestClient.CreateDeleteAsyncRetrycanceledRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header. Poll returns a 200 with a response body after success. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Sku> CreatePost200WithPayloadOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsClient.Post200WithPayload", OperationFinalStateVia.Location, createOriginalHttpMessage,
            (response, cancellationToken) =>
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var value = Sku.DeserializeSku(document.RootElement);
                return value;
            },
            async (response, cancellationToken) =>
            {
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var value = Sku.DeserializeSku(document.RootElement);
                return value;
            });
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header. Poll returns a 200 with a response body after success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Sku>> StartPost200WithPayloadOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.Post200WithPayloadAsync(cancellationToken).ConfigureAwait(false);
            return CreatePost200WithPayloadOperation(originalResponse, () => RestClient.CreatePost200WithPayloadRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header. Poll returns a 200 with a response body after success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Sku> StartPost200WithPayloadOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.Post200WithPayload(cancellationToken);
            return CreatePost200WithPayloadOperation(originalResponse, () => RestClient.CreatePost200WithPayloadRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsClient.Post202Retry200", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPost202Retry200OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Post202Retry200Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePost202Retry200Operation(originalResponse, () => RestClient.CreatePost202Retry200Request(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPost202Retry200Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Post202Retry200(product, cancellationToken);
            return CreatePost202Retry200Operation(originalResponse, () => RestClient.CreatePost202Retry200Request(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header, 204 with noresponse body after success. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePost202NoRetry204Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsClient.Post202NoRetry204", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header, 204 with noresponse body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPost202NoRetry204OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Post202NoRetry204Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePost202NoRetry204Operation(originalResponse, () => RestClient.CreatePost202NoRetry204Request(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header, 204 with noresponse body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPost202NoRetry204Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Post202NoRetry204(product, cancellationToken);
            return CreatePost202NoRetry204Operation(originalResponse, () => RestClient.CreatePost202NoRetry204Request(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should poll Location to get the final object. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePostDoubleHeadersFinalLocationGetOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsClient.PostDoubleHeadersFinalLocationGet", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPostDoubleHeadersFinalLocationGetOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.PostDoubleHeadersFinalLocationGetAsync(cancellationToken).ConfigureAwait(false);
            return CreatePostDoubleHeadersFinalLocationGetOperation(originalResponse, () => RestClient.CreatePostDoubleHeadersFinalLocationGetRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPostDoubleHeadersFinalLocationGetOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.PostDoubleHeadersFinalLocationGet(cancellationToken);
            return CreatePostDoubleHeadersFinalLocationGetOperation(originalResponse, () => RestClient.CreatePostDoubleHeadersFinalLocationGetRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePostDoubleHeadersFinalAzureHeaderGetOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsClient.PostDoubleHeadersFinalAzureHeaderGet", OperationFinalStateVia.AzureAsyncOperation, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPostDoubleHeadersFinalAzureHeaderGetOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.PostDoubleHeadersFinalAzureHeaderGetAsync(cancellationToken).ConfigureAwait(false);
            return CreatePostDoubleHeadersFinalAzureHeaderGetOperation(originalResponse, () => RestClient.CreatePostDoubleHeadersFinalAzureHeaderGetRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPostDoubleHeadersFinalAzureHeaderGetOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.PostDoubleHeadersFinalAzureHeaderGet(cancellationToken);
            return CreatePostDoubleHeadersFinalAzureHeaderGetOperation(originalResponse, () => RestClient.CreatePostDoubleHeadersFinalAzureHeaderGetRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object if you support initial Autorest behavior. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePostDoubleHeadersFinalAzureHeaderGetDefaultOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsClient.PostDoubleHeadersFinalAzureHeaderGetDefault", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object if you support initial Autorest behavior. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPostDoubleHeadersFinalAzureHeaderGetDefaultOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.PostDoubleHeadersFinalAzureHeaderGetDefaultAsync(cancellationToken).ConfigureAwait(false);
            return CreatePostDoubleHeadersFinalAzureHeaderGetDefaultOperation(originalResponse, () => RestClient.CreatePostDoubleHeadersFinalAzureHeaderGetDefaultRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object if you support initial Autorest behavior. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPostDoubleHeadersFinalAzureHeaderGetDefaultOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.PostDoubleHeadersFinalAzureHeaderGetDefault(cancellationToken);
            return CreatePostDoubleHeadersFinalAzureHeaderGetDefaultOperation(originalResponse, () => RestClient.CreatePostDoubleHeadersFinalAzureHeaderGetDefaultRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePostAsyncRetrySucceededOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsClient.PostAsyncRetrySucceeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPostAsyncRetrySucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PostAsyncRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePostAsyncRetrySucceededOperation(originalResponse, () => RestClient.CreatePostAsyncRetrySucceededRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPostAsyncRetrySucceededOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PostAsyncRetrySucceeded(product, cancellationToken);
            return CreatePostAsyncRetrySucceededOperation(originalResponse, () => RestClient.CreatePostAsyncRetrySucceededRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePostAsyncNoRetrySucceededOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsClient.PostAsyncNoRetrySucceeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPostAsyncNoRetrySucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PostAsyncNoRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePostAsyncNoRetrySucceededOperation(originalResponse, () => RestClient.CreatePostAsyncNoRetrySucceededRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPostAsyncNoRetrySucceededOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PostAsyncNoRetrySucceeded(product, cancellationToken);
            return CreatePostAsyncNoRetrySucceededOperation(originalResponse, () => RestClient.CreatePostAsyncNoRetrySucceededRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreatePostAsyncRetryFailedOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsClient.PostAsyncRetryFailed", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPostAsyncRetryFailedOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PostAsyncRetryFailedAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePostAsyncRetryFailedOperation(originalResponse, () => RestClient.CreatePostAsyncRetryFailedRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPostAsyncRetryFailedOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PostAsyncRetryFailed(product, cancellationToken);
            return CreatePostAsyncRetryFailedOperation(originalResponse, () => RestClient.CreatePostAsyncRetryFailedRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreatePostAsyncRetrycanceledOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsClient.PostAsyncRetrycanceled", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPostAsyncRetrycanceledOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PostAsyncRetrycanceledAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePostAsyncRetrycanceledOperation(originalResponse, () => RestClient.CreatePostAsyncRetrycanceledRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPostAsyncRetrycanceledOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PostAsyncRetrycanceled(product, cancellationToken);
            return CreatePostAsyncRetrycanceledOperation(originalResponse, () => RestClient.CreatePostAsyncRetrycanceledRequest(product));
        }
    }
}
