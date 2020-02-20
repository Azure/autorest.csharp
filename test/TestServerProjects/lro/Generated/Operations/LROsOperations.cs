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
        public async ValueTask<Response> Put200SucceededAsync(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put200Succeeded(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> Put200SucceededNoStateAsync(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that does not contain ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put200SucceededNoState(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> Put202Retry200Async(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request, service returns a 202 to the initial request, with a location header that points to a polling URL that returns a 200 and an entity that doesn&apos;t contains ProvisioningState. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put202Retry200(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> Put201CreatingSucceeded200Async(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put201CreatingSucceeded200(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> Put200UpdatingSucceeded204Async(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Updating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put200UpdatingSucceeded204(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> Put201CreatingFailed200Async(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Created’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put201CreatingFailed200(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> Put200Acceptedcanceled200Async(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put200Acceptedcanceled200(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PutNoHeaderInRetryAsync(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request, service returns a 202 to the initial request with location header. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNoHeaderInRetry(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PutAsyncRetrySucceededAsync(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutAsyncRetrySucceeded(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PutAsyncNoRetrySucceededAsync(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutAsyncNoRetrySucceeded(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PutAsyncRetryFailedAsync(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutAsyncRetryFailed(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PutAsyncNoRetrycanceledAsync(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutAsyncNoRetrycanceled(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PutAsyncNoHeaderInRetryAsync(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request, service returns a 202 to the initial request with Azure-AsyncOperation header. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutAsyncNoHeaderInRetry(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PutNonResourceAsync(Sku sku, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNonResource(Sku sku, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PutAsyncNonResourceAsync(Sku sku, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutAsyncNonResource(Sku sku, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PutSubResourceAsync(SubProduct product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutSubResource(SubProduct product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PutAsyncSubResourceAsync(SubProduct product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutAsyncSubResource(SubProduct product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> DeleteProvisioning202Accepted200SucceededAsync(CancellationToken cancellationToken = default)
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
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DeleteProvisioning202Accepted200Succeeded(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> DeleteProvisioning202DeletingFailed200Async(CancellationToken cancellationToken = default)
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
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DeleteProvisioning202DeletingFailed200(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> DeleteProvisioning202Deletingcanceled200Async(CancellationToken cancellationToken = default)
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
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DeleteProvisioning202Deletingcanceled200(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> Delete202Retry200Async(CancellationToken cancellationToken = default)
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete202Retry200(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> Delete202NoRetry204Async(CancellationToken cancellationToken = default)
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete202NoRetry204(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> DeleteNoHeaderInRetryAsync(CancellationToken cancellationToken = default)
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
        /// <summary> Long running delete request, service returns a location header in the initial request. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DeleteNoHeaderInRetry(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> DeleteAsyncNoHeaderInRetryAsync(CancellationToken cancellationToken = default)
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
        /// <summary> Long running delete request, service returns an Azure-AsyncOperation header in the initial request. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DeleteAsyncNoHeaderInRetry(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> DeleteAsyncRetrySucceededAsync(CancellationToken cancellationToken = default)
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DeleteAsyncRetrySucceeded(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> DeleteAsyncNoRetrySucceededAsync(CancellationToken cancellationToken = default)
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DeleteAsyncNoRetrySucceeded(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> DeleteAsyncRetryFailedAsync(CancellationToken cancellationToken = default)
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DeleteAsyncRetryFailed(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> DeleteAsyncRetrycanceledAsync(CancellationToken cancellationToken = default)
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
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DeleteAsyncRetrycanceled(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> Post200WithPayloadAsync(CancellationToken cancellationToken = default)
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header. Poll returns a 200 with a response body after success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post200WithPayload(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> Post202Retry200Async(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post202Retry200(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> Post202NoRetry204Async(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header, 204 with noresponse body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post202NoRetry204(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PostDoubleHeadersFinalLocationGetAsync(CancellationToken cancellationToken = default)
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
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostDoubleHeadersFinalLocationGet(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PostDoubleHeadersFinalAzureHeaderGetAsync(CancellationToken cancellationToken = default)
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
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostDoubleHeadersFinalAzureHeaderGet(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PostDoubleHeadersFinalAzureHeaderGetDefaultAsync(CancellationToken cancellationToken = default)
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
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object if you support initial Autorest behavior. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostDoubleHeadersFinalAzureHeaderGetDefault(CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PostAsyncRetrySucceededAsync(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostAsyncRetrySucceeded(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PostAsyncNoRetrySucceededAsync(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostAsyncNoRetrySucceeded(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PostAsyncRetryFailedAsync(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostAsyncRetryFailed(Product product, CancellationToken cancellationToken = default)
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
        public async ValueTask<Response> PostAsyncRetrycanceledAsync(Product product, CancellationToken cancellationToken = default)
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
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostAsyncRetrycanceled(Product product, CancellationToken cancellationToken = default)
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.Put200Succeeded", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut200SucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await Put200SucceededAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePut200SucceededOperation(originalResponse, () => CreatePut200SucceededRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut200SucceededOperation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = Put200Succeeded(product, cancellationToken);
            return CreatePut200SucceededOperation(originalResponse, () => CreatePut200SucceededRequest(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.Put200SucceededNoState", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that does not contain ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut200SucceededNoStateOperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await Put200SucceededNoStateAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePut200SucceededNoStateOperation(originalResponse, () => CreatePut200SucceededNoStateRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that does not contain ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut200SucceededNoStateOperation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = Put200SucceededNoState(product, cancellationToken);
            return CreatePut200SucceededNoStateOperation(originalResponse, () => CreatePut200SucceededNoStateRequest(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.Put202Retry200", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request, service returns a 202 to the initial request, with a location header that points to a polling URL that returns a 200 and an entity that doesn&apos;t contains ProvisioningState. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut202Retry200OperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await Put202Retry200Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePut202Retry200Operation(originalResponse, () => CreatePut202Retry200Request(product));
        }
        /// <summary> Long running put request, service returns a 202 to the initial request, with a location header that points to a polling URL that returns a 200 and an entity that doesn&apos;t contains ProvisioningState. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut202Retry200Operation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = Put202Retry200(product, cancellationToken);
            return CreatePut202Retry200Operation(originalResponse, () => CreatePut202Retry200Request(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.Put201CreatingSucceeded200", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut201CreatingSucceeded200OperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await Put201CreatingSucceeded200Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePut201CreatingSucceeded200Operation(originalResponse, () => CreatePut201CreatingSucceeded200Request(product));
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut201CreatingSucceeded200Operation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = Put201CreatingSucceeded200(product, cancellationToken);
            return CreatePut201CreatingSucceeded200Operation(originalResponse, () => CreatePut201CreatingSucceeded200Request(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.Put200UpdatingSucceeded204", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Updating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut200UpdatingSucceeded204OperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await Put200UpdatingSucceeded204Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePut200UpdatingSucceeded204Operation(originalResponse, () => CreatePut200UpdatingSucceeded204Request(product));
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Updating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut200UpdatingSucceeded204Operation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = Put200UpdatingSucceeded204(product, cancellationToken);
            return CreatePut200UpdatingSucceeded204Operation(originalResponse, () => CreatePut200UpdatingSucceeded204Request(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.Put201CreatingFailed200", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Created’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut201CreatingFailed200OperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await Put201CreatingFailed200Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePut201CreatingFailed200Operation(originalResponse, () => CreatePut201CreatingFailed200Request(product));
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Created’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut201CreatingFailed200Operation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = Put201CreatingFailed200(product, cancellationToken);
            return CreatePut201CreatingFailed200Operation(originalResponse, () => CreatePut201CreatingFailed200Request(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.Put200Acceptedcanceled200", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPut200Acceptedcanceled200OperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await Put200Acceptedcanceled200Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePut200Acceptedcanceled200Operation(originalResponse, () => CreatePut200Acceptedcanceled200Request(product));
        }
        /// <summary> Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPut200Acceptedcanceled200Operation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = Put200Acceptedcanceled200(product, cancellationToken);
            return CreatePut200Acceptedcanceled200Operation(originalResponse, () => CreatePut200Acceptedcanceled200Request(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.PutNoHeaderInRetry", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request, service returns a 202 to the initial request with location header. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutNoHeaderInRetryOperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await PutNoHeaderInRetryAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutNoHeaderInRetryOperation(originalResponse, () => CreatePutNoHeaderInRetryRequest(product));
        }
        /// <summary> Long running put request, service returns a 202 to the initial request with location header. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutNoHeaderInRetryOperation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = PutNoHeaderInRetry(product, cancellationToken);
            return CreatePutNoHeaderInRetryOperation(originalResponse, () => CreatePutNoHeaderInRetryRequest(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.PutAsyncRetrySucceeded", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutAsyncRetrySucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await PutAsyncRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncRetrySucceededOperation(originalResponse, () => CreatePutAsyncRetrySucceededRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncRetrySucceededOperation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = PutAsyncRetrySucceeded(product, cancellationToken);
            return CreatePutAsyncRetrySucceededOperation(originalResponse, () => CreatePutAsyncRetrySucceededRequest(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.PutAsyncNoRetrySucceeded", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutAsyncNoRetrySucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await PutAsyncNoRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncNoRetrySucceededOperation(originalResponse, () => CreatePutAsyncNoRetrySucceededRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncNoRetrySucceededOperation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = PutAsyncNoRetrySucceeded(product, cancellationToken);
            return CreatePutAsyncNoRetrySucceededOperation(originalResponse, () => CreatePutAsyncNoRetrySucceededRequest(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.PutAsyncRetryFailed", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutAsyncRetryFailedOperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await PutAsyncRetryFailedAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncRetryFailedOperation(originalResponse, () => CreatePutAsyncRetryFailedRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncRetryFailedOperation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = PutAsyncRetryFailed(product, cancellationToken);
            return CreatePutAsyncRetryFailedOperation(originalResponse, () => CreatePutAsyncRetryFailedRequest(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.PutAsyncNoRetrycanceled", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutAsyncNoRetrycanceledOperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await PutAsyncNoRetrycanceledAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncNoRetrycanceledOperation(originalResponse, () => CreatePutAsyncNoRetrycanceledRequest(product));
        }
        /// <summary> Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncNoRetrycanceledOperation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = PutAsyncNoRetrycanceled(product, cancellationToken);
            return CreatePutAsyncNoRetrycanceledOperation(originalResponse, () => CreatePutAsyncNoRetrycanceledRequest(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.PutAsyncNoHeaderInRetry", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request, service returns a 202 to the initial request with Azure-AsyncOperation header. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPutAsyncNoHeaderInRetryOperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await PutAsyncNoHeaderInRetryAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncNoHeaderInRetryOperation(originalResponse, () => CreatePutAsyncNoHeaderInRetryRequest(product));
        }
        /// <summary> Long running put request, service returns a 202 to the initial request with Azure-AsyncOperation header. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPutAsyncNoHeaderInRetryOperation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = PutAsyncNoHeaderInRetry(product, cancellationToken);
            return CreatePutAsyncNoHeaderInRetryOperation(originalResponse, () => CreatePutAsyncNoHeaderInRetryRequest(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.PutNonResource", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Sku.DeserializeSku(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Sku.DeserializeSku(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Sku>> StartPutNonResourceOperationAsync(Sku sku, CancellationToken cancellationToken = default)
        {
            var originalResponse = await PutNonResourceAsync(sku, cancellationToken).ConfigureAwait(false);
            return CreatePutNonResourceOperation(originalResponse, () => CreatePutNonResourceRequest(sku));
        }
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Sku> StartPutNonResourceOperation(Sku sku, CancellationToken cancellationToken = default)
        {
            var originalResponse = PutNonResource(sku, cancellationToken);
            return CreatePutNonResourceOperation(originalResponse, () => CreatePutNonResourceRequest(sku));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.PutAsyncNonResource", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Sku.DeserializeSku(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Sku.DeserializeSku(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Sku>> StartPutAsyncNonResourceOperationAsync(Sku sku, CancellationToken cancellationToken = default)
        {
            var originalResponse = await PutAsyncNonResourceAsync(sku, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncNonResourceOperation(originalResponse, () => CreatePutAsyncNonResourceRequest(sku));
        }
        /// <summary> Long running put request with non resource. </summary>
        /// <param name="sku"> sku to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Sku> StartPutAsyncNonResourceOperation(Sku sku, CancellationToken cancellationToken = default)
        {
            var originalResponse = PutAsyncNonResource(sku, cancellationToken);
            return CreatePutAsyncNonResourceOperation(originalResponse, () => CreatePutAsyncNonResourceRequest(sku));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.PutSubResource", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = SubProduct.DeserializeSubProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = SubProduct.DeserializeSubProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<SubProduct>> StartPutSubResourceOperationAsync(SubProduct product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await PutSubResourceAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutSubResourceOperation(originalResponse, () => CreatePutSubResourceRequest(product));
        }
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<SubProduct> StartPutSubResourceOperation(SubProduct product, CancellationToken cancellationToken = default)
        {
            var originalResponse = PutSubResource(product, cancellationToken);
            return CreatePutSubResourceOperation(originalResponse, () => CreatePutSubResourceRequest(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "LROsOperations.PutAsyncSubResource", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = SubProduct.DeserializeSubProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = SubProduct.DeserializeSubProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<SubProduct>> StartPutAsyncSubResourceOperationAsync(SubProduct product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await PutAsyncSubResourceAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePutAsyncSubResourceOperation(originalResponse, () => CreatePutAsyncSubResourceRequest(product));
        }
        /// <summary> Long running put request with sub resource. </summary>
        /// <param name="product"> Sub Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<SubProduct> StartPutAsyncSubResourceOperation(SubProduct product, CancellationToken cancellationToken = default)
        {
            var originalResponse = PutAsyncSubResource(product, cancellationToken);
            return CreatePutAsyncSubResourceOperation(originalResponse, () => CreatePutAsyncSubResourceRequest(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsOperations.DeleteProvisioning202Accepted200Succeeded", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartDeleteProvisioning202Accepted200SucceededOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await DeleteProvisioning202Accepted200SucceededAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteProvisioning202Accepted200SucceededOperation(originalResponse, () => CreateDeleteProvisioning202Accepted200SucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartDeleteProvisioning202Accepted200SucceededOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = DeleteProvisioning202Accepted200Succeeded(cancellationToken);
            return CreateDeleteProvisioning202Accepted200SucceededOperation(originalResponse, () => CreateDeleteProvisioning202Accepted200SucceededRequest());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsOperations.DeleteProvisioning202DeletingFailed200", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartDeleteProvisioning202DeletingFailed200OperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await DeleteProvisioning202DeletingFailed200Async(cancellationToken).ConfigureAwait(false);
            return CreateDeleteProvisioning202DeletingFailed200Operation(originalResponse, () => CreateDeleteProvisioning202DeletingFailed200Request());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Failed’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartDeleteProvisioning202DeletingFailed200Operation(CancellationToken cancellationToken = default)
        {
            var originalResponse = DeleteProvisioning202DeletingFailed200(cancellationToken);
            return CreateDeleteProvisioning202DeletingFailed200Operation(originalResponse, () => CreateDeleteProvisioning202DeletingFailed200Request());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsOperations.DeleteProvisioning202Deletingcanceled200", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartDeleteProvisioning202Deletingcanceled200OperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await DeleteProvisioning202Deletingcanceled200Async(cancellationToken).ConfigureAwait(false);
            return CreateDeleteProvisioning202Deletingcanceled200Operation(originalResponse, () => CreateDeleteProvisioning202Deletingcanceled200Request());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Canceled’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartDeleteProvisioning202Deletingcanceled200Operation(CancellationToken cancellationToken = default)
        {
            var originalResponse = DeleteProvisioning202Deletingcanceled200(cancellationToken);
            return CreateDeleteProvisioning202Deletingcanceled200Operation(originalResponse, () => CreateDeleteProvisioning202Deletingcanceled200Request());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsOperations.Delete204Succeeded", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                return Response.FromValue(r, r);
            },
            async (r, c) =>
            {
                await Task.CompletedTask;
                return Response.FromValue(r, r);
            });
        }
        /// <summary> Long running delete succeeds and returns right away. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDelete204SucceededOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await Delete204SucceededAsync(cancellationToken).ConfigureAwait(false);
            return CreateDelete204SucceededOperation(originalResponse, () => CreateDelete204SucceededRequest());
        }
        /// <summary> Long running delete succeeds and returns right away. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDelete204SucceededOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = Delete204Succeeded(cancellationToken);
            return CreateDelete204SucceededOperation(originalResponse, () => CreateDelete204SucceededRequest());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsOperations.Delete202Retry200", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartDelete202Retry200OperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await Delete202Retry200Async(cancellationToken).ConfigureAwait(false);
            return CreateDelete202Retry200Operation(originalResponse, () => CreateDelete202Retry200Request());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartDelete202Retry200Operation(CancellationToken cancellationToken = default)
        {
            var originalResponse = Delete202Retry200(cancellationToken);
            return CreateDelete202Retry200Operation(originalResponse, () => CreateDelete202Retry200Request());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsOperations.Delete202NoRetry204", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartDelete202NoRetry204OperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await Delete202NoRetry204Async(cancellationToken).ConfigureAwait(false);
            return CreateDelete202NoRetry204Operation(originalResponse, () => CreateDelete202NoRetry204Request());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartDelete202NoRetry204Operation(CancellationToken cancellationToken = default)
        {
            var originalResponse = Delete202NoRetry204(cancellationToken);
            return CreateDelete202NoRetry204Operation(originalResponse, () => CreateDelete202NoRetry204Request());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsOperations.DeleteNoHeaderInRetry", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                return Response.FromValue(r, r);
            },
            async (r, c) =>
            {
                await Task.CompletedTask;
                return Response.FromValue(r, r);
            });
        }
        /// <summary> Long running delete request, service returns a location header in the initial request. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteNoHeaderInRetryOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await DeleteNoHeaderInRetryAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteNoHeaderInRetryOperation(originalResponse, () => CreateDeleteNoHeaderInRetryRequest());
        }
        /// <summary> Long running delete request, service returns a location header in the initial request. Subsequent calls to operation status do not contain location header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteNoHeaderInRetryOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = DeleteNoHeaderInRetry(cancellationToken);
            return CreateDeleteNoHeaderInRetryOperation(originalResponse, () => CreateDeleteNoHeaderInRetryRequest());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsOperations.DeleteAsyncNoHeaderInRetry", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                return Response.FromValue(r, r);
            },
            async (r, c) =>
            {
                await Task.CompletedTask;
                return Response.FromValue(r, r);
            });
        }
        /// <summary> Long running delete request, service returns an Azure-AsyncOperation header in the initial request. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteAsyncNoHeaderInRetryOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await DeleteAsyncNoHeaderInRetryAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncNoHeaderInRetryOperation(originalResponse, () => CreateDeleteAsyncNoHeaderInRetryRequest());
        }
        /// <summary> Long running delete request, service returns an Azure-AsyncOperation header in the initial request. Subsequent calls to operation status do not contain Azure-AsyncOperation header. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncNoHeaderInRetryOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = DeleteAsyncNoHeaderInRetry(cancellationToken);
            return CreateDeleteAsyncNoHeaderInRetryOperation(originalResponse, () => CreateDeleteAsyncNoHeaderInRetryRequest());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsOperations.DeleteAsyncRetrySucceeded", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                return Response.FromValue(r, r);
            },
            async (r, c) =>
            {
                await Task.CompletedTask;
                return Response.FromValue(r, r);
            });
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteAsyncRetrySucceededOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await DeleteAsyncRetrySucceededAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncRetrySucceededOperation(originalResponse, () => CreateDeleteAsyncRetrySucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncRetrySucceededOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = DeleteAsyncRetrySucceeded(cancellationToken);
            return CreateDeleteAsyncRetrySucceededOperation(originalResponse, () => CreateDeleteAsyncRetrySucceededRequest());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsOperations.DeleteAsyncNoRetrySucceeded", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                return Response.FromValue(r, r);
            },
            async (r, c) =>
            {
                await Task.CompletedTask;
                return Response.FromValue(r, r);
            });
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteAsyncNoRetrySucceededOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await DeleteAsyncNoRetrySucceededAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncNoRetrySucceededOperation(originalResponse, () => CreateDeleteAsyncNoRetrySucceededRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncNoRetrySucceededOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = DeleteAsyncNoRetrySucceeded(cancellationToken);
            return CreateDeleteAsyncNoRetrySucceededOperation(originalResponse, () => CreateDeleteAsyncNoRetrySucceededRequest());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsOperations.DeleteAsyncRetryFailed", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                return Response.FromValue(r, r);
            },
            async (r, c) =>
            {
                await Task.CompletedTask;
                return Response.FromValue(r, r);
            });
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteAsyncRetryFailedOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await DeleteAsyncRetryFailedAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncRetryFailedOperation(originalResponse, () => CreateDeleteAsyncRetryFailedRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncRetryFailedOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = DeleteAsyncRetryFailed(cancellationToken);
            return CreateDeleteAsyncRetryFailedOperation(originalResponse, () => CreateDeleteAsyncRetryFailedRequest());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Delete, "LROsOperations.DeleteAsyncRetrycanceled", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                return Response.FromValue(r, r);
            },
            async (r, c) =>
            {
                await Task.CompletedTask;
                return Response.FromValue(r, r);
            });
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartDeleteAsyncRetrycanceledOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await DeleteAsyncRetrycanceledAsync(cancellationToken).ConfigureAwait(false);
            return CreateDeleteAsyncRetrycanceledOperation(originalResponse, () => CreateDeleteAsyncRetrycanceledRequest());
        }
        /// <summary> Long running delete request, service returns a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartDeleteAsyncRetrycanceledOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = DeleteAsyncRetrycanceled(cancellationToken);
            return CreateDeleteAsyncRetrycanceledOperation(originalResponse, () => CreateDeleteAsyncRetrycanceledRequest());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsOperations.Post200WithPayload", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Sku.DeserializeSku(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Sku.DeserializeSku(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header. Poll returns a 200 with a response body after success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Sku>> StartPost200WithPayloadOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await Post200WithPayloadAsync(cancellationToken).ConfigureAwait(false);
            return CreatePost200WithPayloadOperation(originalResponse, () => CreatePost200WithPayloadRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header. Poll returns a 200 with a response body after success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Sku> StartPost200WithPayloadOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = Post200WithPayload(cancellationToken);
            return CreatePost200WithPayloadOperation(originalResponse, () => CreatePost200WithPayloadRequest());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsOperations.Post202Retry200", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                return Response.FromValue(r, r);
            },
            async (r, c) =>
            {
                await Task.CompletedTask;
                return Response.FromValue(r, r);
            });
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPost202Retry200OperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await Post202Retry200Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePost202Retry200Operation(originalResponse, () => CreatePost202Retry200Request(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPost202Retry200Operation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = Post202Retry200(product, cancellationToken);
            return CreatePost202Retry200Operation(originalResponse, () => CreatePost202Retry200Request(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsOperations.Post202NoRetry204", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header, 204 with noresponse body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPost202NoRetry204OperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await Post202NoRetry204Async(product, cancellationToken).ConfigureAwait(false);
            return CreatePost202NoRetry204Operation(originalResponse, () => CreatePost202NoRetry204Request(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; header, 204 with noresponse body after success. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPost202NoRetry204Operation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = Post202NoRetry204(product, cancellationToken);
            return CreatePost202NoRetry204Operation(originalResponse, () => CreatePost202NoRetry204Request(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsOperations.PostDoubleHeadersFinalLocationGet", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPostDoubleHeadersFinalLocationGetOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await PostDoubleHeadersFinalLocationGetAsync(cancellationToken).ConfigureAwait(false);
            return CreatePostDoubleHeadersFinalLocationGetOperation(originalResponse, () => CreatePostDoubleHeadersFinalLocationGetRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPostDoubleHeadersFinalLocationGetOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = PostDoubleHeadersFinalLocationGet(cancellationToken);
            return CreatePostDoubleHeadersFinalLocationGetOperation(originalResponse, () => CreatePostDoubleHeadersFinalLocationGetRequest());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsOperations.PostDoubleHeadersFinalAzureHeaderGet", FinalStateVia.AzureAsyncOperation, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPostDoubleHeadersFinalAzureHeaderGetOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await PostDoubleHeadersFinalAzureHeaderGetAsync(cancellationToken).ConfigureAwait(false);
            return CreatePostDoubleHeadersFinalAzureHeaderGetOperation(originalResponse, () => CreatePostDoubleHeadersFinalAzureHeaderGetRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPostDoubleHeadersFinalAzureHeaderGetOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = PostDoubleHeadersFinalAzureHeaderGet(cancellationToken);
            return CreatePostDoubleHeadersFinalAzureHeaderGetOperation(originalResponse, () => CreatePostDoubleHeadersFinalAzureHeaderGetRequest());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsOperations.PostDoubleHeadersFinalAzureHeaderGetDefault", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object if you support initial Autorest behavior. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPostDoubleHeadersFinalAzureHeaderGetDefaultOperationAsync(CancellationToken cancellationToken = default)
        {
            var originalResponse = await PostDoubleHeadersFinalAzureHeaderGetDefaultAsync(cancellationToken).ConfigureAwait(false);
            return CreatePostDoubleHeadersFinalAzureHeaderGetDefaultOperation(originalResponse, () => CreatePostDoubleHeadersFinalAzureHeaderGetDefaultRequest());
        }
        /// <summary> Long running post request, service returns a 202 to the initial request with both Location and Azure-Async header. Poll Azure-Async and it&apos;s success. Should NOT poll Location to get the final object if you support initial Autorest behavior. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPostDoubleHeadersFinalAzureHeaderGetDefaultOperation(CancellationToken cancellationToken = default)
        {
            var originalResponse = PostDoubleHeadersFinalAzureHeaderGetDefault(cancellationToken);
            return CreatePostDoubleHeadersFinalAzureHeaderGetDefaultOperation(originalResponse, () => CreatePostDoubleHeadersFinalAzureHeaderGetDefaultRequest());
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsOperations.PostAsyncRetrySucceeded", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPostAsyncRetrySucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await PostAsyncRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePostAsyncRetrySucceededOperation(originalResponse, () => CreatePostAsyncRetrySucceededRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPostAsyncRetrySucceededOperation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = PostAsyncRetrySucceeded(product, cancellationToken);
            return CreatePostAsyncRetrySucceededOperation(originalResponse, () => CreatePostAsyncRetrySucceededRequest(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsOperations.PostAsyncNoRetrySucceeded", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                using var document = JsonDocument.Parse(r.ContentStream);
                var value = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value, r);
            },
            async (r, c) =>
            {
                using var document = await JsonDocument.ParseAsync(r.ContentStream, default, c).ConfigureAwait(false);
                var value0 = Product.DeserializeProduct(document.RootElement);
                return Response.FromValue(value0, r);
            });
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Product>> StartPostAsyncNoRetrySucceededOperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await PostAsyncNoRetrySucceededAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePostAsyncNoRetrySucceededOperation(originalResponse, () => CreatePostAsyncNoRetrySucceededRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Product> StartPostAsyncNoRetrySucceededOperation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = PostAsyncNoRetrySucceeded(product, cancellationToken);
            return CreatePostAsyncNoRetrySucceededOperation(originalResponse, () => CreatePostAsyncNoRetrySucceededRequest(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsOperations.PostAsyncRetryFailed", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                return Response.FromValue(r, r);
            },
            async (r, c) =>
            {
                await Task.CompletedTask;
                return Response.FromValue(r, r);
            });
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPostAsyncRetryFailedOperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await PostAsyncRetryFailedAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePostAsyncRetryFailedOperation(originalResponse, () => CreatePostAsyncRetryFailedRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPostAsyncRetryFailedOperation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = PostAsyncRetryFailed(product, cancellationToken);
            return CreatePostAsyncRetryFailedOperation(originalResponse, () => CreatePostAsyncRetryFailedRequest(product));
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

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "LROsOperations.PostAsyncRetrycanceled", FinalStateVia.Location, createOriginalHttpMessage,
            (r, c) =>
            {
                return Response.FromValue(r, r);
            },
            async (r, c) =>
            {
                await Task.CompletedTask;
                return Response.FromValue(r, r);
            });
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Operation<Response>> StartPostAsyncRetrycanceledOperationAsync(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = await PostAsyncRetrycanceledAsync(product, cancellationToken).ConfigureAwait(false);
            return CreatePostAsyncRetrycanceledOperation(originalResponse, () => CreatePostAsyncRetrycanceledRequest(product));
        }
        /// <summary> Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="product"> Product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Operation<Response> StartPostAsyncRetrycanceledOperation(Product product, CancellationToken cancellationToken = default)
        {
            var originalResponse = PostAsyncRetrycanceled(product, cancellationToken);
            return CreatePostAsyncRetrycanceledOperation(originalResponse, () => CreatePostAsyncRetrycanceledRequest(product));
        }
    }
}
