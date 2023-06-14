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
    internal class VirtualMachineScaleSetVMOperationSource : IOperationSource<VirtualMachineScaleSetVMResource>
    {
        private readonly ArmClient _client;

        internal VirtualMachineScaleSetVMOperationSource(ArmClient client)
        {
            _client = client;
        }

        VirtualMachineScaleSetVMResource IOperationSource<VirtualMachineScaleSetVMResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = VirtualMachineScaleSetVMData.DeserializeVirtualMachineScaleSetVMData(document.RootElement);
            return new VirtualMachineScaleSetVMResource(_client, data);
        }

        async ValueTask<VirtualMachineScaleSetVMResource> IOperationSource<VirtualMachineScaleSetVMResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = VirtualMachineScaleSetVMData.DeserializeVirtualMachineScaleSetVMData(document.RootElement);
            return new VirtualMachineScaleSetVMResource(_client, data);
        }
    }
}
