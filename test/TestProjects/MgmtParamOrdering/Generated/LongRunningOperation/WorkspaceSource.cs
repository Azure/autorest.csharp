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
    internal class WorkspaceSource : IOperationSource<Workspace>
    {
        private readonly ArmClient _client;

        internal WorkspaceSource(ArmClient client)
        {
            _client = client;
        }

        Workspace IOperationSource<Workspace>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = WorkspaceData.DeserializeWorkspaceData(document.RootElement);
            return new Workspace(_client, data);
        }

        async ValueTask<Workspace> IOperationSource<Workspace>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = WorkspaceData.DeserializeWorkspaceData(document.RootElement);
            return new Workspace(_client, data);
        }
    }
}
