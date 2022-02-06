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
    internal class SubParentWithNonResChWithLocSource : IOperationSource<SubParentWithNonResChWithLoc>
    {
        private readonly ArmClient _client;

        internal SubParentWithNonResChWithLocSource(ArmClient client)
        {
            _client = client;
        }

        SubParentWithNonResChWithLoc IOperationSource<SubParentWithNonResChWithLoc>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = SubParentWithNonResChWithLocData.DeserializeSubParentWithNonResChWithLocData(document.RootElement);
            return new SubParentWithNonResChWithLoc(_client, data);
        }

        async ValueTask<SubParentWithNonResChWithLoc> IOperationSource<SubParentWithNonResChWithLoc>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = SubParentWithNonResChWithLocData.DeserializeSubParentWithNonResChWithLocData(document.RootElement);
            return new SubParentWithNonResChWithLoc(_client, data);
        }
    }
}
