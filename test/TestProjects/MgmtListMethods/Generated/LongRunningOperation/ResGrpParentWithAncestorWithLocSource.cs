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
    internal class ResGrpParentWithAncestorWithLocSource : IOperationSource<ResGrpParentWithAncestorWithLoc>
    {
        private readonly ArmClient _client;

        internal ResGrpParentWithAncestorWithLocSource(ArmClient client)
        {
            _client = client;
        }

        ResGrpParentWithAncestorWithLoc IOperationSource<ResGrpParentWithAncestorWithLoc>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = ResGrpParentWithAncestorWithLocData.DeserializeResGrpParentWithAncestorWithLocData(document.RootElement);
            return new ResGrpParentWithAncestorWithLoc(_client, data);
        }

        async ValueTask<ResGrpParentWithAncestorWithLoc> IOperationSource<ResGrpParentWithAncestorWithLoc>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = ResGrpParentWithAncestorWithLocData.DeserializeResGrpParentWithAncestorWithLocData(document.RootElement);
            return new ResGrpParentWithAncestorWithLoc(_client, data);
        }
    }
}
