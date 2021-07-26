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
    internal partial class VirtualMachineExtensionsRestOperations
    {
        private string subscriptionId;
        private Uri endpoint;
        private string apiVersion;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of VirtualMachineExtensionsRestOperations. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="apiVersion"/> is null. </exception>
        public VirtualMachineExtensionsRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, Uri endpoint = null, string apiVersion = "2020-06-01")
        {
            this.subscriptionId = subscriptionId ?? throw new ArgumentNullException(nameof(subscriptionId));
            this.endpoint = endpoint ?? new Uri("https://management.azure.com");
            this.apiVersion = apiVersion ?? throw new ArgumentNullException(nameof(apiVersion));
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string resourceGroupName, string vmName, string vmExtensionName, VirtualMachineExtensionData extensionParameters)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/virtualMachines/", false);
            uri.AppendPath(vmName, true);
            uri.AppendPath("/extensions/", false);
            uri.AppendPath(vmExtensionName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(extensionParameters);
            request.Content = content;
            return message;
        }

        /// <summary> The operation to create or update the extension. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmName"> The name of the virtual machine where the extension should be created or updated. </param>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="vmName"/>, <paramref name="vmExtensionName"/>, or <paramref name="extensionParameters"/> is null. </exception>
        public async Task<Response> CreateOrUpdateAsync(string resourceGroupName, string vmName, string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }
            if (extensionParameters == null)
            {
                throw new ArgumentNullException(nameof(extensionParameters));
            }

            using var message = CreateCreateOrUpdateRequest(resourceGroupName, vmName, vmExtensionName, extensionParameters);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> The operation to create or update the extension. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmName"> The name of the virtual machine where the extension should be created or updated. </param>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="vmName"/>, <paramref name="vmExtensionName"/>, or <paramref name="extensionParameters"/> is null. </exception>
        public Response CreateOrUpdate(string resourceGroupName, string vmName, string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }
            if (extensionParameters == null)
            {
                throw new ArgumentNullException(nameof(extensionParameters));
            }

            using var message = CreateCreateOrUpdateRequest(resourceGroupName, vmName, vmExtensionName, extensionParameters);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateUpdateRequest(string resourceGroupName, string vmName, string vmExtensionName, VirtualMachineExtensionUpdate extensionParameters)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/virtualMachines/", false);
            uri.AppendPath(vmName, true);
            uri.AppendPath("/extensions/", false);
            uri.AppendPath(vmExtensionName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(extensionParameters);
            request.Content = content;
            return message;
        }

        /// <summary> The operation to update the extension. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmName"> The name of the virtual machine where the extension should be updated. </param>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Update Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="vmName"/>, <paramref name="vmExtensionName"/>, or <paramref name="extensionParameters"/> is null. </exception>
        public async Task<Response> UpdateAsync(string resourceGroupName, string vmName, string vmExtensionName, VirtualMachineExtensionUpdate extensionParameters, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }
            if (extensionParameters == null)
            {
                throw new ArgumentNullException(nameof(extensionParameters));
            }

            using var message = CreateUpdateRequest(resourceGroupName, vmName, vmExtensionName, extensionParameters);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> The operation to update the extension. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmName"> The name of the virtual machine where the extension should be updated. </param>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Update Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="vmName"/>, <paramref name="vmExtensionName"/>, or <paramref name="extensionParameters"/> is null. </exception>
        public Response Update(string resourceGroupName, string vmName, string vmExtensionName, VirtualMachineExtensionUpdate extensionParameters, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }
            if (extensionParameters == null)
            {
                throw new ArgumentNullException(nameof(extensionParameters));
            }

            using var message = CreateUpdateRequest(resourceGroupName, vmName, vmExtensionName, extensionParameters);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteRequest(string resourceGroupName, string vmName, string vmExtensionName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/virtualMachines/", false);
            uri.AppendPath(vmName, true);
            uri.AppendPath("/extensions/", false);
            uri.AppendPath(vmExtensionName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            return message;
        }

        /// <summary> The operation to delete the extension. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmName"> The name of the virtual machine where the extension should be deleted. </param>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="vmName"/>, or <paramref name="vmExtensionName"/> is null. </exception>
        public async Task<Response> DeleteAsync(string resourceGroupName, string vmName, string vmExtensionName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var message = CreateDeleteRequest(resourceGroupName, vmName, vmExtensionName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> The operation to delete the extension. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmName"> The name of the virtual machine where the extension should be deleted. </param>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="vmName"/>, or <paramref name="vmExtensionName"/> is null. </exception>
        public Response Delete(string resourceGroupName, string vmName, string vmExtensionName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var message = CreateDeleteRequest(resourceGroupName, vmName, vmExtensionName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string resourceGroupName, string vmName, string vmExtensionName, string expand)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/virtualMachines/", false);
            uri.AppendPath(vmName, true);
            uri.AppendPath("/extensions/", false);
            uri.AppendPath(vmExtensionName, true);
            if (expand != null)
            {
                uri.AppendQuery("$expand", expand, true);
            }
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> The operation to get the extension. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmName"> The name of the virtual machine containing the extension. </param>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="vmName"/>, or <paramref name="vmExtensionName"/> is null. </exception>
        public async Task<Response<VirtualMachineExtensionData>> GetAsync(string resourceGroupName, string vmName, string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var message = CreateGetRequest(resourceGroupName, vmName, vmExtensionName, expand);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VirtualMachineExtensionData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = VirtualMachineExtensionData.DeserializeVirtualMachineExtensionData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> The operation to get the extension. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmName"> The name of the virtual machine containing the extension. </param>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="vmName"/>, or <paramref name="vmExtensionName"/> is null. </exception>
        public Response<VirtualMachineExtensionData> Get(string resourceGroupName, string vmName, string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var message = CreateGetRequest(resourceGroupName, vmName, vmExtensionName, expand);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VirtualMachineExtensionData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = VirtualMachineExtensionData.DeserializeVirtualMachineExtensionData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListRequest(string resourceGroupName, string vmName, string expand)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/virtualMachines/", false);
            uri.AppendPath(vmName, true);
            uri.AppendPath("/extensions", false);
            if (expand != null)
            {
                uri.AppendQuery("$expand", expand, true);
            }
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> The operation to get all extensions of a Virtual Machine. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmName"> The name of the virtual machine containing the extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="vmName"/> is null. </exception>
        public async Task<Response<VirtualMachineExtensionsListResult>> ListAsync(string resourceGroupName, string vmName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }

            using var message = CreateListRequest(resourceGroupName, vmName, expand);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VirtualMachineExtensionsListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = VirtualMachineExtensionsListResult.DeserializeVirtualMachineExtensionsListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> The operation to get all extensions of a Virtual Machine. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="vmName"> The name of the virtual machine containing the extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="vmName"/> is null. </exception>
        public Response<VirtualMachineExtensionsListResult> List(string resourceGroupName, string vmName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }

            using var message = CreateListRequest(resourceGroupName, vmName, expand);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VirtualMachineExtensionsListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = VirtualMachineExtensionsListResult.DeserializeVirtualMachineExtensionsListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
