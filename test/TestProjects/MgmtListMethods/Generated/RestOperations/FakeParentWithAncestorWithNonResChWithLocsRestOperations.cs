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
    internal partial class FakeParentWithAncestorWithNonResChWithLocsRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of FakeParentWithAncestorWithNonResChWithLocsRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public FakeParentWithAncestorWithNonResChWithLocsRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-06-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string subscriptionId, string fakeName, string fakeParentWithAncestorWithNonResChWithLocName, FakeParentWithAncestorWithNonResChWithLocData data)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Fake/fakes/", false);
            uri.AppendPath(fakeName, true);
            uri.AppendPath("/fakeParentWithAncestorWithNonResChWithLocs/", false);
            uri.AppendPath(fakeParentWithAncestorWithNonResChWithLocName, true);
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
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="fakeName"> Name. </param>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="fakeName"/>, <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="fakeName"/> or <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakeParentWithAncestorWithNonResChWithLocData>> CreateOrUpdateAsync(string subscriptionId, string fakeName, string fakeParentWithAncestorWithNonResChWithLocName, FakeParentWithAncestorWithNonResChWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChWithLocName, nameof(fakeParentWithAncestorWithNonResChWithLocName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(subscriptionId, fakeName, fakeParentWithAncestorWithNonResChWithLocName, data);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakeParentWithAncestorWithNonResChWithLocData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakeParentWithAncestorWithNonResChWithLocData.DeserializeFakeParentWithAncestorWithNonResChWithLocData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="fakeName"> Name. </param>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="fakeName"/>, <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="fakeName"/> or <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakeParentWithAncestorWithNonResChWithLocData> CreateOrUpdate(string subscriptionId, string fakeName, string fakeParentWithAncestorWithNonResChWithLocName, FakeParentWithAncestorWithNonResChWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChWithLocName, nameof(fakeParentWithAncestorWithNonResChWithLocName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(subscriptionId, fakeName, fakeParentWithAncestorWithNonResChWithLocName, data);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakeParentWithAncestorWithNonResChWithLocData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakeParentWithAncestorWithNonResChWithLocData.DeserializeFakeParentWithAncestorWithNonResChWithLocData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string subscriptionId, string fakeName, string fakeParentWithAncestorWithNonResChWithLocName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Fake/fakes/", false);
            uri.AppendPath(fakeName, true);
            uri.AppendPath("/fakeParentWithAncestorWithNonResChWithLocs/", false);
            uri.AppendPath(fakeParentWithAncestorWithNonResChWithLocName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="fakeName"> Name. </param>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="fakeName"/> or <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="fakeName"/> or <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakeParentWithAncestorWithNonResChWithLocData>> GetAsync(string subscriptionId, string fakeName, string fakeParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChWithLocName, nameof(fakeParentWithAncestorWithNonResChWithLocName));

            using var message = CreateGetRequest(subscriptionId, fakeName, fakeParentWithAncestorWithNonResChWithLocName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakeParentWithAncestorWithNonResChWithLocData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakeParentWithAncestorWithNonResChWithLocData.DeserializeFakeParentWithAncestorWithNonResChWithLocData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((FakeParentWithAncestorWithNonResChWithLocData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="fakeName"> Name. </param>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="fakeName"/> or <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="fakeName"/> or <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakeParentWithAncestorWithNonResChWithLocData> Get(string subscriptionId, string fakeName, string fakeParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChWithLocName, nameof(fakeParentWithAncestorWithNonResChWithLocName));

            using var message = CreateGetRequest(subscriptionId, fakeName, fakeParentWithAncestorWithNonResChWithLocName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakeParentWithAncestorWithNonResChWithLocData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakeParentWithAncestorWithNonResChWithLocData.DeserializeFakeParentWithAncestorWithNonResChWithLocData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((FakeParentWithAncestorWithNonResChWithLocData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListTestRequest(string subscriptionId, string fakeName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Fake/fakes/", false);
            uri.AppendPath(fakeName, true);
            uri.AppendPath("/fakeParentWithAncestorWithNonResChWithLocs", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="fakeName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="fakeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="fakeName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakeParentWithAncestorWithNonResChWithLocListResult>> ListTestAsync(string subscriptionId, string fakeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));

            using var message = CreateListTestRequest(subscriptionId, fakeName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakeParentWithAncestorWithNonResChWithLocListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakeParentWithAncestorWithNonResChWithLocListResult.DeserializeFakeParentWithAncestorWithNonResChWithLocListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="fakeName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="fakeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="fakeName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakeParentWithAncestorWithNonResChWithLocListResult> ListTest(string subscriptionId, string fakeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));

            using var message = CreateListTestRequest(subscriptionId, fakeName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakeParentWithAncestorWithNonResChWithLocListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakeParentWithAncestorWithNonResChWithLocListResult.DeserializeFakeParentWithAncestorWithNonResChWithLocListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListNonResourceChildRequest(string subscriptionId, string fakeName, string fakeParentWithAncestorWithNonResChWithLocName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Fake/fakes/", false);
            uri.AppendPath(fakeName, true);
            uri.AppendPath("/fakeParentWithAncestorWithNonResChWithLocs/", false);
            uri.AppendPath(fakeParentWithAncestorWithNonResChWithLocName, true);
            uri.AppendPath("/nonResourceChild", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists all. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="fakeName"> Name. </param>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="fakeName"/> or <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="fakeName"/> or <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<NonResourceChildListResult>> ListNonResourceChildAsync(string subscriptionId, string fakeName, string fakeParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChWithLocName, nameof(fakeParentWithAncestorWithNonResChWithLocName));

            using var message = CreateListNonResourceChildRequest(subscriptionId, fakeName, fakeParentWithAncestorWithNonResChWithLocName);
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
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="fakeName"> Name. </param>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="fakeName"/> or <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="fakeName"/> or <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<NonResourceChildListResult> ListNonResourceChild(string subscriptionId, string fakeName, string fakeParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChWithLocName, nameof(fakeParentWithAncestorWithNonResChWithLocName));

            using var message = CreateListNonResourceChildRequest(subscriptionId, fakeName, fakeParentWithAncestorWithNonResChWithLocName);
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

        internal HttpMessage CreateListBySubscriptionRequest(string subscriptionId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Fake/fakeParentWithAncestorWithNonResChWithLocs", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakeParentWithAncestorWithNonResChWithLocListResult>> ListBySubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var message = CreateListBySubscriptionRequest(subscriptionId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakeParentWithAncestorWithNonResChWithLocListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakeParentWithAncestorWithNonResChWithLocListResult.DeserializeFakeParentWithAncestorWithNonResChWithLocListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakeParentWithAncestorWithNonResChWithLocListResult> ListBySubscription(string subscriptionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var message = CreateListBySubscriptionRequest(subscriptionId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakeParentWithAncestorWithNonResChWithLocListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakeParentWithAncestorWithNonResChWithLocListResult.DeserializeFakeParentWithAncestorWithNonResChWithLocListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListTestByLocationsRequest(string subscriptionId, string location)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Fake/locations/", false);
            uri.AppendPath(location, true);
            uri.AppendPath("/nonResourceChild", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets all under the specified subscription for the specified location. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="location"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<NonResourceChildListResult>> ListTestByLocationsAsync(string subscriptionId, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            using var message = CreateListTestByLocationsRequest(subscriptionId, location);
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

        /// <summary> Gets all under the specified subscription for the specified location. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="location"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<NonResourceChildListResult> ListTestByLocations(string subscriptionId, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            using var message = CreateListTestByLocationsRequest(subscriptionId, location);
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

        internal HttpMessage CreateListTestNextPageRequest(string nextLink, string subscriptionId, string fakeName)
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
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="fakeName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/> or <paramref name="fakeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="fakeName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakeParentWithAncestorWithNonResChWithLocListResult>> ListTestNextPageAsync(string nextLink, string subscriptionId, string fakeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));

            using var message = CreateListTestNextPageRequest(nextLink, subscriptionId, fakeName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakeParentWithAncestorWithNonResChWithLocListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakeParentWithAncestorWithNonResChWithLocListResult.DeserializeFakeParentWithAncestorWithNonResChWithLocListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="fakeName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/> or <paramref name="fakeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="fakeName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakeParentWithAncestorWithNonResChWithLocListResult> ListTestNextPage(string nextLink, string subscriptionId, string fakeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));

            using var message = CreateListTestNextPageRequest(nextLink, subscriptionId, fakeName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakeParentWithAncestorWithNonResChWithLocListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakeParentWithAncestorWithNonResChWithLocListResult.DeserializeFakeParentWithAncestorWithNonResChWithLocListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListBySubscriptionNextPageRequest(string nextLink, string subscriptionId)
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

        /// <summary> Lists all in a subscription. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="subscriptionId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakeParentWithAncestorWithNonResChWithLocListResult>> ListBySubscriptionNextPageAsync(string nextLink, string subscriptionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var message = CreateListBySubscriptionNextPageRequest(nextLink, subscriptionId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakeParentWithAncestorWithNonResChWithLocListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakeParentWithAncestorWithNonResChWithLocListResult.DeserializeFakeParentWithAncestorWithNonResChWithLocListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all in a subscription. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="subscriptionId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakeParentWithAncestorWithNonResChWithLocListResult> ListBySubscriptionNextPage(string nextLink, string subscriptionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var message = CreateListBySubscriptionNextPageRequest(nextLink, subscriptionId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakeParentWithAncestorWithNonResChWithLocListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakeParentWithAncestorWithNonResChWithLocListResult.DeserializeFakeParentWithAncestorWithNonResChWithLocListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
