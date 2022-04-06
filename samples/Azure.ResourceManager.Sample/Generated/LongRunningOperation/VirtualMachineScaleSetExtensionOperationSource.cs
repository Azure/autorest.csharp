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
    internal class VirtualMachineScaleSetExtensionOperationSource : IOperationSource<VirtualMachineScaleSetExtensionResource>
    {
        private readonly ArmClient _client;

        internal VirtualMachineScaleSetExtensionOperationSource(ArmClient client)
        {
            _client = client;
        }

        VirtualMachineScaleSetExtensionResource IOperationSource<VirtualMachineScaleSetExtensionResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = VirtualMachineScaleSetExtensionData.DeserializeVirtualMachineScaleSetExtensionData(document.RootElement);
            return new VirtualMachineScaleSetExtensionResource(_client, data);
        }

        async ValueTask<VirtualMachineScaleSetExtensionResource> IOperationSource<VirtualMachineScaleSetExtensionResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = VirtualMachineScaleSetExtensionData.DeserializeVirtualMachineScaleSetExtensionData(document.RootElement);
            return new VirtualMachineScaleSetExtensionResource(_client, data);
        }
    }
}
