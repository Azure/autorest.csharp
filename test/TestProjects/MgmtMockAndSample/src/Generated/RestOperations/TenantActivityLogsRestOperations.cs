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
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    internal partial class TenantActivityLogsRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of TenantActivityLogsRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public TenantActivityLogsRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2015-04-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal RequestUriBuilder CreateListRequestUri(string filter, string select)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Insights/eventtypes/management/values", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, true);
            }
            if (select != null)
            {
                uri.AppendQuery("$select", select, true);
            }
            return uri;
        }

        internal HttpMessage CreateListRequest(string filter, string select)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Insights/eventtypes/management/values", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, true);
            }
            if (select != null)
            {
                uri.AppendQuery("$select", select, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets the Activity Logs for the Tenant.&lt;br&gt;Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.).&lt;br&gt;One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level. </summary>
        /// <param name="filter"> Reduces the set of data collected. &lt;br&gt;The **$filter** is very restricted and allows only the following patterns.&lt;br&gt;- List events for a resource group: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceGroupName eq '&lt;ResourceGroupName&gt;'.&lt;br&gt;- List events for resource: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceUri eq '&lt;ResourceURI&gt;'.&lt;br&gt;- List events for a subscription: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation'.&lt;br&gt;- List events for a resource provider: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceProvider eq '&lt;ResourceProviderName&gt;'.&lt;br&gt;- List events for a correlation Id: api-version=2014-04-01&amp;$filter=eventTimestamp ge '2014-07-16T04:36:37.6407898Z' and eventTimestamp le '2014-07-20T04:36:37.6407898Z' and eventChannels eq 'Admin, Operation' and correlationId eq '&lt;CorrelationID&gt;'.&lt;br&gt;**NOTE**: No other syntax is allowed. </param>
        /// <param name="select"> Used to fetch events with only the given properties.&lt;br&gt;The **$select** argument is a comma separated list of property names to be returned. Possible values are: *authorization*, *claims*, *correlationId*, *description*, *eventDataId*, *eventName*, *eventTimestamp*, *httpRequest*, *level*, *operationId*, *operationName*, *properties*, *resourceGroupName*, *resourceProviderName*, *resourceId*, *status*, *submissionTimestamp*, *subStatus*, *subscriptionId*. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<EventDataCollection>> ListAsync(string filter = null, string select = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateListRequest(filter, select);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        EventDataCollection value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = EventDataCollection.DeserializeEventDataCollection(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets the Activity Logs for the Tenant.&lt;br&gt;Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.).&lt;br&gt;One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level. </summary>
        /// <param name="filter"> Reduces the set of data collected. &lt;br&gt;The **$filter** is very restricted and allows only the following patterns.&lt;br&gt;- List events for a resource group: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceGroupName eq '&lt;ResourceGroupName&gt;'.&lt;br&gt;- List events for resource: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceUri eq '&lt;ResourceURI&gt;'.&lt;br&gt;- List events for a subscription: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation'.&lt;br&gt;- List events for a resource provider: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceProvider eq '&lt;ResourceProviderName&gt;'.&lt;br&gt;- List events for a correlation Id: api-version=2014-04-01&amp;$filter=eventTimestamp ge '2014-07-16T04:36:37.6407898Z' and eventTimestamp le '2014-07-20T04:36:37.6407898Z' and eventChannels eq 'Admin, Operation' and correlationId eq '&lt;CorrelationID&gt;'.&lt;br&gt;**NOTE**: No other syntax is allowed. </param>
        /// <param name="select"> Used to fetch events with only the given properties.&lt;br&gt;The **$select** argument is a comma separated list of property names to be returned. Possible values are: *authorization*, *claims*, *correlationId*, *description*, *eventDataId*, *eventName*, *eventTimestamp*, *httpRequest*, *level*, *operationId*, *operationName*, *properties*, *resourceGroupName*, *resourceProviderName*, *resourceId*, *status*, *submissionTimestamp*, *subStatus*, *subscriptionId*. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<EventDataCollection> List(string filter = null, string select = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateListRequest(filter, select);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        EventDataCollection value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = EventDataCollection.DeserializeEventDataCollection(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateListNextPageRequestUri(string nextLink, string filter, string select)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            return uri;
        }

        internal HttpMessage CreateListNextPageRequest(string nextLink, string filter, string select)
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

        /// <summary> Gets the Activity Logs for the Tenant.&lt;br&gt;Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.).&lt;br&gt;One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="filter"> Reduces the set of data collected. &lt;br&gt;The **$filter** is very restricted and allows only the following patterns.&lt;br&gt;- List events for a resource group: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceGroupName eq '&lt;ResourceGroupName&gt;'.&lt;br&gt;- List events for resource: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceUri eq '&lt;ResourceURI&gt;'.&lt;br&gt;- List events for a subscription: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation'.&lt;br&gt;- List events for a resource provider: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceProvider eq '&lt;ResourceProviderName&gt;'.&lt;br&gt;- List events for a correlation Id: api-version=2014-04-01&amp;$filter=eventTimestamp ge '2014-07-16T04:36:37.6407898Z' and eventTimestamp le '2014-07-20T04:36:37.6407898Z' and eventChannels eq 'Admin, Operation' and correlationId eq '&lt;CorrelationID&gt;'.&lt;br&gt;**NOTE**: No other syntax is allowed. </param>
        /// <param name="select"> Used to fetch events with only the given properties.&lt;br&gt;The **$select** argument is a comma separated list of property names to be returned. Possible values are: *authorization*, *claims*, *correlationId*, *description*, *eventDataId*, *eventName*, *eventTimestamp*, *httpRequest*, *level*, *operationId*, *operationName*, *properties*, *resourceGroupName*, *resourceProviderName*, *resourceId*, *status*, *submissionTimestamp*, *subStatus*, *subscriptionId*. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<EventDataCollection>> ListNextPageAsync(string nextLink, string filter = null, string select = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            using var message = CreateListNextPageRequest(nextLink, filter, select);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        EventDataCollection value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = EventDataCollection.DeserializeEventDataCollection(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets the Activity Logs for the Tenant.&lt;br&gt;Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.).&lt;br&gt;One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="filter"> Reduces the set of data collected. &lt;br&gt;The **$filter** is very restricted and allows only the following patterns.&lt;br&gt;- List events for a resource group: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceGroupName eq '&lt;ResourceGroupName&gt;'.&lt;br&gt;- List events for resource: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceUri eq '&lt;ResourceURI&gt;'.&lt;br&gt;- List events for a subscription: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation'.&lt;br&gt;- List events for a resource provider: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceProvider eq '&lt;ResourceProviderName&gt;'.&lt;br&gt;- List events for a correlation Id: api-version=2014-04-01&amp;$filter=eventTimestamp ge '2014-07-16T04:36:37.6407898Z' and eventTimestamp le '2014-07-20T04:36:37.6407898Z' and eventChannels eq 'Admin, Operation' and correlationId eq '&lt;CorrelationID&gt;'.&lt;br&gt;**NOTE**: No other syntax is allowed. </param>
        /// <param name="select"> Used to fetch events with only the given properties.&lt;br&gt;The **$select** argument is a comma separated list of property names to be returned. Possible values are: *authorization*, *claims*, *correlationId*, *description*, *eventDataId*, *eventName*, *eventTimestamp*, *httpRequest*, *level*, *operationId*, *operationName*, *properties*, *resourceGroupName*, *resourceProviderName*, *resourceId*, *status*, *submissionTimestamp*, *subStatus*, *subscriptionId*. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<EventDataCollection> ListNextPage(string nextLink, string filter = null, string select = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            using var message = CreateListNextPageRequest(nextLink, filter, select);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        EventDataCollection value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = EventDataCollection.DeserializeEventDataCollection(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
