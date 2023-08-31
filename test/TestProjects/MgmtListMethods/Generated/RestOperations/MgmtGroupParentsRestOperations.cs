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
    internal partial class MgmtGroupParentsRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of MgmtGroupParentsRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public MgmtGroupParentsRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-06-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string groupId, string mgmtGroupParentName, MgmtGroupParentData data)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Management/managementGroups/", false);
            uri.AppendPath(groupId, true);
            uri.AppendPath("/mgmtGroupParents/", false);
            uri.AppendPath(mgmtGroupParentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = data;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Create or update. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/>, <paramref name="mgmtGroupParentName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> or <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<MgmtGroupParentData>> CreateOrUpdateAsync(string groupId, string mgmtGroupParentName, MgmtGroupParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(groupId, mgmtGroupParentName, data);
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
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/>, <paramref name="mgmtGroupParentName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> or <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<MgmtGroupParentData> CreateOrUpdate(string groupId, string mgmtGroupParentName, MgmtGroupParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(groupId, mgmtGroupParentName, data);
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
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string groupId, string mgmtGroupParentName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Management/managementGroups/", false);
            uri.AppendPath(groupId, true);
            uri.AppendPath("/mgmtGroupParents/", false);
            uri.AppendPath(mgmtGroupParentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="mgmtGroupParentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> or <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<MgmtGroupParentData>> GetAsync(string groupId, string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));

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
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="mgmtGroupParentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> or <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<MgmtGroupParentData> Get(string groupId, string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));

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
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListRequest(string groupId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Management/managementGroups/", false);
            uri.AppendPath(groupId, true);
            uri.AppendPath("/mgmtGroupParents", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<MgmtGroupParentListResult>> ListAsync(string groupId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));

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
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<MgmtGroupParentListResult> List(string groupId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));

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
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListNextPageRequest(string nextLink, string groupId)
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
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="groupId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<MgmtGroupParentListResult>> ListNextPageAsync(string nextLink, string groupId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));

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
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="groupId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<MgmtGroupParentListResult> ListNextPage(string nextLink, string groupId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));

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
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
