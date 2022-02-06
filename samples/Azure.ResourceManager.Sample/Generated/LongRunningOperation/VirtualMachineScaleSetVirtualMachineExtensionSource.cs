// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Sample
{
    internal class VirtualMachineScaleSetVirtualMachineExtensionSource : IOperationSource<VirtualMachineScaleSetVirtualMachineExtension>
    {
        private readonly ArmClient _client;

        internal VirtualMachineScaleSetVirtualMachineExtensionSource(ArmClient client)
        {
            _client = client;
        }

        VirtualMachineScaleSetVirtualMachineExtension IOperationSource<VirtualMachineScaleSetVirtualMachineExtension>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = VirtualMachineExtensionData.DeserializeVirtualMachineExtensionData(document.RootElement);
            return new VirtualMachineScaleSetVirtualMachineExtension(_client, data);
        }

        async ValueTask<VirtualMachineScaleSetVirtualMachineExtension> IOperationSource<VirtualMachineScaleSetVirtualMachineExtension>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = VirtualMachineExtensionData.DeserializeVirtualMachineExtensionData(document.RootElement);
            return new VirtualMachineScaleSetVirtualMachineExtension(_client, data);
        }
    }
}
