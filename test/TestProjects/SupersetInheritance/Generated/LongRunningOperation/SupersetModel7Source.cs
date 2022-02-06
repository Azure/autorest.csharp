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

namespace SupersetInheritance
{
    internal class SupersetModel7Source : IOperationSource<SupersetModel7>
    {
        private readonly ArmClient _client;

        internal SupersetModel7Source(ArmClient client)
        {
            _client = client;
        }

        SupersetModel7 IOperationSource<SupersetModel7>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = SupersetModel7Data.DeserializeSupersetModel7Data(document.RootElement);
            return new SupersetModel7(_client, data);
        }

        async ValueTask<SupersetModel7> IOperationSource<SupersetModel7>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = SupersetModel7Data.DeserializeSupersetModel7Data(document.RootElement);
            return new SupersetModel7(_client, data);
        }
    }
}
