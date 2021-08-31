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
using MgmtLRO.Models;

namespace MgmtLRO
{
    internal partial class BarsRestOperations
    {
        private string subscriptionId;
        private Uri endpoint;
        private string apiVersion;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;
        private readonly string _userAgent;

        /// <summary> Initializes a new instance of BarsRestOperations. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="options"> The client options used to construct the current client. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="apiVersion"/> is null. </exception>
        public BarsRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, ClientOptions options, string subscriptionId, Uri endpoint = null, string apiVersion = "2020-06-01")
        {
            this.subscriptionId = subscriptionId ?? throw new ArgumentNullException(nameof(subscriptionId));
            this.endpoint = endpoint ?? new Uri("https://management.azure.com");
            this.apiVersion = apiVersion ?? throw new ArgumentNullException(nameof(apiVersion));
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _userAgent = HttpMessageUtilities.GetUserAgentName(this, options);
        }

        internal HttpMessage CreateCreateRequest(string resourceGroupName, string barName, BarData body)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Fake/bars/", false);
            uri.AppendPath(barName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(body);
            request.Content = content;
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="body"> The Bar to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="barName"/>, or <paramref name="body"/> is null. </exception>
        public async Task<Response> CreateAsync(string resourceGroupName, string barName, BarData body, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (barName == null)
            {
                throw new ArgumentNullException(nameof(barName));
            }
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var message = CreateCreateRequest(resourceGroupName, barName, body);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="body"> The Bar to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="barName"/>, or <paramref name="body"/> is null. </exception>
        public Response Create(string resourceGroupName, string barName, BarData body, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (barName == null)
            {
                throw new ArgumentNullException(nameof(barName));
            }
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var message = CreateCreateRequest(resourceGroupName, barName, body);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateUpdateRequest(string resourceGroupName, string barName, BarUpdate parameters)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Fake/bars/", false);
            uri.AppendPath(barName, true);
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

        /// <summary> Update an Bars. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="barName"> The name of the bar. </param>
        /// <param name="parameters"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="barName"/>, or <paramref name="parameters"/> is null. </exception>
        public async Task<Response> UpdateAsync(string resourceGroupName, string barName, BarUpdate parameters, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (barName == null)
            {
                throw new ArgumentNullException(nameof(barName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var message = CreateUpdateRequest(resourceGroupName, barName, parameters);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Update an Bars. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="barName"> The name of the bar. </param>
        /// <param name="parameters"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="barName"/>, or <paramref name="parameters"/> is null. </exception>
        public Response Update(string resourceGroupName, string barName, BarUpdate parameters, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (barName == null)
            {
                throw new ArgumentNullException(nameof(barName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var message = CreateUpdateRequest(resourceGroupName, barName, parameters);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string resourceGroupName, string barName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Fake/bars/", false);
            uri.AppendPath(barName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="barName"/> is null. </exception>
        public async Task<Response<BarData>> GetAsync(string resourceGroupName, string barName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (barName == null)
            {
                throw new ArgumentNullException(nameof(barName));
            }

            using var message = CreateGetRequest(resourceGroupName, barName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        BarData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = BarData.DeserializeBarData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((BarData)null, message.Response);
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="barName"/> is null. </exception>
        public Response<BarData> Get(string resourceGroupName, string barName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (barName == null)
            {
                throw new ArgumentNullException(nameof(barName));
            }

            using var message = CreateGetRequest(resourceGroupName, barName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        BarData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = BarData.DeserializeBarData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((BarData)null, message.Response);
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteRequest(string resourceGroupName, string barName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Fake/bars/", false);
            uri.AppendPath(barName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="barName"/> is null. </exception>
        public async Task<Response> DeleteAsync(string resourceGroupName, string barName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (barName == null)
            {
                throw new ArgumentNullException(nameof(barName));
            }

            using var message = CreateDeleteRequest(resourceGroupName, barName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                case 204:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="barName"/> is null. </exception>
        public Response Delete(string resourceGroupName, string barName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (barName == null)
            {
                throw new ArgumentNullException(nameof(barName));
            }

            using var message = CreateDeleteRequest(resourceGroupName, barName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                case 204:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
