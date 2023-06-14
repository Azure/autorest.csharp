// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Sample
{
    internal class VirtualMachineScaleSetVirtualMachineExtensionOperationSource : IOperationSource<VirtualMachineScaleSetVirtualMachineExtensionResource>
    {
        private readonly ArmClient _client;

        internal VirtualMachineScaleSetVirtualMachineExtensionOperationSource(ArmClient client)
        {
            _client = client;
        }

        VirtualMachineScaleSetVirtualMachineExtensionResource IOperationSource<VirtualMachineScaleSetVirtualMachineExtensionResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = VirtualMachineExtensionData.DeserializeVirtualMachineExtensionData(document.RootElement);
            return new VirtualMachineScaleSetVirtualMachineExtensionResource(_client, data);
        }

        async ValueTask<VirtualMachineScaleSetVirtualMachineExtensionResource> IOperationSource<VirtualMachineScaleSetVirtualMachineExtensionResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = VirtualMachineExtensionData.DeserializeVirtualMachineExtensionData(document.RootElement);
            return new VirtualMachineScaleSetVirtualMachineExtensionResource(_client, data);
        }
    }
}
