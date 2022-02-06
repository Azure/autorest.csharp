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

namespace MgmtListMethods
{
    internal class SubParentWithLocSource : IOperationSource<SubParentWithLoc>
    {
        private readonly ArmClient _client;

        internal SubParentWithLocSource(ArmClient client)
        {
            _client = client;
        }

        SubParentWithLoc IOperationSource<SubParentWithLoc>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = SubParentWithLocData.DeserializeSubParentWithLocData(document.RootElement);
            return new SubParentWithLoc(_client, data);
        }

        async ValueTask<SubParentWithLoc> IOperationSource<SubParentWithLoc>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = SubParentWithLocData.DeserializeSubParentWithLocData(document.RootElement);
            return new SubParentWithLoc(_client, data);
        }
    }
}
