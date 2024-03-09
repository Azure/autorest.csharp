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
using MgmtOperations.Models;

namespace MgmtOperations
{
    internal partial class AvailabilitySetGrandChildRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of AvailabilitySetGrandChildRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public AvailabilitySetGrandChildRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-06-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal HttpMessage CreateListRequest(string subscriptionId, string resourceGroupName, string availabilitySetName, string availabilitySetChildName)
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
            uri.AppendPath("/providers/Microsoft.Compute/availabilitySets/", false);
            uri.AppendPath(availabilitySetName, true);
            uri.AppendPath("/availabilitySetChildren/", false);
            uri.AppendPath(availabilitySetChildName, true);
            uri.AppendPath("/availabilitySetGrandChildren", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Retrieves information about an availability set. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="availabilitySetName"/> or <paramref name="availabilitySetChildName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="availabilitySetName"/> or <paramref name="availabilitySetChildName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<AvailabilitySetGrandChildListResult>> ListAsync(string subscriptionId, string resourceGroupName, string availabilitySetName, string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));
            Argument.AssertNotNullOrEmpty(availabilitySetChildName, nameof(availabilitySetChildName));

            using var message = CreateListRequest(subscriptionId, resourceGroupName, availabilitySetName, availabilitySetChildName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AvailabilitySetGrandChildListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AvailabilitySetGrandChildListResult.DeserializeAvailabilitySetGrandChildListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Retrieves information about an availability set. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="availabilitySetName"/> or <paramref name="availabilitySetChildName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="availabilitySetName"/> or <paramref name="availabilitySetChildName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<AvailabilitySetGrandChildListResult> List(string subscriptionId, string resourceGroupName, string availabilitySetName, string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));
            Argument.AssertNotNullOrEmpty(availabilitySetChildName, nameof(availabilitySetChildName));

            using var message = CreateListRequest(subscriptionId, resourceGroupName, availabilitySetName, availabilitySetChildName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AvailabilitySetGrandChildListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AvailabilitySetGrandChildListResult.DeserializeAvailabilitySetGrandChildListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string subscriptionId, string resourceGroupName, string availabilitySetName, string availabilitySetChildName, string availabilitySetGrandChildName)
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
            uri.AppendPath("/providers/Microsoft.Compute/availabilitySets/", false);
            uri.AppendPath(availabilitySetName, true);
            uri.AppendPath("/availabilitySetChildren/", false);
            uri.AppendPath(availabilitySetChildName, true);
            uri.AppendPath("/availabilitySetGrandChildren/", false);
            uri.AppendPath(availabilitySetGrandChildName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Retrieves information about an availability set. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="availabilitySetName"/>, <paramref name="availabilitySetChildName"/> or <paramref name="availabilitySetGrandChildName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="availabilitySetName"/>, <paramref name="availabilitySetChildName"/> or <paramref name="availabilitySetGrandChildName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<AvailabilitySetGrandChildData>> GetAsync(string subscriptionId, string resourceGroupName, string availabilitySetName, string availabilitySetChildName, string availabilitySetGrandChildName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));
            Argument.AssertNotNullOrEmpty(availabilitySetChildName, nameof(availabilitySetChildName));
            Argument.AssertNotNullOrEmpty(availabilitySetGrandChildName, nameof(availabilitySetGrandChildName));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, availabilitySetName, availabilitySetChildName, availabilitySetGrandChildName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AvailabilitySetGrandChildData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AvailabilitySetGrandChildData.DeserializeAvailabilitySetGrandChildData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((AvailabilitySetGrandChildData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Retrieves information about an availability set. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="availabilitySetName"/>, <paramref name="availabilitySetChildName"/> or <paramref name="availabilitySetGrandChildName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="availabilitySetName"/>, <paramref name="availabilitySetChildName"/> or <paramref name="availabilitySetGrandChildName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<AvailabilitySetGrandChildData> Get(string subscriptionId, string resourceGroupName, string availabilitySetName, string availabilitySetChildName, string availabilitySetGrandChildName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));
            Argument.AssertNotNullOrEmpty(availabilitySetChildName, nameof(availabilitySetChildName));
            Argument.AssertNotNullOrEmpty(availabilitySetGrandChildName, nameof(availabilitySetGrandChildName));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, availabilitySetName, availabilitySetChildName, availabilitySetGrandChildName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AvailabilitySetGrandChildData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AvailabilitySetGrandChildData.DeserializeAvailabilitySetGrandChildData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((AvailabilitySetGrandChildData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string subscriptionId, string resourceGroupName, string availabilitySetName, string availabilitySetChildName, string availabilitySetGrandChildName, AvailabilitySetGrandChildData data)
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
            uri.AppendPath("/providers/Microsoft.Compute/availabilitySets/", false);
            uri.AppendPath(availabilitySetName, true);
            uri.AppendPath("/availabilitySetChildren/", false);
            uri.AppendPath(availabilitySetChildName, true);
            uri.AppendPath("/availabilitySetGrandChildren/", false);
            uri.AppendPath(availabilitySetGrandChildName, true);
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

        /// <summary> Create or update an availability set. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="data"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="availabilitySetName"/>, <paramref name="availabilitySetChildName"/>, <paramref name="availabilitySetGrandChildName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="availabilitySetName"/>, <paramref name="availabilitySetChildName"/> or <paramref name="availabilitySetGrandChildName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<AvailabilitySetGrandChildData>> CreateOrUpdateAsync(string subscriptionId, string resourceGroupName, string availabilitySetName, string availabilitySetChildName, string availabilitySetGrandChildName, AvailabilitySetGrandChildData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));
            Argument.AssertNotNullOrEmpty(availabilitySetChildName, nameof(availabilitySetChildName));
            Argument.AssertNotNullOrEmpty(availabilitySetGrandChildName, nameof(availabilitySetGrandChildName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(subscriptionId, resourceGroupName, availabilitySetName, availabilitySetChildName, availabilitySetGrandChildName, data);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AvailabilitySetGrandChildData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AvailabilitySetGrandChildData.DeserializeAvailabilitySetGrandChildData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Create or update an availability set. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="availabilitySetGrandChildName"> The name of the availability set grand child. </param>
        /// <param name="data"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="availabilitySetName"/>, <paramref name="availabilitySetChildName"/>, <paramref name="availabilitySetGrandChildName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="availabilitySetName"/>, <paramref name="availabilitySetChildName"/> or <paramref name="availabilitySetGrandChildName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<AvailabilitySetGrandChildData> CreateOrUpdate(string subscriptionId, string resourceGroupName, string availabilitySetName, string availabilitySetChildName, string availabilitySetGrandChildName, AvailabilitySetGrandChildData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));
            Argument.AssertNotNullOrEmpty(availabilitySetChildName, nameof(availabilitySetChildName));
            Argument.AssertNotNullOrEmpty(availabilitySetGrandChildName, nameof(availabilitySetGrandChildName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(subscriptionId, resourceGroupName, availabilitySetName, availabilitySetChildName, availabilitySetGrandChildName, data);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AvailabilitySetGrandChildData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AvailabilitySetGrandChildData.DeserializeAvailabilitySetGrandChildData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
