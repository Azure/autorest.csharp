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

namespace MgmtScopeResource
{
    internal class PolicyAssignmentSource : IOperationSource<PolicyAssignment>
    {
        private readonly ArmClient _client;

        internal PolicyAssignmentSource(ArmClient client)
        {
            _client = client;
        }

        PolicyAssignment IOperationSource<PolicyAssignment>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = PolicyAssignmentData.DeserializePolicyAssignmentData(document.RootElement);
            return new PolicyAssignment(_client, data);
        }

        async ValueTask<PolicyAssignment> IOperationSource<PolicyAssignment>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = PolicyAssignmentData.DeserializePolicyAssignmentData(document.RootElement);
            return new PolicyAssignment(_client, data);
        }
    }
}
