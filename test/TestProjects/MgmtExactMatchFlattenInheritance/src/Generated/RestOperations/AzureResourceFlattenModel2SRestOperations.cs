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
using MgmtExactMatchFlattenInheritance.Models;

namespace MgmtExactMatchFlattenInheritance
{
    internal partial class AzureResourceFlattenModel2SRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of AzureResourceFlattenModel2SRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public AzureResourceFlattenModel2SRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-06-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal RequestUriBuilder CreateListRequestUri(string subscriptionId, string resourceGroupName)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/azureResourceFlattenModel2s", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateListRequest(string subscriptionId, string resourceGroupName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/azureResourceFlattenModel2s", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Get an AzureResourceFlattenModel2. </summary>
        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<AzureResourceFlattenModel2ListResult>> ListAsync(string subscriptionId, string resourceGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var message = CreateListRequest(subscriptionId, resourceGroupName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AzureResourceFlattenModel2ListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = AzureResourceFlattenModel2ListResult.DeserializeAzureResourceFlattenModel2ListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an AzureResourceFlattenModel2. </summary>
        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<AzureResourceFlattenModel2ListResult> List(string subscriptionId, string resourceGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var message = CreateListRequest(subscriptionId, resourceGroupName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AzureResourceFlattenModel2ListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = AzureResourceFlattenModel2ListResult.DeserializeAzureResourceFlattenModel2ListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreatePutRequestUri(string subscriptionId, string resourceGroupName, string name, AzureResourceFlattenModel2 azureResourceFlattenModel2)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/azureResourceFlattenModel2s/", false);
            uri.AppendPath(name, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreatePutRequest(string subscriptionId, string resourceGroupName, string name, AzureResourceFlattenModel2 azureResourceFlattenModel2)
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
            uri.AppendPath("/providers/Microsoft.Compute/azureResourceFlattenModel2s/", false);
            uri.AppendPath(name, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(azureResourceFlattenModel2);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Create or update an AzureResourceFlattenModel2. </summary>
        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The <see cref="string"/> to use. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="azureResourceFlattenModel2"> The <see cref="AzureResourceFlattenModel2"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/> or <paramref name="azureResourceFlattenModel2"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<AzureResourceFlattenModel2>> PutAsync(string subscriptionId, string resourceGroupName, string name, AzureResourceFlattenModel2 azureResourceFlattenModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(azureResourceFlattenModel2, nameof(azureResourceFlattenModel2));

            using var message = CreatePutRequest(subscriptionId, resourceGroupName, name, azureResourceFlattenModel2);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AzureResourceFlattenModel2 value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = AzureResourceFlattenModel2.DeserializeAzureResourceFlattenModel2(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Create or update an AzureResourceFlattenModel2. </summary>
        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The <see cref="string"/> to use. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="azureResourceFlattenModel2"> The <see cref="AzureResourceFlattenModel2"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/> or <paramref name="azureResourceFlattenModel2"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<AzureResourceFlattenModel2> Put(string subscriptionId, string resourceGroupName, string name, AzureResourceFlattenModel2 azureResourceFlattenModel2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(azureResourceFlattenModel2, nameof(azureResourceFlattenModel2));

            using var message = CreatePutRequest(subscriptionId, resourceGroupName, name, azureResourceFlattenModel2);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AzureResourceFlattenModel2 value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = AzureResourceFlattenModel2.DeserializeAzureResourceFlattenModel2(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateGetRequestUri(string subscriptionId, string resourceGroupName, string name)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/azureResourceFlattenModel2s/", false);
            uri.AppendPath(name, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateGetRequest(string subscriptionId, string resourceGroupName, string name)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/azureResourceFlattenModel2s/", false);
            uri.AppendPath(name, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Get an AzureResourceFlattenModel2. </summary>
        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<AzureResourceFlattenModel2>> GetAsync(string subscriptionId, string resourceGroupName, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, name);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AzureResourceFlattenModel2 value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = AzureResourceFlattenModel2.DeserializeAzureResourceFlattenModel2(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an AzureResourceFlattenModel2. </summary>
        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<AzureResourceFlattenModel2> Get(string subscriptionId, string resourceGroupName, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, name);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AzureResourceFlattenModel2 value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = AzureResourceFlattenModel2.DeserializeAzureResourceFlattenModel2(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
