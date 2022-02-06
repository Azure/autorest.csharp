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
    internal class FakeParentWithAncestorWithNonResChSource : IOperationSource<FakeParentWithAncestorWithNonResCh>
    {
        private readonly ArmClient _client;

        internal FakeParentWithAncestorWithNonResChSource(ArmClient client)
        {
            _client = client;
        }

        FakeParentWithAncestorWithNonResCh IOperationSource<FakeParentWithAncestorWithNonResCh>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = FakeParentWithAncestorWithNonResChData.DeserializeFakeParentWithAncestorWithNonResChData(document.RootElement);
            return new FakeParentWithAncestorWithNonResCh(_client, data);
        }

        async ValueTask<FakeParentWithAncestorWithNonResCh> IOperationSource<FakeParentWithAncestorWithNonResCh>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = FakeParentWithAncestorWithNonResChData.DeserializeFakeParentWithAncestorWithNonResChData(document.RootElement);
            return new FakeParentWithAncestorWithNonResCh(_client, data);
        }
    }
}
