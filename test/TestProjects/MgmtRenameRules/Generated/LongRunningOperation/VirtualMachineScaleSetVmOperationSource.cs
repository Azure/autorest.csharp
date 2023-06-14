// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtRenameRules
{
    internal class VirtualMachineScaleSetVmOperationSource : IOperationSource<VirtualMachineScaleSetVmResource>
    {
        private readonly ArmClient _client;

        internal VirtualMachineScaleSetVmOperationSource(ArmClient client)
        {
            _client = client;
        }

        VirtualMachineScaleSetVmResource IOperationSource<VirtualMachineScaleSetVmResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = VirtualMachineScaleSetVmData.DeserializeVirtualMachineScaleSetVmData(document.RootElement);
            return new VirtualMachineScaleSetVmResource(_client, data);
        }

        async ValueTask<VirtualMachineScaleSetVmResource> IOperationSource<VirtualMachineScaleSetVmResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = VirtualMachineScaleSetVmData.DeserializeVirtualMachineScaleSetVmData(document.RootElement);
            return new VirtualMachineScaleSetVmResource(_client, data);
        }
    }
}
