// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtConstants
{
    internal class OptionalMachineOperationSource : IOperationSource<OptionalMachineResource>
    {
        private readonly ArmClient _client;

        internal OptionalMachineOperationSource(ArmClient client)
        {
            _client = client;
        }

        OptionalMachineResource IOperationSource<OptionalMachineResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = OptionalMachineData.DeserializeOptionalMachineData(document.RootElement);
            return new OptionalMachineResource(_client, data);
        }

        async ValueTask<OptionalMachineResource> IOperationSource<OptionalMachineResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = OptionalMachineData.DeserializeOptionalMachineData(document.RootElement);
            return new OptionalMachineResource(_client, data);
        }
    }
}
