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
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    internal partial class TenantParentsRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of TenantParentsRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public TenantParentsRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-06-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal RequestUriBuilder CreateCreateOrUpdateRequestUri(string tenantTestName, string tenantParentName, TenantParentData data)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Tenant/tenantTests/", false);
            uri.AppendPath(tenantTestName, true);
            uri.AppendPath("/tenantParents/", false);
            uri.AppendPath(tenantParentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string tenantTestName, string tenantParentName, TenantParentData data)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Tenant/tenantTests/", false);
            uri.AppendPath(tenantTestName, true);
            uri.AppendPath("/tenantParents/", false);
            uri.AppendPath(tenantParentName, true);
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

        /// <summary> Create or update. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/>, <paramref name="tenantParentName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> or <paramref name="tenantParentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<TenantParentData>> CreateOrUpdateAsync(string tenantTestName, string tenantParentName, TenantParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));
            Argument.AssertNotNullOrEmpty(tenantParentName, nameof(tenantParentName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(tenantTestName, tenantParentName, data);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = TenantParentData.DeserializeTenantParentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/>, <paramref name="tenantParentName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> or <paramref name="tenantParentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<TenantParentData> CreateOrUpdate(string tenantTestName, string tenantParentName, TenantParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));
            Argument.AssertNotNullOrEmpty(tenantParentName, nameof(tenantParentName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(tenantTestName, tenantParentName, data);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = TenantParentData.DeserializeTenantParentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateGetRequestUri(string tenantTestName, string tenantParentName)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Tenant/tenantTests/", false);
            uri.AppendPath(tenantTestName, true);
            uri.AppendPath("/tenantParents/", false);
            uri.AppendPath(tenantParentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateGetRequest(string tenantTestName, string tenantParentName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Tenant/tenantTests/", false);
            uri.AppendPath(tenantTestName, true);
            uri.AppendPath("/tenantParents/", false);
            uri.AppendPath(tenantParentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> or <paramref name="tenantParentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> or <paramref name="tenantParentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<TenantParentData>> GetAsync(string tenantTestName, string tenantParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));
            Argument.AssertNotNullOrEmpty(tenantParentName, nameof(tenantParentName));

            using var message = CreateGetRequest(tenantTestName, tenantParentName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = TenantParentData.DeserializeTenantParentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((TenantParentData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> or <paramref name="tenantParentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> or <paramref name="tenantParentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<TenantParentData> Get(string tenantTestName, string tenantParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));
            Argument.AssertNotNullOrEmpty(tenantParentName, nameof(tenantParentName));

            using var message = CreateGetRequest(tenantTestName, tenantParentName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = TenantParentData.DeserializeTenantParentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((TenantParentData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateListRequestUri(string tenantTestName)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Tenant/tenantTests/", false);
            uri.AppendPath(tenantTestName, true);
            uri.AppendPath("/tenantParents", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateListRequest(string tenantTestName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Tenant/tenantTests/", false);
            uri.AppendPath(tenantTestName, true);
            uri.AppendPath("/tenantParents", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<TenantParentListResult>> ListAsync(string tenantTestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));

            using var message = CreateListRequest(tenantTestName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = TenantParentListResult.DeserializeTenantParentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<TenantParentListResult> List(string tenantTestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));

            using var message = CreateListRequest(tenantTestName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = TenantParentListResult.DeserializeTenantParentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateListNextPageRequestUri(string nextLink, string tenantTestName)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            return uri;
        }

        internal HttpMessage CreateListNextPageRequest(string nextLink, string tenantTestName)
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

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="tenantTestName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<TenantParentListResult>> ListNextPageAsync(string nextLink, string tenantTestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));

            using var message = CreateListNextPageRequest(nextLink, tenantTestName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = TenantParentListResult.DeserializeTenantParentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="tenantTestName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<TenantParentListResult> ListNextPage(string nextLink, string tenantTestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));

            using var message = CreateListNextPageRequest(nextLink, tenantTestName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = TenantParentListResult.DeserializeTenantParentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
