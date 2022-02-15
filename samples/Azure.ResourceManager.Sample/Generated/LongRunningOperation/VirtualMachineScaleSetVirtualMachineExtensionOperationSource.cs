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
    internal class VirtualMachineScaleSetVirtualMachineExtensionOperationSource : IOperationSource<VirtualMachineScaleSetVirtualMachineExtension>
    {
        private readonly ArmClient _client;

        internal VirtualMachineScaleSetVirtualMachineExtensionOperationSource(ArmClient client)
        {
            _client = client;
        }

        VirtualMachineScaleSetVirtualMachineExtension IOperationSource<VirtualMachineScaleSetVirtualMachineExtension>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            try
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var data = VirtualMachineExtensionData.DeserializeVirtualMachineExtensionData(document.RootElement);
                return new VirtualMachineScaleSetVirtualMachineExtension(_client, data);
            }
            finally
            {
                response.ContentStream.Position = 0;
            }
        }

        async ValueTask<VirtualMachineScaleSetVirtualMachineExtension> IOperationSource<VirtualMachineScaleSetVirtualMachineExtension>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            try
            {
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var data = VirtualMachineExtensionData.DeserializeVirtualMachineExtensionData(document.RootElement);
                return new VirtualMachineScaleSetVirtualMachineExtension(_client, data);
            }
            finally
            {
                response.ContentStream.Position = 0;
            }
        }
    }
}
