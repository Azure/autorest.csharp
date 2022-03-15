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
    internal class VirtualMachineResourceOperationSource : IOperationSource<VirtualMachineResource>
    {
        private readonly ArmClient _client;

        internal VirtualMachineResourceOperationSource(ArmClient client)
        {
            _client = client;
        }

        VirtualMachineResource IOperationSource<VirtualMachineResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = VirtualMachineResourceData.DeserializeVirtualMachineResourceData(document.RootElement);
            return new VirtualMachineResource(_client, data);
        }

        async ValueTask<VirtualMachineResource> IOperationSource<VirtualMachineResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = VirtualMachineResourceData.DeserializeVirtualMachineResourceData(document.RootElement);
            return new VirtualMachineResource(_client, data);
        }
    }
}
