// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.Pipeline;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    internal partial class UsageRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly MessagePipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of UsageRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public UsageRestOperations(MessagePipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-06-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal PipelineMessage CreateListRequest(string subscriptionId, AzureLocation location)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.SetMethod("GET");
            var uri = new RequestUri();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Compute/locations/", false);
            uri.AppendPath(location.ToString(), true);
            uri.AppendPath("/usages", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri.ToUri();
            request.SetHeaderValue("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets, for the specified location, the current compute resource usage information as well as the limits for compute resources under the subscription. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="location"> The location for which resource usage is queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Result<ListUsagesResult>> ListAsync(string subscriptionId, AzureLocation location, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var message = CreateListRequest(subscriptionId, location);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ListUsagesResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.GetRawResponse().ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ListUsagesResult.DeserializeListUsagesResult(document.RootElement);
                        return Result.FromValue(value, message.Response);
                    }
                default:
                    throw new MessageFailedException(message.Response);
            }
        }

        /// <summary> Gets, for the specified location, the current compute resource usage information as well as the limits for compute resources under the subscription. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="location"> The location for which resource usage is queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public Result<ListUsagesResult> List(string subscriptionId, AzureLocation location, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var message = CreateListRequest(subscriptionId, location);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ListUsagesResult value = default;
                        using var document = JsonDocument.Parse(message.Response.GetRawResponse().ContentStream);
                        value = ListUsagesResult.DeserializeListUsagesResult(document.RootElement);
                        return Result.FromValue(value, message.Response);
                    }
                default:
                    throw new MessageFailedException(message.Response);
            }
        }

        internal PipelineMessage CreateListNextPageRequest(string nextLink, string subscriptionId, AzureLocation location)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.SetMethod("GET");
            var uri = new RequestUri();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri.ToUri();
            request.SetHeaderValue("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets, for the specified location, the current compute resource usage information as well as the limits for compute resources under the subscription. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="location"> The location for which resource usage is queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="subscriptionId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Result<ListUsagesResult>> ListNextPageAsync(string nextLink, string subscriptionId, AzureLocation location, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNull(nextLink, nameof(nextLink));
            ClientUtilities.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var message = CreateListNextPageRequest(nextLink, subscriptionId, location);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ListUsagesResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.GetRawResponse().ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ListUsagesResult.DeserializeListUsagesResult(document.RootElement);
                        return Result.FromValue(value, message.Response);
                    }
                default:
                    throw new MessageFailedException(message.Response);
            }
        }

        /// <summary> Gets, for the specified location, the current compute resource usage information as well as the limits for compute resources under the subscription. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="location"> The location for which resource usage is queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="subscriptionId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public Result<ListUsagesResult> ListNextPage(string nextLink, string subscriptionId, AzureLocation location, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNull(nextLink, nameof(nextLink));
            ClientUtilities.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var message = CreateListNextPageRequest(nextLink, subscriptionId, location);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ListUsagesResult value = default;
                        using var document = JsonDocument.Parse(message.Response.GetRawResponse().ContentStream);
                        value = ListUsagesResult.DeserializeListUsagesResult(document.RootElement);
                        return Result.FromValue(value, message.Response);
                    }
                default:
                    throw new MessageFailedException(message.Response);
            }
        }
    }
}
