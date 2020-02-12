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
    internal partial class LROSADsOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of LROSADsOperations. </summary>
        public LROSADsOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreatePutNonRetry400Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/nonretryerror/put/400", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 400 to the initial request. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PutNonRetry400Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutNonRetry400");
            scope.Start();
            try
            {
                using var message = CreatePutNonRetry400Request(product);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public Response<Product> PutNonRetry400(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutNonRetry400");
            scope.Start();
            try
            {
                using var message = CreatePutNonRetry400Request(product);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutNonRetry201Creating400Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/nonretryerror/put/201/creating/400", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a Product with &apos;ProvisioningState&apos; = &apos;Creating&apos; and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PutNonRetry201Creating400Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutNonRetry201Creating400");
            scope.Start();
            try
            {
                using var message = CreatePutNonRetry201Creating400Request(product);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running put request, service returns a Product with &apos;ProvisioningState&apos; = &apos;Creating&apos; and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PutNonRetry201Creating400(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutNonRetry201Creating400");
            scope.Start();
            try
            {
                using var message = CreatePutNonRetry201Creating400Request(product);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutNonRetry201Creating400InvalidJsonRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/nonretryerror/put/201/creating/400/invalidjson", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a Product with &apos;ProvisioningState&apos; = &apos;Creating&apos; and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PutNonRetry201Creating400InvalidJsonAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutNonRetry201Creating400InvalidJson");
            scope.Start();
            try
            {
                using var message = CreatePutNonRetry201Creating400InvalidJsonRequest(product);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running put request, service returns a Product with &apos;ProvisioningState&apos; = &apos;Creating&apos; and 201 response code. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PutNonRetry201Creating400InvalidJson(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutNonRetry201Creating400InvalidJson");
            scope.Start();
            try
            {
                using var message = CreatePutNonRetry201Creating400InvalidJsonRequest(product);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutAsyncRelativeRetry400Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/nonretryerror/putasync/retry/400", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 200 with ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRelativeRetry400Headers>> PutAsyncRelativeRetry400Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetry400");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetry400Request(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetry400Headers(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public ResponseWithHeaders<Product, PutAsyncRelativeRetry400Headers> PutAsyncRelativeRetry400(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetry400");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetry400Request(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetry400Headers(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteNonRetry400Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/nonretryerror/delete/400", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 400 with an error body. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteNonRetry400Headers>> DeleteNonRetry400Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteNonRetry400");
            scope.Start();
            try
            {
                using var message = CreateDeleteNonRetry400Request();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteNonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 400 with an error body. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteNonRetry400Headers> DeleteNonRetry400(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteNonRetry400");
            scope.Start();
            try
            {
                using var message = CreateDeleteNonRetry400Request();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteNonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDelete202NonRetry400Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/nonretryerror/delete/202/retry/400", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 with a location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Delete202NonRetry400Headers>> Delete202NonRetry400Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Delete202NonRetry400");
            scope.Start();
            try
            {
                using var message = CreateDelete202NonRetry400Request();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Delete202NonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 202 with a location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Delete202NonRetry400Headers> Delete202NonRetry400(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Delete202NonRetry400");
            scope.Start();
            try
            {
                using var message = CreateDelete202NonRetry400Request();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Delete202NonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteAsyncRelativeRetry400Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/nonretryerror/deleteasync/retry/400", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRelativeRetry400Headers>> DeleteAsyncRelativeRetry400Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetry400");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetry400Request();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteAsyncRelativeRetry400Headers> DeleteAsyncRelativeRetry400(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetry400");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetry400Request();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePostNonRetry400Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/nonretryerror/post/400", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running post request, service returns a 400 with no error body. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<PostNonRetry400Headers>> PostNonRetry400Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostNonRetry400");
            scope.Start();
            try
            {
                using var message = CreatePostNonRetry400Request(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostNonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public ResponseWithHeaders<PostNonRetry400Headers> PostNonRetry400(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostNonRetry400");
            scope.Start();
            try
            {
                using var message = CreatePostNonRetry400Request(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostNonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePost202NonRetry400Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/nonretryerror/post/202/retry/400", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 with a location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Post202NonRetry400Headers>> Post202NonRetry400Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Post202NonRetry400");
            scope.Start();
            try
            {
                using var message = CreatePost202NonRetry400Request(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202NonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public ResponseWithHeaders<Post202NonRetry400Headers> Post202NonRetry400(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Post202NonRetry400");
            scope.Start();
            try
            {
                using var message = CreatePost202NonRetry400Request(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202NonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePostAsyncRelativeRetry400Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/nonretryerror/postasync/retry/400", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<PostAsyncRelativeRetry400Headers>> PostAsyncRelativeRetry400Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetry400");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetry400Request(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public ResponseWithHeaders<PostAsyncRelativeRetry400Headers> PostAsyncRelativeRetry400(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetry400");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetry400Request(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutError201NoProvisioningStatePayloadRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/put/201/noprovisioningstatepayload", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 201 to the initial request with no payload. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PutError201NoProvisioningStatePayloadAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutError201NoProvisioningStatePayload");
            scope.Start();
            try
            {
                using var message = CreatePutError201NoProvisioningStatePayloadRequest(product);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public Response<Product> PutError201NoProvisioningStatePayload(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutError201NoProvisioningStatePayload");
            scope.Start();
            try
            {
                using var message = CreatePutError201NoProvisioningStatePayloadRequest(product);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutAsyncRelativeRetryNoStatusRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/putasync/retry/nostatus", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRelativeRetryNoStatusHeaders>> PutAsyncRelativeRetryNoStatusAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryNoStatus");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryNoStatusRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryNoStatusHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public ResponseWithHeaders<Product, PutAsyncRelativeRetryNoStatusHeaders> PutAsyncRelativeRetryNoStatus(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryNoStatus");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryNoStatusRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryNoStatusHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutAsyncRelativeRetryNoStatusPayloadRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/putasync/retry/nostatuspayload", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRelativeRetryNoStatusPayloadHeaders>> PutAsyncRelativeRetryNoStatusPayloadAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryNoStatusPayload");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryNoStatusPayloadRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryNoStatusPayloadHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public ResponseWithHeaders<Product, PutAsyncRelativeRetryNoStatusPayloadHeaders> PutAsyncRelativeRetryNoStatusPayload(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryNoStatusPayload");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryNoStatusPayloadRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryNoStatusPayloadHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDelete204SucceededRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/delete/204/nolocation", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 204 to the initial request, indicating success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete204SucceededAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Delete204Succeeded");
            scope.Start();
            try
            {
                using var message = CreateDelete204SucceededRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 204:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 204 to the initial request, indicating success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete204Succeeded(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Delete204Succeeded");
            scope.Start();
            try
            {
                using var message = CreateDelete204SucceededRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 204:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteAsyncRelativeRetryNoStatusRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/deleteasync/retry/nostatus", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRelativeRetryNoStatusHeaders>> DeleteAsyncRelativeRetryNoStatusAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetryNoStatus");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetryNoStatusRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetryNoStatusHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteAsyncRelativeRetryNoStatusHeaders> DeleteAsyncRelativeRetryNoStatus(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetryNoStatus");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetryNoStatusRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetryNoStatusHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePost202NoLocationRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/post/202/nolocation", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, without a location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Post202NoLocationHeaders>> Post202NoLocationAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Post202NoLocation");
            scope.Start();
            try
            {
                using var message = CreatePost202NoLocationRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202NoLocationHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public ResponseWithHeaders<Post202NoLocationHeaders> Post202NoLocation(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Post202NoLocation");
            scope.Start();
            try
            {
                using var message = CreatePost202NoLocationRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202NoLocationHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePostAsyncRelativeRetryNoPayloadRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/postasync/retry/nopayload", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<PostAsyncRelativeRetryNoPayloadHeaders>> PostAsyncRelativeRetryNoPayloadAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetryNoPayload");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetryNoPayloadRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetryNoPayloadHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public ResponseWithHeaders<PostAsyncRelativeRetryNoPayloadHeaders> PostAsyncRelativeRetryNoPayload(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetryNoPayload");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetryNoPayloadRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetryNoPayloadHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePut200InvalidJsonRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/put/200/invalidjson", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that is not a valid json. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put200InvalidJsonAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Put200InvalidJson");
            scope.Start();
            try
            {
                using var message = CreatePut200InvalidJsonRequest(product);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public Response<Product> Put200InvalidJson(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Put200InvalidJson");
            scope.Start();
            try
            {
                using var message = CreatePut200InvalidJsonRequest(product);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutAsyncRelativeRetryInvalidHeaderRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/putasync/retry/invalidheader", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRelativeRetryInvalidHeaderHeaders>> PutAsyncRelativeRetryInvalidHeaderAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryInvalidHeaderRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public ResponseWithHeaders<Product, PutAsyncRelativeRetryInvalidHeaderHeaders> PutAsyncRelativeRetryInvalidHeader(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryInvalidHeaderRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutAsyncRelativeRetryInvalidJsonPollingRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/putasync/retry/invalidjsonpolling", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRelativeRetryInvalidJsonPollingHeaders>> PutAsyncRelativeRetryInvalidJsonPollingAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryInvalidJsonPollingRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public ResponseWithHeaders<Product, PutAsyncRelativeRetryInvalidJsonPollingHeaders> PutAsyncRelativeRetryInvalidJsonPolling(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryInvalidJsonPollingRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDelete202RetryInvalidHeaderRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/delete/202/retry/invalidheader", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request receing a reponse with an invalid &apos;Location&apos; and &apos;Retry-After&apos; headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Delete202RetryInvalidHeaderHeaders>> Delete202RetryInvalidHeaderAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Delete202RetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreateDelete202RetryInvalidHeaderRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Delete202RetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request receing a reponse with an invalid &apos;Location&apos; and &apos;Retry-After&apos; headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Delete202RetryInvalidHeaderHeaders> Delete202RetryInvalidHeader(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Delete202RetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreateDelete202RetryInvalidHeaderRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Delete202RetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteAsyncRelativeRetryInvalidHeaderRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/deleteasync/retry/invalidheader", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRelativeRetryInvalidHeaderHeaders>> DeleteAsyncRelativeRetryInvalidHeaderAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetryInvalidHeaderRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteAsyncRelativeRetryInvalidHeaderHeaders> DeleteAsyncRelativeRetryInvalidHeader(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetryInvalidHeaderRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteAsyncRelativeRetryInvalidJsonPollingRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/deleteasync/retry/invalidjsonpolling", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRelativeRetryInvalidJsonPollingHeaders>> DeleteAsyncRelativeRetryInvalidJsonPollingAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetryInvalidJsonPollingRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteAsyncRelativeRetryInvalidJsonPollingHeaders> DeleteAsyncRelativeRetryInvalidJsonPolling(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetryInvalidJsonPollingRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePost202RetryInvalidHeaderRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/post/202/retry/invalidheader", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with invalid &apos;Location&apos; and &apos;Retry-After&apos; headers. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Post202RetryInvalidHeaderHeaders>> Post202RetryInvalidHeaderAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Post202RetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreatePost202RetryInvalidHeaderRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202RetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with invalid &apos;Location&apos; and &apos;Retry-After&apos; headers. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Post202RetryInvalidHeaderHeaders> Post202RetryInvalidHeader(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Post202RetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreatePost202RetryInvalidHeaderRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202RetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePostAsyncRelativeRetryInvalidHeaderRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/postasync/retry/invalidheader", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<PostAsyncRelativeRetryInvalidHeaderHeaders>> PostAsyncRelativeRetryInvalidHeaderAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetryInvalidHeaderRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public ResponseWithHeaders<PostAsyncRelativeRetryInvalidHeaderHeaders> PostAsyncRelativeRetryInvalidHeader(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetryInvalidHeaderRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePostAsyncRelativeRetryInvalidJsonPollingRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/error/postasync/retry/invalidjsonpolling", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<PostAsyncRelativeRetryInvalidJsonPollingHeaders>> PostAsyncRelativeRetryInvalidJsonPollingAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetryInvalidJsonPollingRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public ResponseWithHeaders<PostAsyncRelativeRetryInvalidJsonPollingHeaders> PostAsyncRelativeRetryInvalidJsonPolling(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetryInvalidJsonPollingRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutNonRetry400PollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running put request, service returns a 400 to the initial request. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PutNonRetry400PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutNonRetry400");
            scope.Start();
            try
            {
                using var message = CreatePutNonRetry400PollingRequest(pollingLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running put request, service returns a 400 to the initial request. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PutNonRetry400Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutNonRetry400");
            scope.Start();
            try
            {
                using var message = CreatePutNonRetry400PollingRequest(pollingLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutNonRetry201Creating400PollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running put request, service returns a Product with &apos;ProvisioningState&apos; = &apos;Creating&apos; and 201 response code. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PutNonRetry201Creating400PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutNonRetry201Creating400");
            scope.Start();
            try
            {
                using var message = CreatePutNonRetry201Creating400PollingRequest(pollingLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running put request, service returns a Product with &apos;ProvisioningState&apos; = &apos;Creating&apos; and 201 response code. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PutNonRetry201Creating400Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutNonRetry201Creating400");
            scope.Start();
            try
            {
                using var message = CreatePutNonRetry201Creating400PollingRequest(pollingLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutNonRetry201Creating400InvalidJsonPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running put request, service returns a Product with &apos;ProvisioningState&apos; = &apos;Creating&apos; and 201 response code. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PutNonRetry201Creating400InvalidJsonPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutNonRetry201Creating400InvalidJson");
            scope.Start();
            try
            {
                using var message = CreatePutNonRetry201Creating400InvalidJsonPollingRequest(pollingLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running put request, service returns a Product with &apos;ProvisioningState&apos; = &apos;Creating&apos; and 201 response code. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PutNonRetry201Creating400InvalidJsonPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutNonRetry201Creating400InvalidJson");
            scope.Start();
            try
            {
                using var message = CreatePutNonRetry201Creating400InvalidJsonPollingRequest(pollingLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutAsyncRelativeRetry400PollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running put request, service returns a 200 with ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRelativeRetry400Headers>> PutAsyncRelativeRetry400PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetry400");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetry400PollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetry400Headers(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running put request, service returns a 200 with ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Product, PutAsyncRelativeRetry400Headers> PutAsyncRelativeRetry400Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetry400");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetry400PollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetry400Headers(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteNonRetry400PollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 400 with an error body. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteNonRetry400Headers>> DeleteNonRetry400PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteNonRetry400");
            scope.Start();
            try
            {
                using var message = CreateDeleteNonRetry400PollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteNonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 400 with an error body. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteNonRetry400Headers> DeleteNonRetry400Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteNonRetry400");
            scope.Start();
            try
            {
                using var message = CreateDeleteNonRetry400PollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteNonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDelete202NonRetry400PollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 with a location header. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Delete202NonRetry400Headers>> Delete202NonRetry400PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Delete202NonRetry400");
            scope.Start();
            try
            {
                using var message = CreateDelete202NonRetry400PollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Delete202NonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 202 with a location header. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Delete202NonRetry400Headers> Delete202NonRetry400Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Delete202NonRetry400");
            scope.Start();
            try
            {
                using var message = CreateDelete202NonRetry400PollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Delete202NonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteAsyncRelativeRetry400PollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRelativeRetry400Headers>> DeleteAsyncRelativeRetry400PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetry400");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetry400PollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteAsyncRelativeRetry400Headers> DeleteAsyncRelativeRetry400Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetry400");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetry400PollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePostNonRetry400PollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running post request, service returns a 400 with no error body. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<PostNonRetry400Headers>> PostNonRetry400PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostNonRetry400");
            scope.Start();
            try
            {
                using var message = CreatePostNonRetry400PollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostNonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running post request, service returns a 400 with no error body. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<PostNonRetry400Headers> PostNonRetry400Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostNonRetry400");
            scope.Start();
            try
            {
                using var message = CreatePostNonRetry400PollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostNonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePost202NonRetry400PollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running post request, service returns a 202 with a location header. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Post202NonRetry400Headers>> Post202NonRetry400PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Post202NonRetry400");
            scope.Start();
            try
            {
                using var message = CreatePost202NonRetry400PollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202NonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running post request, service returns a 202 with a location header. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Post202NonRetry400Headers> Post202NonRetry400Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Post202NonRetry400");
            scope.Start();
            try
            {
                using var message = CreatePost202NonRetry400PollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202NonRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePostAsyncRelativeRetry400PollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<PostAsyncRelativeRetry400Headers>> PostAsyncRelativeRetry400PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetry400");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetry400PollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running post request, service returns a 202 to the initial request Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<PostAsyncRelativeRetry400Headers> PostAsyncRelativeRetry400Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetry400");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetry400PollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetry400Headers(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutError201NoProvisioningStatePayloadPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running put request, service returns a 201 to the initial request with no payload. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PutError201NoProvisioningStatePayloadPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutError201NoProvisioningStatePayload");
            scope.Start();
            try
            {
                using var message = CreatePutError201NoProvisioningStatePayloadPollingRequest(pollingLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running put request, service returns a 201 to the initial request with no payload. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PutError201NoProvisioningStatePayloadPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutError201NoProvisioningStatePayload");
            scope.Start();
            try
            {
                using var message = CreatePutError201NoProvisioningStatePayloadPollingRequest(pollingLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutAsyncRelativeRetryNoStatusPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRelativeRetryNoStatusHeaders>> PutAsyncRelativeRetryNoStatusPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryNoStatus");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryNoStatusPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryNoStatusHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Product, PutAsyncRelativeRetryNoStatusHeaders> PutAsyncRelativeRetryNoStatusPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryNoStatus");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryNoStatusPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryNoStatusHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutAsyncRelativeRetryNoStatusPayloadPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRelativeRetryNoStatusPayloadHeaders>> PutAsyncRelativeRetryNoStatusPayloadPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryNoStatusPayload");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryNoStatusPayloadPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryNoStatusPayloadHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Product, PutAsyncRelativeRetryNoStatusPayloadHeaders> PutAsyncRelativeRetryNoStatusPayloadPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryNoStatusPayload");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryNoStatusPayloadPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryNoStatusPayloadHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDelete204SucceededPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 204 to the initial request, indicating success. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete204SucceededPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Delete204Succeeded");
            scope.Start();
            try
            {
                using var message = CreateDelete204SucceededPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 204:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 204 to the initial request, indicating success. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete204SucceededPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Delete204Succeeded");
            scope.Start();
            try
            {
                using var message = CreateDelete204SucceededPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 204:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteAsyncRelativeRetryNoStatusPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRelativeRetryNoStatusHeaders>> DeleteAsyncRelativeRetryNoStatusPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetryNoStatus");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetryNoStatusPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetryNoStatusHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteAsyncRelativeRetryNoStatusHeaders> DeleteAsyncRelativeRetryNoStatusPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetryNoStatus");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetryNoStatusPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetryNoStatusHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePost202NoLocationPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, without a location header. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Post202NoLocationHeaders>> Post202NoLocationPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Post202NoLocation");
            scope.Start();
            try
            {
                using var message = CreatePost202NoLocationPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202NoLocationHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, without a location header. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Post202NoLocationHeaders> Post202NoLocationPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Post202NoLocation");
            scope.Start();
            try
            {
                using var message = CreatePost202NoLocationPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202NoLocationHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePostAsyncRelativeRetryNoPayloadPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<PostAsyncRelativeRetryNoPayloadHeaders>> PostAsyncRelativeRetryNoPayloadPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetryNoPayload");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetryNoPayloadPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetryNoPayloadHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<PostAsyncRelativeRetryNoPayloadHeaders> PostAsyncRelativeRetryNoPayloadPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetryNoPayload");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetryNoPayloadPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetryNoPayloadHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePut200InvalidJsonPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that is not a valid json. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put200InvalidJsonPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Put200InvalidJson");
            scope.Start();
            try
            {
                using var message = CreatePut200InvalidJsonPollingRequest(pollingLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that is not a valid json. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Put200InvalidJsonPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Put200InvalidJson");
            scope.Start();
            try
            {
                using var message = CreatePut200InvalidJsonPollingRequest(pollingLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutAsyncRelativeRetryInvalidHeaderPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRelativeRetryInvalidHeaderHeaders>> PutAsyncRelativeRetryInvalidHeaderPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryInvalidHeaderPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Product, PutAsyncRelativeRetryInvalidHeaderHeaders> PutAsyncRelativeRetryInvalidHeaderPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryInvalidHeaderPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutAsyncRelativeRetryInvalidJsonPollingPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRelativeRetryInvalidJsonPollingHeaders>> PutAsyncRelativeRetryInvalidJsonPollingPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryInvalidJsonPollingPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Product, PutAsyncRelativeRetryInvalidJsonPollingHeaders> PutAsyncRelativeRetryInvalidJsonPollingPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PutAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRelativeRetryInvalidJsonPollingPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDelete202RetryInvalidHeaderPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request receing a reponse with an invalid &apos;Location&apos; and &apos;Retry-After&apos; headers. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Delete202RetryInvalidHeaderHeaders>> Delete202RetryInvalidHeaderPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Delete202RetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreateDelete202RetryInvalidHeaderPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Delete202RetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request receing a reponse with an invalid &apos;Location&apos; and &apos;Retry-After&apos; headers. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Delete202RetryInvalidHeaderHeaders> Delete202RetryInvalidHeaderPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Delete202RetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreateDelete202RetryInvalidHeaderPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Delete202RetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteAsyncRelativeRetryInvalidHeaderPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRelativeRetryInvalidHeaderHeaders>> DeleteAsyncRelativeRetryInvalidHeaderPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetryInvalidHeaderPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteAsyncRelativeRetryInvalidHeaderHeaders> DeleteAsyncRelativeRetryInvalidHeaderPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetryInvalidHeaderPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteAsyncRelativeRetryInvalidJsonPollingPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRelativeRetryInvalidJsonPollingHeaders>> DeleteAsyncRelativeRetryInvalidJsonPollingPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetryInvalidJsonPollingPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteAsyncRelativeRetryInvalidJsonPollingHeaders> DeleteAsyncRelativeRetryInvalidJsonPollingPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.DeleteAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRelativeRetryInvalidJsonPollingPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePost202RetryInvalidHeaderPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with invalid &apos;Location&apos; and &apos;Retry-After&apos; headers. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Post202RetryInvalidHeaderHeaders>> Post202RetryInvalidHeaderPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Post202RetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreatePost202RetryInvalidHeaderPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202RetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with invalid &apos;Location&apos; and &apos;Retry-After&apos; headers. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Post202RetryInvalidHeaderHeaders> Post202RetryInvalidHeaderPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.Post202RetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreatePost202RetryInvalidHeaderPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202RetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePostAsyncRelativeRetryInvalidHeaderPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<PostAsyncRelativeRetryInvalidHeaderHeaders>> PostAsyncRelativeRetryInvalidHeaderPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetryInvalidHeaderPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. The endpoint indicated in the Azure-AsyncOperation header is invalid. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<PostAsyncRelativeRetryInvalidHeaderHeaders> PostAsyncRelativeRetryInvalidHeaderPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetryInvalidHeader");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetryInvalidHeaderPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetryInvalidHeaderHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePostAsyncRelativeRetryInvalidJsonPollingPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<PostAsyncRelativeRetryInvalidJsonPollingHeaders>> PostAsyncRelativeRetryInvalidJsonPollingPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetryInvalidJsonPollingPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<PostAsyncRelativeRetryInvalidJsonPollingHeaders> PostAsyncRelativeRetryInvalidJsonPollingPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROSADsOperations.PostAsyncRelativeRetryInvalidJsonPolling");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRelativeRetryInvalidJsonPollingPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRelativeRetryInvalidJsonPollingHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
