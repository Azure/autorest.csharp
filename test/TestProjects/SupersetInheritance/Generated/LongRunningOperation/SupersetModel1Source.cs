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
    internal class SupersetModel1Source : IOperationSource<SupersetModel1>
    {
        private readonly ArmClient _client;

        internal SupersetModel1Source(ArmClient client)
        {
            _client = client;
        }

        SupersetModel1 IOperationSource<SupersetModel1>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = SupersetModel1Data.DeserializeSupersetModel1Data(document.RootElement);
            return new SupersetModel1(_client, data);
        }

        async ValueTask<SupersetModel1> IOperationSource<SupersetModel1>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = SupersetModel1Data.DeserializeSupersetModel1Data(document.RootElement);
            return new SupersetModel1(_client, data);
        }
    }
}
