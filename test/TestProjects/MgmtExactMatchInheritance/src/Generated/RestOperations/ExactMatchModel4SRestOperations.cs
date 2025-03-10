// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using MgmtExactMatchInheritance.Models;

namespace MgmtExactMatchInheritance
{
    internal partial class ExactMatchModel4SRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of ExactMatchModel4SRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public ExactMatchModel4SRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-06-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal RequestUriBuilder CreatePutRequestUri(string subscriptionId, string resourceGroupName, string exactMatchModel4SName, ExactMatchModel4 exactMatchModel4)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/exactMatchModel4s/", false);
            uri.AppendPath(exactMatchModel4SName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreatePutRequest(string subscriptionId, string resourceGroupName, string exactMatchModel4SName, ExactMatchModel4 exactMatchModel4)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/exactMatchModel4s/", false);
            uri.AppendPath(exactMatchModel4SName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(exactMatchModel4);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The <see cref="string"/> to use. </param>
        /// <param name="exactMatchModel4SName"> The <see cref="string"/> to use. </param>
        /// <param name="exactMatchModel4"> The <see cref="ExactMatchModel4"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="exactMatchModel4SName"/> or <paramref name="exactMatchModel4"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="exactMatchModel4SName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<ExactMatchModel4>> PutAsync(string subscriptionId, string resourceGroupName, string exactMatchModel4SName, ExactMatchModel4 exactMatchModel4, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(exactMatchModel4SName, nameof(exactMatchModel4SName));
            Argument.AssertNotNull(exactMatchModel4, nameof(exactMatchModel4));

            using var message = CreatePutRequest(subscriptionId, resourceGroupName, exactMatchModel4SName, exactMatchModel4);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ExactMatchModel4 value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = ExactMatchModel4.DeserializeExactMatchModel4(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The <see cref="string"/> to use. </param>
        /// <param name="exactMatchModel4SName"> The <see cref="string"/> to use. </param>
        /// <param name="exactMatchModel4"> The <see cref="ExactMatchModel4"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="exactMatchModel4SName"/> or <paramref name="exactMatchModel4"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="exactMatchModel4SName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<ExactMatchModel4> Put(string subscriptionId, string resourceGroupName, string exactMatchModel4SName, ExactMatchModel4 exactMatchModel4, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(exactMatchModel4SName, nameof(exactMatchModel4SName));
            Argument.AssertNotNull(exactMatchModel4, nameof(exactMatchModel4));

            using var message = CreatePutRequest(subscriptionId, resourceGroupName, exactMatchModel4SName, exactMatchModel4);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ExactMatchModel4 value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = ExactMatchModel4.DeserializeExactMatchModel4(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
