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
    public partial class LrosaDsClient
    {
        internal LrosaDsRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of LrosaDsClient. </summary>
        internal LrosaDsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new LrosaDsRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Long running put request, service returns a 400 to the initial request. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutNonRetry400Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LrosaDsClient.PutNonRetry400", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 400 to the initial request. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutNonRetry400OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutNonRetry400Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePutNonRetry400Operation(originalResponse, () => RestClient.CreatePutNonRetry400Request(product));
        }
        /// <summary> Long running put request, service returns a 400 to the initial request. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutNonRetry400Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutNonRetry400(product, cancellationToken);
            return CreatePutNonRetry400Operation(originalResponse, () => RestClient.CreatePutNonRetry400Request(product));
        }
        /// <summary> Long running put request, service returns a Product with &apos;ProvisioningState&apos; = &apos;Creating&apos; and 201 response code. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutNonRetry201Creating400Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LrosaDsClient.PutNonRetry201Creating400", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a Product with &apos;ProvisioningState&apos; = &apos;Creating&apos; and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutNonRetry201Creating400OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutNonRetry201Creating400Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePutNonRetry201Creating400Operation(originalResponse, () => RestClient.CreatePutNonRetry201Creating400Request(product));
        }
        /// <summary> Long running put request, service returns a Product with &apos;ProvisioningState&apos; = &apos;Creating&apos; and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutNonRetry201Creating400Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutNonRetry201Creating400(product, cancellationToken);
            return CreatePutNonRetry201Creating400Operation(originalResponse, () => RestClient.CreatePutNonRetry201Creating400Request(product));
        }
        /// <summary> Long running put request, service returns a Product with &apos;ProvisioningState&apos; = &apos;Creating&apos; and 201 response code. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutNonRetry201Creating400InvalidJsonOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LrosaDsClient.PutNonRetry201Creating400InvalidJson", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a Product with &apos;ProvisioningState&apos; = &apos;Creating&apos; and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutNonRetry201Creating400InvalidJsonOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutNonRetry201Creating400InvalidJsonAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutNonRetry201Creating400InvalidJsonOperation(originalResponse, () => RestClient.CreatePutNonRetry201Creating400InvalidJsonRequest(product));
        }
        /// <summary> Long running put request, service returns a Product with &apos;ProvisioningState&apos; = &apos;Creating&apos; and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutNonRetry201Creating400InvalidJsonOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutNonRetry201Creating400InvalidJson(product, cancellationToken);
            return CreatePutNonRetry201Creating400InvalidJsonOperation(originalResponse, () => RestClient.CreatePutNonRetry201Creating400InvalidJsonRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 with ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutAsyncRelativeRetry400Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LrosaDsClient.PutAsyncRelativeRetry400", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 200 with ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutAsyncRelativeRetry400OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutAsyncRelativeRetry400Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncRelativeRetry400Operation(originalResponse, () => RestClient.CreatePutAsyncRelativeRetry400Request(product));
        }
        /// <summary> Long running put request, service returns a 200 with ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncRelativeRetry400Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutAsyncRelativeRetry400(product, cancellationToken);
            return CreatePutAsyncRelativeRetry400Operation(originalResponse, () => RestClient.CreatePutAsyncRelativeRetry400Request(product));
        }
        /// <summary> Long running delete request, service returns a 400 with an error body. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDeleteNonRetry400Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LrosaDsClient.DeleteNonRetry400", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 400 with an error body. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteNonRetry400OperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteNonRetry400Async(cancellationToken).ConfigureAwait(false);
            return CreateDeleteNonRetry400Operation(originalResponse, () => RestClient.CreateDeleteNonRetry400Request());
        }
        /// <summary> Long running delete request, service returns a 400 with an error body. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteNonRetry400Operation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteNonRetry400(cancellationToken);
            return CreateDeleteNonRetry400Operation(originalResponse, () => RestClient.CreateDeleteNonRetry400Request());
        }
        /// <summary> Long running delete request, service returns a 202 with a location header. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDelete202NonRetry400Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LrosaDsClient.Delete202NonRetry400", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 202 with a location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDelete202NonRetry400OperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.Delete202NonRetry400Async(cancellationToken).ConfigureAwait(false);
            return CreateDelete202NonRetry400Operation(originalResponse, () => RestClient.CreateDelete202NonRetry400Request());
        }
        /// <summary> Long running delete request, service returns a 202 with a location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDelete202NonRetry400Operation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.Delete202NonRetry400(cancellationToken);
            return CreateDelete202NonRetry400Operation(originalResponse, () => RestClient.CreateDelete202NonRetry400Request());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDeleteAsyncRelativeRetry400Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LrosaDsClient.DeleteAsyncRelativeRetry400", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        public async ValueTask<Operation<Response>> StartDeleteAsyncRelativeRetry400OperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteAsyncRelativeRetry400Async(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncRelativeRetry400Operation(originalResponse, () => RestClient.CreateDeleteAsyncRelativeRetry400Request());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncRelativeRetry400Operation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteAsyncRelativeRetry400(cancellationToken);
            return CreateDeleteAsyncRelativeRetry400Operation(originalResponse, () => RestClient.CreateDeleteAsyncRelativeRetry400Request());
        }
        /// <summary> Long running post request, service returns a 400 with no error body. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreatePostNonRetry400Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LrosaDsClient.PostNonRetry400", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 400 with no error body. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPostNonRetry400OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PostNonRetry400Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePostNonRetry400Operation(originalResponse, () => RestClient.CreatePostNonRetry400Request(product));
        }
        /// <summary> Long running post request, service returns a 400 with no error body. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPostNonRetry400Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PostNonRetry400(product, cancellationToken);
            return CreatePostNonRetry400Operation(originalResponse, () => RestClient.CreatePostNonRetry400Request(product));
        }
        /// <summary> Long running post request, service returns a 202 with a location header. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreatePost202NonRetry400Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LrosaDsClient.Post202NonRetry400", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 202 with a location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPost202NonRetry400OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Post202NonRetry400Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePost202NonRetry400Operation(originalResponse, () => RestClient.CreatePost202NonRetry400Request(product));
        }
        /// <summary> Long running post request, service returns a 202 with a location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPost202NonRetry400Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Post202NonRetry400(product, cancellationToken);
            return CreatePost202NonRetry400Operation(originalResponse, () => RestClient.CreatePost202NonRetry400Request(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreatePostAsyncRelativeRetry400Operation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LrosaDsClient.PostAsyncRelativeRetry400", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 202 to the initial request Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPostAsyncRelativeRetry400OperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PostAsyncRelativeRetry400Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePostAsyncRelativeRetry400Operation(originalResponse, () => RestClient.CreatePostAsyncRelativeRetry400Request(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPostAsyncRelativeRetry400Operation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PostAsyncRelativeRetry400(product, cancellationToken);
            return CreatePostAsyncRelativeRetry400Operation(originalResponse, () => RestClient.CreatePostAsyncRelativeRetry400Request(product));
        }
        /// <summary> Long running put request, service returns a 201 to the initial request with no payload. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutError201NoProvisioningStatePayloadOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LrosaDsClient.PutError201NoProvisioningStatePayload", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 201 to the initial request with no payload. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutError201NoProvisioningStatePayloadOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutError201NoProvisioningStatePayloadAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutError201NoProvisioningStatePayloadOperation(originalResponse, () => RestClient.CreatePutError201NoProvisioningStatePayloadRequest(product));
        }
        /// <summary> Long running put request, service returns a 201 to the initial request with no payload. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutError201NoProvisioningStatePayloadOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutError201NoProvisioningStatePayload(product, cancellationToken);
            return CreatePutError201NoProvisioningStatePayloadOperation(originalResponse, () => RestClient.CreatePutError201NoProvisioningStatePayloadRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutAsyncRelativeRetryNoStatusOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LrosaDsClient.PutAsyncRelativeRetryNoStatus", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        public async ValueTask<Operation<Product>> StartPutAsyncRelativeRetryNoStatusOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutAsyncRelativeRetryNoStatusAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncRelativeRetryNoStatusOperation(originalResponse, () => RestClient.CreatePutAsyncRelativeRetryNoStatusRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncRelativeRetryNoStatusOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutAsyncRelativeRetryNoStatus(product, cancellationToken);
            return CreatePutAsyncRelativeRetryNoStatusOperation(originalResponse, () => RestClient.CreatePutAsyncRelativeRetryNoStatusRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutAsyncRelativeRetryNoStatusPayloadOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LrosaDsClient.PutAsyncRelativeRetryNoStatusPayload", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        public async ValueTask<Operation<Product>> StartPutAsyncRelativeRetryNoStatusPayloadOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutAsyncRelativeRetryNoStatusPayloadAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncRelativeRetryNoStatusPayloadOperation(originalResponse, () => RestClient.CreatePutAsyncRelativeRetryNoStatusPayloadRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncRelativeRetryNoStatusPayloadOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutAsyncRelativeRetryNoStatusPayload(product, cancellationToken);
            return CreatePutAsyncRelativeRetryNoStatusPayloadOperation(originalResponse, () => RestClient.CreatePutAsyncRelativeRetryNoStatusPayloadRequest(product));
        }
        /// <summary> Long running delete request, service returns a 204 to the initial request, indicating success. </summary>
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LrosaDsClient.Delete204Succeeded", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 204 to the initial request, indicating success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDelete204SucceededOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.Delete204SucceededAsync(cancellationToken).ConfigureAwait(false);
            return CreateDelete204SucceededOperation(originalResponse, () => RestClient.CreateDelete204SucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 204 to the initial request, indicating success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDelete204SucceededOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.Delete204Succeeded(cancellationToken);
            return CreateDelete204SucceededOperation(originalResponse, () => RestClient.CreateDelete204SucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDeleteAsyncRelativeRetryNoStatusOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LrosaDsClient.DeleteAsyncRelativeRetryNoStatus", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        public async ValueTask<Operation<Response>> StartDeleteAsyncRelativeRetryNoStatusOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteAsyncRelativeRetryNoStatusAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncRelativeRetryNoStatusOperation(originalResponse, () => RestClient.CreateDeleteAsyncRelativeRetryNoStatusRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncRelativeRetryNoStatusOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteAsyncRelativeRetryNoStatus(cancellationToken);
            return CreateDeleteAsyncRelativeRetryNoStatusOperation(originalResponse, () => RestClient.CreateDeleteAsyncRelativeRetryNoStatusRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, without a location header. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreatePost202NoLocationOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LrosaDsClient.Post202NoLocation", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 202 to the initial request, without a location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPost202NoLocationOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Post202NoLocationAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePost202NoLocationOperation(originalResponse, () => RestClient.CreatePost202NoLocationRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, without a location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPost202NoLocationOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Post202NoLocation(product, cancellationToken);
            return CreatePost202NoLocationOperation(originalResponse, () => RestClient.CreatePost202NoLocationRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreatePostAsyncRelativeRetryNoPayloadOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LrosaDsClient.PostAsyncRelativeRetryNoPayload", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        public async ValueTask<Operation<Response>> StartPostAsyncRelativeRetryNoPayloadOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PostAsyncRelativeRetryNoPayloadAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePostAsyncRelativeRetryNoPayloadOperation(originalResponse, () => RestClient.CreatePostAsyncRelativeRetryNoPayloadRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPostAsyncRelativeRetryNoPayloadOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PostAsyncRelativeRetryNoPayload(product, cancellationToken);
            return CreatePostAsyncRelativeRetryNoPayloadOperation(originalResponse, () => RestClient.CreatePostAsyncRelativeRetryNoPayloadRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that is not a valid json. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePut200InvalidJsonOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LrosaDsClient.Put200InvalidJson", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that is not a valid json. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut200InvalidJsonOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Put200InvalidJsonAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePut200InvalidJsonOperation(originalResponse, () => RestClient.CreatePut200InvalidJsonRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that is not a valid json. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut200InvalidJsonOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Put200InvalidJson(product, cancellationToken);
            return CreatePut200InvalidJsonOperation(originalResponse, () => RestClient.CreatePut200InvalidJsonRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutAsyncRelativeRetryInvalidHeaderOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LrosaDsClient.PutAsyncRelativeRetryInvalidHeader", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutAsyncRelativeRetryInvalidHeaderOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutAsyncRelativeRetryInvalidHeaderAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncRelativeRetryInvalidHeaderOperation(originalResponse, () => RestClient.CreatePutAsyncRelativeRetryInvalidHeaderRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncRelativeRetryInvalidHeaderOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutAsyncRelativeRetryInvalidHeader(product, cancellationToken);
            return CreatePutAsyncRelativeRetryInvalidHeaderOperation(originalResponse, () => RestClient.CreatePutAsyncRelativeRetryInvalidHeaderRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Product> CreatePutAsyncRelativeRetryInvalidJsonPollingOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LrosaDsClient.PutAsyncRelativeRetryInvalidJsonPolling", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        public async ValueTask<Operation<Product>> StartPutAsyncRelativeRetryInvalidJsonPollingOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PutAsyncRelativeRetryInvalidJsonPollingAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncRelativeRetryInvalidJsonPollingOperation(originalResponse, () => RestClient.CreatePutAsyncRelativeRetryInvalidJsonPollingRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncRelativeRetryInvalidJsonPollingOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PutAsyncRelativeRetryInvalidJsonPolling(product, cancellationToken);
            return CreatePutAsyncRelativeRetryInvalidJsonPollingOperation(originalResponse, () => RestClient.CreatePutAsyncRelativeRetryInvalidJsonPollingRequest(product));
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request receing a reponse with an invalid &apos;Location&apos; and &apos;Retry-After&apos; headers. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDelete202RetryInvalidHeaderOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LrosaDsClient.Delete202RetryInvalidHeader", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 202 to the initial request receing a reponse with an invalid &apos;Location&apos; and &apos;Retry-After&apos; headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDelete202RetryInvalidHeaderOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.Delete202RetryInvalidHeaderAsync(cancellationToken).ConfigureAwait(false);
            return CreateDelete202RetryInvalidHeaderOperation(originalResponse, () => RestClient.CreateDelete202RetryInvalidHeaderRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request receing a reponse with an invalid &apos;Location&apos; and &apos;Retry-After&apos; headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDelete202RetryInvalidHeaderOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.Delete202RetryInvalidHeader(cancellationToken);
            return CreateDelete202RetryInvalidHeaderOperation(originalResponse, () => RestClient.CreateDelete202RetryInvalidHeaderRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDeleteAsyncRelativeRetryInvalidHeaderOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LrosaDsClient.DeleteAsyncRelativeRetryInvalidHeader", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteAsyncRelativeRetryInvalidHeaderOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteAsyncRelativeRetryInvalidHeaderAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncRelativeRetryInvalidHeaderOperation(originalResponse, () => RestClient.CreateDeleteAsyncRelativeRetryInvalidHeaderRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncRelativeRetryInvalidHeaderOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteAsyncRelativeRetryInvalidHeader(cancellationToken);
            return CreateDeleteAsyncRelativeRetryInvalidHeaderOperation(originalResponse, () => RestClient.CreateDeleteAsyncRelativeRetryInvalidHeaderRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreateDeleteAsyncRelativeRetryInvalidJsonPollingOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LrosaDsClient.DeleteAsyncRelativeRetryInvalidJsonPolling", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        public async ValueTask<Operation<Response>> StartDeleteAsyncRelativeRetryInvalidJsonPollingOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await RestClient.DeleteAsyncRelativeRetryInvalidJsonPollingAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncRelativeRetryInvalidJsonPollingOperation(originalResponse, () => RestClient.CreateDeleteAsyncRelativeRetryInvalidJsonPollingRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncRelativeRetryInvalidJsonPollingOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = RestClient.DeleteAsyncRelativeRetryInvalidJsonPolling(cancellationToken);
            return CreateDeleteAsyncRelativeRetryInvalidJsonPollingOperation(originalResponse, () => RestClient.CreateDeleteAsyncRelativeRetryInvalidJsonPollingRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with invalid &apos;Location&apos; and &apos;Retry-After&apos; headers. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreatePost202RetryInvalidHeaderOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LrosaDsClient.Post202RetryInvalidHeader", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with invalid &apos;Location&apos; and &apos;Retry-After&apos; headers. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPost202RetryInvalidHeaderOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.Post202RetryInvalidHeaderAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePost202RetryInvalidHeaderOperation(originalResponse, () => RestClient.CreatePost202RetryInvalidHeaderRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with invalid &apos;Location&apos; and &apos;Retry-After&apos; headers. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPost202RetryInvalidHeaderOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.Post202RetryInvalidHeader(product, cancellationToken);
            return CreatePost202RetryInvalidHeaderOperation(originalResponse, () => RestClient.CreatePost202RetryInvalidHeaderRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreatePostAsyncRelativeRetryInvalidHeaderOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LrosaDsClient.PostAsyncRelativeRetryInvalidHeader", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPostAsyncRelativeRetryInvalidHeaderOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PostAsyncRelativeRetryInvalidHeaderAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePostAsyncRelativeRetryInvalidHeaderOperation(originalResponse, () => RestClient.CreatePostAsyncRelativeRetryInvalidHeaderRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPostAsyncRelativeRetryInvalidHeaderOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PostAsyncRelativeRetryInvalidHeader(product, cancellationToken);
            return CreatePostAsyncRelativeRetryInvalidHeaderOperation(originalResponse, () => RestClient.CreatePostAsyncRelativeRetryInvalidHeaderRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        public Operation<Response> CreatePostAsyncRelativeRetryInvalidJsonPollingOperation(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LrosaDsClient.PostAsyncRelativeRetryInvalidJsonPolling", OperationFinalStateVia.Location, createOriginalHttpMessage,
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
        public async ValueTask<Operation<Response>> StartPostAsyncRelativeRetryInvalidJsonPollingOperationAsync(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = await RestClient.PostAsyncRelativeRetryInvalidJsonPollingAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePostAsyncRelativeRetryInvalidJsonPollingOperation(originalResponse, () => RestClient.CreatePostAsyncRelativeRetryInvalidJsonPollingRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPostAsyncRelativeRetryInvalidJsonPollingOperation(Product product, CancellationToken cancellationToken = default)
        {

            var originalResponse = RestClient.PostAsyncRelativeRetryInvalidJsonPolling(product, cancellationToken);
            return CreatePostAsyncRelativeRetryInvalidJsonPollingOperation(originalResponse, () => RestClient.CreatePostAsyncRelativeRetryInvalidJsonPollingRequest(product));
        }
    }
}
