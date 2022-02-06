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
    internal class SupersetModel6Source : IOperationSource<SupersetModel6>
    {
        private readonly ArmClient _client;

        internal SupersetModel6Source(ArmClient client)
        {
            _client = client;
        }

        SupersetModel6 IOperationSource<SupersetModel6>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = SupersetModel6Data.DeserializeSupersetModel6Data(document.RootElement);
            return new SupersetModel6(_client, data);
        }

        async ValueTask<SupersetModel6> IOperationSource<SupersetModel6>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = SupersetModel6Data.DeserializeSupersetModel6Data(document.RootElement);
            return new SupersetModel6(_client, data);
        }
    }
}
