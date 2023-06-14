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
using MgmtExpandResourceTypes.Models;

namespace MgmtExpandResourceTypes
{
    internal partial class RecordSetsRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of RecordSetsRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public RecordSetsRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-09-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal HttpMessage CreateUpdateRequest(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, string relativeRecordSetName, RecordSetData data, string ifMatch)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Network/dnsZones/", false);
            uri.AppendPath(zoneName, true);
            uri.AppendPath("/", false);
            uri.AppendPath(recordType.ToSerialString(), true);
            uri.AppendPath("/", false);
            uri.AppendPath(relativeRecordSetName, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(data);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="recordType"> The type of DNS record in this record set. </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<RecordSetData>> UpdateAsync(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, string relativeRecordSetName, RecordSetData data, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, zoneName, recordType, relativeRecordSetName, data, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RecordSetData.DeserializeRecordSetData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="recordType"> The type of DNS record in this record set. </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<RecordSetData> Update(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, string relativeRecordSetName, RecordSetData data, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, zoneName, recordType, relativeRecordSetName, data, ifMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RecordSetData.DeserializeRecordSetData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, string relativeRecordSetName, RecordSetData data, string ifMatch, string ifNoneMatch)
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
            uri.AppendPath("/providers/Microsoft.Network/dnsZones/", false);
            uri.AppendPath(zoneName, true);
            uri.AppendPath("/", false);
            uri.AppendPath(recordType.ToSerialString(), true);
            uri.AppendPath("/", false);
            uri.AppendPath(relativeRecordSetName, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch);
            }
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(data);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="recordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<RecordSetData>> CreateOrUpdateAsync(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, string relativeRecordSetName, RecordSetData data, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(subscriptionId, resourceGroupName, zoneName, recordType, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        RecordSetData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RecordSetData.DeserializeRecordSetData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="recordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<RecordSetData> CreateOrUpdate(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, string relativeRecordSetName, RecordSetData data, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(subscriptionId, resourceGroupName, zoneName, recordType, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        RecordSetData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RecordSetData.DeserializeRecordSetData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteRequest(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, string relativeRecordSetName, string ifMatch)
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
            uri.AppendPath("/providers/Microsoft.Network/dnsZones/", false);
            uri.AppendPath(zoneName, true);
            uri.AppendPath("/", false);
            uri.AppendPath(recordType.ToSerialString(), true);
            uri.AppendPath("/", false);
            uri.AppendPath(relativeRecordSetName, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Deletes a record set from a DNS zone. This operation cannot be undone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="recordType"> The type of DNS record in this record set. Record sets of type SOA cannot be deleted (they are deleted when the DNS zone is deleted). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always delete the current record set. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> DeleteAsync(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, string relativeRecordSetName, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, zoneName, recordType, relativeRecordSetName, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Deletes a record set from a DNS zone. This operation cannot be undone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="recordType"> The type of DNS record in this record set. Record sets of type SOA cannot be deleted (they are deleted when the DNS zone is deleted). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always delete the current record set. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response Delete(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, string relativeRecordSetName, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, zoneName, recordType, relativeRecordSetName, ifMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, string relativeRecordSetName)
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
            uri.AppendPath("/providers/Microsoft.Network/dnsZones/", false);
            uri.AppendPath(zoneName, true);
            uri.AppendPath("/", false);
            uri.AppendPath(recordType.ToSerialString(), true);
            uri.AppendPath("/", false);
            uri.AppendPath(relativeRecordSetName, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="recordType"> The type of DNS record in this record set. </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<RecordSetData>> GetAsync(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, zoneName, recordType, relativeRecordSetName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RecordSetData.DeserializeRecordSetData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((RecordSetData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="recordType"> The type of DNS record in this record set. </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<RecordSetData> Get(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, zoneName, recordType, relativeRecordSetName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RecordSetData.DeserializeRecordSetData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((RecordSetData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListByTypeRequest(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, int? top, string recordsetnamesuffix)
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
            uri.AppendPath("/providers/Microsoft.Network/dnsZones/", false);
            uri.AppendPath(zoneName, true);
            uri.AppendPath("/", false);
            uri.AppendPath(recordType.ToSerialString(), true);
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            if (recordsetnamesuffix != null)
            {
                uri.AppendQuery("$recordsetnamesuffix", recordsetnamesuffix, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="recordType"> The type of record sets to enumerate. </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<RecordSetListResult>> ListByTypeAsync(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest(subscriptionId, resourceGroupName, zoneName, recordType, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="recordType"> The type of record sets to enumerate. </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<RecordSetListResult> ListByType(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest(subscriptionId, resourceGroupName, zoneName, recordType, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListByDnsZoneRequest(string subscriptionId, string resourceGroupName, string zoneName, int? top, string recordsetnamesuffix)
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
            uri.AppendPath("/providers/Microsoft.Network/dnsZones/", false);
            uri.AppendPath(zoneName, true);
            uri.AppendPath("/recordsets", false);
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            if (recordsetnamesuffix != null)
            {
                uri.AppendQuery("$recordsetnamesuffix", recordsetnamesuffix, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists all record sets in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<RecordSetListResult>> ListByDnsZoneAsync(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByDnsZoneRequest(subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all record sets in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<RecordSetListResult> ListByDnsZone(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByDnsZoneRequest(subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListAllByDnsZoneRequest(string subscriptionId, string resourceGroupName, string zoneName, int? top, string recordSetNameSuffix)
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
            uri.AppendPath("/providers/Microsoft.Network/dnsZones/", false);
            uri.AppendPath(zoneName, true);
            uri.AppendPath("/all", false);
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            if (recordSetNameSuffix != null)
            {
                uri.AppendQuery("$recordsetnamesuffix", recordSetNameSuffix, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists all record sets in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordSetNameSuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<RecordSetListResult>> ListAllByDnsZoneAsync(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordSetNameSuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListAllByDnsZoneRequest(subscriptionId, resourceGroupName, zoneName, top, recordSetNameSuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all record sets in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordSetNameSuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<RecordSetListResult> ListAllByDnsZone(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordSetNameSuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListAllByDnsZoneRequest(subscriptionId, resourceGroupName, zoneName, top, recordSetNameSuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListByTypeNextPageRequest(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, int? top, string recordsetnamesuffix)
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

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="recordType"> The type of record sets to enumerate. </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<RecordSetListResult>> ListByTypeNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, subscriptionId, resourceGroupName, zoneName, recordType, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="recordType"> The type of record sets to enumerate. </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<RecordSetListResult> ListByTypeNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, subscriptionId, resourceGroupName, zoneName, recordType, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListByDnsZoneNextPageRequest(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top, string recordsetnamesuffix)
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

        /// <summary> Lists all record sets in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<RecordSetListResult>> ListByDnsZoneNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByDnsZoneNextPageRequest(nextLink, subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all record sets in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<RecordSetListResult> ListByDnsZoneNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByDnsZoneNextPageRequest(nextLink, subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListAllByDnsZoneNextPageRequest(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top, string recordSetNameSuffix)
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

        /// <summary> Lists all record sets in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordSetNameSuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<RecordSetListResult>> ListAllByDnsZoneNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordSetNameSuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListAllByDnsZoneNextPageRequest(nextLink, subscriptionId, resourceGroupName, zoneName, top, recordSetNameSuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all record sets in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordSetNameSuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<RecordSetListResult> ListAllByDnsZoneNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordSetNameSuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListAllByDnsZoneNextPageRequest(nextLink, subscriptionId, resourceGroupName, zoneName, top, recordSetNameSuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
