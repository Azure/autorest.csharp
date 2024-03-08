// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Sample
{
    internal partial class VirtualMachineExtensionImagesRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of VirtualMachineExtensionImagesRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public VirtualMachineExtensionImagesRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-06-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal RequestUriBuilder CreateGetRequestUri(string subscriptionId, AzureLocation location, string publisherName, string type, string version)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Compute/locations/", false);
            uri.AppendPath(location, true);
            uri.AppendPath("/publishers/", false);
            uri.AppendPath(publisherName, true);
            uri.AppendPath("/artifacttypes/vmextension/types/", false);
            uri.AppendPath(type, true);
            uri.AppendPath("/versions/", false);
            uri.AppendPath(version, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateGetRequest(string subscriptionId, AzureLocation location, string publisherName, string type, string version)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Compute/locations/", false);
            uri.AppendPath(location, true);
            uri.AppendPath("/publishers/", false);
            uri.AppendPath(publisherName, true);
            uri.AppendPath("/artifacttypes/vmextension/types/", false);
            uri.AppendPath(type, true);
            uri.AppendPath("/versions/", false);
            uri.AppendPath(version, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets a virtual machine extension image. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The <see cref="string"/> to use. </param>
        /// <param name="type"> The <see cref="string"/> to use. </param>
        /// <param name="version"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<VirtualMachineExtensionImageData>> GetAsync(string subscriptionId, AzureLocation location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));
            Argument.AssertNotNullOrEmpty(type, nameof(type));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using var message = CreateGetRequest(subscriptionId, location, publisherName, type, version);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VirtualMachineExtensionImageData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = VirtualMachineExtensionImageData.DeserializeVirtualMachineExtensionImageData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((VirtualMachineExtensionImageData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a virtual machine extension image. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The <see cref="string"/> to use. </param>
        /// <param name="type"> The <see cref="string"/> to use. </param>
        /// <param name="version"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<VirtualMachineExtensionImageData> Get(string subscriptionId, AzureLocation location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));
            Argument.AssertNotNullOrEmpty(type, nameof(type));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using var message = CreateGetRequest(subscriptionId, location, publisherName, type, version);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VirtualMachineExtensionImageData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = VirtualMachineExtensionImageData.DeserializeVirtualMachineExtensionImageData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((VirtualMachineExtensionImageData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateListTypesRequestUri(string subscriptionId, AzureLocation location, string publisherName)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Compute/locations/", false);
            uri.AppendPath(location, true);
            uri.AppendPath("/publishers/", false);
            uri.AppendPath(publisherName, true);
            uri.AppendPath("/artifacttypes/vmextension/types", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateListTypesRequest(string subscriptionId, AzureLocation location, string publisherName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Compute/locations/", false);
            uri.AppendPath(location, true);
            uri.AppendPath("/publishers/", false);
            uri.AppendPath(publisherName, true);
            uri.AppendPath("/artifacttypes/vmextension/types", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets a list of virtual machine extension image types. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="publisherName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="publisherName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<IReadOnlyList<VirtualMachineExtensionImageData>>> ListTypesAsync(string subscriptionId, AzureLocation location, string publisherName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));

            using var message = CreateListTypesRequest(subscriptionId, location, publisherName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<VirtualMachineExtensionImageData> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<VirtualMachineExtensionImageData> array = new List<VirtualMachineExtensionImageData>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(VirtualMachineExtensionImageData.DeserializeVirtualMachineExtensionImageData(item));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a list of virtual machine extension image types. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="publisherName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="publisherName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<IReadOnlyList<VirtualMachineExtensionImageData>> ListTypes(string subscriptionId, AzureLocation location, string publisherName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));

            using var message = CreateListTypesRequest(subscriptionId, location, publisherName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<VirtualMachineExtensionImageData> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<VirtualMachineExtensionImageData> array = new List<VirtualMachineExtensionImageData>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(VirtualMachineExtensionImageData.DeserializeVirtualMachineExtensionImageData(item));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateListVersionsRequestUri(string subscriptionId, AzureLocation location, string publisherName, string type, string filter, int? top, string orderby)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Compute/locations/", false);
            uri.AppendPath(location, true);
            uri.AppendPath("/publishers/", false);
            uri.AppendPath(publisherName, true);
            uri.AppendPath("/artifacttypes/vmextension/types/", false);
            uri.AppendPath(type, true);
            uri.AppendPath("/versions", false);
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, true);
            }
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            if (orderby != null)
            {
                uri.AppendQuery("$orderby", orderby, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateListVersionsRequest(string subscriptionId, AzureLocation location, string publisherName, string type, string filter, int? top, string orderby)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Compute/locations/", false);
            uri.AppendPath(location, true);
            uri.AppendPath("/publishers/", false);
            uri.AppendPath(publisherName, true);
            uri.AppendPath("/artifacttypes/vmextension/types/", false);
            uri.AppendPath(type, true);
            uri.AppendPath("/versions", false);
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, true);
            }
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            if (orderby != null)
            {
                uri.AppendQuery("$orderby", orderby, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets a list of virtual machine extension image versions. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The <see cref="string"/> to use. </param>
        /// <param name="type"> The <see cref="string"/> to use. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The <see cref="int"/>? to use. </param>
        /// <param name="orderby"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="publisherName"/> or <paramref name="type"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="publisherName"/> or <paramref name="type"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<IReadOnlyList<VirtualMachineExtensionImageData>>> ListVersionsAsync(string subscriptionId, AzureLocation location, string publisherName, string type, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));
            Argument.AssertNotNullOrEmpty(type, nameof(type));

            using var message = CreateListVersionsRequest(subscriptionId, location, publisherName, type, filter, top, orderby);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<VirtualMachineExtensionImageData> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<VirtualMachineExtensionImageData> array = new List<VirtualMachineExtensionImageData>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(VirtualMachineExtensionImageData.DeserializeVirtualMachineExtensionImageData(item));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a list of virtual machine extension image versions. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The <see cref="string"/> to use. </param>
        /// <param name="type"> The <see cref="string"/> to use. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The <see cref="int"/>? to use. </param>
        /// <param name="orderby"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="publisherName"/> or <paramref name="type"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="publisherName"/> or <paramref name="type"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<IReadOnlyList<VirtualMachineExtensionImageData>> ListVersions(string subscriptionId, AzureLocation location, string publisherName, string type, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));
            Argument.AssertNotNullOrEmpty(type, nameof(type));

            using var message = CreateListVersionsRequest(subscriptionId, location, publisherName, type, filter, top, orderby);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<VirtualMachineExtensionImageData> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<VirtualMachineExtensionImageData> array = new List<VirtualMachineExtensionImageData>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(VirtualMachineExtensionImageData.DeserializeVirtualMachineExtensionImageData(item));
                        }
                        value = array;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
