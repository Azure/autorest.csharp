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
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    internal partial class VirtualMachineScaleSetExtensionsRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of VirtualMachineScaleSetExtensionsRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public VirtualMachineScaleSetExtensionsRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-06-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string subscriptionId, string resourceGroupName, string vmScaleSetName, string vmssExtensionName, VirtualMachineScaleSetExtensionData data)
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
            uri.AppendPath("/providers/Microsoft.Compute/virtualMachineScaleSets/", false);
            uri.AppendPath(vmScaleSetName, true);
            uri.AppendPath("/extensions/", false);
            uri.AppendPath(vmssExtensionName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("x-ms-client-request-id", message.Request.ClientRequestId);
            request.Headers.Add("x-ms-return-client-request-id", "true");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(data);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> The operation to create or update an extension. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set where the extension should be create or updated. </param>
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="data"> Parameters supplied to the Create VM scale set Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/>, <paramref name="vmssExtensionName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/> or <paramref name="vmssExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> CreateOrUpdateAsync(string subscriptionId, string resourceGroupName, string vmScaleSetName, string vmssExtensionName, VirtualMachineScaleSetExtensionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));
            Argument.AssertNotNullOrEmpty(vmssExtensionName, nameof(vmssExtensionName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(subscriptionId, resourceGroupName, vmScaleSetName, vmssExtensionName, data);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> The operation to create or update an extension. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set where the extension should be create or updated. </param>
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="data"> Parameters supplied to the Create VM scale set Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/>, <paramref name="vmssExtensionName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/> or <paramref name="vmssExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response CreateOrUpdate(string subscriptionId, string resourceGroupName, string vmScaleSetName, string vmssExtensionName, VirtualMachineScaleSetExtensionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));
            Argument.AssertNotNullOrEmpty(vmssExtensionName, nameof(vmssExtensionName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(subscriptionId, resourceGroupName, vmScaleSetName, vmssExtensionName, data);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateUpdateRequest(string subscriptionId, string resourceGroupName, string vmScaleSetName, string vmssExtensionName, VirtualMachineScaleSetExtensionPatch patch)
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
            uri.AppendPath("/providers/Microsoft.Compute/virtualMachineScaleSets/", false);
            uri.AppendPath(vmScaleSetName, true);
            uri.AppendPath("/extensions/", false);
            uri.AppendPath(vmssExtensionName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("x-ms-client-request-id", message.Request.ClientRequestId);
            request.Headers.Add("x-ms-return-client-request-id", "true");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(patch);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> The operation to update an extension. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set where the extension should be updated. </param>
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="patch"> Parameters supplied to the Update VM scale set Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/>, <paramref name="vmssExtensionName"/> or <paramref name="patch"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/> or <paramref name="vmssExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> UpdateAsync(string subscriptionId, string resourceGroupName, string vmScaleSetName, string vmssExtensionName, VirtualMachineScaleSetExtensionPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));
            Argument.AssertNotNullOrEmpty(vmssExtensionName, nameof(vmssExtensionName));
            Argument.AssertNotNull(patch, nameof(patch));

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, vmScaleSetName, vmssExtensionName, patch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> The operation to update an extension. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set where the extension should be updated. </param>
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="patch"> Parameters supplied to the Update VM scale set Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/>, <paramref name="vmssExtensionName"/> or <paramref name="patch"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/> or <paramref name="vmssExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response Update(string subscriptionId, string resourceGroupName, string vmScaleSetName, string vmssExtensionName, VirtualMachineScaleSetExtensionPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));
            Argument.AssertNotNullOrEmpty(vmssExtensionName, nameof(vmssExtensionName));
            Argument.AssertNotNull(patch, nameof(patch));

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, vmScaleSetName, vmssExtensionName, patch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteRequest(string subscriptionId, string resourceGroupName, string vmScaleSetName, string vmssExtensionName)
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
            uri.AppendPath("/providers/Microsoft.Compute/virtualMachineScaleSets/", false);
            uri.AppendPath(vmScaleSetName, true);
            uri.AppendPath("/extensions/", false);
            uri.AppendPath(vmssExtensionName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("x-ms-client-request-id", message.Request.ClientRequestId);
            request.Headers.Add("x-ms-return-client-request-id", "true");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> The operation to delete the extension. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set where the extension should be deleted. </param>
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/> or <paramref name="vmssExtensionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/> or <paramref name="vmssExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> DeleteAsync(string subscriptionId, string resourceGroupName, string vmScaleSetName, string vmssExtensionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));
            Argument.AssertNotNullOrEmpty(vmssExtensionName, nameof(vmssExtensionName));

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, vmScaleSetName, vmssExtensionName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> The operation to delete the extension. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set where the extension should be deleted. </param>
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/> or <paramref name="vmssExtensionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/> or <paramref name="vmssExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response Delete(string subscriptionId, string resourceGroupName, string vmScaleSetName, string vmssExtensionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));
            Argument.AssertNotNullOrEmpty(vmssExtensionName, nameof(vmssExtensionName));

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, vmScaleSetName, vmssExtensionName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string subscriptionId, string resourceGroupName, string vmScaleSetName, string vmssExtensionName, string expand)
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
            uri.AppendPath("/providers/Microsoft.Compute/virtualMachineScaleSets/", false);
            uri.AppendPath(vmScaleSetName, true);
            uri.AppendPath("/extensions/", false);
            uri.AppendPath(vmssExtensionName, true);
            if (expand != null)
            {
                uri.AppendQuery("$expand", expand, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("x-ms-client-request-id", message.Request.ClientRequestId);
            request.Headers.Add("x-ms-return-client-request-id", "true");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> The operation to get the extension. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set containing the extension. </param>
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/> or <paramref name="vmssExtensionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/> or <paramref name="vmssExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<VirtualMachineScaleSetExtensionData>> GetAsync(string subscriptionId, string resourceGroupName, string vmScaleSetName, string vmssExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));
            Argument.AssertNotNullOrEmpty(vmssExtensionName, nameof(vmssExtensionName));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, vmScaleSetName, vmssExtensionName, expand);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VirtualMachineScaleSetExtensionData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = VirtualMachineScaleSetExtensionData.DeserializeVirtualMachineScaleSetExtensionData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((VirtualMachineScaleSetExtensionData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> The operation to get the extension. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set containing the extension. </param>
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/> or <paramref name="vmssExtensionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vmScaleSetName"/> or <paramref name="vmssExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<VirtualMachineScaleSetExtensionData> Get(string subscriptionId, string resourceGroupName, string vmScaleSetName, string vmssExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));
            Argument.AssertNotNullOrEmpty(vmssExtensionName, nameof(vmssExtensionName));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, vmScaleSetName, vmssExtensionName, expand);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VirtualMachineScaleSetExtensionData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = VirtualMachineScaleSetExtensionData.DeserializeVirtualMachineScaleSetExtensionData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((VirtualMachineScaleSetExtensionData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListRequest(string subscriptionId, string resourceGroupName, string vmScaleSetName)
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
            uri.AppendPath("/providers/Microsoft.Compute/virtualMachineScaleSets/", false);
            uri.AppendPath(vmScaleSetName, true);
            uri.AppendPath("/extensions", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("x-ms-client-request-id", message.Request.ClientRequestId);
            request.Headers.Add("x-ms-return-client-request-id", "true");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets a list of all extensions in a VM scale set. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set containing the extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="vmScaleSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<VirtualMachineScaleSetExtensionListResult>> ListAsync(string subscriptionId, string resourceGroupName, string vmScaleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));

            using var message = CreateListRequest(subscriptionId, resourceGroupName, vmScaleSetName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VirtualMachineScaleSetExtensionListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = VirtualMachineScaleSetExtensionListResult.DeserializeVirtualMachineScaleSetExtensionListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a list of all extensions in a VM scale set. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set containing the extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="vmScaleSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<VirtualMachineScaleSetExtensionListResult> List(string subscriptionId, string resourceGroupName, string vmScaleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));

            using var message = CreateListRequest(subscriptionId, resourceGroupName, vmScaleSetName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VirtualMachineScaleSetExtensionListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = VirtualMachineScaleSetExtensionListResult.DeserializeVirtualMachineScaleSetExtensionListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListNextPageRequest(string nextLink, string subscriptionId, string resourceGroupName, string vmScaleSetName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("x-ms-client-request-id", message.Request.ClientRequestId);
            request.Headers.Add("x-ms-return-client-request-id", "true");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets a list of all extensions in a VM scale set. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set containing the extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="vmScaleSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<VirtualMachineScaleSetExtensionListResult>> ListNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string vmScaleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));

            using var message = CreateListNextPageRequest(nextLink, subscriptionId, resourceGroupName, vmScaleSetName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VirtualMachineScaleSetExtensionListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = VirtualMachineScaleSetExtensionListResult.DeserializeVirtualMachineScaleSetExtensionListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a list of all extensions in a VM scale set. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set containing the extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="vmScaleSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<VirtualMachineScaleSetExtensionListResult> ListNextPage(string nextLink, string subscriptionId, string resourceGroupName, string vmScaleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(vmScaleSetName, nameof(vmScaleSetName));

            using var message = CreateListNextPageRequest(nextLink, subscriptionId, resourceGroupName, vmScaleSetName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VirtualMachineScaleSetExtensionListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = VirtualMachineScaleSetExtensionListResult.DeserializeVirtualMachineScaleSetExtensionListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
