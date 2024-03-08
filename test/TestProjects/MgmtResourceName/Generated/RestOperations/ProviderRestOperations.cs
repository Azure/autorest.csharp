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
using MgmtResourceName.Models;

namespace MgmtResourceName
{
    internal partial class ProviderRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of ProviderRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public ProviderRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-06-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal RequestUriBuilder CreateGetRequestUri(string resourceProviderNamespace, string expand)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Authorization/providerOperations/", false);
            uri.AppendPath(resourceProviderNamespace, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (expand != null)
            {
                uri.AppendQuery("$expand", expand, true);
            }
            return uri;
        }

        internal HttpMessage CreateGetRequest(string resourceProviderNamespace, string expand)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Authorization/providerOperations/", false);
            uri.AppendPath(resourceProviderNamespace, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (expand != null)
            {
                uri.AppendQuery("$expand", expand, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets provider operations metadata for the specified resource provider. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<ProviderOperationData>> GetAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));

            using var message = CreateGetRequest(resourceProviderNamespace, expand);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProviderOperationData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProviderOperationData.DeserializeProviderOperationData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((ProviderOperationData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets provider operations metadata for the specified resource provider. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<ProviderOperationData> Get(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));

            using var message = CreateGetRequest(resourceProviderNamespace, expand);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProviderOperationData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProviderOperationData.DeserializeProviderOperationData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((ProviderOperationData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateListRequestUri(string expand)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Authorization/providerOperations", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (expand != null)
            {
                uri.AppendQuery("$expand", expand, true);
            }
            return uri;
        }

        internal HttpMessage CreateListRequest(string expand)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Authorization/providerOperations", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (expand != null)
            {
                uri.AppendQuery("$expand", expand, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets provider operations metadata for all resource providers. </summary>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProviderOperationsMetadataListResult>> ListAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateListRequest(expand);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProviderOperationsMetadataListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProviderOperationsMetadataListResult.DeserializeProviderOperationsMetadataListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets provider operations metadata for all resource providers. </summary>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProviderOperationsMetadataListResult> List(string expand = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateListRequest(expand);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProviderOperationsMetadataListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProviderOperationsMetadataListResult.DeserializeProviderOperationsMetadataListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateListNextPageRequestUri(string nextLink, string expand)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            return uri;
        }

        internal HttpMessage CreateListNextPageRequest(string nextLink, string expand)
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

        /// <summary> Gets provider operations metadata for all resource providers. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<ProviderOperationsMetadataListResult>> ListNextPageAsync(string nextLink, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            using var message = CreateListNextPageRequest(nextLink, expand);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProviderOperationsMetadataListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProviderOperationsMetadataListResult.DeserializeProviderOperationsMetadataListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets provider operations metadata for all resource providers. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<ProviderOperationsMetadataListResult> ListNextPage(string nextLink, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            using var message = CreateListNextPageRequest(nextLink, expand);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProviderOperationsMetadataListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProviderOperationsMetadataListResult.DeserializeProviderOperationsMetadataListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
