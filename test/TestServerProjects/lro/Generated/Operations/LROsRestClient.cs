// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using lro.Models;

namespace lro
{
    internal partial class LROsRestClient
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of LROsRestClient. </summary>
        public LROsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Put200Succeeded");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Put200Succeeded");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Put200SucceededNoState");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Put200SucceededNoState");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Put202Retry200");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Put202Retry200");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Put201CreatingSucceeded200");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Put201CreatingSucceeded200");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Put200UpdatingSucceeded204");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Put200UpdatingSucceeded204");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Put201CreatingFailed200");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Put201CreatingFailed200");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Put200Acceptedcanceled200");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Put200Acceptedcanceled200");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutNoHeaderInRetry");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutNoHeaderInRetry");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutAsyncRetrySucceeded");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutAsyncRetrySucceeded");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutAsyncNoRetrySucceeded");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutAsyncNoRetrySucceeded");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutAsyncRetryFailed");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutAsyncRetryFailed");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutAsyncNoRetrycanceled");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutAsyncNoRetrycanceled");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutAsyncNoHeaderInRetry");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutAsyncNoHeaderInRetry");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutNonResource");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutNonResource");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutAsyncNonResource");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutAsyncNonResource");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutSubResource");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutSubResource");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutAsyncSubResource");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PutAsyncSubResource");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteProvisioning202Accepted200Succeeded");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteProvisioning202Accepted200Succeeded");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteProvisioning202DeletingFailed200");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteProvisioning202DeletingFailed200");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteProvisioning202Deletingcanceled200");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteProvisioning202Deletingcanceled200");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.Delete204Succeeded");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.Delete204Succeeded");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.Delete202Retry200");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.Delete202Retry200");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.Delete202NoRetry204");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.Delete202NoRetry204");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteNoHeaderInRetry");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteNoHeaderInRetry");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteAsyncNoHeaderInRetry");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteAsyncNoHeaderInRetry");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteAsyncRetrySucceeded");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteAsyncRetrySucceeded");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteAsyncNoRetrySucceeded");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteAsyncNoRetrySucceeded");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteAsyncRetryFailed");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteAsyncRetryFailed");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteAsyncRetrycanceled");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.DeleteAsyncRetrycanceled");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.Post200WithPayload");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.Post200WithPayload");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Post202Retry200");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Post202Retry200");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Post202NoRetry204");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.Post202NoRetry204");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.PostDoubleHeadersFinalLocationGet");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.PostDoubleHeadersFinalLocationGet");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.PostDoubleHeadersFinalAzureHeaderGet");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.PostDoubleHeadersFinalAzureHeaderGet");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.PostDoubleHeadersFinalAzureHeaderGetDefault");
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
            using var scope = clientDiagnostics.CreateScope("LROsClient.PostDoubleHeadersFinalAzureHeaderGetDefault");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PostAsyncRetrySucceeded");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PostAsyncRetrySucceeded");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PostAsyncNoRetrySucceeded");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PostAsyncNoRetrySucceeded");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PostAsyncRetryFailed");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PostAsyncRetryFailed");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PostAsyncRetrycanceled");
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

            using var scope = clientDiagnostics.CreateScope("LROsClient.PostAsyncRetrycanceled");
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
    }
}
