// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtMultipleParentResource
{
    internal class TheParentOperationSource : IOperationSource<TheParentResource>
    {
        private readonly ArmClient _client;

        internal TheParentOperationSource(ArmClient client)
        {
            _client = client;
        }

        TheParentResource IOperationSource<TheParentResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = TheParentData.DeserializeTheParentData(document.RootElement);
            return new TheParentResource(_client, data);
        }

        async ValueTask<TheParentResource> IOperationSource<TheParentResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = TheParentData.DeserializeTheParentData(document.RootElement);
            return new TheParentResource(_client, data);
        }
    }
}
