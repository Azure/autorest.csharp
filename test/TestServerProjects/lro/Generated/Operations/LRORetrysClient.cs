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
    public partial class LRORetrysClient
    {
        internal LRORetrysRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of LRORetrysClient. </summary>
        internal LRORetrysClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new LRORetrysRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Long running put request, service returns a 500, then a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LRORetrysClient.Put201CreatingSucceeded200", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 500, then a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut201CreatingSucceeded200OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Put201CreatingSucceeded200Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePut201CreatingSucceeded200Operation(originalResponse, () => RestClient.CreatePut201CreatingSucceeded200Request(product));
        }
        /// <summary> Long running put request, service returns a 500, then a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut201CreatingSucceeded200Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Put201CreatingSucceeded200(product, cancellationToken);
            return CreatePut201CreatingSucceeded200Operation(originalResponse, () => RestClient.CreatePut201CreatingSucceeded200Request(product));
        }
        /// <summary> Long running put request, service returns a 500, then a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutAsyncRelativeRetrySucceededOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LRORetrysClient.PutAsyncRelativeRetrySucceeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 500, then a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutAsyncRelativeRetrySucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutAsyncRelativeRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncRelativeRetrySucceededOperation(originalResponse, () => RestClient.CreatePutAsyncRelativeRetrySucceededRequest(product));
        }
        /// <summary> Long running put request, service returns a 500, then a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncRelativeRetrySucceededOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutAsyncRelativeRetrySucceeded(product, cancellationToken);
            return CreatePutAsyncRelativeRetrySucceededOperation(originalResponse, () => RestClient.CreatePutAsyncRelativeRetrySucceededRequest(product));
        }
        /// <summary> Long running delete request, service returns a 500, then a  202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LRORetrysClient.DeleteProvisioning202Accepted200Succeeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 500, then a  202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartDeleteProvisioning202Accepted200SucceededOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteProvisioning202Accepted200SucceededAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteProvisioning202Accepted200SucceededOperation(originalResponse, () => RestClient.CreateDeleteProvisioning202Accepted200SucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 500, then a  202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartDeleteProvisioning202Accepted200SucceededOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteProvisioning202Accepted200Succeeded(cancellationToken);
            return CreateDeleteProvisioning202Accepted200SucceededOperation(originalResponse, () => RestClient.CreateDeleteProvisioning202Accepted200SucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDelete202Retry200Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LRORetrysClient.Delete202Retry200", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDelete202Retry200OperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.Delete202Retry200Async(cancellationToken).ConfigureAwait(false);
            return CreateDelete202Retry200Operation(originalResponse, () => RestClient.CreateDelete202Retry200Request());
        }
        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDelete202Retry200Operation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.Delete202Retry200(cancellationToken);
            return CreateDelete202Retry200Operation(originalResponse, () => RestClient.CreateDelete202Retry200Request());
        }
        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDeleteAsyncRelativeRetrySucceededOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LRORetrysClient.DeleteAsyncRelativeRetrySucceeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteAsyncRelativeRetrySucceededOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteAsyncRelativeRetrySucceededAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncRelativeRetrySucceededOperation(originalResponse, () => RestClient.CreateDeleteAsyncRelativeRetrySucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncRelativeRetrySucceededOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteAsyncRelativeRetrySucceeded(cancellationToken);
            return CreateDeleteAsyncRelativeRetrySucceededOperation(originalResponse, () => RestClient.CreateDeleteAsyncRelativeRetrySucceededRequest());
        }
        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LRORetrysClient.Post202Retry200", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPost202Retry200OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Post202Retry200Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePost202Retry200Operation(originalResponse, () => RestClient.CreatePost202Retry200Request(product));
        }
        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPost202Retry200Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Post202Retry200(product, cancellationToken);
            return CreatePost202Retry200Operation(originalResponse, () => RestClient.CreatePost202Retry200Request(product));
        }
        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreatePostAsyncRelativeRetrySucceededOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LRORetrysClient.PostAsyncRelativeRetrySucceeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPostAsyncRelativeRetrySucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PostAsyncRelativeRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePostAsyncRelativeRetrySucceededOperation(originalResponse, () => RestClient.CreatePostAsyncRelativeRetrySucceededRequest(product));
        }
        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPostAsyncRelativeRetrySucceededOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PostAsyncRelativeRetrySucceeded(product, cancellationToken);
            return CreatePostAsyncRelativeRetrySucceededOperation(originalResponse, () => RestClient.CreatePostAsyncRelativeRetrySucceededRequest(product));
        }
    }
}
