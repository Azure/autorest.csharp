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
    internal partial class MgmtGroupParentsRestOperations
    {
        private Uri endpoint;
        private string apiVersion;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;
        private readonly string _userAgent;

        /// <summary> Initializes a new instance of MgmtGroupParentsRestOperations. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="options"> The client options used to construct the current client. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public MgmtGroupParentsRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, ClientOptions options, Uri endpoint = null, string apiVersion = "2020-06-01")
        {
            this.endpoint = endpoint ?? new Uri("https://management.azure.com");
            this.apiVersion = apiVersion ?? throw new ArgumentNullException(nameof(apiVersion));
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _userAgent = HttpMessageUtilities.GetUserAgentName(this, options);
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string groupId, string mgmtGroupParentName, MgmtGroupParentData parameters)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/providers/Microsoft.Management/managementGroups/", false);
            uri.AppendPath(groupId, true);
            uri.AppendPath("/mgmtGroupParents/", false);
            uri.AppendPath(mgmtGroupParentName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(parameters);
            request.Content = content;
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Create or update. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/>, <paramref name="mgmtGroupParentName"/>, or <paramref name="parameters"/> is null. </exception>
        public async Task<Response<MgmtGroupParentData>> CreateOrUpdateAsync(string groupId, string mgmtGroupParentName, MgmtGroupParentData parameters, CancellationToken cancellationToken = default)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (mgmtGroupParentName == null)
            {
                throw new ArgumentNullException(nameof(mgmtGroupParentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var message = CreateCreateOrUpdateRequest(groupId, mgmtGroupParentName, parameters);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGroupParentData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MgmtGroupParentData.DeserializeMgmtGroupParentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/>, <paramref name="mgmtGroupParentName"/>, or <paramref name="parameters"/> is null. </exception>
        public Response<MgmtGroupParentData> CreateOrUpdate(string groupId, string mgmtGroupParentName, MgmtGroupParentData parameters, CancellationToken cancellationToken = default)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (mgmtGroupParentName == null)
            {
                throw new ArgumentNullException(nameof(mgmtGroupParentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var message = CreateCreateOrUpdateRequest(groupId, mgmtGroupParentName, parameters);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGroupParentData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MgmtGroupParentData.DeserializeMgmtGroupParentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string groupId, string mgmtGroupParentName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/providers/Microsoft.Management/managementGroups/", false);
            uri.AppendPath(groupId, true);
            uri.AppendPath("/mgmtGroupParents/", false);
            uri.AppendPath(mgmtGroupParentName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="mgmtGroupParentName"/> is null. </exception>
        public async Task<Response<MgmtGroupParentData>> GetAsync(string groupId, string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (mgmtGroupParentName == null)
            {
                throw new ArgumentNullException(nameof(mgmtGroupParentName));
            }

            using var message = CreateGetRequest(groupId, mgmtGroupParentName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGroupParentData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MgmtGroupParentData.DeserializeMgmtGroupParentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((MgmtGroupParentData)null, message.Response);
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="mgmtGroupParentName"/> is null. </exception>
        public Response<MgmtGroupParentData> Get(string groupId, string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (mgmtGroupParentName == null)
            {
                throw new ArgumentNullException(nameof(mgmtGroupParentName));
            }

            using var message = CreateGetRequest(groupId, mgmtGroupParentName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGroupParentData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MgmtGroupParentData.DeserializeMgmtGroupParentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((MgmtGroupParentData)null, message.Response);
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListRequest(string groupId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/providers/Microsoft.Management/managementGroups/", false);
            uri.AppendPath(groupId, true);
            uri.AppendPath("/mgmtGroupParents", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> is null. </exception>
        public async Task<Response<MgmtGroupParentListResult>> ListAsync(string groupId, CancellationToken cancellationToken = default)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }

            using var message = CreateListRequest(groupId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGroupParentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MgmtGroupParentListResult.DeserializeMgmtGroupParentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> is null. </exception>
        public Response<MgmtGroupParentListResult> List(string groupId, CancellationToken cancellationToken = default)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }

            using var message = CreateListRequest(groupId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGroupParentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MgmtGroupParentListResult.DeserializeMgmtGroupParentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListNextPageRequest(string nextLink, string groupId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="groupId"/> is null. </exception>
        public async Task<Response<MgmtGroupParentListResult>> ListNextPageAsync(string nextLink, string groupId, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }

            using var message = CreateListNextPageRequest(nextLink, groupId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGroupParentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MgmtGroupParentListResult.DeserializeMgmtGroupParentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="groupId"/> is null. </exception>
        public Response<MgmtGroupParentListResult> ListNextPage(string nextLink, string groupId, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }

            using var message = CreateListNextPageRequest(nextLink, groupId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGroupParentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MgmtGroupParentListResult.DeserializeMgmtGroupParentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
