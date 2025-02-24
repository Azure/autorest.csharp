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
using MgmtDiscriminator.Models;

namespace MgmtDiscriminator
{
    internal partial class ArtifactsRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of ArtifactsRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public ArtifactsRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-06-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal RequestUriBuilder CreateCreateOrUpdateRequestUri(string resourceScope, string artifactName, ArtifactData data)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceScope, false);
            uri.AppendPath("/providers/Microsoft.Blueprint/artifacts/", false);
            uri.AppendPath(artifactName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string resourceScope, string artifactName, ArtifactData data)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceScope, false);
            uri.AppendPath("/providers/Microsoft.Blueprint/artifacts/", false);
            uri.AppendPath(artifactName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(data, ModelSerializationExtensions.WireOptions);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Create or update blueprint artifact. </summary>
        /// <param name="resourceScope"> The scope of the resource. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'). </param>
        /// <param name="artifactName"> Name of the blueprint artifact. </param>
        /// <param name="data"> Blueprint artifact to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceScope"/>, <paramref name="artifactName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="artifactName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<ArtifactData>> CreateOrUpdateAsync(string resourceScope, string artifactName, ArtifactData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceScope, nameof(resourceScope));
            Argument.AssertNotNullOrEmpty(artifactName, nameof(artifactName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(resourceScope, artifactName, data);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        ArtifactData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = ArtifactData.DeserializeArtifactData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Create or update blueprint artifact. </summary>
        /// <param name="resourceScope"> The scope of the resource. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'). </param>
        /// <param name="artifactName"> Name of the blueprint artifact. </param>
        /// <param name="data"> Blueprint artifact to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceScope"/>, <paramref name="artifactName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="artifactName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<ArtifactData> CreateOrUpdate(string resourceScope, string artifactName, ArtifactData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceScope, nameof(resourceScope));
            Argument.AssertNotNullOrEmpty(artifactName, nameof(artifactName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(resourceScope, artifactName, data);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        ArtifactData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = ArtifactData.DeserializeArtifactData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateGetRequestUri(string resourceScope, string artifactName)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceScope, false);
            uri.AppendPath("/providers/Microsoft.Blueprint/artifacts/", false);
            uri.AppendPath(artifactName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateGetRequest(string resourceScope, string artifactName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceScope, false);
            uri.AppendPath("/providers/Microsoft.Blueprint/artifacts/", false);
            uri.AppendPath(artifactName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Get a blueprint artifact. </summary>
        /// <param name="resourceScope"> The scope of the resource. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'). </param>
        /// <param name="artifactName"> Name of the blueprint artifact. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceScope"/> or <paramref name="artifactName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="artifactName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<ArtifactData>> GetAsync(string resourceScope, string artifactName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceScope, nameof(resourceScope));
            Argument.AssertNotNullOrEmpty(artifactName, nameof(artifactName));

            using var message = CreateGetRequest(resourceScope, artifactName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ArtifactData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = ArtifactData.DeserializeArtifactData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((ArtifactData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a blueprint artifact. </summary>
        /// <param name="resourceScope"> The scope of the resource. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'). </param>
        /// <param name="artifactName"> Name of the blueprint artifact. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceScope"/> or <paramref name="artifactName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="artifactName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<ArtifactData> Get(string resourceScope, string artifactName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceScope, nameof(resourceScope));
            Argument.AssertNotNullOrEmpty(artifactName, nameof(artifactName));

            using var message = CreateGetRequest(resourceScope, artifactName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ArtifactData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = ArtifactData.DeserializeArtifactData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((ArtifactData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateDeleteRequestUri(string resourceScope, string artifactName)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceScope, false);
            uri.AppendPath("/providers/Microsoft.Blueprint/artifacts/", false);
            uri.AppendPath(artifactName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateDeleteRequest(string resourceScope, string artifactName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceScope, false);
            uri.AppendPath("/providers/Microsoft.Blueprint/artifacts/", false);
            uri.AppendPath(artifactName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Delete a blueprint artifact. </summary>
        /// <param name="resourceScope"> The scope of the resource. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'). </param>
        /// <param name="artifactName"> Name of the blueprint artifact. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceScope"/> or <paramref name="artifactName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="artifactName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<ArtifactData>> DeleteAsync(string resourceScope, string artifactName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceScope, nameof(resourceScope));
            Argument.AssertNotNullOrEmpty(artifactName, nameof(artifactName));

            using var message = CreateDeleteRequest(resourceScope, artifactName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ArtifactData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = ArtifactData.DeserializeArtifactData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((ArtifactData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Delete a blueprint artifact. </summary>
        /// <param name="resourceScope"> The scope of the resource. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'). </param>
        /// <param name="artifactName"> Name of the blueprint artifact. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceScope"/> or <paramref name="artifactName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="artifactName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<ArtifactData> Delete(string resourceScope, string artifactName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceScope, nameof(resourceScope));
            Argument.AssertNotNullOrEmpty(artifactName, nameof(artifactName));

            using var message = CreateDeleteRequest(resourceScope, artifactName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ArtifactData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = ArtifactData.DeserializeArtifactData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((ArtifactData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateListRequestUri(string resourceScope)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceScope, false);
            uri.AppendPath("/providers/Microsoft.Blueprint/artifacts", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateListRequest(string resourceScope)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceScope, false);
            uri.AppendPath("/providers/Microsoft.Blueprint/artifacts", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> List artifacts for a given blueprint definition. </summary>
        /// <param name="resourceScope"> The scope of the resource. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceScope"/> is null. </exception>
        public async Task<Response<ArtifactList>> ListAsync(string resourceScope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceScope, nameof(resourceScope));

            using var message = CreateListRequest(resourceScope);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ArtifactList value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = ArtifactList.DeserializeArtifactList(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> List artifacts for a given blueprint definition. </summary>
        /// <param name="resourceScope"> The scope of the resource. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceScope"/> is null. </exception>
        public Response<ArtifactList> List(string resourceScope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceScope, nameof(resourceScope));

            using var message = CreateListRequest(resourceScope);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ArtifactList value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = ArtifactList.DeserializeArtifactList(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateListNextPageRequestUri(string nextLink, string resourceScope)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            return uri;
        }

        internal HttpMessage CreateListNextPageRequest(string nextLink, string resourceScope)
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

        /// <summary> List artifacts for a given blueprint definition. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="resourceScope"> The scope of the resource. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="resourceScope"/> is null. </exception>
        public async Task<Response<ArtifactList>> ListNextPageAsync(string nextLink, string resourceScope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNull(resourceScope, nameof(resourceScope));

            using var message = CreateListNextPageRequest(nextLink, resourceScope);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ArtifactList value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = ArtifactList.DeserializeArtifactList(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> List artifacts for a given blueprint definition. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="resourceScope"> The scope of the resource. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="resourceScope"/> is null. </exception>
        public Response<ArtifactList> ListNextPage(string nextLink, string resourceScope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNull(resourceScope, nameof(resourceScope));

            using var message = CreateListNextPageRequest(nextLink, resourceScope);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ArtifactList value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = ArtifactList.DeserializeArtifactList(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
