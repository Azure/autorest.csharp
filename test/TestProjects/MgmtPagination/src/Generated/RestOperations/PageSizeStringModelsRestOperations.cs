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
using MgmtPagination.Models;

namespace MgmtPagination
{
    internal partial class PageSizeStringModelsRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of PageSizeStringModelsRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public PageSizeStringModelsRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-06-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal RequestUriBuilder CreateListRequestUri(string subscriptionId, string resourceGroupName, string maxpagesize)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/pageSizeStringModel", false);
            if (maxpagesize != null)
            {
                uri.AppendQuery("maxpagesize", maxpagesize, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateListRequest(string subscriptionId, string resourceGroupName, string maxpagesize)
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
            uri.AppendPath("/providers/Microsoft.Compute/pageSizeStringModel", false);
            if (maxpagesize != null)
            {
                uri.AppendQuery("maxpagesize", maxpagesize, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<PageSizeStringModelListResult>> ListAsync(string subscriptionId, string resourceGroupName, string maxpagesize = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var message = CreateListRequest(subscriptionId, resourceGroupName, maxpagesize);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PageSizeStringModelListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = PageSizeStringModelListResult.DeserializePageSizeStringModelListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<PageSizeStringModelListResult> List(string subscriptionId, string resourceGroupName, string maxpagesize = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var message = CreateListRequest(subscriptionId, resourceGroupName, maxpagesize);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PageSizeStringModelListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = PageSizeStringModelListResult.DeserializePageSizeStringModelListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreatePutRequestUri(string subscriptionId, string resourceGroupName, string name, PageSizeStringModelData data)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/pageSizeStringModel/", false);
            uri.AppendPath(name, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreatePutRequest(string subscriptionId, string resourceGroupName, string name, PageSizeStringModelData data)
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
            uri.AppendPath("/providers/Microsoft.Compute/pageSizeStringModel/", false);
            uri.AppendPath(name, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(data);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The <see cref="string"/> to use. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="PageSizeStringModelData"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<PageSizeStringModelData>> PutAsync(string subscriptionId, string resourceGroupName, string name, PageSizeStringModelData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreatePutRequest(subscriptionId, resourceGroupName, name, data);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PageSizeStringModelData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = PageSizeStringModelData.DeserializePageSizeStringModelData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The <see cref="string"/> to use. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="PageSizeStringModelData"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<PageSizeStringModelData> Put(string subscriptionId, string resourceGroupName, string name, PageSizeStringModelData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreatePutRequest(subscriptionId, resourceGroupName, name, data);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PageSizeStringModelData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = PageSizeStringModelData.DeserializePageSizeStringModelData(document.RootElement);
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
            uri.AppendPath("/providers/Microsoft.Compute/pageSizeStringModel/", false);
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
            uri.AppendPath("/providers/Microsoft.Compute/pageSizeStringModel/", false);
            uri.AppendPath(name, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<PageSizeStringModelData>> GetAsync(string subscriptionId, string resourceGroupName, string name, CancellationToken cancellationToken = default)
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
                        PageSizeStringModelData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = PageSizeStringModelData.DeserializePageSizeStringModelData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((PageSizeStringModelData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<PageSizeStringModelData> Get(string subscriptionId, string resourceGroupName, string name, CancellationToken cancellationToken = default)
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
                        PageSizeStringModelData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = PageSizeStringModelData.DeserializePageSizeStringModelData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((PageSizeStringModelData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateListNextPageRequestUri(string nextLink, string subscriptionId, string resourceGroupName, string maxpagesize)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            return uri;
        }

        internal HttpMessage CreateListNextPageRequest(string nextLink, string subscriptionId, string resourceGroupName, string maxpagesize)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<PageSizeStringModelListResult>> ListNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string maxpagesize = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var message = CreateListNextPageRequest(nextLink, subscriptionId, resourceGroupName, maxpagesize);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PageSizeStringModelListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = PageSizeStringModelListResult.DeserializePageSizeStringModelListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> The <see cref="string"/> to use. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<PageSizeStringModelListResult> ListNextPage(string nextLink, string subscriptionId, string resourceGroupName, string maxpagesize = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var message = CreateListNextPageRequest(nextLink, subscriptionId, resourceGroupName, maxpagesize);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PageSizeStringModelListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = PageSizeStringModelListResult.DeserializePageSizeStringModelListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
