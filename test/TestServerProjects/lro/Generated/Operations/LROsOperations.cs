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
using custom_baseUrl_paging.Models;
using lro.Models;
using Product = lro.Models.Product;

namespace lro
{
    internal partial class LROsOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of LROsOperations. </summary>
        public LROsOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }

        //public async ValueTask<Operation<Product>> Put200SucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        //{
        //    var originalResponse = (await Put200SucceededAsync(product, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        //    using var originalRequest = CreatePut200SucceededRequest(product);
        //    var originalUri = originalRequest.Request.Uri.ToString();
        //    var originalInfo = ArmPollingHelpers.GetScenarioInfo(originalResponse, originalUri);
        //    const bool isPutOrPatch = true;
        //    if (!isPutOrPatch && (originalInfo.HeaderFrom == ArmPollingHelpers.HeaderFrom.None || originalInfo.HeaderFrom != ArmPollingHelpers.HeaderFrom.Location))
        //    {
        //        throw await originalResponse.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
        //    }

        //    return OperationFactory.CreateAsync(originalResponse, async (r, c) =>
        //    {
        //        var info = ArmPollingHelpers.GetScenarioInfo(r, originalUri);
        //        return await ArmPollingHelpers.GetResponseAsync(pipeline, clientDiagnostics, "LROsOperations.Put200Succeeded", info.PollUri, c).ConfigureAwait(false);
        //    }, r =>
        //    {
        //        var info = ArmPollingHelpers.GetScenarioInfo(r, originalUri);
        //        return new ValueTask<bool>(ArmPollingHelpers.IsTerminalState(r, info));
        //    }, async (r, c) =>
        //    {
        //        var finalUri = isPutOrPatch ? originalUri : originalInfo.PollUri;
        //        var response = await ArmPollingHelpers.GetResponseAsync(pipeline, clientDiagnostics, "LROsOperations.Put200Succeeded", finalUri, c).ConfigureAwait(false);
        //        using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
        //        var value = Product.DeserializeProduct(document.RootElement);
        //        return Response.FromValue(value, response);
        //    });
        //}

        internal HttpMessage CreatePut200SucceededRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/put/200/succeeded", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put200SucceededAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200Succeeded");
            scope.Start();
            try
            {
                using var message = CreatePut200SucceededRequest(product);
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Put200Succeeded(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200Succeeded");
            scope.Start();
            try
            {
                using var message = CreatePut200SucceededRequest(product);
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
        internal HttpMessage CreatePut200SucceededNoStateRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/put/200/succeeded/nostate", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that does not contain ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put200SucceededNoStateAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200SucceededNoState");
            scope.Start();
            try
            {
                using var message = CreatePut200SucceededNoStateRequest(product);
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that does not contain ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Put200SucceededNoState(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200SucceededNoState");
            scope.Start();
            try
            {
                using var message = CreatePut200SucceededNoStateRequest(product);
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
        internal HttpMessage CreatePut202Retry200Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/put/202/retry/200", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 202 to the initial request, with a location header that points to a polling URL that returns a 200 and an entity that doesn&apos;t contains ProvisioningState. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put202Retry200Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put202Retry200");
            scope.Start();
            try
            {
                using var message = CreatePut202Retry200Request(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Long running put request, service returns a 202 to the initial request, with a location header that points to a polling URL that returns a 200 and an entity that doesn&apos;t contains ProvisioningState. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Put202Retry200(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put202Retry200");
            scope.Start();
            try
            {
                using var message = CreatePut202Retry200Request(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreatePut201CreatingSucceeded200Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/put/201/creating/succeeded/200", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put201CreatingSucceeded200Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put201CreatingSucceeded200");
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
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
        public Response<Product> Put201CreatingSucceeded200(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put201CreatingSucceeded200");
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePut200UpdatingSucceeded204Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/put/200/updating/succeeded/200", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Updating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put200UpdatingSucceeded204Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200UpdatingSucceeded204");
            scope.Start();
            try
            {
                using var message = CreatePut200UpdatingSucceeded204Request(product);
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Updating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Put200UpdatingSucceeded204(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200UpdatingSucceeded204");
            scope.Start();
            try
            {
                using var message = CreatePut200UpdatingSucceeded204Request(product);
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
        internal HttpMessage CreatePut201CreatingFailed200Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/put/201/created/failed/200", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Created’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put201CreatingFailed200Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put201CreatingFailed200");
            scope.Start();
            try
            {
                using var message = CreatePut201CreatingFailed200Request(product);
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Created’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Put201CreatingFailed200(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put201CreatingFailed200");
            scope.Start();
            try
            {
                using var message = CreatePut201CreatingFailed200Request(product);
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
        internal HttpMessage CreatePut200Acceptedcanceled200Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/put/200/accepted/canceled/200", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put200Acceptedcanceled200Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200Acceptedcanceled200");
            scope.Start();
            try
            {
                using var message = CreatePut200Acceptedcanceled200Request(product);
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Put200Acceptedcanceled200(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200Acceptedcanceled200");
            scope.Start();
            try
            {
                using var message = CreatePut200Acceptedcanceled200Request(product);
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
        internal HttpMessage CreatePutNoHeaderInRetryRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/put/noheader/202/200", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 202 to the initial request with location header. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutNoHeaderInRetryHeaders>> PutNoHeaderInRetryAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreatePutNoHeaderInRetryRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutNoHeaderInRetryHeaders(message.Response);
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
        /// <summary> Long running put request, service returns a 202 to the initial request with location header. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Product, PutNoHeaderInRetryHeaders> PutNoHeaderInRetry(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreatePutNoHeaderInRetryRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutNoHeaderInRetryHeaders(message.Response);
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
        //public async ValueTask<Operation<Product>> PutAsyncRetrySucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        //{
        //    var originalResponse = (await PutAsyncRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        //    using var originalRequest = CreatePutAsyncRetrySucceededRequest(product);
        //    var originalUri = originalRequest.Request.Uri.ToString();
        //    var originalInfo = ArmPollingHelpers.GetScenarioInfo(originalResponse, originalUri);
        //    const bool isPutOrPatch = true;
        //    if (!isPutOrPatch && (originalInfo.HeaderFrom == ArmPollingHelpers.HeaderFrom.None || originalInfo.HeaderFrom != ArmPollingHelpers.HeaderFrom.Location))
        //    {
        //        throw await originalResponse.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
        //    }

        //    return OperationFactory.CreateAsync(originalResponse, async (r, c) =>
        //    {
        //        var info = ArmPollingHelpers.GetScenarioInfo(r, originalUri);
        //        return await ArmPollingHelpers.GetResponseAsync(pipeline, clientDiagnostics, "LROsOperations.Put200Succeeded", info.PollUri, c).ConfigureAwait(false);
        //    }, r =>
        //    {
        //        var info = ArmPollingHelpers.GetScenarioInfo(r, originalUri);
        //        return new ValueTask<bool>(ArmPollingHelpers.IsTerminalState(r, info));
        //    }, async (r, c) =>
        //    {
        //        var finalUri = isPutOrPatch ? originalUri : originalInfo.PollUri;
        //        var response = await ArmPollingHelpers.GetResponseAsync(pipeline, clientDiagnostics, "LROsOperations.Put200Succeeded", finalUri, c).ConfigureAwait(false);
        //        switch (response.Status)
        //        {
        //            case 200:
        //            case 204 when !isPutOrPatch:
        //            {
        //                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
        //                var value = Product.DeserializeProduct(document.RootElement);
        //                return Response.FromValue(value, response);
        //            }
        //            default:
        //                throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
        //        }
        //    });
        //}

        public async ValueTask<Operation<Product>> PutAsyncRetrySucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = (await PutAsyncRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            return await ArmOperationHelpers.CreateAsync(pipeline, clientDiagnostics, originalResponse, true, "LROsOperations.Put200Succeeded",
                () => CreatePutAsyncRetrySucceededRequest(product),
                async response =>
                {
                    using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                    var value = Product.DeserializeProduct(document.RootElement);
                    return Response.FromValue(value, response);
                });
            //using var originalRequest = CreatePutAsyncRetrySucceededRequest(product);
            //var originalUri = originalRequest.Request.Uri.ToString();
            //var originalInfo = ArmPollingHelpers.GetScenarioInfo(originalResponse, originalUri);
            //const bool isPutOrPatch = true;
            //if (!isPutOrPatch && (originalInfo.HeaderFrom == ArmPollingHelpers.HeaderFrom.None || originalInfo.HeaderFrom != ArmPollingHelpers.HeaderFrom.Location))
            //{
            //    throw await originalResponse.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
            //}

            //return OperationFactory.CreateAsync(originalResponse, async (r, c) =>
            //{
            //    var info = ArmPollingHelpers.GetScenarioInfo(r, originalUri);
            //    return await ArmPollingHelpers.GetResponseAsync(pipeline, clientDiagnostics, "LROsOperations.Put200Succeeded", info.PollUri, c).ConfigureAwait(false);
            //}, r =>
            //{
            //    var info = ArmPollingHelpers.GetScenarioInfo(r, originalUri);
            //    return new ValueTask<bool>(ArmPollingHelpers.IsTerminalState(r, info));
            //}, async (r, c) =>
            //{
            //    var finalUri = isPutOrPatch ? originalUri : originalInfo.PollUri;
            //    var response = await ArmPollingHelpers.GetResponseAsync(pipeline, clientDiagnostics, "LROsOperations.Put200Succeeded", finalUri, c).ConfigureAwait(false);
            //    switch (response.Status)
            //    {
            //        case 200:
            //        case 204 when !isPutOrPatch:
            //            {
            //                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            //                var value = Product.DeserializeProduct(document.RootElement);
            //                return Response.FromValue(value, response);
            //            }
            //        default:
            //            throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
            //    }
            //});
        }
        internal HttpMessage CreatePutAsyncRetrySucceededRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/putasync/retry/succeeded", false);
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
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRetrySucceededHeaders>> PutAsyncRetrySucceededAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRetrySucceededRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRetrySucceededHeaders(message.Response);
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
        public ResponseWithHeaders<Product, PutAsyncRetrySucceededHeaders> PutAsyncRetrySucceeded(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRetrySucceededRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRetrySucceededHeaders(message.Response);
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
        internal HttpMessage CreatePutAsyncNoRetrySucceededRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/putasync/noretry/succeeded", false);
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
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncNoRetrySucceededHeaders>> PutAsyncNoRetrySucceededAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNoRetrySucceededRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncNoRetrySucceededHeaders(message.Response);
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
        public ResponseWithHeaders<Product, PutAsyncNoRetrySucceededHeaders> PutAsyncNoRetrySucceeded(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNoRetrySucceededRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncNoRetrySucceededHeaders(message.Response);
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
        internal HttpMessage CreatePutAsyncRetryFailedRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/putasync/retry/failed", false);
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
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRetryFailedHeaders>> PutAsyncRetryFailedAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncRetryFailed");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRetryFailedRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRetryFailedHeaders(message.Response);
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
        public ResponseWithHeaders<Product, PutAsyncRetryFailedHeaders> PutAsyncRetryFailed(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncRetryFailed");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRetryFailedRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRetryFailedHeaders(message.Response);
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
        internal HttpMessage CreatePutAsyncNoRetrycanceledRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/putasync/noretry/canceled", false);
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
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncNoRetrycanceledHeaders>> PutAsyncNoRetrycanceledAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNoRetrycanceled");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNoRetrycanceledRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncNoRetrycanceledHeaders(message.Response);
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
        public ResponseWithHeaders<Product, PutAsyncNoRetrycanceledHeaders> PutAsyncNoRetrycanceled(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNoRetrycanceled");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNoRetrycanceledRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncNoRetrycanceledHeaders(message.Response);
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
        internal HttpMessage CreatePutAsyncNoHeaderInRetryRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/putasync/noheader/201/200", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request, service returns a 202 to the initial request with Azure-AsyncOperation header. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncNoHeaderInRetryHeaders>> PutAsyncNoHeaderInRetryAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNoHeaderInRetryRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncNoHeaderInRetryHeaders(message.Response);
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
        /// <summary> Long running put request, service returns a 202 to the initial request with Azure-AsyncOperation header. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Product, PutAsyncNoHeaderInRetryHeaders> PutAsyncNoHeaderInRetry(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNoHeaderInRetryRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncNoHeaderInRetryHeaders(message.Response);
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
        internal HttpMessage CreatePutNonResourceRequest(Sku sku)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/putnonresource/202/200", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(sku);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Sku>> PutNonResourceAsync(Sku sku, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutNonResource");
            scope.Start();
            try
            {
                using var message = CreatePutNonResourceRequest(sku);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Sku.DeserializeSku(document.RootElement);
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
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Sku> PutNonResource(Sku sku, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutNonResource");
            scope.Start();
            try
            {
                using var message = CreatePutNonResourceRequest(sku);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Sku.DeserializeSku(document.RootElement);
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
        internal HttpMessage CreatePutAsyncNonResourceRequest(Sku sku)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/putnonresourceasync/202/200", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(sku);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Sku>> PutAsyncNonResourceAsync(Sku sku, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNonResource");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNonResourceRequest(sku);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Sku.DeserializeSku(document.RootElement);
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
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Sku> PutAsyncNonResource(Sku sku, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNonResource");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNonResourceRequest(sku);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Sku.DeserializeSku(document.RootElement);
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
        internal HttpMessage CreatePutSubResourceRequest(SubProduct product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/putsubresource/202/200", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SubProduct>> PutSubResourceAsync(SubProduct product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutSubResource");
            scope.Start();
            try
            {
                using var message = CreatePutSubResourceRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = SubProduct.DeserializeSubProduct(document.RootElement);
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
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SubProduct> PutSubResource(SubProduct product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutSubResource");
            scope.Start();
            try
            {
                using var message = CreatePutSubResourceRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = SubProduct.DeserializeSubProduct(document.RootElement);
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
        internal HttpMessage CreatePutAsyncSubResourceRequest(SubProduct product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/putsubresourceasync/202/200", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SubProduct>> PutAsyncSubResourceAsync(SubProduct product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncSubResource");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncSubResourceRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = SubProduct.DeserializeSubProduct(document.RootElement);
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
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SubProduct> PutAsyncSubResource(SubProduct product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncSubResource");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncSubResourceRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = SubProduct.DeserializeSubProduct(document.RootElement);
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
        internal HttpMessage CreateDeleteProvisioning202Accepted200SucceededRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/delete/provisioning/202/accepted/200/succeeded", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> DeleteProvisioning202Accepted200SucceededAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteProvisioning202Accepted200Succeeded");
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> DeleteProvisioning202Accepted200Succeeded(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteProvisioning202Accepted200Succeeded");
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteProvisioning202DeletingFailed200Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/delete/provisioning/202/deleting/200/failed", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> DeleteProvisioning202DeletingFailed200Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteProvisioning202DeletingFailed200");
            scope.Start();
            try
            {
                using var message = CreateDeleteProvisioning202DeletingFailed200Request();
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
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> DeleteProvisioning202DeletingFailed200(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteProvisioning202DeletingFailed200");
            scope.Start();
            try
            {
                using var message = CreateDeleteProvisioning202DeletingFailed200Request();
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
        internal HttpMessage CreateDeleteProvisioning202Deletingcanceled200Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/delete/provisioning/202/deleting/200/canceled", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> DeleteProvisioning202Deletingcanceled200Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteProvisioning202Deletingcanceled200");
            scope.Start();
            try
            {
                using var message = CreateDeleteProvisioning202Deletingcanceled200Request();
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
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> DeleteProvisioning202Deletingcanceled200(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteProvisioning202Deletingcanceled200");
            scope.Start();
            try
            {
                using var message = CreateDeleteProvisioning202Deletingcanceled200Request();
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
        internal HttpMessage CreateDelete204SucceededRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/delete/204/succeeded", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete succeeds and returns right away. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete204SucceededAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.Delete204Succeeded");
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
        /// <summary> Long running delete succeeds and returns right away. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete204Succeeded(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.Delete204Succeeded");
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
        internal HttpMessage CreateDelete202Retry200Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/delete/202/retry/200", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Delete202Retry200Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.Delete202Retry200");
            scope.Start();
            try
            {
                using var message = CreateDelete202Retry200Request();
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Delete202Retry200(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.Delete202Retry200");
            scope.Start();
            try
            {
                using var message = CreateDelete202Retry200Request();
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
        internal HttpMessage CreateDelete202NoRetry204Request()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/delete/202/noretry/204", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Delete202NoRetry204Async(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.Delete202NoRetry204");
            scope.Start();
            try
            {
                using var message = CreateDelete202NoRetry204Request();
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Delete202NoRetry204(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.Delete202NoRetry204");
            scope.Start();
            try
            {
                using var message = CreateDelete202NoRetry204Request();
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
        internal HttpMessage CreateDeleteNoHeaderInRetryRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/delete/noheader", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a location header in the initial request. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteNoHeaderInRetryHeaders>> DeleteNoHeaderInRetryAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreateDeleteNoHeaderInRetryRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteNoHeaderInRetryHeaders(message.Response);
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
        /// <summary> Long running delete request, service returns a location header in the initial request. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteNoHeaderInRetryHeaders> DeleteNoHeaderInRetry(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreateDeleteNoHeaderInRetryRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteNoHeaderInRetryHeaders(message.Response);
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
        internal HttpMessage CreateDeleteAsyncNoHeaderInRetryRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/deleteasync/noheader/202/204", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns an Azure-AsyncOperation header in the initial request. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncNoHeaderInRetryHeaders>> DeleteAsyncNoHeaderInRetryAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncNoHeaderInRetryRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncNoHeaderInRetryHeaders(message.Response);
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
        /// <summary> Long running delete request, service returns an Azure-AsyncOperation header in the initial request. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteAsyncNoHeaderInRetryHeaders> DeleteAsyncNoHeaderInRetry(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncNoHeaderInRetryRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncNoHeaderInRetryHeaders(message.Response);
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
        internal HttpMessage CreateDeleteAsyncRetrySucceededRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/deleteasync/retry/succeeded", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRetrySucceededHeaders>> DeleteAsyncRetrySucceededAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRetrySucceededRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRetrySucceededHeaders(message.Response);
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
        public ResponseWithHeaders<DeleteAsyncRetrySucceededHeaders> DeleteAsyncRetrySucceeded(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRetrySucceededRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRetrySucceededHeaders(message.Response);
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
        internal HttpMessage CreateDeleteAsyncNoRetrySucceededRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/deleteasync/noretry/succeeded", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncNoRetrySucceededHeaders>> DeleteAsyncNoRetrySucceededAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncNoRetrySucceededRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncNoRetrySucceededHeaders(message.Response);
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
        public ResponseWithHeaders<DeleteAsyncNoRetrySucceededHeaders> DeleteAsyncNoRetrySucceeded(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncNoRetrySucceededRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncNoRetrySucceededHeaders(message.Response);
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
        internal HttpMessage CreateDeleteAsyncRetryFailedRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/deleteasync/retry/failed", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRetryFailedHeaders>> DeleteAsyncRetryFailedAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncRetryFailed");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRetryFailedRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRetryFailedHeaders(message.Response);
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
        public ResponseWithHeaders<DeleteAsyncRetryFailedHeaders> DeleteAsyncRetryFailed(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncRetryFailed");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRetryFailedRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRetryFailedHeaders(message.Response);
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
        internal HttpMessage CreateDeleteAsyncRetrycanceledRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/deleteasync/retry/canceled", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRetrycanceledHeaders>> DeleteAsyncRetrycanceledAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncRetrycanceled");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRetrycanceledRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRetrycanceledHeaders(message.Response);
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
        public ResponseWithHeaders<DeleteAsyncRetrycanceledHeaders> DeleteAsyncRetrycanceled(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncRetrycanceled");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRetrycanceledRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRetrycanceledHeaders(message.Response);
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
        internal HttpMessage CreatePost200WithPayloadRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/post/payload/200", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header. Poll returns a 200 with a response body after success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Sku>> Post200WithPayloadAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.Post200WithPayload");
            scope.Start();
            try
            {
                using var message = CreatePost200WithPayloadRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Sku.DeserializeSku(document.RootElement);
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header. Poll returns a 200 with a response body after success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Sku> Post200WithPayload(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.Post200WithPayload");
            scope.Start();
            try
            {
                using var message = CreatePost200WithPayloadRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Sku.DeserializeSku(document.RootElement);
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
        internal HttpMessage CreatePost202Retry200Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/post/202/retry/200", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Post202Retry200Headers>> Post202Retry200Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Post202Retry200");
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Post202Retry200Headers> Post202Retry200(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Post202Retry200");
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePost202NoRetry204Request(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/post/202/noretry/204", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(product);
            request.Content = content;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header, 204 with noresponse body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, Post202NoRetry204Headers>> Post202NoRetry204Async(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Post202NoRetry204");
            scope.Start();
            try
            {
                using var message = CreatePost202NoRetry204Request(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new Post202NoRetry204Headers(message.Response);
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header, 204 with noresponse body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Product, Post202NoRetry204Headers> Post202NoRetry204(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Post202NoRetry204");
            scope.Start();
            try
            {
                using var message = CreatePost202NoRetry204Request(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new Post202NoRetry204Headers(message.Response);
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
        internal HttpMessage CreatePostDoubleHeadersFinalLocationGetRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/LROPostDoubleHeadersFinalLocationGet", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PostDoubleHeadersFinalLocationGetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostDoubleHeadersFinalLocationGet");
            scope.Start();
            try
            {
                using var message = CreatePostDoubleHeadersFinalLocationGetRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PostDoubleHeadersFinalLocationGet(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostDoubleHeadersFinalLocationGet");
            scope.Start();
            try
            {
                using var message = CreatePostDoubleHeadersFinalLocationGetRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreatePostDoubleHeadersFinalAzureHeaderGetRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/LROPostDoubleHeadersFinalAzureHeaderGet", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PostDoubleHeadersFinalAzureHeaderGetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostDoubleHeadersFinalAzureHeaderGet");
            scope.Start();
            try
            {
                using var message = CreatePostDoubleHeadersFinalAzureHeaderGetRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PostDoubleHeadersFinalAzureHeaderGet(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostDoubleHeadersFinalAzureHeaderGet");
            scope.Start();
            try
            {
                using var message = CreatePostDoubleHeadersFinalAzureHeaderGetRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreatePostDoubleHeadersFinalAzureHeaderGetDefaultRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/LROPostDoubleHeadersFinalAzureHeaderGetDefault", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object if you support initial Autorest behavior. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PostDoubleHeadersFinalAzureHeaderGetDefaultAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostDoubleHeadersFinalAzureHeaderGetDefault");
            scope.Start();
            try
            {
                using var message = CreatePostDoubleHeadersFinalAzureHeaderGetDefaultRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object if you support initial Autorest behavior. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PostDoubleHeadersFinalAzureHeaderGetDefault(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostDoubleHeadersFinalAzureHeaderGetDefault");
            scope.Start();
            try
            {
                using var message = CreatePostDoubleHeadersFinalAzureHeaderGetDefaultRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreatePostAsyncRetrySucceededRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/postasync/retry/succeeded", false);
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
        public async ValueTask<Response<Product>> PostAsyncRetrySucceededAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRetrySucceededRequest(product);
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PostAsyncRetrySucceeded(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRetrySucceededRequest(product);
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
        internal HttpMessage CreatePostAsyncNoRetrySucceededRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/postasync/noretry/succeeded", false);
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
        public async ValueTask<Response<Product>> PostAsyncNoRetrySucceededAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncNoRetrySucceededRequest(product);
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PostAsyncNoRetrySucceeded(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncNoRetrySucceededRequest(product);
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
        internal HttpMessage CreatePostAsyncRetryFailedRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/postasync/retry/failed", false);
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
        public async ValueTask<ResponseWithHeaders<PostAsyncRetryFailedHeaders>> PostAsyncRetryFailedAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncRetryFailed");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRetryFailedRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRetryFailedHeaders(message.Response);
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
        public ResponseWithHeaders<PostAsyncRetryFailedHeaders> PostAsyncRetryFailed(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncRetryFailed");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRetryFailedRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRetryFailedHeaders(message.Response);
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
        internal HttpMessage CreatePostAsyncRetrycanceledRequest(Product product)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/lro/postasync/retry/canceled", false);
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
        public async ValueTask<ResponseWithHeaders<PostAsyncRetrycanceledHeaders>> PostAsyncRetrycanceledAsync(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncRetrycanceled");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRetrycanceledRequest(product);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRetrycanceledHeaders(message.Response);
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
        public ResponseWithHeaders<PostAsyncRetrycanceledHeaders> PostAsyncRetrycanceled(Product product, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncRetrycanceled");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRetrycanceledRequest(product);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRetrycanceledHeaders(message.Response);
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
        internal HttpMessage CreatePut200SucceededPollingRequest(string pollingLink)
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put200SucceededPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200Succeeded");
            scope.Start();
            try
            {
                using var message = CreatePut200SucceededPollingRequest(pollingLink);
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Put200SucceededPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200Succeeded");
            scope.Start();
            try
            {
                using var message = CreatePut200SucceededPollingRequest(pollingLink);
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
        internal HttpMessage CreatePut200SucceededNoStatePollingRequest(string pollingLink)
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that does not contain ProvisioningState=’Succeeded’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put200SucceededNoStatePollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200SucceededNoState");
            scope.Start();
            try
            {
                using var message = CreatePut200SucceededNoStatePollingRequest(pollingLink);
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that does not contain ProvisioningState=’Succeeded’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Put200SucceededNoStatePolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200SucceededNoState");
            scope.Start();
            try
            {
                using var message = CreatePut200SucceededNoStatePollingRequest(pollingLink);
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
        internal HttpMessage CreatePut202Retry200PollingRequest(string pollingLink)
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
        /// <summary> Long running put request, service returns a 202 to the initial request, with a location header that points to a polling URL that returns a 200 and an entity that doesn&apos;t contains ProvisioningState. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put202Retry200PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put202Retry200");
            scope.Start();
            try
            {
                using var message = CreatePut202Retry200PollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Long running put request, service returns a 202 to the initial request, with a location header that points to a polling URL that returns a 200 and an entity that doesn&apos;t contains ProvisioningState. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Put202Retry200Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put202Retry200");
            scope.Start();
            try
            {
                using var message = CreatePut202Retry200PollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreatePut201CreatingSucceeded200PollingRequest(string pollingLink)
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put201CreatingSucceeded200PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put201CreatingSucceeded200");
            scope.Start();
            try
            {
                using var message = CreatePut201CreatingSucceeded200PollingRequest(pollingLink);
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Put201CreatingSucceeded200Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put201CreatingSucceeded200");
            scope.Start();
            try
            {
                using var message = CreatePut201CreatingSucceeded200PollingRequest(pollingLink);
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
        internal HttpMessage CreatePut200UpdatingSucceeded204PollingRequest(string pollingLink)
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Updating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put200UpdatingSucceeded204PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200UpdatingSucceeded204");
            scope.Start();
            try
            {
                using var message = CreatePut200UpdatingSucceeded204PollingRequest(pollingLink);
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Updating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Put200UpdatingSucceeded204Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200UpdatingSucceeded204");
            scope.Start();
            try
            {
                using var message = CreatePut200UpdatingSucceeded204PollingRequest(pollingLink);
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
        internal HttpMessage CreatePut201CreatingFailed200PollingRequest(string pollingLink)
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Created’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put201CreatingFailed200PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put201CreatingFailed200");
            scope.Start();
            try
            {
                using var message = CreatePut201CreatingFailed200PollingRequest(pollingLink);
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Created’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Put201CreatingFailed200Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put201CreatingFailed200");
            scope.Start();
            try
            {
                using var message = CreatePut201CreatingFailed200PollingRequest(pollingLink);
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
        internal HttpMessage CreatePut200Acceptedcanceled200PollingRequest(string pollingLink)
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Put200Acceptedcanceled200PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200Acceptedcanceled200");
            scope.Start();
            try
            {
                using var message = CreatePut200Acceptedcanceled200PollingRequest(pollingLink);
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Put200Acceptedcanceled200Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Put200Acceptedcanceled200");
            scope.Start();
            try
            {
                using var message = CreatePut200Acceptedcanceled200PollingRequest(pollingLink);
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
        internal HttpMessage CreatePutNoHeaderInRetryPollingRequest(string pollingLink)
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
        /// <summary> Long running put request, service returns a 202 to the initial request with location header. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutNoHeaderInRetryHeaders>> PutNoHeaderInRetryPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreatePutNoHeaderInRetryPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutNoHeaderInRetryHeaders(message.Response);
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
        /// <summary> Long running put request, service returns a 202 to the initial request with location header. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Product, PutNoHeaderInRetryHeaders> PutNoHeaderInRetryPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreatePutNoHeaderInRetryPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutNoHeaderInRetryHeaders(message.Response);
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
        internal HttpMessage CreatePutAsyncRetrySucceededPollingRequest(string pollingLink)
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
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRetrySucceededHeaders>> PutAsyncRetrySucceededPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRetrySucceededPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRetrySucceededHeaders(message.Response);
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
        public ResponseWithHeaders<Product, PutAsyncRetrySucceededHeaders> PutAsyncRetrySucceededPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRetrySucceededPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRetrySucceededHeaders(message.Response);
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
        internal HttpMessage CreatePutAsyncNoRetrySucceededPollingRequest(string pollingLink)
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
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncNoRetrySucceededHeaders>> PutAsyncNoRetrySucceededPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNoRetrySucceededPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncNoRetrySucceededHeaders(message.Response);
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
        public ResponseWithHeaders<Product, PutAsyncNoRetrySucceededHeaders> PutAsyncNoRetrySucceededPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNoRetrySucceededPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncNoRetrySucceededHeaders(message.Response);
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
        internal HttpMessage CreatePutAsyncRetryFailedPollingRequest(string pollingLink)
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
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncRetryFailedHeaders>> PutAsyncRetryFailedPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncRetryFailed");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRetryFailedPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRetryFailedHeaders(message.Response);
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
        public ResponseWithHeaders<Product, PutAsyncRetryFailedHeaders> PutAsyncRetryFailedPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncRetryFailed");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncRetryFailedPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncRetryFailedHeaders(message.Response);
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
        internal HttpMessage CreatePutAsyncNoRetrycanceledPollingRequest(string pollingLink)
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
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncNoRetrycanceledHeaders>> PutAsyncNoRetrycanceledPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNoRetrycanceled");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNoRetrycanceledPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncNoRetrycanceledHeaders(message.Response);
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
        public ResponseWithHeaders<Product, PutAsyncNoRetrycanceledHeaders> PutAsyncNoRetrycanceledPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNoRetrycanceled");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNoRetrycanceledPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncNoRetrycanceledHeaders(message.Response);
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
        internal HttpMessage CreatePutAsyncNoHeaderInRetryPollingRequest(string pollingLink)
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
        /// <summary> Long running put request, service returns a 202 to the initial request with Azure-AsyncOperation header. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, PutAsyncNoHeaderInRetryHeaders>> PutAsyncNoHeaderInRetryPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNoHeaderInRetryPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncNoHeaderInRetryHeaders(message.Response);
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
        /// <summary> Long running put request, service returns a 202 to the initial request with Azure-AsyncOperation header. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Product, PutAsyncNoHeaderInRetryHeaders> PutAsyncNoHeaderInRetryPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNoHeaderInRetryPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new PutAsyncNoHeaderInRetryHeaders(message.Response);
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
        internal HttpMessage CreatePutNonResourcePollingRequest(string pollingLink)
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
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Sku>> PutNonResourcePollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutNonResource");
            scope.Start();
            try
            {
                using var message = CreatePutNonResourcePollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Sku.DeserializeSku(document.RootElement);
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
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Sku> PutNonResourcePolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutNonResource");
            scope.Start();
            try
            {
                using var message = CreatePutNonResourcePollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Sku.DeserializeSku(document.RootElement);
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
        internal HttpMessage CreatePutAsyncNonResourcePollingRequest(string pollingLink)
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
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Sku>> PutAsyncNonResourcePollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNonResource");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNonResourcePollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Sku.DeserializeSku(document.RootElement);
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
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Sku> PutAsyncNonResourcePolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncNonResource");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncNonResourcePollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Sku.DeserializeSku(document.RootElement);
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
        internal HttpMessage CreatePutSubResourcePollingRequest(string pollingLink)
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
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SubProduct>> PutSubResourcePollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutSubResource");
            scope.Start();
            try
            {
                using var message = CreatePutSubResourcePollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = SubProduct.DeserializeSubProduct(document.RootElement);
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
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SubProduct> PutSubResourcePolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutSubResource");
            scope.Start();
            try
            {
                using var message = CreatePutSubResourcePollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = SubProduct.DeserializeSubProduct(document.RootElement);
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
        internal HttpMessage CreatePutAsyncSubResourcePollingRequest(string pollingLink)
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
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SubProduct>> PutAsyncSubResourcePollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncSubResource");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncSubResourcePollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = SubProduct.DeserializeSubProduct(document.RootElement);
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
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SubProduct> PutAsyncSubResourcePolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PutAsyncSubResource");
            scope.Start();
            try
            {
                using var message = CreatePutAsyncSubResourcePollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = SubProduct.DeserializeSubProduct(document.RootElement);
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
        internal HttpMessage CreateDeleteProvisioning202Accepted200SucceededPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> DeleteProvisioning202Accepted200SucceededPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteProvisioning202Accepted200Succeeded");
            scope.Start();
            try
            {
                using var message = CreateDeleteProvisioning202Accepted200SucceededPollingRequest(pollingLink);
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
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> DeleteProvisioning202Accepted200SucceededPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteProvisioning202Accepted200Succeeded");
            scope.Start();
            try
            {
                using var message = CreateDeleteProvisioning202Accepted200SucceededPollingRequest(pollingLink);
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
        internal HttpMessage CreateDeleteProvisioning202DeletingFailed200PollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> DeleteProvisioning202DeletingFailed200PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteProvisioning202DeletingFailed200");
            scope.Start();
            try
            {
                using var message = CreateDeleteProvisioning202DeletingFailed200PollingRequest(pollingLink);
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
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> DeleteProvisioning202DeletingFailed200Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteProvisioning202DeletingFailed200");
            scope.Start();
            try
            {
                using var message = CreateDeleteProvisioning202DeletingFailed200PollingRequest(pollingLink);
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
        internal HttpMessage CreateDeleteProvisioning202Deletingcanceled200PollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> DeleteProvisioning202Deletingcanceled200PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteProvisioning202Deletingcanceled200");
            scope.Start();
            try
            {
                using var message = CreateDeleteProvisioning202Deletingcanceled200PollingRequest(pollingLink);
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
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> DeleteProvisioning202Deletingcanceled200Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteProvisioning202Deletingcanceled200");
            scope.Start();
            try
            {
                using var message = CreateDeleteProvisioning202Deletingcanceled200PollingRequest(pollingLink);
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
        /// <summary> Long running delete succeeds and returns right away. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete204SucceededPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Delete204Succeeded");
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
        /// <summary> Long running delete succeeds and returns right away. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete204SucceededPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Delete204Succeeded");
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
        internal HttpMessage CreateDelete202Retry200PollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Delete202Retry200PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Delete202Retry200");
            scope.Start();
            try
            {
                using var message = CreateDelete202Retry200PollingRequest(pollingLink);
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Delete202Retry200Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Delete202Retry200");
            scope.Start();
            try
            {
                using var message = CreateDelete202Retry200PollingRequest(pollingLink);
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
        internal HttpMessage CreateDelete202NoRetry204PollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> Delete202NoRetry204PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Delete202NoRetry204");
            scope.Start();
            try
            {
                using var message = CreateDelete202NoRetry204PollingRequest(pollingLink);
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> Delete202NoRetry204Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Delete202NoRetry204");
            scope.Start();
            try
            {
                using var message = CreateDelete202NoRetry204PollingRequest(pollingLink);
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
        internal HttpMessage CreateDeleteNoHeaderInRetryPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns a location header in the initial request. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteNoHeaderInRetryHeaders>> DeleteNoHeaderInRetryPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreateDeleteNoHeaderInRetryPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteNoHeaderInRetryHeaders(message.Response);
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
        /// <summary> Long running delete request, service returns a location header in the initial request. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteNoHeaderInRetryHeaders> DeleteNoHeaderInRetryPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreateDeleteNoHeaderInRetryPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteNoHeaderInRetryHeaders(message.Response);
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
        internal HttpMessage CreateDeleteAsyncNoHeaderInRetryPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running delete request, service returns an Azure-AsyncOperation header in the initial request. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteAsyncNoHeaderInRetryHeaders>> DeleteAsyncNoHeaderInRetryPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncNoHeaderInRetryPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncNoHeaderInRetryHeaders(message.Response);
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
        /// <summary> Long running delete request, service returns an Azure-AsyncOperation header in the initial request. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteAsyncNoHeaderInRetryHeaders> DeleteAsyncNoHeaderInRetryPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncNoHeaderInRetry");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncNoHeaderInRetryPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncNoHeaderInRetryHeaders(message.Response);
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
        internal HttpMessage CreateDeleteAsyncRetrySucceededPollingRequest(string pollingLink)
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
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRetrySucceededHeaders>> DeleteAsyncRetrySucceededPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRetrySucceededPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRetrySucceededHeaders(message.Response);
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
        public ResponseWithHeaders<DeleteAsyncRetrySucceededHeaders> DeleteAsyncRetrySucceededPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRetrySucceededPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRetrySucceededHeaders(message.Response);
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
        internal HttpMessage CreateDeleteAsyncNoRetrySucceededPollingRequest(string pollingLink)
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
        public async ValueTask<ResponseWithHeaders<DeleteAsyncNoRetrySucceededHeaders>> DeleteAsyncNoRetrySucceededPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncNoRetrySucceededPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncNoRetrySucceededHeaders(message.Response);
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
        public ResponseWithHeaders<DeleteAsyncNoRetrySucceededHeaders> DeleteAsyncNoRetrySucceededPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncNoRetrySucceededPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncNoRetrySucceededHeaders(message.Response);
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
        internal HttpMessage CreateDeleteAsyncRetryFailedPollingRequest(string pollingLink)
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
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRetryFailedHeaders>> DeleteAsyncRetryFailedPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncRetryFailed");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRetryFailedPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRetryFailedHeaders(message.Response);
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
        public ResponseWithHeaders<DeleteAsyncRetryFailedHeaders> DeleteAsyncRetryFailedPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncRetryFailed");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRetryFailedPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRetryFailedHeaders(message.Response);
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
        internal HttpMessage CreateDeleteAsyncRetrycanceledPollingRequest(string pollingLink)
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
        public async ValueTask<ResponseWithHeaders<DeleteAsyncRetrycanceledHeaders>> DeleteAsyncRetrycanceledPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncRetrycanceled");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRetrycanceledPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRetrycanceledHeaders(message.Response);
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
        public ResponseWithHeaders<DeleteAsyncRetrycanceledHeaders> DeleteAsyncRetrycanceledPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.DeleteAsyncRetrycanceled");
            scope.Start();
            try
            {
                using var message = CreateDeleteAsyncRetrycanceledPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new DeleteAsyncRetrycanceledHeaders(message.Response);
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
        internal HttpMessage CreatePost200WithPayloadPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header. Poll returns a 200 with a response body after success. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Sku>> Post200WithPayloadPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Post200WithPayload");
            scope.Start();
            try
            {
                using var message = CreatePost200WithPayloadPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Sku.DeserializeSku(document.RootElement);
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header. Poll returns a 200 with a response body after success. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Sku> Post200WithPayloadPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Post200WithPayload");
            scope.Start();
            try
            {
                using var message = CreatePost200WithPayloadPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Sku.DeserializeSku(document.RootElement);
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
        internal HttpMessage CreatePost202Retry200PollingRequest(string pollingLink)
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Post202Retry200Headers>> Post202Retry200PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Post202Retry200");
            scope.Start();
            try
            {
                using var message = CreatePost202Retry200PollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202Retry200Headers(message.Response);
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Post202Retry200Headers> Post202Retry200Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Post202Retry200");
            scope.Start();
            try
            {
                using var message = CreatePost202Retry200PollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new Post202Retry200Headers(message.Response);
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
        internal HttpMessage CreatePost202NoRetry204PollingRequest(string pollingLink)
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header, 204 with noresponse body after success. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<Product, Post202NoRetry204Headers>> Post202NoRetry204PollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Post202NoRetry204");
            scope.Start();
            try
            {
                using var message = CreatePost202NoRetry204PollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new Post202NoRetry204Headers(message.Response);
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header, 204 with noresponse body after success. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Product, Post202NoRetry204Headers> Post202NoRetry204Polling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.Post202NoRetry204");
            scope.Start();
            try
            {
                using var message = CreatePost202NoRetry204PollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Product.DeserializeProduct(document.RootElement);
                            var headers = new Post202NoRetry204Headers(message.Response);
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
        internal HttpMessage CreatePostDoubleHeadersFinalLocationGetPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should poll Location to get the final object. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PostDoubleHeadersFinalLocationGetPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostDoubleHeadersFinalLocationGet");
            scope.Start();
            try
            {
                using var message = CreatePostDoubleHeadersFinalLocationGetPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should poll Location to get the final object. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PostDoubleHeadersFinalLocationGetPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostDoubleHeadersFinalLocationGet");
            scope.Start();
            try
            {
                using var message = CreatePostDoubleHeadersFinalLocationGetPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreatePostDoubleHeadersFinalAzureHeaderGetPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PostDoubleHeadersFinalAzureHeaderGetPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostDoubleHeadersFinalAzureHeaderGet");
            scope.Start();
            try
            {
                using var message = CreatePostDoubleHeadersFinalAzureHeaderGetPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PostDoubleHeadersFinalAzureHeaderGetPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostDoubleHeadersFinalAzureHeaderGet");
            scope.Start();
            try
            {
                using var message = CreatePostDoubleHeadersFinalAzureHeaderGetPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreatePostDoubleHeadersFinalAzureHeaderGetDefaultPollingRequest(string pollingLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(pollingLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object if you support initial Autorest behavior. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PostDoubleHeadersFinalAzureHeaderGetDefaultPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostDoubleHeadersFinalAzureHeaderGetDefault");
            scope.Start();
            try
            {
                using var message = CreatePostDoubleHeadersFinalAzureHeaderGetDefaultPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object if you support initial Autorest behavior. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PostDoubleHeadersFinalAzureHeaderGetDefaultPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostDoubleHeadersFinalAzureHeaderGetDefault");
            scope.Start();
            try
            {
                using var message = CreatePostDoubleHeadersFinalAzureHeaderGetDefaultPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreatePostAsyncRetrySucceededPollingRequest(string pollingLink)
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
        public async ValueTask<Response<Product>> PostAsyncRetrySucceededPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRetrySucceededPollingRequest(pollingLink);
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PostAsyncRetrySucceededPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRetrySucceededPollingRequest(pollingLink);
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
        internal HttpMessage CreatePostAsyncNoRetrySucceededPollingRequest(string pollingLink)
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
        public async ValueTask<Response<Product>> PostAsyncNoRetrySucceededPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncNoRetrySucceededPollingRequest(pollingLink);
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="pollingLink"> The URL to poll for the final response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Product> PostAsyncNoRetrySucceededPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncNoRetrySucceeded");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncNoRetrySucceededPollingRequest(pollingLink);
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
        internal HttpMessage CreatePostAsyncRetryFailedPollingRequest(string pollingLink)
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
        public async ValueTask<ResponseWithHeaders<PostAsyncRetryFailedHeaders>> PostAsyncRetryFailedPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncRetryFailed");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRetryFailedPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRetryFailedHeaders(message.Response);
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
        public ResponseWithHeaders<PostAsyncRetryFailedHeaders> PostAsyncRetryFailedPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncRetryFailed");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRetryFailedPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRetryFailedHeaders(message.Response);
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
        internal HttpMessage CreatePostAsyncRetrycanceledPollingRequest(string pollingLink)
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
        public async ValueTask<ResponseWithHeaders<PostAsyncRetrycanceledHeaders>> PostAsyncRetrycanceledPollingAsync(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncRetrycanceled");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRetrycanceledPollingRequest(pollingLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRetrycanceledHeaders(message.Response);
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
        public ResponseWithHeaders<PostAsyncRetrycanceledHeaders> PostAsyncRetrycanceledPolling(string pollingLink, CancellationToken cancellationToken = default)
        {
            if (pollingLink == null)
            {
                throw new ArgumentNullException(nameof(pollingLink));
            }

            using var scope = clientDiagnostics.CreateScope("LROsOperations.PostAsyncRetrycanceled");
            scope.Start();
            try
            {
                using var message = CreatePostAsyncRetrycanceledPollingRequest(pollingLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new PostAsyncRetrycanceledHeaders(message.Response);
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
