// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using validation.Models.V100;

namespace validation
{
    internal partial class AllOperations
    {
        private string subscriptionId;
        private string host;
        private string ApiVersion;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of AllOperations. </summary>
        public AllOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, string host = "http://localhost:3000", string ApiVersion = "1.0.0")
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (ApiVersion == null)
            {
                throw new ArgumentNullException(nameof(ApiVersion));
            }

            this.subscriptionId = subscriptionId;
            this.host = host;
            this.ApiVersion = ApiVersion;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Validates input parameters on the method. See swagger for details. </summary>
        /// <param name="resourceGroupName"> Required string between 3 and 10 chars with pattern [a-zA-Z0-9]+. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="id"> Required int multiple of 10 from 100 to 1000. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> ValidationOfMethodParametersAsync(string resourceGroupName, int id, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }

            using var scope = clientDiagnostics.CreateScope("validation.ValidationOfMethodParameters");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/fakepath/", false);
                request.Uri.AppendPath(subscriptionId, true);
                request.Uri.AppendPath("/", false);
                request.Uri.AppendPath(resourceGroupName, true);
                request.Uri.AppendPath("/", false);
                request.Uri.AppendPath(id, true);
                request.Uri.AppendQuery("apiVersion", ApiVersion, true);
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
        /// <summary> Validates body parameters on the method. See swagger for details. </summary>
        /// <param name="resourceGroupName"> Required string between 3 and 10 chars with pattern [a-zA-Z0-9]+. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="id"> Required int multiple of 10 from 100 to 1000. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> ValidationOfBodyAsync(string resourceGroupName, int id, Product? body, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }

            using var scope = clientDiagnostics.CreateScope("validation.ValidationOfBody");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/fakepath/", false);
                request.Uri.AppendPath(subscriptionId, true);
                request.Uri.AppendPath("/", false);
                request.Uri.AppendPath(resourceGroupName, true);
                request.Uri.AppendPath("/", false);
                request.Uri.AppendPath(id, true);
                request.Headers.Add("Content-Type", "application/json");
                request.Uri.AppendQuery("apiVersion", ApiVersion, true);
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(body);
                request.Content = content;
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
        /// <summary> MISSING·OPERATION-DESCRIPTION. </summary>
        public async ValueTask<Response> GetWithConstantInPathAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("validation.GetWithConstantInPath");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/validation/constantsInPath/", false);
                request.Uri.AppendPath("constant", true);
                request.Uri.AppendPath("/value", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> MISSING·OPERATION-DESCRIPTION. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Product>> PostWithConstantInBodyAsync(Product? body, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("validation.PostWithConstantInBody");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/validation/constantsInPath/", false);
                request.Uri.AppendPath("constant", true);
                request.Uri.AppendPath("/value", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(body);
                request.Content = content;
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
    }
}
