// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    internal partial class MgmtGrpParentWithNonResChesRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of MgmtGrpParentWithNonResChesRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public MgmtGrpParentWithNonResChesRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-06-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string groupId, string mgmtGrpParentWithNonResChName, MgmtGrpParentWithNonResChData data)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Management/managementGroups/", false);
            uri.AppendPath(groupId, true);
            uri.AppendPath("/mgmtGrpParentWithNonResChes/", false);
            uri.AppendPath(mgmtGrpParentWithNonResChName, true);
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
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/>, <paramref name="mgmtGrpParentWithNonResChName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> or <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<MgmtGrpParentWithNonResChData>> CreateOrUpdateAsync(string groupId, string mgmtGrpParentWithNonResChName, MgmtGrpParentWithNonResChData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChName, nameof(mgmtGrpParentWithNonResChName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(groupId, mgmtGrpParentWithNonResChName, data);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGrpParentWithNonResChData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MgmtGrpParentWithNonResChData.DeserializeMgmtGrpParentWithNonResChData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/>, <paramref name="mgmtGrpParentWithNonResChName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> or <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<MgmtGrpParentWithNonResChData> CreateOrUpdate(string groupId, string mgmtGrpParentWithNonResChName, MgmtGrpParentWithNonResChData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChName, nameof(mgmtGrpParentWithNonResChName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(groupId, mgmtGrpParentWithNonResChName, data);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGrpParentWithNonResChData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MgmtGrpParentWithNonResChData.DeserializeMgmtGrpParentWithNonResChData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string groupId, string mgmtGrpParentWithNonResChName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Management/managementGroups/", false);
            uri.AppendPath(groupId, true);
            uri.AppendPath("/mgmtGrpParentWithNonResChes/", false);
            uri.AppendPath(mgmtGrpParentWithNonResChName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="mgmtGrpParentWithNonResChName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> or <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<MgmtGrpParentWithNonResChData>> GetAsync(string groupId, string mgmtGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChName, nameof(mgmtGrpParentWithNonResChName));

            using var message = CreateGetRequest(groupId, mgmtGrpParentWithNonResChName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGrpParentWithNonResChData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MgmtGrpParentWithNonResChData.DeserializeMgmtGrpParentWithNonResChData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((MgmtGrpParentWithNonResChData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="mgmtGrpParentWithNonResChName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> or <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<MgmtGrpParentWithNonResChData> Get(string groupId, string mgmtGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChName, nameof(mgmtGrpParentWithNonResChName));

            using var message = CreateGetRequest(groupId, mgmtGrpParentWithNonResChName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGrpParentWithNonResChData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MgmtGrpParentWithNonResChData.DeserializeMgmtGrpParentWithNonResChData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((MgmtGrpParentWithNonResChData)null, message.Response);
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
            uri.AppendPath("/mgmtGrpParentWithNonResChes", false);
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
        public async Task<Response<MgmtGrpParentWithNonResChListResult>> ListAsync(string groupId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));

            using var message = CreateListRequest(groupId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGrpParentWithNonResChListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MgmtGrpParentWithNonResChListResult.DeserializeMgmtGrpParentWithNonResChListResult(document.RootElement);
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
        public Response<MgmtGrpParentWithNonResChListResult> List(string groupId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));

            using var message = CreateListRequest(groupId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGrpParentWithNonResChListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MgmtGrpParentWithNonResChListResult.DeserializeMgmtGrpParentWithNonResChListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListNonResourceChildRequest(string groupId, string mgmtGrpParentWithNonResChName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Management/managementGroups/", false);
            uri.AppendPath(groupId, true);
            uri.AppendPath("/mgmtGrpParentWithNonResChes/", false);
            uri.AppendPath(mgmtGrpParentWithNonResChName, true);
            uri.AppendPath("/nonResourceChild", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists all. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="mgmtGrpParentWithNonResChName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> or <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<NonResourceChildListResult>> ListNonResourceChildAsync(string groupId, string mgmtGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChName, nameof(mgmtGrpParentWithNonResChName));

            using var message = CreateListNonResourceChildRequest(groupId, mgmtGrpParentWithNonResChName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NonResourceChildListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = NonResourceChildListResult.DeserializeNonResourceChildListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all. </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> or <paramref name="mgmtGrpParentWithNonResChName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> or <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<NonResourceChildListResult> ListNonResourceChild(string groupId, string mgmtGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChName, nameof(mgmtGrpParentWithNonResChName));

            using var message = CreateListNonResourceChildRequest(groupId, mgmtGrpParentWithNonResChName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NonResourceChildListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = NonResourceChildListResult.DeserializeNonResourceChildListResult(document.RootElement);
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
        public async Task<Response<MgmtGrpParentWithNonResChListResult>> ListNextPageAsync(string nextLink, string groupId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));

            using var message = CreateListNextPageRequest(nextLink, groupId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGrpParentWithNonResChListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MgmtGrpParentWithNonResChListResult.DeserializeMgmtGrpParentWithNonResChListResult(document.RootElement);
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
        public Response<MgmtGrpParentWithNonResChListResult> ListNextPage(string nextLink, string groupId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));

            using var message = CreateListNextPageRequest(nextLink, groupId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MgmtGrpParentWithNonResChListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MgmtGrpParentWithNonResChListResult.DeserializeMgmtGrpParentWithNonResChListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
