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
    internal partial class LRORetrysOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of LRORetrysOperations. </summary>
        public LRORetrysOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreatePut201CreatingSucceeded200Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/retryerror/put/201/creating/succeeded/200", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 500, then a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put201CreatingSucceeded200Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LRORetrysOperations.Put201CreatingSucceeded200");
            scope.Start();
            try
            {
                using var message = CreatePut201CreatingSucceeded200Request(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
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
        public Response<Product> Put201CreatingSucceeded200(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LRORetrysOperations.Put201CreatingSucceeded200");
            scope.Start();
            try
            {
                using var message = CreatePut201CreatingSucceeded200Request(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutAsyncRelativeRetrySucceededRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/retryerror/putasync/retry/succeeded", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 500, then a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRelativeRetrySucceededHeaders>> PutAsyncRelativeRetrySucceededAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LRORetrysOperations.PutAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetrySucceededRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetrySucceededHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
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
        public ResponseWithHeaders<Product, PutAsyncRelativeRetrySucceededHeaders> PutAsyncRelativeRetrySucceeded(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LRORetrysOperations.PutAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetrySucceededRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetrySucceededHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteProvisioning202Accepted200SucceededRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/retryerror/delete/provisioning/202/accepted/200/succeeded", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 500, then a  202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> DeleteProvisioning202Accepted200SucceededAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LRORetrysOperations.DeleteProvisioning202Accepted200Succeeded");
            scope.Start();
            try
            {
                using var message = CreateDeleteProvisioning202Accepted200SucceededRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 500, then a  202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> DeleteProvisioning202Accepted200Succeeded(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LRORetrysOperations.DeleteProvisioning202Accepted200Succeeded");
            scope.Start();
            try
            {
                using var message = CreateDeleteProvisioning202Accepted200SucceededRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDelete202Retry200Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/retryerror/delete/202/retry/200", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Delete202Retry200Headers>> Delete202Retry200Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LRORetrysOperations.Delete202Retry200");
            scope.Start();
            try
            {
                using var message = CreateDelete202Retry200Request();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Delete202Retry200Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Delete202Retry200Headers> Delete202Retry200(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LRORetrysOperations.Delete202Retry200");
            scope.Start();
            try
            {
                using var message = CreateDelete202Retry200Request();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Delete202Retry200Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteAsyncRelativeRetrySucceededRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/retryerror/deleteasync/retry/succeeded", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRelativeRetrySucceededHeaders>> DeleteAsyncRelativeRetrySucceededAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LRORetrysOperations.DeleteAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetrySucceededRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetrySucceededHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteAsyncRelativeRetrySucceededHeaders> DeleteAsyncRelativeRetrySucceeded(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LRORetrysOperations.DeleteAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetrySucceededRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetrySucceededHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePost202Retry200Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/retryerror/post/202/retry/200", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Post202Retry200Headers>> Post202Retry200Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LRORetrysOperations.Post202Retry200");
            scope.Start();
            try
            {
                using var message = CreatePost202Retry200Request(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202Retry200Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Post202Retry200Headers> Post202Retry200(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LRORetrysOperations.Post202Retry200");
            scope.Start();
            try
            {
                using var message = CreatePost202Retry200Request(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202Retry200Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePostAsyncRelativeRetrySucceededRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/retryerror/postasync/retry/succeeded", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<PostAsyncRelativeRetrySucceededHeaders>> PostAsyncRelativeRetrySucceededAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LRORetrysOperations.PostAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetrySucceededRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetrySucceededHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
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
        public ResponseWithHeaders<PostAsyncRelativeRetrySucceededHeaders> PostAsyncRelativeRetrySucceeded(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LRORetrysOperations.PostAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetrySucceededRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetrySucceededHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
