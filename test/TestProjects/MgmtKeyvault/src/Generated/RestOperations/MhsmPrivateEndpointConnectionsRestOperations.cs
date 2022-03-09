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
using MgmtKeyvault.Models;

namespace MgmtKeyvault
{
    internal partial class MhsmPrivateEndpointConnectionsRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of MhsmPrivateEndpointConnectionsRestOperations. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public MhsmPrivateEndpointConnectionsRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2021-04-01-preview";
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal HttpMessage CreateListByResourceRequest(string subscriptionId, string resourceGroupName, string name)
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
            uri.AppendPath("/providers/Microsoft.KeyVault/managedHSMs/", false);
            uri.AppendPath(name, true);
            uri.AppendPath("/privateEndpointConnections", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> The List operation gets information about the private endpoint connections associated with the managed HSM Pool. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> Name of the resource group that contains the managed HSM pool. </param>
        /// <param name="name"> Name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is null. </exception>
        public async Task<Response<MhsmPrivateEndpointConnectionsListResult>> ListByResourceAsync(string subscriptionId, string resourceGroupName, string name, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var message = CreateListByResourceRequest(subscriptionId, resourceGroupName, name);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MhsmPrivateEndpointConnectionsListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MhsmPrivateEndpointConnectionsListResult.DeserializeMhsmPrivateEndpointConnectionsListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> The List operation gets information about the private endpoint connections associated with the managed HSM Pool. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> Name of the resource group that contains the managed HSM pool. </param>
        /// <param name="name"> Name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is null. </exception>
        public Response<MhsmPrivateEndpointConnectionsListResult> ListByResource(string subscriptionId, string resourceGroupName, string name, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var message = CreateListByResourceRequest(subscriptionId, resourceGroupName, name);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MhsmPrivateEndpointConnectionsListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MhsmPrivateEndpointConnectionsListResult.DeserializeMhsmPrivateEndpointConnectionsListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName)
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
            uri.AppendPath("/providers/Microsoft.KeyVault/managedHSMs/", false);
            uri.AppendPath(name, true);
            uri.AppendPath("/privateEndpointConnections/", false);
            uri.AppendPath(privateEndpointConnectionName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets the specified private endpoint connection associated with the managed HSM Pool. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> Name of the resource group that contains the managed HSM pool. </param>
        /// <param name="name"> Name of the managed HSM Pool. </param>
        /// <param name="privateEndpointConnectionName"> Name of the private endpoint connection associated with the managed hsm pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/> or <paramref name="privateEndpointConnectionName"/> is null. </exception>
        public async Task<Response<MhsmPrivateEndpointConnectionData>> GetAsync(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (privateEndpointConnectionName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointConnectionName));
            }

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, name, privateEndpointConnectionName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MhsmPrivateEndpointConnectionData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MhsmPrivateEndpointConnectionData.DeserializeMhsmPrivateEndpointConnectionData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((MhsmPrivateEndpointConnectionData)null, message.Response);
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Gets the specified private endpoint connection associated with the managed HSM Pool. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> Name of the resource group that contains the managed HSM pool. </param>
        /// <param name="name"> Name of the managed HSM Pool. </param>
        /// <param name="privateEndpointConnectionName"> Name of the private endpoint connection associated with the managed hsm pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/> or <paramref name="privateEndpointConnectionName"/> is null. </exception>
        public Response<MhsmPrivateEndpointConnectionData> Get(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (privateEndpointConnectionName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointConnectionName));
            }

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, name, privateEndpointConnectionName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MhsmPrivateEndpointConnectionData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MhsmPrivateEndpointConnectionData.DeserializeMhsmPrivateEndpointConnectionData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((MhsmPrivateEndpointConnectionData)null, message.Response);
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutRequest(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName, MhsmPrivateEndpointConnectionData properties)
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
            uri.AppendPath("/providers/Microsoft.KeyVault/managedHSMs/", false);
            uri.AppendPath(name, true);
            uri.AppendPath("/privateEndpointConnections/", false);
            uri.AppendPath(privateEndpointConnectionName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(properties);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Updates the specified private endpoint connection associated with the managed hsm pool. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> Name of the resource group that contains the managed HSM pool. </param>
        /// <param name="name"> Name of the managed HSM Pool. </param>
        /// <param name="privateEndpointConnectionName"> Name of the private endpoint connection associated with the managed hsm pool. </param>
        /// <param name="properties"> The intended state of private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/>, <paramref name="privateEndpointConnectionName"/> or <paramref name="properties"/> is null. </exception>
        public async Task<Response<MhsmPrivateEndpointConnectionData>> PutAsync(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName, MhsmPrivateEndpointConnectionData properties, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (privateEndpointConnectionName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointConnectionName));
            }
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var message = CreatePutRequest(subscriptionId, resourceGroupName, name, privateEndpointConnectionName, properties);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MhsmPrivateEndpointConnectionData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MhsmPrivateEndpointConnectionData.DeserializeMhsmPrivateEndpointConnectionData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Updates the specified private endpoint connection associated with the managed hsm pool. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> Name of the resource group that contains the managed HSM pool. </param>
        /// <param name="name"> Name of the managed HSM Pool. </param>
        /// <param name="privateEndpointConnectionName"> Name of the private endpoint connection associated with the managed hsm pool. </param>
        /// <param name="properties"> The intended state of private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/>, <paramref name="privateEndpointConnectionName"/> or <paramref name="properties"/> is null. </exception>
        public Response<MhsmPrivateEndpointConnectionData> Put(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName, MhsmPrivateEndpointConnectionData properties, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (privateEndpointConnectionName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointConnectionName));
            }
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var message = CreatePutRequest(subscriptionId, resourceGroupName, name, privateEndpointConnectionName, properties);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MhsmPrivateEndpointConnectionData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MhsmPrivateEndpointConnectionData.DeserializeMhsmPrivateEndpointConnectionData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteRequest(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.KeyVault/managedHSMs/", false);
            uri.AppendPath(name, true);
            uri.AppendPath("/privateEndpointConnections/", false);
            uri.AppendPath(privateEndpointConnectionName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Deletes the specified private endpoint connection associated with the managed hsm pool. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> Name of the resource group that contains the managed HSM pool. </param>
        /// <param name="name"> Name of the managed HSM Pool. </param>
        /// <param name="privateEndpointConnectionName"> Name of the private endpoint connection associated with the managed hsm pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/> or <paramref name="privateEndpointConnectionName"/> is null. </exception>
        public async Task<HttpMessage> DeleteAsync(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (privateEndpointConnectionName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointConnectionName));
            }

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, name, privateEndpointConnectionName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message;
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Deletes the specified private endpoint connection associated with the managed hsm pool. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> Name of the resource group that contains the managed HSM pool. </param>
        /// <param name="name"> Name of the managed HSM Pool. </param>
        /// <param name="privateEndpointConnectionName"> Name of the private endpoint connection associated with the managed hsm pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/> or <paramref name="privateEndpointConnectionName"/> is null. </exception>
        public HttpMessage Delete(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (privateEndpointConnectionName == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointConnectionName));
            }

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, name, privateEndpointConnectionName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message;
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListByResourceNextPageRequest(string nextLink, string subscriptionId, string resourceGroupName, string name)
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

        /// <summary> The List operation gets information about the private endpoint connections associated with the managed HSM Pool. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> Name of the resource group that contains the managed HSM pool. </param>
        /// <param name="name"> Name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is null. </exception>
        public async Task<Response<MhsmPrivateEndpointConnectionsListResult>> ListByResourceNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string name, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var message = CreateListByResourceNextPageRequest(nextLink, subscriptionId, resourceGroupName, name);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MhsmPrivateEndpointConnectionsListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MhsmPrivateEndpointConnectionsListResult.DeserializeMhsmPrivateEndpointConnectionsListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> The List operation gets information about the private endpoint connections associated with the managed HSM Pool. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> Name of the resource group that contains the managed HSM pool. </param>
        /// <param name="name"> Name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="name"/> is null. </exception>
        public Response<MhsmPrivateEndpointConnectionsListResult> ListByResourceNextPage(string nextLink, string subscriptionId, string resourceGroupName, string name, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var message = CreateListByResourceNextPageRequest(nextLink, subscriptionId, resourceGroupName, name);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MhsmPrivateEndpointConnectionsListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MhsmPrivateEndpointConnectionsListResult.DeserializeMhsmPrivateEndpointConnectionsListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
