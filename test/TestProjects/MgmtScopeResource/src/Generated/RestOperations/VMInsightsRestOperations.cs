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

namespace MgmtScopeResource
{
    internal partial class VMInsightsRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of VMInsightsRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public VMInsightsRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2018-11-27-preview";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal RequestUriBuilder CreateGetOnboardingStatusRequestUri(string resourceUri)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.Insights/vmInsightsOnboardingStatuses/default", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateGetOnboardingStatusRequest(string resourceUri)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.Insights/vmInsightsOnboardingStatuses/default", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Retrieves the VM Insights onboarding status for the specified resource or resource scope. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the resource, or scope, whose status to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> is null. </exception>
        public async Task<Response<VMInsightsOnboardingStatusData>> GetOnboardingStatusAsync(string resourceUri, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateGetOnboardingStatusRequest(resourceUri);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VMInsightsOnboardingStatusData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = VMInsightsOnboardingStatusData.DeserializeVMInsightsOnboardingStatusData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((VMInsightsOnboardingStatusData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Retrieves the VM Insights onboarding status for the specified resource or resource scope. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the resource, or scope, whose status to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> is null. </exception>
        public Response<VMInsightsOnboardingStatusData> GetOnboardingStatus(string resourceUri, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateGetOnboardingStatusRequest(resourceUri);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VMInsightsOnboardingStatusData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = VMInsightsOnboardingStatusData.DeserializeVMInsightsOnboardingStatusData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((VMInsightsOnboardingStatusData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
