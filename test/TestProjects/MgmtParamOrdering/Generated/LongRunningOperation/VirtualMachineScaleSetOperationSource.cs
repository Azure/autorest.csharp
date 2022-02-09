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

namespace MgmtParamOrdering
{
    internal class VirtualMachineScaleSetOperationSource : IOperationSource<VirtualMachineScaleSet>
    {
        private readonly ArmClient _client;

        internal VirtualMachineScaleSetOperationSource(ArmClient client)
        {
            _client = client;
        }

        VirtualMachineScaleSet IOperationSource<VirtualMachineScaleSet>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(document.RootElement);
            return new VirtualMachineScaleSet(_client, data);
        }

        async ValueTask<VirtualMachineScaleSet> IOperationSource<VirtualMachineScaleSet>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(document.RootElement);
            return new VirtualMachineScaleSet(_client, data);
        }
    }
}
