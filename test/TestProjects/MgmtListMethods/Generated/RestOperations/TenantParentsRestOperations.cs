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
using Azure.ResourceManager.Core;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    internal partial class TenantParentsRestOperations
    {
        private readonly string _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of TenantParentsRestOperations. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public TenantParentsRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-06-01";
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _userAgent = Azure.ResourceManager.Core.HttpMessageUtilities.GetUserAgentName(this, applicationId);
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string tenantTestName, string tenantParentName, TenantParentData parameters)
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
            content.JsonWriter.WriteObjectValue(parameters);
            request.Content = content;
            message.SetProperty("SDKUserAgent", _userAgent);
            return message;
        }

        /// <summary> Create or update. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/>, <paramref name="tenantParentName"/>, or <paramref name="parameters"/> is null. </exception>
        public async Task<Response<TenantParentData>> CreateOrUpdateAsync(string tenantTestName, string tenantParentName, TenantParentData parameters, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }
            if (tenantParentName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var message = CreateCreateOrUpdateRequest(tenantTestName, tenantParentName, parameters);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = TenantParentData.DeserializeTenantParentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/>, <paramref name="tenantParentName"/>, or <paramref name="parameters"/> is null. </exception>
        public Response<TenantParentData> CreateOrUpdate(string tenantTestName, string tenantParentName, TenantParentData parameters, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }
            if (tenantParentName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var message = CreateCreateOrUpdateRequest(tenantTestName, tenantParentName, parameters);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = TenantParentData.DeserializeTenantParentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
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
            message.SetProperty("SDKUserAgent", _userAgent);
            return message;
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> or <paramref name="tenantParentName"/> is null. </exception>
        public async Task<Response<TenantParentData>> GetAsync(string tenantTestName, string tenantParentName, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }
            if (tenantParentName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentName));
            }

            using var message = CreateGetRequest(tenantTestName, tenantParentName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = TenantParentData.DeserializeTenantParentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((TenantParentData)null, message.Response);
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> or <paramref name="tenantParentName"/> is null. </exception>
        public Response<TenantParentData> Get(string tenantTestName, string tenantParentName, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }
            if (tenantParentName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentName));
            }

            using var message = CreateGetRequest(tenantTestName, tenantParentName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = TenantParentData.DeserializeTenantParentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((TenantParentData)null, message.Response);
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
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
            message.SetProperty("SDKUserAgent", _userAgent);
            return message;
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        public async Task<Response<TenantParentListResult>> ListAsync(string tenantTestName, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }

            using var message = CreateListRequest(tenantTestName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = TenantParentListResult.DeserializeTenantParentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        public Response<TenantParentListResult> List(string tenantTestName, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }

            using var message = CreateListRequest(tenantTestName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = TenantParentListResult.DeserializeTenantParentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
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
            message.SetProperty("SDKUserAgent", _userAgent);
            return message;
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="tenantTestName"/> is null. </exception>
        public async Task<Response<TenantParentListResult>> ListNextPageAsync(string nextLink, string tenantTestName, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }

            using var message = CreateListNextPageRequest(nextLink, tenantTestName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = TenantParentListResult.DeserializeTenantParentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="tenantTestName"/> is null. </exception>
        public Response<TenantParentListResult> ListNextPage(string nextLink, string tenantTestName, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }

            using var message = CreateListNextPageRequest(nextLink, tenantTestName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TenantParentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = TenantParentListResult.DeserializeTenantParentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
